<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Adm/admLogado.Master" CodeBehind="_bkp_admCampaign.aspx.vb" Inherits="Torra.admCampaign" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="container mb-5">
        <section  class="mb-3 mb-md-5">
            <div class="row mt-3 mt-md-5 align-items-center">
                <div class="col-8 col-sm-8 col-md-6 col-lg-6 col-xl-6 text-left text-sm-left text-md-left text-lg-left text-xl-left">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb p-0 ">
                            <li class="breadcrumb-item"><a href="dashboard.aspx">Dashboard</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Campanhas</li>
                        </ol>
                    </nav>
                </div>
                <div class="col-6 col-sm-6 col-md-6 col-lg-6 col-xl-6 text-right text-sm-right text-md-right text-lg-right text-xl-right fixed-mobile">
                    <div class="plus-bt">+</div>
                    <a class="btn bt-blue text-uppercase" href="admClients_edit.aspx" role="button">+ Criar Campanha</a>
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
                        <h5 class="py-2 py-md-0"><img src="../assets/image/filter.svg" alt=""> Busca</h5>
                        <div class="searchform">
                            <asp:TextBox ID="tbNome" runat="server" class="form-control filter-name" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-mg" placeholder="Ex.: Nome Campanha..."></asp:TextBox>
                        </div>
                        <div class="result"></div>
                    </div>
                    <div class="filter-date col-4 col-sm-4 col-md-4 col-lg-4 col-lx-4 text-left">
                     
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
                <div class="row no-gutters <%# funcFundo(Container.DataItem("cam_ativo")) %>">
                    <div class="box-img col-2 col-sm-2 col-md-2 col-lg-2 col-lx-2 border-right d-none d-sm-none d-md-flex d-lg-flex align-items-center justify-content-center">
                       
                    </div>
                    <div class="col-12 col-sm-12 col-md-8 col-lg-7 col-lx-8 pl-0 pl-md-3">
                        <div class="card-body pt-0 pb-3 px-3 py-md-4 px-md-4">
                            <h5 class="card-title mb-0"><%# Container.DataItem("cam_nome") %></h5>
                            <p class="card-text"><%# Container.DataItem("cam_inicio") %> - <%# Container.DataItem("cam_fim") %></p>
                            <div class="d-flex">
                                <p class="card-text mr-3 mr-md-5 mb-0"><strong>Criado por:</strong><small class="text-muted d-block d-md-inline"> <%# Container.DataItem("cad_id") %></small></p>
                                <p class="card-text mr-3 mr-md-5 mb-0"><strong>Data:</strong><small class="text-muted  d-block d-md-inline"> <%# funcData(Container.DataItem("cam_data")) %></small></p>
                                <p class="card-text mr-3 mr-md-5 mb-0"><strong>Status:</strong><small class="text-muted  d-block d-md-inline"> <%# funcAtivo(Container.DataItem("cam_ativo")) %></small></p>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-sm-12 col-md-2 col-lg-3 col-lx-2 py-1 px-3 p-md-4 text-left text-md-right order-first order-md-3">
                        <h6 class="mt-2 mt-md-1">ID: 000<%# Container.DataItem("cam_id") %></h6>
                        <div class="dropdown dropleft">
                            <button class=" dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <img src="../assets/image/option.svg" alt="">
                            </button>
                            
                            <div class="dropdown-menu" aria-labelledby="dropdownMenuButton">
                              <a class="dropdown-item" href="admCampaign_edit.aspx?camId=<%# Container.DataItem("cam_id") %>">Editar <img src="../assets/image/edit.svg" alt=""></a>
                              <a class="dropdown-item" href="admprizes.aspx?camId=<%# Container.DataItem("cam_id") %>">Prêmios <img src="../assets/image/edit.svg" alt=""></a>
                                <a class="dropdown-item" href="#" id="butExcluir3" runat="server">Prêmios <img src="../assets/image/edit.svg" alt=""></a>
                               <asp:LinkButton ID="butExcluir" runat="server" class="dropdown-item">cliq</asp:LinkButton><img src="../assets/image/trash.svg" alt="">
                                <asp:LinkButton ID="linkDetalhes" runat="server" CssClass="btn btn-inverse width-100 btn-sm" Text="Detalhes" Visible="false"></asp:LinkButton>
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
