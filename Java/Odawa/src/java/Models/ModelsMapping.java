/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Models;

import java.util.*;
import javax.xml.datatype.DatatypeConfigurationException;
import javax.xml.datatype.DatatypeFactory;
import org.datacontract.schemas._2004._07.bu.*;

/**
 *
 * @author Denis Charette
 */
public class ModelsMapping {
    
    //---------Comments
    
    public static void createComment(CommentJ cj) {
        ObjectFactory o = new ObjectFactory();
        Comment c = new Comment();
        c.setCommentaire(o.createCommentCommentaire(cj.getCommentaire()));
        c.setIdRestaurant(cj.getIdRestaurant());
        c.setIdUtilisateur(cj.getIdUtilisateur());
        org.tempuri.OdawaService service = new org.tempuri.OdawaService();
        org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
        port.createComment(c);
    }
    
    public static ArrayList<CommentJ> getCommentByRestaurant(java.lang.Integer id) {
        org.tempuri.OdawaService service = new org.tempuri.OdawaService();
        org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
        List<Comment> lstC =  port.getCommentByRestaurant(id).getComment();
        ArrayList<CommentJ> arrayCommentJ = new ArrayList<CommentJ>();
        for (Comment c : lstC){
            CommentJ com = new CommentJ();
            com.setId(c.getId());
            com.setCommentaire(c.getCommentaire().getValue());
            com.setIdRestaurant(c.getIdRestaurant());
            com.setIdUtilisateur(c.getIdUtilisateur());
            arrayCommentJ.add(com);
        }
        return arrayCommentJ;
    }
    
    public static void updateComment(CommentJ cj) {
        ObjectFactory o = new ObjectFactory();
        Comment c = new Comment();
        c.setId(cj.getId());
        c.setCommentaire(o.createCommentCommentaire(cj.getCommentaire()));
        c.setIdRestaurant(cj.getIdRestaurant());
        c.setIdUtilisateur(cj.getIdUtilisateur());
        org.tempuri.OdawaService service = new org.tempuri.OdawaService();
        org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
        port.updateComment(c);
    }
    
    public static void deleteComment(java.lang.Integer id) {
        org.tempuri.OdawaService service = new org.tempuri.OdawaService();
        org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
        port.deleteComment(id);
    }
    
    //---------Reservations
    
    public static void createReservation(ReservationJ rj) throws DatatypeConfigurationException {
        ObjectFactory o = new ObjectFactory();
        DatatypeFactory datatypes = DatatypeFactory.newInstance(); 
        Reservation r = new Reservation();
        r.setNom(o.createReservationNom(rj.getNom()));
        r.setPrenom(o.createReservationPrenom(rj.getPrenom()));
        r.setDate(datatypes.newXMLGregorianCalendar(rj.getDate().toString()));
        r.setTypeService(rj.getTypeService());
        r.setNbPersonnes(rj.getNbPersonnes());
        r.setEmail(o.createReservationEmail(rj.getEmail()));
        r.setPhone(o.createReservationPhone(rj.getPhone()));
        r.setIdRestaurant(rj.getIdRestaurant());
        r.setStatus(rj.getStatus());
        r.setEncodedDateTime(datatypes.newXMLGregorianCalendar(rj.getEncodedDateTime().toString()));
        org.tempuri.OdawaService service = new org.tempuri.OdawaService();
        org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
        port.createReservation(r);
    }
    
    public static ArrayList<ReservationJ> getReservationByRestaurant(java.lang.Integer id) {
        org.tempuri.OdawaService service = new org.tempuri.OdawaService();
        org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
        List<Reservation> lstR =  port.getReservationByRestaurant(id).getReservation();
        ArrayList<ReservationJ> arrayReservationJ = new ArrayList<ReservationJ>();
        for(Reservation r : lstR){
            ReservationJ res = new ReservationJ();
            res.setId(r.getId());
            res.setNom(r.getNom().getValue());
            res.setPrenom(r.getPrenom().getValue());
            res.setDate(r.getDate().toGregorianCalendar().getTime());
            res.setTypeService(r.isTypeService());
            res.setNbPersonnes(r.getNbPersonnes());
            res.setEmail(r.getEmail().getValue());
            res.setPhone(r.getPhone().getValue());
            res.setIdRestaurant(r.getIdRestaurant());
            res.setStatus(r.getStatus());
            res.setEncodedDateTime(r.getEncodedDateTime().toGregorianCalendar().getTime());
            arrayReservationJ.add(res);
        }
        return arrayReservationJ;
    }
    
