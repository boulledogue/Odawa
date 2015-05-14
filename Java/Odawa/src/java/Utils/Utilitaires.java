/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Utils;

import java.util.ArrayList;

/**
 *
 * @author Alistreaza
 */
public class Utilitaires {

    public static ArrayList<String> returnNomJour() {
        ArrayList<String> nmJ = new ArrayList();
        nmJ.add("Dimanche : ");
        nmJ.add("Lundi : ");
        nmJ.add("Mardi : ");
        nmJ.add("Mercredi : ");
        nmJ.add("Jeudi : ");
        nmJ.add("Vendredi : ");
        nmJ.add("Samedi : ");
        return nmJ;
    }
    
}
