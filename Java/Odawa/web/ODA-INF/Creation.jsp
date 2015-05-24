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
                            Création d'un compte utilisateur
                        </div>
                        <div class="panel-body">
                            <form id="UtForm" data-toggle="validator" class="form-horizontal">
                                <div class="form-group">
                                    <div class="input-group debug-gestrest">
                                        <span class="input-group-addon">Nom</span>
                                        <input type="text" class="form-control" id="inptNom">
                                    </div>
                                    <div class="col-sm-10">
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="input-group debug-gestrest">
                                        <span class="input-group-addon">Prenom</span>
                                        <input type="text" class="form-control" id="inptPrenom">
                                    </div>
                                    <div class="col-sm-10">
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="input-group debug-gestrest">
                                        <span class="input-group-addon">Nom d'Utilisateur</span>
                                        <input type="text" class="form-control" id="inptUsername">
                                    </div>
                                    <div class="col-sm-10">
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="input-group debug-gestrest">
                                        <span class="input-group-addon">Mot de Passe</span>
                                        <input type="password" class="form-control" id="inptPassword">
                                    </div>
                                    <div class="col-sm-10">
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="input-group debug-gestrest">
                                        <span class="input-group-addon">E-mail</span>
                                        <input type="email" class="form-control" id="inptEmail">
                                    </div>
                                    <div class="col-sm-10">
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="input-group debug-gestrest">
                                        <span class="input-group-addon">Telephone</span>
                                        <input type="text" class="form-control" id="inptPhone">
                                    </div>
                                    <div class="col-sm-10">
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>
                            </form>
                            <div class="col-sm-9"><div class="alert alert-info hidden" style="text-align: left;padding: 9px;" role="alert">Certains champs sont visiblement incomplets ou incorrectes!</div></div>
                            <div class="col-sm-3"><p class="text-right"><a onclick="CreateUser()" class="btn btn-primary">Créer!</a></p></div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <script>
            function CreateUser() {
                if(Validator()) {
                    $.post("/Creation",{
                        nom: $("#inptNom").val(),
                        prenom: $("#inptPrenom").val(),
                        username: $("#inptUsername").val(),
                        password: $("#inptPassword").val(),
                        email: $("#inptEmail").val(),
                        phone: $("#inptPhone").val().split('/').join('').split('.').join('')
                    }).done( function () { document.location.href = "/Connect";});
                }else{ $(".alert").removeClass("hidden"); $("#UtForm").validator('validate'); }
            }
            
            function Validator() {
                var emailreg = new RegExp('^[a-z0-9]+([_|\.|-]{1}[a-z0-9]+)*@[a-z0-9]', 'i');
                if ($("#inptNom").val() != "") {
                    if ($("#inptPrenom").val() != "") {
                        if ($("#inptUsername").val() != "") {
                            if ($("#inptPassword").val() != "") { 
                                if ($("#inptEmail").val() != "" && emailreg.test($("#inptEmail").val())) { 
                                    if ( $("#inptPhone").val() != "" && $.isNumeric($("#inptPhone").val().split('/').join('').split('.').join('')) ) {
                                        var rtn = true;
                                    } else { var rtn = false; }
                                } else { var rtn = false; }
                            } else { var rtn = false; }
                        } else { var rtn = false; }
                    } else { var rtn = false; }
                } else { var rtn = false; }
                return rtn;
            }
        </script>
        <jsp:include page="/ODA-INF/BASE/Footer.jsp" />
    </body>
</html>