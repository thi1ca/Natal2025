<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="teste.aspx.vb" Inherits="Natal2025.teste" Async="true"%>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
        <script language="javascript" type="text/javascript">
            // desabilita o botao 
            function disableButtonOnClick(oButton, sButtonText) {
                oButton.disabled = true;
                // altera o texto do botão
                oButton.value = sButtonText;
            }
        </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="tbCelular" runat="server" TextMode="Phone" ToolTip="Email"></asp:TextBox>
            <asp:DropDownList ID="ddlChip" runat="server"></asp:DropDownList>
            <asp:Button ID="butWhatsapp" runat="server" Text="Testar Whatsapp" />
            &nbsp;
            <asp:Button ID="butConexões" runat="server" Text="Testar Conexões" />
            <br />
            <br /> <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="True"></asp:GridView>
            <br />
            <br />
            <br />
            <asp:TextBox ID="tbEmail" runat="server" TextMode="Email" ToolTip="Email"></asp:TextBox>
            <asp:Button ID="butEmail" runat="server" Text="Enviar Email" />
            <br />
            <br />
            <br />
            <asp:Button ID="butWhatsappFeedback" runat="server" Text="Enviar Whatsapp de feedback" />
            <br />
            <asp:Label ID="labStatus" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="labscript" runat="server" Text="" Visible="false"></asp:Label>
            <br />
            <br />
             <asp:Button ID="butBancos" runat="server" Text="Testar Integração de bancos" />

              <br />
            <br />
             <asp:Button ID="butGiftCard" runat="server" Text="Cria GiftCard" />

             <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Botão" OnClick="Button1_Click" OnClientClick="disableButton('Button1'); return true;" />
             <br />
            <br />
             <asp:Button ID="butFuncionario" runat="server" Text="Atualiza Quem é funcionario" />

             <br />
            <br />
             <asp:Button ID="butFuncionario2" runat="server" Text="Atualiza Quem é funcionario um a um" />

              <br />
            <br />
             <asp:Button ID="butAPIClinte" runat="server" Text="testa a API de Cliente" />
            <asp:Label ID="labAPICliente" runat="server" Text=""></asp:Label>
        </div>

         <div>
            <canvas id="myDoughnutChart" width="200" height="50"></canvas>
        </div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    </form>
    <script type="text/javascript">
        var ctxvv = document.getElementById('myDoughnutChart');
        var myChart = new Chart(ctxvv, {
            type: "doughnut",
            data: {
                labels: ["Valor 1", "Valor 2", "Valor 3"],
                datasets: [{
                    label: "Valores",
                    data: chartData, // Usa os dados enviados do código VB.NET
                    backgroundColor: [
                        "rgb(255, 99, 132)",
                        "rgb(54, 162, 235)",
                        "rgb(255, 205, 86)"
                    ]
                }]
            },
            options: {
                plugins: {
                    legend: {
                        position: "bottom"
                    }
                }
            }
        });
    </script>
</body>
</html>
