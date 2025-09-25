<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchBox.ascx.cs" Inherits="Libreria_InvestYPrincipal_Web.UserControls.SearchBox" %>
<div>
    <asp:TextBox ID="txtTitulo" runat="server" Placeholder="Buscar por título"></asp:TextBox>
    <asp:TextBox ID="txtAutor" runat="server" Placeholder="Buscar por autor"></asp:TextBox>
    <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
</div>