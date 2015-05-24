/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Controller;

import Models.ModelsMapping;
import Models.ReservationJ;
import Models.RestaurantJ;
import java.io.UnsupportedEncodingException;
import java.util.ArrayList;
import javax.xml.datatype.DatatypeConfigurationException;

/**
 *
 * @author Denis Charette
 */
public class ReservationManager {
    
    public static void Add(ReservationJ rj) throws DatatypeConfigurationException, UnsupportedEncodingException{        
        ModelsMapping.createReservation(rj);
        MailManager.SendCreateReservationMail(rj);
        MailManager.SendCreateReservationNotifMail(rj);
    }
    
    public static ReservationJ GetReservation(int id){
        ReservationJ r = ModelsMapping.getReservation(id);
        return r;
    }
    
    public static ArrayList<ReservationJ> GetReservationsByRestaurant(int id){
        ArrayList<ReservationJ> a = ModelsMapping.getReservationByRestaurant(id);
        return a;
    }
    
    public static ArrayList<ReservationJ> GetReservationsByRestaurateur(ArrayList<RestaurantJ> rst){
        ArrayList<ReservationJ> a = new ArrayList();
        for(RestaurantJ r : rst){            
            ArrayList<ReservationJ> rsvt = GetReservationsByRestaurant(r.getId());
            for(ReservationJ rv : rsvt){ 
                a.add(rv);
            }
        }
        return a;
    }
    
    public static void Update(ReservationJ rj) throws DatatypeConfigurationException, UnsupportedEncodingException{        
        ModelsMapping.updateReservation(rj);
        if (rj.getStatus() == 2) MailManager.SendAcceptReservationMail(rj);
        else if (rj.getStatus() == 3) MailManager.SendRefuseReservationMail(rj);
    }
    
    public static boolean IsValid(String nom, String prenom, String date, String typeService, String nbPersonnes, 
            String email, String phone, String idRestaurant, String statut, String encodedDateTime)
    {
        if(nom == null) return false;
        if(prenom == null) return false;
        if(date == null) return false;
        if(typeService == null) return false;
        if(nbPersonnes == null) return false;
        if(email == null) return false;
        if(phone == null) return false;
        if(idRestaurant == null) return false;
        if(statut == null) return false;
        if(encodedDateTime == null) return false;
        
        try
        {
            Integer.parseInt(nbPersonnes);
            Integer.parseInt(idRestaurant);
            Integer.parseInt(statut);
        } catch(NumberFormatException e) { return false; } 
        return true;
    }
}
