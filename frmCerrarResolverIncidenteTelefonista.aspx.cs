using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Servicios;
using Dominio;
using Negocio;

namespace TPC_Caero_Hoffman
{
    public partial class frmCerrarResolverIncidenteTelefonista : System.Web.UI.Page
    {
        private List<Incidente> buscaIncidente;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["_NombreUsuario"] == null)
            {
                Session.Add("Error", "Debes loguearte para ingresar");
                Response.Redirect("Error.aspx", false);
            }

        }

        protected void dgvIncidentes_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = dgvIncidentes.Rows[e.NewSelectedIndex];
            lblIDIncidente.Text = row.Cells[0].Text;
            lblIncidenteSeleccionado.Text = "Incidente #" + lblIDIncidente.Text + " Seleccionado";
        }

        protected void btnCerrarIncidente_Click(object sender, EventArgs e)
        {
            try
            {
                IncidenteNegocio negocioIncidente = new IncidenteNegocio();
                Incidente nuevo = new Incidente();
                Incidente consulta = new Incidente();

                nuevo.ID = int.Parse(lblIDIncidente.Text);
                //VERIFICO EL ESTADO DEL INCIDENTE
                consulta = negocioIncidente.buscarIndividualID(nuevo);

                switch (consulta.Estado.IDEstado)
                {
                    case 6:
                        lblConfirmacion.Text = "Este incidente se encuentra RESUELTO, no se puede CERRAR";
                        break;
                    case 3:
                        lblConfirmacion.Text = "Este incidente se encuentra CERRADO, no se puede CERRAR";
                        break;
                    default:
                        try
                        {
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

                                lblConfirmacion.Text = "Atención: Incidente cerrado, mail a cliente no enviado.";
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
                        catch (Exception ex)
                        {
                            lblConfirmacion.Text = "Atención: No se pudo cerrar el incidente, intente nuevamente.";
                        }
                        break;
                }
            }
            catch(Exception ex)
            {
                lblConfirmacion.Text = "Atención: Ocurrió un Error, regrese al Menú Principal.";
            }
            
            

        }

        protected void btnBuscarIncidentexID_Click(object sender, EventArgs e)
        {
            Incidente incidente = new Incidente();
            IncidenteNegocio incidentenegocio = new IncidenteNegocio();
            int Legajo = Convert.ToInt32(Session["_Legajo"]);
            try
            {
                incidente.ID = int.Parse(txtBuscarIncidentexID.Text);
                incidente.Empleado = new Empleado();
                incidente.Empleado.Legajo = Legajo;
                buscaIncidente = incidentenegocio.buscarIncidentePorIDyLegajo(incidente);
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
                IncidenteNegocio negocioIncidente = new IncidenteNegocio();
                Incidente nuevo = new Incidente();
                Incidente consulta = new Incidente();

            nuevo.ID = int.Parse(lblIDIncidente.Text);

            //VERIFICO EL ESTADO DEL INCIDENTE
            consulta = negocioIncidente.buscarIndividualID(nuevo);
            switch (consulta.Estado.IDEstado)
            {
                case 6:
                    lblConfirmacion.Text = "Este incidente se encuentra RESUELTO, no se puede RESOLVER";
                    break;
                case 3:
                    lblConfirmacion.Text = "Este incidente se encuentra CERRADO, no se puede RESOLVER";
                    break;
                default:
                    try
                    {
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
                    catch (Exception ex)
                    {
                        lblConfirmacion.Text = "Atención: No se pudo resolver el incidente, intente nuevamente.";

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


        protected void btnAbiertos_Click(object sender, EventArgs e)
        {
            Incidente incidente = new Incidente();
            IncidenteNegocio incidentenegocio = new IncidenteNegocio();
            int Legajo = Convert.ToInt32(Session["_Legajo"]);
            try
            {
                buscaIncidente = incidentenegocio.buscarIncidentesxLegajoAsignadoyEstadoAbierto(Legajo);
                dgvIncidentes.DataSource = buscaIncidente;
                dgvIncidentes.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);

            }
        }

        protected void btnEnAnalisis_Click(object sender, EventArgs e)
        {
            Incidente incidente = new Incidente();
            IncidenteNegocio incidentenegocio = new IncidenteNegocio();
            int Legajo = Convert.ToInt32(Session["_Legajo"]);
            try
            {
                buscaIncidente = incidentenegocio.buscarIncidentesxLegajoAsignadoyEstadoEnAnalisis(Legajo);
                dgvIncidentes.DataSource = buscaIncidente;
                dgvIncidentes.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);

            }
        }

        protected void btnAsignados_Click(object sender, EventArgs e)
        {
            Incidente incidente = new Incidente();
            IncidenteNegocio incidentenegocio = new IncidenteNegocio();
            int Legajo = Convert.ToInt32(Session["_Legajo"]);
            try
            {
                buscaIncidente = incidentenegocio.buscarIncidentesxLegajoAsignadoyEstadoAsignado(Legajo);
                dgvIncidentes.DataSource = buscaIncidente;
                dgvIncidentes.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);

            }
        }

        protected void btnReabiertos_Click(object sender, EventArgs e)
        {
            Incidente incidente = new Incidente();
            IncidenteNegocio incidentenegocio = new IncidenteNegocio();
            int Legajo = Convert.ToInt32(Session["_Legajo"]);
            try
            {
                buscaIncidente = incidentenegocio.buscarIncidentesxLegajoAsignadoyEstadoReabierto(Legajo);
                dgvIncidentes.DataSource = buscaIncidente;
                dgvIncidentes.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);

            }
        }

        protected void btnTodos_Click(object sender, EventArgs e)
        {
            Incidente incidente = new Incidente();
            IncidenteNegocio incidentenegocio = new IncidenteNegocio();
            int Legajo = Convert.ToInt32(Session["_Legajo"]);
            try
            {
                buscaIncidente = incidentenegocio.buscarIncidentesxLegajoAsignado(Legajo);
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