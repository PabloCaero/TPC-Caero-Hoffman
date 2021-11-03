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
    public partial class IncidenteForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Incidente incidente = new Incidente();
            IncidenteNegocio negocio = new IncidenteNegocio();

            incidente.Empleado = new Empleado();
            incidente.Empleado.Legajo = int.Parse(txtIDEmpleado.Text);
            incidente.Cliente = new Cliente();
            incidente.Cliente.IDCliente = int.Parse(txtIDCliente.Text);
            incidente.Detalles = txtDetalles.Text;
            incidente.Estado = new Estado();
            incidente.Estado.IDEstado = int.Parse(txtEstado.Text);
            incidente.ComentarioFinal = txtComentarioFinal.Text;
    

            negocio.agregar(incidente);
            Response.Redirect("Default.aspx");
        }
    }
}