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
    public partial class frmCerrarIncidente : System.Web.UI.Page
    {
        private List<Incidente> buscaIncidente;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["_NombreUsuario"] == null && (int)Session["_Cargo"] != 1)
            {
                Session.Add("Error", "Debes loguearte para ingresar");
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void dgvIncidentes_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = dgvIncidentes.Rows[e.NewSelectedIndex];
            lblIDIncidente.Text = row.Cells[0].Text;
            lblIncidenteSeleccionado.Text = "Incidente Seleccionado";
        }

        protected void btnCerrarIncidente_Click(object sender, EventArgs e)
        {
            try
            {
                IncidenteNegocio negocioIncidente = new IncidenteNegocio();
                Incidente nuevo = new Incidente();

                nuevo.ID = int.Parse(lblIDIncidente.Text);
                nuevo.Detalles = txtComentarioFinal.Text;
                negocioIncidente.cerrarIncidente(nuevo);

                //ENVIA MAIL AL CLIENTE
                IncidenteNegocio negocio = new IncidenteNegocio();
                Incidente ultimo = new Incidente();

                ultimo = negocio.buscarIndividualID(nuevo);

                EmailService emailService = new EmailService();
                emailService.armarCorreoIncidenteCerradoCliente(ultimo);
                try
                {
                    emailService.enviarMail();
                }
                catch (Exception ex)
                {
                    lblConfirmacion.Text = "Atención: Incidente cerrado, mail a cliente no enviado";
                }

                //ENVIA MAIL AL EMPLEADO  
                emailService.armarCorreoIncidenteCerradoEmpleado(ultimo);
                try
                {
                    emailService.enviarMail();
                    lblConfirmacion.Text = "Atención: Incidente cerrado, regrese al Menú Principal.";
                }
                catch (Exception ex)
                {
                    lblConfirmacion.Text = "Atención: Incidente cerrado, mail a empleado no enviado.";
                }
            }
            catch(Exception ex)
            {
                lblConfirmacion.Text = "Atención: No se pudo cerrar el incidente, intente nuevamente.";
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

        protected void btnResolverIncidente_Click(object sender, EventArgs e)
        {
            try
            {
                IncidenteNegocio negocioIncidente = new IncidenteNegocio();
                Incidente nuevo = new Incidente();

                nuevo.ID = int.Parse(lblIDIncidente.Text);
                nuevo.Detalles = txtComentarioFinal.Text;
                negocioIncidente.resolverIncidente(nuevo);

                //ENVIA MAIL AL CLIENTE
                IncidenteNegocio negocio = new IncidenteNegocio();
                Incidente ultimo = new Incidente();

                ultimo = negocio.buscarIndividualID(nuevo);

                EmailService emailService = new EmailService();
                emailService.armarCorreoIncidenteResueltoCliente(ultimo);
                try
                {
                    emailService.enviarMail();

                }
                catch (Exception ex)
                {
                    lblConfirmacion.Text = "Atención: Incidente resuelto, mail a cliente no enviado.";
                }

                //ENVIA MAIL AL EMPLEADO  
                emailService.armarCorreoIncidenteResueltoEmpleado(ultimo);
                try
                {
                    emailService.enviarMail();
                    lblConfirmacion.Text = "Atención: Incidente resuelto, regrese al Menú Principal.";

                }
                catch (Exception ex)
                {
                    lblConfirmacion.Text = "Atención: Incidente resuelto, mail a empleado no enviado.";

                }
            }
            catch(Exception ex)
            {
                lblConfirmacion.Text = "Atención: No se pudo resolver el incidente, intente nuevamente.";

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