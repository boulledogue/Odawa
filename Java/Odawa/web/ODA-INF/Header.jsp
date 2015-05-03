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
          <p class="navbar-text hello-debug"> Bienvenue ${Session.getAttribute("Utilisateur").getNom()} </p>
          <li><a href="/Gestion"> Gestion du Compte </a></li>
          <li><a href="/Search"> Recherche </a></li>
          <li class="last"><a href="/Connect"> Connection </a></li>
          <!-- Oui, j'ai honte d'avoir utilisé cette méthode! J'en dors même mal la nuit ^^''' -->
          <li><span>&nbsp;</span></li>
        </ul>
      </div>
    </div>
  </nav>
