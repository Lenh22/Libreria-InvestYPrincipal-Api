<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookForm.ascx.cs" Inherits="Libreria_InvestYPrincipal_Web.UserControls.BookForm" %>
<div class="card">
    <div class="card-header">
        <h5 class="mb-0">
            <asp:Label ID="lblFormTitle" runat="server" Text="Nuevo Libro"></asp:Label>
        </h5>
    </div>
    <div class="card-body">
        <asp:HiddenField ID="hdnBookId" runat="server" />
        
        <div class="row">
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="<%= txtTitle.ClientID %>" class="form-label">Título *</label>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" MaxLength="200"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle" 
                        ErrorMessage="El título es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="<%= ddlGenre.ClientID %>" class="form-label">Género *</label>
                    <asp:DropDownList ID="ddlGenre" runat="server" CssClass="form-select">
                        <asp:ListItem Value="" Text="Seleccionar género..."></asp:ListItem>
                        <asp:ListItem Value="Ficción" Text="Ficción"></asp:ListItem>
                        <asp:ListItem Value="No Ficción" Text="No Ficción"></asp:ListItem>
                        <asp:ListItem Value="Ciencia Ficción" Text="Ciencia Ficción"></asp:ListItem>
                        <asp:ListItem Value="Fantasía" Text="Fantasía"></asp:ListItem>
                        <asp:ListItem Value="Misterio" Text="Misterio"></asp:ListItem>
                        <asp:ListItem Value="Romance" Text="Romance"></asp:ListItem>
                        <asp:ListItem Value="Historia" Text="Historia"></asp:ListItem>
                        <asp:ListItem Value="Biografía" Text="Biografía"></asp:ListItem>
                        <asp:ListItem Value="Técnico" Text="Técnico"></asp:ListItem>
                        <asp:ListItem Value="Otro" Text="Otro"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvGenre" runat="server" ControlToValidate="ddlGenre" 
                        ErrorMessage="El género es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="<%= txtPublishDate.ClientID %>" class="form-label">Fecha de Publicación *</label>
                    <asp:TextBox ID="txtPublishDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPublishDate" runat="server" ControlToValidate="txtPublishDate" 
                        ErrorMessage="La fecha de publicación es obligatoria" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvPublishDate" runat="server" ControlToValidate="txtPublishDate"
                        Type="Date" Operator="LessThanEqual"
                        ErrorMessage="La fecha no puede ser futura" CssClass="text-danger" Display="Dynamic">
                    </asp:CompareValidator>

                </div>
            </div>
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="<%= txtPages.ClientID %>" class="form-label">Páginas *</label>
                    <asp:TextBox ID="txtPages" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPages" runat="server" ControlToValidate="txtPages" 
                        ErrorMessage="El número de páginas es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvPages" runat="server" ControlToValidate="txtPages" 
                        MinimumValue="1" MaximumValue="1000" Type="Integer"
                        ErrorMessage="El número de páginas debe estar entre 1 y 1000" CssClass="text-danger" Display="Dynamic"></asp:RangeValidator>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="<%= txtPublisher.ClientID %>" class="form-label">Editorial *</label>
                    <asp:TextBox ID="txtPublisher" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPublisher" runat="server" ControlToValidate="txtPublisher" 
                        ErrorMessage="La editorial es obligatoria" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="<%= txtISBN.ClientID %>" class="form-label">ISBN *</label>
                    <asp:TextBox ID="txtISBN" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvISBN" runat="server" ControlToValidate="txtISBN" 
                        ErrorMessage="El ISBN es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="<%= txtPrice.ClientID %>" class="form-label">Precio *</label>
                    <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" TextMode="Number" step="0.01"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ControlToValidate="txtPrice" 
                        ErrorMessage="El precio es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvPrice" runat="server" ControlToValidate="txtPrice" 
                        MinimumValue="1" MaximumValue="1000" Type="Double"
                        ErrorMessage="El precio debe estar entre 1 y 1000" CssClass="text-danger" Display="Dynamic"></asp:RangeValidator>
                </div>
            </div>
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="<%= ddlLanguage.ClientID %>" class="form-label">Idioma *</label>
                    <asp:DropDownList ID="ddlLanguage" runat="server" CssClass="form-select">
                        <asp:ListItem Value="" Text="Seleccionar idioma..."></asp:ListItem>
                        <asp:ListItem Value="Español" Text="Español"></asp:ListItem>
                        <asp:ListItem Value="Inglés" Text="Inglés"></asp:ListItem>
                        <asp:ListItem Value="Francés" Text="Francés"></asp:ListItem>
                        <asp:ListItem Value="Alemán" Text="Alemán"></asp:ListItem>
                        <asp:ListItem Value="Italiano" Text="Italiano"></asp:ListItem>
                        <asp:ListItem Value="Portugués" Text="Portugués"></asp:ListItem>
                        <asp:ListItem Value="Otro" Text="Otro"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvLanguage" runat="server" ControlToValidate="ddlLanguage" 
                        ErrorMessage="El idioma es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="mb-3">
                    <label for="<%= ddlAuthor.ClientID %>" class="form-label">Autor *</label>
                    <asp:DropDownList ID="ddlAuthor" runat="server" CssClass="form-select"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvAuthor" runat="server" ControlToValidate="ddlAuthor" 
                        ErrorMessage="El autor es obligatorio" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-12">
                <asp:Button ID="btnSave" runat="server" Text="Guardar" CssClass="btn btn-success me-2" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancel_Click" />
            </div>
        </div>
    </div>
</div>
