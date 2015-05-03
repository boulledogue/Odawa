/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Controller;
import Models.ModelsMapping;
import Models.TypeCuisineJ;
import java.util.ArrayList;

/**
 *
 * @author Alistreaza
 */
public class TypeCuisineManager {
        
    public static ArrayList<TypeCuisineJ> GetAllTypeCuisine(){
        ArrayList<TypeCuisineJ> a = ModelsMapping.getAllTypeCuisine();
        return a;
    }
}
