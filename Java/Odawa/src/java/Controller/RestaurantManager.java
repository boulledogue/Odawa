/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Controller;

import Models.ModelsMapping;
import Models.RestaurantJ;
import Utils.LogManager;
import java.util.ArrayList;

/**
 *
 * @author Denis Charette
 */
public class RestaurantManager {
    
    public static void Add(RestaurantJ rj){        
        ModelsMapping.createRestaurant(rj);
    }    
    
    public static RestaurantJ GetRestaurant(int id){
        RestaurantJ r = ModelsMapping.getRestaurant(id);
        return r;
    }
    
    public static ArrayList<RestaurantJ> GetRestaurants(String s){
        ArrayList<RestaurantJ> a = ModelsMapping.SearchRestaurant(s);
        return a;
    }
    
    public static ArrayList<RestaurantJ> GetAllRestaurant(){
        ArrayList<RestaurantJ> a = ModelsMapping.getAllRestaurant();
        return a;
    }
    
    public static ArrayList<RestaurantJ> GetRestaurantsByRestaurateur(int id){
        ArrayList<RestaurantJ> a = ModelsMapping.getRestaurantbyRestaurateur(id);
        return a;
    }
    
    public static ArrayList<RestaurantJ> GetRestaurantsByTypeCuisine(int id){
        ArrayList<RestaurantJ> a = ModelsMapping.getRestaurantByTypeCuisine(id);
        return a;
    }
    
    public static ArrayList<RestaurantJ> GetAllSnack(){
        ArrayList<RestaurantJ> a = ModelsMapping.getAllSnack();
        return a;
    }
    
    public static ArrayList<RestaurantJ> GetBestRestaurants(){
        ArrayList<RestaurantJ> a = ModelsMapping.bestRestaurant();
        return a;
    }
    
    public static RestaurantJ RandomRestaurant(){
        RestaurantJ r = ModelsMapping.randomRestaurant();
        return r;
    }
    
    public static void Update(RestaurantJ rj){        
        ModelsMapping.updateRestaurant(rj);
    }
    
    public static void Delete(int id){
        ModelsMapping.deleteRestaurant(id);
    }
    
    public static boolean IsValid(String nom, String adresse, String numero, String zipCode, 
            String localite, String description, String budgetLow, String budgetHigh, String genre, String Horaire,
            String idTypeCuisine, String idRestaurateur)
    {   
        if(nom == null) return false;
        if(adresse == null) return false;
        if(numero == null) return false;
        if(zipCode == null) return false;
        if(localite == null) return false;
        if(description == null) return false;
        if(budgetLow == null) return false;
        if(budgetHigh == null) return false;
        if(genre == null) return false;
        if(Horaire == null) return false;
        if(idTypeCuisine == null) return false;
        if(idRestaurateur == null) return false;
        
        try
        {
            Integer.parseInt(budgetLow);
            Integer.parseInt(budgetHigh);
            Integer.parseInt(genre);
            Integer.parseInt(idTypeCuisine);
            Integer.parseInt(idRestaurateur);
        } catch(NumberFormatException e) { 
            LogManager log = new LogManager();
            log.LogException(e);
            return false;  
        }
        
        return true;
    }
}