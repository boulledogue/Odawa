/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Models;
import org.datacontract.schemas._2004._07.bu.*;

/**
 *
 * @author Alistreaza
 */
public class TypeCuisineManager {
    public ArrayOfTypeCuisine getAll() {
            org.tempuri.OdawaService service = new org.tempuri.OdawaService();
            org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
            ArrayOfTypeCuisine result = port.getAllTypeCuisine();
            return result;
    }
}
