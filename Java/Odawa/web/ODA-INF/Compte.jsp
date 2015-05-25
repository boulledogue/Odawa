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
                                <p class="text-right" style="margin-top: -20px; margin-bottom: 0px;"><a href="#" data-toggle="modal" data-target=".bs-example-modal-sm" ><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></a></p>
                                    </c:if>
                        </div>
                        <div class="panel-body">
                            <form id="UtForm" data-toggle="validator" class="form-horizontal">
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
                            <div class="col-sm-9"><div class="alert alert-info hidden" style="text-align: left;padding: 9px;" role="alert">Certains champs sont visiblement incomplets ou incorrectes!</div></div>
                            <div class="col-sm-3"><p class="text-right"><a onclick="UpdateUser()" class="btn btn-primary">Mettre à Jour</a></p></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="modal fade bs-example-modal-sm" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-sm">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="myModalLabel">Suppression</h4>
                    </div>
                    <div class="modal-body">
                        Etes-vous sûr de vouloir supprimer ce compte ? 
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-danger" type="button" class="close" data-dismiss="modal" aria-label="Close">Refuser</button>
                        <a href="/Compte?delete=<c:out value="${sessionScope.Utilisateur.getId()}"/>" class="btn btn-danger">Accepter</a>
                    </div>
                </div>
            </div>
        </div>
        <script>
            function UpdateUser() {
                if (Validator() == true) {
                    $.post("/Compte", {
                        nom: $("#inptNom").val(),
                        prenom: $("#inptPrenom").val(),
                        username: $("#inptUsername").val(),
                        password: $("#inptPassword").val(),
                        email: $("#inptEmail").val(),
                        phone: $("#inptPhone").val().split('/').join('').split('.').join('')
                    }).done(function () {
                        location.reload(true);
                    });
                } else {
                    $(".alert").removeClass("hidden");
                    $("#UtForm").validator('validate');
                }
            }

            function Validator() {
                var emailreg = new RegExp('^[a-z0-9]+([_|\.|-]{1}[a-z0-9]+)*@[a-z0-9]', 'i');
                if ($("#inptNom").val() != "") {
                    if ($("#inptPrenom").val() != "") {
                        if ($("#inptUsername").val() != "") {
                            if ($("#inptPassword").val() != "") {
                                if ($("#inptEmail").val() != "" && emailreg.test($("#inptEmail").val())) {
                                    if ($("#inptPhone").val() != "" && $.isNumeric($("#inptPhone").val().split('/').join('').split('.').join(''))) {
                                        var rtn = true;
                                    } else {
                                        var rtn = false;
                                    }
                                } else {
                                    var rtn = false;
                                }
                            } else {
                                var rtn = false;
                            }
                        } else {
                            var rtn = false;
                        }
                    } else {
                        var rtn = false;
                    }
                } else {
                    var rtn = false;
                }
                return rtn;
            }
        </script>
        <jsp:include page="/ODA-INF/BASE/Footer.jsp" />
    </body>
</html>