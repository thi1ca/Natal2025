<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/comMenu.Master" CodeBehind="home.aspx.vb" Inherits="Natal_torra.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <div class="row no-gutters camp-natal">
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 box-ganha natal position-relative">
                        <img src="assets/image/img_carro.png" alt="Carro BYD Premiação Torra">
                        <h3 class="text-beige pt-4 pb-3 text-center">
                            <span class="text-white d-block mb-2">Carro BYD Dolphin Mini</span>
                            Data do Sorteio <br><strong class="text-red">13/01/2025</strong><br>
                            <!-- <span class="text-white">A cada 50 reais em compras,<br>
                                você ganha 1 número da sorte!</span> -->
                        </h3>
                    </div>
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 pt-3 pb-5">
                        <div class="row no-gutters content-filter list-box">

                            <!-- Coloca a div vazio aqui-->
                            <div id="divVazio" runat="server">
                                Não foi encontrado números da sorte
                            </div>
                             <!-- Fim da div vazio -->

                            <!-- Coloca o Repeater aqui-->
                              <asp:repeater id="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                                    <ItemTemplate>
                            <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 pt-2 box-bilhete">
                                <div class="erro-busca text-center" id="div1" runat="server">
                                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-left p-0 d-flex justify-content-between">
                                        <h3 class="text-blue text-left"><strong><%# Convert.ToDateTime(Container.DataItem("cup_cupom_data")).ToString("dd/MM/yyyy")  %></strong> - Loja <%# Container.DataItem("loj_nome") %> </h3><span>R$ <%# Container.DataItem("cup_valor") %></span>
                                    </div>
                                </div>
                                 <asp:repeater id="Repeater2" runat="server" >
                                    <ItemTemplate>
                                <div class="card mb-2 text-white">
                                    <a>
                                        <div class="row no-gutters">
                                            <div class="col-6 d-flex justify-content-center align-items-center">
                                                <img src="assets/image/star_natal.svg" alt="Seu número da Sorte Torra">
                                                <p class="text-beige">Seu número<br>da <strong>Sorte Torra</strong></p>
                                            </div>
                                            <div class="col-6 text-right code-natal">
                                                <div class="card-body">
                                                    <h5> <%# FuncFormata(Container.DataItem("sor_numero")) %></h5>
                                                </div>
                                            </div>
                                        </div>
                                    </a>
                                </div>
                                         </ItemTemplate>
                              </asp:repeater>                              
                            </div>
                                     </ItemTemplate>
                              </asp:repeater>
                            <!-- Fim do repeater -->

                        </div>
                    </div>
                </div>
</asp:Content>
