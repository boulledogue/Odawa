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
import java.util.logging.Level;
import java.util.logging.Logger;
import javax.xml.datatype.DatatypeConfigurationException;

public class Gestion extends HttpServlet {

    protected void processRequest(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        // Si ?delete=id
        // alors suppression du compte Restaurant
        if (request.getParameter("delete") != null) {
            RestaurantManager.Delete(Integer.parseInt(request.getParameter("delete")));
        }
        response.setContentType("text/html;charset=UTF-8");
        HttpSession session = request.getSession();
        RestaurateurJ rst = (RestaurateurJ) session.getAttribute("Utilisateur");
        ArrayList<RestaurantJ> lstRest = RestaurantManager.GetRestaurantsByRestaurateur(rst.getId());
        request.setAttribute("Restaurants", lstRest);
        ArrayList<ReservationJ> rsvt = ReservationManager.GetReservationsByRestaurateur(lstRest);
        request.setAttribute("Reservations", rsvt);
        ArrayList<TypeCuisineJ> type = TypeCuisineManager.GetAllTypeCuisine();
        request.setAttribute("Types", type);
        request.getRequestDispatcher("/ODA-INF/Gestion.jsp").forward(request, response);
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
        // nom,adresse,numero,localite,zip,descr,bdglow,bdghg,
        // HrLndOuv,HrLndFrm,HrMarOuv,HrMarFrm,HrMercOuv,HrMercFrm,HrJdOuv,HrJdFrm,HrVndOuv,HrVndFrm,HrSmdOuv,HrSmdFrm,HrDmcOuv,HrDmcFrm
        // Type
        if (request.getParameter("action").equals("1")) {
            RestaurantJ r = new RestaurantJ();
            r.setNom(request.getParameter("nom"));
            r.setAdresse(request.getParameter("adresse"));
            r.setNumero(request.getParameter("numero"));
            r.setLocalite(request.getParameter("localite"));
            r.setZipCode(request.getParameter("zip"));
            r.setDescription(request.getParameter("descr"));
            r.setBudgetLow(Integer.parseInt(request.getParameter("bdglow")));
            r.setBudgetHigh(Integer.parseInt(request.getParameter("bdghgt")));
            r.setHoraire(
                    request.getParameter("HrLndOuv") + "-" + request.getParameter("HrLndFrm") + ";"
                    + request.getParameter("HrMarOuv") + "-" + request.getParameter("HrMarFrm") + ";"
                    + request.getParameter("HrMercOuv") + "-" + request.getParameter("HrMercFrm") + ";"
                    + request.getParameter("HrJdOuv") + "-" + request.getParameter("HrJdFrm") + ";"
                    + request.getParameter("HrVndOuv") + "-" + request.getParameter("HrVndFrm") + ";"
                    + request.getParameter("HrSmdOuv") + "-" + request.getParameter("HrSmdFrm") + ";"
                    + request.getParameter("HrDmcOuv") + "-" + request.getParameter("HrDmcFrm")
            );
            r.setIdTypeCuisine(Integer.parseInt(request.getParameter("Type")));
            HttpSession session = request.getSession();
            RestaurateurJ rest = (RestaurateurJ) session.getAttribute("Utilisateur");
            r.setIdRestaurateur(rest.getId());
            r.setGenre(Integer.parseInt(request.getParameter("Genre")));
            RestaurantManager.Add(r);
        }
        // Si ?action=2 ( Accepter / Refuser Réservation ) ( choix = 2 => Accepter, choix = 3 => Refuser )
        // id,choix
        if (request.getParameter("action").equals("2")) {
            try {
                ReservationJ r = ReservationManager.GetReservation(Integer.parseInt(request.getParameter("id")));
                r.setStatus(Integer.parseInt(request.getParameter("choix")));
                ReservationManager.Update(r);
            } catch (DatatypeConfigurationException ex) {
                Logger.getLogger(Gestion.class.getName()).log(Level.SEVERE, null, ex);
            }
        }

        processRequest(request, response);
    }
}
