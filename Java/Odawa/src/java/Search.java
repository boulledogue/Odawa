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
import java.util.*;

import Models.*;
import Controller.*;

/**
 *
 * @author Alistreaza
 */
public class Search extends HttpServlet {

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
        if( request.getParameter("SearchType") != null ) {
            if( request.getParameter("SearchType").equals("1") ) { 
                request.setAttribute("SearchType",1);
                request.setAttribute("Restaurants",RestaurantManager.GetAllRestaurant());
            }else{
                if( request.getParameter("SearchType").equals("2") ) { 
                    request.setAttribute("SearchType",2);
                    request.setAttribute("Restaurants",RestaurantManager.GetAllSnack());
                } 
            }
        }else{ 
            request.setAttribute("SearchType",0); 
            if( request.getAttribute("SearchString") != null)
                request.setAttribute("Restaurants",RestaurantManager.GetRestaurants((String)request.getAttribute("SearchString")));
            else
                request.setAttribute("Restaurants",RestaurantManager.GetBestRestaurants());
        }
        request.getRequestDispatcher("/ODA-INF/Search.jsp").forward(request,response);
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
        request.setAttribute("SearchString",request.getParameter("SearchString"));
        processRequest(request, response);
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
