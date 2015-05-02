/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Models;

import java.util.*;
import org.datacontract.schemas._2004._07.bu.*;

/**
 *
 * @author Denis Charette
 */
public class ModelsMapping {
    
    public static void createReservation(Reservation r) {
        org.tempuri.OdawaService service = new org.tempuri.OdawaService();
        org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
        port.createReservation(r);
    }
    
    public static ArrayList<ReservationJ> getReservationByRestaurant(java.lang.Integer id) {
        org.tempuri.OdawaService service = new org.tempuri.OdawaService();
        org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
        List<Reservation> lstR =  port.getReservationByRestaurant(id).getReservation();
        ArrayList<ReservationJ> arrayReservationJ = new ArrayList<ReservationJ>();
        for(Reservation r : lstR){
            ReservationJ res = new ReservationJ();
            res.setId(r.getId());
            res.setNom(r.getNom().getValue());
            res.setPrenom(r.getPrenom().getValue());
            res.setDate(r.getDate().toGregorianCalendar().getTime());
            res.setTypeService(r.isTypeService());
            res.setNbPersonnes(r.getNbPersonnes());
            res.setEmail(r.getEmail().getValue());
            res.setPhone(r.getPhone().getValue());
            res.setIdRestaurant(r.getIdRestaurant());
            res.setStatus(r.getStatus());
            res.setEncodedDateTime(r.getEncodedDateTime().toGregorianCalendar().getTime());
            arrayReservationJ.add(res);
        }
        return arrayReservationJ;
    }
    
    public static void updateReservation(Reservation r) {
        org.tempuri.OdawaService service = new org.tempuri.OdawaService();
        org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
        port.updateReservation(r);
    }
    
    //------------------------
    
    public static void createRestaurant(Restaurant r) {
        org.tempuri.OdawaService service = new org.tempuri.OdawaService();
        org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
        port.createRestaurant(r);
    }
    
    public static ArrayList<RestaurantJ> SearchRestaurant(String s) {
        org.tempuri.OdawaService service = new org.tempuri.OdawaService();
        org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
        List<Restaurant> lstR = port.searchRestaurant(s).getRestaurant();
        ArrayList<RestaurantJ> arrayRestaurantJ = new ArrayList<RestaurantJ>();
        for(Restaurant r : lstR){            
            RestaurantJ rest = new RestaurantJ();
            rest.setId(r.getId());
            rest.setNom(r.getNom().getValue());
            rest.setAdresse(r.getAdresse().getValue());
            rest.setNumero(r.getNumero().getValue());
            rest.setZipCode(r.getNumero().getValue());
            rest.setLocalite(r.getLocalite().getValue());
            rest.setDescription(r.getDescription().getValue());
            rest.setBudgetLow(r.getBudgetLow());
            rest.setBudgetHigh(r.getBudgetHigh());
            rest.setPremium(r.isPremium());
            rest.setIdTypeCuisine(r.getIdTypeCuisine());
            rest.setIdRestaurateur(r.getIdRestaurateur());
            rest.setIdHoraire(r.getIdHoraire());
            arrayRestaurantJ.add(rest);
        }
        return arrayRestaurantJ;
    }

    public static void updateRestaurant(Restaurant r) {
        org.tempuri.OdawaService service = new org.tempuri.OdawaService();
        org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
        port.updateRestaurant(r);
    }

    public static void deleteRestaurant(java.lang.Integer id) {
        org.tempuri.OdawaService service = new org.tempuri.OdawaService();
        org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
        port.deleteRestaurant(id);
    }
}
