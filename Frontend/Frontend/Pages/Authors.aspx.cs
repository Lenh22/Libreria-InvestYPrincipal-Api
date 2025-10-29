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
using Frontend.Dto;

namespace Frontend.Pages
{
    public partial class Authors : System.Web.UI.Page
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private const string API_BASE_URL = "http://localhost:7000/api";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cvBirthDate.ValueToCompare = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }


        protected async void Page_PreRender(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                await LoadAuthors();
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
                    gvAutores.DataSource = authors;
                    gvAutores.DataBind();

                    // Actualizar contador de autores
                    int authorCount = authors?.Count ?? 0;
                    ltAuthorCount.Text = $"{authorCount} authors";
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al cargar autores: {ex.Message}", "error");
            }
            return;
        }

        protected void btnNewAuthor_Click(object sender, EventArgs e)
        {
            ClearForm();
            ShowModal();
        }
        //RegisterAsyncTask para la asyncronia en web form clasico
        protected void gvAutores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int authorId = Convert.ToInt32(e.CommandArgument);
                RegisterAsyncTask(new PageAsyncTask(async () => await LoadAuthorForEdit(authorId)));
            }
            else if (e.CommandName == "Delete")
            {
                int authorId = Convert.ToInt32(e.CommandArgument);
                RegisterAsyncTask(new PageAsyncTask(async () => await DeleteAuthor(authorId)));
            }
        }
        // Para controlar los eventos RowEditing
        protected void gvAutores_RowCancel(object sender, EventArgs e)
        {
            // Evita el comportamiento predeterminado
            if (e is GridViewEditEventArgs editArgs)
                editArgs.Cancel = true;
            if (e is GridViewDeleteEventArgs deleteArgs)
                deleteArgs.Cancel = true;
        }

        private async Task LoadAuthorForEdit(int authorId)
        {
            try
            {
                var response = await httpClient.GetAsync($"{API_BASE_URL}/authors/{authorId}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var author = JsonConvert.DeserializeObject<AuthorDto>(json);

                    hdnAuthorId.Value = author.Id.ToString();
                    txtName.Text = author.Name;
                    txtBirthDate.Text = author.BirthDate.ToString("yyyy-MM-dd");
                    txtNationality.Text = author.Nationality;

                    ShowModal();
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al cargar autor: {ex.Message}", "error");
            }
        }

        private async Task DeleteAuthor(int authorId)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"{API_BASE_URL}/authors/{authorId}");
                if (response.IsSuccessStatusCode)
                {
                    ShowMessage("Autor eliminado correctamente", "success");
                    await LoadAuthors();
                }
                else
                {
                    //Verificar:Podriamos agregar los mensajes del Back si es que hay
                    var errorResponse = await response.Content.ReadAsStringAsync();

                    string errorMessage;
                    try
                    {
                        var errorObj = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, string>>(errorResponse);
                        errorMessage = errorObj != null && errorObj.ContainsKey("message")
                            ? errorObj["message"]
                            : "Error desconocido al eliminar el autor.";
                    }
                    catch
                    {
                        errorMessage = "Error desconocido al eliminar el autor.";
                    }

                    ShowMessage(errorMessage, "warning");
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al eliminar autor: {ex.Message}", "error");
            }
        }

        protected async void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    var author = new AuthorDto
                    {
                        Id = string.IsNullOrEmpty(hdnAuthorId.Value) ? 0 : Convert.ToInt32(hdnAuthorId.Value),
                        Name = txtName.Text.Trim(),
                        BirthDate = Convert.ToDateTime(txtBirthDate.Text),
                        Nationality = txtNationality.Text.Trim()
                    };

                    var json = JsonConvert.SerializeObject(author);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpResponseMessage response;
                    if (author.Id == 0)
                    {
                        response = await httpClient.PostAsync($"{API_BASE_URL}/authors", content);
                    }
                    else
                    {
                        response = await httpClient.PutAsync($"{API_BASE_URL}/authors/{author.Id}", content);
                    }

                    if (response.IsSuccessStatusCode)
                    {
                        ShowMessage(author.Id == 0 ? "Autor creado correctamente" : "Autor actualizado correctamente", "success");
                        HideModal();
                        await LoadAuthors();
                    }
                    else
                    {
                        ShowMessage("Error al guardar el autor", "error");
                    }
                }
                catch (Exception ex)
                {
                    ShowMessage($"Error al guardar autor: {ex.Message}", "error");
                }
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            HideModal();
        }

        private void ClearForm()
        {
            hdnAuthorId.Value = "0";
            txtName.Text = string.Empty;
            txtBirthDate.Text = string.Empty;
            txtNationality.Text = string.Empty;
        }

        private void ShowModal()
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAuthorModal", "showAuthorModal();", true);
        }

        private void HideModal()
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "HideModal", "hideAuthorModal();", true);
        }

        private void ShowMessage(string message, string type)
        {
            string script = $"showMessage('{message}', '{type}');";
            ScriptManager.RegisterStartupScript(this, GetType(), "ShowMessage", script, true);
        }
        protected void btnShowModal_Click(object sender, EventArgs e)
        {
            // Llama al JavaScript para mostrar el modal
            ScriptManager.RegisterStartupScript(this, GetType(), "ShowAuthorModal", "showAuthorModal();", true);
        }
    }
}