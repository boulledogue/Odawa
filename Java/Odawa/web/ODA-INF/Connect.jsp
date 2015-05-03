<!DOCTYPE html>
<html lang="fr">
  <head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Template</title>
    <link href="/ODA-INF/css/yeti.min.css" rel="stylesheet">
  </head>
  <body>
    <div class="container">
      <div class="row">
        <div class="col-md-6 col-md-offset-3 vrt-center">
          <div class="panel panel-default">
            <div class="panel-body debug-search">
              <form class="form-horizontal">
                <div class="form-group">
                  <label class="col-sm-2 control-label">Username</label>
                  <div class="col-sm-10">
                    <input type="email" id="email" class="form-control" placeholder="">
                  </div>
                </div>
                <div class="form-group">
                  <label class="col-sm-2 control-label">Password</label>
                  <div class="col-sm-10">
                    <input type="password" id="password" class="form-control" placeholder="">
                  </div>
                </div>
                <div class="form-group">
                  <div class="col-sm-offset-2 col-sm-10">
                    <a href="#" class="btn btn-info" onclick="Send()">Send</a>
                  </div>
                </div>
              </form>
            </div>
          </div>
        </div>
      </div>
    </div>
    <script src="/ODA-INF/js/jquery.min.js"></script>
    <script src="/ODA-INF/js/bootstrap.min.js"></script>
    <script>
    function Send() {
        $.post("/Connect",{username: $("#email").val(),password: $("#password").val()})
            .done(function(data) { 
                if(data.success === true) document.location.href="/";
                else alert("Votre login ou votre password est mauvais !")
            })
    }
    </script>
  </body>
</html>
