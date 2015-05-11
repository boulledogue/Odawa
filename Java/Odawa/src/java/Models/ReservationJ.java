/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Models;

import java.text.DateFormat;
import java.util.Date;

/**
 *
 * @author Denis Charette
 */
public class ReservationJ {
    private int id;
    private String nom;
    private String prenom;
    private Date date;
    private boolean typeService;
    private int nbPersonnes;
    private String email;
    private String phone;
    private int idRestaurant; 
    private int status;
    private Date encodedDateTime;
    
    private String Restaurant; 
    
    public void setId(int id) { this.id = id; }
    public void setNom(String nom) { this.nom = nom; }
    public void setPrenom(String prenom) { this.prenom = prenom; }
    public void setDate(Date date) { this.date = date; }
    public void setTypeService(boolean type) { this.typeService = type; }
    public void setNbPersonnes(int nb) { this.nbPersonnes = nb; }
    public void setEmail(String email) { this.email = email; }
    public void setPhone(String phone) { this.phone = phone; }
    public void setIdRestaurant(int id) { this.idRestaurant = id; }
    public void setStatus(int status) { this.status = status; }
    public void setEncodedDateTime(Date dateTime) { this.encodedDateTime = dateTime; }
    
    public void setRestaurant(String Restaurant) { this.Restaurant = Restaurant; }
    
    public int getId() { return this.id; }
    public String getNom() { return this.nom; }
    public String getPrenom() { return this.prenom; }
    public Date getDate() { return this.date; }
    public boolean getTypeService() { return this.typeService; }
    public int getNbPersonnes() { return this.nbPersonnes; }
    public String getEmail() { return this.email; }
    public String getPhone() { return this.phone; }
    public int getIdRestaurant() { return this.idRestaurant; }
    public int getStatus() { return this.status; }
    public Date getEncodedDateTime() { return this.encodedDateTime; }
    
    public String getRestaurant() { return this.Restaurant; }
}
