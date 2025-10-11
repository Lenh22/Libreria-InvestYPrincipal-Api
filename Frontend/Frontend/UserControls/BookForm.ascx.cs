using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Frontend.Dto;

namespace Frontend.UserControls
{
    public partial class BookForm : UserControl
    {
        public event EventHandler SaveRequested;
        public event EventHandler CancelRequested;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Configurar la validación de fecha para que no sea futura
                cvPublishDate.ValueToCompare = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        public int BookId
        {
            get
            {
                int.TryParse(hdnBookId.Value, out int id);
                return id;
            }
            set { hdnBookId.Value = value.ToString(); }
        }

        public string Title
        {
            get { return txtTitle.Text.Trim(); }
            set { txtTitle.Text = value; }
        }

        public string Genre
        {
            get { return ddlGenre.SelectedValue; }
            set { ddlGenre.SelectedValue = value; }
        }

        public DateTime PublishDate
        {
            get
            {
                DateTime.TryParse(txtPublishDate.Text, out DateTime date);
                return date;
            }
            set { txtPublishDate.Text = value.ToString("yyyy-MM-dd"); }
        }

        public int Pages
        {
            get
            {
                int.TryParse(txtPages.Text, out int pages);
                return pages;
            }
            set { txtPages.Text = value.ToString(); }
        }

        public string Publisher
        {
            get { return txtPublisher.Text.Trim(); }
            set { txtPublisher.Text = value; }
        }

        public string ISBN
        {
            get { return txtISBN.Text.Trim(); }
            set { txtISBN.Text = value; }
        }

        public decimal Price //Verificar que obtenga bien el dato
        {
            get
            {
                decimal.TryParse(txtPrice.Text, out decimal price);
                return price;
            }
            set { txtPrice.Text = value.ToString("F2"); }
        }

        public string Language
        {
            get { return ddlLanguage.SelectedValue; }
            set { ddlLanguage.SelectedValue = value; }
        }

        public int AuthorId
        {
            get
            {
                int.TryParse(ddlAuthor.SelectedValue, out int authorId);
                return authorId;
            }
            set { ddlAuthor.SelectedValue = value.ToString(); }
        }

        public void SetFormTitle(string title)
        {
            lblFormTitle.Text = title;
        }

        public void ClearForm()
        {
            hdnBookId.Value = "0";
            txtTitle.Text = string.Empty;
            ddlGenre.SelectedIndex = 0;
            txtPublishDate.Text = string.Empty;
            txtPages.Text = string.Empty;
            txtPublisher.Text = string.Empty;
            txtISBN.Text = string.Empty;
            txtPrice.Text = string.Empty;
            ddlLanguage.SelectedIndex = 0;
            ddlAuthor.SelectedIndex = 0;
        }

        public void LoadAuthors(IEnumerable<AuthorDto> authors)
        {
            ddlAuthor.Items.Clear();
            ddlAuthor.Items.Add(new ListItem("Select author...", ""));
            
            foreach (var author in authors)
            {
                ddlAuthor.Items.Add(new ListItem(author.Name, author.Id.ToString()));
            }
        }

        public BookDto SaveBook()
        {
            if (Page.IsValid)
            {
                return new BookDto
                {
                    Id = BookId,
                    Title = Title,
                    Genre = Genre,
                    PublishDate = PublishDate,
                    Pages = Pages,
                    Publisher = Publisher,
                    ISBN = ISBN,
                    Price = Price,
                    Language = Language,
                    AuthorId = AuthorId
                };
            }
            return null;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                SaveRequested?.Invoke(this, e);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            CancelRequested?.Invoke(this, e);
        }
    }
}
