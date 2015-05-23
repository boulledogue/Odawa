/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Controller;

import Models.ReservationJ;
import Models.RestaurantJ;
import Models.RestaurateurJ;
import java.io.UnsupportedEncodingException;
import java.text.Format;
import java.text.SimpleDateFormat;
import java.util.Properties;
import javax.mail.Message;
import javax.mail.MessagingException;
import javax.mail.Session;
import javax.mail.Transport;
import javax.mail.internet.AddressException;
import javax.mail.internet.InternetAddress;
import javax.mail.internet.MimeMessage;

/**
 *
 * @author Denis Charette
 */
public class MailManager {

    //serveur utilisé pour envoyer les emails, je dois utiliser le serveur de mon provider
    private final static String mailHost = "smtp.skynet.be";
    //adresse email de l'administrateur de l'application Odawa
    private final static String mailAdmin = "denis@charette.be";
    //adresse email "From", j'ai du utiliser la mienne pour m'authentifier correctement sur le server Skynet
    private final static String mailFrom = "denis.charette@skynet.be";
    //nom convivial pour le destinataire de l'email
    private final static String mailFromName = "Odawa Automatic Mailing";
    
    //envoi d'un mail à l'utilisateur lors de la création d'une réservation
    public static void SendCreateReservationMail(ReservationJ r) throws UnsupportedEncodingException {
        RestaurantJ restaurant = RestaurantManager.GetRestaurant(r.getIdRestaurant());
        RestaurateurJ restaurateur = RestaurateurManager.getRestaurateurByRestaurant(r.getIdRestaurant());
        Properties props = new Properties();
        props.put("mail.smtp.host", mailHost);
        Format formatter = new SimpleDateFormat("dd/MM/yyyy");

        Session session = Session.getDefaultInstance(props);

        String msgBody = "Votre réservation a bien été prise en compte.\n"
                + "Veuillez noter que celle-ci doit encore être confirmée par le restaurant.\n"
                + "Voici les détails de votre réservation:\n\n"
                + "Restaurant: " + restaurant.getNom() + "\n"
                + "Adresse: " + restaurant.getAdresse() + " " + restaurant.getNumero() + ", " + restaurant.getZipCode() + " " + restaurant.getLocalite() + "\n"
                + "Téléphone: " + restaurateur.getPhone() + "\n"
                + "Nombre de personnes: " + r.getNbPersonnes() + "\n"                
                + "Date: " + formatter.format(r.getDate()) + "\n";
                if (!r.getTypeService()){
                    msgBody += "Pour le service du midi.\n\n";
                }else{
                    msgBody += "Pour le service du soir.\n\n";
                }
                msgBody += "Merci de la confiance que vous nous accordez.\n\n"
                + "L'équipe Odawa";
        try {
            Message msg = new MimeMessage(session);
            msg.setFrom(new InternetAddress(mailFrom, mailFromName));
            msg.setRecipients(Message.RecipientType.TO,
                    InternetAddress.parse(r.getEmail()));
            msg.setSubject("Votre demande de réservation chez '" + restaurant.getNom() + "' est enregistrée");
            msg.setText(msgBody);
            Transport.send(msg);

        } catch (AddressException e) {
            // ne peut être bloquant pour l'application
        } catch (MessagingException e) {
            // ne peut être bloquant pour l'application
        }
    }
    
    //envoi du mail de confirmation à l'utilisateur lors de la validation par le restaurateur
    public static void SendAcceptReservationMail(ReservationJ r) throws UnsupportedEncodingException {
        RestaurantJ restaurant = RestaurantManager.GetRestaurant(r.getIdRestaurant());
        RestaurateurJ restaurateur = RestaurateurManager.getRestaurateurByRestaurant(r.getIdRestaurant());
        Properties props = new Properties();
        props.put("mail.smtp.host", mailHost);
        Format formatter = new SimpleDateFormat("dd/MM/yyyy");

        Session session = Session.getDefaultInstance(props);

        String msgBody = "Nous avons le plaisir de vous informer que votre réservation est confirmée.\n"
                + "Voici les détails de votre réservation:\n\n"
                + "Restaurant: " + restaurant.getNom() + "\n"
                + "Adresse: " + restaurant.getAdresse() + " " + restaurant.getNumero() + ", " + restaurant.getZipCode() + " " + restaurant.getLocalite() + "\n"
                + "Téléphone: " + restaurateur.getPhone() + "\n"
                + "Nombre de personnes: " + r.getNbPersonnes() + "\n"
                + "Date: " + formatter.format(r.getDate()) + "\n";
                if (!r.getTypeService()){
                    msgBody += "Pour le service du midi.\n\n";
                }else{
                    msgBody += "Pour le service du soir.\n\n";
                }
                msgBody += "Merci de la confiance que vous nous accordez.\n\n"
                + "L'équipe Odawa";
        try {
            Message msg = new MimeMessage(session);
            msg.setFrom(new InternetAddress(mailFrom, mailFromName));
            msg.setRecipients(Message.RecipientType.TO,
                    InternetAddress.parse(r.getEmail()));
            msg.setSubject("Votre demande de réservation chez '" + restaurant.getNom() + "' est confirmée");
            msg.setText(msgBody);
            Transport.send(msg);

        } catch (AddressException e) {
            // ne peut être bloquant pour l'application
        } catch (MessagingException e) {
            // ne peut être bloquant pour l'application
        }
    }
    
