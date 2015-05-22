// Dependance Externe
import java.io.IOException;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

// Dependance Interne
import Controller.RestaurantManager;
import Controller.TypeCuisineManager;

public class Search extends HttpServlet {

    protected void processRequest(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        if( request.getParameter("SearchType") != null ) {
            if( request.getParameter("SearchType").equals("1") ) { 
                request.setAttribute("SearchType",1);
                request.setAttribute("Restaurants",RestaurantManager.GetAllRestaurant());
            }else{
                if( request.getParameter("SearchType").equals("2") ) { 
                    request.setAttribute("SearchType",2);
                    request.setAttribute("Restaurants",RestaurantManager.GetAllSnack());
                }else{
                    request.setAttribute("SearchType",3);
                    int id = Integer.parseInt(request.getParameter("TypeCuisine"));
                    request.setAttribute("Restaurants",RestaurantManager.GetRestaurantsByTypeCuisine(id));
                } 
            }
        }else{ 
            request.setAttribute("SearchType",0); 
            if( request.getAttribute("SearchString") != null)
                request.setAttribute("Restaurants",RestaurantManager.GetRestaurants((String)request.getAttribute("SearchString")));
        }
        request.setAttribute("TypeCuisines",TypeCuisineManager.GetAllTypeCuisine());
        request.getRequestDispatcher("/ODA-INF/Search.jsp").forward(request,response);
    }

    @Override
   protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        request.setAttribute("SearchString",request.getParameter("SearchString"));
        processRequest(request, response);
    }
}
