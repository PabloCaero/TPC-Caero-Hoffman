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
          
            Response.Redirect("Default.aspx");

        }
    }
}