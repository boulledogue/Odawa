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
}
