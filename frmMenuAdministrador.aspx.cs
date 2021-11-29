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

            if (Session["_NombreUsuario"] == null && (int)Session["_IDCargo"] != 1)
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
                string NombreCargo = "Administrador";

                lblNombre.Text = Apellido + ", " + Nombre;
                lblLegajo.Text = Legajo.ToString();
                lblNombreCargo.Text = NombreCargo;
            }


        }

        //MENU DE CLIENTES
        protected void btnIngresarCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClienteForm.aspx");
        }

       
      
        protected void btnBuscarClientexDNI_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmBuscarClientePorDNI.aspx");
        }

        protected void btnModificarCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmModificarCliente.aspx");
        }

        protected void brnEliminarCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmEliminarCliente.aspx");
        }

        //MENU DE INCIDENTES
        protected void btnCrearIncidente_Click(object sender, EventArgs e)
        {
            Response.Redirect("IncidenteForm.aspx");
        }
        protected void btnBuscarIncidentexID_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmBuscarIncidentePorID.aspx");
        }

        protected void btnModificarIncidente_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmModificarDetallesIncidente.aspx");
        }

        protected void btnReasignarIncidente_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmReasignarIncidente.aspx");

        }

        protected void btnCerrarIncidente_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmCerrarResolverIncidente.aspx");
        }

        protected void btnReabrirIncidente_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmReabrirIncidente.aspx");

        }


        //MENU DE EMPLEADOS
        protected void btnRegistrarEmpleado_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmpleadoForm.aspx");
        }

        protected void btnModificarEmpleado_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmModificarEmpleado.aspx");
        }

        protected void btnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmEliminarEmpleado.aspx");
        }

        protected void btnBuscarEmpleado_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmBuscarEmpleado.aspx");
        }

        protected void btnReporteIncidentes_Click(object sender, EventArgs e)
        {
            Response.Redirect("ReportesExcel.aspx");
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