<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BookSearch.ascx.cs" Inherits="Frontend.UserControls.BookSearch" %>
<div class="card-body">
        <div class="row">
            <div class="col-md-4">
                <label for="<%= txtTitle.ClientID %>" class="form-label">Title:</label>
                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" placeholder="Search by title..."></asp:TextBox>
            </div>
            <div class="col-md-4">
                <label for="<%= txtGenre.ClientID %>" class="form-label">Genre:</label>
                <asp:TextBox ID="txtGenre" runat="server" CssClass="form-control" placeholder="Search by genre..."></asp:TextBox>
            </div>
            <div class="col-md-4">
                <label for="<%= txtAuthorName.ClientID %>" class="form-label">Author:</label>
                <asp:TextBox ID="txtAuthorName" runat="server" CssClass="form-control" placeholder="Search by author..."></asp:TextBox>
            </div>
        </div>
        <div class="row mt-3">
            <div class="col-12">
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary me-2" OnClick="btnSearch_Click" />
                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-secondary" OnClick="btnClear_Click" />
            </div>
        </div>
        
        <!-- Search Results Section -->
        <div id="searchResultsSection" runat="server" visible="false" class="mt-4">
            <h6>Search Results:</h6>
            <asp:GridView ID="gvSearchResults" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover"
                OnRowCommand="gvSearchResults_RowCommand" DataKeyNames="Id">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Title" HeaderText="Title" />
                    <asp:TemplateField HeaderText="Genre">
                        <ItemTemplate>
                            <span class="badge bg-info"><%# Eval("Genre") %></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Pages">
                        <ItemTemplate>
                            <span class="badge bg-secondary"><%# Eval("Pages") %> pgs</span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="PublishDate" HeaderText="Publish Date" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField DataField="Publisher" HeaderText="Publisher" />
                    <asp:BoundField DataField="ISBN" HeaderText="ISBN" ItemStyle-CssClass="font-monospace small" />
                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" ItemStyle-CssClass="fw-bold text-success" />
                    <asp:TemplateField HeaderText="Language">
                        <ItemTemplate>
                            <span class="badge bg-warning text-dark"><%# Eval("Language") %></span>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="AuthorName" HeaderText="Author" ItemStyle-CssClass="text-muted" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <div class="btn-group" role="group">
                                <asp:Button ID="btnEdit" runat="server" Text="Edit" 
                                    CssClass="btn btn-sm btn-warning me-1" 
                                    CommandName="EditBook" CommandArgument='<%# Eval("Id") %>' CausesValidation="false" />
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" 
                                    CssClass="btn btn-sm btn-danger" 
                                    CommandName="DeleteBook" 
                                    CommandArgument='<%# Eval("Id") %>' 
                                    OnClientClick="return confirm('Are you sure you want to delete this book?');"
                                    CausesValidation="false"/>

                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
</div>
