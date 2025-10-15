<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/adm/admLogado.Master" CodeBehind="admCalendars.aspx.vb" Inherits="Torra.admCalendars" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <main role="main" class="container mb-5">
        <section  class="mb-3 mb-md-5">
            <div class="row mt-3 mt-md-5 align-items-center">
                <div class="col-8 col-sm-8 col-md-6 col-lg-6 col-xl-6 text-left text-sm-left text-md-left text-lg-left text-xl-left">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb p-0 ">
                            <li class="breadcrumb-item"><a href="dashboard.aspx">Dashboard</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Calendário de premiação</li>
                        </ol>
                    </nav>
                </div>






                <div class="col-6 col-sm-6 col-md-6 col-lg-6 col-xl-6 text-right text-sm-right text-md-right text-lg-right text-xl-right fixed-mobile">
                    <div class="plus-bt">+</div>
                    <asp:Button ID="butNew" runat="server" Text="+ Nova Data Manual" class="btn bt-blue text-uppercase" role="button" data-toggle="modal" data-target="#exampleModal"/>
                     <div class="plus-bt">+</div>
                    <asp:Button ID="butSmart" runat="server" Text="+ Datas SMART" class="btn bt-blue text-uppercase" role="button"/> 
                </div>
                <div class="col-4 col-sm-4 col-md-6 col-lg-6 col-xl-6 text-right text-sm-right text-md-right text-lg-right text-xl-right d-flex d-sm-none justify-content-end">
                    <button type="submit" class="btn bt-save text-uppercase ml-3 btn-md d-flex d-sm-none justify-content-end">Filtrar</button>
                </div>
                
               
            </div>
        </section>


        

        <div class="modal" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
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
            
                                  <div class="col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 pl-0 pl-md-2 form-group">
                                    <span class="has-float-label">
                                        <div class="input-group select-mist mb-3">
                                            <asp:DropDownList ID="ddlCampanha" runat="server" class="custom-select" AutoPostBack="True"></asp:DropDownList>
                                           <label for="campanha">Selecione a campanha</label>
                                            <div class="input-group-append">
                                            <button class="btn btn-outline-secondary" type="button"><img src="../assets/image/arrow-down.svg" alt="" class="w-75"></button>
                                            </div>
                                        </div>
                                    </span>
                                </div>
            
                                  <div class="col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 pl-0 pl-md-2 form-group">
                                    <span class="has-float-label">
                                        <div class="input-group select-mist mb-3">
                                            <asp:DropDownList ID="ddlPremio" runat="server" class="custom-select"></asp:DropDownList>
                                           <label for="campanha">Selecione o Prêmio</label>
                                            <div class="input-group-append">
                                            <button class="btn btn-outline-secondary" type="button"><img src="../assets/image/arrow-down.svg" alt="" class="w-75"></button>
                                            </div>
                                        </div>
                                    </span>
                                </div>
                                
                                 
                                 <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-lx-4 pl-0 pl-md-2 form-group">
                                    <div class="dates d-md-flex mb-3 has-float-label">
                                        <div class="input-group select-mist">
                                            <!-- <input class="form-control form-control-lg start_date" type="text" placeholder="dd/mm/aaaa" id="startdate_datepicker"> -->
                                            <asp:TextBox ID="tbDataPremio" runat="server" class="form-control form-control-lg start_date" placeholder="dd/mm/aaaa" MaxLength="12" ></asp:TextBox>
                                            <label for="startdate_datepicker">Selecione o período</label>
                                            <div class="input-group-append">
                                                <span class="fa fa-calendar input-group-text start_date_calendar" aria-hidden="true "><img src="../assets/image/date-fill.svg" alt=""></span>
                                            </div>
                                            
                                        </div>
                                    </div>
                                </div>
                                <div class="col-12 col-sm-12 col-md-2 col-lg-2 col-xl-2 pl-0 pl-md-2 form-group">
                                    <div class="dates d-md-flex mb-3 has-float-label">
                                        <div class="input-group">
                                            <input type="text" class="form-control form-control-l time" id="time" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-mg" placeholder="12:10:33">
                                            <div class="input-group-append">
                                                <span class="fa fa-calendar input-group-text start_date_calendar" aria-hidden="true "><img src="../assets/image/clock.svg" alt=""></span>
                                            </div>
                                            <label for="voucher" class="floatlabel">Selecione a Hora</label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 pl-0 pl-md-2 form-group">
                                    <span class="has-float-label">
                                        <label for="voucher" class="floatlabel">Código do voucher (Somente se for disponibilizado imediatamente)</label>
                                        <asp:TextBox ID="tbVoucher" runat="server" class="form-control form-control-lg mb-3" type="text" MaxLength="30"></asp:TextBox>
                                    </span>
                                </div> 
            
                             </div>
                            </div>
                    </section>
                    
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">FECHAR</button>
                    <asp:Button ID="butCadastrar" runat="server" Text="SALVAR" class="btn bt-save text-uppercase  btn-md"></asp:Button>
                    <asp:Button ID="butCancel" runat="server" Text="CANCELAR" class="btn bt-cancel text-uppercase  btn-md"></asp:Button>
                    <asp:Button ID="butConfirmar" runat="server" Text="ATUALIZAR" class="btn btn-primary text-uppercase  btn-md"></asp:Button>
                    <asp:TextBox ID="tbID" runat="server" Visible="false"></asp:TextBox>
                </div>
              </div>
            </div>
          </div>


        <section class="filter">
            <div class="formSetup">
                <div class="row">
                    <div class="bt-filter col-5 col-sm-5 col-md-5 col-lg-5 col-lx-5 text-left">
                        <h5 class="py-2 py-md-0"><img src="../assets/image/filter.svg" alt=""> Busca</h5>
                        <div class="d-md-flex">
                            <span class="has-float-label pr-2 w-50">
                                <div class="input-group select-mist mb-3">
                                    <asp:DropDownList ID="ddlFiltroCampanha" runat="server" class="custom-select" AutoPostBack="True"></asp:DropDownList>
                                <label for="campanha">Selecione a campanha</label>
                                    <div class="input-group-append">
                                    <button class="btn btn-outline-secondary" type="button"><img src="../assets/image/arrow-down.svg" alt="" class="w-75"></button>
                                    </div>
                                </div>
                            </span>
                            <span class="has-float-label pl-2 w-50">
                                <div class="input-group select-mist mb-3">
                                    <asp:DropDownList ID="ddlFiltroPremio" runat="server" class="custom-select"></asp:DropDownList>
                                <label for="campanha">Selecione o Prêmio</label>
                                    <div class="input-group-append">
                                    <button class="btn btn-outline-secondary" type="button"><img src="../assets/image/arrow-down.svg" alt="" class="w-75"></button>
                                    </div>
                                </div>
                            </span>
                        </div>
                    </div>

                    <div class="filter-date col-4 col-sm-4 col-md-4 col-lg-4 col-lx-4 text-left">
                        <h5 class="py-2 py-md-0"><img src="../assets/image/date.svg" alt=""> Período</h5>
                        <div class="dates d-md-flex">
                            <div class="start_date input-group mb-1 mb-md-4 mr-2">
                                <!-- <input class="form-control start_date" type="text" placeholder="Data inicial" id="startdate_datepicker"> -->
                                <asp:TextBox ID="tbFiltroInicio" runat="server" class="form-control start_date" placeholder="Data inicial" MaxLength="12"></asp:TextBox>
                                <div class="input-group-append">
                                    <span class="fa fa-calendar input-group-text start_date_calendar" aria-hidden="true "><img src="../assets/image/date-fill.svg" alt=""></span>
                                </div>
                            </div>
                            <div class="end_date input-group mb-1 mb-md-4 ml-2">
                                <!-- <input class="form-control end_date" type="text" placeholder="Data final" id="enddate_datepicker"> -->
                                <asp:TextBox ID="tbFiltroFim" runat="server" class="form-control end_date" placeholder="Data final" MaxLength="12"></asp:TextBox>	
                                <div class="input-group-append">
                                    <span class="fa fa-calendar input-group-text end_date_calendar" aria-hidden="true "><img src="../assets/image/date-fill.svg" alt=""></span>
                                </div>
                            </div>
                        </div>

                    </div>

                    <div class="filter-order col-3 col-sm-3 col-md-3 col-lg-3 col-lx-3">
                        <h5 class="py-2 py-md-0"><img src="../assets/image/order.svg" alt=""> Ordenar</h5>
                        <div class="select-radio text-rigth d-md-flex justify-content-end">
                            <asp:DropDownList ID="ddlOrdenacao" runat="server" class="custom-select form-check" aria-label="Example select with button addon" AutoPostBack="True"></asp:DropDownList>
                           
                            <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" class="btn bt-save text-uppercase ml-3 btn-md d-none d-md-block" />
                        </div>
                    </div>

                </div>
            </div>
        </section>
        <section class="show-list">

          
                <asp:repeater id="Repeater1" runat="server" >
					<ItemTemplate>
            <div class="card rounded-5 mb-3 w-100 my-2">
                <div class="row no-gutters <%# FunctionFundo(Container.DataItem("cal_data_premio")) %>">
                    <div class="box-img col-2 col-sm-2 col-md-2 col-lg-2 col-lx-2 border-right d-none d-sm-none d-md-flex d-lg-flex align-items-center justify-content-center">
                       
                    </div>
                    <div class="col-12 col-sm-12 col-md-8 col-lg-7 col-lx-8 pl-0 pl-md-3">
                        <div class="card-body pt-0 pb-3 px-3 py-md-4 px-md-4">
                            <h5 class="card-title mb-0"><%# Container.DataItem("cal_data_premio") %></h5>
                            <p class="card-text"><strong>Vencedor:</strong> <%# Container.DataItem("cli_nome") %></p>
                            <p class="card-text"><strong>Voucher:</strong><%# Container.DataItem("cal_voucher") %></p>
                            <div class="d-flex">
                                <p class="card-text mr-3 mr-md-5 mb-0"><strong>Criado por:</strong><small class="text-muted d-block d-md-inline"> <%# Container.DataItem("cad_nome") %></small></p>
                                <p class="card-text mr-3 mr-md-5 mb-0"><strong>Data:</strong><small class="text-muted  d-block d-md-inline"> <%# funcData(Container.DataItem("cal_data")) %></small></p>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-sm-12 col-md-2 col-lg-3 col-lx-2 py-1 px-3 p-md-4 text-left text-md-right order-first order-md-3">
                        <h6 class="mt-2 mt-md-1">ID: 000<%# Container.DataItem("cal_id") %></h6>
                        <div class="dropdown dropleft">
                            <button class=" dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <img src="../assets/image/option.svg" alt="">
                            </button>
                            
                            <div class="dropdown-menu text-right" aria-labelledby="dropdownMenuButton">
                             
                             
                              <asp:LinkButton ID="butEditar" runat="server" CssClass="dropdown-item" Text="Editar" CommandArgument='<%# Eval("cal_id") %>'></asp:LinkButton>
                               <asp:LinkButton ID="butExcluir" runat="server" class="dropdown-item" CommandArgument='<%# Eval("cal_id") %>'>Excluir</asp:LinkButton>
                                 <a class="dropdown-item" href="admWinners.aspx?calId=<%# Container.DataItem("cal_id") %>">Notificar <img src="../assets/image/notification.svg" alt="Notificar"></a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
                     </ItemTemplate>
				</asp:repeater>
              <asp:TextBox ID="tbPaginacao" runat="server" Visible="false"></asp:TextBox>
                    <asp:Button ID="butCarregar" runat="server" Text="+Carregar próximos" class="btn bt-save text-uppercase ml-3 btn-sm" Visible="false"/>
          
            
              

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
