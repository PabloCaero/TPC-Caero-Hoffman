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
            if (Session["_NombreUsuario"] == null && (int)Session["_IDCargo"] != 1)
            {
                Session.Add("Error", "Debes loguearte para ingresar");
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

        protected void dgvIncidentes_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Incidente incidente = new Incidente();
                IncidenteNegocio negocioincidente = new IncidenteNegocio();
                GridViewRow fila = dgvIncidentes.Rows[e.RowIndex];

                //MODIFICACION DE DETALLES DE INCIDENTE
                incidente.ID = Convert.ToInt32(dgvIncidentes.DataKeys[e.RowIndex].Values[0]);
                incidente.Detalles = ((fila.FindControl("txtDetalles")) as TextBox).Text.ToUpper();


                negocioincidente.modificarDetalles(incidente);
                lblConfirmacion.Text = "Atención: El detalle del incidente #" + incidente.ID + " fue modificado. Regrese al Menú Principal";

            }
            catch (Exception ex)
            {
                lblConfirmacion.Text = "Atención: Ocurrió un error.";
            }

        }

        protected void dgvIncidentes_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void dgvIncidentes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Response.Redirect("frmModificarDetallesIncidente.aspx");
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
    }
}