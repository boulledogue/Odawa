<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<jsp:include page="/ODA-INF/Header.jsp" />
  <div class="container ocnt">
    <div class="row">
      <div class="col-md-8">
        <div class="panel panel-default debug-panel">
          <div class="panel-body">
            <p class="debug-titre">Restaurant au hasard!</p>
            <div class="panel panel-default">
              <div class="panel-body">
                <div class="page-header page-header-debug">
                  <h4><p class="text-left">${RandomRestaurant.getNom()}</p><p class="text-right txt-debug"><small><c:out value="${RandomRestaurant.getGenre() == 1 ? 'Restaurant': 'Snack'}"/></small></p></h4>
                </div>
                <div class="well col-md-6 rest-prsnt"><div id="map-container"></div></div>
                <div class="col-md-6 rest-top top-rest">
                  <p class="text-right">${RandomRestaurant.getRestaurateur()}</p>
                  <p>Type de Cuisine : ${RandomRestaurant.getTypeCuisine()}</p>
                  <p>Adresse : ${RandomRestaurant.getAllOfAdresse()} </p> 
                  <p>Horaire : ${RandomRestaurant.getFormatHoraire()}</p>
                  <p>Fourchette de Tarif : ${RandomRestaurant.getAllBudget()}</p>
                  <p class="text-right"><span class="badge"><c:out value="${RandomRestaurant.getPremium() == true ? 'P': ''}"/></span></p>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="col-md-4">
        <div class="panel panel-default">
          <div class="panel-body">
            <p class="debug-titre">Les 3 Meilleurs Restaurant</p>
            <c:forEach var="Restaurant" items="${BestRestaurants}" >
                <div class="panel panel-default">
                    <div class="panel-body">
                        <h5><p class="text-left"><strong>${Restaurant.getNom()}</strong></p>
                            <p class="text-right txt-debug"><small> <c:out value="${Restaurant.getGenre() == 1 ? 'Restaurant': 'Snack'}"/> </small></p></h5>
                    </div>
                </div>
            </c:forEach>
          </div>
        </div>
      </div>
    </div>
  </div>
<jsp:include page="/ODA-INF/Footer.jsp" />
