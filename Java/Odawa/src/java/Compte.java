// Dependance Externe
import java.io.IOException;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

public class Compte extends HttpServlet {

    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        // Si ?delete=id
        // alors suppression du compte Utilisateur
        // N'est pas possible pour un Restaurateur
        response.setContentType("text/html;charset=UTF-8");
        request.getRequestDispatcher("/ODA-INF/Compte.jsp").forward(request,response);
    }

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        // Donnée envoyé :
        // nom,prenom,username,password,email,phone
        processRequest(request, response);
    }
}
