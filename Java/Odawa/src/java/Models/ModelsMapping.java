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
 * @author Alistreaza
 */
public class ModelsMapping {
    
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
    
}
