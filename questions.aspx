<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="questions.aspx.vb" MasterPageFile="~/semMenu.Master"  Inherits="Natal2025.questions" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <div class="row no-gutters">
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 mb-4">
                        <h3 class="text-blue text-center">
                            Selecione a <strong>resposta correta</strong></h3>
                    </div>
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 form-group">
                       <p class="text-blue text-center">
                           <asp:Label ID="labPergunta" runat="server" Text="Selecione..."></asp:Label></p>
                       <div class="mb-3 d-flex flex-column flex-md-row flex-wrap">
                         <div class="custom-control custom-radio custom-control-inline form-check input-group-lg w-100 mb-3 mr-0">
                                <asp:RadioButton ID="rbResposta1"  class="form-check-input " runat="server" GroupName="resposta"/>
                                <label for="ContentPlaceHolder1_rbResposta1" class="custom-control-label text-blue form-check-label w-100 my-3">
                                    <asp:Label ID="labResposta1" for="loja1" runat="server" Text="Loja 1"></asp:Label>
                                </label>
                                <asp:TextBox ID="tbResposta1" runat="server" Visible="False" Text="0" ReadOnly="True" MaxLength="1"></asp:TextBox>
                            </div>
                            <div class="custom-control custom-radio custom-control-inline form-check input-group-lg w-100 mb-3 mr-0">
                                <asp:RadioButton ID="rbResposta2" class="form-check-input "  runat="server" GroupName="resposta" />
                                <label for="ContentPlaceHolder1_rbResposta2" class="custom-control-label text-blue form-check-label w-100 my-3">
                                    <asp:Label ID="labResposta2" for="loja2" runat="server" Text="Loja 2"></asp:Label>
                                </label>
                                <asp:TextBox ID="tbResposta2" runat="server" Visible="False" Text="0" ReadOnly="True" MaxLength="1"></asp:TextBox>
                            </div>
                            <div class="custom-control custom-radio custom-control-inline form-check input-group-lg w-100 mb-3 mr-0">
                               
                                <asp:RadioButton ID="rbResposta3"  class="form-check-input " runat="server" GroupName="resposta"  />
                                <label for="ContentPlaceHolder1_rbResposta3" class="custom-control-label text-blue form-check-label w-100 my-3">
                                    <asp:Label ID="labResposta3" for="loja3" runat="server" Text="Loja 3"></asp:Label>
                                </label>
                                <asp:TextBox ID="tbResposta3" runat="server" Visible="False" Text="0" ReadOnly="True" MaxLength="1"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <asp:Button ID="butProximo" class="btn btn-primary btn-lg btn-block" runat="server" Text="AVANÇAR" /><asp:TextBox ID="tbCorreto" runat="server" Visible="False" Text="0" ReadOnly="True" MaxLength="1"></asp:TextBox>
                    
                    <a class="btn-lg btn-block voltar-login text-blue text-center mt-4" href="index.aspx" role="button"><img src="assets/image/arrow-left.svg" alt=""> VOLTAR AO LOGIN</a>
                </div>
             </asp:Content>
