<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<jsp:include page="/ODA-INF/Header.jsp" />
  <div class="container ocnt">
    <div class="row">
      <c:if test="${SearchType == 0 }">
      <div class="panel panel-default">
        <div class="panel-heading">
          <div class="form-group">
            <div class="input-group debug-search">
              <div class="input-group-addon">Recherche :</div>
              <form method="post">
                  <input type="text" class="form-control" name="SearchString">
              </form>
            </div>
          </div>
        </div>
      </div>
      </c:if>  
      <div class="panel panel-default">
        <table class="table">
          <thead>
            <tr>
              <th>Nom</th>
              <th>Localisation</th>
              <th>Type de cuisine</th>
              <th>Premium</th>
            </tr>
          </thead>
          <tbody>
            <c:forEach var="Restaurant" items="${Restaurants}" >
              <tr>
                <td><a href="/Restaurant?id=${Restaurant.getId()}">${Restaurant.getNom()}</a></td>
                <td>${Restaurant.getLocalite()}</td>
                <td>${Restaurant.getTypeCuisine()}</td>
                <th><span class="badge"><c:out value="${Restaurant.getPremium() == true ? 'P': ''}"/></span></th>
            </tr>
            </c:forEach>
          </tbody>
        </table>
      </div>
    </div>
  </div>
<jsp:include page="/ODA-INF/Footer.jsp" />