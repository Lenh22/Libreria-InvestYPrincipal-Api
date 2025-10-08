<%@ Page Title="Authors" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Authors.aspx.cs" Inherits="Frontend.Pages.Authors" Async="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Author Management</title>
    <script type="text/javascript">
        function showAuthorModal() {
            var modal = new bootstrap.Modal(document.getElementById('authorModal'));
            modal.show();
        }

        function hideAuthorModal() {
            var modal = bootstrap.Modal.getInstance(document.getElementById('authorModal'));
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
        <!-- Header Section -->
        <div class="row mb-4">
            <div class="col-12">
                <div class="d-flex justify-content-between align-items-center">
                    <div>
                        <h1 class="page-title mb-2">
                            <i class="fas fa-user-edit text-primary me-3"></i>Author Management
                        </h1>
                        <p class="text-muted">Manage your author database efficiently</p>
                    </div>
                    <div>
                        <asp:Button ID="btnNewAuthor" runat="server" Text="New Author" 
                            CssClass="btn btn-primary btn-lg shadow" OnClick="btnNewAuthor_Click" />
                    </div>
                </div>
            </div>
        </div>
        
        <!-- Authors Grid Section -->
        <div class="row">
            <div class="col-12">
                <div class="card shadow-sm">
                    <div class="card-header bg-gradient-primary text-white d-flex justify-content-between align-items-center">
                        <h5 class="mb-0">
                            <i class="fas fa-list me-2"></i>Author List
                        </h5>
                        <span class="badge bg-light text-dark" id="authorCount">0 authors</span>
                    </div>
                    <div class="card-body p-0">
                        <div class="table-responsive">
                            <asp:GridView ID="gvAutores" runat="server" AutoGenerateColumns="false" 
                                CssClass="table table-hover mb-0"
                                OnRowCommand="gvAutores_RowCommand" DataKeyNames="Id">
                                <Columns>
                                    <asp:BoundField DataField="Id" HeaderText="ID" ItemStyle-CssClass="fw-bold text-primary" />
                                    <asp:BoundField DataField="Name" HeaderText="Name" ItemStyle-CssClass="fw-semibold" />
                                    <asp:BoundField DataField="BirthDate" HeaderText="Birth Date" DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:BoundField DataField="Nationality" HeaderText="Nationality" ItemStyle-CssClass="text-muted" />
                                    <asp:TemplateField HeaderText="Actions" ItemStyle-Width="150">
                                        <ItemTemplate>
                                            <div class="btn-group" role="group">
                                                <asp:Button ID="btnEdit" runat="server" Text="Edit" 
                                                    CssClass="btn btn-sm btn-warning me-1" 
                                                    CommandName="Edit" CommandArgument='<%# Eval("Id") %>' />
                                                <asp:Button ID="btnDelete" runat="server" Text="Delete" 
                                                    CssClass="btn btn-sm btn-danger" 
                                                    CommandName="Delete" CommandArgument='<%# Eval("Id") %>' 
                                                    OnClientClick="return confirm('Are you sure you want to delete this author?');" />
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataTemplate>
                                    <div class="text-center py-5">
                                        <i class="fas fa-user-edit fa-3x text-muted mb-3"></i>
                                        <h5 class="text-muted">No authors registered</h5>
                                        <p class="text-muted">Start by adding your first author to the database</p>
                                        <asp:Button ID="btnAddFirstAuthor" runat="server" Text="Add First Author" 
                                            CssClass="btn btn-primary" OnClick="btnNewAuthor_Click" />
                                    </div>
                                </EmptyDataTemplate>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
                
        <!-- Author Form Modal -->
        <div id="authorModal" runat="server" ClientIDMode="Static" class="modal fade" tabindex="-1" aria-labelledby="authorModalLabel" aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header bg-gradient-primary text-white">
                        <h5 class="modal-title" id="authorModalLabel">
                            <i class="fas fa-user-edit me-2"></i>Author Form
                        </h5>
                        <button type="button" class="btn-close btn-close-white" data-bs-dismiss="modal" aria-label="Close"></button>
                    </div>
                            <div class="modal-body">
                                <div class="card">
                                    <div class="card-body">
                                        <asp:HiddenField ID="hdnAuthorId" runat="server" />
                                        
                                        <div class="mb-3">
                                            <label for="<%= txtName.ClientID %>" class="form-label">Nombre *</label>
                                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" 
                                                ErrorMessage="El nombre es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
                                        
                                        <div class="mb-3">
                                            <label for="<%= txtBirthDate.ClientID %>" class="form-label">Fecha de Nacimiento *</label>
                                            <asp:TextBox ID="txtBirthDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvBirthDate" runat="server" ControlToValidate="txtBirthDate" 
                                                ErrorMessage="La fecha de nacimiento es obligatoria" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="cvBirthDate" runat="server" ControlToValidate="txtBirthDate"
                                                Type="Date" Operator="LessThanEqual"
                                                ErrorMessage="La fecha no puede ser futura" CssClass="text-danger" Display="Dynamic">
                                            </asp:CompareValidator>

                                        </div>
                                        
                                        <div class="mb-3">
                                            <label for="<%= txtNationality.ClientID %>" class="form-label">Nacionalidad *</label>
                                            <asp:TextBox ID="txtNationality" runat="server" CssClass="form-control" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfvNationality" runat="server" ControlToValidate="txtNationality" 
                                                ErrorMessage="La nacionalidad es obligatoria" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                                        </div>
                                        
                                        <div class="row">
                                            <div class="col-12">
                                                <asp:Button ID="btnSave" runat="server" Text="Guardar" CssClass="btn btn-success me-2" OnClick="btnSave_Click" />
                                                <asp:Button ID="btnCancel" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancel_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
