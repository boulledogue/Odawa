/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Controller;

import Models.ModelsMapping;
import Models.RestaurantJ;
import java.util.ArrayList;
import java.util.HashSet;
import java.util.Set;
import org.datacontract.schemas._2004._07.bu.*;

/**
 *
 * @author Denis Charette
 */
public class RestaurantManager {
    
    public static void Add(RestaurantJ rj){
        ObjectFactory o = new ObjectFactory();
        Restaurant r = new Restaurant();
        r.setNom(o.createRestaurantNom(rj.getNom()));
        r.setAdresse(o.createRestaurantAdresse(rj.getAdresse()));
        r.setNumero(o.createRestaurantNumero(rj.getNumero()));
        r.setZipCode(o.createRestaurantZipCode(rj.getZipCode()));
        r.setLocalite(o.createRestaurantLocalite(rj.getLocalite()));
        r.setDescription(o.createRestaurantDescription(rj.getDescription()));
        r.setBudgetLow(rj.getBudgetLow());
        r.setBudgetHigh(rj.getBudgetHigh());
        r.setPremium(rj.getPremium());
        r.setGenre(rj.getGenre());
        r.setIdTypeCuisine(rj.getIdTypeCuisine());
        r.setIdRestaurateur(rj.getIdRestaurateur());
        r.setIdHoraire(rj.getIdHoraire());
        ModelsMapping.createRestaurant(r);
    }    
    
    public static ArrayList<RestaurantJ> GetRestaurants(String s){
        ArrayList<RestaurantJ> a = ModelsMapping.SearchRestaurant(s);
        return a;
    }
    
    public static void Update(RestaurantJ rj){
        ObjectFactory o = new ObjectFactory();
        Restaurant r = new Restaurant();
        r.setId(rj.getId());
        r.setNom(o.createRestaurantNom(rj.getNom()));
        r.setAdresse(o.createRestaurantAdresse(rj.getAdresse()));
        r.setNumero(o.createRestaurantNumero(rj.getNumero()));
        r.setZipCode(o.createRestaurantZipCode(rj.getZipCode()));
        r.setLocalite(o.createRestaurantLocalite(rj.getLocalite()));
        r.setDescription(o.createRestaurantDescription(rj.getDescription()));
        r.setBudgetLow(rj.getBudgetLow());
        r.setBudgetHigh(rj.getBudgetHigh());
        r.setPremium(rj.getPremium());
        r.setGenre(rj.getGenre());
        r.setIdTypeCuisine(rj.getIdTypeCuisine());
        r.setIdRestaurateur(rj.getIdRestaurateur());
        r.setIdHoraire(rj.getIdHoraire());
        ModelsMapping.updateRestaurant(r);
    }
    
    public static void Delete(int id){
        ModelsMapping.deleteRestaurant(id);
    }
}