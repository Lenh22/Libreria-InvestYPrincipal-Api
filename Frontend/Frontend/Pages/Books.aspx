<%@ Page Title="Libros" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="Frontend.Pages.Books" Async="true" %>
<%@ Register Src="~/UserControls/BookSearch.ascx" TagName="BookSearch" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/BookForm.ascx" TagName="BookForm" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Gestión de Libros</title>
    <script type="text/javascript">
        function showBookModal() {
            var modal = new bootstrap.Modal(document.getElementById('bookModal'));
            modal.show();
        }

        function hideBookModal() {
            var modal = bootstrap.Modal.getInstance(document.getElementById('bookModal'));
            if (modal) {
                modal.hide();
            }
        }

        function showMessage(message, type) {
            var alertClass = type === 'success' ? 'alert-success' : 'alert-danger';
            var alertHtml = '<div class="alert ' + alertClass + ' alert-dismissible fade show" role="alert">' +
                message +
                '<button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>' +
                '</div>';
            
            var container = document.querySelector('.container-fluid');
            if (container) {
                container.insertAdjacentHTML('afterbegin', alertHtml);
                
                // Auto-hide after 5 seconds
                setTimeout(function() {
                    var alert = container.querySelector('.alert');
                    if (alert) {
                        var bsAlert = new bootstrap.Alert(alert);
                        bsAlert.close();
                    }
                }, 5000);
            }
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-12">
                <h2 class="mb-4">Gestión de Libros</h2>
                
                <!-- Search Control -->
                <uc:BookSearch ID="ucBookSearch" runat="server" />
                
                <!-- Action Buttons -->
                <div class="mb-3">
                    <asp:Button ID="btnNewBook" runat="server" Text="Nuevo Libro" CssClass="btn btn-primary" OnClick="btnNewBook_Click" />
                </div>
                
                <!-- Books Grid -->
                <div class="card">
                    <div class="card-header">
                        <h5 class="mb-0">Lista de Libros</h5>
                    </div>
                    <div class="card-body">
                        <asp:GridView ID="gvLibros" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover"
                            OnRowCommand="gvLibros_RowCommand" DataKeyNames="Id">
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
                                <asp:TemplateField HeaderText="Acciones">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEdit" runat="server" Text="Editar" CssClass="btn btn-sm btn-warning me-1" 
                                            CommandName="Edit" CommandArgument='<%# Eval("Id") %>' />
                                        <asp:Button ID="btnDelete" runat="server" Text="Eliminar" CssClass="btn btn-sm btn-danger" 
                                            CommandName="Delete" CommandArgument='<%# Eval("Id") %>' 
                                            OnClientClick="return confirm('¿Está seguro de que desea eliminar este libro?');" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                
                <!-- Book Form Modal -->
                <div class="modal fade" id="bookModal" tabindex="-1" aria-labelledby="bookModalLabel" aria-hidden="true">
                    <div class="modal-dialog modal-lg">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="bookModalLabel">Libro</h5>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                            </div>
                            <div class="modal-body">
                                <uc:BookForm ID="ucBookForm" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
