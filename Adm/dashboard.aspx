<%@ Page Title="Lojas Torra - Dashboard" Language="vb" AutoEventWireup="false" MasterPageFile="~/Adm/admLogado.Master" CodeBehind="dashboard.aspx.vb" Inherits="Natal2025.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="login container mb-5">
        <div class="container d-flex flex-column justify-content-center text-center pb-5">
            <div class="row mt-3 mt-md-5">
                <div class="col-12 col-sm-12 col-md-12 col-xl-12 text-left">
                    <h6>Seja bem vindo(a),</h6>
                    <h3 class="text-gray"><asp:Label ID="labNome" runat="server" Text=""></asp:Label></h3>
                </div>
            </div>
            <div class="row my-3 my-md-5">
               
               
              
                <div class="col-6 col-sm-6 col-md-6 col-xl-3 col-lg-3 px-1 px-md-3">
                    <a href="winner.aspx" class="icon-dash">
                        <div class="card text-white mb-2 mb-md-3 text-left">
                            <div class="card-body d-flex">
                                <img src="../assets/image/send.svg" alt="">
                                <h5 class="card-title">Procurar <strong class="d-block">Vencedor</strong></h5>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="col-6 col-sm-6 col-md-6 col-xl-3 col-lg-3 px-1 px-md-3">
                    <a href="admClients.aspx" class="icon-dash">
                        <div class="card text-white mb-2 mb-md-3 text-left">
                            <div class="card-body d-flex">
                                <img src="../assets/image/avatar-wt.svg" alt="">
                                <h5 class="card-title">Administrar <strong class="d-block">Clientes</strong></h5>
                            </div>
                        </div>
                    </a>
                </div>
                <div class="col-6 col-sm-6 col-md-6 col-xl-3 col-lg-3 px-1 px-md-3">
                    <a href="admUsers.aspx" class="icon-dash">
                        <div class="card text-white mb-2 mb-md-3 text-left">
                            <div class="card-body d-flex">
                                <img src="../assets/image/people-new.svg" alt="">
                                <h5 class="card-title">Administrar <strong class="d-block">Usuários</strong></h5>
                            </div>
                        </div>
                    </a>
                </div>
                  <div class="col-6 col-sm-6 col-md-6 col-xl-3 col-lg-3 px-1 px-md-3">
                    <a href="admWhatsapp.aspx" class="icon-dash">
                        <div class="card text-white mb-2 mb-md-3 text-left">
                            <div class="card-body d-flex">
                                <img src="../assets/image/people-new.svg" alt="">
                                <h5 class="card-title">Status <strong class="d-block">Whatsapp</strong></h5>
                            </div>
                        </div>
                    </a>
                </div>

                  <div class="col-6 col-sm-6 col-md-6 col-xl-3 col-lg-3 px-1 px-md-3">
                    <a href="cupomdeloja.aspx" class="icon-dash">
                        <div class="card text-white mb-2 mb-md-3 text-left">
                            <div class="card-body d-flex">
                                <img src="../assets/image/people-new.svg" alt="">
                                <h5 class="card-title">Simular <strong class="d-block">Cupom de Loja</strong></h5>
                            </div>
                        </div>
                    </a>
                </div>

                  <div class="col-6 col-sm-6 col-md-6 col-xl-3 col-lg-3 px-1 px-md-3">
                    <a href="cupomdelojareal.aspx" class="icon-dash">
                        <div class="card text-white mb-2 mb-md-3 text-left">
                            <div class="card-body d-flex">
                                <img src="../assets/image/people-new.svg" alt="">
                                <h5 class="card-title">Cadastra Cupom de Cliente<strong class="d-block">sem CPF</strong></h5>
                            </div>
                        </div>
                    </a>
                </div>

                <div class="col-6 col-sm-6 col-md-6 col-xl-3 col-lg-3 px-1 px-md-3">
                    <a href="regularizaNumeroDaSorte.aspx" class="icon-dash">
                        <div class="card text-white mb-2 mb-md-3 text-left">
                            <div class="card-body d-flex">
                                <img src="../assets/image/send.svg" alt="">
                                <h5 class="card-title">Regulariza <strong class="d-block">Números da Sorte</strong></h5>
                            </div>
                        </div>
                    </a>
                </div>

                  <div class="col-6 col-sm-6 col-md-6 col-xl-3 col-lg-3 px-1 px-md-3">
                    <a href="excluicpf.aspx" class="icon-dash">
                        <div class="card text-white mb-2 mb-md-3 text-left">
                            <div class="card-body d-flex">
                                <img src="../assets/image/people-new.svg" alt="">
                                <h5 class="card-title">Exclui <strong class="d-block">CPF</strong></h5>
                            </div>
                        </div>
                    </a>
                </div>

                 <div class="col-6 col-sm-6 col-md-6 col-xl-3 col-lg-3 px-1 px-md-3">
                    <a href="simulaCliente.aspx" class="icon-dash">
                        <div class="card text-white mb-2 mb-md-3 text-left">
                            <div class="card-body d-flex">
                                <img src="../assets/image/people-new.svg" alt="">
                                <h5 class="card-title">Simula e Comunica <strong class="d-block">CLIENTE</strong></h5>
                            </div>
                        </div>
                    </a>
                </div>

                <div class="col-6 col-sm-6 col-md-6 col-xl-3 col-lg-3 px-1 px-md-3">
                    <a href="admGraphs.aspx" class="icon-dash">
                        <div class="card text-white mb-2 mb-md-3 text-left">
                            <div class="card-body d-flex">
                                <img src="../assets/image/chart-line.svg" alt="">
                                <h5 class="card-title">Info & <strong class="d-block">Estatísticas</strong></h5>
                            </div>
                        </div>
                    </a>
                </div>
            </div>
            
        </div>
    </main>
</asp:Content>
