<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmReasignarIncidente.aspx.cs" Inherits="TPC_Caero_Hoffman.frmReasignarIncidente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <!--BOTON VOLVER ATRÁS-->
    <br />
    <div style="text-align: right; width:990px" >
       <asp:Button Text="Menú Principal" CssClass="btn btn-dark" ID="btnMenuPrincipal" OnClick="btnMenuPrincipal_Click1" runat="server" />
    </div>


    <div>
    <h3 >Reasignar Incidente</h3>
    </div>
    <div>
        <h4 class="center">Seleccionar un Incidente</h4>
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
            <asp:Label ID="lblSeleccionIncidente" CssClass="center" runat="server" Font-Bold="true"/>
              </div>
    <br />
        <div class="row" > 
            <asp:GridView ID="dgvIncidentes" CssClass="table table-hover table-info" runat="server" AutoGenerateColumns="false"
          
                DataKeyNames="ID" OnSelectedIndexChanging="dgvIncidentes_SelectedIndexChanging"
                >
                <Columns>
                  
                  <asp:BoundField DataField="ID" HeaderText="Numero de Incidente"/>    
                  <asp:BoundField DataField="Empleado.Legajo" HeaderText="Legajo de Empleado Asignado"/>
                  <asp:BoundField DataField="Empleado.Nombre" HeaderText="Nombre de Empleado"/>
                  <asp:BoundField DataField="Empleado.Apellido" HeaderText="Apellido de Empleado"/>
                  <asp:BoundField DataField="Estado.Nombre_Estado" HeaderText="Estado"/>
                  <asp:BoundField DataField="Detalles" HeaderText="Detalles"/>
              
              <asp:CommandField ButtonType="Link" ShowSelectButton="true" ShowEditButton="false" ShowDeleteButton="false" />

                </Columns>

            </asp:GridView>


              <!--IMPORTANTE PARA ASIGNAR ATRIBUTO-->
            <asp:Label ID="lblIDIncidente" runat="server" Visible="false" />
      
           </div>
    
          
     
    <div>
        <h4 class="center">Seleccionar un Empleado</h4>
    </div>
          <div class="container">
        <div class="row justify-content-center">
            <div class="col-md-6">
         <label for="inputEmail4" class="form-label">Por Legajo</label>
     <div class="alinear"> 
         <div>
         <asp:TextBox type="text" runat="server"  class="form-control" id="txtBuscarEmpleadoxID" />
         </div>        
         <asp:Button ID="btnBuscarEmpleadoxLegajo" CssClass="btn btn-primary mb-2" runat="server" OnClick="btnBuscarEmpleadoxLegajo_Click" Text="Buscar" />          
      </div>
               </div>

              <div class="col-md-4">
          <label for="inputEmail4" class="form-label">Por Apellido</label>
         <div class="alinear">
             <div>
        <asp:TextBox type="text" runat="server"  class="form-control" id="txtBuscarEmpleadoxApellido" />
               </div>
        <asp:Button ID="btnBuscarEmpleadoxApellido" runat="server" CssClass="btn btn-primary mb-2" OnClick="btnBuscarEmpleadoxApellido_Click" Text="Buscar" />
              </div>
                  </div>
            </div>
        </div> 

           <br />
     <div class="d-grid gap-2 col-6 mx-auto" style="border: none; background-color: yellow ; border-radius:10px 10px">
           <asp:Label ID="lblSeleccionEmpleado" CssClass="center" Font-Bold="true" runat="server" />
     
              </div>
    <br />
   
        <div class="row" > 
            <asp:GridView ID="dgvEmpleados" CssClass="table table-hover table-info" runat="server"
                AutoGenerateColumns="false"          
                DataKeyNames="Legajo" OnSelectedIndexChanging="dgvEmpleados_SelectedIndexChanging" >
                <Columns>
                    <asp:BoundField DataField="Legajo" HeaderText="ID" />
                    <asp:BoundField DataField="Cargo.Nombre_Cargo" HeaderText="Cargo" />    
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre"/>
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido"/>

                    <asp:CommandField ButtonType="Link" ShowSelectButton="true" />
                </Columns>

            </asp:GridView>
            <!--IMPORTANTE PARA ASIGNAR ATRIBUTO-->
            <asp:Label ID="lblLegajoEmpleado" runat="server" Visible="false" />
            

        </div>
       

    <div class="d-grid gap-2 col-6 mx-auto">
    <asp:Button Text="Reasignar Incidente" CssClass="btn btn-primary btn-lg" ID="btnReasignarIncidente" OnClick="btnReasignarIncidente_Click" runat="server" />
      </div>

    <br />

          <div class="d-grid gap-2 col-6 mx-auto" style="border: none; background-color: yellow ; border-radius:10px 10px">
              <asp:Label ID="lblConfirmacion" CssClass="center" runat="server" Font-Bold="true"/>                                   
              </div>

</asp:Content>
