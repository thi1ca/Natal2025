<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/comMenu.Master" CodeBehind="winners.aspx.vb" Inherits="Torra.winners" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="row no-gutters">
            <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 box-ganha position-relative">
                <img src="assets/image/coroa.png" alt="Coroa Ganhador">
                <h3 class="text-white orange-bg py-3 text-right">
                    <%=qtdVencedores %> clientes foram <br><strong>Premiados</strong></h3>
            </div>
            <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 pb-1 pt-3">
                <h6 class="text-blue text-left">
                    Confira os últimos ganhadores:</h6>
            </div>
            <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 d-flex flex-column ganhadores">
                  <asp:repeater id="Repeater1" runat="server" >
					<ItemTemplate>
                    <div class="card mb-2 text-blue">
                        <div class="row no-gutters">
                            <div class="col-3 d-flex justify-content-center align-items-center">
                                <img src="assets/image/crown.png" alt="Ganhador" class="w-50">
                            </div>
                            <div class="col-9 text-left">
                                <div class="card-body">
                                    <h2 class="m-0 name-winners"><%# Container.DataItem("cli_nome") %> <span></span></h2>
                                    <p class="m-0">Loja <span><%# Container.DataItem("loj_nome") %></span> - <small><%# Convert.ToDateTime(Container.DataItem("cup_cupom_data")).ToString("dd/MM/yyyy") %></small></p>
                                </div>
                            </div>
                        </div>
                    </div>
                        </ItemTemplate>
                      </asp:repeater>
                      


            </div>
        </div>
</asp:Content>
