/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Controller;

import Models.ReservationJ;
import Models.RestaurantJ;
import Models.RestaurateurJ;
import Utils.LogManager;
import java.io.UnsupportedEncodingException;
import java.text.Format;
import java.text.SimpleDateFormat;
import java.util.Properties;
import javax.mail.Message;
import javax.mail.MessagingException;
import javax.mail.PasswordAuthentication;
import javax.mail.Session;
import javax.mail.Transport;
import javax.mail.internet.AddressException;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeMessage;

/**
 * Attention, veuillez désactiver votre anti-virus/pare-feu pour utiliser le MailManager -> sinon exception
 * @author Denis Charette
 */
public class MailManager {

    //serveur utilisé pour envoyer les emails, je dois utiliser le serveur de mon provider
    private final static String mailHost = "smtp.gmail.com";
    //port pour l'envoi des emails
    private final static String mailPort = "587";
    //adresse email de l'administrateur de l'application Odawa
    private final static String mailAdmin = "denis@charette.be";
    //adresse email "From", j'ai du utiliser la mienne pour m'authentifier correctement sur le server Skynet
    private final static String mailFrom = "odawa.mailing@gmail.com";
    //nom convivial pour le destinataire de l'email
    private final static String mailFromName = "Odawa Automatic Mailing";
    //mot de passe du compte mail pour l'envoi
    private final static String mailFromPassword = "EsaProjet2015";
    
    //envoi d'un mail à l'utilisateur lors de la création d'une réservation
    public static void SendCreateReservationMail(ReservationJ r) throws UnsupportedEncodingException {
        RestaurantJ restaurant = RestaurantManager.GetRestaurant(r.getIdRestaurant());
        RestaurateurJ restaurateur = RestaurateurManager.getRestaurateurByRestaurant(r.getIdRestaurant());
        Properties props = new Properties();
        props.put("mail.smtp.auth", "true");
        props.put("mail.smtp.starttls.enable", "true");
        props.put("mail.smtp.host", mailHost);
        props.put("mail.smtp.port", mailPort);
        Format formatter = new SimpleDateFormat("dd/MM/yyyy");

        Session session = Session.getInstance(props,
		  new javax.mail.Authenticator() {
			protected PasswordAuthentication getPasswordAuthentication() {
				return new PasswordAuthentication(mailFrom,mailFromPassword);
			}
		  });
        try {
            Message message = new MimeMessage(session);
            message.setFrom(new InternetAddress(mailFrom));
            message.setRecipients(Message.RecipientType.TO,
            InternetAddress.parse(r.getEmail()));
            message.setSubject("Votre demande de réservation chez '" + restaurant.getNom() + "' est enregistrée");
            String messageBody = "Votre réservation a bien été prise en compte.\n"
            + "Veuillez noter que celle-ci doit encore être confirmée par le restaurant.\n"
            + "Voici les détails de votre réservation:\n\n"
            + "Restaurant: " + restaurant.getNom() + "\n"
            + "Adresse: " + restaurant.getAdresse() + " " + restaurant.getNumero() + ", " + restaurant.getZipCode() + " " + restaurant.getLocalite() + "\n"
            + "Téléphone: " + restaurateur.getPhone() + "\n"
            + "Nombre de personnes: " + r.getNbPersonnes() + "\n"                
            + "Date: " + formatter.format(r.getDate()) + "\n";
            if (!r.getTypeService()){
                messageBody += "Pour le service du midi.\n\n";
            }else{
                messageBody += "Pour le service du soir.\n\n";
            }
            messageBody += "Merci de la confiance que vous nous accordez.\n\n"
            + "L'équipe Odawa";
            message.setText(messageBody);
            Transport.send(message);
      } catch (Exception e) {
            LogManager l = new LogManager();
            l.LogMailException(e);
            //log en cas d'exception lors de l'envoi d'un mail, pas de blocage
      }
    }
    
    //envoi d'un mail de notifiation au restaurateur lors de la création d'une réservation
    public static void SendCreateReservationNotifMail(ReservationJ r) throws UnsupportedEncodingException {
        RestaurantJ restaurant = RestaurantManager.GetRestaurant(r.getIdRestaurant());
        RestaurateurJ restaurateur = RestaurateurManager.getRestaurateurByRestaurant(r.getIdRestaurant());
        Properties props = new Properties();
        props.put("mail.smtp.auth", "true");
        props.put("mail.smtp.starttls.enable", "true");
        props.put("mail.smtp.host", mailHost);
        props.put("mail.smtp.port", mailPort);
        Format formatter = new SimpleDateFormat("dd/MM/yyyy");

        Session session = Session.getInstance(props,
		  new javax.mail.Authenticator() {
			protected PasswordAuthentication getPasswordAuthentication() {
				return new PasswordAuthentication(mailFrom,mailFromPassword);
			}
		  });
        try {
            Message message = new MimeMessage(session);
            message.setFrom(new InternetAddress(mailFrom));
            message.setRecipients(Message.RecipientType.TO,
            InternetAddress.parse(r.getEmail()));
            message.setSubject("Une nouvelle demande de réservation chez '" + restaurant.getNom() + "' est enregistrée");
            String messageBody = "Une nouvelle réservation vient d'être enregistrée.\n"
            + "Voici les détails de la réservation:\n\n"
            + "Nom: " + r.getNom() + " " + r.getPrenom() + "\n"
            + "Restaurant: " + restaurant.getNom() + "\n"
            + "Adresse: " + restaurant.getAdresse() + " " + restaurant.getNumero() + ", " + restaurant.getZipCode() + " " + restaurant.getLocalite() + "\n"
            + "Nombre de personnes: " + r.getNbPersonnes() + "\n"                
            + "Date: " + formatter.format(r.getDate()) + "\n";
            if (!r.getTypeService()){
                messageBody += "Pour le service du midi.\n\n";
            }else{
                messageBody += "Pour le service du soir.\n\n";
            }
            messageBody += "Vous pouvez gérer les réservations en attente en vous connectant sur le site d'Odawa.\n"
            + "Merci de la confiance que vous nous accordez.\n\n"
            + "L'équipe Odawa";
            message.setText(messageBody);
            Transport.send(message);
        } catch (Exception e) {
            LogManager l = new LogManager();
            l.LogMailException(e);
            //log en cas d'exception lors de l'envoi d'un mail, pas de blocage
        }
    }
    
