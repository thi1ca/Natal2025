<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="_bkp_forgotPassword.aspx.vb" Inherits="Torra.forgotPassword" %>


<!doctype html>
<html lang="en">
  <head>
    <title>Raspe & Ganhe - Login</title>
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
            <form class="pt-5 mx-auto" action="changePassword.aspx" id="form_recuperar">
                <div class="row no-gutters">
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 mb-4">
                        <h3 class="text-white text-center">
                            <strong>Recupere</strong> sua Senha</h3>
                    </div>
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12">
                        <div class="form-group stap select-cpf">
                            <div class="icon mb-3 d-flex align-items-center">
                                <i class="d-flex align-items-center justify-content-center"><img src="assets/image/stap-01.svg" alt=""></i>
                                <div class="pl-2">
                                    <h5 class="mb-0">Passo 1</h5>
                                    <strong>Documentos de Identificação</strong>
                                </div>
                            </div>
                            <span class="has-float-label mb-2 inser-cpf">
                                <label for="cpf" class="floatlabel color2">Informe seu CPF</label>
                                <input class="form-control form-control-lg cpf" type="text" id="cpf" name="cpf" inputmode="numeric" placeholder="CPF" minlength="14" required>
                            </span>
                        </div>
                        <div class="form-group stap select-opt">
                            <div class="icon mb-2 d-flex align-items-center">
                                <i class="d-flex align-items-center justify-content-center"><img src="assets/image/stap-02.svg" alt=""></i>
                                <div class="pl-2">
                                    <h5 class="mb-0">Passo 2</h5>
                                    <strong>Selecione uma opção para recuperar a senha:</strong>
                                </div>
                            </div>
                            <span class="warp-label">
                                <div class="custom-control custom-radio custom-control-inline form-check input-group-lg my-0">
                                    <input class="form-check-input custom-control-input" type="radio" name="customRadioInline" id="selectphone" value="Telefone" required>
                                    <label class="custom-control-label mask-phone form-check-label ml-1" for="selectphone">
                                      Telefone: <span>15981744017</span><span></span>
                                    </label>
                                </div>
                                <div class="custom-control custom-radio custom-control-inline form-check input-group-lg my-0">
                                    <input class="form-check-input custom-control-input" type="radio" name="customRadioInline" id="selectemail" value="E-mail" required>
                                    <label class="custom-control-label mask-email form-check-label ml-1" for="selectemail">
                                      E-mail: <span>marcelo.costa@lojastorra.com.br</span><span></span><i>lojastorra.com.br</i><i></i>
                                    </label>
                                </div>
                            </span>
                        </div>
                        <div class="form-group stap">
                            <div class="icon mb-2 d-flex align-items-center">
                                <i class="d-flex align-items-center justify-content-center"><img src="assets/image/stap-03.svg" alt=""></i>
                                <div class="pl-2">
                                    <h5 class="mb-0">Passo 3</h5>
                                    <strong>Insira o código para validação</strong>
                                </div>
                            </div>
                            <span class="has-float-label remove">
                                <div class="container-fluid no-gutters position-relative z-index-10">
                                    <div class="row">
                                        <div class="col-2 px-1 px-sm-2 px-md-2 px-lx-2 box-number">
                                            <div class="input-number input-group input-group-lg mb-3">
                                                <input type="text" class="form-control py-2 number" inputmode="numeric" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-lg" maxlength="1" name="numbervalid1" required>
                                            </div>
                                        </div>
                                        <div class="col-2 px-1 px-sm-2 px-md-2 px-lx-2 box-number">
                                            <div class="input-number input-group input-group-lg mb-3">
                                                <input type="text" class="form-control py-2 number" inputmode="numeric" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-lg" maxlength="1" name="numbervalid2" required>
                                            </div>
                                        </div>
                                        <div class="col-2 px-1 px-sm-2 px-md-2 px-lx-2 box-number">
                                            <div class="input-number input-group input-group-lg mb-3">
                                                <input type="text" class="form-control py-2 number" inputmode="numeric" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-lg" maxlength="1" name="numbervalid3" required>
                                            </div>
                                        </div>
                                        <div class="col-2 px-1 px-sm-2 px-md-2 px-lx-2 box-number">
                                            <div class="input-number input-group input-group-lg mb-3">
                                                <input type="text" class="form-control py-2 number" inputmode="numeric" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-lg" maxlength="1" name="numbervalid4" required>
                                            </div>
                                        </div>
                                        <div class="col-2 px-1 px-sm-2 px-md-2 px-lx-2 box-number">
                                            <div class="input-number input-group input-group-lg mb-3">
                                                <input type="text" class="form-control py-2 number" inputmode="numeric" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-lg" maxlength="1" name="numbervalid5" required>
                                            </div>
                                        </div>
                                        <div class="col-2 px-1 px-sm-2 px-md-2 px-lx-2 box-number">
                                            <div class="input-number input-group input-group-lg mb-3">
                                                <input type="text" class="form-control py-2 number" inputmode="numeric" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-lg" maxlength="1" name="numbervalid6" required>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </span>
                        </div>
                        <button type="submit" class="btn btn-primary bt-step btn-lg btn-block mt-4">PROXÍMO PASSO</button>
                    </div>

                    <a class="btn-lg btn-block voltar-login text-white text-center mt-4 mb-4" href="index.aspx" role="button"><img src="assets/image/arrow-left.svg" alt=""> VOLTAR AO LOGIN</a>
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
