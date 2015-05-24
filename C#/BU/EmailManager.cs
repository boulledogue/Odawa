using BU.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BU
{
    public static class EmailManager
    {
        private static string emailHost = "smtp.skynet.be";
        private static string adminMail = "denis@charette.be";
        private static string emailFrom = "denis.charette@skynet.be";

        public static void EmailException(string message)
        {
            MailMessage mail = new MailMessage(emailFrom, adminMail);
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = emailHost;
            mail.Subject = "Erreur dans l'application Odawa, VEUILLEZ VERIFIER!";
            mail.Body = message.ToString();
            client.Send(mail);
        }

        public static void EmailCreateRestaurateur(Restaurateur r)
        {
            MailMessage mail = new MailMessage(emailFrom, r.email);
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = emailHost;
            mail.Subject = "Votre compte a été créé";
            mail.Body = "Bienvenue sur odawa!\n"
            + "Votre nom d'utilisateur: " + r.username + "\n"
            + "Votre mot de passe: " + r.password + "\n\n"
            + "Pour vous connecter, visitez http://www.odawa.be et cliquez sur connexion\n\n"
            + "Merci de votre confiance et à bientôt sur Odawa.";
            client.Send(mail);
        }
    }
}
