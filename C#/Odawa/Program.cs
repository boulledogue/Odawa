using BU;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Odawa
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                //construction du message d'erreur
                StringBuilder messageSB = new StringBuilder();
                string executingAssembly = System.Reflection.Assembly.GetExecutingAssembly().ToString();
                messageSB.Append(DateTime.Now + " - ");
                messageSB.Append(executingAssembly + " - ");
                if (ex == null)
                {
                    messageSB.Append("Erreur inconnue!");
                }
                else
                {
                    messageSB.Append(ex.ToString());
                    if (ex.InnerException != null) messageSB.Append(ex.InnerException.ToString());
                }
                messageSB.Append("\n-----------------------------------------------------------\n");
                
                //insertion dans le fichier log
                try
                {
                    LogManager.LogException(messageSB.ToString());
                }
                catch
                {
                    //on ne fait rien ici, ça ne peut pas être bloquant pour fermer l'application
                }

                //envoi d'un email
                try
                {
                    EmailManager.EmailException(messageSB.ToString());
                }
                catch
                {
                    //on ne fait rien ici, ça ne peut pas être bloquant pour fermer l'application
                }
                finally
                {
                    //affichage d'un message convivial et fermeture propre
                    String message = "Une erreur s'est produite, l'application va maintenant se fermer.";
                    MessageBoxIcon icon = MessageBoxIcon.Error;
                    MessageBoxButtons button = MessageBoxButtons.OK;
                    MessageBox.Show(message, "Erreur", button, icon);
                    Application.Exit();
                }
            }
        }
    }
}
