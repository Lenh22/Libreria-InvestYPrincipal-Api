<%@ Page Title="Libros" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="Libreria_InvestYPrincipal_Web.Pages.Books" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Gestión de Libros</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Libros</h2>

    <asp:GridView ID="gvLibros" runat="server" AutoGenerateColumns="false" CssClass="table">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="ID" />
            <asp:BoundField DataField="Title" HeaderText="Título" />
            <asp:BoundField DataField="Genre" HeaderText="Género" />
            <asp:BoundField DataField="PublishDate" HeaderText="Fecha Publicación" DataFormatString="{0:dd/MM/yyyy}" />
            <asp:BoundField DataField="Pages" HeaderText="Páginas" />
            <asp:BoundField DataField="Publisher" HeaderText="Editorial" />
            <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
            <asp:BoundField DataField="Price" HeaderText="Precio" DataFormatString="{0:C}" />
            <asp:BoundField DataField="Language" HeaderText="Idioma" />
            <asp:BoundField DataField="AuthorName" HeaderText="Autor" />
        </Columns>
    </asp:GridView>
</asp:Content>
