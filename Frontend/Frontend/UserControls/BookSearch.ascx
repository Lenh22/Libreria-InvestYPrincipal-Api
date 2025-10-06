<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookSearch.ascx.cs" Inherits="Frontend.UserControls.BookSearch" %>
<div class="card mb-4">
    <div class="card-header">
        <h5 class="mb-0">Búsqueda de Libros</h5>
    </div>
    <div class="card-body">
        <div class="row">
            <div class="col-md-4">
                <label for="<%= txtTitle.ClientID %>" class="form-label">Título:</label>
                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" placeholder="Buscar por título..."></asp:TextBox>
            </div>
            <div class="col-md-4">
                <label for="<%= txtGenre.ClientID %>" class="form-label">Género:</label>
                <asp:TextBox ID="txtGenre" runat="server" CssClass="form-control" placeholder="Buscar por género..."></asp:TextBox>
            </div>
            <div class="col-md-4">
                <label for="<%= txtAuthorName.ClientID %>" class="form-label">Autor:</label>
                <asp:TextBox ID="txtAuthorName" runat="server" CssClass="form-control" placeholder="Buscar por autor..."></asp:TextBox>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-12">
                <asp:Button ID="btnSearch" runat="server" Text="Buscar" CssClass="btn btn-primary me-2" OnClick="btnSearch_Click" />
                <asp:Button ID="btnClear" runat="server" Text="Limpiar" CssClass="btn btn-secondary" OnClick="btnClear_Click" />
            </div>
        </div>
        
        <!-- Search Results Section -->
        <div id="searchResultsSection" runat="server" visible="false" class="mt-4">
            <h6>Resultados de la búsqueda:</h6>
            <asp:GridView ID="gvSearchResults" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover"
                OnRowCommand="gvSearchResults_RowCommand" DataKeyNames="Id">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Title" HeaderText="Título" />
                    <asp:BoundField DataField="Genre" HeaderText="Género" />
                    <asp:BoundField DataField="AuthorName" HeaderText="Autor" />
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <asp:Button ID="btnSelect" runat="server" Text="Seleccionar" CssClass="btn btn-sm btn-info" 
                                CommandName="Select" CommandArgument='<%# Eval("Id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</div>
