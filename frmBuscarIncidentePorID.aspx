<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmBuscarIncidentePorID.aspx.cs" Inherits="TPC_Caero_Hoffman.frmBuscarIncidentePorID" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    <h2>Buscar Incidente</h2>
    </div>
    
     <div class="col-9">
    <label for="inputEmail4" class="form-label">Buscar por ID de Incidente</label>
        <asp:TextBox type="text" runat="server"  class="form-control" id="txtBuscarIncidentexID" />
        <asp:Button ID="btnBuscarIncidentexID" runat="server" OnClick="btnBuscarIncidentexID_Click" Text="Buscar" />  
   
         <div>
        <div class="row" > 
            <asp:GridView ID="dgvIncidentes" CssClass="table table-success table-striped" runat="server" AutoGenerateColumns="false" >
                <Columns>
                  <asp:BoundField DataField="ID" HeaderText="Numero de Incidente"/>   
                  <asp:BoundField DataField="Cliente.Nombre" HeaderText="Nombre de Cliente"/>
                  <asp:BoundField DataField="Cliente.Apellido" HeaderText="Apellido del Cliente"/>
                  <asp:BoundField DataField="Empleado.Legajo" HeaderText="Legajo de Empleado Asignado"/>
                  <asp:BoundField DataField="Empleado.Nombre" HeaderText="Nombre de Empleado"/>
                  <asp:BoundField DataField="Empleado.Apellido" HeaderText="Apellido de Empleado"/>
                  <asp:BoundField DataField="Estado.Nombre_Estado" HeaderText="Estado"/>
                  <asp:BoundField DataField="Detalles" HeaderText="Detalles"/>
                </Columns>

            </asp:GridView>
        </div>
        </div>
         </div>

</asp:Content>
