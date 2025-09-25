<%@ Page Title="Autores" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Author.aspx.cs" Inherits="Libreria_InvestYPrincipal_Web.Pages.Author" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Gestión de Autores</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Autores</h2>

    <asp:GridView ID="gvAutores" runat="server" AutoGenerateColumns="false" CssClass="table">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="Name" HeaderText="Nombre" />
            <asp:BoundField DataField="BirthDate" HeaderText="Fecha Nacimiento" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="Nationality" HeaderText="Nacionalidad" />
        </Columns>
    </asp:GridView>
</asp:Content>
