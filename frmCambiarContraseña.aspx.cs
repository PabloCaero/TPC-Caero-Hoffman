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
    public partial class frmCambiarContraseña : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["_NombreUsuario"] == null)
            {
                Session.Add("Error", "Debes loguearte para ingresar");
                Response.Redirect("Error.aspx", false);
            }         
        }

        protected void btnCambiarContrasena_Click(object sender, EventArgs e)
        {
            int Legajo = Convert.ToInt32(Session["_Legajo"]);//TOMA EL LEGAJO DE LA SESION INICIADA
            string nuevoPassword;
            Empleado empleado = new Empleado();
            EmpleadoNegocio empleadoNegocio = new EmpleadoNegocio();

            empleado.Legajo = Legajo;
            empleado.Contrasena = txtContrasenaAnterior.Text;

            nuevoPassword = txtContrasenaNueva.Text;
            try
            {
                empleadoNegocio.modificarPassword(empleado, nuevoPassword);
                lblContrasenaCambiada.Text = "Contraseña cambiada con éxito, regrese al menu principal.";
            }
            catch(Exception ex)
            {
                lblContrasenaCambiada.Text = "No se pudo cambiar la contraseña. ";
            }


        }

        protected void btnMenuPrincipal_Click(object sender, EventArgs e)
        {        
            int IDCargo = Convert.ToInt32((int)Session["_IDCargo"]);

            switch (IDCargo)
            {
                case 1:
                    Response.Redirect("frmMenuAdministrador.aspx");
                    break;
                case 2:
                    Response.Redirect("frmMenuSupervisor.aspx");
                    break;
                case 3:
                    Response.Redirect("frmMenuTelefonista.aspx");
                    break;

                default: Response.Redirect("Error.aspx");
                    break;
            }
        }
    }
}