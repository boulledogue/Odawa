// Dependance Externe
import java.io.IOException;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

// Dependance Interne
import Controller.RestaurantManager;
import Models.RestaurantJ;
import static Utils.Jour.*;

public class Index extends HttpServlet {

    protected void processRequest(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        RestaurantJ r = RestaurantManager.RandomRestaurant();
        request.setAttribute("RestaurantRandom",r); 
        request.setAttribute("BestRestaurants",RestaurantManager.GetBestRestaurants());
        request.setAttribute("NumJour",getNumJour());
        request.setAttribute("nomJour",getNomJour());
        request.setAttribute("nomJours",getNomJours());
        request.getRequestDispatcher("/ODA-INF/Index.jsp").forward(request,response);
    }

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }
}
