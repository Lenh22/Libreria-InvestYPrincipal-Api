<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookForm.ascx.cs" Inherits="Frontend.UserControls.BookForm" %>
<div class="card">
    <div class="card-header">
        <h5 class="mb-0">
            <asp:Label ID="lblFormTitle" runat="server" Text="New Book"></asp:Label>
        </h5>
    </div>
    <div class="card-body">
        <asp:HiddenField ID="hdnBookId" runat="server" />
        
        <div class="row">
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="<%= txtTitle.ClientID %>" class="form-label">Title *</label>
                    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" MaxLength="200"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle" 
                        ErrorMessage="Title is required" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="<%= ddlGenre.ClientID %>" class="form-label">Genre *</label>
                    <asp:DropDownList ID="ddlGenre" runat="server" CssClass="form-select">
                        <asp:ListItem Value="" Text="Select genre..."></asp:ListItem>
                        <asp:ListItem Value="Fiction" Text="Fiction"></asp:ListItem>
                        <asp:ListItem Value="Non-Fiction" Text="Non-Fiction"></asp:ListItem>
                        <asp:ListItem Value="Science Fiction" Text="Science Fiction"></asp:ListItem>
                        <asp:ListItem Value="Fantasy" Text="Fantasy"></asp:ListItem>
                        <asp:ListItem Value="Mystery" Text="Mystery"></asp:ListItem>
                        <asp:ListItem Value="Romance" Text="Romance"></asp:ListItem>
                        <asp:ListItem Value="History" Text="History"></asp:ListItem>
                        <asp:ListItem Value="Biography" Text="Biography"></asp:ListItem>
                        <asp:ListItem Value="Technical" Text="Technical"></asp:ListItem>
                        <asp:ListItem Value="Other" Text="Other"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvGenre" runat="server" ControlToValidate="ddlGenre" 
                        ErrorMessage="Genre is required" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="<%= txtPublishDate.ClientID %>" class="form-label">Publish Date *</label>
                    <asp:TextBox ID="txtPublishDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPublishDate" runat="server" ControlToValidate="txtPublishDate" 
                        ErrorMessage="Publish date is required" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvPublishDate" runat="server" ControlToValidate="txtPublishDate"
                        Type="Date" Operator="LessThanEqual"
                        ErrorMessage="Date cannot be in the future" CssClass="text-danger" Display="Dynamic">
                    </asp:CompareValidator>

                </div>
            </div>
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="<%= txtPages.ClientID %>" class="form-label">Pages *</label>
                    <asp:TextBox ID="txtPages" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPages" runat="server" ControlToValidate="txtPages" 
                        ErrorMessage="Number of pages is required" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvPages" runat="server" ControlToValidate="txtPages" 
                        MinimumValue="1" MaximumValue="1000" Type="Integer"
                        ErrorMessage="Number of pages must be between 1 and 1000" CssClass="text-danger" Display="Dynamic"></asp:RangeValidator>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="<%= txtPublisher.ClientID %>" class="form-label">Publisher *</label>
                    <asp:TextBox ID="txtPublisher" runat="server" CssClass="form-control" MaxLength="100"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPublisher" runat="server" ControlToValidate="txtPublisher" 
                        ErrorMessage="Publisher is required" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="<%= txtISBN.ClientID %>" class="form-label">ISBN *</label>
                    <asp:TextBox ID="txtISBN" runat="server" CssClass="form-control" MaxLength="20"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvISBN" runat="server" ControlToValidate="txtISBN" 
                        ErrorMessage="ISBN is required" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="<%= txtPrice.ClientID %>" class="form-label">Price *</label>
                    <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" TextMode="Number" step="0.01"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ControlToValidate="txtPrice" 
                        ErrorMessage="Price is required" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvPrice" runat="server" ControlToValidate="txtPrice" 
                        MinimumValue="1" MaximumValue="1000" Type="Double"
                        ErrorMessage="Price must be between 1 and 1000" CssClass="text-danger" Display="Dynamic"></asp:RangeValidator>
                </div>
            </div>
            <div class="col-md-6">
                <div class="mb-3">
                    <label for="<%= ddlLanguage.ClientID %>" class="form-label">Language *</label>
                    <asp:DropDownList ID="ddlLanguage" runat="server" CssClass="form-select">
                        <asp:ListItem Value="" Text="Select language..."></asp:ListItem>
                        <asp:ListItem Value="Spanish" Text="Spanish"></asp:ListItem>
                        <asp:ListItem Value="English" Text="English"></asp:ListItem>
                        <asp:ListItem Value="French" Text="French"></asp:ListItem>
                        <asp:ListItem Value="German" Text="German"></asp:ListItem>
                        <asp:ListItem Value="Italian" Text="Italian"></asp:ListItem>
                        <asp:ListItem Value="Portuguese" Text="Portuguese"></asp:ListItem>
                        <asp:ListItem Value="Other" Text="Other"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvLanguage" runat="server" ControlToValidate="ddlLanguage" 
                        ErrorMessage="Language is required" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-12">
                <div class="mb-3">
                    <label for="<%= ddlAuthor.ClientID %>" class="form-label">Author *</label>
                    <asp:DropDownList ID="ddlAuthor" runat="server" CssClass="form-select"></asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvAuthor" runat="server" ControlToValidate="ddlAuthor" 
                        ErrorMessage="Author is required" CssClass="text-danger" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-12">
                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success me-2" OnClick="btnSave_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" data-bs-dismiss="modal" CssClass="btn btn-secondary" OnClick="btnCancel_Click" CausesValidation="false"/>

            </div>
        </div>
    </div>
</div>
