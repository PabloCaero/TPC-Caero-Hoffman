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
    
    <div class="container">
        <div class="row align-items-start">

            <div class="col">
    <label for="inputEmail4" class="form-label">Buscar por ID</label>
    <div class="alinear">
        <div>
        <asp:TextBox type="text" runat="server"  class="form-control" id="txtBuscarIncidentexID" />
          </div>
            <asp:Button ID="btnBuscarIncidentexID" CssClass="btn btn-primary mb-2" runat="server" OnClick="btnBuscarIncidentexID_Click" Text="Buscar" />  
       </div>
                </div>

             <div class="col">
          <label for="inputEmail4" class="form-label">Buscar por Apellido Cliente</label>
    <div class="alinear">
        <div>    
        <asp:TextBox type="text" runat="server"  class="form-control" id="txtBuscarIncidentexApeCliente" />
         </div>
            <asp:Button ID="btnBuscarIncidentexApeCliente" CssClass="btn btn-primary mb-2" runat="server" OnClick="btnBuscarIncidentexApeCliente_Click" Text="Buscar" /> 
       </div>
                </div>

             <div class="col">
        <label for="inputEmail4" class="form-label">Buscar por Apellido Empleado</label>
    <div class="alinear">
        <div>
        <asp:TextBox type="text" runat="server"  class="form-control" id="txtBuscarIncidentexApeEmpleado" />
          </div>
        <asp:Button ID="btnBuscarIncidentexApeEmpleado" CssClass="btn btn-primary mb-2" runat="server" OnClick="btnBuscarIncidentexApeEmpleado_Click" Text="Buscar" /> 
        </div>
            </div>
            </div>

        </div>
     
        <br />

         <div>
        <div class="row" > 
            <asp:GridView ID="dgvIncidentes" CssClass="table table-hover table-info" runat="server" AutoGenerateColumns="false" >
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
       

</asp:Content>
