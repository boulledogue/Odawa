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
    
    public void setId(int id) { this.id = id; }
    public void setCommentaire(String commentaire) { this.commentaire = commentaire; }
    public void setIdRestaurant(int idRestaurant) { this.idRestaurant = idRestaurant; }
    public void setIdUtilisateur(int idUtilisateur) { this.idUtilisateur = idUtilisateur; }
    
    public int getId() { return this.id; }
    public String getCommentaire() { return this.commentaire; }
    public int getIdRestaurant() { return this.idRestaurant; }
    public int getIdUtilisateur() { return this.idUtilisateur; }
}
