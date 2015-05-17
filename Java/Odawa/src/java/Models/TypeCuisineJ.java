/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Models;

/**
 *
 * @author Denis Charette
 */
public class TypeCuisineJ {
    private int id;
    private String type;
    private String description;
    
    public void setId(int id) { this.id = id; }
    public void setType(String type) { this.type = type; }
    public void setDescription(String description) { this.description = description; }
    
    public int getId() { return this.id; }
    public String getType() { return this.type; }
    public String getDescription() { return this.description; }
}