    public static void updateReservation(ReservationJ rj) throws DatatypeConfigurationException {
        ObjectFactory o = new ObjectFactory();
        DatatypeFactory datatypes = DatatypeFactory.newInstance();
        Reservation r = new Reservation();
        r.setId(rj.getId());
        r.setNom(o.createReservationNom(rj.getNom()));
        r.setPrenom(o.createReservationPrenom(rj.getPrenom()));
        r.setDate(datatypes.newXMLGregorianCalendar(rj.getDate().toString()));
        r.setTypeService(rj.getTypeService());
        r.setNbPersonnes(rj.getNbPersonnes());
        r.setEmail(o.createReservationEmail(rj.getEmail()));
        r.setPhone(o.createReservationPhone(rj.getPhone()));
        r.setIdRestaurant(rj.getIdRestaurant());
        r.setStatus(rj.getStatus());
        r.setEncodedDateTime(datatypes.newXMLGregorianCalendar(rj.getEncodedDateTime().toString()));
        org.tempuri.OdawaService service = new org.tempuri.OdawaService();
        org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
        port.updateReservation(r);
    }
    
    //---------Restaurants
    
    public static void createRestaurant(RestaurantJ rj) {
        ObjectFactory o = new ObjectFactory();
        Restaurant r = new Restaurant();
        r.setNom(o.createRestaurantNom(rj.getNom()));
        r.setAdresse(o.createRestaurantAdresse(rj.getAdresse()));
        r.setNumero(o.createRestaurantNumero(rj.getNumero()));
        r.setZipCode(o.createRestaurantZipCode(rj.getZipCode()));
        r.setLocalite(o.createRestaurantLocalite(rj.getLocalite()));
        r.setDescription(o.createRestaurantDescription(rj.getDescription()));
        r.setBudgetLow(rj.getBudgetLow());
        r.setBudgetHigh(rj.getBudgetHigh());
        r.setPremium(rj.getPremium());
        r.setGenre(rj.getGenre());
        r.setIdTypeCuisine(rj.getIdTypeCuisine());
        r.setIdRestaurateur(rj.getIdRestaurateur());
        r.setIdHoraire(rj.getIdHoraire());
        org.tempuri.OdawaService service = new org.tempuri.OdawaService();
        org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
        port.createRestaurant(r);
    }
    
    public static RestaurantJ getRestaurant(java.lang.Integer id) {
        org.tempuri.OdawaService service = new org.tempuri.OdawaService();
        org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
        Restaurant r = port.getRestaurant(id);
        return ConvertToRestaurantJ(r);
    }
    
    public static ArrayList<RestaurantJ> SearchRestaurant(String s) {
        org.tempuri.OdawaService service = new org.tempuri.OdawaService();
        org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
        List<Restaurant> lstR = port.searchRestaurant(s).getRestaurant();
        ArrayList<RestaurantJ> arrayRestaurantJ = new ArrayList<RestaurantJ>();
        for(Restaurant r : lstR){            
            RestaurantJ rest = ConvertToRestaurantJ(r);
            arrayRestaurantJ.add(rest);
        }
        return arrayRestaurantJ;
    }

    public static ArrayList<RestaurantJ> getAllRestaurant() {
        org.tempuri.OdawaService service = new org.tempuri.OdawaService();
        org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
        List<Restaurant> lstR = port.getAllRestaurant().getRestaurant();
        ArrayList<RestaurantJ> arrayRestaurantJ = new ArrayList<RestaurantJ>();
        for(Restaurant r : lstR){            
            RestaurantJ rest = ConvertToRestaurantJ(r);
            arrayRestaurantJ.add(rest);
        }
        return arrayRestaurantJ;
    }

