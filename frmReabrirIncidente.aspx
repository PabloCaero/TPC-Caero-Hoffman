<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmReabrirIncidente.aspx.cs" Inherits="TPC_Caero_Hoffman.frmReabrirIncidente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <!--BOTON VOLVER ATRÁS-->
    <br />
    <div style="text-align: right; width:990px" >
       <asp:Button Text="Menú Principal" CssClass="btn btn-dark" ID="btnMenuPrincipal" OnClick="btnMenuPrincipal_Click" runat="server" />
    </div>

    <div>
    <h3>Reabrir Incidente</h3>
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
     <div class="d-grid gap-2 col-6 mx-auto" style="border: none; background-color: yellow ; border-radius:10px 10px">
            <asp:Label ID="lblSeleccion" CssClass="center" runat="server" Font-Bold="true"/>
              </div>
    <br />
       
        <div class="row" > 
            <asp:GridView ID="dgvIncidentes" CssClass="table table-hover table-info" runat="server" AutoGenerateColumns="false"
          
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
            <asp:Label ID="lblIDIncidente" runat="server" Visible="false"/>
          

           </div>
        

    
  <div class="d-grid gap-2 col-6 mx-auto">
    <asp:Button Text="Reabrir Incidente" CssClass="btn btn-primary btn-lg" ID="btnReabrirIncidente" OnClick="btnReabrirIncidente_Click" runat="server" />
      </div>

    <br />

          <div class="d-grid gap-2 col-6 mx-auto" style="border: none; background-color: yellow ; border-radius:10px 10px">
              <asp:Label ID="lblConfirmacion" CssClass="center" runat="server" Font-Bold="true"/>                                   
              </div>



</asp:Content>
