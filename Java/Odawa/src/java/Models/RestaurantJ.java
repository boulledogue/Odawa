/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Models;

/**
 *
 * @author Alistreaza
 */
public class RestaurantJ {
    private int id;
    private String nom;
    private String adresse;
    private String numero;
    private String zipCode;
    private String localite;
    private String description;
    private int budgetLow;
    private int budgetHigh;
    private boolean premium;
    private int genre;
    private int idTypeCuisine;
    private int idRestaurateur;
    private int idHoraire;
    
   /* public RestaurantJ(int id,String nom,String adresse,String numero,String zipcode,String localite,String description,int budgetLow,int budgetHigh,boolean premium,int idTypeCuisine,int idRestaurateur, int idHoraire) {
        this.id = id;
        this.nom = nom;
        this.adresse = adresse;
        this.numero = numero;
        this.zipCode = zipcode;
        this.localite = localite;
        this.description = description;
        this.budgetLow = budgetLow;
        this.budgetHigh = budgetHigh;
        this.premium = premium;
        this.idTypeCuisine = idTypeCuisine;
        this.idRestaurateur = idRestaurateur;
        this.idHoraire = idHoraire;
    } */
    
    public void setId(int id) { this.id = id; }
    public void setNom(String nom) { this.nom = nom; }
    public void setAdresse(String adresse) { this.adresse = adresse; }
    public void setNumero(String numero) { this.numero = numero; }
    public void setZipCode(String zipCode) { this.zipCode = zipCode; }
    public void setLocalite(String localite) { this.localite = localite; }
    public void setDescription(String description) { this.description = description; }
    public void setBudgetLow(int budgetLow) { this.budgetLow = budgetLow; }
    public void setBudgetHigh(int budgetHigh) { this.budgetHigh = budgetHigh; }
    public void setPremium(boolean premium) { this.premium = premium; }
    public void setGenre(int genre) { this.genre = genre; }
    public void setIdTypeCuisine(int idTypeCuisine) { this.idTypeCuisine = idTypeCuisine; }
    public void setIdRestaurateur(int idRestaurateur) { this.idRestaurateur = idRestaurateur; }
    public void setIdHoraire(int idHoraire) { this.idHoraire = idHoraire; }
    
    public int getId() { return this.id; }
    public String getNom() { return this.nom; }
    public String getAdresse() { return this.adresse; }
    public String getNumero() { return this.numero; }
    public String getZipCode() { return this.zipCode; }
    public String getLocalite() { return this.localite; }
    public String getDescription() { return this.description; }
    public int getBudgetLow() { return this.budgetLow; }
    public int getBudgetHigh() { return this.budgetHigh; }
    public boolean getPremium() { return this.premium; }
    public int getGenre() { return this.genre; }
    public int getIdTypeCuisine() { return this.idTypeCuisine; }
    public int getIdRestaurateur() { return this.idRestaurateur; }
    public int getIdHoraire() { return this.idHoraire; }
}
