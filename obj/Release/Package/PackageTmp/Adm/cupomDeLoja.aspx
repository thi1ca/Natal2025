<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="cupomDeLoja.aspx.vb" Inherits="Natal_torra.cupomDeLoja" %>
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
     <link rel="stylesheet" href="https://cdn.rawgit.com/tonystar/bootstrap-float-label/v4.0.2/bootstrap-float-label.min.css"/>
     <link href="https://cdn.jsdelivr.net/npm/sweetalert2@11.10.6/dist/sweetalert2.min.css" rel="stylesheet">
     <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11.10.6/dist/sweetalert2.all.min.js"></script>

</head>
<body class="padding-bottom pilot-project">
    <form id="form1" runat="server" class="form-projP">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <main role="main" class="login">
        <section class="top-banner vh-100 h-remove">
            <div class="container py-4 py-md-5 h-100 h-remove">
                <div class="row  h-100 h-remove d-flex justify-content-center align-items-center">
                    <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 text-left h-100 h-remove flex-column d-flex justify-content-center align-items-center order-2 order-md-1 mt-3 mt-md-0">
                        <img src="../assets/image/adm/Logo_pomocao_natal_Torra.png" alt="Raspe & Ganhe" class="mb-4 mb-md-5 w-50 d-none d-sm-block">
                        <p class="text-gray pb-3">Preencha os campos abaixo para simular uma compra em loja física.</br></br> A partir daí, você terá direito a uma Número da Sorte a cada R$50,00 para testar nossa Promoção de Natal Torra. E se seu cupom for gerado com Cartão Torra, os números da sorte triplicam!!!</br></br>O seu teste deve ser feito pelo <b>celular</b>, através do link que será mostrado em seguida.</p>

                        <span class="has-float-label mb-3 in-cpf">
                            <label for="cpf" class="floatlabel color1">Informe seu CPF</label>
                            <asp:TextBox ID="tbCPF" runat="server" class="form-control form-control-lg cpf" inputmode="numeric" type="text" name="cpf" placeholder="CPF"></asp:TextBox>
                        </span>
                        <span class="has-float-label mb-3 in-cpf">
                            <div class="input-group select-mist">
                                <asp:DropDownList ID="ddlLoja" runat="server" class="custom-select" aria-label="Selecione a loja"></asp:DropDownList>
                                <label for="ddlLoja">Loja que comrpou</label>
                                <div class="input-group-append">
                                <button class="btn btn-outline-secondary" type="button"><img src="../assets/image/arrow-down.svg" alt="" class="w-75"></button>
                                </div>
                            </div>
                        </span>
                        <asp:Button ID="butCadastrar" runat="server" Text="GERAR CUPOM DE LOJA" class="btn btn-primary bt-save text-uppercase mt-3 btn-md"></asp:Button>
                    </div>
                    <div class="col-12 col-sm-12 col-md-8 col-lg-8 col-xl-8 order-1 order-md-2 text-center" >
                        <img src="../assets/image/adm/Logo_pomocao_natal_Torra.png" alt="Raspe & Ganhe" class="w-35 d-flex d-sm-none m-auto">
                        <figure class="flex-column d-flex justify-content-center align-items-center mt-3">
                            <img src="../assets/image/adm/carro-byd-dolphin-mini.png" alt="Raspe & Ganhe" class="w-auto with-mobile">
                            <!-- <img src="../assets/image/raspe-ganhe-box-02.png" alt="Raspe & Ganhe"  class="w-auto with-mobile"> -->
                        </figure>
                    </div>
                </div>
            </div>
        </section>
        <section class="py-5" style="background: #d7cfcb;">
            <div class="container">
                <div class="row  h-100 h-remove d-flex justify-content-center align-items-center">
                    <div class="col-12 col-sm-12 col-md-5 col-lg-5 col-xl-5">
                        <img src="../assets/image/adm/como-funciona.png" alt="" class="w-100">
                    </div>
                    <div class="col-12 col-sm-12 col-md-7 col-lg-7 col-xl-7 pl-3 pr-3 pl-md-5 pr-md-5">
                        <h3 class="text-beige font-weight-light pb-2 text-center text-md-left">Vamos dar <strong class="text-beige font-weight-bold d-block d-md-inline">um exemplo</strong></h3>
                        <p class="text-gray">Se seu cupom for gerado com <strong>valor de R$125,00</strong> com qualquer forma de pagamento, com exceção do Cartão Torra, você terá direito a <strong>2 números da sorte</strong>. Mas se esse mesmo cupom gerar esse mesmo valor, porém com Cartão Torra, você terá direito a <strong>6 números da sorte.</strong></p>

                        <p class="text-gray">No final, iremos fazer um sorteio com todos os participantes da empresa, e o sortudo que for contemplado, irá <strong>ganhar um voucher de R$150,00</strong> para comprar em nossa loja virtual.</p>
                    </div>
                </div>
            </div>
        </section>
        <section id="results" class="result-pp bg-beige">
            <div class="container py-3 py-md-5">
                <div class="row no-gutters">
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center flex-column d-flex justify-content-center align-items-center">
                        <h3 class="text-white font-weight-light pb-2">Você ganhou seu <strong class="text-red font-weight-bold d-block d-md-inline">Número da Sorte</strong></h3>
                        <p class="text-white pb-4">Utilize seu CPF para entrar na Promoção de Natal Torra. Siga as instruções no <br class="d-none d-md-block">aplicativo para testar sua sorte.
                    </div>
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 pb-3 pb-md-5 mb-4 text-center">
                        <div class="PaperImpress">
                            <div class="sup"></div>
                            <div class="inf"></div>
                            <div class="paper py-3 py-md-4">
                                <div class="txt-paper" id="divQRCode" runat="server">
                                    <img src="../assets/image/Lojas-torra-impresso.png" alt="Lojas Torra">
                                    <p class="font-weight-bold m-0 pt-4">CPF</p>
                                    <h6 class="pb-3 h3 font-weight-bold"><% =varCPF%></h6>
    
                                    <p class="m-0"><strong>Data da compra:</strong> <% =varData%></p>
                                    <p class="m-0"><strong>Loja comprada:</strong> <% =varLoja%></p>
                                    <p class="m-0"><strong>Valor:</strong> <% =varPreco%></p>
                                    <p class="m-0"><strong>Forma de Pagamento:</strong> <% =varFormaPG%></p>
                                    <p class="m-0"><strong>Qtd Números da sorte:</strong> <% =varQtdNumeros%></p>
                                    <div class="row no-gutters pb-3 pt-2 pt-md-4 d-flex justify-content-center align-items-center">
                                        <div class="col-4 col-sm-4 col-md-4 col-lg-4 col-xl-4 pl-2 text-center">
                                            <a href="https://nataltorra2024.lojastorra.com.br/"><img src="assets/image/qr-code-promo-natal_final.png" class="w-100"/></a>
                                        </div>
                                        <div class="col-8 col-sm-8 col-md-8 col-lg-8 col-xl-8 text-left pl-3">
                                            <small>Escaneie o qrcode e acesse nosso APP para usar seu número</small>
                                            <a href="https://nataltorra2024.lojastorra.com.br/" target="_blank">nataltorra2024.lojastorra.com.br</a>
                                        </div>
                                    </div>
                                </div>
                                <asp:TextBox ID="tbFicha" runat="server"  Enabled="False" Text="0"></asp:TextBox>
                            </div>
                            
                            <small class="text-white font-weight-bold pt-4">*Não se esqueça da loja selecionada aqui, no APP<br> você precisará dessa informação.</small>
                        </div>
                    </div>
                    
                </div>
            </div>    
        </section>
        <section  class="result-pp bg-red">
            <div class="container py-3 py-md-5">
                <div class="row no-gutters">
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center pb-2 pb-sm-2 pb-md-4 h-100 flex-column d-flex justify-content-center align-items-center">
                        <h3 class="text-white font-weight-light pb-2 pb-mb-4">Baixe agora o <strong class="font-weight-bold d-block d-md-inline">APP Loja Torra</strong></h3>
                    </div>
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center h-100  d-flex flex-row flex-sm-row flex-md-row  justify-content-center align-items-center">
                        <a href="https://app.lojastorra.com.br/Jsk9/v5jrja93" class="mx-2 mx-md-3 my-2"><img src="../assets/image/app_store.png" alt="Dispinível na App Store" class="w-100"></a>
                        <a href="https://app.lojastorra.com.br/Jsk9/v5jrja93" class="mx-2 mx-md-3 my-2"><img src="../assets/image/app_google_play.png" alt="Dispinível no Google Play" class="w-100"></a>
                    </div>
                </div>
            </div>
        </section>
       
    </main>

         </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="butCadastrar" />
        </Triggers>
     </asp:UpdatePanel>
       
          <footer class="footer footer-pp">
        <div class="container d-flex flex-column flex-lg-row flex-xl-row flex-md-row flex-sm-column justify-content-center justify-content-xl-between justify-content-lg-between justify-content-md-between justify-content-sm-center align-content-center align-items-center">
            <div class="copyright pt-2 pb-2 py-md-2"><p class="m-0"><a href="https://www.lojastorra.com.br/" target="_blank"><img src="../assets/image/torra-rodape.png" alt="Lojas Torra"></a></p></div>
            <div class="copyright pt-2 pb-2 py-md-2"><p class="m-0">Magazine Torra Torra LTDA | CNPJ: 22.685.030/0001-11</p></div>
            <div class="social-midia pt-2 pb-2 py-md-2">
                <a href="https://www.instagram.com/lojastorra/" target="_blank"><img src="../assets/image/instagram.svg"></a>
                <a href="https://pt-br.facebook.com/LojasTorra/" target="_blank"><img src="../assets/image/facebook.svg"></a>
                <a href="https://www.youtube.com/channel/UCmR9GomJR7Cs-PTipnDdseg" target="_blank"><img src="../assets/image/youtube.svg"></a>
                <a href="https://br.linkedin.com/company/lojastorra?original_referer=https%3A%2F%2Fwww.google.com%2F" target="_blank"><img src="../assets/image/linkedin.svg"></a>
            </div>
        </div>
    </footer>
    <!-- Modal -->
    <div class="modal fade" id="ModalAlertCenter" tabindex="-1" role="dialog" aria-labelledby="ModalAlertCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
        <div class="modal-content">
            <div class="modal-header">
            <h5 class="modal-title" id="exampleModalLongTitle">Modal title</h5>
            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                <span aria-hidden="true">&times;</span>
            </button>
            </div>
            <div class="modal-body">
            ...
            </div>
            <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
            <button type="button" class="btn btn-primary">Save changes</button>
            </div>
        </div>
        </div>
    </div>

        <asp:Label ID="labscript" runat="server" Text=""></asp:Label>
         <asp:Label ID="labMin" runat="server" Text=""></asp:Label>
    </form>

   <!-- Optional JavaScript -->
    <!-- jQuery first, then Popper.js, then Bootstrap JS -->
    <script src="https://code.jquery.com/jquery-3.3.1.slim.min.js" integrity="sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js" integrity="sha384-UO2eT0CpHqdSJQ6hJty5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1" crossorigin="anonymous"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js" integrity="sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM" crossorigin="anonymous"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery.mask/0.9.0/jquery.mask.min.js"></script>

    <script src="https://cdn.jsdelivr.net/npm/jquery-validation@1.19.5/dist/jquery.validate.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/jquery-validation@1.19.5/dist/additional-methods.js"></script>

    <script src="../assets/js/scriptAdm.js"></script>
    <script src="../assets/js/confetti.min.js"></script>
    
</body>
</html>
