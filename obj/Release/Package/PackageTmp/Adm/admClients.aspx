<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Adm/admLogado.Master" CodeBehind="admClients.aspx.vb" Inherits="Natal_torra.admClients" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="container mb-5">
        <section  class="mb-3 mb-md-5">
            <div class="row mt-3 mt-md-5 align-items-center">
                <div class="col-8 col-sm-8 col-md-6 col-lg-6 col-xl-6 text-left text-sm-left text-md-left text-lg-left text-xl-left">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb p-0 ">
                            <li class="breadcrumb-item"><a href="dashboard.aspx">Dashboard</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Clientes</li>
                        </ol>
                    </nav>
                </div>
                <div class="col-6 col-sm-6 col-md-6 col-lg-6 col-xl-6 text-right text-sm-right text-md-right text-lg-right text-xl-right fixed-mobile">
                    
                </div>
                <div class="col-4 col-sm-4 col-md-6 col-lg-6 col-xl-6 text-right text-sm-right text-md-right text-lg-right text-xl-right d-flex d-sm-none justify-content-end">
                    <button type="submit" class="btn bt-save text-uppercase ml-3 btn-md d-flex d-sm-none justify-content-end">Filtrar</button>
                </div>
            </div>
        </section>
        <section class="filter">
            <div class="formSetup">
                <div class="row">
                    <div class="bt-filter col-4 col-sm-4 col-md-5 col-lg-5 col-lx-5 text-left">
                        <h5 class="py-2 py-md-0"><img src="../assets/image/filter.svg" alt=""> Busca por Nome</h5>
                        <div class="searchform">
                            <asp:TextBox ID="tbNome" runat="server" class="form-control filter-name" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-mg" placeholder="Ex: Nome Cliente..."></asp:TextBox>                            
                            
                        </div>
                        <!-- <div class="result">
                           
                        </div> -->
                    </div>
                    <div class="filter-date col-4 col-sm-4 col-md-4 col-lg-4 col-lx-4 text-left">
                        <h5 class="py-2 py-md-0"><img src="../assets/image/filter.svg" alt=""> Busca por CPF</h5>
                        <asp:TextBox ID="tbCPF" runat="server" class="form-control cpf" inputmode="numeric" name="cpf" aria-describedby="inputGroup-sizing-mg" placeholder="Ex: CPF" MaxLength="12"></asp:TextBox>
                    </div>
                    <div class="filter-order col-4 col-sm-4 col-md-3 col-lg-3 col-lx-3">
                        <h5 class="py-2 py-md-0"><img src="../assets/image/order.svg" alt=""> Ordenar</h5>
                        <div class="select-radio text-rigth d-md-flex justify-content-end">
                            <asp:DropDownList ID="ddlOrdenacao" runat="server" class="custom-select form-check" aria-label="Example select with button addon" AutoPostBack="True"></asp:DropDownList>
                            <!--
                            <select class="custom-select form-check" id="inputGroupSelect04" aria-label="Example select with button addon">
                                <option value="ativo">Ativo</option>
                                <option value="inativo">Inativo</option>
                                <option value="nomeasc">Nome ASC</option>
                                <option value="nomedesc">Nome DESC</option>
                            </select>-->
                            <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" class="btn bt-save text-uppercase ml-3 btn-md d-none d-md-block" />
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <section class="show-list user">

            <!-- LISTAGEM 01 -->
                <asp:repeater id="Repeater1" runat="server" >
					<ItemTemplate>
            <div class="card rounded-5 mb-3 w-100 my-2">
                <div class="row d-flex justify-content-between no-gutters <%# funcFundo(Container.DataItem("cli_ativo")) %>">
                    <div class="box-img col-2 col-sm-2 col-md-2 col-lg-2 col-lx-2 border-right d-none d-sm-none d-md-flex d-lg-flex align-items-center justify-content-center">
                        <img src="../assets/avatar/<%# Container.DataItem("cli_imagem") %>" alt="" class="rounded p-3 p-sm-3 p-md-3 p-lg-0">
                    </div>
                    <div class="col-12 col-sm-12 col-md-8 col-lg-8 col-lx-8 pl-0">
                        <div class="card-body pt-0 pb-3 px-3 py-md-4 px-md-4">
                            <h5 class="card-title mb-0"><%# Container.DataItem("cli_nome") %></h5>
                            <p class="card-text"><%# Container.DataItem("cli_email") %></p>
                            <div class="row no-gutters pb-2">
                                <div class="col-12 col-sm-12 col-md-3 col-lg-3 col-xl-3">
                                    <p class="card-text"><strong>Nasc:</strong> <small class="text-muted d-block d-md-inline"> <%# Convert.ToDateTime(Container.DataItem("cli_nascimento")).ToString("dd/MM/yyyy") %></small></p>
                                </div>
                                <div class="col-12 col-sm-12 col-md-3 col-lg-3 col-xl-3">
                                    <p class="card-text"><strong>Celular:</strong> <small class="text-muted  d-block d-md-inline"> <%# funcCel(Container.DataItem("cli_celular")) %></small></p>
                                </div>
                                <div class="col-12 col-sm-12 col-md-3 col-lg-3 col-xl-3">
                                    <p class="card-text"><strong>Status:</strong> <small class="text-muted  d-block d-md-inline"> <%# funcAtivo(Container.DataItem("cli_ativo")) %></small></p>
                                </div>
                                <div class="col-12 col-sm-12 col-md-3 col-lg-3 col-xl-3">
                                    <p class="card-text"><strong>Gênero:</strong> <small class="text-muted  d-block d-md-inline"><%# Container.DataItem("gen_nome") %> </small></p>
                                </div>
                            </div>

                            <div class="row no-gutters separador pt-2">
                                <div class="col-12 col-sm-12 col-md-3 col-lg-3 col-xl-3">
                                    <p class="card-text"><strong>Respostas:</strong> <small class="text-muted d-block d-md-inline"> <%# If(IsDBNull(Container.DataItem("respostas")), "0", Container.DataItem("respostas")) %></small></p>
                                </div>
                                <div class="col-12 col-sm-12 col-md-3 col-lg-3 col-xl-3">
                                    <p class="card-text"><strong>Acertos:</strong> <small class="text-muted d-block d-md-inline"><%# funcAcertos(Container.DataItem("acertos"), Container.DataItem("respostas")) %> </small></p>
                                </div>
                                <div class="col-12 col-sm-12 col-md-3 col-lg-3 col-xl-3">
                                    <p class="card-text"><strong>Cupons:</strong> <small class="text-muted  d-block d-md-inline"> <%# If(IsDBNull(Container.DataItem("cupons")), "0", Container.DataItem("cupons")) %></small></p>
                                </div>
                                <div class="col-12 col-sm-12 col-md-3 col-lg-3 col-xl-3">
                                    <p class="card-text"><strong>Números da sorte:</strong> <small class="text-muted  d-block d-md-inline"> <%# If(IsDBNull(Container.DataItem("sorte")), "0", Container.DataItem("sorte")) %></small></p>
                                </div>
                            </div>
                        </div>
                    </div>


                    <div class="col-12 col-sm-12 col-md-2 col-lg-2 col-lx-2 py-1 px-3 p-md-4 text-left text-md-right order-first order-md-3 d-flex flex-column justify-content-center ">
                        <h6 class="mt-1 mt-md-1">CPF: <%# FuncCPF(Container.DataItem("cli_cpf")) %></h6>
                        <h7 class="mt-1 mt-md-1">ID: 000<%# Container.DataItem("cli_id") %></h7>
                        <!-- <div class="dropdown dropleft">
                            <button class=" dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <img src="../assets/image/option.svg" alt="">
                            </button>
                            
                            <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                              <a class="dropdown-item" href="admClients_edit.aspx?cadId=<%# Container.DataItem("cli_id") %>">Detalhes <img src="../assets/image/edit.svg" alt=""></a>
                              
                            </div>
                        </div> -->
                    </div>
                </div>
            </div>
                     </ItemTemplate>
				</asp:repeater>

          

              

            <nav class="pb-5 d-flex justify-content-center justify-content-md-between align-items-center" aria-label="Page navigation example">
            <div class="desciption-pagination d-none d-md-block"><p>
                <asp:Label ID="labTotal" runat="server" Text=""></asp:Label></p></div>
            <ul class="pagination">
                <li class="page-item">
                    <asp:LinkButton ID="butAnterior" class="page-link" runat="server">Anterior</asp:LinkButton>
                </li>
                <!--
                <li class="page-item active"><a class="page-link" href="#">1</a></li>
                <li class="page-item"><a class="page-link" href="#">2</a></li>
                <li class="page-item"><a class="page-link" href="#">3</a></li>-->
                <li class="page-item"><asp:LinkButton ID="butProximo" class="page-link" runat="server">Próximo</asp:LinkButton>
                
                </li>
            </ul>
            </nav>
            
        </section>
        
    </main>
</asp:Content>
