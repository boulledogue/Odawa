/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Controller;
import Models.ModelsMapping;
import Models.TypeCuisineJ;
import java.util.ArrayList;
import org.datacontract.schemas._2004._07.bu.TypeCuisine;

/**
 *
 * @author Alistreaza
 */
public class TypeCuisineManager {
        
    public static ArrayList<TypeCuisineJ> GetAllTypeCuisine(){
        ArrayList<TypeCuisineJ> a = ModelsMapping.getAllTypeCuisine();
        return a;
    }
    
    public static TypeCuisineJ GetTypeCuisine(int id){
        TypeCuisineJ t = ModelsMapping.getTypeCuisine(id);
        return t;
    }
    
    public static boolean IsValid(String type, String description) 
    {
        if(type == null) return false;
        if(description == null) return false;
        
        
        return true;
    }
}