    //envoi d'un mail à l'utilisateur lors du refus de la réservation par le restaurateur
    public static void SendRefuseReservationMail(ReservationJ r) throws UnsupportedEncodingException {
        RestaurantJ restaurant = RestaurantManager.GetRestaurant(r.getIdRestaurant());
        RestaurateurJ restaurateur = RestaurateurManager.getRestaurateurByRestaurant(r.getIdRestaurant());
        Properties props = new Properties();
        props.put("mail.smtp.host", mailHost);
        Format formatter = new SimpleDateFormat("dd/MM/yyyy");

        Session session = Session.getDefaultInstance(props);

        String msgBody = "Nous sommes au regret de vous informer que votre réservation est refusée.\n"
                + "Voici les détails de votre réservation:\n\n"
                + "Restaurant: " + restaurant.getNom() + "\n"
                + "Adresse: " + restaurant.getAdresse() + " " + restaurant.getNumero() + ", " + restaurant.getZipCode() + " " + restaurant.getLocalite() + "\n"
                + "Téléphone: " + restaurateur.getPhone() + "\n"
                + "Nombre de personnes: " + r.getNbPersonnes() + "\n"
                + "Date: " + formatter.format(r.getDate()) + "\n";
                if (!r.getTypeService()){
                    msgBody += "Pour le service du midi.\n\n";
                }else{
                    msgBody += "Pour le service du soir.\n\n";
                }
                msgBody += "Merci de la confiance que vous nous accordez.\n\n"
                + "L'équipe Odawa";
        try {
            Message msg = new MimeMessage(session);
            msg.setFrom(new InternetAddress(mailFrom, mailFromName));
            msg.setRecipients(Message.RecipientType.TO,
                    InternetAddress.parse(r.getEmail()));
            msg.setSubject("Votre demande de réservation chez '" + restaurant.getNom() + "' est refusée");
            msg.setText(msgBody);
            Transport.send(msg);

        } catch (AddressException e) {
            // ne peut être bloquant pour l'application
        } catch (MessagingException e) {
            // ne peut être bloquant pour l'application
        }
    }
    
    //envoi d'un mail de notifiation au restaurateur lors de la création d'une réservation
    public static void SendCreateReservationNotifMail(ReservationJ r) throws UnsupportedEncodingException {
        RestaurantJ restaurant = RestaurantManager.GetRestaurant(r.getIdRestaurant());
        RestaurateurJ restaurateur = RestaurateurManager.getRestaurateurByRestaurant(r.getIdRestaurant());
        Properties props = new Properties();
        props.put("mail.smtp.host", mailHost);
        Format formatter = new SimpleDateFormat("dd/MM/yyyy");

        Session session = Session.getDefaultInstance(props);

        String msgBody = "Une nouvelle réservation vient d'être enregistrée.\n"
                + "Voici les détails de la réservation:\n\n"
                + "Restaurant: " + restaurant.getNom() + "\n"
                + "Adresse: " + restaurant.getAdresse() + " " + restaurant.getNumero() + ", " + restaurant.getZipCode() + " " + restaurant.getLocalite() + "\n"
                + "Nombre de personnes: " + r.getNbPersonnes() + "\n"                
                + "Date: " + formatter.format(r.getDate()) + "\n";
                if (!r.getTypeService()){
                    msgBody += "Pour le service du midi.\n\n";
                }else{
                    msgBody += "Pour le service du soir.\n\n";
                }
                msgBody += "Vous pouvez gérer les réservations en attente en vous connectant sur le site d'Odawa.\n"
                + "Merci de la confiance que vous nous accordez.\n\n"
                + "L'équipe Odawa";
        try {
            Message msg = new MimeMessage(session);
            msg.setFrom(new InternetAddress(mailFrom, mailFromName));
            msg.setRecipients(Message.RecipientType.TO,
                    InternetAddress.parse(restaurateur.getEmail()));
            msg.setSubject("Une nouvelle demande de réservation chez '" + restaurant.getNom() + "' est enregistrée");
            msg.setText(msgBody);
            Transport.send(msg);

        } catch (AddressException e) {
            // ne peut être bloquant pour l'application
        } catch (MessagingException e) {
            // ne peut être bloquant pour l'application
        }
    }
}
