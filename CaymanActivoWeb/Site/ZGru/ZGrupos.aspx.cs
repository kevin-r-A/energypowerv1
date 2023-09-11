using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

public partial class ZGrupos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            cargarGrupos();
            CargaAprobadoresGru();
            CargaAprobadoresSubGru();
            CargaAprobadoresDesc();
            this.Title = ConfigurationManager.AppSettings["Titulo"] + " Catálogos - Grupo/Subgrupo/Descripción";
        }
    }
    private void cargarGrupos()
    { 
        Logica.GRUPO gr= new Logica.GRUPO();
        rlbgrupos.DataSource = gr.fGetGrupos1();
        rlbgrupos.DataTextField = "nombre";
        rlbgrupos.DataValueField = "id";
        rlbgrupos.DataBind();
        upgru.Update();
    }

    protected void rlbgrupos_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarSubgrupo();
        CargaAprobadoresGru();
        CargaAprobadoresSubGru();
        CargaAprobadoresDesc();
    }

    private void cargarSubgrupo()
    {
        rlbdescripcion.Items.Clear();
        updes.Update();
        Logica.GRUPO gr = new Logica.GRUPO();
        rlbsubgrupo.DataSource = gr.fGetHijos(2, int.Parse(rlbgrupos.SelectedValue.ToString()));
        rlbsubgrupo.DataTextField = "gru_nombre";
        rlbsubgrupo.DataValueField = "gru_id";
        rlbsubgrupo.DataBind();
        upsub.Update();
    }
    
    protected void rlbsubgrupo_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarDescripcion();
        CargaAprobadoresSubGru();
        CargaAprobadoresDesc();
    }

    private void cargarDescripcion()
    {
        Logica.GRUPO gr = new Logica.GRUPO();
        rlbdescripcion.DataSource = gr.fGetHijos(3, int.Parse(rlbsubgrupo.SelectedValue.ToString()));
        rlbdescripcion.DataTextField = "gru_nombre";
        rlbdescripcion.DataValueField = "gru_id";
        rlbdescripcion.DataBind();
        updes.Update();
    }

    protected void ibgr1_Click(object sender, ImageClickEventArgs e)
    {
        lblmp.Text = "Nuevo Grupo";
        upnuevo.Update();
        mpnuevo.Show();
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        if (lblmp.Text == "Editar Grupo")
        {
            Logica.GRUPO gr = new Logica.GRUPO();
            gr.GRU_NOMBRE = Logica.HELPER.capitalize(txtnombre.Text);
            gr.Id = int.Parse(rlbgrupos.SelectedValue);
            gr.GRU_CODIGO = txtcodigo.Text;
            gr.GRU_CTA1 = txtcta1.Text;
            gr.GRU_CTA2 = txtcta2.Text;
            gr.GRU_CTA3 = txtcta3.Text;
            gr.fUpdGrupo(int.Parse(txtvu.Text));
            cargarGrupos();
            rlbgrupos.SelectedValue = gr.Id.ToString();  
        }
        else
        {
            Logica.GRUPO gr = new Logica.GRUPO();
            gr.GRU_NOMBRE = Logica.HELPER.capitalize(txtnombre.Text);
            gr.GRU_PADRE = 0;
            gr.GRU_NIVEL = 1;
            gr.GRU_CODIGO = txtcodigo.Text;
            gr.GRU_CTA1 = txtcta1.Text;
            gr.GRU_CTA2 = txtcta2.Text;
            gr.GRU_CTA3 = txtcta3.Text;
            gr.fAddGrupo(int.Parse(txtvu.Text));           
            cargarGrupos();
            rlbsubgrupo.Items.Clear();
            rlbdescripcion.Items.Clear();   
        }

        txtnombre.Text = "";
        txtvu.Text = "";
        txtcta1.Text = "";
        txtcta2.Text = "";
        txtcta3.Text = "";
        txtcodigo.Text = "";
        upnuevo.Update();
        mpnuevo.Hide();
    }
 
    protected void btncerrar_Click(object sender, EventArgs e)
    {
        txtnombre.Text = "";
        txtvu.Text = "";
        upnuevo.Update();
        mpnuevo.Hide();
    }
    protected void ibgr2_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbgrupos.SelectedItem != null)
        {
            Logica.GRUPO gr = new Logica.GRUPO(int.Parse(rlbgrupos.SelectedValue));
            lblmp.Text = "Editar Grupo";
            string[] grupo = rlbgrupos.SelectedItem.Text.Split('-');
            txtnombre.Text = Logica.HELPER.capitalize(grupo[0].ToString().Trim());
            txtvu.Text = Logica.HELPER.getVuSriGrupo(rlbgrupos.SelectedValue);
            txtcodigo.Text = Logica.HELPER.getCodigoGrupo(rlbgrupos.SelectedValue);
            txtcta1.Text = gr.GRU_CTA1;
            txtcta2.Text = gr.GRU_CTA2;
            txtcta3.Text = gr.GRU_CTA3;
            //txtvu.Enabled = false;
            upnuevo.Update();
            mpnuevo.Show();
        }
        txtcodigo.Text = "";
        txtnombre.Text = "";
    }
    protected void ibgr3_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbgrupos.SelectedItem != null)
        {
            Logica.GRUPO gr = new Logica.GRUPO();
            int activos = gr.fcheckActivo(rlbgrupos.SelectedValue);
            if (activos == 0)
            {
                gr.Id = int.Parse(rlbgrupos.SelectedValue);
                gr.fDelGrupo();
                cargarGrupos();
                rlbsubgrupo.Items.Clear();
                rlbdescripcion.Items.Clear();
                upsub.Update();
                updes.Update();
            }
            else
            {
                messbox1.Mensaje = "No se pudo eliminar el Grupo ya que esta referenciado en " + activos + " activo(s)";
                messbox1.Tipo = "E";
                messbox1.showMess();
            }
        }
    }
    protected void btncerrar2_Click(object sender, EventArgs e)
    {
        txtnombre2.Text = "";
        upnuevo2.Update();
        mp2.Hide();
    }
    protected void ibgr4_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbgrupos.SelectedItem != null)
        {
            lblmp2.Text = "Nuevo SubGrupo";
            upnuevo2.Update();
            mp2.Show();
        }
    }
    protected void ibgr5_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbsubgrupo.SelectedItem != null)
        {
            lblmp2.Text = "Editar SubGrupo";
            string[] grupo = rlbsubgrupo.SelectedItem.Text.Split('-');
            txtnombre2.Text = grupo[0].ToString().Trim();
            txtcodigo2.Text = Logica.HELPER.getCodigoGrupo(rlbsubgrupo.SelectedValue);
            upnuevo2.Update();
            mp2.Show();
        }

    }
    protected void ibgr6_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbsubgrupo.SelectedItem != null)
        {
            Logica.GRUPO gr = new Logica.GRUPO();
            int activos = gr.fcheckActivo(rlbsubgrupo.SelectedValue);
            if (activos == 0)
            {
                gr.Id = int.Parse(rlbsubgrupo.SelectedValue);
                gr.fDelGrupo2();
                cargarSubgrupo();
                rlbdescripcion.Items.Clear();
                updes.Update();
            }
            else
            {
                messbox1.Mensaje = "No se pudo eliminar el SubGrupo ya que esta referenciado en " + activos + " activo(s)";
                messbox1.Tipo = "E";
                messbox1.showMess();
            }
        }
    }
    protected void btnsave2_Click(object sender, EventArgs e)
    {        
        if (lblmp2.Text == "Editar SubGrupo")
        {
            Logica.GRUPO gr = new Logica.GRUPO();
            gr.fUpdNombre(Logica.HELPER.capitalize(txtnombre2.Text), rlbsubgrupo.SelectedValue, txtcodigo2.Text);
            cargarSubgrupo();
            rlbsubgrupo.SelectedValue = gr.Id.ToString();
        }
        else if (lblmp2.Text == "Nuevo SubGrupo")
        {
            Logica.GRUPO gr = new Logica.GRUPO();
            if (!gr.fgetGruIng(Logica.HELPER.capitalize(txtnombre2.Text), rlbgrupos.SelectedValue))
            {                
                gr.GRU_NOMBRE = Logica.HELPER.capitalize(txtnombre2.Text);
                gr.GRU_PADRE = int.Parse(rlbgrupos.SelectedValue);
                gr.GRU_NIVEL = 2;
                gr.GRU_CODIGO = txtcodigo2.Text;
                gr.fAddGrupo(-1);
                cargarSubgrupo();
                rlbdescripcion.Items.Clear();
            }               
        }
        else if (lblmp2.Text == "Editar Descripción")
        {
            Logica.GRUPO gr = new Logica.GRUPO();
            gr.fUpdNombre(Logica.HELPER.capitalize(txtnombre2.Text), rlbdescripcion.SelectedValue, txtcodigo2.Text);
            cargarDescripcion();
            rlbdescripcion.SelectedValue = gr.Id.ToString();
        }
        else if (lblmp2.Text == "Nueva Descripción")
        {
            Logica.GRUPO gr = new Logica.GRUPO();
            if (!gr.fgetGruIng(Logica.HELPER.capitalize(txtnombre2.Text), rlbsubgrupo.SelectedValue))
            {                
                gr.GRU_NOMBRE = Logica.HELPER.capitalize(txtnombre2.Text);
                gr.GRU_PADRE = int.Parse(rlbsubgrupo.SelectedValue);
                gr.GRU_NIVEL = 3;
                gr.GRU_CODIGO = txtcodigo2.Text;
                gr.fAddGrupo(-1);
                cargarDescripcion();
            }
        }
        mp2.Hide();
        txtnombre2.Text = "";
        txtcodigo2.Text = "";
        upnuevo2.Update();
    }
    protected void ibgr7_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbsubgrupo.SelectedItem != null)
        {
            lblmp2.Text = "Nueva Descripción";
            upnuevo2.Update();
            mp2.Show();
        }
    }
    protected void ibgr8_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbdescripcion.SelectedItem != null)
        {
            lblmp2.Text = "Editar Descripción";
            string[] grupo = rlbdescripcion.SelectedItem.Text.Split('-');
            txtnombre2.Text = grupo[0].ToString().Trim();
            txtcodigo2.Text = Logica.HELPER.getCodigoGrupo(rlbdescripcion.SelectedValue);
            upnuevo2.Update();
            mp2.Show();
        }
    }
    protected void ibgr9_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbdescripcion.SelectedItem != null)
        {
            Logica.GRUPO gr = new Logica.GRUPO();
            int activos = gr.fcheckActivo(rlbdescripcion.SelectedValue);
            if (activos == 0)
            {
                gr.Id = int.Parse(rlbdescripcion.SelectedValue);
                gr.fDelGrupo3();
                cargarDescripcion();
            }
            else
            {
                messbox1.Mensaje = "No se pudo eliminar la Descripción ya que esta referenciado en " + activos + " activo(s)";
                messbox1.Tipo = "E";
                messbox1.showMess();
            }
        }
    }

    //APROBADORES POR GRUPO
    protected void ibgr4trasladosGru_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbgrupos.SelectedItem != null)
        {
            lblmp3.Text = "Nuevo Aprobador Traslados";
            ddUsuario.ClearSelection();
            ugeIdSelected.Value = rlbgrupos.SelectedValue;
            nivelSelected.Value = "1";
            tipoSelected.Value = "0";
            upnuevo3.Update();
            mp3.Show();
        }
    }
    protected void ibgr5trasladosGru_Click(object sender, ImageClickEventArgs e)
    {
        if (rblTrasladoGru.SelectedItem != null)
        {
            DataTable table = Logica.HELPER.getAprobadorGrupo(int.Parse(rblTrasladoGru.SelectedValue));
            lblmp3.Text = "Editar Aprobador Traslados";
            cddUsuario.SelectedValue = Logica.HELPER.getUsuario(rblTrasladoGru.SelectedItem.Text);
            nivelSelected.Value = "1";
            tipoSelected.Value = "0";
            idSelected.Value = rblTrasladoGru.SelectedValue;
            ordenSelected.Value = table.Rows[0]["APRGRU_ORDEN"].ToString();
            upnuevo3.Update();
            mp3.Show();
        }
    }

    protected void ibgr6trasladosGru_Click(object sender, ImageClickEventArgs e)
    {
        if (rblTrasladoGru.SelectedItem != null)
        {
            Logica.HELPER.delAprobadorGrupo(int.Parse(rblTrasladoGru.SelectedValue));
            CargaAprobadoresGru();
        }
    }
    protected void ibgr4bajasGru_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbgrupos.SelectedItem != null)
        {
            lblmp3.Text = "Nuevo Aprobador Bajas";
            ddUsuario.ClearSelection();
            ugeIdSelected.Value = rlbgrupos.SelectedValue;
            nivelSelected.Value = "1";
            tipoSelected.Value = "1";
            upnuevo3.Update();
            mp3.Show();
        }
    }

    protected void ibgr5bajasGru_Click(object sender, ImageClickEventArgs e)
    {
        if (rblBajaGru.SelectedItem != null)
        {
            DataTable table = Logica.HELPER.getAprobadorGrupo(int.Parse(rblBajaGru.SelectedValue));
            lblmp3.Text = "Editar Aprobador Bajas";
            cddUsuario.SelectedValue = Logica.HELPER.getUsuario(rblBajaGru.SelectedItem.Text);
            nivelSelected.Value = "1";
            tipoSelected.Value = table.Rows[0]["APRGRU_TIPO"].ToString();
            idSelected.Value = rblBajaGru.SelectedValue;
            ordenSelected.Value = table.Rows[0]["APRGRU_ORDEN"].ToString();
            cddUsuario.SelectedValue = Logica.HELPER.getUsuario(rblBajaGru.SelectedItem.Text);
            upnuevo3.Update();
            mp3.Show();
        }
    }

    protected void ibgr6bajasGru_Click(object sender, ImageClickEventArgs e)
    {
        if (rblBajaGru.SelectedItem != null)
        {
            Logica.HELPER.delAprobadorGrupo(int.Parse(rblBajaGru.SelectedValue));
            CargaAprobadoresGru();
        }
    }

    protected void ibgr4trasladosDesc_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbdescripcion.SelectedItem != null)
        {
            lblmp3.Text = "Nuevo Aprobador Traslados";
            ddUsuario.ClearSelection();
            ugeIdSelected.Value = rlbdescripcion.SelectedValue;
            nivelSelected.Value = "3";
            tipoSelected.Value = "0";
            upnuevo3.Update();
            mp3.Show();
        }
    }

    protected void ibgr5trasladosDesc_Click(object sender, ImageClickEventArgs e)
    {
        if (rblTrasladoDesc.SelectedItem != null)
        {
            DataTable table = Logica.HELPER.getAprobadorGrupo(int.Parse(rblTrasladoDesc.SelectedValue));
            lblmp3.Text = "Editar Aprobador Traslados";
            cddUsuario.SelectedValue = Logica.HELPER.getUsuario(rblTrasladoDesc.SelectedItem.Text);
            nivelSelected.Value = "3";
            tipoSelected.Value = "0";
            idSelected.Value = rblTrasladoDesc.SelectedValue;
            ordenSelected.Value = table.Rows[0]["APRGRU_ORDEN"].ToString();
            upnuevo3.Update();
            mp3.Show();
        }
    }

    protected void ibgr6trasladosDesc_Click(object sender, ImageClickEventArgs e)
    {
        if (rblTrasladoDesc.SelectedItem != null)
        {
            Logica.HELPER.delAprobadorGrupo(int.Parse(rblTrasladoDesc.SelectedValue));
            CargaAprobadoresDesc();
        }
    }

    protected void ibgr4bajasDesc_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbdescripcion.SelectedItem != null)
        {
            lblmp3.Text = "Nuevo Aprobador Bajas";
            ddUsuario.ClearSelection();
            ugeIdSelected.Value = rlbdescripcion.SelectedValue;
            nivelSelected.Value = "3";
            tipoSelected.Value = "1";
            upnuevo3.Update();
            mp3.Show();
        }
    }

    protected void ibgr5bajasDesc_Click(object sender, ImageClickEventArgs e)
    {
        if (rblBajaDesc.SelectedItem != null)
        {
            DataTable table = Logica.HELPER.getAprobadorGrupo(int.Parse(rblBajaDesc.SelectedValue));
            lblmp3.Text = "Editar Aprobador Bajas";
            cddUsuario.SelectedValue = Logica.HELPER.getUsuario(rblBajaDesc.SelectedItem.Text);
            nivelSelected.Value = "3";
            tipoSelected.Value = table.Rows[0]["APRGRU_TIPO"].ToString();
            idSelected.Value = rblBajaDesc.SelectedValue;
            ordenSelected.Value = table.Rows[0]["APRGRU_ORDEN"].ToString();
            cddUsuario.SelectedValue = Logica.HELPER.getUsuario(rblBajaDesc.SelectedItem.Text);
            upnuevo3.Update();
            mp3.Show();
        }
    }

    protected void ibgr6bajasDesc_Click(object sender, ImageClickEventArgs e)
    {
        if (rblBajaDesc.SelectedItem != null)
        {
            Logica.HELPER.delAprobadorGrupo(int.Parse(rblBajaDesc.SelectedValue));
            CargaAprobadoresDesc();
        }
    }

    protected void btncerrar3_Click(object sender, EventArgs e)
    {
        ddUsuario.ClearSelection();
        nivelSelected.Value = null;
        ugeIdSelected.Value = null;
        tipoSelected.Value = null;
        upnuevo3.Update();
        mp3.Hide();
    }
    protected void btnsave3_Click(object sender, EventArgs e)
    {
        if (lblmp3.Text == "Nuevo Aprobador Traslados")
        {
            if (!Logica.HELPER.compruebaAprobadorGrupo(ddUsuario.SelectedValue, int.Parse(tipoSelected.Value), int.Parse(ugeIdSelected.Value)))
            {
                Logica.HELPER.insAprobadorGrupo(ddUsuario.SelectedValue, int.Parse(tipoSelected.Value), int.Parse(ugeIdSelected.Value));
                recargaAprobadores(nivelSelected.Value);
                ddUsuario.ClearSelection();
                nivelSelected.Value = null;
                ugeIdSelected.Value = null;
                tipoSelected.Value = null;
                upnuevo3.Update();
                mp3.Hide();
            }
        }
        else if (lblmp3.Text == "Editar Aprobador Traslados")
        {
            Logica.HELPER.updAprobadorGrupo(ddUsuario.SelectedValue, int.Parse(idSelected.Value), int.Parse(ordenSelected.Value));
            recargaAprobadores(nivelSelected.Value);
            ddUsuario.SelectedValue = null;
            nivelSelected.Value = null;
            ordenSelected.Value = null;
            idSelected.Value = null;
            tipoSelected.Value = null;
            upnuevo3.Update();
            mp3.Hide();
        }
        else if (lblmp3.Text == "Nuevo Aprobador Bajas")
        {
            if (!Logica.HELPER.compruebaAprobadorGrupo(ddUsuario.SelectedValue, int.Parse(tipoSelected.Value), int.Parse(ugeIdSelected.Value)))
            {
                Logica.HELPER.insAprobadorGrupo(ddUsuario.SelectedValue, int.Parse(tipoSelected.Value), int.Parse(ugeIdSelected.Value));
                recargaAprobadores(nivelSelected.Value);
                ddUsuario.ClearSelection();
                nivelSelected.Value = null;
                ugeIdSelected.Value = null;
                tipoSelected.Value = null;
                upnuevo3.Update();
                mp3.Hide();
            }
        }
        else if (lblmp3.Text == "Editar Aprobador Bajas")
        {
            Logica.HELPER.updAprobadorGrupo(ddUsuario.SelectedValue, int.Parse(idSelected.Value), int.Parse(ordenSelected.Value));
            recargaAprobadores(nivelSelected.Value);
            ddUsuario.SelectedValue = null;
            nivelSelected.Value = null;
            ordenSelected.Value = null;
            idSelected.Value = null;
            tipoSelected.Value = null;
            upnuevo3.Update();
            mp3.Hide();
        }
    }
    protected void ibgr4trasladosSubGru_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbsubgrupo.SelectedItem != null)
        {
            lblmp3.Text = "Nuevo Aprobador Traslados";
            ddUsuario.ClearSelection();
            ugeIdSelected.Value = rlbsubgrupo.SelectedValue;
            nivelSelected.Value = "2";
            tipoSelected.Value = "0";
            upnuevo3.Update();
            mp3.Show();
        }
    }

    protected void ibgr5trasladosSubGru_Click(object sender, ImageClickEventArgs e)
    {
        if (rblTrasladoSubGru.SelectedItem != null)
        {
            DataTable table = Logica.HELPER.getAprobadorGrupo(int.Parse(rblTrasladoSubGru.SelectedValue));
            lblmp3.Text = "Editar Aprobador Traslados";
            cddUsuario.SelectedValue = Logica.HELPER.getUsuario(rblTrasladoSubGru.SelectedItem.Text);
            nivelSelected.Value = "2";
            tipoSelected.Value = "0";
            idSelected.Value = rblTrasladoSubGru.SelectedValue;
            ordenSelected.Value = table.Rows[0]["APRGRU_ORDEN"].ToString();
            upnuevo3.Update();
            mp3.Show();
        }
    }

    protected void ibgr6trasladosSubGru_Click(object sender, ImageClickEventArgs e)
    {
        if (rblTrasladoSubGru.SelectedItem != null)
        {
            Logica.HELPER.delAprobadorGrupo(int.Parse(rblTrasladoSubGru.SelectedValue));
            CargaAprobadoresSubGru();
        }
    }

    protected void ibgr4bajasSubGru_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbsubgrupo.SelectedItem != null)
        {
            lblmp3.Text = "Nuevo Aprobador Bajas";
            ddUsuario.ClearSelection();
            ugeIdSelected.Value = rlbsubgrupo.SelectedValue;
            nivelSelected.Value = "2";
            tipoSelected.Value = "1";
            upnuevo3.Update();
            mp3.Show();
        }
    }

    protected void ibgr5bajasSubGru_Click(object sender, ImageClickEventArgs e)
    {
        if (rblBajaSubGru.SelectedItem != null)
        {
            DataTable table = Logica.HELPER.getAprobadorGrupo(int.Parse(rblBajaSubGru.SelectedValue));
            lblmp3.Text = "Editar Aprobador Bajas";
            cddUsuario.SelectedValue = Logica.HELPER.getUsuario(rblBajaSubGru.SelectedItem.Text);
            nivelSelected.Value = "2";
            tipoSelected.Value = table.Rows[0]["APRGRU_TIPO"].ToString();
            idSelected.Value = rblBajaSubGru.SelectedValue;
            ordenSelected.Value = table.Rows[0]["APRGRU_ORDEN"].ToString();
            cddUsuario.SelectedValue = Logica.HELPER.getUsuario(rblBajaSubGru.SelectedItem.Text);
            upnuevo3.Update();
            mp3.Show();
        }
    }

    protected void ibgr6bajasSubGru_Click(object sender, ImageClickEventArgs e)
    {
        if (rblBajaSubGru.SelectedItem != null)
        {
            Logica.HELPER.delAprobadorGrupo(int.Parse(rblBajaSubGru.SelectedValue));
            CargaAprobadoresSubGru();
        }
    }

    private void CargaAprobadoresGru()
    {
        DataTable aprobadoresGru;
        aprobadoresGru = Logica.HELPER.getAprobadoresGrupos(0, int.Parse(rlbgrupos.SelectedValue != "" ? rlbgrupos.SelectedValue : "0"));
        rblTrasladoGru.DataSource = aprobadoresGru;
        rblTrasladoGru.DataTextField = "UserName";
        rblTrasladoGru.DataValueField = "APR_ID";
        rblTrasladoGru.DataBind();
        uptrasladosGru.Update();

        rblBajaGru.DataSource = Logica.HELPER.getAprobadoresGrupos(1, int.Parse(rlbgrupos.SelectedValue != "" ? rlbgrupos.SelectedValue : "0"));
        rblBajaGru.DataTextField = "UserName";
        rblBajaGru.DataValueField = "APR_ID";
        rblBajaGru.DataBind();
        upbajasGru.Update();
    }
    private void CargaAprobadoresSubGru()
    {
        DataTable aprobadoresGru;
        aprobadoresGru = Logica.HELPER.getAprobadoresGrupos(0, int.Parse(rlbsubgrupo.SelectedValue != "" ? rlbsubgrupo.SelectedValue : "0"));
        rblTrasladoSubGru.DataSource = aprobadoresGru;
        rblTrasladoSubGru.DataTextField = "UserName";
        rblTrasladoSubGru.DataValueField = "APR_ID";
        rblTrasladoSubGru.DataBind();
        uptrasladosSubGru.Update();

        rblBajaSubGru.DataSource = Logica.HELPER.getAprobadoresGrupos(1, int.Parse(rlbsubgrupo.SelectedValue != "" ? rlbsubgrupo.SelectedValue : "0"));
        rblBajaSubGru.DataTextField = "UserName";
        rblBajaSubGru.DataValueField = "APR_ID";
        rblBajaSubGru.DataBind();
        upbajasSubGru.Update();
    }

    private void CargaAprobadoresDesc()
    {
        DataTable aprobadoresGru;
        aprobadoresGru = Logica.HELPER.getAprobadoresGrupos(0, int.Parse(rlbdescripcion.SelectedValue != "" ? rlbdescripcion.SelectedValue : "0"));
        rblTrasladoDesc.DataSource = aprobadoresGru;
        rblTrasladoDesc.DataTextField = "UserName";
        rblTrasladoDesc.DataValueField = "APR_ID";
        rblTrasladoDesc.DataBind();
        uptrasladosDesc.Update();

        rblBajaDesc.DataSource = Logica.HELPER.getAprobadoresGrupos(1, int.Parse(rlbdescripcion.SelectedValue != "" ? rlbdescripcion.SelectedValue : "0"));
        rblBajaDesc.DataTextField = "UserName";
        rblBajaDesc.DataValueField = "APR_ID";
        rblBajaDesc.DataBind();
        upbajasDesc.Update();
    }

    private void recargaAprobadores(string nivel)
    {
        switch (nivel)
        {
            case "1":
                CargaAprobadoresGru();
                break;
            case "2":
                CargaAprobadoresSubGru();
                break;
            case "3":
                CargaAprobadoresDesc();
                break;
        }
    }

    protected void rlbdescripcion_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargaAprobadoresDesc();
    }
}