<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/comMenu.Master" CodeBehind="termsandprivacy.aspx.vb" Inherits="Natal_torra.termsandprivacy" %>

<%@ Register Src="~/componentes/terms.ascx" TagPrefix="uc1" TagName="terms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:terms runat="server" ID="terms" />
</asp:Content>
