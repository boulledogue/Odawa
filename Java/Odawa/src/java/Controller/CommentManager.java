/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Controller;

import Models.ModelsMapping;
import Models.CommentJ;
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
}
