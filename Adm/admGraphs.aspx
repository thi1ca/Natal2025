<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Adm/admLogado.Master" CodeBehind="admGraphs.aspx.vb" Inherits="Natal2025.admGraphs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <main role="main" class="container mb-5">
        <section class="filter">
            <div class="formSetup">
                <div class="row mt-3 mt-md-5 align-items-center">
                    <div class="col-8 col-smfa-rotate-180 col-md-6 col-lg-6 col-xl-6 text-left text-sm-left text-md-left text-lg-left text-xl-left">
                        <nav aria-label="breadcrumb">
                            <ol class="breadcrumb p-0 ">
                                <li class="breadcrumb-item"><a href="../dashboard.html">Dashboard</a></li>
                                <li class="breadcrumb-item"><a href="raspe-e-ganhe.html">Raspe & Ganhe</a></li>
                                <li class="breadcrumb-item active" aria-current="page">Info & Estatísticas</li>
                            </ol>
                        </nav>
                    </div>
                    <div class="col-4 col-sm-4 col-md-6 col-lg-6 col-xl-6 text-right text-sm-right text-md-right text-lg-right text-xl-right d-flex d-sm-none justify-content-end">
                        <button type="submit" class="btn bt-save text-uppercase ml-3 btn-md d-flex d-md-none justify-content-end">Filtrar</button>
                    </div>
                </div>
            </div>
        </section>
        <section class="filter">
            <div class="formSetup">
                <div class="row">
                    <div class="bt-filter col-4 col-sm-4 col-md-5 col-lg-5 col-lx-5 text-left">
                        <h5 class="py-2 py-md-0"><img src="../assets/image/filter.svg" alt=""> Lojas</h5>
                        <div class="searchform">
                           <asp:DropDownList ID="ddlCampanha" runat="server" class="custom-select"></asp:DropDownList>
                        </div>
                        <div class="result"></div>
                    </div>
                    <div class="filter-date col-4 col-sm-4 col-md-5 col-lg-5 col-lx-5 text-left">
                        <h5 class="py-2 py-md-0"><img src="../assets/image/date.svg" alt=""> Período</h5>
                        <div class="dates d-md-flex">
                             <div class="start_date input-group mb-1 mb-md-4 mr-2">
                                <asp:TextBox ID="tbDataInicio" runat="server" class="form-control start_date" placeholder="Data inicial" MaxLength="10"></asp:TextBox>
                                <div class="input-group-append">
                                    <span class="fa fa-calendar input-group-text start_date_calendar" aria-hidden="true "><img src="../assets/image/date-fill.svg" alt=""></span>
                                </div>
                            </div>
                            <div class="end_date input-group mb-1 mb-md-4 ml-2">
                                <asp:TextBox  ID="tbDataFim" runat="server" class="form-control end_date" placeholder="Data final" MaxLength="10"></asp:TextBox>	
                                <div class="input-group-append">
                                    <span class="fa fa-calendar input-group-text end_date_calendar" aria-hidden="true "><img src="../assets/image/date-fill.svg" alt=""></span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="filter-order col-3 col-sm-3 col-md-2 col-lg-2 col-lx-2">
                        <h5 class="py-2 py-md-0">.</h5>
                        <div class="select-radio text-rigth d-md-flex justify-content-end">
                            <asp:Button ID="butFiltrar" runat="server" Text="Filtrar" class="btn bt-save text-uppercase ml-3 btn-sm"/>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <section class="create-page mb-4 mt-4">
            <div class="container px-0">
                <div class="row">
                    <div class="col-12 pb-3">
                        <h4>Informações Gerais</h2>
                    </div>
                    <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 pb-2">
                        <div class="chart">
                            <div class="card text-white mb-2 mb-md-3 text-left">
                                <div class="card-body d-flex">
                                    <div class="row align-items-center no-gutters w-100">
                                        <div class="col-6">
                                            <img src="../assets/image/chart-line.svg">
                                            <h5 class="card-title">Raspada <strong class="d-block">Hoje</strong></h5>
                                        </div>
                                        <div class="col-6 text-right">
                                            <h6><img src="../assets/image/people.svg"> <asp:Label ID="labRaspadosHoje" runat="server" Text=""></asp:Label></h6>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 pb-2">
                        <div class="chart">
                            <div class="card text-white mb-2 mb-md-3 text-left">
                                <div class="card-body d-flex">
                                    <div class="row align-items-center no-gutters w-100">
                                        <div class="col-6">
                                            <img src="../assets/image/chart-line.svg">
                                            <h5 class="card-title">Raspadas <strong class="d-block">Totais</strong></h5>
                                        </div>
                                        <div class="col-6 text-right">
                                            <h6><img src="../assets/image/people.svg"> <asp:Label ID="labRaspadosTotal" runat="server" Text=""></asp:Label></h6>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 pb-2">
                        <div class="chart">
                            <div class="card text-white mb-2 mb-md-3 text-left" style="background: #FF5101;">
                                <div class="card-body d-flex">
                                    <div class="row align-items-center no-gutters w-100">
                                        <div class="col-6">
                                            <img src="../assets/image/chart-line.svg">
                                            <h5 class="card-title">Raspadas <strong class="d-block">Premiadas</strong></h5>
                                        </div>
                                        <div class="col-6 text-right">
                                            <h6><img src="../assets/image/people.svg"> <asp:Label ID="labRaspadosPremiados" runat="server" Text=""></asp:Label></h6>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    
                    
                    <div class="col-12 pb-3">
                        <h4>Raspe & Ganhe por mês</h2>
                    </div>
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 pb-5">
                        <canvas id="myCartNew" width="200" height="50"></canvas>
                    </div>



                    <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 pb-2">
                        <div class="chart">
                            <div class="card text-white mb-2 mb-md-3 text-left " style="background: #FF5101;">
                                <div class="card-body d-flex">
                                    <div class="row align-items-center no-gutters w-100">
                                        <div class="col-6">
                                            <img src="../assets/image/chart-line.svg">
                                            <h5 class="card-title">Clientes <strong class="d-block">Hoje</strong></h5>
                                        </div>
                                        <div class="col-6 text-right">
                                            <h6><img src="../assets/image/people.svg"> <asp:Label ID="labClientesHoje" runat="server" Text=""></asp:Label></h6>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 pb-2">
                        <div class="chart">
                            <div class="card text-white mb-2 mb-md-3 text-left">
                                <div class="card-body d-flex">
                                    <div class="row align-items-center no-gutters w-100">
                                        <div class="col-6">
                                            <img src="../assets/image/chart-line.svg">
                                            <h5 class="card-title">Clientes <strong class="d-block">Totais</strong></h5>
                                        </div>
                                        <div class="col-6 text-right">
                                            <h6><img src="../assets/image/people.svg"> <asp:Label ID="labClientestotais" runat="server" Text=""></asp:Label></h6>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-12 col-sm-12 col-md-4 col-lg-4 col-xl-4 pb-2">
                        <div class="chart">
                            <div class="card text-white mb-2 mb-md-3 text-left">
                                <div class="card-body d-flex">
                                    <div class="row align-items-center no-gutters w-100">
                                        <div class="col-6">
                                            <img src="../assets/image/chart-line.svg">
                                            <h5 class="card-title">Cupons <strong class="d-block">não raspados</strong></h5>
                                        </div>
                                        <div class="col-6 text-right">
                                            <h6><img src="../assets/image/people.svg"><asp:Label ID="labCupons" runat="server" Text=""></asp:Label></h6>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>



                    <div class="col-12 pb-3">
                        <h4>Dados por mês e dias</h2>
                    </div>
                    <div class="col-12 col-sm-12 col-md-12 col-lg-6 col-xl-6 pb-5">
                        <canvas id="myChart" width="200" height="100"></canvas>
                    </div>
                    <div class="col-12 col-sm-12 col-md-12 col-lg-6 col-xl-6 pb-5">
                        <canvas id="myLineChart" width="200" height="100"></canvas>
                    </div>
                    <div class="col-12 pb-3">
                        <h4>Dados em Pizza</h2>
                    </div>
                    <div class="col-6 col-sm-6 col-md-4 col-lg-4 col-xl-4 pb-5">
                        <canvas id="myDoughnutChart" width="200" height="50"></canvas>
                    </div>
                    <div class="col-6 col-sm-6 col-md-4 col-lg-4 col-xl-4 pb-5">
                        <canvas id="myPieChart" width="200" height="50"></canvas>
                    </div>
                    <div class="col-6 col-sm-6 col-md-4 col-lg-4 col-xl-4 pb-5">
                        <canvas id="myPolarArea" width="200" height="50"></canvas>
                    </div>
                </div>
            </div>
            
            
            
            
        </section>
        
    </main>
   
    
    
  
        
</asp:Content>
