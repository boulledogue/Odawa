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
        //Constantes pour l'envoi d'un email: adresse d'expédition, adresse de l'admin de l'application (support), serveur smtp, mot de passe, port
        private static MailAddress fromAddress = new MailAddress("odawa.mailing@gmail.com", "Odawa Automatic Mailing");
        private static MailAddress adminEmail = new MailAddress("denis@charette.be", "Administrateur Odawa");
        private static string emailHost = "smtp.gmail.com";
        private static string fromPassword = "EsaProjet2015";
        private static int port = 587;

        //Envoi d'un email en cas d'exception irrécupérable (crash), le corps du message est passé en paramètre
        public static void EmailException(string message)
        {
            //Paramétrage pour Gmail
            var smtp = new SmtpClient
            {
                Host = emailHost,
                Port = port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            //Initialise un email pour l'envoyer de "fromAddress" à "adminEmail"
            using (var email = new MailMessage(fromAddress, adminEmail)
            {
                //Sujet de l'email
                Subject = "Erreur dans l'application Odawa, VEUILLEZ VERIFIER!",
                //Corps de l'email
                Body = message
            })
            {
                //Envoi
                smtp.Send(email);
            }
        }

        //Envoi de l'email de confirmation de la création du compte restaurateur (passé en paramètre)
        public static void EmailCreateRestaurateur(Restaurateur r)
        {
            //Construction de la chaine nom + prénom
            string restaurateurNom = r.nom + " " + r.prenom;
            //Construction de l'adresse du destinataire (email passé en paramètre, chaine nom + prénom)
            MailAddress restaurateurEmail = new MailAddress(r.email, restaurateurNom);
            //Paramétrage pour Gmail
            var smtp = new SmtpClient
            {
                Host = emailHost,
                Port = port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            //Initialise un email pour l'envoyer de "fromAddress" à "restaurateurEmail"
            using (var email = new MailMessage(fromAddress, restaurateurEmail)
            {
                //Sujet de l'email
                Subject = "Votre compte a été créé",
                //Corps de l'email
                Body = "Bienvenue sur odawa!\n"
                + "Votre nom d'utilisateur: " + r.username + "\n"
                + "Votre mot de passe: " + r.password + "\n\n"
                + "Pour vous connecter, visitez http://www.odawa.be et cliquez sur connexion\n\n"
                + "Merci de votre confiance et à bientôt sur Odawa."
            })
            {
                //Envoi de l'email
                smtp.Send(email);
            }
        }
    }
}
