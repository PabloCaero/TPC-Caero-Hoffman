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
            //PARA CERRAR SESION 
            Session.Add("_IDCargo", 0);
            Session.Add("_NombreUsuario", null);
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
                    //TELEFONISTA
                        empleado = negocio.buscarNombreUsuario(empleado);
                      
                        Session.Add("_NombreUsuario", empleado.NombreUsuario);
                        Session.Add("_Nombre", empleado.Nombre);
                        Session.Add("_Apellido", empleado.Apellido);            
                        Session.Add("_IDCargo", 3);//ID CARGO TELEFONISTA                
                        Session.Add("_Legajo", empleado.Legajo);
                        Response.Redirect("frmMenuTelefonista.aspx");
                    }
                    else
                    {
                        if (negocio.Loguear(empleado) == 2)
                        {
                        //SUPERVISOR
                        empleado = negocio.buscarNombreUsuario(empleado);
                       
                        Session.Add("_NombreUsuario", empleado.NombreUsuario);
                        Session.Add("_Nombre", empleado.Nombre);
                        Session.Add("_Apellido", empleado.Apellido);
                        Session.Add("_IDCargo", 2);//ID CARGO SUPERVISOR
                        Session.Add("_Legajo", empleado.Legajo);     
                        Response.Redirect("frmMenuSupervisor.aspx");
                        }
                        else
                        {
                            if (negocio.Loguear(empleado) == 1)
                            {
                            //ADMINISTRADOR
                            empleado = negocio.buscarNombreUsuario(empleado);
                       
                            Session.Add("_NombreUsuario", empleado.NombreUsuario);
                            Session.Add("_Nombre", empleado.Nombre);
                            Session.Add("_Apellido", empleado.Apellido);
                            Session.Add("_IDCargo", 1);//ID CARGO ADMINISTRADOR    
                            Session.Add("_Legajo", empleado.Legajo);           
                            Response.Redirect("frmMenuAdministrador.aspx");
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