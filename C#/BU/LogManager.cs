using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BU
{
    public static class LogManager
    {
        private static string tmpPath = System.IO.Path.GetTempPath();

        public static void LogException(Exception ex)
        {
            //construction du message d'erreur
            StringBuilder messageSB = new StringBuilder();
            string executingAssembly = System.Reflection.Assembly.GetExecutingAssembly().ToString();
            messageSB.Append(DateTime.Now + " - ");
            messageSB.Append(executingAssembly + " - ");
            if (ex == null) messageSB.Append("Erreur inconnue!");
            else
            {
                messageSB.Append(ex.ToString());
                if (ex.InnerException != null) messageSB.Append(ex.InnerException.ToString());
            }
            messageSB.Append("\n-----------------------------------------------------------\n");
            string logFilePath =  tmpPath + "OdawaExceptionLog.log";

            //ajout au fichier dont le chemin complet est spécifié à la ligne précédente
            try
            {
                System.IO.File.AppendAllText(logFilePath, messageSB.ToString());
            }
            catch
            {
                //on ne fait rien si une exception survient pendant la création du log, ne peut être bloquant
            }

            //envoi de l'exception formatée par email
            try
            {
                EmailManager.EmailException(messageSB.ToString());
            }
            catch
            {
                //on ne fait rien si une exception survient pendant l'envoi du mail, ne peut être bloquant
            }
        }

        public static void LogNullException(string message)
        {
            //construction du message d'erreur
            StringBuilder messageSB = new StringBuilder();
            messageSB.Append(DateTime.Now + " - ");
            if (message == null) messageSB.Append("Erreur: valeur 'null' inconnue!");
            else messageSB.Append(message);
            messageSB.Append("\n-----------------------------------------------------------\n");
            string logFilePath = tmpPath + "OdawaNullExceptionLog.log";

            //ajout au fichier dont le chemin complet est spécifié à la ligne précédente
            try
            {
                System.IO.File.AppendAllText(logFilePath, messageSB.ToString());
            }
            catch
            {
                //on ne fait rien si une exception survient pendant la création du log, ne peut être bloquant
            }
        }
    }
}
