<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/comMenu.Master" CodeBehind="receive-coupon.aspx.vb" Inherits="Natal2025.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container py-0 px-0  flex-column d-flex justify-content-center info-cupom">
        <div class="row px-3">
            <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 pt-0 pb-4 passo-passo"> 
                <h3 class="text-blue text-left "><strong>Como visualizar</strong><br>o seu Código de Desconto</h3>  
                <p class="pb-3">Acesse pela forma de sua preferência!</p>
                <div class="card mb-2 text-blue p-0 border-0">
                    <div class="row no-gutters">
                        <div class="col-2 d-flex justify-content-center align-items-start">
                            <img src="assets/image/whatsapp.svg" alt="Ganhador" class="w-65">
                        </div>
                        <div class="col-10 text-left">
                            <div class="card-body p-0">
                                <strong class="m-0">Whatsapp</strong>
                                <p class="m-0">Você receberá uma mensagem de Whatsapp da Lojas Torra com a informação do seu Código de desconto e a validade. </p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card mb-1 text-blue p-0 border-0">
                    <div class="row no-gutters">
                        <div class="col-2 d-flex justify-content-center align-items-start">
                            <img src="assets/image/email.svg" alt="Ganhador" class="w-50">
                        </div>
                        <div class="col-10 text-left">
                            <div class="card-body p-0">
                                <strong class="m-0">E-mail</strong>
                                <p class="m-0">Você também receberá um e-mail da Lojas Torra com o Código de Desconto e demais informações necessárias para aproveitar o seu prêmio. </p>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- <strong>Whatsapp</strong>         
                <p>Uma da opção de envio do código será via whatsapp para melhor ajuda-lo.</p>
                <strong>E-mail</strong>     
                <p>Para quem prefere receber no e-mail, também informamos o código facilitando.</p> -->
            </div>
            <div class="col-5 col-sm-5 col-md-5 col-lg-5 col-xl-5 d-flex align-items-center">
                <img src="assets/image/mobile-info.gif" alt="Mobile" class="w-100">
            </div>
            <div class="col-7 col-sm-7 col-md-7 col-lg-7 col-xl-7 pt-3 passo-passo text-left pl-0 pr-0">
                <h3 class="text-blue text-left">Encontre o seu Código<br><strong>no APP Lojas Torra</strong></h3>
                <p class="font-13">Abra o aplicativo Lojas Torra;</p>
                <p class="font-13">Clique em “Raspe&Ganhe” e faça seu login;</p>
                <p class="font-13">Na tela inicial clique na aba "Premiados";</p>
                <p class="font-13">Selecione o bilhete premiado e veja o seu Código de Desconto.</p>
            </div>
            <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 pt-3 passo-passo text-left">
                <p><small>Obs.: O Código de Desconto estará disponível em até 7 dias após o seu bilhete ter sido raspado.</small></p>
            </div>
        </div>
    </div>
    <div class="container pt-3 flex-column d-flex justify-content-center">
        <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 mt-4 d-flex flex-column ganhadores px-0">
            <!-- <h3 class="text-blue text-center py-4"><strong>Conheça alguns</strong> ganhadores</h3> -->
            <a href="winners.aspx" class="btn btn-primary btn-lg btn-block" role="button">CONHEÇA ALGUNS GANHADORES</a>
            
        </div>
        <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 py-4 px-0">
            <p class="small text-justify">A campanha Raspe&Ganhe da Lojas Torra é uma ação em que clientes que comprarem qualquer valor em uma das lojas físicas da Lojas Torra, irão receber um bilhete da sorte que será acessado pelo aplicativo da Lojas Torra. Ao criar a sua conta no Raspe&Ganhe, você terá acesso aos bilhetes que ainda poderão ser raspados, aos bilhetes que não foram premiados e também aos bilhetes que foram premiados e ainda estão disponíveis para uso...<a href="terms.aspx" class="link-leiamais">Leia mais</a></p>
        </div>
    </div>
</asp:Content>
