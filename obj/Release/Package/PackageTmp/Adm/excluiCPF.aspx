<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Adm/admLogado.Master" CodeBehind="excluiCPF.aspx.vb" Inherits="Natal_torra.excluiCPF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main role="main" class="container mb-5 mt-5">
        <section  class="mb-3 mb-md-5">
            <div class="row mt-3 mt-md-5">
                <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 text-left text-sm-left text-md-left text-lg-left text-xl-left">
                    <nav aria-label="breadcrumb">
                        <ol class="breadcrumb p-0 ">
                            <li class="breadcrumb-item"><a href="dashboard.aspx">Dashboard</a></li>
                            <li class="breadcrumb-item" aria-current="page"><a href="excluiCPF.aspx">Excluir histórico CPF</a></li>
                        </ol>
                    </nav>
                </div>
            </div>
        </section>

        <section class="create-page pb-5">
            <div class="formSetup pb-5">
                <div class="row no-gutters">
                    <div class="col-12 form-group">
                        <span class="has-float-label">
                            <asp:CheckBox ID="cbCliente" runat="server" Text="Exclui Cliente?" />
                            <label for="nome" class="floatlabel">Excluir todo histórico do cliente</label>
                            <div class="input-group mb-3 input-bt">
                                <asp:TextBox ID="tbCPF" runat="server" class="form-control form-control-lg mb-0 cpf" type="text" placeholder="Ex.:CPF fo cliente" aria-describedby="ContentPlaceHolder1_butExcluir"></asp:TextBox>
                                <div class="input-group-append">
                                    <asp:Button ID="butExcluir" runat="server" Text="Excluir Histórico"/>
                                </div>
                              </div>
                        </span>
                    </div>
                </div>
            </div>
        </section>
    </main>



</asp:Content>
