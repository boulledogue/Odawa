<%-- 
    Document   : NotFound
    Created on : 1 juin 2015, 13:51:08
    Author     : DCR
--%>

<%-- JSP Code --%>
<!DOCTYPE html>
<html lang="fr">
    <jsp:include page="/ODA-INF/BASE/Head.jsp" />
    <body>
        <jsp:include page="/ODA-INF/BASE/Navbar.jsp" />
        <div class="container ocnt">
            <div class="row">
                <div class="col-lg-8 col-md-offset-2">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <h1 class="text-center">Erreur 500</h1>
                            <p class="text-center">Site indisponible, veuillez réessayer plus tard.</p>
                        </div>
                    </div>
                </div>
            </div>  
        </div>
        <jsp:include page="/ODA-INF/BASE/Footer.jsp" />
    </body>
</html>