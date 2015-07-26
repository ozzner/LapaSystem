using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;

namespace Entidades
{
    public class ENT_Error
    {
        string MsjError;
        string FunError;
        string App;

        string ruta = ""; //HttpRuntime.AppDomainAppPath;

        public ENT_Error(string msjerror, string metodo, string app)
        {
            MsjError = msjerror;
            FunError = metodo;
            App = app;
        }

        public void RegisterLog()
        {
            string strPathLog = "C:\\LapaWeb\\"+DateTime.Today.Year+"\\LogWeb" + DateTime.Today.Year + "-" + DateTime.Today.Month + "-" + DateTime.Today.Day + ".log";
            TextWriter tx = new StreamWriter(strPathLog, true);
            tx.WriteLine(DateTime.Now.ToString());
            tx.WriteLine("Mensaje: " + MsjError);
            tx.WriteLine("Metodo: " + FunError);
            tx.WriteLine("Aplicacion: " + App);
            tx.WriteLine("\r");
            tx.Close();
        }
    }
}
