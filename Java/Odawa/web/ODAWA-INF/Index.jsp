<%-- 
    Document   : Index
    Created on : 23-avr.-2015, 13:52:47
    Author     : dcr
--%>

<%@page import="org.datacontract.schemas._2004._07.bu.ArrayOfTypeCuisine"%>
<%@page import="org.datacontract.schemas._2004._07.bu.TypeCuisine"%>
<%@page import="com.sun.xml.rpc.processor.modeler.j2ee.xml.string"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>Index</title>
    </head>
    <body>
        <h1>Liste des types de cuisine</h1>
        <% 
        ArrayOfTypeCuisine array = (ArrayOfTypeCuisine) request.getAttribute("ListeTypeCuisine");
        int i = 1;
        for(TypeCuisine t : array.getTypeCuisine()){
        %>
        <%=i%> <%=t.getType().getValue()%> <br>
        <%
        i++;
        }
        %>
    </body>
</html>
