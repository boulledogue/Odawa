// Dependance Externe
import Controller.UtilisateurManager;
import Models.UtilisateurJ;
import java.io.IOException;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

public class Compte extends HttpServlet {

    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        // Si ?delete=id
        // alors suppression du compte Utilisateur
        // N'est pas possible pour un Restaurateur
        if (request.getParameter("delete") != null) {
            UtilisateurManager.deleteUtilisateur(Integer.parseInt(request.getParameter("delete")));
        }
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
        HttpSession session = request.getSession();
        UtilisateurJ u = (UtilisateurJ) session.getAttribute("Utilisateur");
        u.setNom(request.getParameter("nom"));
        u.setPrenom(request.getParameter("prenom"));
        u.setUsername(request.getParameter("username"));
        u.setPassword(request.getParameter("password"));
        u.setEmail(request.getParameter("email"));
        u.setPhone(request.getParameter("phone"));
        UtilisateurManager.updateUtilisateur(u);
    }
}
