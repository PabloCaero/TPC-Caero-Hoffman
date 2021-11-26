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
    public partial class frmModificarDetallesIncidente : System.Web.UI.Page
    {
        private List<Incidente> buscaIncidente;
        protected void Page_Load(object sender, EventArgs e)
        {

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

        protected void dgvIncidentes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Incidente incidente = new Incidente();
            IncidenteNegocio negocioincidente = new IncidenteNegocio();
            GridViewRow fila = dgvIncidentes.Rows[e.RowIndex];

            //MODIFICACION DE DETALLES DE INCIDENTE
            incidente.ID = Convert.ToInt32(dgvIncidentes.DataKeys[e.RowIndex].Values[0]);
            incidente.Detalles = ((fila.FindControl("txtDetalles")) as TextBox).Text.ToUpper();


            negocioincidente.modificarDetalles(incidente);

            Response.Redirect("Default.aspx");
        }

        protected void dgvIncidentes_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void dgvIncidentes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Response.Redirect("frmModificarDetallesIncidente.aspx");
        }
    }
}