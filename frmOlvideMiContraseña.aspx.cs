using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Servicios;
using Negocio;

namespace TPC_Caero_Hoffman
{
    public partial class frmOlvideMiContraseña : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmLogin.aspx");
        }

        protected void btnRecuperarPassword_Click(object sender, EventArgs e)
        {
            Empleado empleado = new Empleado();
            EmpleadoNegocio empleadoNegocio = new EmpleadoNegocio();

            

            try
            {
                empleado.Email = txtEmail.Text;
                empleado = empleadoNegocio.buscarUsuarioxEmail(empleado);
                EmailService emailService = new EmailService();
                emailService.armarCorreoOlvideMiContrasena(empleado);
                emailService.enviarMail();
                lblEstadoEnvio.Text = "Se ha enviado un correo a su casilla, reviselo para poder ingresar a la plataforma";
            }
            catch (Exception ex)
            {
                lblEstadoEnvio.Text = "Mail incorrecto";

            }

        }
    }
}