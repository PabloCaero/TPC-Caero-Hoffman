using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPC_Caero_Hoffman
{
    public partial class frmMenuSupervisor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["_NombreUsuario"] != null && (int)Session["_IDCargo"] == 2)
            {
                string Nombre = Session["_Nombre"] != null ? Session["_Nombre"].ToString() : "";
                string Apellido = Session["_Apellido"] != null ? Session["_Apellido"].ToString() : "";
                int Legajo = Convert.ToInt32(Session["_Legajo"]);
                int IDCargo = Convert.ToInt32((int)Session["_IDCargo"]);
                string NombreCargo = "Supervisor";

                lblNombre.Text = Apellido + ", " + Nombre;
                lblLegajo.Text = Legajo.ToString();
                lblNombreCargo.Text = NombreCargo;
            }
            else
            {
                Response.Redirect("Error.aspx", false);
            }
        }



        protected void btnModificarIncidente_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmModificarDetallesIncidente.aspx");

        }

        protected void btnCrearIncidente_Click(object sender, EventArgs e)
        {
            Response.Redirect("IncidenteForm.aspx");
        }

        protected void btnCerrarIncidente_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCerrarResolverIncidente.aspx");

        }

        protected void btnIngresarCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClienteForm.aspx");
        }

        protected void btnBuscarClientexDNI_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmBuscarClientePorDNI.aspx");
        }

        protected void btnReabrirIncidente_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmReabrirIncidente.aspx");
        }

        protected void btnMisIncidentes_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmMisIncidentes.aspx");
        }

        protected void btnReasignarIncidente_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmReasignarIncidente.aspx");
        }

        protected void btnCambiarContrasena_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCambiarContraseña.aspx");
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmLogin.aspx");
        }
    }
}