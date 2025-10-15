<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Adm/admLogado.Master" CodeBehind="listWinners.aspx.vb" Inherits="Torra.listWinners" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <main role="main" class="container mb-5">
        <section  class="mb-3 mb-md-5">
            <div class="row mt-3 mt-md-5 align-items-center">
                <div class="col-8 col-sm-8 col-md-6 col-lg-6 col-xl-6 text-left text-sm-left text-md-left text-lg-left text-xl-left">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb p-0 ">
                            <li class="breadcrumb-item"><a href="dashboard.aspx">Dashboard</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Lista Premiados</li>
                        </ol>
                    </nav>
                </div>
                <div class="col-4 col-sm-4 col-md-6 col-lg-6 col-xl-6 text-right text-sm-right text-md-right text-lg-right text-xl-right d-flex d-sm-none justify-content-end">
                    <button type="submit" class="btn bt-save text-uppercase ml-3 btn-md d-flex d-sm-none justify-content-end">Filtrar</button>
                </div>
            </div>
        </section>

           <section class="filter">
            <div class="formSetup">
                <div class="row">
                    <div class="bt-filter col-6 col-sm-6 col-md-8 col-lg-9 col-lx-9 text-left">
                        <h5 class="py-2 py-md-0"><img src="../assets/image/filter.svg" alt=""> Busca</h5>
                        <div class="d-md-flex searchform">
                            <span class="has-float-label pr-2 w-100 in-email">
                                <div class="input-group select-mist mb-3">
                                    <asp:DropDownList ID="ddlCampanha" runat="server" class="form-control custom-select" AutoPostBack="True"></asp:DropDownList>
                                <label for="campanha">Selecione a campanha</label>
                                    <div class="input-group-append">
                                    <button class="btn btn-outline-secondary" type="button"><img src="../assets/image/arrow-down.svg" alt="" class="w-75"></button>
                                    </div>
                                </div>
                            </span>
                        </div>
                    </div>
                    <div class="filter-order col-6 col-sm-6 col-md-4 col-lg-3 col-lx-3 text-right">
                        <h5 class="py-2 py-md-0"><img src="../assets/image/order.svg" alt=""> Ordenar</h5>
                        <div class="select-radio text-rigth d-md-flex justify-content-end">
                            <asp:DropDownList ID="ddlOrdenacao" runat="server" class="custom-select form-check" aria-label="Example select with button addon" AutoPostBack="True"></asp:DropDownList>
                          
                        </div>
                    </div>

                </div>
            </div>
        </section>


           
        <section class="show-list ">

          
                <asp:repeater id="Repeater1" runat="server" >
					<ItemTemplate>
            <div class="card rounded-5 mb-3 w-100 my-2">
                <div class="row no-gutters <%# FunctionFundo(Container.DataItem("pre_ativo")) %>">
                    <div class="col-12 col-sm-12 col-md-8 col-lg-7 col-lx-8 pl-0 pl-md-3">
                        <div class="card-body pt-0 pb-3 px-3 py-md-4 px-md-4">
                            <h5 class="card-title mb-0"><%# Container.DataItem("pre_nome") %></h5>
                            <p class="card-text">Prêmio é um voucher? <%# FuncAtivo(Container.DataItem("pre_voucher"), 2) %></p>
                            <div class="d-flex">
                                <p class="card-text mr-3 mr-md-5 mb-0"><strong>Criado por:</strong><small class="text-muted d-block d-md-inline"> <%# Container.DataItem("cad_nome") %></small></p>
                                <p class="card-text mr-3 mr-md-5 mb-0"><strong>Data:</strong><small class="text-muted  d-block d-md-inline"> <%# funcData(Container.DataItem("pre_data")) %></small></p>
                                <p class="card-text mr-3 mr-md-5 mb-0"><strong>Status:</strong><small class="text-muted  d-block d-md-inline"> <%# funcAtivo(Container.DataItem("pre_ativo"), 1) %></small></p>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-sm-12 col-md-2 col-lg-3 col-lx-2 py-1 px-3 p-md-4 text-left text-md-right order-first order-md-3">
                        <h6 class="mt-2 mt-md-1">ID: 000<%# Container.DataItem("pre_id") %></h6>
                        <div class="dropdown dropleft text-left">
                            <button class=" dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <img src="../assets/image/option.svg" alt="">
                            </button>
                            
                            <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                             
                              <a class="dropdown-item" href="admCalendar.aspx?preId=<%# Container.DataItem("pre_id") %>">Calendário de premiação <img src="../assets/image/calendar.svg" alt="Calendário de premiação"></a>
                              <asp:LinkButton ID="butEditar" runat="server" CssClass="dropdown-item" CommandArgument='<%# Eval("cam_id") %>'> Editar <img src="../assets/image/edit.svg" alt="Editar"></asp:LinkButton>
                               <asp:LinkButton ID="butExcluir" runat="server" class="dropdown-item" CommandArgument='<%# Eval("cam_id") %>'>Desativar <img src="../assets/image/trash.svg" alt="Desativar"></asp:LinkButton>
                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
                     </ItemTemplate>
				</asp:repeater>
             
          
            
              

            <nav class="pb-5 d-flex justify-content-center justify-content-md-between align-items-center" aria-label="Page navigation example">
            <div class="desciption-pagination d-none d-md-block"><p>
                <asp:Label ID="labTotal" runat="server" Text=""></asp:Label></p></div>
            <ul class="pagination">
                <li class="page-item disabled">
                    <asp:LinkButton ID="butAnterior" class="page-link" runat="server">Anterior</asp:LinkButton>
                </li>
                
                <li class="page-item"><asp:LinkButton ID="butProximo" class="page-link" runat="server">Próximo</asp:LinkButton>
                
                </li>
            </ul>
            </nav>
            
        </section>
        
    </main>
</asp:Content>
