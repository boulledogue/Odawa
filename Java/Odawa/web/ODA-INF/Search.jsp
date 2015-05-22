<%-- Dependance --%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<%@ taglib prefix="fn" uri="http://java.sun.com/jsp/jstl/functions" %>

<%-- JSP Code --%>
<!DOCTYPE html>
<html lang="fr">
    <jsp:include page="/ODA-INF/BASE/Head.jsp" />
    <body>
        <jsp:include page="/ODA-INF/BASE/Navbar.jsp" />
        <div class="container ocnt">
            <div class="row">
                <c:if test="${SearchType == 0 || SearchType == 3 }">
                    <div role="tabpanel">
                        <ul style="padding-left: 5px;" class="nav nav-tabs" role="tablist">
                            <li role="presentation" class="<c:out value="${SearchType == 0?'active':''}"/>"><a style="padding: 5px 15px;" href="<c:out value="${SearchType == 3?'/Search':'#home'}"/>" aria-controls="home" role="<c:out value="${SearchType == 0?'tab':''}"/>" data-toggle="<c:out value="${SearchType == 0?'tab':''}"/>">Texte</a></li>
                            <li role="presentation" class="<c:out value="${SearchType == 3?'active':''}"/>"><a style="padding: 5px 15px;" href="#profile" aria-controls="profile" role="tab" data-toggle="tab">Type de Cuisine</a></li>
                        </ul>
                        <div class="tab-content">
                            <div role="tabpanel" class="tab-pane <c:out value="${SearchType == 0?'active':''}"/>" id="home">
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
                            </div>
                            <div role="tabpanel" class="tab-pane <c:out value="${SearchType == 3?'active':''}"/>" id="profile">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <div class="row">
                                            <c:forEach var="TypeCuisine" items="${TypeCuisines}" >
                                                <div class="col-md-2"><a data-toggle="tooltip" data-placement="bottom" title="<c:out value="${TypeCuisine.getDescription()}"/>" href="Search?SearchType=3&TypeCuisine=<c:out value="${TypeCuisine.getId()}"/>"><c:out value="${TypeCuisine.getType()}"/></a></div>
                                                </c:forEach>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </c:if>
                
                <c:if test="${fn:length(Restaurants) gt 0 }">
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
                                    <td><a href="/Restaurant?id=<c:out value="${Restaurant.getId()}"/>"><c:out value="${Restaurant.getNom()}"/></a></td>
                                    <td><c:out value="${Restaurant.getLocalite()}"/></td>
                                    <td><c:out value="${Restaurant.getTypeCuisine()}"/></td>
                                    <th><span class="badge"><c:out value="${Restaurant.getPremium() == true ? 'P': ''}"/></span></th>
                                </tr>
                            </c:forEach>
                        </tbody>
                    </table>
                </div>
                </c:if>
                
            </div>
        </div>
        <script>
            $(function () { $('[data-toggle="tooltip"]').tooltip() })
        </script>
        <jsp:include page="/ODA-INF/BASE/Footer.jsp" />
    </body>
</html>
