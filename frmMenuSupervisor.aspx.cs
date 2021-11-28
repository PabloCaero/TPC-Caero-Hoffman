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
            if (Session["_NombreUsuario"] == null && (int)Session["_IDCargo"] != 2)
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
                string NombreCargo = "Supervisor";

                lblNombre.Text = Apellido + ", " + Nombre;
                lblLegajo.Text = Legajo.ToString();
                lblNombreCargo.Text = NombreCargo;
            }




        }



        protected void btnModificarIncidente_Click(object sender, EventArgs e)
        {

        }

        protected void btnCrearIncidente_Click(object sender, EventArgs e)
        {

        }

        protected void btnCerrarIncidente_Click(object sender, EventArgs e)
        {

        }

        protected void btnIngresarCliente_Click(object sender, EventArgs e)
        {

        }

        protected void btnBuscarClientexDNI_Click(object sender, EventArgs e)
        {

        }

        protected void btnReabrirIncidente_Click(object sender, EventArgs e)
        {

        }

        protected void btnMisIncidentes_Click(object sender, EventArgs e)
        {

        }

        protected void btnReasignarIncidente_Click(object sender, EventArgs e)
        {

        }

        protected void btnCambiarContrasena_Click(object sender, EventArgs e)
        {

        }
    }
}