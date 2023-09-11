using System; 
using System.Diagnostics; 
using System.Text;
using System.Data;
using System.Configuration;
using System.Web;
using System.Security;
using System.IO;
using System.Reflection;

    public class ErrorTrapper
    {
        private string sLogFormat;
        private string sErrorTime;	
        public int ErrorNumber;
        public string ErrorMessage;

        public void SetOnError(string sMsg, int correoTec)
        {
            sLogFormat = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> ";
            string sYear = DateTime.Now.Year.ToString();
            string sMonth = DateTime.Now.Month.ToString();
            string sDay = DateTime.Now.Day.ToString();
            sErrorTime = sDay + "." + sMonth + "." + sYear;

            int nStackCnt = 0;
            StringBuilder oString = new StringBuilder();
            StackTrace oStack = new StackTrace(true);

            nStackCnt = oStack.FrameCount;

            // I've decided to only show the last few items of the stack. 
            // They are displayed in order by most recent frame. 

            if (nStackCnt > 5) 
            { 
                nStackCnt = 5; 
            }

            for (int i = 0; i < nStackCnt; i++)
            {
                // The first frame (0) is always this method (SetOnError), 
                // so we don't want to display it. 

                if (i > 0)
                {
                    oString.Append(oStack.GetFrame(i).GetMethod().ReflectedType.FullName + "\n");
                    oString.Append(" " + oStack.GetFrame(i).GetMethod().ToString() + "\n");

                    // If it is the first frame we want to view, it will contain info from the 
                    // class/method that generated the error 

                    if (i == 1) { oString.Append(" " + sMsg + "\n\n"); }
                }
            }

            //// Flag our class to react in RedirectOnError when it is called. 

            //this.ErrorNumber = 2;
            //this.ErrorMessage = oString.ToString();

            try
            {

                StreamWriter sw = new StreamWriter(System.Web.HttpContext.Current.Server.MapPath("~")+"/Site/Administracion/Logs/Log_" + sErrorTime+".txt", true);
                sw.WriteLine(sLogFormat + oString.ToString());
                sw.WriteLine("");
                sw.Flush();
                sw.Close();
                sw.Dispose();

                if (correoTec == 1)
                {
                    Correos cor = new Correos();
                    cor.enviarCorreoAdmin(sLogFormat + oString.ToString(), sErrorTime);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //public void RedirectOnError()
        //{
            
        //  //  if (this.ErrorNumber == 0) { return; }
        //    // If an error exists, react with your custom page/notification process. 
        //   // System.Console.WriteLine(this.ErrorMessage);
        //}

    }

