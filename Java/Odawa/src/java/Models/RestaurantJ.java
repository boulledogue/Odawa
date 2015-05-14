/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Models;
import java.util.ArrayList;

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
    private String Horaire;
    private int idTypeCuisine;
    private int idRestaurateur;
    
    private String TypeCuisine;
    private String Restaurateur;

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
    
    public void setTypeCuisine(String TypeCuisine) { this.TypeCuisine = TypeCuisine; }
    public void setRestaurateur(String Restaurateur) { this.Restaurateur = Restaurateur; }
    public void setHoraire(String Horaire) { this.Horaire = Horaire; }
    
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
    
    public String getTypeCuisine() { return this.TypeCuisine; }
    public String getRestaurateur() { return this.Restaurateur; }
    public String getHoraire() { return this.Horaire; }
    
    public String getAllOfAdresse() { return getAdresse() + ", N°" + getNumero() + " -- " + getZipCode() + " " + getLocalite(); }
    public String getAllBudget() {  return "De " + getBudgetLow() + " Euros à " + getBudgetHigh() + " Euros."; }
    public ArrayList<String> getFormatHoraire() { 
        ArrayList<String> rtn = new ArrayList() ;
        String[] Horaires = Horaire.split(";");
        for( String HoraireF : Horaires ) {
            String[] HoraireJ = HoraireF.split("-");
            if(HoraireJ[0].substring(0,4).equals("0000")) rtn.add("Aucune Ouverture");
            else rtn.add("De " + HoraireJ[0].substring(0,2) + "H" + HoraireJ[0].substring(2,4) + " à " + HoraireJ[1].substring(0,2) + "H" + HoraireJ[1].substring(2,4));
        }
        return rtn;
    }
}