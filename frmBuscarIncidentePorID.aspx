<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmBuscarIncidentePorID.aspx.cs" Inherits="TPC_Caero_Hoffman.frmBuscarIncidentePorID" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    <h2>Buscar Incidente</h2>
    </div>
    <div >
     <div class="col-9">
    <label for="inputEmail4" class="form-label">Ingrese el número de Incidente</label>
        <asp:TextBox type="text" runat="server"  class="form-control" id="txtBuscarIncidentexID" />
        <asp:Button ID="btnBuscarIncidentexID" runat="server" OnClick="btnBuscarIncidentexID_Click" Text="Buscar" />  
   
        <div class="row" > 
            <asp:GridView ID="dgvIncidentes" CssClass="table" runat="server" AutoGenerateColumns="false" >
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="Numero de Incidente"/>
                    <asp:BoundField DataField="Cliente.IDCliente" HeaderText="Numero de Cliente"/>
                    <asp:BoundField DataField="Empleado.Legajo" HeaderText="Legajo de Empleado Asignado"/>
                    <asp:BoundField DataField="Estado.IDEstado" HeaderText="Estado del Incidente"/>
                    <asp:BoundField DataField="Detalles" HeaderText="Detalles"/>
                </Columns>

            </asp:GridView>
        </div>
        </div>
</asp:Content>
