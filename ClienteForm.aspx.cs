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
    public partial class ClienteForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["_NombreUsuario"] == null)
            {
                Session.Add("Error", "Debes loguearte para ingresar");
                Response.Redirect("Error.aspx", false);
            }
        }

        protected void btnCargarCliente_Click(object sender, EventArgs e)
        {
            //IMPORTANTE PARA VALIDAR
            Page.Validate();
            if (!Page.IsValid)
                return;

            try
            {
                Cliente cliente = new Cliente();
                Direccion direccion = new Direccion();
                ClienteNegocio negocioCliente = new ClienteNegocio();
                DireccionNegocio negocioDireccion = new DireccionNegocio();

                direccion.Calle = txtCalle.Text;
                direccion.Numero = int.Parse(txtAltura.Text);
                direccion.Localidad = txtLocalidad.Text;
                direccion.Provincia = txtProvincia.Text;
                direccion.Codigo_Postal = txtCodigoPostal.Text;
                negocioDireccion.agregar(direccion);

                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.Dni = txtDNI.Text;
                cliente.Email = txtEmail.Text;
                cliente.Fecha_Nac = DateTime.Parse(txtFechaNacimiento.Text);
                cliente.Telefono = txtTelefono.Text;
                negocioCliente.agregar(cliente);
                lblConfirmacion.Text = "Atención: Cliente agregado correctamente, regrese al Menu Principal.";
            }
            catch(Exception ex)
            {
                lblConfirmacion.Text = "No se pudo cargar el cliente, intente nuevamente.";
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

                default:
                    Response.Redirect("Error.aspx");
                    break;
            }
        }
    }
}