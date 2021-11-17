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

        protected void btnCargarIncidente_Click(object sender, EventArgs e)
        {
            Incidente incidente = new Incidente();
            IncidenteNegocio negocio = new IncidenteNegocio();

            //FALTA PODER 
            incidente.Cliente = new Cliente();
            incidente.Cliente.IDCliente = int.Parse(dgvClientes.DataKeys);

            incidente.Empleado = new Empleado();
            incidente.Empleado.Legajo = int.Parse(dgvEmpleados.DataKeys.GetEnumerator );

            incidente.Detalles = txtDetalles.Text;


            negocio.agregar(incidente);
            Response.Redirect("Default.aspx");
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
                empleado.Legajo = int.Parse(txtBuscarEmpleadoxLegajo.Text);
                buscaEmpleado = empleadonegocio.buscarLegajo(empleado);
                dgvEmpleados.DataSource = buscaEmpleado;
                dgvEmpleados.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);

            }
        }
    }
}