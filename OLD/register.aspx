<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="register.aspx.vb" MasterPageFile="~/semMenu.Master" Inherits="Torra.register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <div class="row no-gutters">
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 mb-4">
                        <h3 class="text-white text-left">
                            <strong>CPF: </strong><asp:Label ID="labCPF" runat="server" Text="000.000.000-00"></asp:Label></h3>
                    </div>
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 form-group">
                        <span class="has-float-label mb-2 in-nome">
                            <label for="nome" >Nome Completo</label>
                            <asp:TextBox ID="tbNome" runat="server" class="form-control form-control-lg nome" MaxLength="50" placeholder="Ex.: Marcelo Silva.." required="True"></asp:TextBox>
                        </span>
                    </div>
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 form-group">
                        <span class="has-float-label mb-2 in-email">                           
                            <label for="email" class="floatlabel color2">E-mail</label>
                             <asp:TextBox ID="tbEmail" runat="server" class="form-control form-control-lg email" MaxLength="50" placeholder="email@gmail.com.br" TextMode="Email" required="True"/>
                        </span>
                    </div>
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 form-group">
                        <span class="has-float-label mb-2 in-phones">
                            <label for="phones" class="floatlabel color3">Celular</label>
                            <asp:TextBox ID="tbCelular" runat="server" class="form-control form-control-lg phones" MaxLength="15" placeholder="(00) 00000-00" TextMode="Phone" required="True"/>                            
                        </span>
                    </div><!--
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 mb-2 form-group input-senha">
                        <span class="has-float-label mb-2 in-senha">
                            <label for="senha" class="floatlabel color4">Senha</label>
                           
                            <img src="assets/image/eye.svg" alt="Visualizar" class="eye">
                        </span>
                    </div>
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 mb-2 form-group input-senha">
                        <span class="has-float-label mb-2 in-repsenha">
                            <label for="senhaRec" class="floatlabel color5">Repeta a senha</label>
                            
                            <img src="assets/image/eye.svg" alt="Visualizar" class="eye">
                        </span>
                    </div>
                     <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 mb-4 form-group input-senha">
                        <span class="has-float-label in-avatar">
                            <label for="inputGroupFile01" class="floatlabel color6">Imagem Avatar</label>
                            <div class="input-group input-group-lg">
                                <div class="custom-file py-4">
                                    <input type="file" class="custom-file-input form-control form-control-lg" id="inputGroupFile01" aria-describedby="inputGroupFileAddon01">
                                    <label class="custom-file-label col-form-label-lg d-flex align-items-center" for="inputGroupFile01">Selecione o arquivo</label>
                                </div>
                            </div>
                        </span>
                    </div> -->
                    <asp:Button ID="butAvancar" class="btn btn-primary btn-lg btn-block" runat="server" Text="ATUALIZAR INFORMAÇÕES" />
                </div>
    <script src="assets/js/jquery.email-autocomplete.js"></script>
    <script>
        (function ($) {
            $(function () {
                $(".email").emailautocomplete({
                    domains: ["example.com"] //add your own domains
                });
            });
        }(jQuery));
    </script>
              </asp:Content>

    

   
  
