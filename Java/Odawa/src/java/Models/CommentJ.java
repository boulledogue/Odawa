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
public class CommentJ {
    private int id;
    private String commentaire;
    private int idRestaurant;
    private int idUtilisateur;
    
    private String NomRestaurant;
    private String NomUtilisateur;
    
    public void setId(int id) { this.id = id; }
    public void setCommentaire(String commentaire) { this.commentaire = commentaire; }
    public void setIdRestaurant(int idRestaurant) { this.idRestaurant = idRestaurant; }
    public void setIdUtilisateur(int idUtilisateur) { this.idUtilisateur = idUtilisateur; }
    
    public void setNomRestaurant(String NomRestaurant) { this.NomRestaurant = NomRestaurant; }
    public void setNomUtilisateur(String NomUtilisateur) { this.NomUtilisateur = NomUtilisateur; }
    
    public int getId() { return this.id; }
    public String getCommentaire() { return this.commentaire; }
    public int getIdRestaurant() { return this.idRestaurant; }
    public int getIdUtilisateur() { return this.idUtilisateur; }
    
    public String getNomRestaurant() { return this.NomRestaurant; }
    public String getNomUtilisateur() { return this.NomUtilisateur; }
}