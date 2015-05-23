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

    private final static String mailHost = "smtp.skynet.be";
    private final static String mailFrom = "denis.charette@skynet.be";
    private final static String mailFromName = "Odawa Automatic Mailing";
    
    public static void SendCreateReservationMail(ReservationJ r) throws UnsupportedEncodingException {
        RestaurantJ rest = RestaurantManager.GetRestaurant(r.getIdRestaurant());
        RestaurateurJ restau = RestaurateurManager.getRestaurateurByRestaurant(r.getIdRestaurant());
        Properties props = new Properties();
        props.put("mail.smtp.host", mailHost);
        Format formatter = new SimpleDateFormat("dd/MM/yyyy");

        Session session = Session.getDefaultInstance(props);

        String msgBody = "Votre réservation a bien été prise en compte.\n"
                + "Veuillez noter que celle-ci doit encore être confirmée par le restaurant.\n"
                + "Voici les détails de votre réservation:\n\n"
                + "Restaurant: " + rest.getNom() + "\n"
                + "Adresse: " + rest.getAdresse() + " " + rest.getNumero() + ", " + rest.getZipCode() + " " + rest.getLocalite() + "\n"
                + "Téléphone: " + restau.getPhone() + "\n"
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
            msg.setSubject("Votre demande de réservation chez '" + rest.getNom() + "' est enregistrée");
            msg.setText(msgBody);
            Transport.send(msg);

        } catch (AddressException e) {
            // ne peut être bloquant pour l'application
        } catch (MessagingException e) {
            // ne peut être bloquant pour l'application
        }
    }
    
    public static void SendAcceptReservationMail(ReservationJ r) throws UnsupportedEncodingException {
        RestaurantJ rest = RestaurantManager.GetRestaurant(r.getIdRestaurant());
        RestaurateurJ restau = RestaurateurManager.getRestaurateurByRestaurant(r.getIdRestaurant());
        Properties props = new Properties();
        props.put("mail.smtp.host", mailHost);
        Format formatter = new SimpleDateFormat("dd/MM/yyyy");

        Session session = Session.getDefaultInstance(props);

        String msgBody = "Nous avons le plaisir de vous informer que votre réservation est confirmée.\n"
                + "Voici les détails de votre réservation:\n\n"
                + "Restaurant: " + rest.getNom() + "\n"
                + "Adresse: " + rest.getAdresse() + " " + rest.getNumero() + ", " + rest.getZipCode() + " " + rest.getLocalite() + "\n"
                + "Téléphone: " + restau.getPhone() + "\n"
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
            msg.setSubject("Votre demande de réservation chez '" + rest.getNom() + "' est confirmée");
            msg.setText(msgBody);
            Transport.send(msg);

        } catch (AddressException e) {
            // ne peut être bloquant pour l'application
        } catch (MessagingException e) {
            // ne peut être bloquant pour l'application
        }
    }
    
    public static void SendRefuseReservationMail(ReservationJ r) throws UnsupportedEncodingException {
        RestaurantJ rest = RestaurantManager.GetRestaurant(r.getIdRestaurant());
        RestaurateurJ restau = RestaurateurManager.getRestaurateurByRestaurant(r.getIdRestaurant());
        Properties props = new Properties();
        props.put("mail.smtp.host", mailHost);
        Format formatter = new SimpleDateFormat("dd/MM/yyyy");

        Session session = Session.getDefaultInstance(props);

        String msgBody = "Nous sommes au regret de vous informer que votre réservation est refusée.\n"
                + "Voici les détails de votre réservation:\n\n"
                + "Restaurant: " + rest.getNom() + "\n"
                + "Adresse: " + rest.getAdresse() + " " + rest.getNumero() + ", " + rest.getZipCode() + " " + rest.getLocalite() + "\n"
                + "Téléphone: " + restau.getPhone() + "\n"
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
            msg.setSubject("Votre demande de réservation chez '" + rest.getNom() + "' est refusée");
            msg.setText(msgBody);
            Transport.send(msg);

        } catch (AddressException e) {
            // ne peut être bloquant pour l'application
        } catch (MessagingException e) {
            // ne peut être bloquant pour l'application
        }
    }
}