    public static ArrayList<RestaurantJ> getAllSnack() {
        org.tempuri.OdawaService service = new org.tempuri.OdawaService();
        org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
        List<Restaurant> lstR = port.getAllSnack().getRestaurant();
        ArrayList<RestaurantJ> arrayRestaurantJ = new ArrayList<RestaurantJ>();
        for(Restaurant r : lstR){            
            RestaurantJ rest = ConvertToRestaurantJ(r);
            arrayRestaurantJ.add(rest);
        }
        return arrayRestaurantJ;
    }
    
    public static ArrayList<RestaurantJ> bestRestaurant() {
        org.tempuri.OdawaService service = new org.tempuri.OdawaService();
        org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
        List<Restaurant> lstR = port.bestRestaurant().getRestaurant();
        ArrayList<RestaurantJ> arrayRestaurantJ = new ArrayList<RestaurantJ>();
        for(Restaurant r : lstR){            
            RestaurantJ rest = ConvertToRestaurantJ(r);
            arrayRestaurantJ.add(rest);
        }
        return arrayRestaurantJ;
    }
    
    public static RestaurantJ randomRestaurant() {
        org.tempuri.OdawaService service = new org.tempuri.OdawaService();
        org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
        Restaurant r = port.randomRestaurant();
        return ConvertToRestaurantJ(r);
    }
    
    public static void updateRestaurant(RestaurantJ rj) {
        ObjectFactory o = new ObjectFactory();
        Restaurant r = new Restaurant();
        r.setId(rj.getId());
        r.setNom(o.createRestaurantNom(rj.getNom()));
        r.setAdresse(o.createRestaurantAdresse(rj.getAdresse()));
        r.setNumero(o.createRestaurantNumero(rj.getNumero()));
        r.setZipCode(o.createRestaurantZipCode(rj.getZipCode()));
        r.setLocalite(o.createRestaurantLocalite(rj.getLocalite()));
        r.setDescription(o.createRestaurantDescription(rj.getDescription()));
        r.setBudgetLow(rj.getBudgetLow());
        r.setBudgetHigh(rj.getBudgetHigh());
        r.setPremium(rj.getPremium());
        r.setGenre(rj.getGenre());
        r.setIdTypeCuisine(rj.getIdTypeCuisine());
        r.setIdRestaurateur(rj.getIdRestaurateur());
        r.setIdHoraire(rj.getIdHoraire());
        org.tempuri.OdawaService service = new org.tempuri.OdawaService();
        org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
        port.updateRestaurant(r);
    }

    public static void deleteRestaurant(java.lang.Integer id) {
        org.tempuri.OdawaService service = new org.tempuri.OdawaService();
        org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
        port.deleteRestaurant(id);
    }
    
    public static RestaurantJ ConvertToRestaurantJ(Restaurant r){
        RestaurantJ rest = new RestaurantJ();
        rest.setId(r.getId());
        rest.setNom(r.getNom().getValue());
        rest.setAdresse(r.getAdresse().getValue());
        rest.setNumero(r.getNumero().getValue());
        rest.setZipCode(r.getZipCode().getValue());
        rest.setLocalite(r.getLocalite().getValue());
        rest.setDescription(r.getDescription().getValue());
        rest.setBudgetLow(r.getBudgetLow());
        rest.setBudgetHigh(r.getBudgetHigh());
        rest.setPremium(r.isPremium());
        rest.setGenre(r.getGenre());
        rest.setIdTypeCuisine(r.getIdTypeCuisine());
        rest.setIdRestaurateur(r.getIdRestaurateur());
        rest.setIdHoraire(r.getIdHoraire());
        return rest;
    }
    
    //---------Restaurateurs
    
    public static RestaurateurJ getRestaurateurByRestaurant(java.lang.Integer id) {
        org.tempuri.OdawaService service = new org.tempuri.OdawaService();
        org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
        Restaurateur r = port.getRestaurateurByRestaurant(id);
        RestaurateurJ rj = new RestaurateurJ();
        rj.setId(r.getId());
        rj.setNom(r.getNom().getValue());
        rj.setPrenom(r.getPrenom().getValue());
        rj.setUsername(r.getUsername().getValue());
        rj.setPassword(r.getPassword().getValue());
        rj.setEmail(r.getEmail().getValue());
        rj.setPhone(r.getPhone().getValue());
        return rj;
    }
    
