using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
using Microsoft.Win32.SafeHandles;
using System.ComponentModel;
using System.IO;
using System.Web.Security;
using System.Configuration;


public partial class Site_Activos_ImprimirCod : System.Web.UI.Page
{
    ErrorTrapper errtrap;

    protected void Page_Load(object sender, EventArgs e)
    {
        this.Title = ConfigurationManager.AppSettings["Titulo"] + " Imprimir Códigos de Barras";
        //hk5.Attributes.Add("onmouseout", "this.src='../../Img/cod1.png';return true;");
        //hk5.Attributes.Add("onmouseover", "this.src='../../Img/cod2.png';return true");

        ibimp1.Attributes.Add("onmouseout", "this.src='../../Img/imp1.png'");
        ibimp1.Attributes.Add("onmouseover", "this.src='../../Img/imp2.png'");

        try
        {
            if ((string)(Session["emid"]) == null)
            {
                Session.Abandon();
                FormsAuthentication.SignOut();
                FormsAuthentication.RedirectToLoginPage();
            }
            else
            {
                lblEmpresa.Text = Session["emid"].ToString();
                cargarHistorial();
                txtultimocod.Text = Logica.HELPER.getUltCodimpr();
            }
        }
        catch
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }       
    }

    private void cargarHistorial()
    {
        try
        {
            rgcodigos.DataSource = Logica.HELPER.getHistorialCod();
            rgcodigos.DataBind();
        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
            messbox1.Mensaje = "Error: " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
        }
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern SafeFileHandle CreateFile(string lpFileName, FileAccess dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, FileMode dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

    private void Print(string encabezado, string codigobarras)
    {
        try
        {
            int x1 = Convert.ToInt32(((57 - (encabezado.Length * 1.4782)) / 2) * (((57 - (encabezado.Length * 1.4782)) / 2) * 0.3662));

            // Command to be sent to the printer         
            string command =

            "^XA" + //inicio de label

            "^FO" +

            x1 + ",25" + //MARGEN DE IMPRESION X,Y Del siguiente campo        

            "^AC,26,12" + //FUENTE ^Afo,h,w ->> f=fuente o=orientacion, h=alto (10 a 32000), w=ancho (10 a 32000)

            "^FD" + //Inicio de datos ^FDa a=Datos

            encabezado + //Datos //fUENTE C=38letras

            "^FS" + //Final de campo (separador)

            "^FO" +

            "15,45" + //ALINEACION CB GRAFICO

            "^BY1.5,3" + //^BYw,r,h w=ancho en puntos (1 a 10), r=ancho de cb (2.0 a 3.0), h=alto del cb

            "^AC,26,12" +

            "^BC,80,N,N,N" + //^BCo,h,f,g,e,m

            "^FD" +

            codigobarras.Replace("(", "").Replace(")", "") +

            "^FS" +

             "^FO" +

            (236 - codigobarras.Length) / 2 + ",130" + //MARGEN DE IMPRESION X,Y Del siguiente campo

            "^AC,26,12" + //FUENTE ^Afo,h,w ->> f=fuente o=orientacion, h=alto (10 a 32000), w=ancho (10 a 32000)

            "^FD" + //Inicio de datos ^FDa a=Datos

            codigobarras + //Datos //fUENTE C=38letras

            "^FS" + //Final de campo (separador)

            "^XZ"; //fin de label

            // Create a buffer with the command         
            Byte[] buffer = new byte[command.Length];
            buffer = System.Text.Encoding.ASCII.GetBytes(command);
            // Use the CreateFile external func to connect to the LPT1 port         
            SafeFileHandle printer = CreateFile(@"\\192.168.1.4\ZDesigne", FileAccess.ReadWrite, 0, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);
            // SafeFileHandle printer = CreateFile("USB001", FileAccess.ReadWrite, 0, IntPtr.Zero, FileMode.Open, 0, IntPtr.Zero);

            // Aqui verifico se a impressora é válida         
            if (printer.IsInvalid == true)
            {
                return;
            }
            // Open the filestream to the lpt1 port and send the command         
            FileStream lpt1 = new FileStream(printer, FileAccess.ReadWrite);
            lpt1.Write(buffer, 0, buffer.Length);
            // Close the FileStream connection         
            lpt1.Close();
        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
            messbox1.Mensaje = "Error: " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
        }
    }

    public string completarCodigo(string cod)
    {
        try
        {
            //ceros es el numero de digitos disponibles para activos
            int ceros = int.Parse((string)(Session["emtd"])) - ((string)(Session["empr"])).Length - 1;
            for (int i = cod.Length; i < ceros; i++)
                cod = "0" + cod;
            return cod;
        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0);
            messbox1.Mensaje = "Error: " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
            return "";
        }
    }
    protected void ibxls1_Click(object sender, ImageClickEventArgs e)
    {
        try
        {

        int td = int.Parse(Session["emtd"].ToString());
        int nveces = int.Parse(txtnumcodigos.Text);
        string sigCod = "";

        sigCod = txtultimocod.Text;

        string cod1 = "";
        string cod2 = "";

        if (td == 14)
        {            
            for (int i = 0; i < nveces; i++)
            {              

                sigCod = (int.Parse(sigCod) + 1).ToString();
                string codigo = Logica.HELPER.getVerificador(Session["empr"].ToString() + completarCodigo(sigCod), int.Parse(Session["emtd"].ToString()));
                
                 if(i==0)
                     cod1 = codigo;
                
                Print(lblEmpresa.Text.ToUpper(),codigo);

                Logica.HELPER.insCodImpreso(sigCod,codigo.Substring(13, 1),Session["empr"].ToString(),codigo.Substring(7, 7),Session["emid"].ToString());

                if(i+1==nveces)
                    cod2 = codigo;
            }
            Logica.HELPER.insHCodImpreso(Membership.GetUser().UserName.ToLower(), DropDownList1.SelectedItem.ToString(), cod1, cod2, nveces.ToString());
        }
        else if (td == 20)
        {
            for (int i = 0; i < nveces; i++)
            {

                sigCod = (int.Parse(sigCod) + 1).ToString();
                string codigo = Logica.HELPER.getVerificador(Session["empr"].ToString() + completarCodigo(sigCod), int.Parse(Session["emtd"].ToString()));

                if (i == 0)
                    cod1 = codigo;

                //descomentar para imprimir en zebra gk740
                //Print(lblEmpresa.Text.ToUpper(), codigo);

                Logica.HELPER.insCodImpreso(sigCod, codigo.Substring(19, 1), Session["empr"].ToString(), codigo.Substring(13, 7), Session["emid"].ToString());

                if (i + 1 == nveces)
                    cod2 = codigo;
            }
            Logica.HELPER.insHCodImpreso(Membership.GetUser().UserName.ToLower(), DropDownList1.SelectedItem.ToString(), cod1, cod2, nveces.ToString());
        }

        cargarHistorial();
        txtultimocod.Text = Logica.HELPER.getUltCodimpr();
            

        }
        catch (Exception ex)
        {
            errtrap = new ErrorTrapper();
            errtrap.SetOnError("Usuario:" + Membership.GetUser().UserName + "<< " + ex.Message, 0); //1 enviar mail
            messbox1.Mensaje = "Error. " + ex.Message;
            messbox1.Tipo = "E";
            messbox1.showMess();
        }
    }
}