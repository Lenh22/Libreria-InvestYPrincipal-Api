using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Frontend.Dto;

namespace Frontend.UserControls
{
    public partial class BookSearch : UserControl
    {
        public event EventHandler SearchRequested;
        public event EventHandler ClearRequested;
        public event EventHandler<BookSelectedEventArgs> BookSelected;
        public event EventHandler<int> EditRequested;
        public event EventHandler<int> DeleteRequested;

        public string Title => txtTitle.Text.Trim();
        public string Genre => txtGenre.Text.Trim();
        public string AuthorName => txtAuthorName.Text.Trim();

        public List<BookDto> SearchResults
        {
            get { return (List<BookDto>)ViewState["SearchResults"] ?? new List<BookDto>(); }
            set 
            { 
                ViewState["SearchResults"] = value;
                gvSearchResults.DataSource = value;
                gvSearchResults.DataBind();
                searchResultsSection.Visible = value != null && value.Count > 0;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchRequested?.Invoke(this, e);
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtTitle.Text = string.Empty;
            txtGenre.Text = string.Empty;
            txtAuthorName.Text = string.Empty;
            SearchResults = new List<BookDto>();
            ClearRequested?.Invoke(this, e);
        }

        protected void gvSearchResults_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int bookId = Convert.ToInt32(e.CommandArgument);
                var selectedBook = SearchResults.Find(b => b.Id == bookId);
                if (selectedBook != null)
                {
                    BookSelected?.Invoke(this, new BookSelectedEventArgs(selectedBook));
                }
            }
            else if (e.CommandName == "EditBook")
            {
                int bookId = Convert.ToInt32(e.CommandArgument);
                EditRequested?.Invoke(this, bookId);
            }
            else if (e.CommandName == "DeleteBook")
            {
                int bookId = Convert.ToInt32(e.CommandArgument);
                DeleteRequested?.Invoke(this, bookId);
            }
        }

        public void ClearSearchResults()
        {
            SearchResults = new List<BookDto>();
        }
    }

    public class BookSelectedEventArgs : EventArgs
    {
        public BookDto SelectedBook { get; }

        public BookSelectedEventArgs(BookDto book)
        {
            SelectedBook = book;
        }
    }
}
