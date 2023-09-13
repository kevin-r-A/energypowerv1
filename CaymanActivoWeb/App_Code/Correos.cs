using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Net.Mail;
//using System.Web.Mail;
using System.Diagnostics;
using System.Reflection;
using System.Net.Configuration;
using System.Net.Mime;
using System.Net;

/// <summary>
/// Summary description for Correos
/// </summary>
public class Correos
{
        public Correos()
        {
        }
    public void envioCorreosEnergyPower(string asunto, string cuerpo, string rutaPDF)
    {

        // Configurar los detalles del correo
        string remitente = ConfigurationManager.AppSettings["usuario_correo_logueo1"];
        //string destinatario = Session["MICORREOBAJA"].ToString();
        string clave = ConfigurationManager.AppSettings["Passw_correo_logueo1"];
        string smtp = ConfigurationManager.AppSettings["SMTP"];

        //string destinatario = "kevinabastidas@gmail.com";


        // Crear el objeto MailMessage
        MailMessage mensaje = new MailMessage(remitente, ConfigurationManager.AppSettings["destinatario1"]);
        mensaje.To.Add(ConfigurationManager.AppSettings["destinatario2"]); // Agrega destinatario2
        mensaje.Subject = asunto;
        mensaje.Body = cuerpo;
        Attachment adjunto = new Attachment(rutaPDF, MediaTypeNames.Application.Pdf);
        mensaje.Attachments.Add(adjunto);
        // Configurar el servidor SMTP de Office 365
        var puerto = Convert.ToInt16(ConfigurationManager.AppSettings["SmtPort"]);
        SmtpClient clienteSmtp = new SmtpClient(smtp, puerto);
        clienteSmtp.EnableSsl = true;
        clienteSmtp.UseDefaultCredentials = false;
        clienteSmtp.Credentials = new NetworkCredential(remitente, clave);

        try
        {
            // Enviar el correo
            clienteSmtp.Send(mensaje);
            Console.WriteLine("Correo enviado exitosamente.");
            Debug.WriteLine("Este es un mensaje de depuración");

        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al enviar el correo: " + ex.Message);
        }

        // Cerrar el cliente SMTP y liberar recursos
        clienteSmtp.Dispose();
    }

    public void enviarCorreo(string de, string nombre, string para, string asunto, string cuerpo, string cc, string nombreAdjunto, string tipoAdjunto)
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add(para);            
            msg.From = new MailAddress(de, nombre, System.Text.Encoding.UTF8);
            msg.Subject = asunto;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = cuerpo;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;

