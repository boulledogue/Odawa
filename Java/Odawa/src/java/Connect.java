// Dependance Externe
import java.io.IOException;
import java.io.PrintWriter;     // Utilisé pour répondre en JSON à la fonction de vérification du Mot de Passe
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

// Dependance Interne
import Controller.RestaurateurManager;
import Controller.UtilisateurManager;
import Models.RestaurateurJ;
import Models.UtilisateurJ;

public class Connect extends HttpServlet {

    protected void processRequest(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        request.getRequestDispatcher("/ODA-INF/Connect.jsp").forward(request,response);
    }
    
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        
        boolean isUtilisateur = UtilisateurManager.AcceptUtilisateur(request.getParameter("username"),request.getParameter("password"));
        boolean isRestaurateur = RestaurateurManager.AcceptRestaurateur(request.getParameter("username"),request.getParameter("password"));
        boolean exist = (isUtilisateur == true || isRestaurateur==true ) ;
        if( exist == true ) {
            HttpSession session = request.getSession();
            session.setAttribute("isRestaurateur",isRestaurateur);
            if( isRestaurateur == true ){
                RestaurateurJ rest = RestaurateurManager.getRestaurateurByUsername(request.getParameter("username"));
                session.setAttribute("Utilisateur",rest);
            }else{
                UtilisateurJ utl = UtilisateurManager.getUtilisateurByUsername(request.getParameter("username"));
                session.setAttribute("Utilisateur",utl);
            }
        }
        response.setContentType("application/json");
        try (PrintWriter out = response.getWriter()) { out.println("{\"success\":"+exist+"}"); }
        
    }
}
