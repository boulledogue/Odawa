/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Controller;

import Models.RestaurateurJ;
import Models.ModelsMapping;

/**
 *
 * @author Alistreaza
 */
public class RestaurateurManager {
    
    public static RestaurateurJ getRestaurateurByRestaurant(int id){
        RestaurateurJ r = ModelsMapping.getRestaurateurByRestaurant(id);
        return r;
    }
    
    public static boolean AcceptRestaurateur(String username, String password) {
        org.tempuri.OdawaService service = new org.tempuri.OdawaService();
        org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
        boolean r = port.acceptLoginRestaurateur(username, password);
        return r;
    }

    public static void updateRestaurateur(RestaurateurJ rj) {
        ModelsMapping.updateRestaurateur(rj);
    }
}
