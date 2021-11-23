<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCerrarIncidente.aspx.cs" Inherits="TPC_Caero_Hoffman.frmCerrarIncidente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
    <h2>Cerrar Incidente</h2>
    </div>
    
     <div class="col-9">
    <label for="inputEmail4" class="form-label">Buscar Incidente por ID</label>
        <asp:TextBox type="text" runat="server"  class="form-control" id="txtBuscarIncidentexID" />
        <asp:Button ID="btnBuscarIncidentexID" runat="server" OnClick="btnBuscarIncidentexID_Click" Text="Buscar" />  
   
       
        <div class="row" > 
            <asp:GridView ID="dgvIncidentes" CssClass="table table-success table-striped" runat="server" AutoGenerateColumns="false"
          
                DataKeyNames="ID" OnSelectedIndexChanging="dgvIncidentes_SelectedIndexChanging"
                >
                <Columns>
                  
                  <asp:BoundField DataField="ID" HeaderText="Numero de Incidente"/>    
                  <asp:BoundField DataField="Cliente.Nombre" HeaderText="Nombre de Cliente"/>
                  <asp:BoundField DataField="Cliente.Apellido" HeaderText="Apellido de Cliente"/>
                  <asp:BoundField DataField="Empleado.Legajo" HeaderText="Legajo de Empelado Asignado"/>
                  <asp:BoundField DataField="Empleado.Nombre" HeaderText="Nombre de Empleado"/>
                  <asp:BoundField DataField="Empleado.Apellido" HeaderText="Apellido de Empleado"/>
                  <asp:BoundField DataField="Estado.Nombre_Estado" HeaderText="Estado"/>
                  <asp:BoundField DataField="Detalles" HeaderText="Detalles"/>
              
              <asp:CommandField ButtonType="Link" ShowSelectButton="true" ShowEditButton="false" ShowDeleteButton="false" />

                </Columns>

            </asp:GridView>


              <!--IMPORTANTE PARA ASIGNAR ATRIBUTO-->
            <asp:Label ID="lblIDIncidente" runat="server" />
           </div>
         </div>

    
    <!--COMENTARIO FINAL DEL INCIDENTE-->
     <div class="col-9">
    <label for="inputEmail4" class="form-label">Describa los detalles de cierre del incidente: </label>
        <asp:TextBox type="text" runat="server"  class="form-control" id="txtComentarioFinal" Height="50px" />
        <asp:Button ID="btnCerrarIncidente" runat="server" OnClick="btnCerrarIncidente_Click" Text="Cerrar Incidente" />  
     </div>

</asp:Content>
