// Dependance Externe
import java.io.IOException;
import java.util.ArrayList;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

// Dependance Interne
import Controller.ReservationManager;
import Controller.RestaurantManager;
import Controller.TypeCuisineManager;
import Models.ReservationJ;
import Models.RestaurantJ;
import Models.RestaurateurJ;
import Models.TypeCuisineJ;

public class Gestion extends HttpServlet {

    protected void processRequest(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        // Si ?delete=id
        // alors suppression du compte Restaurant
        response.setContentType("text/html;charset=UTF-8");
        HttpSession session = request.getSession();
        RestaurateurJ rst = (RestaurateurJ) session.getAttribute("Utilisateur");
        ArrayList<RestaurantJ> lstRest = RestaurantManager.GetRestaurantsByRestaurateur(rst.getId());
        request.setAttribute("Restaurants",lstRest);
        ArrayList<ReservationJ> rsvt = ReservationManager.GetReservationsByRestaurateur(lstRest);
        request.setAttribute("Reservations",rsvt);
        ArrayList<TypeCuisineJ> type = TypeCuisineManager.GetAllTypeCuisine();
        request.setAttribute("Types",type);
        request.getRequestDispatcher("/ODA-INF/Gestion.jsp").forward(request,response);
    }

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        // Si ?action=1 ( Ajout Restaurant )
        // nom,adresse,numero,localite,zip,descr,bdglow,bdghg,HrLndOuv,HrLndFrm,HrMarOuv,
        // HrMarFrm,HrMercOuv,HrMercFrm,HrJdOuv,HrJdFrm,HrVndOuv,HrVndFrm,HrSmdOuv,HrSmdFrm,HrDmcOuv,HrDmcFrm,Type
        
        // Si ?action=2 ( Choix Réservation ) ( choix = 1 => Accepter, choix = 2 => Refuser )
        // id,choix
        processRequest(request, response);
    }
}
