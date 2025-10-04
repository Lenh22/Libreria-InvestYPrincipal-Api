using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Libreria_InvestYPrincipal_Web.Dto;

namespace Libreria_InvestYPrincipal_Web.Pages
{
    public partial class Authors : System.Web.UI.Page
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private const string API_BASE_URL = "https://localhost:7000/api";//Verificar esto

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAuthors();
            }
        }

        private async void LoadAuthors()
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
                }
            }
            catch (Exception ex)
            {
                ShowMessage($"Error al cargar autores: {ex.Message}", "error");
            }
        }

        protected void btnNewAuthor_Click(object sender, EventArgs e)
        {
            ClearForm();
            ShowModal();
        }

        protected void gvAutores_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                int authorId = Convert.ToInt32(e.CommandArgument);
                LoadAuthorForEdit(authorId);
            }
            else if (e.CommandName == "Delete")
            {
                int authorId = Convert.ToInt32(e.CommandArgument);
                DeleteAuthor(authorId);
            }
        }

        private async void LoadAuthorForEdit(int authorId)
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

        private async void DeleteAuthor(int authorId)
        {
            try
            {
                var response = await httpClient.DeleteAsync($"{API_BASE_URL}/authors/{authorId}");
                if (response.IsSuccessStatusCode)
                {
                    ShowMessage("Autor eliminado correctamente", "success");
                    LoadAuthors();
                }
                else
                {
                    ShowMessage("Error al eliminar el autor", "error");
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
                        LoadAuthors();
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
            ScriptManager.RegisterStartupScript(this, GetType(), "ShowModal", "showAuthorModal();", true);
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

    }
}