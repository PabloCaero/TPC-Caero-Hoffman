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
    public partial class EmpleadoForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["_NombreUsuario"] == null && (int)Session["_Cargo"] == 2 || (int)Session["_Cargo"] == 3)
            {
                Session.Add("Error", "Debes loguearte para ingresar");
                Response.Redirect("Error.aspx", false);
            }
            else
            {
                CargoNegocio cargonegocio = new CargoNegocio();
                try
                {
                    if (!IsPostBack)
                    {
                        List<Cargo> listCargo = cargonegocio.listar();

                        ddlCargos.DataSource = listCargo;
                        ddlCargos.DataTextField = "Nombre_Cargo";
                        ddlCargos.DataValueField = "IDCargo";
                        ddlCargos.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    Session.Add("error", ex);

                }
            }

        }

        protected void btnCargarEmpleado_Click(object sender, EventArgs e)
        {
            Empleado empleado = new Empleado();
            Direccion direccion = new Direccion();
            EmpleadoNegocio negocioEmpleado = new EmpleadoNegocio();
            DireccionNegocio negocioDireccion = new DireccionNegocio();

            direccion.Calle = txtCalle.Text;
            direccion.Numero = int.Parse(txtAltura.Text);
            direccion.Localidad = txtLocalidad.Text;
            direccion.Provincia = txtProvincia.Text;
            direccion.Codigo_Postal = txtCodigoPostal.Text;
            negocioDireccion.agregar(direccion);

            empleado.Cargo = new Cargo();
            empleado.Cargo.IDCargo = int.Parse(ddlCargos.SelectedValue);

            empleado.Nombre = txtNombre.Text;
            empleado.NombreUsuario = txtNombreUsuario.Text;
            empleado.Contrasena = txtContrasena.Text;
            empleado.Apellido = txtApellido.Text;
            empleado.Dni = txtDNI.Text;
            empleado.Email = txtEmail.Text;
            empleado.Fecha_Nac = DateTime.Parse(txtFechaNacimiento.Text);
            empleado.Telefono = txtTelefono.Text;
            negocioEmpleado.agregar(empleado);

            
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

                default:
                    Response.Redirect("Error.aspx");
                    break;
            }
        }
    }
}