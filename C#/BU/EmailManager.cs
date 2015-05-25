using BU.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BU
{
    public static class EmailManager
    {
        private static MailAddress fromAddress = new MailAddress("odawa.mailing@gmail.com", "Odawa Automatic Mailing");
        private static MailAddress adminEmail = new MailAddress("denis@charette.be", "Administrateur Odawa");
        private static string emailHost = "smtp.gmail.com";
        private static string fromPassword = "EsaProjet2015";
        private static int port = 587;

        public static void EmailException(string message)
        {
            var smtp = new SmtpClient
            {
                Host = emailHost,
                Port = port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var email = new MailMessage(fromAddress, adminEmail)
            {
                Subject = "Erreur dans l'application Odawa, VEUILLEZ VERIFIER!",
                Body = message
            })
            {
                smtp.Send(email);
            }
        }

        public static void EmailCreateRestaurateur(Restaurateur r)
        {
            string restaurateurNom = r.nom + " " + r.prenom;
            MailAddress restaurateurEmail = new MailAddress(r.email, restaurateurNom);
            var smtp = new SmtpClient
            {
                Host = emailHost,
                Port = port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var email = new MailMessage(fromAddress, restaurateurEmail)
            {
                Subject = "Votre compte a été créé",
                Body = "Bienvenue sur odawa!\n"
                + "Votre nom d'utilisateur: " + r.username + "\n"
                + "Votre mot de passe: " + r.password + "\n\n"
                + "Pour vous connecter, visitez http://www.odawa.be et cliquez sur connexion\n\n"
                + "Merci de votre confiance et à bientôt sur Odawa."
            })
            {
                smtp.Send(email);
            }
        }
    }
}
