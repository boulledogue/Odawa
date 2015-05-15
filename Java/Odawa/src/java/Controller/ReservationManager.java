/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Controller;

import Models.ModelsMapping;
import Models.ReservationJ;
import Models.RestaurantJ;
import java.util.ArrayList;
import javax.xml.datatype.DatatypeConfigurationException;

/**
 *
 * @author Denis Charette
 */
public class ReservationManager {
    
    public static void Add(ReservationJ rj) throws DatatypeConfigurationException{        
        ModelsMapping.createReservation(rj);
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
    
    public static void Update(ReservationJ rj) throws DatatypeConfigurationException{        
        ModelsMapping.updateReservation(rj);
    }
}
