<%@ Page Title="Books" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Books.aspx.cs" Inherits="Frontend.Pages.Books" Async="true" %>
<%@ Register Src="~/UserControls/BookSearch.ascx" TagName="BookSearch" TagPrefix="uc" %>
<%@ Register Src="~/UserControls/BookForm.ascx" TagName="BookForm" TagPrefix="uc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Book Management</title>
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
            var iconClass = type === 'success' ? 'fas fa-check-circle' : 'fas fa-exclamation-triangle';
            var alertHtml = '<div class="alert ' + alertClass + ' alert-dismissible fade show" role="alert">' +
                '<i class="' + iconClass + ' me-2"></i>' + message +
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

        // Animación de entrada
        document.addEventListener('DOMContentLoaded', function() {
            const elements = document.querySelectorAll('.card, .btn');
            elements.forEach((el, index) => {
                el.style.opacity = '0';
                el.style.transform = 'translateY(20px)';
                setTimeout(() => {
                    el.style.transition = 'all 0.6s ease';
                    el.style.opacity = '1';
                    el.style.transform = 'translateY(0)';
                }, index * 100);
            });
        });
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <!-- Header Section -->
        <div class="row mb-4">
            <div class="col-12">
                <div class="d-flex justify-content-between align-items-center">
                    <div>
                        <h1 class="page-title mb-2">
                            <i class="fas fa-book-open text-primary me-3"></i>Book Management
                        </h1>
                        <p class="text-muted">Manage your book catalog efficiently</p>
                    </div>
                    <div>
                        <asp:Button ID="btnNewBook" runat="server" Text="New Book" 
                            CssClass="btn btn-primary btn-lg shadow" OnClick="btnNewBook_Click" />
                    </div>
                </div>
            </div>
        </div>

        <!-- Search Section -->
        <div class="row mb-4">
            <div class="col-12">
                <div class="card shadow-sm">
                    <div class="card-header bg-gradient-primary text-white">
                        <h5 class="mb-0">
                            <i class="fas fa-search me-2"></i>Book Search
                        </h5>
                    </div>
                    <div class="card-body">
                        <uc:BookSearch ID="ucBookSearch" runat="server" />
                    </div>
                </div>
            </div>
        </div>
        
        <!-- Books Grid Section -->
        <div class="row">
            <div class="col-12">
                <div class="card shadow-sm">
                    <div class="card-header bg-gradient-primary text-white d-flex justify-content-between align-items-center">
                        <h5 class="mb-0">
                            <i class="fas fa-list me-2"></i>Book List
                        </h5>
                        <span class="badge bg-light text-dark" id="bookCount">0 books</span>
                    </div>
                    <div class="card-body p-0">
                        <div class="table-responsive">
                            <asp:GridView ID="gvLibros" runat="server" AutoGenerateColumns="false" 
                                CssClass="table table-hover mb-0"
                                OnRowCommand="gvLibros_RowCommand" DataKeyNames="Id"
                                OnRowDataBound="gvLibros_RowDataBound">
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="ID" ItemStyle-CssClass="fw-bold text-primary" />
                                    <asp:BoundField DataField="Title" HeaderText="Title" ItemStyle-CssClass="fw-semibold" />
                                    <asp:TemplateField HeaderText="Genre">
                                        <ItemTemplate>
                                            <span class="badge bg-info"><%# Eval("Genre") %></span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="PublishDate" HeaderText="Publish Date" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:TemplateField HeaderText="Pages">
                                        <ItemTemplate>
                                            <span class="badge bg-secondary"><%# Eval("Pages") %> pgs</span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Publisher" HeaderText="Publisher" />
                                    <asp:BoundField DataField="ISBN" HeaderText="ISBN" ItemStyle-CssClass="font-monospace small" />
                                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" ItemStyle-CssClass="fw-bold text-success" />
                                    <asp:TemplateField HeaderText="Language">
                                        <ItemTemplate>
                                            <span class="badge bg-warning text-dark"><%# Eval("Language") %></span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="AuthorName" HeaderText="Author" ItemStyle-CssClass="text-muted" />
                                    <asp:TemplateField HeaderText="Actions" ItemStyle-Width="150">
                                        <ItemTemplate>
                                            <div class="btn-group" role="group">
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" 
                                                    CssClass="btn btn-sm btn-warning me-1" 
                                                    CommandName="Edit" CommandArgument='<%# Eval("Id") %>' />
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" 
                                                    CssClass="btn btn-sm btn-danger" 
                                                    CommandName="Delete" CommandArgument='<%# Eval("Id") %>' 
                                                    OnClientClick="return confirm('Are you sure you want to delete this book?');" />
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div class="text-center py-5">
                                        <i class="fas fa-book fa-3x text-muted mb-3"></i>
                                        <h5 class="text-muted">No books registered</h5>
                                        <p class="text-muted">Start by adding your first book to the catalog</p>
                                        <asp:Button ID="btnAddFirstBook" runat="server" Text="Add First Book" 
                                            CssClass="btn btn-primary" OnClick="btnNewBook_Click" />
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
                
        <!-- Book Form Modal -->
        <div class="modal fade" id="bookModal" tabindex="-1" aria-labelledby="bookModalLabel" aria-hidden="true">
            <div class="modal-dialog modal-xl">
                <div class="modal-content">
                    <div class="modal-header bg-gradient-primary text-white">
                        <h5 class="modal-title" id="bookModalLabel">
                            <i class="fas fa-book me-2"></i>Book Form
                        </h5>
                        <button type="button" class="btn-close btn-close-white" data-bs-dismiss="modal" aria-label="Close"></button>
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
