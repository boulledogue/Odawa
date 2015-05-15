<%-- Dependance --%>
<%@ taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>

<%-- JSP Code --%>
<nav class="navbar navbar-default">
    <div class="container-fluid">
        <div class="navbar-header">
            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
                <span class="sr-only">Toggle navigation</span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
                <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="/">Odawa</a>
        </div>
        <div id="navbar" class="navbar-collapse collapse">
            <ul class="nav navbar-nav navbar-left">
                <p class="navbar-text navbar-text-debug">Restaurant,Snack,Bar,...</p>
                <li><span>&nbsp;</span></li>
                <li><a href="/Search?SearchType=1">Restaurants</a></li>
                <li class="last"><a href="/Search?SearchType=2">Snacks</a></li>
            </ul>
            <ul class="nav navbar-nav navbar-right">
                <c:if test="${ sessionScope.Utl != null }" > 
                    <p class="navbar-text hello-debug">
                        Bonjour <c:out value="${sessionScope.Utl.getPrenom()}"/> <c:out value="${sessionScope.Utl.getNom()}"/>
                        (<a href="/Disconnect"> Déconnecter </a>) -- Compte <c:out value="${(sessionScope.AdmState == true) ? 'Restaurateur': 'Utilisateur'}"/>
                    </p>
                    <li><a href="/Compte"> Gestion du compte </a></li>
                </c:if>
                <c:if test="${ sessionScope.AdmState == true }" > 
                   <li><a href="/Gestion"> Restaurant & Reservation </a></li>
                </c:if>
                <li class="<c:out value="${(sessionScope.Utl == null) ? '' : 'last'}"/>" ><a href="/Search"> Recherche </a></li>
                <c:if test="${ sessionScope.Utl == null }" >
                    <li class="last"><a href="/Connect"> Connexion </a></li>
                </c:if>
                <li><span>&nbsp;</span></li>
            </ul>
        </div>
    </div>
</nav>
