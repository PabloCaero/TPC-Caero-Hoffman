using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TPC_Caero_Hoffman
{
    public partial class GestionDirecciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DireccionNegocio negocio3 = new DireccionNegocio();
            dgvDirecciones.DataSource = negocio3.listar();
            dgvDirecciones.DataBind();
        }
    }
}