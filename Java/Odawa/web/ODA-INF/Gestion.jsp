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
                                                    <p class="text-right" style="margin-top: -20px; margin-bottom: 0px;"><a data-toggle="modal" data-target="#myModal" href="#"><span class="glyphicon glyphicon-remove" aria-hidden="true"></span></a></p>
                                                </h4>
                                            </div>
                                            <div id="collapse<c:out value="${Restaurant.getId()}"/>" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                                                <div class="panel-body">
                                                    <form class="form-horizontal">
                                                        <div class="form-group">
                                                            <div class="input-group debug-gestrest">
                                                                <span class="input-group-addon" id="basic-addon1">Nom</span>
                                                                <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getNom()}"/>">
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="col-lg-6">
                                                                <div class="input-group">
                                                                    <span class="input-group-addon" id="basic-addon1">Adresse</span>
                                                                    <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getAdresse()}"/>">
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-6">
                                                                <div  class="input-group">
                                                                    <span class="input-group-addon" id="basic-addon1">Numéro</span>
                                                                    <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getNumero()}"/>">
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="form-group">
                                                            <div class="col-lg-6">
                                                                <div class="input-group">
                                                                    <span class="input-group-addon" id="basic-addon1">Localité</span>
                                                                    <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getLocalite()}"/>">
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-6">
                                                                <div  class="input-group">
                                                                    <span class="input-group-addon" id="basic-addon1">Zip Code</span>
                                                                    <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getZipCode()}"/>">
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
                                                                    <span class="input-group-addon" id="basic-addon1">Budget Low</span>
                                                                    <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getBudgetLow()}"/>">
                                                                    <div class="input-group-addon"> &euro; </div>
                                                                </div>
                                                            </div>
                                                            <div class="col-lg-6">
                                                                <div  class="input-group">
                                                                    <span class="input-group-addon" id="basic-addon1">Budget Hight</span>
                                                                    <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getBudgetHigh()}"/>">
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
                                                                        <div class="input-group">
                                                                            <span class="input-group-addon" id="basic-addon1">Lundi Ouvert.</span>
                                                                            <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getArrayHoraire()[0]}"/>">
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-6">
                                                                        <div  class="input-group">
                                                                            <span class="input-group-addon" id="basic-addon1">Lundi Fermet.</span>
                                                                            <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getArrayHoraire()[1]}"/>">
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-lg-6">
                                                                        <div class="input-group">
                                                                            <span class="input-group-addon" id="basic-addon1">Mardi Ouvert.</span>
                                                                            <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getArrayHoraire()[2]}"/>">
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-6">
                                                                        <div  class="input-group">
                                                                            <span class="input-group-addon" id="basic-addon1">Mardi Fermet.</span>
                                                                            <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getArrayHoraire()[3]}"/>">
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-lg-6">
                                                                        <div class="input-group">
                                                                            <span class="input-group-addon" id="basic-addon1">Mercredi Ouvert.</span>
                                                                            <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getArrayHoraire()[4]}"/>">
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-6">
                                                                        <div  class="input-group">
                                                                            <span class="input-group-addon" id="basic-addon1">Mercredi Fermet.</span>
                                                                            <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getArrayHoraire()[5]}"/>">
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-lg-6">
                                                                        <div class="input-group">
                                                                            <span class="input-group-addon" id="basic-addon1">Jeudi Ouvert.</span>
                                                                            <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getArrayHoraire()[6]}"/>">
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-6">
                                                                        <div  class="input-group">
                                                                            <span class="input-group-addon" id="basic-addon1">Jeudi Fermet.</span>
                                                                            <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getArrayHoraire()[7]}"/>">
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-lg-6">
                                                                        <div class="input-group">
                                                                            <span class="input-group-addon" id="basic-addon1">Vendredi Ouvert.</span>
                                                                            <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getArrayHoraire()[8]}"/>">
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-6">
                                                                        <div  class="input-group">
                                                                            <span class="input-group-addon" id="basic-addon1">Vendredi Fermet.</span>
                                                                            <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getArrayHoraire()[9]}"/>">
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-lg-6">
                                                                        <div class="input-group">
                                                                            <span class="input-group-addon" id="basic-addon1">Samedi Ouvert.</span>
                                                                            <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getArrayHoraire()[10]}"/>">
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-6">
                                                                        <div  class="input-group">
                                                                            <span class="input-group-addon" id="basic-addon1">Samedi Fermet.</span>
                                                                            <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getArrayHoraire()[11]}"/>">
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="form-group">
                                                                    <div class="col-lg-6">
                                                                        <div class="input-group">
                                                                            <span class="input-group-addon" id="basic-addon1">Dimanche Ouvert.</span>
                                                                            <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getArrayHoraire()[12]}"/>">
                                                                        </div>
                                                                    </div>
                                                                    <div class="col-lg-6">
                                                                        <div  class="input-group">
                                                                            <span class="input-group-addon" id="basic-addon1">Dimanche Fermet.</span>
                                                                            <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getArrayHoraire()[13]}"/>">
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
                                                                        <input type="checkbox" aria-label="..." <c:out value="${Restaurant.getPremium() == true ? 'checked': ''}"/> disabled="">
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
                                                    </form>
                                                    <a class="btn btn-primary">Enregistrer</a>
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
                                                                    <label class="col-sm-2 control-label">Téléphone</label>
                                                                    <div class="col-sm-10">
                                                                        <p class="form-control-static"><c:out value="${Reservation.getPhone()}"/></p>
                                                                    </div>
                                                                </div>
                                                            </form>
                                                        </div>
                                                    </div>
                                                    <a class="btn btn-success hello-debug">Accepter</a>
                                                    <a class="btn btn-danger hello-debug">Refuser</a>
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
                                    <span class="input-group-addon" id="basic-addon1">Nom</span>
                                    <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getNom()}"/>">
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-6">
                                    <div class="input-group">
                                        <span class="input-group-addon" id="basic-addon1">Adresse</span>
                                        <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getAdresse()}"/>">
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div  class="input-group">
                                        <span class="input-group-addon" id="basic-addon1">Numéro</span>
                                        <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getNumero()}"/>">
                                    </div>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-lg-6">
                                    <div class="input-group">
                                        <span class="input-group-addon" id="basic-addon1">Localité</span>
                                        <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getLocalite()}"/>">
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div  class="input-group">
                                        <span class="input-group-addon" id="basic-addon1">Zip Code</span>
                                        <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getZipCode()}"/>">
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
                                        <span class="input-group-addon" id="basic-addon1">Budget Low</span>
                                        <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getBudgetLow()}"/>">
                                        <div class="input-group-addon"> &euro; </div>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div  class="input-group">
                                        <span class="input-group-addon" id="basic-addon1">Budget Hight</span>
                                        <input type="text" class="form-control" aria-describedby="basic-addon1" value="<c:out value="${Restaurant.getBudgetHigh()}"/>">
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
                                            <div class="input-group">
                                                <span class="input-group-addon" id="basic-addon1">Lundi Ouvert.</span>
                                                <input type="text" class="form-control" aria-describedby="basic-addon1">
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div  class="input-group">
                                                <span class="input-group-addon" id="basic-addon1">Lundi Fermet.</span>
                                                <input type="text" class="form-control" aria-describedby="basic-addon1">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-6">
                                            <div class="input-group">
                                                <span class="input-group-addon" id="basic-addon1">Mardi Ouvert.</span>
                                                <input type="text" class="form-control" aria-describedby="basic-addon1">
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div  class="input-group">
                                                <span class="input-group-addon" id="basic-addon1">Mardi Fermet.</span>
                                                <input type="text" class="form-control" aria-describedby="basic-addon1">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-6">
                                            <div class="input-group">
                                                <span class="input-group-addon" id="basic-addon1">Mercredi Ouvert.</span>
                                                <input type="text" class="form-control" aria-describedby="basic-addon1">
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div  class="input-group">
                                                <span class="input-group-addon" id="basic-addon1">Mercredi Fermet.</span>
                                                <input type="text" class="form-control" aria-describedby="basic-addon1">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-6">
                                            <div class="input-group">
                                                <span class="input-group-addon" id="basic-addon1">Jeudi Ouvert.</span>
                                                <input type="text" class="form-control" aria-describedby="basic-addon1">
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div  class="input-group">
                                                <span class="input-group-addon" id="basic-addon1">Jeudi Fermet.</span>
                                                <input type="text" class="form-control" aria-describedby="basic-addon1">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-6">
                                            <div class="input-group">
                                                <span class="input-group-addon" id="basic-addon1">Vendredi Ouvert.</span>
                                                <input type="text" class="form-control" aria-describedby="basic-addon1">
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div  class="input-group">
                                                <span class="input-group-addon" id="basic-addon1">Vendredi Fermet.</span>
                                                <input type="text" class="form-control" aria-describedby="basic-addon1">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-6">
                                            <div class="input-group">
                                                <span class="input-group-addon" id="basic-addon1">Samedi Ouvert.</span>
                                                <input type="text" class="form-control" aria-describedby="basic-addon1">
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div  class="input-group">
                                                <span class="input-group-addon" id="basic-addon1">Samedi Fermet.</span>
                                                <input type="text" class="form-control" aria-describedby="basic-addon1">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="col-lg-6">
                                            <div class="input-group">
                                                <span class="input-group-addon" id="basic-addon1">Dimanche Ouvert.</span>
                                                <input type="text" class="form-control" aria-describedby="basic-addon1">
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div  class="input-group">
                                                <span class="input-group-addon" id="basic-addon1">Dimanche Fermet.</span>
                                                <input type="text" class="form-control" aria-describedby="basic-addon1">
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
                                        <span class="input-group-addon" id="basic-addon1">Cuisine</span>
                                        <select class="form-control"> type
                                            <c:forEach var="Type" items="${Types}">
                                                <option value="<c:out value="${Type.getId()}"/>" <c:out value="${Restaurant.getIdTypeCuisine() == Type.getId() ? 'selected': ''}"/>>
                                                    <c:out value="${Type.getType()}"/>
                                                </option>
                                            </c:forEach>
                                        </select>
                                    </div> 
                                </div>
                            </div>
                        </form>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-primary">Enregistrer</button>
                    </div>
                </div>
            </div>
        </div>
        <jsp:include page="/ODA-INF/BASE/Footer.jsp" />
    </body>
</html>