    public static RestaurateurJ getRestaurateurByUsername(java.lang.String username) {
        org.tempuri.OdawaService service = new org.tempuri.OdawaService();
        org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
        Restaurateur r = port.getRestaurateurByUsername(username);
        RestaurateurJ rj = new RestaurateurJ();
        rj.setId(r.getId());
        rj.setNom(r.getNom().getValue());
        rj.setPrenom(r.getPrenom().getValue());
        rj.setUsername(r.getUsername().getValue());
        rj.setPassword(r.getPassword().getValue());
        rj.setEmail(r.getEmail().getValue());
        rj.setPhone(r.getPhone().getValue());
        return rj;
    }
    
    public static void updateRestaurateur(RestaurateurJ rj) {
        ObjectFactory o = new ObjectFactory();
        Restaurateur r = new Restaurateur();
        r.setId(rj.getId());
        r.setNom(o.createRestaurateurNom(rj.getNom()));
        r.setPrenom(o.createRestaurateurPrenom(rj.getPrenom()));
        r.setUsername(o.createRestaurateurUsername(rj.getUsername()));
        r.setPassword(o.createRestaurateurPassword(rj.getPassword()));
        r.setEmail(o.createRestaurateurEmail(rj.getEmail()));
        r.setPhone(o.createRestaurateurPhone(rj.getPhone()));
        org.tempuri.OdawaService service = new org.tempuri.OdawaService();
        org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
        port.updateRestaurateur(r);
    }
    
    //---------Types Cuisine

    public static ArrayList<TypeCuisineJ> getAllTypeCuisine() {
        org.tempuri.OdawaService service = new org.tempuri.OdawaService();
        org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
        List<TypeCuisine> lstT = port.getAllTypeCuisine().getTypeCuisine();
        ArrayList<TypeCuisineJ> arrayTypeJ = new ArrayList<TypeCuisineJ>();
        for(TypeCuisine t : lstT){
            TypeCuisineJ type = new TypeCuisineJ();
            type.setId(t.getId());
            type.setType(t.getType().getValue());
            arrayTypeJ.add(type);
        }
        return arrayTypeJ;
    }
    
    public static TypeCuisineJ getTypeCuisine(java.lang.Integer id) {
        org.tempuri.OdawaService service = new org.tempuri.OdawaService();
        org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
        TypeCuisine t = port.getTypeCuisine(id);
        TypeCuisineJ tj = new TypeCuisineJ();
        tj.setId(t.getId());
        tj.setType(t.getType().getValue());
        return tj;
    }
    
    //---------Utilisateurs
    
    public static UtilisateurJ getUtilisateur(int id) {
        org.tempuri.OdawaService service = new org.tempuri.OdawaService();
        org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
        Utilisateur u = port.getUtilisateur(id);
        UtilisateurJ uj = new UtilisateurJ();
        uj.setId(u.getId());
        uj.setNom(u.getNom().getValue());
        uj.setPrenom(u.getPrenom().getValue());
        uj.setUsername(u.getUsername().getValue());
        uj.setPassword(u.getPassword().getValue());
        uj.setEmail(u.getEmail().getValue());
        uj.setPhone(u.getPhone().getValue());
        return uj;
    }
    
    public static void updateUtilisateur(UtilisateurJ uj) {
        ObjectFactory o = new ObjectFactory();
        Utilisateur u = new Utilisateur();
        u.setId(uj.getId());
        u.setNom(o.createUtilisateurNom(uj.getNom()));
        u.setPrenom(o.createUtilisateurPrenom(uj.getPrenom()));
        u.setUsername(o.createUtilisateurUsername(uj.getUsername()));
        u.setPassword(o.createUtilisateurPassword(uj.getPassword()));
        u.setEmail(o.createUtilisateurEmail(uj.getEmail()));
        u.setPhone(o.createUtilisateurPhone(uj.getPhone()));
        org.tempuri.OdawaService service = new org.tempuri.OdawaService();
        org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
        port.updateUtilisateur(u);
    }
}
