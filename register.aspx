<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/semMenu.Master" CodeBehind="register.aspx.vb" Inherits="Natal2025.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <div class="row no-gutters">
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 mb-4">
                        <h3 class="text-blue text-left">
                            <strong>CPF: </strong><asp:Label ID="labCPF" runat="server" Text="000.000.000-00"></asp:Label></h3>
                    </div>
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 form-group">
                        <span class="has-float-label mb-2 in-nome">
                            <label for="ctl00$ContentPlaceHolder1$tbNome" >Nome Completo</label>
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
                     <div class="col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 form-group">
                        <span class="has-float-label mb-2 in-genero">
                            <div class="input-group select-mist form-control-lg pl-0">
                                
                                <label for="ctl00$ContentPlaceHolder1$ddlGenero" class="color3">Gênero</label>
                                    <asp:DropDownList ID="ddlGenero" runat="server" CssClass="custom-select"></asp:DropDownList>
                                <div class="input-group-append">
                                    <button class="btn btn-outline-secondary" type="button"><img src="../assets/image/arrow-down.svg" alt="" class="w-75"></button>
                                </div>
                            </div>
                        </span>
                    </div>
                     <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 form-group">
                        <span class="has-float-label mb-2 in-birthday">
                            <label for="ctl00$ContentPlaceHolder1$tbBirthday" class="color3">Nascimento</label> 
                            <asp:TextBox ID="data" name="ContentPlaceHolder1_data" runat="server" class="form-control" inputmode="numeric" placeholder="00/00/0000" MaxLength="10" required="True"></asp:TextBox>
                            
                        </span>
                    </div>
                    <asp:Button ID="butAvancar" class="btn btn-primary btn-lg btn-block" runat="server" Text="ATUALIZAR INFORMAÇÕES" />
                    <asp:LinkButton ID="butVoltar" runat="server" PostBackUrl="~/index.aspx" CssClass="btn-lg btn-block voltar-login text-blue text-center mt-4 mb-4"><img src="assets/image/arrow-left.svg" alt=""/> SAIR SEM EDITAR</asp:LinkButton>
                </div>

          
</asp:Content>
