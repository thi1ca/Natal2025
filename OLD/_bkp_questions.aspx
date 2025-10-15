<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/semMenu.Master" CodeBehind="_bkp_questions.aspx.vb" Inherits="Torra._bkp_questions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <div class="row no-gutters">
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 mb-4">
                        <h3 class="text-white text-center">
                            Selecione a <strong>resposta correta</strong></h3>
                    </div>
                    <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 form-group">
                       <p class="text-white text-center">
                           <asp:Label ID="labPergunta" runat="server" Text="Selecione..."></asp:Label></p>
                       <div class="mb-3 d-flex flex-column flex-md-row flex-column-reverse">
                            <div class="custom-control custom-radio custom-control-inline w-100 mb-3">
                                <asp:RadioButton ID="rbResposta1"  runat="server" GroupName="resposta"/>
                                <asp:Label ID="labResposta1" class="custom-control-label text-blue w-100 my-3" for="loja1" runat="server" Text="Loja 1"></asp:Label>
                                <asp:TextBox ID="tbResposta1" runat="server" Visible="False" Text="0" ReadOnly="True" MaxLength="1"></asp:TextBox>
                            </div>
                            <div class="custom-control custom-radio custom-control-inline w-100 mb-3">
                                <asp:RadioButton ID="rbResposta2"  runat="server" GroupName="resposta" />
                                <asp:Label ID="labResposta2" class="custom-control-label text-blue w-100 my-3" for="loja2" runat="server" Text="Loja 2"></asp:Label>
                                <asp:TextBox ID="tbResposta2" runat="server" Visible="False" Text="0" ReadOnly="True" MaxLength="1"></asp:TextBox>
                            </div>
                            <div class="custom-control custom-radio custom-control-inline w-100 mb-3">
                               
                                <asp:RadioButton ID="rbResposta3"  runat="server" GroupName="resposta"  />
                                <asp:Label ID="labResposta3" class="custom-control-label text-blue w-100 my-3" for="loja3" runat="server" Text="Loja 3"></asp:Label>
                                <asp:TextBox ID="tbResposta3" runat="server" Visible="False" Text="0" ReadOnly="True" MaxLength="1"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <asp:Button ID="butProximo" class="btn btn-primary btn-lg btn-block" runat="server" Text="AVANÇAR" /><asp:TextBox ID="tbCorreto" runat="server" Visible="False" Text="0" ReadOnly="True" MaxLength="1"></asp:TextBox>
                    
                    <a class="btn-lg btn-block voltar-login text-white text-center mt-4" href="index.aspx" role="button"><img src="assets/image/arrow-left.svg" alt=""> VOLTAR AO LOGIN</a>
                </div>
             </asp:Content>
