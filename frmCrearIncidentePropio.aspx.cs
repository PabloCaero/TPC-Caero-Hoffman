﻿using System;
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
    public partial class frmCrearIncidentePropio : System.Web.UI.Page
    {
        private List<Cliente> buscaCliente;
        protected void Page_Load(object sender, EventArgs e)
        {
            EspecialidadNegocio especialidadnegocio = new EspecialidadNegocio();
            PrioridadNegocio prioridadnegocio = new PrioridadNegocio();
            try
            {
                if (!IsPostBack)
                {
                    List<Especialidad> listEspecialidad = especialidadnegocio.listar();

                    ddlEspecialidad.DataSource = listEspecialidad;
                    ddlEspecialidad.DataTextField = "Nombre_Especialidad";
                    ddlEspecialidad.DataValueField = "IDEspecialidad";
                    ddlEspecialidad.DataBind();
                }

                if (!IsPostBack)
                {
                    List<Prioridad> listPrioridad = prioridadnegocio.listar();

                    ddlPrioridad.DataSource = listPrioridad;
                    ddlPrioridad.DataTextField = "Nombre_Prioridad";
                    ddlPrioridad.DataValueField = "IDPrioridad";
                    ddlPrioridad.DataBind();
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);

            }

        }

        protected void btnBuscarClientexDNI_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            ClienteNegocio clientenegocio = new ClienteNegocio();

            try
            {
                cliente.Dni = txtBuscarClientexDNI.Text;
                buscaCliente = clientenegocio.buscarDNI(cliente);
                dgvClientes.DataSource = buscaCliente;
                dgvClientes.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        protected void btnCrearIncidente_Click(object sender, EventArgs e)
        {

            IncidenteNegocio negocioIncidente = new IncidenteNegocio();
            Incidente nuevo = new Incidente();

            nuevo.Cliente = new Cliente();
            nuevo.Cliente.IDCliente = int.Parse(lblIDCliente.Text);

            nuevo.Empleado = new Empleado();
           
            int Legajo = Convert.ToInt32(Session["_Legajo"]);
            nuevo.Empleado.Legajo = Legajo;

            nuevo.Especialidad = new Especialidad();
            nuevo.Especialidad.IDEspecialidad = int.Parse(ddlEspecialidad.SelectedValue);

            nuevo.Prioridad = new Prioridad();
            nuevo.Prioridad.IDPrioridad = int.Parse(ddlPrioridad.SelectedValue);

            nuevo.Detalles = txtDetalles.Text;
            negocioIncidente.agregar(nuevo);

            //ENVIA MAIL AL CLIENTE
            IncidenteNegocio negocio = new IncidenteNegocio();
            Incidente ultimo = new Incidente();

            ultimo = negocio.traerUltimoIncidente();


            EmailService emailService = new EmailService();
            emailService.armarCorreoIncidenteAbierto(ultimo);
            try
            {
                emailService.enviarMail();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            //ENVIA MAIL AL EMPLEADO
            emailService.armarCorreoIncidenteAbiertoEmpleado(ultimo);
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

        protected void dgvClientes_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            GridViewRow row = dgvClientes.Rows[e.NewSelectedIndex];
            lblIDCliente.Text = row.Cells[0].Text;
        }
    }
}