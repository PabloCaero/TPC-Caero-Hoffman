using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using Servicios;

namespace TPC_Caero_Hoffman
{
    public partial class frmReasignarIncidente : System.Web.UI.Page
    {
        private List<Empleado> buscaEmpleado;
        private List<Incidente> buscaIncidente;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["_NombreUsuario"] == null && (int)Session["_IDCargo"] != 2 || (int)Session["_IDCargo"] != 1)
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

        protected void dgvEmpleados_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = dgvEmpleados.Rows[e.NewSelectedIndex];
            lblLegajoEmpleado.Text = row.Cells[0].Text;
            lblSeleccionEmpleado.Text = "Empleado seleccionado.";
        }

        protected void dgvIncidentes_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = dgvIncidentes.Rows[e.NewSelectedIndex];
            lblIDIncidente.Text = row.Cells[0].Text;
            lblSeleccionEmpleado.Text = "Incidente seleccionado.";
        }

        protected void btnReasignarIncidente_Click(object sender, EventArgs e)
        {
            try
            {

                IncidenteNegocio negocioIncidente = new IncidenteNegocio();
                Incidente nuevo = new Incidente();

                nuevo.Empleado = new Empleado();
                nuevo.Empleado.Legajo = int.Parse(lblLegajoEmpleado.Text);

                nuevo.ID = int.Parse(lblIDIncidente.Text);
                negocioIncidente.asignarIncidente(nuevo);


                //ENVIA MAIL AL CLIENTE
                IncidenteNegocio negocio = new IncidenteNegocio();
                Incidente ultimo = new Incidente();

                ultimo = negocio.buscarIndividualID(nuevo);

                EmailService emailService = new EmailService();
                emailService.armarCorreoIncidenteAsignadoCliente(ultimo);
                try
                {
                    emailService.enviarMail();

                }
                catch (Exception ex)
                {
                    lblConfirmacion.Text = "Atención: Incidente #" + ultimo.ID + " reasignado a Leg. " + ultimo.Empleado.Legajo + ". No se envió mail de reasignación al cliente.";
                }

                //ENVIA MAIL AL EMPLEADO  
                emailService.armarCorreoIncidenteAsignadoEmpleado(ultimo);
                try
                {
                    emailService.enviarMail();
                    lblConfirmacion.Text = "Atención: Incidente #" + ultimo.ID + " reasignado a Leg. " + ultimo.Empleado.Legajo + ". Regrese al Menú Principal.";

                }
                catch (Exception ex)
                {
                    lblConfirmacion.Text = "Atención: Incidente #" + ultimo.ID + " reasignado a Leg. " + ultimo.Empleado.Legajo + ". No se envió mail de reasignación al empleado. Regrese al Menú Principal.";
                }

            }
            catch (Exception ex)
            {
                lblConfirmacion.Text = "Atención: Ocurrió un error.";

            }
        }

            protected void btnBuscarIncidentexID_Click(object sender, EventArgs e)
            {
                Incidente incidente = new Incidente();
                IncidenteNegocio incidentenegocio = new IncidenteNegocio();

                try
                {
                    incidente.ID = int.Parse(txtBuscarIncidentexID.Text);
                    buscaIncidente = incidentenegocio.buscarID(incidente);
                    dgvIncidentes.DataSource = buscaIncidente;
                    dgvIncidentes.DataBind();
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex);

                }
            }



            protected void btnMenuPrincipal_Click1(object sender, EventArgs e)
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

        protected void btnBuscarIncidentexApeEmpleado_Click(object sender, EventArgs e)
        {
            Incidente incidente = new Incidente();
            IncidenteNegocio incidentenegocio = new IncidenteNegocio();

            try
            {
                incidente.Empleado = new Empleado();
                incidente.Empleado.Apellido = txtBuscarIncidentexApeEmpleado.Text;
                buscaIncidente = incidentenegocio.buscarApellidoEmpleado(incidente);
                dgvIncidentes.DataSource = buscaIncidente;
                dgvIncidentes.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);

            }
        }

        protected void btnBuscarIncidentexApeCliente_Click(object sender, EventArgs e)
        {
            Incidente incidente = new Incidente();
            IncidenteNegocio incidentenegocio = new IncidenteNegocio();

            try
            {
                incidente.Cliente = new Cliente();
                incidente.Cliente.Apellido = txtBuscarIncidentexApeCliente.Text;
                buscaIncidente = incidentenegocio.buscarApellidoCliente(incidente);
                dgvIncidentes.DataSource = buscaIncidente;
                dgvIncidentes.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);

            }
        }
    }
    }

