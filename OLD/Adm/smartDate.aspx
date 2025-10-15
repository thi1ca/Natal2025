<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Adm/admLogado.Master" CodeBehind="smartDate.aspx.vb" Inherits="Torra.smartDate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <main role="main" class="container mb-5">
        <section  class="mb-3 mb-md-5">
            <div class="row mt-3 mt-md-5 align-items-center">
                <div class="col-8 col-sm-8 col-md-6 col-lg-6 col-xl-6 text-left text-sm-left text-md-left text-lg-left text-xl-left">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb p-0 ">
                            <li class="breadcrumb-item"><a href="dashboard.aspx">Dashboard</a></li>
                            <li class="breadcrumb-item"><a href="admCalendars.aspx">Calendário de Premiação</a></li>
                            <li class="breadcrumb-item active" aria-current="page">SMART Dates</li>
                        </ol>
                    </nav>
                </div>


                <div class="col-4 col-sm-4 col-md-6 col-lg-6 col-xl-6 text-right text-sm-right text-md-right text-lg-right text-xl-right d-flex d-sm-none justify-content-end">
                    <button type="submit" class="btn bt-save text-uppercase ml-3 btn-md d-flex d-sm-none justify-content-end">Filtrar</button>
                </div>
                
               
            </div>
        </section>


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
                            <div class="input-group">
                                <!-- <input class="form-control form-control-lg start_date" type="text" placeholder="dd/mm/aaaa" id="startdate_datepicker"> -->
                                <asp:TextBox ID="tbDataPremio" runat="server" class="form-control form-control-lg start_date" placeholder="dd/mm/aaaa" MaxLength="12" ></asp:TextBox>
                                <div class="input-group-append">
                                    <span class="fa fa-calendar input-group-text start_date_calendar" aria-hidden="true "><img src="../assets/image/date-fill.svg" alt=""></span>
                                </div>
                                <label for="startdate_datepicker">Selecione o período</label>
                            </div>
                        </div>
                    </div>
                  
                    <div class="col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 pl-0 pl-md-2 form-group">
                        <span class="has-float-label">
                            <label for="voucher" class="floatlabel">Qtd de cupons neste dia</label>
                            <asp:TextBox ID="tbQtdVoucher" runat="server" class="form-control form-control-lg mb-3" type="text" MaxLength="2"></asp:TextBox>
                        </span>
                    </div> 

                 </div>
                    
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-right p-0">
                        <asp:Button ID="butConfirmar" runat="server" Text="SALVAR" class="btn bt-save text-uppercase mt-3 btn-md"></asp:Button>
                        <asp:Button ID="butSugerir" runat="server" Text="SUGERIR" class="btn btn-primary text-uppercase mt-3 btn-md"></asp:Button>
                        <asp:TextBox ID="tbID" runat="server" Visible="false"></asp:TextBox>
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
           
        </section>
        
    </main>
</asp:Content>

