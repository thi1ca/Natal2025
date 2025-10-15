<%@ Page Title="" Language="vb" Async="true"  AutoEventWireup="false" MasterPageFile="~/Adm/admLogado.Master" CodeBehind="admWhatsapp.aspx.vb" Inherits="Natal_torra.admWhatsapp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <main role="main" class="container mb-5">
                <section  class="mb-3 mb-md-5">
                    <div class="row mt-3 mt-md-5 align-items-center">
                        <div class="col-8 col-sm-8 col-md-6 col-lg-6 col-xl-6 text-left text-sm-left text-md-left text-lg-left text-xl-left">
                            <nav aria-label="breadcrumb">
                                <ol class="breadcrumb p-0 ">
                                    <li class="breadcrumb-item"><a href="dashboard.aspx">Dashboard</a></li>
                                    <li class="breadcrumb-item active" aria-current="page">Verifica Chips de Whatsapp</li>
                                </ol>
                            </nav>
                        </div>

                </section>

                <div class="modal" id="modalCadastra" tabindex="-1" aria-labelledby="modalCadastraLabel" aria-hidden="true">
                    <div class="modal-dialog modal-xl modal-dialog-centered">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title">Nova Data Manual</h5>
                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                    <span aria-hidden="true">&times;</span>
                                </button>
                            </div>
                            <div class="modal-body">
                                <section class="create-page">
                                    <div class="formSetup" id="divFormulario" runat="server">
                                        <div class="row no-gutters">
                                            <div class="col-12 form-group">
                                                <span class="has-float-label">
                                                    <label for="nome" class="floatlabel">Nome da Campanha</label>
                                                    <asp:TextBox ID="tbCampanha" runat="server" class="form-control form-control-lg mb-3" type="text" MaxLength="100"></asp:TextBox>
                                                </span>
                                            </div>
                                            <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 form-group">
                                                <div class="dates d-md-flex mb-3 has-float-label">
                                                    <div class="input-group">
                                                        <asp:TextBox ID="tbDataInicio" runat="server" class="form-control form-control-lg start_date" placeholder="dd/mm/aaaa" MaxLength="12"></asp:TextBox>
                                                        <div class="input-group-append">
                                                            <span class="fa fa-calendar input-group-text start_date_calendar" aria-hidden="true "><img src="../assets/image/date-fill.svg" alt=""></span>
                                                        </div>
                                                        <label for="ctl00$ContentPlaceHolder1$tbDataInicio">Data de início</label>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 pl-0 pl-md-2 form-group">
                                                <div class="dates d-md-flex mb-3 has-float-label">
                                                    <div class="input-group">
                                                        <asp:TextBox ID="tbDataFinal" runat="server" class="form-control form-control-lg start_date" placeholder="dd/mm/aaaa" MaxLength="12"></asp:TextBox>
                                                        <div class="input-group-append">
                                                            <span class="fa fa-calendar input-group-text start_date_calendar" aria-hidden="true "><img src="../assets/image/date-fill.svg" alt=""></span>
                                                        </div>
                                                        <label for="ctl00$ContentPlaceHolder1$tbDataInicio">Data final</label>
                                                    </div>
                                                </div>
                                            </div>
                                            
                                            <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 pl-0 pl-md-2 form-group">
                                                <div class="dates d-md-flex mb-3 has-float-label">
                                                    <div class="input-group">
                                                        <asp:TextBox ID="tbLimite" runat="server" class="form-control form-control-lg start_date" placeholder="dd/mm/aaaa" MaxLength="12"></asp:TextBox>
                                                        <div class="input-group-append">
                                                            <span class="fa fa-calendar input-group-text start_date_calendar" aria-hidden="true "><img src="../assets/image/date-fill.svg" alt=""></span>
                                                        </div>
                                                        <label for="ctl00$ContentPlaceHolder1$tbDataInicio">Data Limite para raspar</label>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-left text-md-right">
                                                <div class="custom-control custom-switch custom-switch-md">
                                                    <input type="checkbox" class="custom-control-input" checked id="cbAtivo" data-size="lg" runat="server">
                                                    <label class="custom-control-label" for="ContentPlaceHolder1_cbAtivo2">Ativar Cadastro</label>
                                                </div>
                                            </div>
                                            
                                        </div>
                                    </div>
                                </section>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="butCadastrar" runat="server" Text="SALVAR" class="btn bt-save text-uppercase mt-3 btn-md"></asp:Button>
                                <asp:Button ID="butCancel" runat="server" Text="CANCELAR" class="btn bt-cancel text-uppercase mt-3 btn-md" data-dismiss="modal"></asp:Button>
                                <asp:Button ID="butConfirmar" runat="server" Text="ATUALIZAR" class="btn bt-save btn-primary text-uppercase mt-3 btn-md"></asp:Button>
                                <asp:TextBox ID="tbID" runat="server" Visible="false"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>

              
                <section class="show-list">

                    <!-- LISTAGEM 01 
                        <asp:repeater id="Repeater1" runat="server" >
                            <ItemTemplate>-->
                    <div class="card rounded-5 mb-3 w-100 my-2">
                        <div class="row no-gutters <%# Container.DataItem("chi_ativo") %>">
                            <div class="box-img col-2 col-sm-2 col-md-2 col-lg-2 col-lx-2 border-right d-none d-sm-none d-md-flex d-lg-flex align-items-center justify-content-center">
                            
                            </div>
                            <div class="col-12 col-sm-12 col-md-8 col-lg-7 col-lx-8 pl-0 pl-md-3">
                                <div class="card-body pt-0 pb-3 px-3 py-md-4 px-md-4">
                                    <h5 class="card-title mb-0 <%# funcCor(Container.DataItem("chi_ativo")) %>"><%# FuncCelular(Container.DataItem("chi_celular")) %></h5>
                                    <p class="card-text"><%# Container.DataItem("chi_autonotify") %></p>
                                    <div class="d-flex">
                                        <p class="card-text mr-3 mr-md-5 mb-0"><strong>Obs:</strong><small class="text-muted d-block d-md-inline"> <%# Container.DataItem("chi_obs") %></small></p>
                                        <p class="card-text mr-3 mr-md-5 mb-0"><strong>Ativo:</strong><small class="text-muted  d-block d-md-inline"> <%# funcAtivo(Container.DataItem("chi_ativo")) %></small></p>
                                        <p class="card-text mr-3 mr-md-5 mb-0"><strong>Status:</strong><small class="text-muted  d-block d-md-inline"> <%# funcStatus(Container.DataItem("chi_autonotify")) %></small></p>
                                        <p class="card-text mr-3 mr-md-5 mb-0"><strong>Delay:</strong><small class="text-muted  d-block d-md-inline"> <%# Container.DataItem("chi_delay") %> Seg</small></p>
                                    </div>
                                </div>
                            </div>
                            <div class="col-12 col-sm-12 col-md-2 col-lg-3 col-lx-2 py-1 px-3 p-md-4 text-left text-md-right order-first order-md-3">
                                <h6 class="mt-2 mt-md-1">ID: 000<%# Container.DataItem("chi_id") %></h6>
                               
                            </div>
                        </div>
                    </div><!---
                            </ItemTemplate>
                        </asp:repeater>-->
                    
                </section>
                
            </main>
</asp:Content>
