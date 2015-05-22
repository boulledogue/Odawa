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
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                Gestion des restaurants
                                <p class="text-right" style="margin-top: -20px; margin-bottom: 0px;"><a data-toggle="modal" data-target="#myModal" href="#"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span></a></p>
                            </div>
                            <div class="panel-body">
                                <c:forEach var="Restaurant" items="${Restaurants}">
                                    <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                                        <div class="panel panel-default">
                                            <div class="panel-heading" role="tab" id="headingOne">
                                                <h4 class="panel-title">
                                                    <a data-toggle="collapse" data-parent="#accordion" href="#collapse<c:out value="${Restaurant.getId()}"/>" aria-expanded="true" aria-controls="collapseOne">
                                                        <c:out value="${Restaurant.getNom()}"/>
                                                    </a>
                                                    <p class="text-right" style="margin-top: -20px; margin-bottom: 0px;"><a href="/Gestion?delete=<c:out value="${Restaurant.getId()}"/>"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></a></p>
                                                </h4>
                                            </div>
                                            <div id="collapse<c:out value="${Restaurant.getId()}"/>" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                                                <div class="panel-body">
                                                    <form class="form-horizontal">
                                                        <div class="form-group">
                                                            <div class="input-group debug-gestrest">
                                                                <span class="input-group-addon">Nom</span>
                                                                <input type="text" class="form-control" value="<c:out value="${Restaurant.getNom()}"/>">
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="col-lg-6">
                                                                <div class="input-group">
                                                                    <span class="input-group-addon">Adresse</span>
                                                                    <input type="text" class="form-control" value="<c:out value="${Restaurant.getAdresse()}"/>">
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-6">
                                                                <div  class="input-group">
                                                                    <span class="input-group-addon">Numéro</span>
                                                                    <input type="text" class="form-control" value="<c:out value="${Restaurant.getNumero()}"/>">
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="col-lg-6">
                                                                <div class="input-group">
                                                                    <span class="input-group-addon">Localité</span>
                                                                    <input type="text" class="form-control" value="<c:out value="${Restaurant.getLocalite()}"/>">
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-6">
                                                                <div  class="input-group">
                                                                    <span class="input-group-addon">Zip Code</span>
                                                                    <input type="text" class="form-control" value="<c:out value="${Restaurant.getZipCode()}"/>">
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="col-lg-12">
                                                                <label class="input-group-addon" style="border-bottom: 0px none; border-right: 1px solid #CCC;">Description</label>
                                                                <textarea class="form-control" rows="3"><c:out value="${Restaurant.getDescription()}"/></textarea>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="col-lg-6">
                                                                <div class="input-group">
                                                                    <span class="input-group-addon">Budget Low</span>
                                                                    <input type="text" class="form-control" value="<c:out value="${Restaurant.getBudgetLow()}"/>">
                                                                    <div class="input-group-addon"> &euro; </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-6">
                                                                <div  class="input-group">
                                                                    <span class="input-group-addon">Budget Hight</span>
                                                                    <input type="text" class="form-control" value="<c:out value="${Restaurant.getBudgetHigh()}"/>">
                                                                    <div class="input-group-addon"> &euro; </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </form>
                                                    <div class="panel panel-default">
                                                        <div class="panel-heading">
                                                            <h3 class="panel-title">Horaire</h3>
                                                        </div>
                                                        <div class="panel-body">
                                                            <form class="form-horizontal">
                                                                <div class="form-group">
                                                                    <div class="col-lg-6">
                                                                        <div class="input-group date">
                                                                            <span class="input-group-addon">Lundi Ouvert.</span>
                                                                            <input type="text" class="form-control" value="<c:out value="${Restaurant.getArrayHoraire()[0]}"/>">
                                                                            <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-6">
                                                                        <div  class="input-group date">
                                                                            <span class="input-group-addon">Lundi Fermet.</span>
                                                                            <input type="text" class="form-control" value="<c:out value="${Restaurant.getArrayHoraire()[1]}"/>">
                                                                            <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-lg-6">
                                                                        <div class="input-group date">
                                                                            <span class="input-group-addon">Mardi Ouvert.</span>
                                                                            <input type="text" class="form-control" value="<c:out value="${Restaurant.getArrayHoraire()[2]}"/>">
                                                                            <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-6">
                                                                        <div  class="input-group date">
                                                                            <span class="input-group-addon">Mardi Fermet.</span>
                                                                            <input type="text" class="form-control" value="<c:out value="${Restaurant.getArrayHoraire()[3]}"/>">
                                                                            <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-lg-6">
                                                                        <div class="input-group date">
                                                                            <span class="input-group-addon">Mercredi Ouvert.</span>
                                                                            <input type="text" class="form-control" value="<c:out value="${Restaurant.getArrayHoraire()[4]}"/>">
                                                                            <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-6">
                                                                        <div  class="input-group date">
                                                                            <span class="input-group-addon">Mercredi Fermet.</span>
                                                                            <input type="text" class="form-control" value="<c:out value="${Restaurant.getArrayHoraire()[5]}"/>">
                                                                            <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-lg-6">
                                                                        <div class="input-group date">
                                                                            <span class="input-group-addon">Jeudi Ouvert.</span>
                                                                            <input type="text" class="form-control" value="<c:out value="${Restaurant.getArrayHoraire()[6]}"/>">
                                                                            <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-6">
                                                                        <div  class="input-group date">
                                                                            <span class="input-group-addon">Jeudi Fermet.</span>
                                                                            <input type="text" class="form-control" value="<c:out value="${Restaurant.getArrayHoraire()[7]}"/>">
                                                                            <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-lg-6">
                                                                        <div class="input-group date">
                                                                            <span class="input-group-addon">Vendredi Ouvert.</span>
                                                                            <input type="text" class="form-control" value="<c:out value="${Restaurant.getArrayHoraire()[8]}"/>">
                                                                            <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-6">
                                                                        <div  class="input-group date">
                                                                            <span class="input-group-addon">Vendredi Fermet.</span>
                                                                            <input type="text" class="form-control" value="<c:out value="${Restaurant.getArrayHoraire()[9]}"/>">
                                                                            <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-lg-6">
                                                                        <div class="input-group date">
                                                                            <span class="input-group-addon">Samedi Ouvert.</span>
                                                                            <input type="text" class="form-control" value="<c:out value="${Restaurant.getArrayHoraire()[10]}"/>">
                                                                            <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-6">
                                                                        <div  class="input-group date">
                                                                            <span class="input-group-addon">Samedi Fermet.</span>
                                                                            <input type="text" class="form-control" value="<c:out value="${Restaurant.getArrayHoraire()[11]}"/>">
                                                                            <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-lg-6">
                                                                        <div class="input-group date">
                                                                            <span class="input-group-addon">Dimanche Ouvert.</span>
                                                                            <input type="text" class="form-control" value="<c:out value="${Restaurant.getArrayHoraire()[12]}"/>">
                                                                            <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-6">
                                                                        <div  class="input-group date">
                                                                            <span class="input-group-addon">Dimanche Fermet.</span>
                                                                            <input type="text" class="form-control" value="<c:out value="${Restaurant.getArrayHoraire()[13]}"/>">
                                                                            <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </form>
                                                        </div>
                                                    </div>
                                                    <form class="form-horizontal hello-debug">
                                                        <div class="form-group">
                                                            <div class="col-lg-6">
                                                                <div class="input-group">
                                                                    <span class="input-group-addon">
                                                                        <input type="checkbox" <c:out value="${Restaurant.getPremium() == true ? 'checked': ''}"/> disabled="">
                                                                    </span>
                                                                    <input type="text" class="form-control dbg-crsr" value="Premium"  disabled>
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-6">
                                                                <select class="form-control"> type
                                                                    <c:forEach var="Type" items="${Types}">
                                                                        <option value="<c:out value="${Type.getId()}"/>" <c:out value="${Restaurant.getIdTypeCuisine() == Type.getId() ? 'selected': ''}"/>>
                                                                            <c:out value="${Type.getType()}"/>
                                                                        </option>
                                                                    </c:forEach>
                                                                </select>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="col-sm-10">
                                                                <div class="radio" style="margin-top: -8px;">
                                                                    <label class="radio-inline">
                                                                        <input type="radio" name="rdio" value="1" <c:out value="${Restaurant.getGenre() == 1 ? 'checked': ''}"/> > Restaurant
                                                                    </label>
                                                                    <label class="radio-inline">
                                                                        <input type="radio" name="rdio" value="2" <c:out value="${Restaurant.getGenre() == 2 ? 'checked': ''}"/>> Snack
                                                                    </label>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </form>
                                                    <!-- <a class="btn btn-primary">Enregistrer</a> -->
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </c:forEach>  
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading">Gestion des reservations</div>
                            <div class="panel-body">
                                <div class="panel-group" id="accordion2" role="tablist" aria-multiselectable="true">
                                    <c:forEach var="Reservation" items="${Reservations}">
                                        <div class="panel panel-default <c:out value="${Reservation.getStatus() == 2 ? 'panel-success': ''}"/> <c:out value="${Reservation.getStatus() == 3 ? 'panel-danger': ''}"/>">
                                            <div class="panel-heading" role="tab" id="headingOne">
                                                <h4 class="panel-title"> <a data-toggle="collapse" data-parent="#accordion2" href="#collapseOne<c:out value="${Reservation.getId()}"/>" aria-expanded="true" aria-controls="collapseOne"><c:out value="${Reservation.getPrenom()}"/> <c:out value="${Reservation.getNom()}"/></a></h4>
                                            </div>
                                            <div id="collapseOne<c:out value="${Reservation.getId()}"/>" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                                                <div class="panel-body">
                                                    <div class="panel panel-default">
                                                        <div class="panel-body">
                                                            <form class="form-horizontal">
                                                                <div class="form-group">
                                                                    <label class="col-sm-2 control-label">Nom</label>
                                                                    <div class="col-sm-10">
                                                                        <p class="form-control-static"><c:out value="${Reservation.getNom()}"/></p>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label class="col-sm-2 control-label">Prenom</label>
                                                                    <div class="col-sm-10">
                                                                        <p class="form-control-static"><c:out value="${Reservation.getPrenom()}"/></p>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label class="col-sm-2 control-label">Date</label>
                                                                    <div class="col-sm-10">
                                                                        <p class="form-control-static"><c:out value="${Reservation.getDate()}"/></p>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label class="col-sm-2 control-label">Nbre de Personnes</label>
                                                                    <div class="col-sm-10">
                                                                        <p class="form-control-static"><c:out value="${Reservation.getNbPersonnes()}"/></p>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label class="col-sm-2 control-label">Email</label>
                                                                    <div class="col-sm-10">
                                                                        <p class="form-control-static"><c:out value="${Reservation.getEmail()}"/></p>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label class="col-sm-2 control-label">Type de Service</label>
                                                                    <div class="col-sm-10">
                                                                        <p class="form-control-static"><c:out value="${Reservation.getTypeService() == true ? 'Midi': 'Soir'}"/></p>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label class="col-sm-2 control-label">Téléphone</label>
                                                                    <div class="col-sm-10">
                                                                        <p class="form-control-static"><c:out value="${Reservation.getPhone()}"/></p>
                                                                    </div>
                                                                </div>
                                                            </form>
                                                        </div>
                                                    </div>
                                                    <c:if test="${ Reservation.getStatus() != 2 }"> <a onclick="AccepterPush(${Reservation.getId()})" class="btn btn-success hello-debug">Accepter</a> </c:if>
                                                    <c:if test="${ Reservation.getStatus() != 3 }"> <a onclick="RefuserPush(${Reservation.getId()})" class="btn btn-danger hello-debug">Refuser</a> </c:if>
                                                    </div>
                                                </div>
                                            </div>
                                    </c:forEach>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- Modal -->
        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                        <h4 class="modal-title" id="myModalLabel">Ajouter un Restaurant</h4>
                    </div>
                    <div class="modal-body">
                        <form class="form-horizontal">
                            <div class="form-group">
                                <div class="input-group debug-gestrest">
                                    <span class="input-group-addon">Nom</span>
                                    <input type="text" id="inptNom" class="form-control">
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-6">
                                    <div class="input-group">
                                        <span class="input-group-addon">Adresse</span>
                                        <input type="text" id="inptAdresse" class="form-control">
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div  class="input-group">
                                        <span class="input-group-addon">Numéro</span>
                                        <input type="text" id="inptNumero" class="form-control">
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-6">
                                    <div class="input-group">
                                        <span class="input-group-addon">Localité</span>
                                        <input type="text" id="inptLocalite" class="form-control">
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div  class="input-group">
                                        <span class="input-group-addon">Zip Code</span>
                                        <input type="text" id="inptZip" class="form-control">
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-12">
                                    <label class="input-group-addon" style="border-bottom: 0px none; border-right: 1px solid #CCC;">Description</label>
                                    <textarea class="form-control" id="inptDescr" rows="3"></textarea>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-6">
                                    <div class="input-group">
                                        <span class="input-group-addon">Budget Low</span>
                                        <input type="text" id="inptBdgLow" class="form-control">
                                        <div class="input-group-addon"> &euro; </div>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div  class="input-group">
                                        <span class="input-group-addon">Budget Hight</span>
                                        <input type="text" id="inptBdgHgt" class="form-control">
                                        <div class="input-group-addon"> &euro; </div>
                                    </div>
                                </div>
                            </div>
                        </form>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title">Horaire</h3>
                            </div>
                            <div class="panel-body">
                                <form class="form-horizontal">
                                    <div class="form-group">
                                        <div class="col-lg-6">
                                            <div class="input-group date">
                                                <span class="input-group-addon">Lundi Ouvert.</span>
                                                <input id="inptHrLndOuv" type="text" class="form-control">
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div  class="input-group date">
                                                <span class="input-group-addon">Lundi Fermet.</span>
                                                <input id="inptHrLndFrm" type="text" class="form-control">
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-6">
                                            <div class="input-group date">
                                                <span class="input-group-addon">Mardi Ouvert.</span>
                                                <input id="inptHrMarOuv" type="text" class="form-control">
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div  class="input-group date">
                                                <span class="input-group-addon">Mardi Fermet.</span>
                                                <input id="inptHrMarFrm" type="text" class="form-control">
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-6">
                                            <div class="input-group date">
                                                <span class="input-group-addon">Mercredi Ouvert.</span>
                                                <input id="inptHrMercOuv" type="text" class="form-control">
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div  class="input-group date">
                                                <span class="input-group-addon">Mercredi Fermet.</span>
                                                <input id="inptHrMercFrm" type="text" class="form-control">
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-6">
                                            <div class="input-group date">
                                                <span class="input-group-addon">Jeudi Ouvert.</span>
                                                <input id="inptHrJdOuv" type="text" class="form-control">
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="input-group date">
                                                <span class="input-group-addon">Jeudi Fermet.</span>
                                                <input id="inptHrJdFrm" type="text" class="form-control">
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-6">
                                            <div class="input-group date">
                                                <span class="input-group-addon">Vendredi Ouvert.</span>
                                                <input id="inptHrVndOuv" type="text" class="form-control">
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div  class="input-group date">
                                                <span class="input-group-addon">Vendredi Fermet.</span>
                                                <input id="inptHrVndFrm" type="text" class="form-control">
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-6">
                                            <div class="input-group date">
                                                <span class="input-group-addon">Samedi Ouvert.</span>
                                                <input id="inptHrSmdOuv" type="text" class="form-control">
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div  class="input-group date">
                                                <span class="input-group-addon">Samedi Fermet.</span>
                                                <input id="inptHrSmdFrm" type="text" class="form-control">
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-6">
                                            <div class="input-group date">
                                                <span class="input-group-addon">Dimanche Ouvert.</span>
                                                <input id="inptHrDmcOuv" type="text" class="form-control">
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div  class="input-group date">
                                                <span class="input-group-addon">Dimanche Fermet.</span>
                                                <input id="inptHrDmcFrm" type="text" class="form-control">
                                                <span class="input-group-addon"><span class="glyphicon glyphicon-time"></span></span>
                                            </div>
                                        </div>
                                    </div>
                                </form>
                            </div>
                        </div>
                        <form class="form-horizontal hello-debug">
                            <div class="form-group">
                                <div class="col-lg-12">
                                    <div  class="input-group">
                                        <span class="input-group-addon">Cuisine</span>
                                        <select id="inptType" class="form-control"> type
                                            <c:forEach var="Type" items="${Types}">
                                                <option value="<c:out value="${Type.getId()}"/>">
                                                    <c:out value="${Type.getType()}"/>
                                                </option>
                                            </c:forEach>
                                        </select>
                                    </div> 
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-sm-10">
                                    <div class="radio" style="margin-top: -8px;">
                                        <label class="radio-inline">
                                            <input type="radio" name="rdio" value="1" checked> Restaurant
                                        </label>
                                        <label class="radio-inline">
                                            <input type="radio" name="rdio" value="2"> Snack
                                        </label>
                                    </div>
                                </div>
                            </div>
                        </form>
                    </div>
                    <div class="modal-footer">
                        <a onclick="AddRestaurant()" class="btn btn-primary">Enregistrer</a>
                    </div>
                </div>
            </div>
        </div>
        <script>
            $('#Horaire').popover({html: true});
            $('.date').datetimepicker({format: 'HHmm'});
            function AddRestaurant() {
                $.post("/Gestion?action=1", {
                    nom: $("#inptNom").val(),
                    adresse: $("#inptAdresse").val(),
                    numero: $("#inptNumero").val(),
                    localite: $("#inptLocalite").val(),
                    zip: $("#inptZip").val(),
                    descr: $("#inptDescr").val(),
                    bdglow: $("#inptBdgLow").val(),
                    bdghgt: $("#inptBdgHgt").val(),
                    HrLndOuv: $("#inptHrLndOuv").val(),
                    HrLndFrm: $("#inptHrLndFrm").val(),
                    HrMarOuv: $("#inptHrMarOuv").val(),
                    HrMarFrm: $("#inptHrMarFrm").val(),
                    HrMercOuv: $("#inptHrMercOuv").val(),
                    HrMercFrm: $("#inptHrMercFrm").val(),
                    HrJdOuv: $("#inptHrJdOuv").val(),
                    HrJdFrm: $("#inptHrJdFrm").val(),
                    HrVndOuv: $("#inptHrVndOuv").val(),
                    HrVndFrm: $("#inptHrVndFrm").val(),
                    HrSmdOuv: $("#inptHrSmdOuv").val(),
                    HrSmdFrm: $("#inptHrSmdFrm").val(),
                    HrDmcOuv: $("#inptHrDmcOuv").val(),
                    HrDmcFrm: $("#inptHrDmcFrm").val(),
                    Type: $("#inptType").val(),
                    Genre: $('input[name=rdio]:checked').val(),
                }).done(function () {
                    location.reload(true);
                });
            }
            function AccepterPush(id) {
                $.post("/Gestion?action=2", {
                    id: id,
                    choix: 2
                }).done(function () {
                    location.reload(true);
                });
            }
            function RefuserPush(id) {
                $.post("/Gestion?action=2", {
                    id: id,
                    choix: 3
                }).done(function () {
                    location.reload(true);
                });
            }
        </script>
        <jsp:include page="/ODA-INF/BASE/Footer.jsp" />
    </body>
</html>