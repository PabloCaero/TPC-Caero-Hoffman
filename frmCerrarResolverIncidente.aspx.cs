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
        }

        protected void btnCerrarIncidente_Click(object sender, EventArgs e)
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

                throw ex;
            }

            //ENVIA MAIL AL EMPLEADO  
            emailService.armarCorreoIncidenteCerradoEmpleado(ultimo);
            try
            {
                emailService.enviarMail();

            }
            catch (Exception ex)
            {

                throw ex;
            }

            Response.Redirect("Default.aspx");

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

                throw ex;
            }

            //ENVIA MAIL AL EMPLEADO  
            emailService.armarCorreoIncidenteResueltoEmpleado(ultimo);
            try
            {
                emailService.enviarMail();

            }
            catch (Exception ex)
            {

                throw ex;
            }

            Response.Redirect("Default.aspx");

        }
    }
}