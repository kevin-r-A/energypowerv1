using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Security;

public partial class ZUge : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if ((string)(Session["emid"]) == null)
            {
                Session.Abandon();
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
        }
        catch
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        if (!IsPostBack)
        {
            cargarUge1();
            this.Title = ConfigurationManager.AppSettings["Titulo"] + " Catálogos - Ubicación Geográfica";
            lblmsgerror.Text = "";
            Session["ip"] = "";
        }
    }

    private void cargarUge1()
    {
        Logica.UGEOGRAFICA zet = new Logica.UGEOGRAFICA();
        rlbgeo1.DataSource = zet.getUgeAll(1, 0);
        rlbgeo1.DataTextField = "uge_nombre";
        rlbgeo1.DataValueField = "uge_id";
        rlbgeo1.DataBind();
        upgeo.Update();
    }

    private void cargarUge2()
    {
        Logica.UGEOGRAFICA zet = new Logica.UGEOGRAFICA();
        rlbgeo2.DataSource = zet.getUgeAll(2, int.Parse(rlbgeo1.SelectedValue));
        rlbgeo2.DataTextField = "uge_nombre";
        rlbgeo2.DataValueField = "uge_id";
        rlbgeo2.DataBind();
        upgeo.Update();
    }

    private void cargarUge3()
    {
        Logica.UGEOGRAFICA zet = new Logica.UGEOGRAFICA();
        rlbgeo3.DataSource = zet.getUgeAll(3, int.Parse(rlbgeo2.SelectedValue));
        rlbgeo3.DataTextField = "uge_nombre";
        rlbgeo3.DataValueField = "uge_id";
        rlbgeo3.DataBind();
        upgeo.Update();
    }

    private void cargarUge4()
    {
        Logica.UGEOGRAFICA zet = new Logica.UGEOGRAFICA();
        rlbgeo4.DataSource = zet.getUgeAll(4, int.Parse(rlbgeo3.SelectedValue));
        rlbgeo4.DataTextField = "uge_nombre";
        rlbgeo4.DataValueField = "uge_id";
        rlbgeo4.DataBind();
        upgeo.Update();
    }

    private void cargarUge5()
    {
        Logica.UGEOGRAFICA zet = new Logica.UGEOGRAFICA();
        rlbgeo5.DataSource = zet.getUge4PuertaPasillo(5, int.Parse(rlbgeo4.SelectedValue));
        rlbgeo5.DataTextField = "uge_nombre";
        rlbgeo5.DataValueField = "uge_id";
        rlbgeo5.DataBind();
        upgeo.Update();
    }

    protected void rlbgeo1_SelectedIndexChanged(object sender, EventArgs e)
    {
        rlbgeo3.Items.Clear();
        rlbgeo4.Items.Clear();
        upgeo.Update();
        cargarUge2();
    }

    protected void rlbgeo2_SelectedIndexChanged(object sender, EventArgs e)
    {
        rlbgeo4.Items.Clear();
        upgeo.Update();
        cargarUge3();
    }

    protected void rlbgeo3_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarUge4();
    }

    protected void ibgr4_Click(object sender, ImageClickEventArgs e)
    {
        lblmp2.Text = "Nueva Geo1";
        lblNombrereader.Text = "Nombre";
        lblIpReader.Visible = false;
        txtIpReader.Visible = false;
        txtIpReader.Text = "";
        upnuevo2.Update();
        mp2.Show();
    }

    protected void ibgr5_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbgeo1.SelectedItem != null)
        {
            lblmp2.Text = "Editar Geo1";
            lblNombrereader.Text = "Nombre";
            lblIpReader.Visible = false;
            txtIpReader.Visible = false;
            txtIpReader.Text = "";

            Logica.UGEOGRAFICA zet = new Logica.UGEOGRAFICA(Convert.ToInt32(rlbgeo1.SelectedValue));

            //if (zet.UGE_READERIP != "" && zet.UGE_READERNOMBRE != "")
            //{
            //    chboxActivaRfid.Checked = true;
            txtnombre2.Text = rlbgeo1.SelectedItem.Text;
            txtCodigo.Text = zet.UGE_CODIGO;


            if (txtnombre2.Text.Contains("["))
            {
                string[] nombre = txtnombre2.Text.Trim().Split('[');

                txtnombre2.Text = nombre[0].Trim();
            }

            //    txtIpReader.Text = zet.UGE_READERIP;
            //    txtNombreReader.Text = zet.UGE_READERNOMBRE;

            //    pan_PortalRfid.Visible = true;
            //}
            //else
            //{
            //    txtnombre2.Text = rlbgeo1.SelectedItem.Text;
            //    chboxActivaRfid.Checked = false;
            //    txtIpReader.Text = "";
            //    txtNombreReader.Text = "";

            //    pan_PortalRfid.Visible = false;
            //}

            upnuevo2.Update();
            mp2.Show();
        }
    }

    protected void ibgr6_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbgeo1.SelectedItem != null)
        {
            if (!Logica.UGEOGRAFICA.valRelActivo(rlbgeo1.SelectedValue) && !Logica.UGEOGRAFICA.valRelActivoH(rlbgeo1.SelectedValue))
            {
                Logica.UGEOGRAFICA.fDelUge1(int.Parse(rlbgeo1.SelectedValue));
                cargarUge1();
                rlbgeo2.Items.Clear();
                rlbgeo3.Items.Clear();
                rlbgeo4.Items.Clear();
                rlbgeo5.Items.Clear();
                upgeo.Update();
            }
            else
            {
                messbox1.Mensaje = "No pudo ser eliminado ya que activamente se relaciona con activos";
                messbox1.Tipo = "E";
                messbox1.showMess();
            }
        }
    }

    protected void btncerrar2_Click(object sender, EventArgs e)
    {
        txtnombre2.Text = "";

        txtCodigo.Text = "";

        txtIpReader.Text = "";

        lblmsgerror.Text = "";

        upnuevo2.Update();
        mp2.Hide();
    }

    protected void btnsave2_Click(object sender, EventArgs e)
    {
        lblmsgerror.Text = "";

        if (lblmp2.Text == "Editar Geo1")
        {
            Logica.UGEOGRAFICA zet = new Logica.UGEOGRAFICA();


            zet.UGE_NOMBRE = Logica.HELPER.capitalize(txtnombre2.Text);
            zet.Id = int.Parse(rlbgeo1.SelectedValue);
            zet.UGE_READERIP = txtIpReader.Text.Trim();
            zet.UGE_READERNOMBRE = "";
            zet.UGE_CODIGO = txtCodigo.Text;

            zet.Update();
            cargarUge1();
            rlbgeo1.SelectedValue = zet.Id.ToString();
        }

        else if (lblmp2.Text == "Nueva Geo1")
        {
            Logica.UGEOGRAFICA zet = new Logica.UGEOGRAFICA();


            if (!Logica.UGEOGRAFICA.fgetUgeIng(Logica.HELPER.capitalize(txtnombre2.Text), 0))
            {
                zet.UGE_NOMBRE = Logica.HELPER.capitalize(txtnombre2.Text);
                zet.UGE_PADRE = 0;
                zet.UGE_NIVEL = 1;
                zet.UGE_CODIGO = txtCodigo.Text;
                zet.UGE_READERIP = txtIpReader.Text.Trim();

                zet.UGE_READERNOMBRE = "";

                zet.Create();
                cargarUge1();
                rlbgeo2.Items.Clear();
                rlbgeo3.Items.Clear();
                rlbgeo4.Items.Clear();
            }
        }
        else if (lblmp2.Text == "Editar Geo2")
        {
            Logica.UGEOGRAFICA zet = new Logica.UGEOGRAFICA();


            zet.UGE_NOMBRE = Logica.HELPER.capitalize(txtnombre2.Text);
            zet.Id = int.Parse(rlbgeo2.SelectedValue);
            string id_uge1 = rlbgeo1.SelectedValue;
            zet.UGE_READERIP = txtIpReader.Text.Trim();
            zet.UGE_READERNOMBRE = "";
            zet.UGE_CODIGO = txtCodigo.Text;

            zet.Update();
            cargarUge2();
            rlbgeo2.SelectedValue = zet.Id.ToString();
            rlbgeo1.SelectedValue = id_uge1;
        }


        else if (lblmp2.Text == "Nueva Geo2")
        {
            Logica.UGEOGRAFICA zet = new Logica.UGEOGRAFICA();


            if (!Logica.UGEOGRAFICA.fgetUgeIng(Logica.HELPER.capitalize(txtnombre2.Text), int.Parse(rlbgeo1.SelectedValue)))
            {
                zet.UGE_NOMBRE = Logica.HELPER.capitalize(txtnombre2.Text);
                zet.UGE_PADRE = int.Parse(rlbgeo1.SelectedValue);
                zet.UGE_NIVEL = 2;
                zet.UGE_READERIP = txtIpReader.Text.Trim();
                zet.UGE_READERNOMBRE = "";
                zet.UGE_CODIGO = txtCodigo.Text;

                zet.Create();
                cargarUge2();
                rlbgeo3.Items.Clear();
                rlbgeo4.Items.Clear();
            }
        }
        else if (lblmp2.Text == "Editar Geo3")
        {
            Logica.UGEOGRAFICA zet = new Logica.UGEOGRAFICA();
            zet.UGE_NOMBRE = Logica.HELPER.capitalize(txtnombre2.Text);
            zet.Id = int.Parse(rlbgeo3.SelectedValue);
            zet.UGE_CODIGO = txtCodigo.Text;
            zet.Update();
            cargarUge3();
            rlbgeo3.SelectedValue = zet.Id.ToString();
        }
        else if (lblmp2.Text == "Nueva Geo3")
        {
            if (!Logica.UGEOGRAFICA.fgetUgeIng(Logica.HELPER.capitalize(txtnombre2.Text), int.Parse(rlbgeo2.SelectedValue)))
            {
                Logica.UGEOGRAFICA zet = new Logica.UGEOGRAFICA();
                zet.UGE_NOMBRE = Logica.HELPER.capitalize(txtnombre2.Text);
                zet.UGE_PADRE = int.Parse(rlbgeo2.SelectedValue);
                zet.UGE_NIVEL = 3;
                zet.UGE_CODIGO = txtCodigo.Text;
                zet.Create();
                cargarUge3();
                rlbgeo4.Items.Clear();
            }
        }
        else if (lblmp2.Text == "Editar Piso/Nivel")
        {
            Logica.UGEOGRAFICA zet = new Logica.UGEOGRAFICA();


            zet.UGE_NOMBRE = Logica.HELPER.capitalize(txtnombre2.Text);
            zet.Id = int.Parse(rlbgeo4.SelectedValue);
            zet.UGE_READERIP = txtIpReader.Text.Trim();
            zet.UGE_READERNOMBRE = "";
            zet.UGE_CODIGO = txtCodigo.Text;

            zet.Update();
            cargarUge4();
            rlbgeo4.SelectedValue = zet.Id.ToString();
            lblmsgerror.Text = "";
        }

        else if (lblmp2.Text == "Nuevo Piso/Nivel")
        {
            Logica.UGEOGRAFICA zet = new Logica.UGEOGRAFICA();


            if (!Logica.UGEOGRAFICA.fgetUgeIng(Logica.HELPER.capitalize(txtnombre2.Text), int.Parse(rlbgeo1.SelectedValue)))
            {
                zet.UGE_NOMBRE = Logica.HELPER.capitalize(txtnombre2.Text);
                zet.UGE_PADRE = int.Parse(rlbgeo3.SelectedValue);
                zet.UGE_NIVEL = 4;
                zet.UGE_READERIP = txtIpReader.Text.Trim();
                zet.UGE_READERNOMBRE = "";
                zet.UGE_CODIGO = txtCodigo.Text;

                zet.Create();
                cargarUge4();
                lblmsgerror.Text = "";
            }
        }

        else if (lblmp2.Text == "Nueva Puerta/Pasillo")
        {
            Logica.UGEOGRAFICA zet = new Logica.UGEOGRAFICA();

            /*
            DICE: ENVIO PARAMETROS PARA SETEAR IP Y NOMBRE  DE READER
            */
            if (txtIpReader.Text.Trim() == "")
            {
                lblmsgerror.Text = "* Ingrese Direccion IP";
            }
            else
            {
                if (!Logica.UGEOGRAFICA.fgetUgeIng(Logica.HELPER.capitalize(txtnombre2.Text), 4))
                {
                    zet.UGE_NOMBRE = Logica.HELPER.capitalize(txtnombre2.Text);
                    zet.UGE_PADRE = int.Parse(rlbgeo4.SelectedValue);
                    zet.UGE_NIVEL = 5;
                    zet.UGE_CODIGO = txtCodigo.Text;
                    zet.UGE_READERIP = txtIpReader.Text.Trim();

                    zet.UGE_READERNOMBRE = Logica.HELPER.capitalize(txtnombre2.Text.Trim());


                    if (IsIPv4(zet.UGE_READERIP.Trim()))
                    {
                        if (!Logica.UGEOGRAFICA.VerificaIpReader(zet.UGE_READERIP))
                        {
                            zet.Create();
                            cargarUge5();
                            lblmsgerror.Text = "";
                        }
                        else
                        {
                            DataTable dt = new DataTable();
                            string tipo = "";
                            dt = Logica.UGEOGRAFICA.DatosReader(zet.UGE_READERIP, ref tipo);
                            string UGE_READERNOMBRE_ = "";
                            string UGE_NOMBRE_ = "";

                            if (dt.Rows.Count > 0)
                            {
                                UGE_READERNOMBRE_ = dt.Rows[0][0].ToString();
                                UGE_NOMBRE_ = dt.Rows[0][1].ToString();
                            }

                            if (tipo == "UGE")

                                lblmsgerror.Text = "IP Reader ya Regitrada en PORTAL: " + UGE_READERNOMBRE_ + ", UBI GEOGRAFICA: " + UGE_NOMBRE_;
                            else
                                lblmsgerror.Text = "IP Reader ya Regitrada en PORTAL: " + UGE_READERNOMBRE_ + ", UBI ORGANICA: " + UGE_NOMBRE_;
                        }
                    }
                    else
                    {
                        lblmsgerror.Text = "Direccion IP no Valida...!!!";
                    }
                }
                else
                {
                    lblmsgerror.Text = "Puerta/Pasillo ya fue Ingresado, corrijalo antes de Continuar...!!!";
                }
            }
        }

        else if (lblmp2.Text == "Editar Puerta/Pasillo")
        {
            Logica.UGEOGRAFICA zet = new Logica.UGEOGRAFICA();

            /*
            DICE: ENVIO PARAMETROS PARA SETEAR IP Y NOMBRE  DE READER
            */
            if (txtIpReader.Text.Trim() == "")
            {
                lblmsgerror.Text = "* Ingrese Direccion IP";
            }
            else
            {
                zet.UGE_NOMBRE = Logica.HELPER.capitalize(txtnombre2.Text);
                zet.Id = int.Parse(rlbgeo5.SelectedValue);
                zet.UGE_READERIP = txtIpReader.Text.Trim();
                zet.UGE_READERNOMBRE = txtnombre2.Text.Trim();
                zet.UGE_CODIGO = txtCodigo.Text;
                //if (chboxActivaRfid.Checked)
                //{
                if (IsIPv4(zet.UGE_READERIP.Trim()))
                {
                    if (Session["ip"].ToString() == txtIpReader.Text.Trim())
                    {
                        zet.Update();
                        cargarUge5();
                        rlbgeo5.SelectedValue = zet.Id.ToString();
                        lblmsgerror.Text = "";
                    }
                    else
                    {
                        if (!Logica.UGEOGRAFICA.VerificaIpReader(zet.UGE_READERIP) && !Logica.UGEOGRAFICA.VerificaIpReaderUorganica(zet.UGE_READERIP))
                        {
                            zet.Update();
                            cargarUge5();
                            rlbgeo5.SelectedValue = zet.Id.ToString();
                            lblmsgerror.Text = "";
                            Session["ip"] = "1";
                            lblmsgerror.Text = "";
                        }
                        else
                        {
                            DataTable dt = new DataTable();
                            string tipo = "";
                            dt = Logica.UGEOGRAFICA.DatosReader(zet.UGE_READERIP, ref tipo);
                            string UGE_READERNOMBRE_ = "";
                            string UGE_NOMBRE_ = "";

                            if (dt.Rows.Count > 0)
                            {
                                UGE_READERNOMBRE_ = dt.Rows[0][0].ToString();
                                UGE_NOMBRE_ = dt.Rows[0][1].ToString();
                            }

                            if (tipo == "UGE")
                            {
                                lblmsgerror.Text = "* IP Reader ya Regitrada en PORTAL: " + UGE_READERNOMBRE_ + ", UBI GEOGRAFICA: " + UGE_NOMBRE_;
                            }
                            else
                            {
                                lblmsgerror.Text = "* IP Reader ya Regitrada en PORTAL: " + UGE_READERNOMBRE_ + ", UBI ORGANICA: " + UGE_NOMBRE_;
                            }
                        }
                    }
                }
                else
                {
                    lblmsgerror.Text = "* Direccion IP no Valida...!!!";
                }

                //}

                //else
                //{
                //    zet.Update();
                //    cargarUge4();
                //    rlbgeo4.SelectedValue = zet.Id.ToString();
                //    lblmsgerror.Text = "";
                //}
            }
        }

        if (lblmsgerror.Text == "")
        {
            upnuevo2.Update();
            txtnombre2.Text = "";
            txtIpReader.Text = "";

            lblmsgerror.Text = "";


            mp2.Hide();
        }
    }

    protected void ibgr7_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbgeo1.SelectedItem != null)
        {
            lblmp2.Text = "Nueva Geo2";
            lblNombrereader.Text = "Nombre";
            lblIpReader.Visible = false;
            txtIpReader.Visible = false;
            txtIpReader.Text = "";
            txtCodigo.Text = "";
            upnuevo2.Update();

            mp2.Show();
        }
    }

    protected void ibgr10_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbgeo2.SelectedItem != null)
        {
            lblmp2.Text = "Nueva Geo3";
            lblNombrereader.Text = "Nombre";
            lblIpReader.Visible = false;
            txtIpReader.Visible = false;
            txtIpReader.Text = "";

            upnuevo2.Update();
            mp2.Show();
        }
    }

    protected void ibgr13_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbgeo3.SelectedItem != null)
        {
            lblmp2.Text = "Nuevo Piso/Nivel";
            lblNombrereader.Text = "Nombre";
            lblIpReader.Visible = false;
            txtIpReader.Visible = false;
            txtIpReader.Text = "";
            txtCodigo.Text = "";
            upnuevo2.Update();
            mp2.Show();
        }
    }

    protected void ibgr8_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbgeo2.SelectedItem != null)
        {
            Logica.UGEOGRAFICA zet = new Logica.UGEOGRAFICA(Convert.ToInt32(rlbgeo2.SelectedValue));
            lblmp2.Text = "Editar Geo2";
            txtnombre2.Text = rlbgeo2.SelectedItem.Text.Trim();
            txtCodigo.Text = zet.UGE_CODIGO;
            lblNombrereader.Text = "Nombre";
            lblIpReader.Visible = false;
            txtIpReader.Visible = false;
            txtIpReader.Text = "";

            upnuevo2.Update();
            mp2.Show();
        }
    }

    protected void ibgr11_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbgeo3.SelectedItem != null)
        {
            Logica.UGEOGRAFICA zet = new Logica.UGEOGRAFICA(Convert.ToInt32(rlbgeo3.SelectedValue));
            lblmp2.Text = "Editar Geo3";
            txtCodigo.Text = zet.UGE_CODIGO;
            txtnombre2.Text = rlbgeo3.SelectedItem.Text.Trim();
            lblNombrereader.Text = "Nombre";
            lblIpReader.Visible = false;
            txtIpReader.Visible = false;
            txtIpReader.Text = "";

            if (txtnombre2.Text.Contains("["))
            {
                string[] nombre = txtnombre2.Text.Trim().Split('[');

                txtnombre2.Text = nombre[0].Trim();
            }

            upnuevo2.Update();
            mp2.Show();
        }
    }

    protected void ibgr14_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbgeo4.SelectedItem != null)
        {
            lblmp2.Text = "Editar Piso/Nivel";
            lblNombrereader.Text = "Nombre";
            lblIpReader.Visible = false;
            txtIpReader.Visible = false;
            txtIpReader.Text = "";


            Logica.UGEOGRAFICA zet = new Logica.UGEOGRAFICA(Convert.ToInt32(rlbgeo4.SelectedValue));
            txtCodigo.Text = zet.UGE_CODIGO;
            if (zet.UGE_READERIP != "" && zet.UGE_READERNOMBRE != "")
            {
                txtnombre2.Text = rlbgeo4.SelectedItem.Text;

                txtIpReader.Text = zet.UGE_READERIP;


                if (txtnombre2.Text.Contains("["))
                {
                    string[] nombre = txtnombre2.Text.Trim().Split('[');

                    txtnombre2.Text = nombre[0].Trim();
                }

                Session["ip"] = txtIpReader.Text.Trim();
            }
            else
            {
                txtnombre2.Text = rlbgeo4.SelectedItem.Text;

                txtIpReader.Text = "";

                if (txtnombre2.Text.Contains("["))
                {
                    string[] nombre = txtnombre2.Text.Trim().Split('[');

                    txtnombre2.Text = nombre[0].Trim();
                }
            }

            upnuevo2.Update();
            mp2.Show();
        }
    }

    protected void ibgr9_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbgeo2.SelectedItem != null)
        {
            if (!Logica.UGEOGRAFICA.valRelActivo(rlbgeo2.SelectedValue) && !Logica.UGEOGRAFICA.valRelActivoH(rlbgeo2.SelectedValue))
            {
                Logica.UGEOGRAFICA.fDelUge2(int.Parse(rlbgeo2.SelectedValue));
                cargarUge2();
                rlbgeo3.Items.Clear();
                rlbgeo4.Items.Clear();
                rlbgeo5.Items.Clear();
                upgeo.Update();
            }
            else
            {
                messbox1.Mensaje = "No pudo ser eliminado ya que activamente se relaciona con activos";
                messbox1.Tipo = "E";
                messbox1.showMess();
            }
        }
    }

    protected void ibgr12_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbgeo3.SelectedItem != null)
        {
            if (!Logica.UGEOGRAFICA.valRelActivo(rlbgeo3.SelectedValue) && !Logica.UGEOGRAFICA.valRelActivoH(rlbgeo3.SelectedValue))
            {
                Logica.UGEOGRAFICA.fDelUge3(int.Parse(rlbgeo3.SelectedValue));
                cargarUge3();
                rlbgeo4.Items.Clear();
                rlbgeo5.Items.Clear();
                upgeo.Update();
            }
            else
            {
                messbox1.Mensaje = "No pudo ser eliminado ya que activamente se relaciona con activos";
                messbox1.Tipo = "E";
                messbox1.showMess();
            }
        }
    }

    protected void ibgr15_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbgeo4.SelectedItem != null)
        {
            if (!Logica.UGEOGRAFICA.valRelActivo(rlbgeo4.SelectedValue) && !Logica.UGEOGRAFICA.valRelActivoH(rlbgeo4.SelectedValue))
            {
                Logica.UGEOGRAFICA.fDelUge4(int.Parse(rlbgeo4.SelectedValue));
                rlbgeo5.Items.Clear();
                cargarUge4();
            }
            else
            {
                messbox1.Mensaje = "No pudo ser eliminado ya que activamente se relaciona con activos";
                messbox1.Tipo = "E";
                messbox1.showMess();
            }
        }
    }


    public static bool IsIPv4(string value)
    {
        var quads = value.Split('.');

        // if we do not have 4 quads, return false
        if (!(quads.Length == 4))
            return false;

        // for each quad
        foreach (var quad in quads)
        {
            int q;
            // if parse fails 
            // or length of parsed int != length of quad string (i.e.; '1' vs '001')
            // or parsed int < 0
            // or parsed int > 255
            // return false
            if (!Int32.TryParse(quad, out q)
                || !q.ToString().Length.Equals(quad.Length)
                || q < 0
                || q > 255)
            {
                return false;
            }
        }

        return true;
    }

    protected void rlbgeo4_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarUge5();
    }

    protected void rlbgeo5_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbgeo4.SelectedItem != null)
        {
            lblmp2.Text = "Nueva Puerta/Pasillo";
            lblNombrereader.Text = "Nombre Reader";
            lblIpReader.Visible = true;
            txtIpReader.Visible = true;

            upnuevo2.Update();
            mp2.Show();
        }
    }

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbgeo5.SelectedItem != null)
        {
            lblmp2.Text = "Editar Puerta/Pasillo";
            lblNombrereader.Text = "Nombre Reader";
            lblIpReader.Visible = true;
            txtIpReader.Visible = true;

            Logica.UGEOGRAFICA zet = new Logica.UGEOGRAFICA(Convert.ToInt32(rlbgeo5.SelectedValue));

            if (zet.UGE_READERIP != "" && zet.UGE_READERNOMBRE != "")
            {
                txtnombre2.Text = rlbgeo5.SelectedItem.Text;

                txtIpReader.Text = zet.UGE_READERIP;

                if (txtnombre2.Text.Contains("["))
                {
                    string[] nombre = txtnombre2.Text.Trim().Split('[');

                    txtnombre2.Text = nombre[0].Trim();
                }

                Session["ip"] = txtIpReader.Text.Trim();
            }


            upnuevo2.Update();
            mp2.Show();
        }
    }

    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        if (rlbgeo5.SelectedItem != null)
        {
            //if (!Logica.UGEOGRAFICA.valRelActivo(rlbgeo5.SelectedValue) && !Logica.UGEOGRAFICA.valRelActivoH(rlbgeo5.SelectedValue))
            //{
            try
            {
                Logica.UGEOGRAFICA.fDelUge5(int.Parse(rlbgeo5.SelectedValue));
                cargarUge5();
            }
            catch (System.Exception ex)
            {
                messbox1.Mensaje = "No pudo ser eliminado: " + ex.Message;
                messbox1.Tipo = "E";
                messbox1.showMess();
            }

            //}
            //else
            //{
            //    messbox1.Mensaje = "No pudo ser eliminado ya que activamente se relaciona con activos";
            //    messbox1.Tipo = "E";
            //    messbox1.showMess();
            //}
        }
    }
}