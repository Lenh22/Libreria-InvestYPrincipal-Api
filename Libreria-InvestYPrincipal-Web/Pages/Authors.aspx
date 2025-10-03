<%@ Page Title="Autores" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Authors.aspx.cs" Inherits="Libreria_InvestYPrincipal_Web.Pages.Authors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Gestión de Autores</title>
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
        <div class="row">
            <div class="col-12">
                <h2 class="mb-4">Gestión de Autores</h2>
                
                <!-- Action Buttons -->
                <div class="mb-3">
                    <asp:Button ID="btnNewAuthor" runat="server" Text="Nuevo Autor" CssClass="btn btn-primary" OnClick="btnNewAuthor_Click" />
                </div>
                
                <!-- Authors Grid -->
                <div class="card">
                    <div class="card-header">
                        <h5 class="mb-0">Lista de Autores</h5>
                    </div>
                    <div class="card-body">
                        <asp:GridView ID="gvAutores" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover"
                            OnRowCommand="gvAutores_RowCommand" DataKeyNames="Id">
                            <Columns>
                                <asp:BoundField DataField="Id" HeaderText="ID" />
                                <asp:BoundField DataField="Name" HeaderText="Nombre" />
                                <asp:BoundField DataField="BirthDate" HeaderText="Fecha Nacimiento" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="Nationality" HeaderText="Nacionalidad" />
                                <asp:TemplateField HeaderText="Acciones">
                                    <ItemTemplate>
                                        <asp:Button ID="btnEdit" runat="server" Text="Editar" CssClass="btn btn-sm btn-warning me-1" 
                                            CommandName="Edit" CommandArgument='<%# Eval("Id") %>' />
                                        <asp:Button ID="btnDelete" runat="server" Text="Eliminar" CssClass="btn btn-sm btn-danger" 
                                            CommandName="Delete" CommandArgument='<%# Eval("Id") %>' 
                                            OnClientClick="return confirm('¿Está seguro de que desea eliminar este autor?');" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                
                <!-- Author Form Modal -->
                <div class="modal fade" id="authorModal" tabindex="-1" aria-labelledby="authorModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                            <div class="modal-header">
                                <h5 class="modal-title" id="authorModalLabel">Autor</h5>
                                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
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
                                                Type="Date" Operator="LessThanEqual" ValueToCompare="<%# DateTime.Now.ToString(\"yyyy-MM-dd\") %>"
                                                ErrorMessage="La fecha no puede ser futura" CssClass="text-danger" Display="Dynamic"></asp:CompareValidator>
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
