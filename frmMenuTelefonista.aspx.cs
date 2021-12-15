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
    public partial class frmMenuTelefonista : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["_NombreUsuario"] == null)
            {
                Session.Add("Error", "Debes loguearte para ingresar");
                Response.Redirect("Error.aspx", false);
            }
            else
            {
                string Nombre = Session["_Nombre"] != null ? Session["_Nombre"].ToString() : "";
                string Apellido = Session["_Apellido"] != null ? Session["_Apellido"].ToString() : "";
                int Legajo = Convert.ToInt32(Session["_Legajo"]);
                int IDCargo = Convert.ToInt32((int)Session["_IDCargo"]);
                string NombreCargo = "Telefonista";

                lblNombre.Text = Apellido + ", " + Nombre;
                lblLegajo.Text = Legajo.ToString();
                lblNombreCargo.Text = NombreCargo;
            }

        }

        protected void btnCerrarIncidente_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCerrarResolverIncidenteTelefonista.aspx");

        }

        protected void btnModificarIncidente_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmModificarDetallesIncidenteTelefonista.aspx");

        }

        protected void btnCrearIncidente_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCrearIncidentePropio.aspx");
        }

        protected void btnBuscarClientexDNI_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmBuscarClientePorDNI.aspx");
        }

        protected void btnIngresarCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClienteForm.aspx");
        }


        protected void btnMisIncidentes_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmMisIncidentes.aspx");
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