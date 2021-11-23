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
    public partial class IncidenteForm : System.Web.UI.Page
    {
        private List<Cliente> buscaCliente;
        private List<Empleado> buscaEmpleado;
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

  
        protected void btnBuscarClientexDNI_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            ClienteNegocio clientenegocio = new ClienteNegocio();

            try
            {
                cliente.Dni = txtBuscarClientexDNI.Text;
                buscaCliente = clientenegocio.buscarDNI(cliente);
                dgvClientes.DataSource = buscaCliente;
                dgvClientes.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
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

        protected void btnCrearIncidente_Click(object sender, EventArgs e)
        {      
            IncidenteNegocio negocioIncidente = new IncidenteNegocio();
            Incidente nuevo = new Incidente();

            nuevo.Cliente = new Cliente();
            nuevo.Cliente.IDCliente = int.Parse(lblIDCliente.Text);

            nuevo.Empleado = new Empleado();
            nuevo.Empleado.Legajo = int.Parse(lblLegajoEmpleado.Text);

            nuevo.Detalles = txtDetalles.Text;
            negocioIncidente.agregar(nuevo);

            Response.Redirect("Default.aspx");
        }

        protected void dgvClientes_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = dgvClientes.Rows[e.NewSelectedIndex];
            lblIDCliente.Text = row.Cells[0].Text;     
        }

        protected void dgvEmpleados_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = dgvEmpleados.Rows[e.NewSelectedIndex];
            lblLegajoEmpleado.Text = row.Cells[0].Text;
        }
    }
}