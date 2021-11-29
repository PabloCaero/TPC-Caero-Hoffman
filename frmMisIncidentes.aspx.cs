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
    public partial class frmMisIncidentes : System.Web.UI.Page
    {
        private List<Incidente> buscaIncidente;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["_NombreUsuario"] == null)
            {
                Session.Add("Error", "Debes loguearte para ingresar");
                Response.Redirect("Error.aspx", false);
            }
            else
            {

                EstadoNegocio estadonegocio = new EstadoNegocio();
                try
                {
                    if (!IsPostBack)
                    {
                        List<Estado> listEstado = estadonegocio.listar();

                        ddlEstados.DataSource = listEstado;
                        ddlEstados.DataTextField = "Nombre_Estado";
                        ddlEstados.DataValueField = "IDEstado";
                        ddlEstados.DataBind();
                    }

                }
                catch (Exception ex)
                {
                    Session.Add("error", ex);

                }

                string Nombre = Session["_Nombre"] != null ? Session["_Nombre"].ToString() : "";
                string Apellido = Session["_Apellido"] != null ? Session["_Apellido"].ToString() : "";
                int Legajo = Convert.ToInt32(Session["_Legajo"]);

                lblDatosEmpleado.Text = Apellido + ", " + Nombre + " - Legajo: " + Legajo.ToString();
            }
        }

        protected void btnBuscarIncidentes_Click(object sender, EventArgs e)
        {
            Incidente incidente = new Incidente();
            IncidenteNegocio incidentenegocio = new IncidenteNegocio();

            try
            {
                incidente.Estado = new Estado();
                incidente.Estado.IDEstado = int.Parse(ddlEstados.SelectedValue);
                incidente.Empleado = new Empleado();
                incidente.Empleado.Legajo = Convert.ToInt32(Session["_Legajo"]);
                buscaIncidente = incidentenegocio.buscarEstadoyLegajo(incidente);
                dgvIncidentes.DataSource = buscaIncidente;
                dgvIncidentes.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);

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
    }
}