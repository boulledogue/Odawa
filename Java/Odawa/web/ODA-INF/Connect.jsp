<%-- JSP Code --%>
<!DOCTYPE html>
<html lang="fr">
    <jsp:include page="/ODA-INF/BASE/Head.jsp" />
    <body>
        <jsp:include page="/ODA-INF/BASE/Navbar.jsp" />
        <div class="container">
            <div class="row">
                <div class="col-md-6 col-md-offset-3 vrt-center">
                    <div class="alert alert-danger hidden" role="alert">Votre nom d'utilisateur ou votre mot de passe est erron�!</div>
                    <div class="panel panel-default">
                        <div class="panel-body debug-search">
                            <form data-toggle="validator" class="form-horizontal">
                                <div class="form-group">
                                    <label class="col-sm-2 control-label">Username</label>
                                    <div class="col-sm-10">
                                        <input type="text" id="email" class="form-control" placeholder="" required>
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-sm-2 control-label">Password</label>
                                    <div class="col-sm-10">
                                        <input type="password" id="password" class="form-control" placeholder="" required>
                                        <div class="help-block with-errors"></div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-sm-offset-2 col-sm-10">
                                        <a href="#" class="btn btn-info" onclick="Send()">Se connecter!</a>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                    <div class="alert alert-info col-md-10" role="alert">Si vous n'avez pas encore de compte, pensez � en cr�er un!</div>
                    <div class="alert alert-info col-md-1 col-md-offset-1" role="alert"><p class="text-center"><a href="/Creation"><span class="glyphicon glyphicon-plus" style="color: white;" aria-hidden="true"></span></a></p></div>
                </div>
            </div>
        </div>
    </div>
    <script>
        function Send() {
            $.post("/Connect", {username: $("#email").val(), password: $("#password").val()})
                    .done(function (data) {
                        if (data.success === true) {
                            document.location.href = "/";
                        }
                        else {
                            $(".alert-danger").removeClass("hidden");
                            $(".alert-info").addClass("hidden")
                        }
                    });
        }
    </script>
    <jsp:include page="/ODA-INF/BASE/Footer.jsp" />
</body>
</html>
