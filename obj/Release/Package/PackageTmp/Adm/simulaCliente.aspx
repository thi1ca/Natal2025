<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Adm/admLogado.Master" CodeBehind="simulaCliente.aspx.vb" Inherits="Natal_torra.simulaCliente" validateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <main role="main" class="container mb-5">
        <section  class="mb-3 mb-md-5">
            <div class="row mt-3 mt-md-5 align-items-center">
                <div class="col-8 col-sm-8 col-md-6 col-lg-6 col-xl-6 text-left text-sm-left text-md-left text-lg-left text-xl-left">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb p-0 ">
                            <li class="breadcrumb-item"><a href="dashboard.aspx">Dashboard</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Simula Cliente</li>
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
                        <h5 class="py-2 py-md-0"><img src="../assets/image/filter.svg" alt=""> Informe o cli_id:</h5>
                        <div class="searchform">
                            <asp:TextBox ID="tbCliId" runat="server" class="form-control filter-name" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-mg" placeholder="ID do cliente" MaxLength="8"></asp:TextBox>                            
                   
                        </div>
                   
                    </div>
                   <asp:Button ID="btnFiltrar" runat="server" Text="Autenticar" class="btn bt-save text-uppercase ml-3 btn-md d-none d-md-block" /> 
                </div>

                 <div class="row"><p></p></div>

                 <div class="row">
                    <div class="bt-filter col-4 col-sm-4 col-md-5 col-lg-5 col-lx-5 text-left">
                        <h5 class="py-2 py-md-0"><img src="../assets/image/filter.svg" alt=""> Informe o cup_id:</h5>
                        <div class="searchform">
                            <asp:TextBox ID="tbCupId" runat="server" class="form-control filter-name" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-mg" placeholder="ID do cupom" MaxLength="8"></asp:TextBox>                            
                   
                        </div>
                   
                    </div>
                   <asp:Button ID="butGerar" runat="server" Text="Corrigir Números da Sorte" class="btn bt-save text-uppercase ml-3 btn-md d-none d-md-block" /> 
                     
                </div>

                 <br /> <br />
                 <div class="row">
                    <div class="bt-filter col-4 col-sm-4 col-md-5 col-lg-5 col-lx-5 text-left">
                        <h5 class="py-2 py-md-0"><img src="../assets/image/filter.svg" alt=""> Texto Email:</h5>
                        <div class="searchform">Olá @Cliente, tudo bem? 
                            <asp:TextBox ID="TbEmail" runat="server" class="form-control filter-name" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-mg" placeholder="ID do cliente" TextMode="MultiLine" Rows="3"></asp:TextBox>                            
                   
                        </div>
                   
                    </div>
                     <div class="bt-filter col-4 col-sm-4 col-md-5 col-lg-5 col-lx-5 text-left">
                        <h5 class="py-2 py-md-0"><img src="../assets/image/filter.svg" alt=""> Texto Whatsapp:</h5>
                        <div class="searchform">
                            <asp:TextBox ID="tbWhatsapp" runat="server" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-mg"  TextMode="MultiLine" Rows="3"></asp:TextBox>                                               
                        </div>                   
                    </div>
                  
                       
                   
                </div>
                   <br /> <asp:Button ID="butEmail" runat="server" Text="Enviar Email" class="btn bt-save text-uppercase ml-3 btn-md d-none d-md-block" />          <br />
                     <asp:Button ID="butWhatsapp" runat="server" Text="Enviar WhatsApp" class="btn bt-save text-uppercase ml-3 btn-md d-none d-md-block" />    
            </div>
                <p></p>
                <p></p>

              
        </section>


         </main>
</asp:Content>
