<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="scratch.aspx.vb" Inherits="Torra.scratch" %>


<!doctype html>
<html lang="en">
  <head>
    <title>Raspe & Ganhe - Raspe</title>
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
        <form id="form1" runat="server">

    <header class="text-center banner">
        <div class="container">
            <div class="w-100">
                <h1><img src="assets/image/Logo_Raspe&Ganhe.svg" alt="Raspe & Ganhe"></h1>
            </div>
        </div>
            <button class="navbar-toggler collapsed" type="button" data-toggle="collapse" data-target="#navbarCollapse" aria-controls="navbarCollapse" aria-expanded="false" aria-label="Toggle navigation">
                <!-- <span class="navbar-toggler-icon"></span> -->
                <img src="assets/image/icon-menu/icone-menu-open.svg" alt="Icone Abrir" class="open-icone">
            </button>
           
    </header>

    <main role="main" class="container">
        <div class="card-raspe container pt-5 flex-column d-flex justify-content-center">
            <div class="overlay-background">
                <a href="home.aspx"><img src="assets/image/touch-02.svg" alt="Touch" class="mb-3"></a>
                <p>Deslize o seu dedo da <strong>direita para a esquerda</strong> 
                    e teste a sua sorte!</p>
            </div>
            <div class="row no-gutters">
                <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12">
                    <div class="card mx-auto text-white flex-column d-flex justify-content-center align-items-center">
                        <div class="container" id="js-container">
                            <canvas class="canvas" id="js-canvas" width="325" height="440"></canvas>

                            <div class="premio py-4 px-4 text-center" style="visibility: hidden;" id="divPremio" runat="server">
                                <h2 class="text-blue mb-0">PARABÉNS</h2>
                                <span>Você ganhou</span>
                                <h3 class="text-orange mt-1">50,00</h3>
                                <span class="mb-3">na próxima compra</span>

                                <div class="position-relative">
                                    <p class="text-blue"> O Código de Desconto será enviado no seu <strong>Whatsapp</strong> e <strong>E-mail</strong> em até 7 dias. Utilize o seu desconto no  <strong>site ou APP Lojas Torra.</strong></p>
                                    <p class="text-blue">Você também pode acessar o Código de Desconto ao fazer login no Raspe&Ganhe, na área Meus Bilhetes / Premiados <strong>em até 7 dias. </strong></p>
                                </div>
                                <asp:TextBox ID="secretCode" class="text-orange mb-2" Visible="False" value="EFG3829" readonly="true" runat="server"></asp:TextBox>   
                                <a class="btn btn-primary btn-action bt-inline btn-lg btn-block d-none" href="receive-coupon.aspx" role="button">INFORMAÇÕES DO CÓDIGO</a>
                                <a href="./home" class="btn-action d-none line pt-3 text-orange">Voltar para meus bilhetes</a>
                            </div>  

                            <div class="premio py-5 px-4 text-center" style="visibility: hidden;" id="divRaspado" runat="server">
                                <div>
                                    <h2 class="text-blue mb-0">Não foi dessa vez</h2>
                                    <span>Tente novamente</span>
                                </div>
                                <div>
                                    <spam class="text-blue">Clique aqui e confira a lista de ganhadores</spam>
                                    <a href="./winners" class="d-none btn-action line text-orange">Lista dos Premiados</a>
                                </div>
                                <a class="btn btn-primary bt-inline btn-lg btn-block d-none" href="./home" role="button">VOLTAR PARA O INÍCIO</a> 
                                
                            </div>  


                        </div>
                    </div>    
                </div>
            </div>
        </div>
        <!-- <img src="assets/image/effects-bg-blur.svg" alt="" class="img-background"> -->
    </main>
             <asp:Label runat="server" Text="" ID="labScript" Visible="false"></asp:Label>
    </form>
      
    <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/0.9.0/jquery.mask.min.js"></script>

    <script src="assets/js/script.js"></script>
    <script src="assets/js/scratchCard.js"></script>
    <script src="assets/js/confetti.min.js"></script>
  </body>
</html>
