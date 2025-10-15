<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Adm/admLogado.Master" CodeBehind="winner.aspx.vb" Inherits="Natal_torra.winner" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
     
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
    <main role="main" class="container mb-5">

        
        <section  class="mb-3 mb-md-5">
            <div class="row mt-3 mt-md-5">
                <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-left text-sm-left text-md-left text-lg-left text-xl-left">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb p-0 ">
                            <li class="breadcrumb-item"><a href="dashboard.aspx">Dashboard</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Procurar Vencedor</li>
                        </ol>
                    </nav>
                </div>
            </div>
        </section>
       
        <section class="create-page pb-5">
            <div class="formSetup">
                <div class="row no-gutters">
                    <div class="col-12 form-group">
                        <span class="has-float-label">
                            <label for="nome" class="floatlabel">1 Prêmio</label>
                            <asp:TextBox ID="tbPremio1" runat="server" class="form-control form-control-lg mb-3" type="text" placeholder="1° Prêmio" MaxLength="6"></asp:TextBox>
                        </span>
                    </div>
                    <div class="col-12 form-group">
                        <span class="has-float-label">
                            <label for="nome" class="floatlabel">2 Prêmio</label>
                            <asp:TextBox ID="tbPremio2" runat="server" class="form-control form-control-lg mb-3" type="text" placeholder="2° Prêmio" MaxLength="6"></asp:TextBox>
                        </span>
                    </div>
                    <div class="col-12 form-group">
                        <span class="has-float-label">
                            <label for="nome" class="floatlabel">3 Prêmio</label>
                            <asp:TextBox ID="tbPremio3" runat="server" class="form-control form-control-lg mb-3" type="text" placeholder="3° Prêmio" MaxLength="6"></asp:TextBox>
                        </span>
                    </div>
                    <div class="col-12 form-group">
                        <span class="has-float-label">
                            <label for="nome" class="floatlabel">4 Prêmio</label>
                            <asp:TextBox ID="tbPremio4" runat="server" class="form-control form-control-lg mb-3" type="text" placeholder="4° Prêmio" MaxLength="6"></asp:TextBox>
                        </span>
                    </div>
                    <div class="col-12 form-group">
                        <span class="has-float-label">
                            <label for="nome" class="floatlabel">5 Prêmio</label>
                            <asp:TextBox ID="tbPremio5" runat="server" class="form-control form-control-lg mb-3" type="text" placeholder="5° Prêmio" MaxLength="6"></asp:TextBox>
                        </span>
                    </div>
                   
                   

                     <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-left text-md-center">
                        <div class="custom-control custom-switch custom-switch-md">
                            <asp:Label ID="labResultado" runat="server" Text=""></asp:Label>                            
                        </div>
                    </div>                    
                   
                    <div class="col-6 col-sm-6 col-md-6 col-lg-6 col-xl-6 text-right">
                        <asp:Button ID="butBuscar" runat="server" Text="PROCURAR" class="btn bt-save text-uppercase mt-3 btn-md"></asp:Button>
                    </div>
                </div>
            </div>
        </section>
       
    </main>
         </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="butBuscar" />
        </Triggers>
     </asp:UpdatePanel>
</asp:Content>
