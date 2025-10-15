<%@ Page Title="Lojas Torra - Adicionar ou Editar Usuário" Language="vb" AutoEventWireup="false" MasterPageFile="~/Adm/admLogado.Master" CodeBehind="admUsers_edit.aspx.vb" Inherits="Natal_torra.admUsers_edit" %>
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
                            <li class="breadcrumb-item" aria-current="page"><a href="admUsers.aspx">Usuários</a></li>
                            <li class="breadcrumb-item active" aria-current="page">Adicionar</li>
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
                            <label for="nome" class="floatlabel">Nome do usuário</label>
                            <asp:TextBox ID="tbNome" runat="server" class="form-control form-control-lg mb-3" type="text" placeholder="Ex.:João Pedro da Silva*"></asp:TextBox>
                        </span>
                    </div>
                    <div class="col-12 form-group">
                        <span class="has-float-label">
                            <label for="email" class="floatlabel">E-mail</label>
                            <asp:TextBox ID="tbEmail" runat="server" class="form-control form-control-lg mb-3" type="email" placeholder="seuemail@dominio.com.br"></asp:TextBox>
                        </span>
                    </div>
                    <div class="col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 pr-0 pr-md-2 form-group">
                        <span class="has-float-label">
                            <label for="phone" class="floatlabel">Celular</label>
                            <asp:TextBox ID="tbCelular" runat="server" class="form-control form-control-lg mb-3 phones" type="phone" placeholder="DDD + 99999-9999"></asp:TextBox>
                        </span>
                    </div>
                    <div class="col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 pl-0 pl-md-2 form-group">
                        <span class="has-float-label">
                            <div class="input-group select-mist mb-3">
                                <asp:DropDownList ID="ddlPerfil" runat="server" class="custom-select" aria-label="Example select with button addon"></asp:DropDownList>
                                <!--
                                <select class="custom-select" id="inputGroupSelect04" aria-label="Example select with button addon">
                                    <option value="Master">Master</option>
                                    <option value="Administrador">Administrador</option>
                                    <option value="Usuario">Usuário</option>
                                    <option value="Clientes">Clientes</option>
                                </select>-->
                                <label for="phone">Selecione o Perfil</label>
                                <div class="input-group-append">
                                <button class="btn btn-outline-secondary" type="button"><img src="../assets/image/arrow-down.svg" alt="" class="w-75"></button>
                                </div>
                            </div>
                        </span>
                    </div>
                    <div id="divAvatar" class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12" runat="server">
                        <label for="inputGroupFile01" class="floatlabel">Imagem avatar</label>
                        <div class="input-group input-group-lg mb-3">
                            <div class="custom-file h-100">
                            <asp:FileUpload ID="tbFoto" runat="server" class="form-control form-control-lg" aria-describedby="inputGroupFileAddon01"></asp:FileUpload>
                            <!--<label class="custom-file-label col-form-label-lg d-flex align-items-center" for="inputGroupFile01">Selecione o arquivo</label>-->
                            </div>
                        </div>
                    </div>
                    <div id="divSenha" runat="server" class="col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 pr-0 pr-md-2 form-group">
                        <span class="has-float-label">
                            <label for="password" class="floatlabel">Senha *</label>
                            <div class="input-senha input-group input-group-lg mb-3">
                                <asp:TextBox ID="tbSenha" runat="server" type="password" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-lg" placeholder="*Mínimo 6 digitos"></asp:TextBox>
                                <div class="eye input-group-append">
                                    <span class="input-group-text"><img src="../assets/image/eye.svg"></span>
                                </div>
                            </div>
                        </span>
                    </div>
                    <div id="divSenha2" runat="server" class="col-12 col-sm-12 col-md-6 col-lg-6 col-xl-6 pl-0 pl-md-2 form-group">
                        <span class="has-float-label">
                            <label for="password-repeat" class="floatlabel">Repita a Senha *</label>
                            <div class="input-senha input-group input-group-lg mb-3">
                                 <asp:TextBox ID="tbSenha2" runat="server" type="password" class="form-control" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-lg" placeholder="*Repita a senha"></asp:TextBox>
                                <div class="eye input-group-append">
                                    <span class="input-group-text"><img src="../assets/image/eye.svg"></span>
                                </div>
                            </div>
                        </span>
                    </div>

                     <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-left text-md-right">
                        <div class="custom-control custom-switch custom-switch-md">
                            <input type="checkbox" class="custom-control-input" checked id="cbAtivo2" data-size="lg" runat="server">
                            <label class="custom-control-label" for="ContentPlaceHolder1_cbAtivo2">Ativar Cadastro</label>
                        </div>
                    </div>
                    
                    
                  
                    <div class="col-6 col-sm-6 col-md-6 col-lg-6 col-xl-6 text-left">
                        <asp:Button ID="btnCancel" runat="server" Text="CANCELAR" class="btn bt-cancel text-uppercase mt-3 btn-md"></asp:Button>
                    </div>
                    <div class="col-6 col-sm-6 col-md-6 col-lg-6 col-xl-6 text-right">
                        <asp:Button ID="butCadastrar" runat="server" Text="SALVAR" class="btn bt-save text-uppercase mt-3 btn-md"></asp:Button>
                        <asp:Button ID="butConfirmar" runat="server" Text="ATUALIZAR" class="btn btn-primary text-uppercase mt-3 btn-md"></asp:Button>
                    </div>
                </div>
            </div>
        </section>
       
    </main>
         </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="butCadastrar" />
        </Triggers>
     </asp:UpdatePanel>
</asp:Content>
