<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/semMenu.Master" CodeBehind="check.aspx.vb" Inherits="Natal_torra.check" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container text-center">
                    <h1><img src="assets/image/Logo_Raspe&Ganhe.svg" alt="Raspe & Ganhe"></h1>
                </div>
                <div class="container">
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-left mt-4 mb-5">
                        <h3 class="text-blue text-left title-notfound">
                            <strong>CPF:</strong> <asp:Label ID="labCPF" runat="server" Text="000.000.000-00"></asp:Label><br>
                            <p class="text-white pt-2">Documento identificado.<br /> Por favor, preencha seus dados.</p>
                        </h3>
                    </div>
                </div>
                
                <div class="container text-center">
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 form-group">
                        <span class="has-float-label mb-2 in-nome">
                            <label for="ctl00$ContentPlaceHolder1$tbNome">Nome Completo</label>
                             <asp:TextBox ID="tbNome" runat="server" class="form-control form-control-lg nome" MaxLength="50" placeholder="Ex.: Marcelo Silva.." required="True"></asp:TextBox>
                        </span>
                    </div>
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 form-group">
                        <span class="has-float-label mb-2 in-email">                           
                            <label for="ctl00$ContentPlaceHolder1$tbEmail" class="color2">E-mail</label>
                              <asp:TextBox ID="tbEmail" runat="server" class="form-control form-control-lg email" MaxLength="50" placeholder="email@gmail.com.br" TextMode="Email" required="True"/>
                        </span>
                    </div>
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 form-group">
                        <span class="has-float-label mb-2 in-phones">
                            <label for="ctl00$ContentPlaceHolder1$tbCelular" class="color3">Celular</label>
                       <asp:TextBox ID="tbCelular" runat="server" class="form-control form-control-lg phones" MaxLength="15" placeholder="(00) 00000-0000" TextMode="Phone" required="True"/>                            
                        </span>
                    </div>
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 mt-5 text-center">
            <asp:Button ID="butAvancar" class="btn btn-primary btn-lg btn-block" runat="server" Text="ENVIAR INFORMAÇÕES" />
                    </div>
                </div>
</asp:Content>
