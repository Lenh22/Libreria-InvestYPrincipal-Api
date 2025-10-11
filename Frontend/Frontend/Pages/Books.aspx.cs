using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Frontend.UserControls;
using Frontend.Dto;

namespace Frontend.Pages
{
    public partial class Books : System.Web.UI.Page
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private const string API_BASE_URL = "http://localhost:7000/api";

        protected void Page_Load(object sender, EventArgs e)
        {
            // Page_Load vacío - la configuración se hace en Page_PreRender
        }

        protected async void Page_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Configurar eventos aquí para asegurar que los UserControls estén disponibles
                SetupEventHandlers();
                await LoadBooks();
                await LoadAuthors();
            }
        }

        private bool _eventsSetup = false;

        private void SetupEventHandlers()
        {
            if (_eventsSetup) return; // Evitar suscripciones duplicadas

            if (ucBookSearch != null)
            {
                ucBookSearch.SearchRequested += UcBookSearch_SearchRequested;
                ucBookSearch.ClearRequested += UcBookSearch_ClearRequested; 
                ucBookSearch.BookSelected += UcBookSearch_BookSelected;     
            }

            if (ucBookForm != null)
            {
                ucBookForm.SaveRequested += UcBookForm_SaveRequested;
                ucBookForm.CancelRequested += UcBookForm_CancelRequested;
            }

            _eventsSetup = true;
        }

        private async Task LoadBooks()
        {
            try
            {
                var response = await httpClient.GetAsync($"{API_BASE_URL}/books");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var books = JsonConvert.DeserializeObject<List<BookDto>>(json);
                    gvLibros.DataSource = books;
                    gvLibros.DataBind();
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al cargar libros: {ex.Message}", "error");
            }
        }

        private async Task LoadAuthors()
        {
            try
            {
                var response = await httpClient.GetAsync($"{API_BASE_URL}/authors");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var authors = JsonConvert.DeserializeObject<List<AuthorDto>>(json);

                    // Cargar autores en el UserControl
                    ucBookForm.LoadAuthors(authors);
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al cargar autores: {ex.Message}", "error");
            }
        }

        protected void btnNewBook_Click(object sender, EventArgs e)
        {
            ucBookForm.ClearForm();
            ucBookForm.SetFormTitle("Nuevo Libro");
            ShowModal();
        }

        protected void gvLibros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int bookId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Edit")
            {
                RegisterAsyncTask(new PageAsyncTask(async () => await LoadBookForEdit(bookId)));
            }
            else if (e.CommandName == "Delete")
            {
                RegisterAsyncTask(new PageAsyncTask(async () => await DeleteBook(bookId)));
            }
        }

        private async Task LoadBookForEdit(int bookId)
        {
            try
            {
                var response = await httpClient.GetAsync($"{API_BASE_URL}/books/{bookId}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var book = JsonConvert.DeserializeObject<BookDto>(json);

                    ucBookForm.BookId = book.Id;
                    ucBookForm.Title = book.Title;
                    ucBookForm.Genre = book.Genre;
                    ucBookForm.PublishDate = book.PublishDate;
                    ucBookForm.Pages = book.Pages;
                    ucBookForm.Publisher = book.Publisher;
                    ucBookForm.ISBN = book.ISBN;
                    ucBookForm.Price = book.Price;
                    ucBookForm.Language = book.Language;
                    ucBookForm.AuthorId = book.AuthorId;

                    ucBookForm.SetFormTitle("Editar Libro");
                    ShowModal();
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al cargar libro: {ex.Message}", "error");
            }
        }

        private async Task DeleteBook(int bookId)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"{API_BASE_URL}/books/{bookId}");
                if (response.IsSuccessStatusCode)
                {
                    ShowMessage("Libro eliminado correctamente", "success");
                    await LoadBooks();
                }
                else
                {
                    ShowMessage("Error al eliminar el libro", "error");
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al eliminar libro: {ex.Message}", "error");
            }
        }

        protected void gvLibros_RowCancel(object sender, EventArgs e)
        {
            // Cancela el comportamiento predeterminado del GridView
            if (e is GridViewEditEventArgs editArgs)
                editArgs.Cancel = true;
            if (e is GridViewDeleteEventArgs deleteArgs)
                deleteArgs.Cancel = true;
        }

        private async void UcBookSearch_SearchRequested(object sender, EventArgs e)
        {
            try
            {
                var searchControl = (UserControls.BookSearch)sender;
                var url = $"{API_BASE_URL}/books/search?title={searchControl.Title}&genre={searchControl.Genre}&authorName={searchControl.AuthorName}";

                var response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var books = JsonConvert.DeserializeObject<List<BookDto>>(json);

                    // Mostrar resultados en el GridView del UserControl
                    searchControl.SearchResults = books;
                }
                else
                {
                    ShowMessage($"API Error: {response.StatusCode} - {response.ReasonPhrase}", "error");
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Error en la búsqueda: {ex.Message}", "error");
            }
        }

        private void UcBookSearch_ClearRequested(object sender, EventArgs e)
        {
            // Limpiar búsqueda y recargar libros (sincrónico)
            ucBookSearch.ClearSearchResults();
            LoadBooks().Wait(); // Espera el resultado sincrónicamente
        }

        private void UcBookSearch_BookSelected(object sender, UserControls.BookSelectedEventArgs e)
        {
            // Cargar el libro seleccionado en el formulario para edición (sincrónico)
            LoadBookForEdit(e.SelectedBook.Id).Wait();
        }

        private async void UcBookForm_SaveRequested(object sender, EventArgs e)
        {
            try
            {
                var book = new BookDto
                {
                    Id = ucBookForm.BookId,
                    Title = ucBookForm.Title,
                    Genre = ucBookForm.Genre,
                    PublishDate = ucBookForm.PublishDate,
                    Pages = ucBookForm.Pages,
                    Publisher = ucBookForm.Publisher,
                    ISBN = ucBookForm.ISBN,
                    Price = ucBookForm.Price,
                    Language = ucBookForm.Language,
                    AuthorId = ucBookForm.AuthorId
                };

                var json = JsonConvert.SerializeObject(book);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response;
                if (book.Id == 0)
                {
                    response = await httpClient.PostAsync($"{API_BASE_URL}/books", content);
                }
                else
                {
                    response = await httpClient.PutAsync($"{API_BASE_URL}/books/{book.Id}", content);
                }

                if (response.IsSuccessStatusCode)
                {
                    ShowMessage(book.Id == 0 ? "Libro creado correctamente" : "Libro actualizado correctamente", "success");
                    HideModal();
                    await LoadBooks();
                }
                else
                {
                    ShowMessage("Error al guardar el libro", "error");
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al guardar libro: {ex.Message}", "error");
            }
        }

        private void UcBookForm_CancelRequested(object sender, EventArgs e)
        {
            HideModal();
        }

        private void ShowModal()
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ShowModal", "showBookModal();", true);
        }

        private void HideModal()
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "HideModal", "hideBookModal();", true);
        }

        private void ShowMessage(string message, string type)
        {
            string script = $"showMessage('{message}', '{type}');";
            ScriptManager.RegisterStartupScript(this, GetType(), "ShowMessage", script, true);
        }

        protected void gvLibros_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Actualizar contador de libros
                int bookCount = gvLibros.Rows.Count;
                string script = $"document.getElementById('bookCount').textContent = '{bookCount} books';";
                ScriptManager.RegisterStartupScript(this, GetType(), "UpdateBookCount", script, true);
            }
        }
    }
}
