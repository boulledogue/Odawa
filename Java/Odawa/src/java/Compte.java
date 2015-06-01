// Dependance Externe

import Controller.RestaurateurManager;
import Controller.UtilisateurManager;
import Models.RestaurateurJ;
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
        if (request.getRequestedSessionId() != null && request.isRequestedSessionIdValid()) {
            if (request.getParameter("delete") != null) {
                UtilisateurManager.deleteUtilisateur(Integer.parseInt(request.getParameter("delete")));
                response.sendRedirect("/Disconnect");
            } else {
                response.setContentType("text/html;charset=UTF-8");
                request.getRequestDispatcher("/ODA-INF/Compte.jsp").forward(request, response);
            }
        } else {
            response.sendRedirect("/Connect");
        }
    }

    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        if (request.getRequestedSessionId() != null && request.isRequestedSessionIdValid()) {
            HttpSession session = request.getSession();
            if (session.getAttribute("isRestaurateur").equals(true)) {
                if (RestaurateurManager.IsValid("0", request.getParameter("nom"), request.getParameter("prenom"), request.getParameter("username"), request.getParameter("password"), request.getParameter("email"), request.getParameter("phone"))) {
                    RestaurateurJ u = (RestaurateurJ) session.getAttribute("Utilisateur");
                    u.setNom(request.getParameter("nom"));
                    u.setPrenom(request.getParameter("prenom"));
                    u.setUsername(request.getParameter("username"));
                    u.setPassword(request.getParameter("password"));
                    u.setEmail(request.getParameter("email"));
                    u.setPhone(request.getParameter("phone"));
                    RestaurateurManager.updateRestaurateur(u);
                }
            } else {
                if (UtilisateurManager.IsValid("0", request.getParameter("nom"), request.getParameter("prenom"), request.getParameter("username"), request.getParameter("password"), request.getParameter("email"), request.getParameter("phone"))) {
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
        }
    }
}
