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
    public partial class GestionEstados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EstadoNegocio negocio5 = new EstadoNegocio();
            dgvEstados.DataSource = negocio5.listar();
            dgvEstados.DataBind();


        }
    }
}