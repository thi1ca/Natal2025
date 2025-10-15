<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="_bkp_index.aspx.vb" MasterPageFile="~/semMenu.Master" Inherits="Torra._bkp_index" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <div class="row no-gutters">
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 form-group">
                        <span class="has-float-label mb-2 in-cpf">
                            <label for="cpf" class="floatlabel color1">Informe seu CPF</label>                            
                            <asp:TextBox ID="tbcpf" class="form-control form-control-lg cpf" name="cpf" inputmode="numeric" placeholder="CPF" minlength="14" required="True" runat="server"></asp:TextBox>
                        </span>
                    </div>
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 mb-0 form-group input-senha">
                        <span class="has-float-label mb-2 in-senha">
                            <label for="senha" class="floatlabel color2">Senha</label>
                            <asp:TextBox ID="tbSenha" runat="server" class="form-control form-control-lg senha" name="senha"  placeholder="Senha" minlength="6" required="True" TextMode="Password"></asp:TextBox>
                            <img src="assets/image/eye.svg" alt="Visualizar" class="eye">
                        </span>
                    </div>
                    <a href="forgotPassword.aspx" target="_self" class="mb-4 d-block text-white text-decoration no-password">Esqueceu a senha?</a>                    
                    <asp:Button ID="btLogin" runat="server" Text="ENTRAR" class="btn btn-primary bt-step btn-lg btn-block mt-4"/>
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 my-4 text-white align-items-center d-flex separate">
                        <p>OU</p>
                    </div>
                    <a class="btn btn-primary bt-inline btn-lg btn-block" href="firstAcess.aspx" role="button">MEU PRIMEIRO ACESSO</a>
                </div>
           </asp:Content>