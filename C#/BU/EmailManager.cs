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
        public static void EmailError(string message)
        {
            string adminMail = "denis@charette.be";
            string emailFrom = "denis.charette@skynet.be";
            MailMessage mail = new MailMessage(emailFrom, adminMail);
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.skynet.be";
            mail.Subject = "Erreur dans l'application Odawa, VEUILLEZ VERIFIER!";
            mail.Body = message.ToString();
            client.Send(mail);
        }

        public static void EmailCreateRestaurateur(Restaurateur r)
        {
            MailMessage mail = new MailMessage("denis.charette@skynet.be", r.email);
            SmtpClient client = new SmtpClient();
            client.Port = 25;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Host = "smtp.skynet.be";
            mail.Subject = "Votre compte a été créé";
            mail.Body = "Bienvenue sur odawa!\n"
            + "Votre nom d'utilisateur: " + r.username + "\n"
            + "Votre mot de passe: " + r.password + "\n";
            client.Send(mail);
        }
    }
}
