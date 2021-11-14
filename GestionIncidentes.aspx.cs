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
    public partial class GestionIncidentes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IncidenteNegocio negocio2 = new IncidenteNegocio();
            dgvIncidentes.DataSource = negocio2.listar();
            dgvIncidentes.DataBind();
        }
    }
}