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
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="page-header page-header-debug">
                            <h4><p class="text-left"><c:out value="${Restaurant.getNom()}"/></p><p class="text-right txt-debug"><small><c:out value="${Restaurant.getGenre() == 1 ? 'Restaurant': 'Snack'}"/></small></p></h4>
                        </div>
                        <div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="panel panel-default page">
                                        <div class="panel-body">
                                            <p class="text-right"><span class="badge"><c:out value="${Restaurant.getPremium() == true ? 'P': ''}"/></span></p>
                                            <p class="text-right"><c:out value="${Restaurant.getRestaurateur()}"/></p>
                                            <p>
                                                <span class="text-muted">Type de Cuisine :</span></br>
                                                <a id="Descr" href="/Search?SearchType=3&TypeCuisine=<c:out value="${Restaurant.getIdTypeCuisine()}"/>" data-toggle="tooltip" data-placement="right" title="Description :</br><c:out value="${Restaurant.getDescriptionTypeCuisine()}"/>"><c:out value="${Restaurant.getTypeCuisine()}"/></a>
                                            </p>
                                            <p><span class="text-muted">Adresse :</span></br><c:out value="${Restaurant.getAllOfAdresse()}"/></p> 
                                            <p><span class="text-muted">Fourchette de Tarif :</span></br><c:out value="${Restaurant.getAllBudget()}"/></p>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-8">
                                    <div class="panel panel-default page">
                                        <div class="panel-body">
                                            <p><span class="text-muted">Description :</span></br><c:out value="${Restaurant.getDescription()}"/></p>
                                        </div>
                                    </div>
                                    <div class="panel panel-default page">
                                        <table class="table">
                                            <thead>
                                                <tr>
                                                    <th>Jour</th>
                                                    <th>Horaire</th>

                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td>
                                                        <c:forEach var="Jour" items="${ListNomJour}">
                                                            <c:out value="${Jour}"/></br>
                                                        </c:forEach>
                                                    </td>
                                                    <td>
                                                        <c:forEach var="Horaire" items="${Restaurant.getFormatHoraire()}">
                                                            <c:out value="${Horaire}"/></br>
                                                        </c:forEach>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <ul class="list-group">
                        <c:forEach var="Comment" items="${Comments}">
                            <li class="list-group-item">
                                <div class="input-group">
                                    <span class="input-group-addon"><c:out value="${Comment.getNomUtilisateur()}"/> :</span>
                                    <input type="text" class="form-control commnt" placeholder="<c:out value="${Comment.getCommentaire()}"/>" disabled>
                                </div>
                            </li>
                        </c:forEach>
                    </ul>
                </div>
                <c:if test="${ sessionScope.isRestaurateur != true }" >
                    <c:if test="${ sessionScope.Utilisateur != null }" >
                        <div class="panel panel-default">
                            <div class="panel-body">
                                <div class="input-group">
                                    <input id="comm" type="text" class="form-control" placeholder="Nouveau Commentaire">
                                    <span class="input-group-btn">
                                        <a onclick="SendComment()" class="btn btn-primary" type="button">Send</a>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </c:if>
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <button type="button" class="btn btn-default" data-toggle="modal" data-target=".resrv-rest-modal">Reserver dans ce Restaurant</button>
                        </div>
                    </div>
                </c:if>
            </div>
        </div>
        <c:if test="${ sessionScope.isRestaurateur != true }" >
            <div class="modal fade resrv-rest-modal" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                            <h4 class="modal-title" id="myModalLabel">Demander une r�servation</h4>
                        </div>
                        <div class="modal-body">
                            <form id="formRest" role="form" data-toggle="validator" class="form-horizontal">
                                <div class="form-group">
                                    <label class="col-sm-2 control-label">Nom</label>
                                    <div class="col-sm-10">
                                        <input type="text" pattern="^[A-Za-z��-]{2,}$" class="form-control" id="inptNom" value="<c:out value="${sessionScope.Utilisateur.getNom()}"/>" <c:out value="${(sessionScope.Utilisateur != null)? 'disabled' : ''}"/> required>
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-2 control-label">Pr�nom</label>
                                    <div class="col-sm-10">
                                        <input type="text" pattern="^[A-Za-z��-]{2,}$" class="form-control" id="inptPrenom" value="<c:out value="${sessionScope.Utilisateur.getPrenom()}"/>" <c:out value="${(sessionScope.Utilisateur != null)? 'disabled' : ''}"/> required>
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-2 control-label">Date</label>
                                    <div class="col-sm-10">
                                        <div class='input-group date' style="">
                                            <input type="text" id="inptDate" class="form-control" required />
                                            <span class="input-group-addon">
                                                <span class="glyphicon glyphicon-calendar"></span>
                                            </span>
                                        </div>
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-2 control-label">Nbre de Personnes</label>
                                    <div class="col-sm-10">
                                        <input min="1" max="99" type="number" class="form-control" id="inptNbr" required>
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-2 control-label">Email</label>
                                    <div class="col-sm-10">
                                        <input type="email" class="form-control" id="inptEmail" value="<c:out value="${sessionScope.Utilisateur.getEmail()}"/>" <c:out value="${(sessionScope.Utilisateur != null)? 'disabled' : ''}"/> required>
                                        <div class="help-block with-errors"> Veuillez encoder l'email sous la forme suivante : xxx@xxx.xx .  </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-2 control-label">T�l�phone</label>
                                    <div class="col-sm-10">
                                        <input type="text" pattern="^0[1-9][0-9]{7,8}$" class="form-control" id="inptPhone" value="<c:out value="${sessionScope.Utilisateur.getPhone()}"/>" <c:out value="${(sessionScope.Utilisateur != null)? 'disabled' : ''}"/> required>
                                        <div class="help-block with-errors"> Veuillez encoder le num�ro sous la forme suivante : 0xxxxxxxx ou 04xxxxxxxx . </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-2 control-label">Type de Service</label>
                                    <div class="col-sm-10">
                                        <div class="radio" style="margin-top: -8px;">
                                            <label class="radio-inline">
                                                <input type="radio" name="rdio" value="false" checked> Midi
                                            </label>
                                            <label class="radio-inline">
                                                <input type="radio" name="rdio" value="true"> Soir
                                            </label>
                                        </div>
                                    </div>
                                </div>
                            </form>
                        </div>
                        <div class="modal-footer">
                            <div class="col-sm-10"><div class="alert alert-danger hidden" style="text-align: left;padding: 9px;" role="alert">Certains champs sont incomplets ou incorrects!</div></div>
                            <div class="col-sm-2"><a id="send" onclick="SendReservation()" class="btn btn-danger btn-sm" >Envoyer</a></div>
                        </div>
                    </div>
                </div>
            </div>
        </c:if>
        <script>
            $('#Descr').tooltip({html: true});
            $('.date').datetimepicker({format: 'DD/MM/YYYY',minDate: moment().add(1, 'd')});
            <c:if test="${ sessionScope.Utilisateur != null }" >
            function SendComment() {
                $.post("/Restaurant?action=1", {
                    idrest: <c:out value="${Restaurant.getId()}"/>,
                    comm: $("#comm").val(),
                    idutl: <c:out value="${sessionScope.Utilisateur.getId()}"/>
                }).done(function () {
                    location.reload(true);
                });
            }
            </c:if>
            <c:if test="${sessionScope.isRestaurateur != true }" >
            
            function SendReservation() {
                if( Validator()) {
                    $.post("/Restaurant?action=2", {
                    nom: $("#inptNom").val(),
                    prenom: $("#inptPrenom").val(),
                    date: $("#inptDate").val(),
                    nbrePersonne: $("#inptNbr").val(),
                    email: $("#inptEmail").val(),
                    phone: $("#inptPhone").val(),
                    type: $('input[name=rdio]:checked').val(),
                    idrest: ${Restaurant.getId()}}
                    ).done(function () { location.reload(true); });
                }else{ $(".alert").removeClass("hidden"); $("#formRest").validator('validate'); }
            }
            
            function Validator() {
                var nomreg = new RegExp('^[A-Za-z��-]{2,}$','i');
                //var emailreg = new RegExp('\b[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}\b','i');
                var phonereg = new RegExp('^0[1-9][0-9]{7,8}$','i');
                if ($("#inptNom").val() != "" && nomreg.test($("#inptNom").val()) ) {
                    if ($("#inptPrenom").val() != "" && nomreg.test($("#inptNom").val())) {
                        if ($("#inptDate").val() != "") {
                            if ($("#inptNbr").val() != "" && $.isNumeric($("#inptNbr").val())) { 
                                if ($("#inptEmail").val() != "") { //&& emailreg.test($("#inptEmail").val()))
                                    if ( $("#inptPhone").val() != "" && phonereg.test($("#inptPhone").val()) ) {
                                        var rtn = true;
                                    } else { var rtn = false; console.log("Echec Phone"); }
                                } else { var rtn = false; console.log("Echec Email"); }
                            } else { var rtn = false; console.log("Echec Nbr"); }
                        } else { var rtn = false; console.log("Echec Date"); }
                    } else { var rtn = false; console.log("Echec Prenom"); }
                } else { var rtn = false; console.log("Echec Nom"); }
                return rtn;
            }
            
            </c:if>
        </script>
        <jsp:include page="/ODA-INF/BASE/Footer.jsp" />
    </body>
</html>