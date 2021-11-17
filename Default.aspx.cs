using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace TPC_Caero_Hoffman
{
    public partial class _Default : Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
          

        }


        protected void btnIngresarCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClienteForm.aspx");
        }

        protected void btnRegistrarEmpleado_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmpleadoForm.aspx");
        }

       

        protected void btnBuscarClientexDNI_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmBuscarClientePorDNI.aspx");
        }

        protected void btnBuscarIncidentexID_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmBuscarIncidentePorID.aspx");
        }


        protected void btnCrearIncidente_Click(object sender, EventArgs e)
        {
            Response.Redirect("IncidenteForm.aspx");
        }
    }
}