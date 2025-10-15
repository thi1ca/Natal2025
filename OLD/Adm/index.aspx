<%@ Page Title="Lojas Torra - Admin" Language="vb" AutoEventWireup="false" CodeBehind="index.aspx.vb" Inherits="Torra.index" %>
<!DOCTYPE html>

<html lang="pt-BR">
<head runat="server">
  
     <!-- Required meta tags -->
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">

    <link rel="icon" type="image/png" sizes="32x32" href="https://www.lojastorra.com.br/favicon-32x32.png">
    <link rel="icon" type="image/png" sizes="16x16" href="https://www.lojastorra.com.br/favicon-16x16.png">
    <link rel="shortcut icon" type="image/x-icon" href="https://www.lojastorra.com.br/favicon-32x32.png">

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" integrity="sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T" crossorigin="anonymous">
    <!-- CSS Lojas Torra -->
    <link rel="stylesheet" href="../assets/css/styleAdm.css">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Lato:ital,wght@0,100;0,300;0,400;0,700;0,900;1,100;1,300;1,400;1,700;1,900&display=swap" rel="stylesheet"> 
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.10.0/css/bootstrap-datepicker.min.css" integrity="sha512-34s5cpvaNG3BknEWSuOncX28vz97bRI59UnVtEEpFX536A7BtZSJHsDyFoCl8S7Dt2TPzcrCEoHBGeM4SUBDBw==" crossorigin="anonymous" referrerpolicy="no-referrer" /> 
    <link href="https://cdn.jsdelivr.net/npm/sweetalert2@11.10.6/dist/sweetalert2.min.css" rel="stylesheet">
     <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11.10.6/dist/sweetalert2.all.min.js"></script>


</head>
<body>
    <form id="form1" runat="server">
        <div>
                 <header class="text-center">
        <div class="container">
            <div class="row align-content-center align-items-center">
                <div class="col-12 col-sm-12 col-md-12 col-xl-12 col-lg-12">
                    <h1><img src="../assets/image/logo-torra.svg" alt="Lojas Torra"></h1>
                </div>
            </div>
        </div>
    </header>
     <section class="banner positive text-center ">
        <div class="container pb-4 pt-4 pb-md-5 pt-md-5 h-100 d-flex flex-column align-content-center justify-content-center">
            <h2>LOGIN</h2>
            <h6>Faça login em sua conta</h6>
        </div>
    </section>
    <main role="main" class="container login mb-5">
        <div class="container flex-column d-flex justify-content-center mb-5">
            <div class="py-5 mx-auto formSetup">
                <div class="input-group input-group-lg mb-3">
                    <div class="input-group-prepend">
                      <span class="input-group-text" id="inputGroup-sizing-lg"><img src="../assets/image/avatar-adm.svg"></span>
                    </div>
                    <asp:TextBox ID="tbEmail" class="form-control" placeholder="Endereço de e-mail" runat="server" required="True" MaxLength="60" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-lg"></asp:TextBox>
                </div>
                <div class="input-group input-group-lg mb-2">
                    <div class="input-group-prepend">
                      <span class="input-group-text" id="inputGroup-sizing-lg"><img src="../assets/image/lock.svg"></span>
                    </div>
                    <asp:TextBox ID="tbSenha" class="form-control" placeholder="Coloque sua senha" runat="server" required="True" type="password" MaxLength="20" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-lg"></asp:TextBox>
                </div>
                <a href="recuperar-senha.html" target="_self" class="mb-4 d-block">Esqueceu a senha?</a>
                <asp:Button ID="btLogin" runat="server" Text="ACESSAR AGORA" class="btn btn-primary btn-lg btn-block mb-5"/> 
            </div>
        </div>
    </main>     
        </div>
          <footer class="footer">
        <div class="container d-flex flex-column flex-lg-row flex-xl-row flex-md-row flex-sm-column justify-content-center justify-content-xl-between justify-content-lg-between justify-content-md-between justify-content-sm-center align-content-center align-items-center">
            <div class="copyright pt-4 pb-2 py-md-4"><p class="m-0">Copyright © 2023, Lojas Torra. Todos os direitos reservados.</p></div>
            <div class="social-midia pt-2 pb-4 py-md-4">
                <a href="https://www.instagram.com/lojastorra/" target="_blank"><img src="../assets/image/instagram.svg"></a>
                <a href="https://pt-br.facebook.com/LojasTorra/" target="_blank"><img src="../assets/image/facebook.svg"></a>
                <a href="https://www.youtube.com/channel/UCmR9GomJR7Cs-PTipnDdseg" target="_blank"><img src="../assets/image/youtube.svg"></a>
                <a href="https://br.linkedin.com/company/lojastorra?original_referer=https%3A%2F%2Fwww.google.com%2F" target="_blank"><img src="../assets/image/linkedin.svg"></a>
            </div>
        </div>
    </footer>
        
        <asp:Label ID="labscript" runat="server" Text="" Visible="false"></asp:Label>
    </form>

     <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <script src="https://code.jquery.com/jquery-3.2.0.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/0.9.0/jquery.mask.min.js"></script>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.10.0/js/bootstrap-datepicker.min.js" integrity="sha512-LsnSViqQyaXpD4mBBdRYeP6sRwJiJveh2ZIbW41EBrNmKxgr/LFZIiWT6yr+nycvhvauz8c2nYMhrP80YhG7Cw==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <script src="https://www.lagoagrande.mg.gov.br/publicacoes/plugins/datepicker/locales/bootstrap-datepicker.pt-BR.js"></script>

    <script src="../assets/js/script.js"></script>
</body>
</html>


