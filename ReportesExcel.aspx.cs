using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;
using System.Configuration;
using System.IO;


namespace TPC_Caero_Hoffman
{
    public partial class ReportesExcel : System.Web.UI.Page
    {
        private List<Incidente> buscaIncidente;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((int)Session["_IDCargo"] != 2 && (int)Session["_IDCargo"] != 1)
            {
                Session.Add("Error", "Debes loguearte para ingresar");
                Response.Redirect("Error.aspx", false);
            }

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


        }

        protected void btnBuscarIncidentes_Click(object sender, EventArgs e)
        {
            Incidente incidente = new Incidente();
            IncidenteNegocio incidentenegocio = new IncidenteNegocio();

            try
            {
                incidente.Estado = new Estado();
                incidente.Estado.IDEstado = int.Parse(ddlEstados.SelectedValue);
                buscaIncidente = incidentenegocio.buscarEstado(incidente);
                dgvIncidentes.DataSource = buscaIncidente;
                dgvIncidentes.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);

            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", string.Format("attachment;filaname={0}.xlsx","selectedrows"));
            Response.Charset = "";       
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            dgvIncidentes.RenderControl(hw);
            Response.Write(sw.ToString());
            dgvIncidentes.AllowPaging = false;
            Response.End();
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