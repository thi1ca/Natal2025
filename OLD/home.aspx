<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/comMenu.Master" CodeBehind="home.aspx.vb" Inherits="Torra.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row no-gutters">
                <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 mb-4">
                    <h3 class="text-blue text-center">
                        Meus <strong>bilhetes</strong> </h3>
                </div>
                <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 mb-0 filter-ticket">
                    <div class="d-flex justify-content-between filter">
                        <button class="btn btn-primary active" type="button" data-toggle="collapse" data-target="#disponivel" aria-expanded="false" aria-controls="disponivel">Disponível</button>
                        <button class="btn btn-primary" type="button" data-toggle="collapse" data-target="#raspados" aria-expanded="false" aria-controls="raspados">Raspados</button>
                        <button class="btn btn-primary" type="button" data-toggle="collapse" data-target="#premiados" aria-expanded="false" aria-controls="premiados">Premiados</button>
                    </div>
                </div>
                <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12">
                    <div class="row no-gutters content-filter list-box">
                        <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 pt-4">

                            <div class="collapse show" id="disponivel">
                                <div id="divVazio1" runat="server">
                                    <div class="erro-busca text-center my-5" id="divPremiado1" runat="server">
                                        <img src="assets/image/ticket-erro.png" alt="Não Encontrado">
                                        <h4>Você ainda não possui <strong>bilhetes disponíveis</strong></h4>

                                        <a class="btn btn-primary bt-inline btn-lg btn-block mt-4" href="winners.aspx" role="button">CONHEÇA OS GANHADORES</a>
                                    </div>
                                </div>
                                <asp:repeater id="Repeater1" runat="server" >
                                    <ItemTemplate>
                                        <div class="card mb-3 text-white" style="background-image: url(assets/image/background-raspadinha.png);">
                                            <a href="scratch.aspx?cupId=<%# Container.DataItem("cup_id") %>">
                                                <div class="row no-gutters">
                                                    <div class="col-4 d-flex justify-content-center align-items-center">
                                                        <img src="assets/image/logo-Raspe&Ganhe.svg" alt="Raspe & Ganhe" class="w-75">
                                                    </div>
                                                    <div class="col-8 text-right">
                                                        <div class="card-body">
                                                            <strong><%# Container.DataItem("cam_nome") %></strong>
                                                            <h5>Lojas Torra - <%# Container.DataItem("loj_nome") %></h5>
                                                            <p><strong>Validade: </strong><small><%# Convert.ToDateTime(Container.DataItem("cam_prazo")).ToString("dd/MM/yyyy")  %></small></p>
                                                        </div>
                                                    </div>
                                                </div>
                                            </a>
                                        </div>
                                    </ItemTemplate>
                                </asp:repeater>
                            </div>

                            
                            <div class="collapse" id="raspados">
                                <div id="divVazio2" runat="server">
                                    <div class="erro-busca text-center my-5" id="divPremiado2" runat="server">
                                        <img src="assets/image/ticket-erro.png" alt="Não Encontrado">
                                        <h4>Você ainda não possui <strong>bilhetes raspados</strong></h4>

                                        <a class="btn btn-primary bt-inline btn-lg btn-block mt-4" href="winners.aspx" role="button">CONHEÇA OS GANHADORES</a>
                                    </div>
                                </div>
                                <asp:repeater id="Repeater2" runat="server" >
                                    <ItemTemplate>
                                        <div class="card mb-3 text-white" style="background-image: url(assets/image/bg-card-raspado.png);">
                                            
                                                <div class="row no-gutters">
                                                    <div class="col-4 d-flex justify-content-center align-items-center">
                                                        <img src="assets/image/logo-Raspe&Ganhe.svg" alt="Raspe & Ganhe" class="w-75">
                                                    </div>
                                                    <div class="col-8 text-right">
                                                        <div class="card-body">
                                                            <strong>Raspadinha</strong>
                                                            <h5>Campanha compre mais</h5>
                                                            <p><strong>Validade: </strong><small>24/10/2024</small></p>
                                                        </div>
                                                    </div>
                                                </div>
                                            
                                        </div>
                                    </ItemTemplate>
                                </asp:repeater>
                            </div>
                            <div class="collapse" id="premiados">
                                <div id="divVazio3" runat="server">
                                    <div class="erro-busca text-center my-5" id="divPremiado3" runat="server">
                                        <img src="assets/image/ticket-erro.png" alt="Não Encontrado">
                                        <h4>Você ainda não possui <strong>bilhetes premiados</strong></h4>
    
                                        <a class="btn btn-primary bt-inline btn-lg btn-block mt-4" href="winners.aspx" role="button">CONHEÇA OS GANHADORES</a>
                                    </div>
                                </div>
                            
                                <asp:repeater id="Repeater3" runat="server" >
                                    <ItemTemplate>
                                        <div class="card mb-3 text-white" style="background-image: url(assets/image/background-raspadinha.png);">
                                            <div class="row no-gutters">
                                                <div class="col-4 d-flex justify-content-center align-items-center">
                                                    <img src="assets/image/logo-Raspe&Ganhe.svg" alt="Raspe & Ganhe" class="w-75">
                                                </div>
                                                <div class="col-8 text-right">
                                                    <div class="card-body">
                                                        <strong>BILHETE PREMIADO</strong>
                                                        <h5>Voucher: <%# Container.DataItem("pre_voucher_codigo") %></h5>
                                                        <p><strong>Raspado: </strong><small><%# Container.DataItem("ras_data")  %></small></p>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>                                             
                                    </ItemTemplate>
                                </asp:repeater>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
</asp:Content>
