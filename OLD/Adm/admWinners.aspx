<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Adm/admLogado.Master" CodeBehind="admWinners.aspx.vb" Inherits="Torra.admWinners" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

    
    <main role="main" class="container mb-5">
        <section  class="mb-3 mb-md-5">
            <div class="row mt-3 mt-md-5 align-items-center">
                <div class="col-8 col-sm-8 col-md-6 col-lg-6 col-xl-6 text-left text-sm-left text-md-left text-lg-left text-xl-left">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb p-0 ">
                            <li class="breadcrumb-item"><a href="dashboard.aspx">Dashboard</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Notifica Premiação</li>
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
                            <span class="has-float-label pr-2 w-100 in-email">
                                  <div class="input-group select-mist mb-3">
                                    <asp:DropDownList ID="ddlPremio" runat="server" class="form-control custom-select"></asp:DropDownList>
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
                                <asp:TextBox ID="tbDataInicio" runat="server" class="form-control form-control-lg start_date" placeholder="dd/mm/aaaa" MaxLength="10" ></asp:TextBox>
                                <div class="input-group-append">
                                    <span class="fa fa-calendar input-group-text start_date_calendar" aria-hidden="true "><img src="../assets/image/date-fill.svg" alt=""></span>
                                </div>
                                <label for="startdate_datepicker">Data Inicial</label>
                            </div>
                        </div>
                    </div>

                    <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-lx-4 pl-0 pl-md-2 form-group">
                        <div class="dates d-md-flex mb-3 has-float-label">
                            <div class="input-group">
                                <!-- <input class="form-control form-control-lg start_date" type="text" placeholder="dd/mm/aaaa" id="startdate_datepicker"> -->
                                <asp:TextBox ID="tbDataFim" runat="server" class="form-control form-control-lg start_date" placeholder="dd/mm/aaaa" MaxLength="10" ></asp:TextBox>
                                <div class="input-group-append">
                                    <span class="fa fa-calendar input-group-text start_date_calendar" aria-hidden="true "><img src="../assets/image/date-fill.svg" alt=""></span>
                                </div>
                                <label for="startdate_datepicker">Data Final</label>
                            </div>
                        </div>
                    
                        <div class="custom-control custom-switch custom-switch-md">
                            <asp:CheckBox ID="cbPendentes" runat="server" Text="Somente não Notificados" Checked="true" />
                        </div>
                             <div class="filter-order col-6 col-sm-6 col-md-4 col-lg-3 col-lx-3 text-right">
                         <asp:Button ID="butFiltrar" runat="server" Text="Filtrar" class="btn bt-save text-uppercase ml-3 btn-sm"/>
                         </div>
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
                    <div class="filter-order col-4 col-sm-4 col-md-3 col-lg-3 col-lx-3 text-right">
                        <h5 class="py-2 py-md-0"><img src="../assets/image/order.svg" alt=""> Ordenar</h5>
                        <div class="select-radio text-rigth d-md-flex justify-content-end">
                            <asp:DropDownList ID="ddlOrdenacao" runat="server" class="custom-select form-check" aria-label="Example select with button addon"></asp:DropDownList>
                          
                        </div>
                    </div>

                     

                </div>
            </div>
        </section>


        <section class="create-page">
            <div class="formSetup user" id="divFormulario">
                <div class="row no-gutters">

                     <asp:repeater id="Repeater2" runat="server" >
					<ItemTemplate>
            <div class="card rounded-5 mb-3 w-100 my-2">
                <div class="row no-gutters <%# Container.DataItem("pre_ativo") %>">
                    <div class="box-img numberTXT col-4 col-sm-4 col-md-4 col-lg-4 col-lx-4 border-right flex-column d-none d-sm-none d-md-flex d-lg-flex align-items-center justify-content-center">
                        <%# Container.DataItem("pre_nome") %>
                        <strong>Raspado em </strong><small class="text-muted d-block d-md-inline"><%# Container.DataItem("ras_data") %></small>
                        <strong>Prêmio programado </strong><small class="text-muted d-block d-md-inline"> <%# Container.DataItem("cal_data_premio") %></small>
                    </div>
                    <div class="infoCupom col-12 col-sm-12 col-md-8 col-lg-8 col-lx-8 pl-0 pl-md-3">
                        <div class="card-body pt-0 pb-3 px-3 py-md-4 px-md-4">
                            <h5 class="card-title mb-0 "><%# Container.DataItem("cli_nome") %> <span><strong>Cupom: </strong>
                                <asp:TextBox ID="tbCupom" runat="server" Text='<%# Container.DataItem("cal_voucher") %>'></asp:TextBox></span></h5>
                            <p class="card-text">
                                <span><img src="../assets/image/card-cpf.svg" alt="CPF"> <%# funcCPF(Container.DataItem("cli_CPF")) %> </span>
                                <span><img src="../assets/image/email.svg" alt="Email"> <%# Container.DataItem("cli_email") %> </span>
                                <span><img src="../assets/image/whatsapp.svg" alt="Whatsapp"><%# funcCelular(Container.DataItem("cli_celular")) %></span>
                            </p>
                            <div class="row">
                                <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-lx-12 d-flex flex-row align-items-center border-top pt-3">
                                    <h3 class="pr-3 m-0 font-weight-bold">Enviar: </h3>
                                    <div class="custom-control custom-checkbox">
                                        <asp:CheckBox  id="cbEmail" runat="server" Text="Enviar por E-mail" />          
                                    </div>
                                    <div class="custom-control custom-checkbox">
                                         <asp:CheckBox  id="cbWhatsapp" runat="server" Text="Enviar por Whatsapp" />  
                                    </div>
                                    <asp:Button ID="butEnviar" runat="server" Text="Enviar cupom" class="btn bt-save text-uppercase ml-3 btn-sm" CommandArgument='<%# Eval("ras_id") %>'/>
                                </div>
                            </div>                           
                        </div>
                    </div>
                    <div class="col-12 col-sm-12 col-md-2 col-lg-2 col-lx-2 py-1 px-3 p-md-4 text-left text-md-right order-first order-md-3 d-flex flex-row flex-md-column justify-content-between">
                        <h6 class="mt-2 mt-md-1">ID: 000<%# Container.DataItem("ras_id") %></h6>
                        <div class="d-flex align-items-end justify-content-end status-env">
                            <div class='mx-1 my-2 box-email <%# funcEnviado(Container.DataItem("cal_notificado_email")) %>' data-toggle="tooltip" data-placement="bottom" title='<%# funcEnviado(Container.DataItem("cal_notificado_email")) %>'>
                                <svg width="30" height="30" viewBox="0 0 30 30" fill="none" xmlns="http://www.w3.org/2000/svg">
                                    <path d="M27.5 15V5.625H2.5V24.375H15M19.375 22.5L22.5 25L27.5 18.75" stroke="#181945" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
                                    <path d="M2.5 5.625L15 15L27.5 5.625" stroke="#181945" stroke-width="2" stroke-linecap="round" stroke-linejoin="round"/>
                                </svg>
                            </div>
                            <div class='mx-1 my-2 box-whatsapp <%# funcEnviado(Container.DataItem("cal_notificado_whatsapp")) %>' data-toggle="tooltip" data-placement="bottom" title='<%# funcEnviado(Container.DataItem("cal_notificado_whatsapp")) %>'>
                                <svg width="30" height="30" viewBox="0 0 30 30" fill="none" xmlns="http://www.w3.org/2000/svg">
                                    <path d="M23.8125 6.13757C22.6665 4.97998 21.3015 4.06216 19.797 3.43764C18.2926 2.81312 16.6789 2.4944 15.05 2.50007C8.225 2.50007 2.6625 8.06257 2.6625 14.8876C2.6625 17.0751 3.2375 19.2001 4.3125 21.0751L2.5625 27.5001L9.125 25.7751C10.9375 26.7626 12.975 27.2876 15.05 27.2876C21.875 27.2876 27.4375 21.7251 27.4375 14.9001C27.4375 11.5876 26.15 8.47507 23.8125 6.13757ZM15.05 25.1876C13.2 25.1876 11.3875 24.6876 9.8 23.7501L9.425 23.5251L5.525 24.5501L6.5625 20.7501L6.3125 20.3626C5.28468 18.7213 4.73892 16.8241 4.7375 14.8876C4.7375 9.21257 9.3625 4.58757 15.0375 4.58757C17.7875 4.58757 20.375 5.66257 22.3125 7.61257C23.2719 8.56753 24.0321 9.7034 24.5492 10.9544C25.0664 12.2053 25.33 13.5465 25.325 14.9001C25.35 20.5751 20.725 25.1876 15.05 25.1876ZM20.7 17.4876C20.3875 17.3376 18.8625 16.5876 18.5875 16.4751C18.3 16.3751 18.1 16.3251 17.8875 16.6251C17.675 16.9376 17.0875 17.6376 16.9125 17.8376C16.7375 18.0501 16.55 18.0751 16.2375 17.9126C15.925 17.7626 14.925 17.4251 13.75 16.3751C12.825 15.5501 12.2125 14.5376 12.025 14.2251C11.85 13.9126 12 13.7501 12.1625 13.5876C12.3 13.4501 12.475 13.2251 12.625 13.0501C12.775 12.8751 12.8375 12.7376 12.9375 12.5376C13.0375 12.3251 12.9875 12.1501 12.9125 12.0001C12.8375 11.8501 12.2125 10.3251 11.9625 9.70007C11.7125 9.10007 11.45 9.17507 11.2625 9.16257H10.6625C10.45 9.16257 10.125 9.23757 9.8375 9.55007C9.5625 9.86257 8.7625 10.6126 8.7625 12.1376C8.7625 13.6626 9.875 15.1376 10.025 15.3376C10.175 15.5501 12.2125 18.6751 15.3125 20.0126C16.05 20.3376 16.625 20.5251 17.075 20.6626C17.8125 20.9001 18.4875 20.8626 19.025 20.7876C19.625 20.7001 20.8625 20.0376 21.1125 19.3126C21.375 18.5876 21.375 17.9751 21.2875 17.8376C21.2 17.7001 21.0125 17.6376 20.7 17.4876Z" fill="#181945"/>
                                </svg>
                            </div>
                        </div>
                        <div class="dropdown dropleft" id="divMenuzinho" runat="server">
                            <button class=" dropdown-toggle" type="button" id="dropdownMenuButton" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                <img src="../assets/image/option.svg" alt="">
                            </button>
                            
                            <div class="dropdown-menu text-right" aria-labelledby="dropdownMenuButton" >
                              <asp:LinkButton ID="butReenviarEmail" runat="server" Class="dropdown-item"  CommandArgument='<%# Eval("ras_id") %>'>Reenviar por email</asp:LinkButton>
                               <asp:LinkButton ID="butReenviarWhatsapp" runat="server" class="dropdown-item" CommandArgument='<%# Eval("ras_id") %>'>Reenviar por whatsapp</asp:LinkButton>
                                
                            </div>
                        </div>
                    </div>
                </div>
            </div>
                     </ItemTemplate>
				</asp:repeater>
                    <asp:TextBox ID="tbPaginacao" runat="server" Visible="false" Text="20"></asp:TextBox>
                    <asp:Button ID="butCarregar" runat="server" Text="+Carregar próximos" class="btn bt-save text-uppercase ml-3 btn-sm"/>
                 </div>

                </div>
            </div>
        </section>
    </main>
               </ContentTemplate>
        
     </asp:UpdatePanel>
</asp:Content>
