using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Libreria_InvestYPrincipal_Web.UserControls
{
    public partial class SearchBox : System.Web.UI.UserControl
    {
        public event EventHandler BuscarClicked;
        public string Titulo => txtTitulo.Text;
        public string Autor => txtAutor.Text;

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            // Lanza el evento para notificar a la página que use el control
            BuscarClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}