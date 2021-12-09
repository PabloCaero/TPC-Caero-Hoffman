<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmBuscarIncidentePorID.aspx.cs" Inherits="TPC_Caero_Hoffman.frmBuscarIncidentePorID" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    <!--BOTON VOLVER ATRÁS-->
    <br />
    <div style="text-align: right; width:990px" >
       <asp:Button Text="Menú Principal" CssClass="btn btn-dark" ID="btnMenuPrincipal" OnClick="btnMenuPrincipal_Click" runat="server" />
    </div>

    <div>
    <h3>Buscar Incidente</h3>
    </div>
    
     <div class="col-9">
    <label for="inputEmail4" class="form-label">Buscar por ID de Incidente</label>
        <asp:TextBox type="text" runat="server"  class="form-control" id="txtBuscarIncidentexID" />
        <asp:Button ID="btnBuscarIncidentexID" runat="server" OnClick="btnBuscarIncidentexID_Click" Text="Buscar" />  
   
        <label for="inputEmail4" class="form-label">Buscar por Apellido Cliente</label>
        <asp:TextBox type="text" runat="server"  class="form-control" id="txtBuscarIncidentexApeCliente" />
        <asp:Button ID="btnBuscarIncidentexApeCliente" runat="server" OnClick="btnBuscarIncidentexApeCliente_Click" Text="Buscar" /> 

         <label for="inputEmail4" class="form-label">Buscar por Apellido Empleado</label>
        <asp:TextBox type="text" runat="server"  class="form-control" id="txtBuscarIncidentexApeEmpleado" />
        <asp:Button ID="btnBuscarIncidentexApeEmpleado" runat="server" OnClick="btnBuscarIncidentexApeEmpleado_Click" Text="Buscar" /> 


         <div>
        <div class="row" > 
            <asp:GridView ID="dgvIncidentes" CssClass="table table-success table-striped" runat="server" AutoGenerateColumns="false" >
                <Columns>
                  <asp:BoundField DataField="ID" HeaderText="Numero de Incidente"/>   
                  <asp:BoundField DataField="Fecha_inicio" HeaderText="Fecha de Inicio" DataFormatString="{0:d}"  HtmlEncode=false />   
                  <asp:BoundField DataField="Cliente.Nombre" HeaderText="Nombre de Cliente"/>
                  <asp:BoundField DataField="Cliente.Apellido" HeaderText="Apellido del Cliente"/>
                  <asp:BoundField DataField="Empleado.Legajo" HeaderText="Legajo de Empleado Asignado"/>
                  <asp:BoundField DataField="Empleado.Nombre" HeaderText="Nombre de Empleado"/>
                  <asp:BoundField DataField="Empleado.Apellido" HeaderText="Apellido de Empleado"/>
                  <asp:BoundField DataField="Estado.Nombre_Estado" HeaderText="Estado"/>
                  <asp:BoundField DataField="Detalles" HeaderText="Detalles"/>
                  <asp:BoundField DataField="Fecha_cierre" HeaderText="Fecha de Cierre" DataFormatString="{0:d}"  HtmlEncode=false />   
                  <asp:BoundField DataField="ComentarioFinal" HeaderText="Comentario Final"/>   

                </Columns>

            </asp:GridView>
        </div>
        </div>
         </div>

</asp:Content>
