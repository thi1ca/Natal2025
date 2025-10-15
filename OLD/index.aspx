<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="index.aspx.vb" MasterPageFile="~/semMenu.Master" Inherits="Torra.index1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <div class="row no-gutters bt-cpf-incio">
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 mb-4">
                        <h3 class="text-white text-center">
                            <strong>Vamos começar?</strong><br>
                            Informe seu CPF para identificação</h3>
                    </div>
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 form-group mb-5 pb-5">
                        <span class="has-float-label mb-2 in-cpf">
                            <label for="cpf" class="floatlabel color1">Informe seu CPF</label>
                            <asp:TextBox ID="tbCPF" class="form-control form-control-lg cpf" inputmode="numeric" name="cpf" placeholder="CPF" runat="server" required></asp:TextBox>
                            
                        </span>
                    </div>
                    
                    <asp:Button ID="butProximo" class="btn btn-primary btn-lg btn-block" runat="server" Text="AVANÇAR" />
                    
                    
                </div>
           </asp:Content>

