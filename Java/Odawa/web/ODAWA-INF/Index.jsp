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
        
    <%-- start web service invocation --%><hr/>
    <%
    try {
	org.tempuri.OdawaService service = new org.tempuri.OdawaService();
	org.tempuri.IOdawaService port = service.getBasicHttpBindingIOdawaService();
	ArrayOfTypeCuisine result = port.getAllTypeCuisine();
        for(TypeCuisine t : result.getTypeCuisine()){
        %>
        <%=t.getId()%> <%=t.getType().getValue()%> <br>
        <%
        }
    } catch (Exception ex) {
	// TODO handle custom exceptions here
    }
    %>
    <%-- end web service invocation --%><hr/>   

    </body>
</html>