            //Aquí es donde se hace lo especial
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("gabriel.baldeon@caymansystems.com", "unreal");
            client.Port = 587;
            //client.Host = "smtp.gmail.com";
            client.Host = "74.125.45.109";
            client.EnableSsl = true; //Esto es para que vaya a través de SSL que es obligatorio con GMail
            try
            {
                client.Send(msg);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                ErrorTrapper err = new ErrorTrapper();
                err.SetOnError(ex.Message, 1);
            }
        }

        public void enviarCorreo2(string de, string nombre, string para, string asunto, string cuerpo, string cc, string nombreAdjunto, string tipoAdjunto)
        {
            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();
            msg.To.Add("info@colegiocooper.edu.ec");
            msg.Bcc.Add(cc);
            msg.From = new MailAddress(de, nombre, System.Text.Encoding.UTF8);
            msg.Subject = asunto;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = cuerpo;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;

            //Aquí es donde se hace lo especial
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("info@colegiocooper.edu.ec", "cooper6776");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            //client.Host = "74.125.45.109";
            client.EnableSsl = true; //Esto es para que vaya a través de SSL que es obligatorio con GMail
            try
            {
                client.Send(msg);
            }
            catch (System.Net.Mail.SmtpException ex)
            {
                ErrorTrapper err = new ErrorTrapper();
                err.SetOnError(ex.Message, 1);
            }
        }

        public void enviarCorreoAdmin(string cuerpo, string nombreAdjunto)
        {
            try
            {
                System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();
                correo.From = new System.Net.Mail.MailAddress("info@caymansystems.com");
                correo.To.Add(ConfigurationManager.AppSettings["emailTecnico"].ToString());
                string rutaArchivo = System.Web.HttpContext.Current.Server.MapPath("~") + "\\Logs\\Log_" + nombreAdjunto + ".txt";
                correo.Attachments.Add(new System.Net.Mail.Attachment(rutaArchivo, "text/html"));
                correo.Subject = "CAYMAN ACTIVO V3 - Error Log...";
                correo.Body = cuerpo;
                correo.IsBodyHtml = false;
                correo.Priority = System.Net.Mail.MailPriority.High;
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential("gabriel.baldeon", "unreal");
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = SMTPUserInfo;
            }
            catch (Exception ex)
            {
                ErrorTrapper err = new ErrorTrapper();
                err.SetOnError(ex.Message, 1);
            }
        }


        public static bool EnviarCorreo(string de, string para, string cc, string asunto, string cuerpo, string nombreAdjunto, string tipoAdjunto)
        {

            System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();
            correo.From = new System.Net.Mail.MailAddress(de);
            correo.To.Add(para);
            if (cc != "")
            {
                correo.CC.Add(cc);
            }
            correo.Subject = asunto;
            correo.Body = cuerpo;
            string file = nombreAdjunto;

            // Create  the file attachment for this e-mail message.
            Attachment data = new Attachment(file, "text/html");
            correo.Attachments.Add(data);
            correo.IsBodyHtml = true;
            correo.Priority = System.Net.Mail.MailPriority.Normal;

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            smtp.Host = ConfigurationManager.AppSettings["SMTP"].ToString();//ipservidor smtp
            smtp.Port = int.Parse(ConfigurationManager.AppSettings["SmtPort"].ToString());
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["usuario_correo_logueo"].ToString(), ConfigurationManager.AppSettings["Passw_correo_logueo"].ToString());
            smtp.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["Ssl"].ToString());


            try
            {
                smtp.Send(correo);
                return true;
            }

            catch (Exception ex)
            {
                return false;
            }
        }     

        //public static void EnviarCorreo(string de, string para, string cc, string asunto, string cuerpo, string nombreAdjunto, string tipoAdjunto)
        //{

        //    System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();
        //    correo.From = new System.Net.Mail.MailAddress(de);
        //    correo.To.Add(para);
        //    if (cc != "")
        //    {
        //        correo.CC.Add(cc);
        //    }
        //    correo.Subject = asunto;
        //    correo.Body = cuerpo;
        //    string file = nombreAdjunto;
        //    string rutaArchivo = System.Web.HttpContext.Current.Server.MapPath("./PDF/") + nombreAdjunto + ".pdf";

        //    // Create  the file attachment for this e-mail message.
        //    Attachment data = new Attachment(rutaArchivo, "text/html");
        //    correo.Attachments.Add(data);
        //    correo.IsBodyHtml = true;
        //    correo.Priority = System.Net.Mail.MailPriority.Normal;

        //    System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
        //    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

        //    smtp.Host = "192.168.1.2";
        //    smtp.Port = 25;
        //    smtp.Credentials = new System.Net.NetworkCredential("cayman@avaluac.com", "cayman1010");

        //    //correo.Credentials = new System.Net.NetworkCredential("gabriel.baldeon@caymansystems.com", "unreal");
        //    //correo.Port = 587;
        //    ////correo.Host = "smtp.gmail.com";
        //    //correo.Host = "74.125.45.109";


        //    //  smtp.EnableSsl = true;
        //    try
        //    {
        //        smtp.Send(correo);
        //    }

        //    catch (Exception ex)
        //    {
        //        //CreateLogFiles cl = new CreateLogFiles();
        //        //cl.ErrorLog("Mtodo email2: " + ex.Message);
        //        throw ex;
        //    }
        //}

        
}
