<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Adm/admLogado.Master" CodeBehind="cupomDeLojaReal.aspx.vb" Inherits="Natal2025.cupomDeLojaReal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    <main role="main" class="login create-page">
        <section class="top-banner vh-100 h-remove">
            <div class="container py-4 py-md-5 h-100 h-remove">
                <div class="row h-remove d-flex justify-content-center align-items-center">
                    <div class="col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 text-left h-100 h-remove flex-column d-flex justify-content-center align-items-center order-2 order-md-1 mt-3 mt-md-0">
                        <div class="row no-gutters">
                            <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-center d-flex flex-column justify-content-center align-items-center">
                                <img src="../assets/image/adm/Logo_pomocao_natal_Torra.png" alt="Raspe & Ganhe" class="mb-3 mb-md-4 w-25 d-none d-sm-block">
                                <p class="text-gray pb-3 pl-0 pr-0 pl-md-5 pr-md-5">Preencha os campos abaixo para cadastrar uma compra de loja física com CPF do cliente.</br>Esse processo será auditável!!!</p>
                            </div>
                            <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 form-group">
                                <span class="has-float-label mb-3 in-cpf w-100">
                                    <label for="cpf" class="floatlabel color1">CPF do Cliente</label>
                                    <asp:TextBox ID="tbCPF" runat="server" class="form-control form-control-lg cpf" inputmode="numeric" type="text" name="cpf" placeholder="CPF"></asp:TextBox>
                                </span>
                            </div>
                            <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 form-group">
                                <span class="has-float-label mb-3 w-100">
                                    <div class="input-group select-mist">
                                        <asp:DropDownList ID="ddlLoja" runat="server" class="custom-select" aria-label="Selecione a loja"></asp:DropDownList>
                                        <label for="ddlLoja" class="select-stor">Loja que comprou</label>
                                        <div class="input-group-append">
                                        <button class="btn btn-outline-secondary" type="button"><img src="../assets/image/arrow-down.svg" alt="" class="w-75"></button>
                                        </div>
                                    </div>
                                </span>
                            </div>
                            <div class="col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 form-group dates pr-0 pr-md-2">
                                <span class="has-float-label mb-3 w-100">
                                    <label for="date" class="floatlabel">Data da compra</label>
                                    <div class="start_date input-group">
                                        <asp:TextBox ID="tbData" runat="server" class="form-control start_date data" inputmode="numeric" type="text" name="data" placeholder="Data e hora" MaxLength="10"></asp:TextBox>
                                        <div class="input-group-append">
                                            <span class="fa fa-calendar input-group-text start_date_calendar" aria-hidden="true "><img src="../assets/image/date-fill.svg" alt=""></span>
                                        </div>
                                    </div>
                                </span>
                            </div>
                            <div class="col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 p-0 form-group pl-0 pl-md-2">
                                <span class="has-float-label input-money mb-3 w-100">
                                    <label for="money" class="floatlabel color1">Valor</label>
                                    <asp:TextBox ID="tbValor" runat="server" class="form-control form-control-lg money" inputmode="numeric" type="text" name="valor" placeholder="00,00"></asp:TextBox>
                                </span>
                            </div>
                            <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 form-group">
                                <span class="has-float-label mb-3 w-100">
                                    <label for="Cupom" class="floatlabel color1">Cupom</label>
                                    <asp:TextBox ID="tbCupom" runat="server" class="form-control form-control-lg" inputmode="numeric" type="text" name="cupom" placeholder="cupom"></asp:TextBox>
                                </span>
                            </div>
                            <div class="col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 form-group dates pr-0 pr-md-2">
                                <span class="has-float-label mb-3 w-100">
                                    <label for="Cupom" class="floatlabel color1">PDV</label>
                                    <asp:TextBox ID="tbPDV" runat="server" class="form-control form-control-lg" inputmode="numeric" type="text" name="pdv" placeholder="pdv"></asp:TextBox>
                                </span>
                            </div>
                            <div class="col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 p-0 form-group pl-0 pl-md-2">
                                <div class="custom-control custom-switch custom-switch-md mt-2">
                                    <asp:CheckBox ID="cbTACC" runat="server" class="custom-control-input" data-size="lg"/>
                                    <label class="custom-control-label" for="ContentPlaceHolder1_cbTACC">Compra com Cartão Torra</label>
                                </div>
                            </div>
                            <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 form-group">
                                <asp:Button ID="butCadastrar" runat="server" Text="GERAR CUPOM DE LOJA" class="btn bt-save w-100 text-uppercase mt-3 btn-md"></asp:Button>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 order-1 order-md-2 text-center" >
                                <img src="../assets/image/adm/Logo_pomocao_natal_Torra.png" alt="Raspe & Ganhe" class="w-35 d-flex d-sm-none m-auto">
                                <figure class="flex-column d-flex justify-content-center align-items-center mt-3 pl-0 pl-md-5">
                                    <img src="../assets/image/adm/carro-byd-dolphin-mini.png" alt="Raspe & Ganhe" class="w-100 with-mobile">
                                    <!-- <img src="../assets/image/raspe-ganhe-box-02.png" alt="Raspe & Ganhe"  class="w-auto with-mobile"> -->
                                </figure>
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
        
       
    </main>

         </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="butCadastrar" />
        </Triggers>
     </asp:UpdatePanel>
       
      
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
  <script src="../assets/js/scriptAdm.js"></script>
    <script src="../assets/js/confetti.min.js"></script>
</asp:Content>
