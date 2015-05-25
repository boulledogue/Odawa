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
                //insertion dans le fichier log
                try
                {
                    LogManager.LogException(ex);
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
