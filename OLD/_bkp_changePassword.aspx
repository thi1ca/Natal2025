<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="_bkp_changePassword.aspx.vb" Inherits="Torra.changePassword" %>


<!doctype html>
<html lang="en">
  <head>
    <title>Raspe & Ganhe - Trocar Senha</title>
    <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <link rel="icon" type="image/png" sizes="32x32" href="https://www.lojastorra.com.br/favicon-32x32.png">
    <link rel="icon" type="image/png" sizes="16x16" href="https://www.lojastorra.com.br/favicon-16x16.png">
    <link rel="shortcut icon" type="image/x-icon" href="https://www.lojastorra.com.br/favicon-32x32.png">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <!-- CSS Lojas Torra -->
    <link rel="stylesheet" href="assets/css/style.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Lato:ital,wght@0,100;0,300;0,400;0,700;0,900;1,100;1,300;1,400;1,700;1,900&display=swap" rel="stylesheet"> 
    <link rel="stylesheet" href="https://cdn.rawgit.com/tonystar/bootstrap-float-label/v4.0.2/bootstrap-float-label.min.css"/>
  </head>
  <body class="mobile">
    <header class="text-center banner">
        <div class="container">
            <h1><img src="assets/image/Logo_Raspe&Ganhe.svg" alt="Raspe & Ganhe"></h1>
        </div>
    </header>
    <main role="main" class="container login vh-90">
        <div class="container flex-column d-flex justify-content-center">
            <form class="pt-5 mx-auto" action="myTickets.aspx" id="form_trocasenha">
                <div class="row no-gutters">
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 mb-4">
                        <h3 class="text-white text-center">
                            <strong>Adicione sua</strong> nova senha</h3>
                    </div>
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 mb-2 form-group input-senha">
                        <span class="has-float-label mb-2 in-novasenha">
                            <label for="senha" class="floatlabel color1">Nova Senha</label>
                            <input class="form-control form-control-lg senha" type="password" name="senha" id="senha" value="" required>
                            <img src="assets/image/eye.svg" alt="Visualizar" class="eye">
                        </span>
                    </div>
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 mb-4 form-group input-senha">
                        <span class="has-float-label mb-2 in-recusenha">
                            <label for="senhaRec" class="floatlabel color2">Repeta sua senha</label>
                            <input class="form-control form-control-lg senhaRec" type="password" name="senhaRec" id="senhaRec" value="" required>
                            <img src="assets/image/eye.svg" alt="Visualizar" class="eye">
                        </span>
                    </div>
                    <button type="submit" class="btn btn-primary btn-lg btn-block">TROCAR SENHA</button>
                </div>
            </form>
        </div>
        <img src="assets/image/effects-bg-blur.svg" alt="" class="img-background">
    </main>

      
    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/0.9.0/jquery.mask.min.js"></script>

    <script src="https://cdn.jsdelivr.net/npm/jquery-validation@1.19.5/dist/jquery.validate.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/jquery-validation@1.19.5/dist/additional-methods.js"></script>

    <script src="assets/js/script.js"></script>
  </body>
</html>
