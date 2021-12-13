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
    public partial class frmReabrirIncidente : System.Web.UI.Page
    {
        private List<Incidente> buscaIncidente;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["_NombreUsuario"] == null)
            {
                Session.Add("Error", "Debes loguearte para ingresar");
                Response.Redirect("Error.aspx", false);
            }
            if ((int)Session["_IDCargo"] == 3)
            {
                Session.Add("Error", "No tienes los permisos suficientes para ingresar a esta sección.");
                Response.Redirect("Error.aspx", false);
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

        protected void dgvIncidentes_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = dgvIncidentes.Rows[e.NewSelectedIndex];
            lblIDIncidente.Text = row.Cells[0].Text;
            lblSeleccion.Text = "Incidente seleccionado";
        }

        protected void btnReabrirIncidente_Click(object sender, EventArgs e)
        {
            IncidenteNegocio negocioIncidente = new IncidenteNegocio();
            Incidente nuevo = new Incidente();
            Incidente consulta = new Incidente();

            nuevo.ID = int.Parse(lblIDIncidente.Text);

            //VERIFICO EL ESTADO DEL INCIDENTE
            consulta = negocioIncidente.buscarIndividualID(nuevo);

            switch (consulta.Estado.IDEstado)
            {
                case 1:
                    lblConfirmacion.Text = "Este incidente se encuentra ABIERTO, no se puede REABRIR";
                    break;
                case 2:
                    lblConfirmacion.Text = "Este incidente se encuentra EN ANALISIS, no se puede REABRIR";
                    break;
                case 4:
                    lblConfirmacion.Text = "Este incidente se encuentra REABIERTO, no se puede REABRIR";
                    break;
                case 5:
                    lblConfirmacion.Text = "Este incidente se encuentra ASIGNADO, no se puede REABRIR";
                    break;
                default:
                    try
                    {
                        negocioIncidente.reabrirIncidente(nuevo);


                        //ENVIA MAIL AL CLIENTE
                        IncidenteNegocio negocio = new IncidenteNegocio();
                        Incidente ultimo = new Incidente();

                        ultimo = negocio.buscarIndividualID(nuevo);

                        EmailService emailService = new EmailService();
                        emailService.armarCorreoIncidenteReabierto(ultimo);
                        try
                        {
                            emailService.enviarMail();
                        }
                        catch (Exception ex)
                        {
                            lblConfirmacion.Text = "Atención: Incidente #" + ultimo.ID + " reabierto . No se envió mail al cliente.";

                        }

                        //ENVIA MAIL AL EMPLEADO  
                        emailService.armarCorreoIncidenteReabiertoEmpleado(ultimo);
                        try
                        {
                            emailService.enviarMail();
                            lblConfirmacion.Text = "Atención: Incidente #" + ultimo.ID + " reabierto. Regrese al Menú Principal.";

                        }
                        catch (Exception ex)
                        {
                            lblConfirmacion.Text = "Atención: Incidente #" + ultimo.ID + " reabierto . No se envió mail al empleado. Regrese al Menú Principal.";
                        }
                    }
                    catch (Exception ex)
                    {
                        lblConfirmacion.Text = "Atención: Ocurrió un error. Regrese al Menú Principal.";
                    }

                    break;
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