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
    public partial class EmpleadoForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CargoNegocio cargonegocio = new CargoNegocio();
            try
            {
                if (!IsPostBack)
                {
                    List<Cargo> listCargo = cargonegocio.listar();

                    ddlCargos.DataSource = listCargo;
                    ddlCargos.DataTextField = "NOMBRECARGO";
                    ddlCargos.DataValueField = "ID";
                    ddlCargos.DataBind();
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
              
            }

        }

      
    }
}