<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<jsp:include page="/ODA-INF/Header.jsp" />
  <div class="container ocnt">
    <div class="row">
      <div class="panel panel-default">
        <div class="panel-body">
          <div class="page-header page-header-debug">
            <h4><p class="text-left">${Restaurant.getNom()}</p><p class="text-right txt-debug"><small><c:out value="${Restaurant.getGenre() == 1 ? 'Restaurant': 'Snack'}"/></small></p></h4>
          </div>
          <div>
            <div class="row">
            <div class="col-md-4">
              <div class="panel panel-default page">
                <div class="panel-body">
                  <div class="page-header page-header-debug">
                    <h4><p class="text-left">${Restaurant.getNom()}</p><p class="text-right txt-debug"><small><c:out value="${Restaurant.getGenre() == 1 ? 'Restaurant': 'Snack'}"/></small></p></h4>
                  </div>
                  <p class="text-right"><span class="badge"><c:out value="${Restaurant.getPremium() == true ? 'P': ''}"/></span></p>
                  <p class="text-right">${Restaurant.getRestaurateur()}</p>
                  <p><span class="text-muted">Type de Cuisine :</span></br> ${Restaurant.getTypeCuisine()}</p>
                  <p><span class="text-muted">Adresse :</span></br> ${Restaurant.getAllOfAdresse()} </p> 
                  <p><span class="text-muted">Fourchette de Tarif :</span></br> ${Restaurant.getAllBudget()}</p>
                  <p><span class="text-muted">Horaire :</span></br> ${Restaurant.getFormatHoraire()[day]}, ce ${nomJour} !
                  </br><a id="Horaire" tabindex="0" role="button" data-toggle="popover" data-trigger="focus" data-content="<table><tr><td><c:forEach var="Jour" items="${Restaurant.returnNomJour()}">${Jour}</br></c:forEach></td><td><c:forEach var="Horaire" items="${Restaurant.getFormatHoraire()}">${Horaire}</br></c:forEach></td></tr></table>">Autre ...</a></p>
                </div>
              </div>
            </div>
            <div class="col-md-8">
              <div class="panel panel-default page">
                <div class="panel-body">
                    <p> <span class="text-muted">Description :</span></br> ${Restaurant.getDescription()} </p>
                </div>
              </div>  
            </div>
          </div>
          </div>
        </div>
        <ul class="list-group">
          <c:forEach var="Comment" items="${Comments}" >
          <li class="list-group-item"><div class="input-group"><span class="input-group-addon">${Comment.getNomUtilisateur()} :</span><input type="text" class="form-control commnt" placeholder="${Comment.getCommentaire()}" disabled></div></li>
          </c:forEach>
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
  <script> $('#Horaire').popover({html: true}); </script>
<jsp:include page="/ODA-INF/Footer.jsp" />