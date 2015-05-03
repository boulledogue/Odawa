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
public class UtilisateurJ {
    private int id;
    private String nom;
    private String prenom;
    private String username;
    private String password;
    private String email;
    private String phone;
    
    public void setId(int id) { this.id = id; }
    public void setNom(String nom) { this.nom = nom; }
    public void setPrenom(String prenom) { this.prenom = prenom; }
    public void setUsername(String username) { this.username = username; }
    public void setPassword(String password) { this.password = password; }
    public void setEmail(String email) { this.email = email; }
    public void setPhone(String phone) { this.phone = phone; }
    
    public int getId() { return this.id; }
    public String getNom() { return this.nom; }
    public String getPrenom() { return this.prenom; }
    public String getUsername() { return this.username; }
    public String getPassword() { return this.password; }
    public String getEmail() { return this.email; }
    public String getPhone() { return this.phone; }
}
