/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Controller;

import Models.ModelsMapping;
import Models.CommentJ;
import Utils.LogManager;
import java.util.ArrayList;

/**
 *
 * @author Alistreaza
 */
public class CommentManager {
    
    public static void Add(CommentJ cj){        
        ModelsMapping.createComment(cj);
    }
    
    public static ArrayList<CommentJ> GetCommentByRestaurant(int id){
        ArrayList<CommentJ> a = ModelsMapping.getCommentByRestaurant(id);
        return a;
    }
    
    public static void Update(CommentJ cj){        
        ModelsMapping.updateComment(cj);
    }
    
    public static void Delete(int id){
        ModelsMapping.deleteComment(id);
    }
    
    public static boolean IsValid(String commentaire, String idRestaurant, String idUtilisateur)
    {
        if(commentaire == null) return false;
        if(idRestaurant == null) return false;
        if(idUtilisateur == null) return false;
        
        try
        {
            Integer.parseInt(idRestaurant);
            Integer.parseInt(idUtilisateur);
        } catch(NumberFormatException e) {
            LogManager log = new LogManager();
            log.LogException(e);
            return false; 
        }
        
        return true;
    }
}
