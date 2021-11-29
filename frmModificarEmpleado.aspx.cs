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
    public partial class frmModificarEmpleado : System.Web.UI.Page
    {
        private List<Empleado> buscaEmpleado;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["_NombreUsuario"] == null && (int)Session["_IDCargo"] != 1)
            {
                Session.Add("Error", "Debes loguearte para ingresar");
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnBuscarEmpleadoxLegajo_Click(object sender, EventArgs e)
        {
            Empleado empleado = new Empleado();
            EmpleadoNegocio empleadonegocio = new EmpleadoNegocio();

            try
            {
                empleado.Legajo = int.Parse(txtBuscarEmpleadoxID.Text);
                buscaEmpleado = empleadonegocio.buscarLegajo(empleado);
                dgvEmpleados.DataSource = buscaEmpleado;
                dgvEmpleados.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        protected void rowCancelEditEvent(object sender, GridViewCancelEditEventArgs e)
        {
            
        }

        protected void rowEditingEvent(object sender, GridViewEditEventArgs e)
        {

        }

        protected void rowUpdatingEvent(object sender, GridViewUpdateEventArgs e)
        {
            Empleado empleado = new Empleado();
            EmpleadoNegocio negocioEmpleado = new EmpleadoNegocio();
            GridViewRow fila = dgvEmpleados.Rows[e.RowIndex];

            CargoNegocio cargonegocio = new CargoNegocio();

           
            //PASOS PARA EDITAR EMPLEADO
            empleado.Legajo = Convert.ToInt32(dgvEmpleados.DataKeys[e.RowIndex].Values[0]);
            empleado.Dni = ((fila.FindControl("txtDNI")) as TextBox).Text.ToUpper();
            empleado.Nombre = ((fila.FindControl("txtNombre")) as TextBox).Text.ToUpper();
            empleado.Apellido = ((fila.FindControl("txtApellido")) as TextBox).Text.ToUpper();
            empleado.Email = ((fila.FindControl("txtEmail")) as TextBox).Text.ToUpper();
            empleado.Telefono = ((fila.FindControl("txtTelefono")) as TextBox).Text.ToUpper();

            



            negocioEmpleado.modificar(empleado);

            
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