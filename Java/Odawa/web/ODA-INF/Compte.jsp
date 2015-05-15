<%-- Dependance --%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>

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
                        <div class="panel-heading">
                            Gestion du Compte
                            <c:if test="${ sessionScope.AdmState != true }" >
                                <p class="text-right" style="margin-top: -20px; margin-bottom: 0px;"><a data-toggle="modal" data-target="#myModal" href="#"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></a></p>
                                    </c:if>
                        </div>
                        <div class="panel-body">
                            <form class="form-horizontal">
                                <div class="form-group">
                                    <div class="input-group debug-gestrest">
                                        <span class="input-group-addon" id="basic-addon1">Nom</span>
                                        <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getNom()}"/>">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="input-group debug-gestrest">
                                        <span class="input-group-addon" id="basic-addon1">Prenom</span>
                                        <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getNom()}"/>">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="input-group debug-gestrest">
                                        <span class="input-group-addon" id="basic-addon1">Nom d'Utilisateur</span>
                                        <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getNom()}"/>">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="input-group debug-gestrest">
                                        <span class="input-group-addon" id="basic-addon1">Mot de Passe</span>
                                        <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getNom()}"/>">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="input-group debug-gestrest">
                                        <span class="input-group-addon" id="basic-addon1">E-mail</span>
                                        <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getNom()}"/>">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="input-group debug-gestrest">
                                        <span class="input-group-addon" id="basic-addon1">Telephone</span>
                                        <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getNom()}"/>">
                                    </div>
                                </div>
                            </form>
                                    <p class="text-right"><a class="btn btn-primary">Mettre à Jour</a></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <jsp:include page="/ODA-INF/BASE/Footer.jsp" />
    </body>
</html>