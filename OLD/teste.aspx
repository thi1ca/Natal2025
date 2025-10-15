<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="teste.aspx.vb" Inherits="Torra.teste" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="butWhatsapp" runat="server" Text="Testar Whatsapp" />
            <br />
            <br />
            <br />
            <asp:TextBox ID="tbEmail" runat="server" TextMode="Email" ToolTip="Email"></asp:TextBox>
            <asp:Button ID="butEmail" runat="server" Text="Enviar Email" />
            <br />
            <br />
            <br />
            Testar Pergunta 3 - Valor de compra<br />
            <br />
            <asp:TextBox ID="tbValor" runat="server"></asp:TextBox>
            <asp:Button ID="butSimular" runat="server" Text="Simular" />
            <br />
            <br />
            1) <asp:Label ID="labResposta1" runat="server" Text=""></asp:Label>
            <br />
            <br />
            2)
            <asp:Label ID="labResposta2" runat="server" Text=""></asp:Label>
            <br />
            <br />
            3)
            <asp:Label ID="labResposta3" runat="server" Text=""></asp:Label>
            <br />
            <br />
            4)
            <asp:Label ID="labCorreto" runat="server" Text=""></asp:Label>
            <br />
            <br />

               <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 form-group">
                       <p class="text-white text-center">
                           <asp:Label ID="labPergunta" runat="server" Text="Selecione..."></asp:Label></p>
                       <div class="mb-3 d-flex flex-column flex-md-row flex-column-reverse">
                            <div class="custom-control custom-radio custom-control-inline w-100 mb-3">
                                <asp:RadioButton ID="rbResposta1" class="custom-control-input" runat="server" GroupName="resposta"/>
                                <asp:Label ID="Label1" class="custom-control-label text-blue w-100 my-3" for="loja1" runat="server" Text="Loja 1"></asp:Label>
                                <asp:TextBox ID="tbResposta1" runat="server" Visible="False" Text="0" ReadOnly="True" MaxLength="1"></asp:TextBox>
                            </div>
                            <div class="custom-control custom-radio custom-control-inline w-100 mb-3">
                                <asp:RadioButton ID="rbResposta2" class="custom-control-input" runat="server" GroupName="resposta" />
                                <asp:Label ID="Label2" class="custom-control-label text-blue w-100 my-3" for="loja2" runat="server" Text="Loja 2"></asp:Label>
                                <asp:TextBox ID="tbResposta2" runat="server" Visible="False" Text="0" ReadOnly="True" MaxLength="1"></asp:TextBox>
                            </div>
                            <div class="custom-control custom-radio custom-control-inline w-100 mb-3">
                               
                                <asp:RadioButton ID="rbResposta3" class="custom-control-input" runat="server" GroupName="resposta"  />
                                <asp:Label ID="Label3" class="custom-control-label text-blue w-100 my-3" for="loja3" runat="server" Text="Loja 3"></asp:Label>
                                <asp:TextBox ID="tbResposta3" runat="server" Visible="False" Text="0" ReadOnly="True" MaxLength="1"></asp:TextBox>
                            </div>
                        </div>
                    </div>
            <asp:Label ID="labscript" runat="server" Text="" Visible="false"></asp:Label>
        </div>
    </form>
</body>
</html>
