<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/semMenu.Master" CodeBehind="confirm-register.aspx.vb" Inherits="Natal2025.confirm_register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row no-gutters confirm-register">
        <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 mb-4">
            <h3 class="text-blue text-center">
                <strong>Confirme seu dados </strong><br>
                para finalizar essa etapa</h3>
        </div>
        <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 mb-1">
            <h4 class="text-blue text-left">
                <strong>CPF: </strong>
                <asp:Label ID="labCPF" runat="server" Text=""></asp:Label></h4>
        </div>
        <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 mb-1">
            <h4 class="text-blue text-left">
                <strong>Nome: </strong><asp:Label ID="labNome" runat="server" Text=""></asp:Label></h4>
        </div>
        <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 mb-1">
            <h4 class="text-blue text-left">
                <strong>E-mail: </strong><asp:Label ID="labEmail" runat="server" Text=""></asp:Label></h4>
        </div>
        <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 mb-1">
            <h4 class="text-blue text-left">
                <strong>Celular: </strong><asp:Label ID="labCelular" runat="server" Text=""></asp:Label></h4>
        </div>
        <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 mb-1">
            <h4 class="text-blue text-left">
                <strong>Gênero: </strong><asp:Label ID="labGenero" runat="server" Text=""></asp:Label></h4>
        </div>
        <div class="col-12 col-sm-12 col-md-12 col-lg-12 col-xl-12 mb-5">
            <h4 class="text-blue text-left">
                <strong>Data de Nascimento: </strong><asp:Label ID="labNascimento" runat="server" Text=""></asp:Label></asp:Label></h4>
        </div>

        <asp:Button ID="butAvancar" class="btn btn-primary btn-lg btn-block" runat="server" Text="CONFIRMAR DADOS" />
        <asp:Button ID="butEdit" class="btn bt-inline btn-lg btn-block mt-3" runat="server" Text="EDITAR INFORMAÇÕES" />
    </div>
</asp:Content>
