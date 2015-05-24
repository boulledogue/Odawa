// Dependance Externe
import java.io.IOException;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

// Dependance Interne
import Controller.CommentManager;
import Controller.ReservationManager;
import Controller.RestaurantManager;
import Models.CommentJ;
import Models.ReservationJ;
import Models.RestaurantJ;
import static Utils.Jour.*;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.xml.datatype.DatatypeConfigurationException;

// Class Restaurant
public class Restaurant extends HttpServlet {

    protected void processRequest(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        RestaurantJ r = RestaurantManager.GetRestaurant(Integer.parseInt(request.getParameter("id")));
        request.setAttribute("Restaurant",r);
        request.setAttribute("Comments",CommentManager.GetCommentByRestaurant(r.getId()));
        request.setAttribute("day",getNumJour());
        request.setAttribute("nomJour",getNomJour());
        request.setAttribute("ListNomJour",getNomJours());
        request.getRequestDispatcher("/ODA-INF/Restaurant.jsp").forward(request,response);
    }

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        if( Integer.parseInt(request.getParameter("action")) == 1 ){
            CommentJ cm = new CommentJ();
            cm.setCommentaire(request.getParameter("comm"));
            cm.setIdUtilisateur(Integer.parseInt(request.getParameter("idutl")));
            cm.setIdRestaurant(Integer.parseInt(request.getParameter("idrest")));
            CommentManager.Add(cm);
        }else{
           // Ajout Reservation
           // Donnée Envoyée. Tout en Stringg
           // nom,prenom,date,nbrePersonne,email,phone,idrest            
            try {
                ReservationJ r = new ReservationJ();
                r.setNom(request.getParameter("nom").toUpperCase());
                r.setPrenom(request.getParameter("prenom"));
                SimpleDateFormat formatter = new SimpleDateFormat("yyyy-MM-dd");
                Date date = formatter.parse(request.getParameter("date"));
                r.setDate(date);
                r.setNbPersonnes(Integer.parseInt(request.getParameter("nbrePersonne")));
                r.setEmail(request.getParameter("email"));
                r.setPhone(request.getParameter("phone"));
                r.setTypeService(request.getParameter("type").equals("true"));
                r.setIdRestaurant(Integer.parseInt(request.getParameter("idrest")));
                ReservationManager.Add(r);
            } catch (ParseException | DatatypeConfigurationException ex) {
                Logger.getLogger(Restaurant.class.getName()).log(Level.SEVERE, null, ex);
            }
        }
    }

}
