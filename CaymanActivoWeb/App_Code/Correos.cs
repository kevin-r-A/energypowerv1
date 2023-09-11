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
using System.Web.Mail;
using System.Diagnostics;
using System.Reflection;
using System.Net.Configuration;

/// <summary>
/// Summary description for Correos
/// </summary>
public class Correos
{
        public Correos()
        {
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
