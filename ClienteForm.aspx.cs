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

        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            ClienteNegocio negocio = new ClienteNegocio();

            cliente.Nombre = txtNombre.Text;
            cliente.Apellido = txtApellido.Text;
            cliente.Dni = txtDNI.Text;
            cliente.Direccion = new Direccion();
            cliente.Direccion.IDDireccion = 1;
            cliente.Email = "maildeprueba@frgp.com";
            cliente.Telefono = "1163088646";

            negocio.agregar(cliente);
            Response.Redirect("Default.aspx");
        }
    }
}