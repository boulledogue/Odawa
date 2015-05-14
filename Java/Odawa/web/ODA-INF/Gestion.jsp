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
                            <div class="panel-heading">Gestion des restaurants</div>
                            <div class="panel-body">
                                <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                                    <div class="panel panel-default">
                                        <div class="panel-heading" role="tab" id="headingOne">
                                            <h4 class="panel-title"><a data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">La Frikadelle</a></h4>
                                        </div>
                                        <div id="collapseOne" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                                            <div class="panel-body">
                                                <form class="form-horizontal">
                                                    <div class="form-group">
                                                        <div class="input-group debug-gestrest">
                                                            <span class="input-group-addon" id="basic-addon1">Nom</span>
                                                            <input type="text" class="form-control" aria-describedby="basic-addon1">
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="col-lg-6">
                                                            <div class="input-group">
                                                                <span class="input-group-addon" id="basic-addon1">Adresse</span>
                                                                <input type="text" class="form-control" aria-describedby="basic-addon1">
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <div  class="input-group">
                                                                <span class="input-group-addon" id="basic-addon1">Numéro</span>
                                                                <input type="text" class="form-control" aria-describedby="basic-addon1">
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="col-lg-6">
                                                            <div class="input-group">
                                                                <span class="input-group-addon" id="basic-addon1">Localité</span>
                                                                <input type="text" class="form-control" aria-describedby="basic-addon1">
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <div  class="input-group">
                                                                <span class="input-group-addon" id="basic-addon1">Zip Code</span>
                                                                <input type="text" class="form-control" aria-describedby="basic-addon1">
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="input-group debug-gestrest">
                                                            <span class="input-group-addon" id="basic-addon1">Description</span>
                                                            <input type="text" class="form-control" aria-describedby="basic-addon1">
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <div class="col-lg-6">
                                                            <div class="input-group">
                                                                <span class="input-group-addon" id="basic-addon1">Budget Low</span>
                                                                <input type="text" class="form-control" aria-describedby="basic-addon1">
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <div  class="input-group">
                                                                <span class="input-group-addon" id="basic-addon1">Budget Hight</span>
                                                                <input type="text" class="form-control" aria-describedby="basic-addon1">
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
                                                        <div class="col-lg-6">
                                                            <div class="input-group">
                                                                <span class="input-group-addon">
                                                                    <input type="checkbox" aria-label="...">
                                                                </span>
                                                                <input type="text" class="form-control dbg-crsr" value="Premium" disabled>
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <select class="form-control">
                                                                <option>1</option>
                                                                <option>2</option>
                                                                <option>3</option>
                                                                <option>4</option>
                                                                <option>5</option>
                                                            </select>
                                                        </div>
                                                    </div>
                                                </form>
                                                <a class="btn btn-primary">Enregistrer</a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading">Gestion des reservations</div>
                            <div class="panel-body">
                                <div class="panel-group" id="accordion2" role="tablist" aria-multiselectable="true">
                                    <div class="panel panel-default panel-success">
                                        <div class="panel-heading" role="tab" id="headingOne">
                                            <h4 class="panel-title"> <a data-toggle="collapse" data-parent="#accordion2" href="#collapseOne2" aria-expanded="true" aria-controls="collapseOne"> Réservation Acceptée </a> </h4>
                                        </div>
                                        <div id="collapseOne2" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingOne">
                                            <div class="panel-body">
                                                <div class="panel panel-default">
                                                    <div class="panel-body">
                                                        <form class="form-horizontal">
                                                            <div class="form-group">
                                                                <label class="col-sm-2 control-label">Nom</label>
                                                                <div class="col-sm-10">
                                                                    <p class="form-control-static">email@example.com</p>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="col-sm-2 control-label">Prenom</label>
                                                                <div class="col-sm-10">
                                                                    <p class="form-control-static">email@example.com</p>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="col-sm-2 control-label">Date</label>
                                                                <div class="col-sm-10">
                                                                    <p class="form-control-static">email@example.com</p>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="col-sm-2 control-label">Nbre de Personnes</label>
                                                                <div class="col-sm-10">
                                                                    <p class="form-control-static">email@example.com</p>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="col-sm-2 control-label">Email</label>
                                                                <div class="col-sm-10">
                                                                    <p class="form-control-static">email@example.com</p>
                                                                </div>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="col-sm-2 control-label">Téléphone</label>
                                                                <div class="col-sm-10">
                                                                    <p class="form-control-static">email@example.com</p>
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
                                    <div class="panel panel-default">
                                        <div class="panel-heading" role="tab" id="headingTwo">
                                            <h4 class="panel-title"> <a class="collapsed" data-toggle="collapse" data-parent="#accordion2" href="#collapseTwo2" aria-expanded="false" aria-controls="collapseTwo"> Réservation en Attente </a> </h4>
                                        </div>
                                        <div id="collapseTwo2" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo">
                                            <div class="panel-body">
                                                Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                            </div>
                                        </div>
                                    </div>
                                    <div class="panel panel-default panel-danger">
                                        <div class="panel-heading" role="tab" id="headingThree">
                                            <h4 class="panel-title"> <a class="collapsed" data-toggle="collapse" data-parent="#accordion2" href="#collapseThree2" aria-expanded="false" aria-controls="collapseThree"> Réservation Refusée </a> </h4>
                                        </div>
                                        <div id="collapseThree2" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingThree">
                                            <div class="panel-body">
                                                Anim pariatur cliche reprehenderit, enim eiusmod high life accusamus terry richardson ad squid. 3 wolf moon officia aute, non cupidatat skateboard dolor brunch. Food truck quinoa nesciunt laborum eiusmod. Brunch 3 wolf moon tempor, sunt aliqua put a bird on it squid single-origin coffee nulla assumenda shoreditch et. Nihil anim keffiyeh helvetica, craft beer labore wes anderson cred nesciunt sapiente ea proident. Ad vegan excepteur butcher vice lomo. Leggings occaecat craft beer farm-to-table, raw denim aesthetic synth nesciunt you probably haven't heard of them accusamus labore sustainable VHS.
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <jsp:include page="/ODA-INF/BASE/Footer.jsp" />
    </body>
</html>