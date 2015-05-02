/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Controller;

import Models.ModelsMapping;
import Models.ReservationJ;
import java.util.ArrayList;
import javax.xml.datatype.DatatypeConfigurationException;
import javax.xml.datatype.DatatypeFactory;
import org.datacontract.schemas._2004._07.bu.ObjectFactory;
import org.datacontract.schemas._2004._07.bu.Reservation;

/**
 *
 * @author Denis Charette
 */
public class ReservationManager {
    
    public static void Add(ReservationJ rj) throws DatatypeConfigurationException{
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
        ModelsMapping.createReservation(r);
    }
    
    public ArrayList<ReservationJ> GetReservationsByRestaurant(int id){
        ArrayList<ReservationJ> a = ModelsMapping.getReservationByRestaurant(id);
        return a;
    }
    
    public static void Update(ReservationJ rj) throws DatatypeConfigurationException{
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
        ModelsMapping.updateReservation(r);
    }
}
