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
            <c:forEach var="restaurant" items="${Restaurants}" >
              <tr>
                <td><a href="/Restaurant?id=${restaurant.getId()}">${restaurant.getNom()}</a></td>
                <td>${restaurant.getLocalite()}</td>
                <td>${restaurant.getIdTypeCuisine()}</td>
                <c:choose>
                    <c:when test="${restaurant.getPremium() == true}">
                        <th><span class="badge">P</span></th>
                    </c:when>
                    <c:otherwise>
                        <th><span class="badge"></span></th>
                    </c:otherwise>
                </c:choose>
            </tr>
            </c:forEach>
          </tbody>
        </table>
      </div>
      <!--<nav>
        <ul class="pagination">
          <li><a href="#" aria-label="Previous"><span aria-hidden="true">&laquo;</span></a></li>
          <li><a href="#">1</a></li>
          <li><a href="#">2</a></li>
          <li><a href="#">3</a></li>
          <li><a href="#">4</a></li>
          <li><a href="#">5</a></li>
          <li><a href="#" aria-label="Next"><span aria-hidden="true">&raquo;</span></a></li>
        </ul>
      </nav>-->
    </div>
  </div>
<jsp:include page="/ODA-INF/Footer.jsp" />