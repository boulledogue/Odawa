// Dependance Externe
import java.io.IOException;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

// Dependance Interne
import Controller.CommentManager;
import Controller.RestaurantManager;
import Models.CommentJ;
import Models.RestaurantJ;
import static Utils.Jour.*;

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
        }
    }

}
