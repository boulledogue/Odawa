// Dependance Externe

import java.io.IOException;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

// Dependance Interne
import Controller.UtilisateurManager;
import Models.UtilisateurJ;

public class Creation extends HttpServlet {

    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        request.getRequestDispatcher("/ODA-INF/Creation.jsp").forward(request, response);
    }

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        if (UtilisateurManager.IsValid("0", request.getParameter("nom"), request.getParameter("prenom"), request.getParameter("username"), request.getParameter("password"), request.getParameter("email"), request.getParameter("phone"))) {
            UtilisateurJ user = new UtilisateurJ();
            user.setNom(request.getParameter("nom"));
            user.setPrenom(request.getParameter("prenom"));
            user.setUsername(request.getParameter("username"));
            user.setPassword(request.getParameter("password"));
            user.setEmail(request.getParameter("email"));
            user.setPhone(request.getParameter("phone"));
            UtilisateurManager.createUtilisateur(user);
        }
    }
}
