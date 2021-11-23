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
    public partial class frmCerrarIncidente : System.Web.UI.Page
    {
        private List<Incidente> buscaIncidente;
        protected void Page_Load(object sender, EventArgs e)
        {

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
    }
}