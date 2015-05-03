<jsp:include page="/ODA-INF/Header.jsp" />
  <div class="container ocnt">
    <div class="row">
      <div class="panel panel-default">
        <div class="panel-body">
          <div class="page-header page-header-debug">
            <h4><p class="text-left">${Restaurant.getNom()}</p><p class="text-right txt-debug"><small> 
                        <c:choose>
                            <c:when test="${Restaurant.getGenre() == 1 }">
                                Restaurant
                            </c:when>
                            <c:otherwise>
                                Snack
                            </c:otherwise>
                        </c:choose>
            </small></p></h4>
          </div>
          <div>
            <div class="well col-md-6 rest-plus-descr"><div id="map-container"></div></div>
            <div class="col-md-6 rest-prsnt">
              <p class="text-right">${Restaurateur.getNom()} ${Restaurateur.getPrenom()}</p>
              <p>Type de Cuisine : ${TypeCuisine.getType()}</p>
              <p>Adresse : ${Restaurant.getAdresse()}, n°${Restaurant.getNumero()} -- ${Restaurant.getZipCode()} ${Restaurant.getLocalite()} </p>
              <p>Horaire : 8H-22H</p>
              <p>Fourchette de Tarif : De ${Restaurant.getBudgetLow()} Euros à ${Restaurant.getBudgetHigh()} Euros</p>
              <div class="well descr">${Restaurant.getDescription()}</div>
            </div>
          </div>
        </div>
        <ul class="list-group">
          <li class="list-group-item"><div class="input-group"><span class="input-group-addon">Marcel :</span><input type="text" class="form-control commnt" placeholder="Tu tire ou Tu pointe ?" disabled></div></li>
          <li class="list-group-item"><div class="input-group"><span class="input-group-addon">Pagnol :</span><input type="text" class="form-control commnt" placeholder="Je pointe Marcel ! Je pointe !" disabled></div></li>
          <li class="list-group-item"><div class="input-group"><span class="input-group-addon">Le Chateau :</span><input type="text" class="form-control commnt" placeholder="Ha, la vinasse du chateau! Du chateau ! Du chateau ! Qu'elle est belle, Qu'il est beau !" disabled></div></li>
          <li class="list-group-item"><div class="input-group"><span class="input-group-addon">De :</span><input type="text" class="form-control commnt" placeholder="De ? Non, rien ! Oublie !" disabled></div></li>
          <li class="list-group-item"><div class="input-group"><span class="input-group-addon">Ma Mere :</span><input type="text" class="form-control commnt" placeholder="On avait dis : 'Pas les mamans !'" disabled></div></li>
          <li class="list-group-item"> <a>Et 50 autres commentaires ...</a> </li>
        </ul>
      </div>
      <div class="panel panel-default">
        <div class="panel-body">
          <div class="input-group">
            <input type="text" class="form-control" placeholder="Nouveau Commentaire">
            <span class="input-group-btn">
              <button class="btn btn-primary" type="button">Send</button>
            </span>
          </div>
        </div>
      </div>
      <div class="panel panel-default">
        <div class="panel-body">
          <button type="button" class="btn btn-default" data-toggle="modal" data-target=".resrv-rest-modal">Reserver dans ce Restaurant</button>
          <p class="text-right txt-debug">Vous avez déja <b>2</b> réservations pour ce restaurant! </p>
        </div>
      </div>
    </div>
  </div>
  <div class="modal fade resrv-rest-modal" tabindex="-1" role="dialog" aria-labelledby="mySmallModalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
          <h4 class="modal-title" id="myModalLabel">Demander une réservation</h4>
        </div>
        <div class="modal-body">
          <form class="form-horizontal">
            <div class="form-group">
              <label for="inputEmail3" class="col-sm-2 control-label">Nom</label>
              <div class="col-sm-10">
                <input type="text" class="form-control" id="inputEmail3">
              </div>
            </div>
            <div class="form-group">
              <label for="inputPassword3" class="col-sm-2 control-label">Prénom</label>
              <div class="col-sm-10">
                <input type="text" class="form-control" id="inputPassword3">
              </div>
            </div>
            <div class="form-group">
              <label for="inputPassword3" class="col-sm-2 control-label">Date</label>
              <div class="col-sm-10">
                <input type="text" class="form-control" id="inputPassword3">
              </div>
            </div>
            <div class="form-group">
              <label for="inputPassword3" class="col-sm-2 control-label">Nbre de Personnes</label>
              <div class="col-sm-10">
                <input type="text" class="form-control" id="inputPassword3">
              </div>
            </div>
            <div class="form-group">
              <label for="inputPassword3" class="col-sm-2 control-label">Email</label>
              <div class="col-sm-10">
                <input type="text" class="form-control" id="inputPassword3">
              </div>
            </div>
            <div class="form-group">
              <label for="inputPassword3" class="col-sm-2 control-label">Téléphone</label>
              <div class="col-sm-10">
                <input type="text" class="form-control" id="inputPassword3">
              </div>
            </div>
          </form>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-primary btn-sm">Envoyer</button>
        </div>
      </div>
    </div>
  </div>
<jsp:include page="/ODA-INF/Footer.jsp" />