    //envoi du mail de confirmation à l'utilisateur lors de la validation par le restaurateur
    public static void SendAcceptReservationMail(ReservationJ r) throws UnsupportedEncodingException {
        RestaurantJ restaurant = RestaurantManager.GetRestaurant(r.getIdRestaurant());
        RestaurateurJ restaurateur = RestaurateurManager.getRestaurateurByRestaurant(r.getIdRestaurant());
        Properties props = new Properties();
        props.put("mail.smtp.auth", "true");
        props.put("mail.smtp.starttls.enable", "true");
        props.put("mail.smtp.host", mailHost);
        props.put("mail.smtp.port", mailPort);
        Format formatter = new SimpleDateFormat("dd/MM/yyyy");

        Session session = Session.getInstance(props,
		  new javax.mail.Authenticator() {
			protected PasswordAuthentication getPasswordAuthentication() {
				return new PasswordAuthentication(mailFrom,mailFromPassword);
			}
		  });
        try {
            Message message = new MimeMessage(session);
            message.setFrom(new InternetAddress(mailFrom));
            message.setRecipients(Message.RecipientType.TO,
            InternetAddress.parse(r.getEmail()));
            message.setSubject("Votre demande de réservation chez '" + restaurant.getNom() + "' est confirmée");
            String messageBody = "Nous avons le plaisir de vous informer que votre réservation est confirmée.\n"
                + "Pour rappel, voici les détails de votre réservation:\n\n"
                + "Restaurant: " + restaurant.getNom() + "\n"
                + "Adresse: " + restaurant.getAdresse() + " " + restaurant.getNumero() + ", " + restaurant.getZipCode() + " " + restaurant.getLocalite() + "\n"
                + "Téléphone: " + restaurateur.getPhone() + "\n"
                + "Nombre de personnes: " + r.getNbPersonnes() + "\n"
                + "Date: " + formatter.format(r.getDate()) + "\n";
                if (!r.getTypeService()){
                    messageBody += "Pour le service du midi.\n\n";
                }else{
                    messageBody += "Pour le service du soir.\n\n";
                }
                messageBody += "Merci de la confiance que vous nous accordez.\n\n"
                + "L'équipe Odawa";
            message.setText(messageBody);
            Transport.send(message);
      } catch (Exception e) {
            LogManager l = new LogManager();
            l.LogMailException(e);
            //log en cas d'exception lors de l'envoi d'un mail, pas de blocage
      }
    }
    
    //envoi d'un mail à l'utilisateur lors du refus de la réservation par le restaurateur
    public static void SendRefuseReservationMail(ReservationJ r) throws UnsupportedEncodingException {
        RestaurantJ restaurant = RestaurantManager.GetRestaurant(r.getIdRestaurant());
        RestaurateurJ restaurateur = RestaurateurManager.getRestaurateurByRestaurant(r.getIdRestaurant());
        Properties props = new Properties();
        props.put("mail.smtp.auth", "true");
        props.put("mail.smtp.starttls.enable", "true");
        props.put("mail.smtp.host", mailHost);
        props.put("mail.smtp.port", mailPort);
        Format formatter = new SimpleDateFormat("dd/MM/yyyy");

        Session session = Session.getInstance(props,
		  new javax.mail.Authenticator() {
			protected PasswordAuthentication getPasswordAuthentication() {
				return new PasswordAuthentication(mailFrom,mailFromPassword);
			}
		  });
        try {
            Message message = new MimeMessage(session);
            message.setFrom(new InternetAddress(mailFrom));
            message.setRecipients(Message.RecipientType.TO,
            InternetAddress.parse(r.getEmail()));
            message.setSubject("Votre demande de réservation chez '" + restaurant.getNom() + "' est refusée");
            String messageBody = "Nous sommes au regret de vous informer que votre réservation est refusée.\n"
                + "Pour rappel, voici les détails de votre réservation:\n\n"
                + "Restaurant: " + restaurant.getNom() + "\n"
                + "Adresse: " + restaurant.getAdresse() + " " + restaurant.getNumero() + ", " + restaurant.getZipCode() + " " + restaurant.getLocalite() + "\n"
                + "Téléphone: " + restaurateur.getPhone() + "\n"
                + "Nombre de personnes: " + r.getNbPersonnes() + "\n"
                + "Date: " + formatter.format(r.getDate()) + "\n";
                if (!r.getTypeService()){
                    messageBody += "Pour le service du midi.\n\n";
                }else{
                    messageBody += "Pour le service du soir.\n\n";
                }
                messageBody += "Merci de la confiance que vous nous accordez.\n\n"
                + "L'équipe Odawa";
            message.setText(messageBody);
            Transport.send(message);
      } catch (Exception e) {
            LogManager l = new LogManager();
            l.LogMailException(e);
            //log en cas d'exception lors de l'envoi d'un mail, pas de blocage
      }
    }    
}
