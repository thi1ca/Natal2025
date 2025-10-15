<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/comMenu.Master" CodeBehind="apply-coupon.aspx.vb" Inherits="Torra.apply_coupon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container py-0 px-0 flex-column d-flex justify-content-center">
        <div class="row no-gutters">
            <div class="col-4 col-sm-4 col-md-4 col-lg-4 col-xl-4">
                <img src="assets/image/Mobile.png" alt="Mobile" class="w-100">
            </div>
            <div class="col-8 col-sm-8 col-md-8 col-lg-8 col-xl-8 pr-4 pl-3 pt-3 passo-passo d-flex flex-column justify-content-around">
                <h3 class="text-blue text-left"><strong>Passo a passo</strong><br>para aplicar o seu Código de Desconto</h3>
                <p>Entre no site ou APP Lojas Torra;</p>
                <p>Navegue e coloque no<img src="assets/image/cart.svg" alt="Icone carrinho">os produtos desejados;</p>
                <p>Após escolher todas as peças, clique no carrinho no canto superior direito;</p>
                <p>Clique em <i class="text-white font-weight-bold">Fechar Pedido</i> e informe os dados solicitados;</p>
            </div>
            <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 pr-4 pl-4 pt-4 passo-passo">     
                <p>Na tela de <strong>Pagamentos</strong>, insira o seu Código de Desconto na área <strong>Vale Troca</strong>;</p>         
                <p>Clique em <i class="text-blue font-weight-bold">Confirmar</i> e <i class="text-white font-weight-bold">Avançar</i>;</p>
                <p>Finalize a sua compra com o seu Desconto Premiado.</p>
            </div>
        </div>
    </div>
    <div class="container pt-3 flex-column d-flex justify-content-center">
        <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 condicoes">
            <div class="card mb-2 p-4 text-blue">
                <h2 class="m-0 text-orange pb-2">Condições Raspe & Ganhe</h2>
                <ul class="m-0 p-0 text-blue">
                    <li>* Oferta válida apenas para o site ou APP Lojas Torra;</li>
                    <li>* Validade do desconto informado na sua raspadinha;</li>
                    <li>* Válido até 31/01/2025.</li>
                </ul>
            </div>
        </div>
        <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 mt-4 d-flex flex-column ganhadores">
            <!-- <h3 class="text-blue text-center py-4"><strong>Conheça alguns</strong> ganhadores</h3> -->
            <a href="winners.aspx" class="btn btn-primary btn-lg btn-block" role="button">CONHEÇA ALGUNS GANHADORES</a>
            
        </div>
        <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 py-4">
            <p class="small">Informamos que a Lojas Torra disponibiliza aos seus clientes cupons de desconto através da página (https://raspeeganhe.lojastorra.com.br) para que possam utilizar em suas compras exclusivamente no site. Ressaltamos que os cupons não são cumulativos com outras eventuais promoções disponíveis de acordo com o período de campanhas específicas já divulgadas. Alertamos que os cupons de descontos para serem usados no nosso site são apenas os divulgados pela Lojas Torra, não possuímos parceria com terceiros</p>
        </div>
    </div>

</asp:Content>
