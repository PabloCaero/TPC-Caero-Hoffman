<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IncidenteForm.aspx.cs" Inherits="TPC_Caero_Hoffman.IncidenteForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
    <h2>Crear Incidente</h2>
    </div>
    <div >
     <div class="col-9">
    <label for="inputEmail4" class="form-label">Buscar Cliente</label>
        <asp:TextBox type="text" runat="server"  class="form-control" id="txtBuscarClientexDNI" />
        <asp:Button ID="btnBuscarClientexDNI" runat="server" OnClick="btnBuscarClientexDNI_Click" Text="Buscar" />  
   
        <div class="row" > 
            <asp:GridView ID="dgvClientes" CssClass="table table-success table-striped" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="DNI" HeaderText="DNI"/>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre"/>
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido"/>
                </Columns>

            </asp:GridView>
        </div>
        </div>
        
     <div class="col-9">
        <label for="inputEmail4" class="form-label">Buscar Empleado</label>
    <asp:TextBox type="text" runat="server"  class="form-control" id="txtBuscarEmpleadoxLegajo" />
        <asp:Button ID="btnBuscarEmpleadoxLegajo" runat="server" OnClick="btnBuscarEmpleadoxLegajo_Click" Text="Buscar" />
         <div class="row" > 
             <asp:GridView ID="dgvEmpleados" CssClass="table table-success table-striped" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Legajo" HeaderText="Legajo"/>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre"/>
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido"/>
                </Columns>

            </asp:GridView>
             </div>
     </div>
  <div class="col-9">
    <label for="inputAddress" class="form-label">Detalles del Incidente</label>
    <asp:TextBox type="text" runat="server"  class="form-control" id="txtDetalles" />
  </div>
         

  <div class="col-md-6">
      <asp:Button ID="btnCargarIncidente" runat="server" OnClick="btnCargarIncidente_Click" Text="Cargar Incidente" />
  </div>
</div>
 
    
</asp:Content>
