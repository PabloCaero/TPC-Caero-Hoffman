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
    public partial class frmLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            Empleado empleado = new Empleado();
            EmpleadoNegocio negocio = new EmpleadoNegocio();
            try
            {              
                empleado.NombreUsuario = txtNombreUsuario.Text;
                empleado.Contrasena = txtPassword.Text;

             //INGRESO SEGUN CARGO
                    if (negocio.Loguear(empleado) == 3)
                    {
                        Session.Add("NombreUsuario", empleado);
                        Response.Redirect("frmMenuTelefonista.aspx");
                    }
                    else
                    {
                        if (negocio.Loguear(empleado) == 2)
                        {
                            Session.Add("NombreUsuario", empleado);
                            Response.Redirect("frmMenuSupervisor.aspx");
                        }
                        else
                        {
                            if (negocio.Loguear(empleado) == 1)
                            {
                                Session.Add("NombreUsuario", empleado);
                                Response.Redirect("Default.aspx");
                            }
                            else
                            {
                                Session.Add("Error", "Usuario o Password incorrectos");
                                Response.Redirect("Error.aspx");
                            }
                        }
                    }
                    
                    
            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
            }

        }
    }
}