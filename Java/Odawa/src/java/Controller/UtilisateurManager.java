/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Controller;

import Models.*;
import org.datacontract.schemas._2004._07.bu.*;

/**
 *
 * @author Alistreaza
 */
public class UtilisateurManager {
    
    public static boolean AcceptUtilisateur(String username, String password) {
        org.tempuri.OdawaService service = new org.tempuri.OdawaService();
        org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
        boolean u = port.acceptLoginUtilisateur(username, password);
        return u;
    }
    
    public static UtilisateurJ getUtilisateurByUsername(String username) {
        UtilisateurJ u = ModelsMapping.getUtilisateurByUsername(username);
        return u;
    }
    
    public static void deleteUtilisateur(int id) {
        ModelsMapping.deleteUtilisateur(id);
    }
    
    public static void updateUtilisateur(UtilisateurJ u) {
        ModelsMapping.updateUtilisateur(u);
    }
    
    public static void createUtilisateur(UtilisateurJ u) {
        boolean o = ModelsMapping.createUtilisateur(u);
    }
    
    public static boolean IsValid(String id, String nom, String prenom, String username, String password,
            String email, String phone) 
    {
        if(id == null) return false;
        if(nom == null) return false;
        if(prenom == null) return false;
        if(username == null) return false;
        if(password == null) return false;
        if(email == null) return false;
        if(phone == null) return false;
        
        return true;
    }
}
