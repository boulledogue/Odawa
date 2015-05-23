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
                            <c:if test="${ sessionScope.isRestaurateur != true }" >
                                <p class="text-right" style="margin-top: -20px; margin-bottom: 0px;"><a href="/Compte?delete=<c:out value="${sessionScope.Utilisateur.getId()}"/>"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></a></p>
                                    </c:if>
                        </div>
                        <div class="panel-body">
                            <form data-toggle="validator" class="form-horizontal">
                                <div class="form-group">
                                    <div class="input-group debug-gestrest">
                                        <span class="input-group-addon">Nom</span>
                                        <input type="text" class="form-control" id="inptNom" value="<c:out value="${sessionScope.Utilisateur.getNom()}"/>" required>
                                    </div>
                                    <div class="col-sm-10">
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="input-group debug-gestrest">
                                        <span class="input-group-addon">Prenom</span>
                                        <input type="text" class="form-control" id="inptPrenom" value="<c:out value="${sessionScope.Utilisateur.getPrenom()}"/>" required>
                                    </div>
                                    <div class="col-sm-10">
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="input-group debug-gestrest">
                                        <span class="input-group-addon">Nom d'Utilisateur</span>
                                        <input type="text" class="form-control" id="inptUsername" value="<c:out value="${sessionScope.Utilisateur.getUsername()}"/>" required>
                                    </div>
                                    <div class="col-sm-10">
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="input-group debug-gestrest">
                                        <span class="input-group-addon">Mot de Passe</span>
                                        <input type="password" class="form-control" id="inptPassword" value="<c:out value="${sessionScope.Utilisateur.getPassword()}"/>" required>
                                    </div>
                                    <div class="col-sm-10">
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="input-group debug-gestrest">
                                        <span class="input-group-addon">E-mail</span>
                                        <input type="email" class="form-control" id="inptEmail" value="<c:out value="${sessionScope.Utilisateur.getEmail()}"/>" required>
                                    </div>
                                    <div class="col-sm-10">
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="input-group debug-gestrest">
                                        <span class="input-group-addon">Telephone</span>
                                        <input type="text" class="form-control" id="inptPhone" value="<c:out value="${sessionScope.Utilisateur.getPhone()}"/>" required>
                                    </div>
                                    <div class="col-sm-10">
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>
                            </form>
                            <p class="text-right"><a onclick="UpdateUser()" class="btn btn-primary">Mettre à Jour</a></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script>
            function UpdateUser() {
                $.post("/Compte",{
                    nom: $("#inptNom").val(),
                    prenom: $("#inptPrenom").val(),
                    username: $("#inptUsername").val(),
                    password: $("#inptPassword").val(),
                    email: $("#inptEmail").val(),
                    phone: $("#inptPhone").val()
                }).done( function () { location.reload(true); } );
            }
        </script>
        <jsp:include page="/ODA-INF/BASE/Footer.jsp" />
    </body>
</html>