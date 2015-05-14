/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import Models.*;
import Controller.*;

/**
 *
 * @author Alistreaza
 */
public class Connect extends HttpServlet {

    /**
     * Processes requests for both HTTP <code>GET</code> and <code>POST</code>
     * methods.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    protected void processRequest(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        response.setContentType("text/html;charset=UTF-8");
        request.getRequestDispatcher("/ODA-INF/Connect.jsp").forward(request,response);
    }

    // <editor-fold defaultstate="collapsed" desc="HttpServlet methods. Click on the + sign on the left to edit the code.">
    /**
     * Handles the HTTP <code>GET</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Handles the HTTP <code>POST</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        
        boolean respUtilisateur = UtilisateurManager.AcceptUtilisateur(request.getParameter("username"),request.getParameter("password"));
        boolean respRestaurateur = RestaurateurManager.AcceptRestaurateur(request.getParameter("username"),request.getParameter("password"));
        boolean resp = (respUtilisateur == true || respRestaurateur==true ) ? true : false ;
        if( resp == true ) {
            HttpSession session = request.getSession();
            session.setAttribute("AdmState",respRestaurateur);
            if( respRestaurateur == true ){
                RestaurateurJ rest = RestaurateurManager.getRestaurateurByUsername(request.getParameter("username"));
                session.setAttribute("Utl",rest);
            }else{
                UtilisateurJ utl = UtilisateurManager.getUtilisateurByUsername(request.getParameter("username"));
                session.setAttribute("Utl",utl);
            }
        }else{ HttpSession session = request.getSession();session.setAttribute("Utl",null); }
        response.setContentType("application/json");
        try (PrintWriter out = response.getWriter()) { out.println("{\"success\":"+resp+"}"); }
        
    }

    /**
     * Returns a short description of the servlet.
     *
     * @return a String containing servlet description
     */
    @Override
    public String getServletInfo() {
        return "Short description";
    }// </editor-fold>

}
