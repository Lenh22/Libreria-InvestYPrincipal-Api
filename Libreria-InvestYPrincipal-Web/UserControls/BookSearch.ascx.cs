using System;
using System.Web.UI;

namespace Libreria_InvestYPrincipal_Web.UserControls
{
    public partial class BookSearch : UserControl
    {
        public event EventHandler SearchRequested;
        public event EventHandler ClearRequested;

        public string Title => txtTitle.Text.Trim();
        public string Genre => txtGenre.Text.Trim();
        public string AuthorName => txtAuthorName.Text.Trim();

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchRequested?.Invoke(this, e);
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtTitle.Text = string.Empty;
            txtGenre.Text = string.Empty;
            txtAuthorName.Text = string.Empty;
            ClearRequested?.Invoke(this, e);
        }
    }
}
