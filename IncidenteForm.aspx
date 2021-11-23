<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IncidenteForm.aspx.cs" Inherits="TPC_Caero_Hoffman.IncidenteForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <div>
    <h2>Crear Incidente</h2>
    </div>

    <!--BUSQUEDA DE CLIENTE-->
    <div>
     <div class="col-9">
    <label for="inputEmail4" class="form-label">Ingrese DNI de Cliente: </label>
        <asp:TextBox type="text" runat="server"  class="form-control" id="txtBuscarClientexDNI" />
        <asp:Button ID="btnBuscarClientexDNI" runat="server" OnClick="btnBuscarClientexDNI_Click" Text="Buscar" />  
   
        <div class="row" > 
            <asp:GridView ID="dgvClientes" CssClass="table table-success table-striped" runat="server"
                AutoGenerateColumns="false"        
                DataKeyNames="IDCliente" OnSelectedIndexChanging="dgvClientes_SelectedIndexChanging">
                <Columns>
                    <asp:BoundField DataField="IDCliente" HeaderText="ID" />
                    <asp:BoundField DataField="DNI" HeaderText="DNI"/>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre"/>
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido"/>
                    <asp:CommandField ButtonType="Link" ShowSelectButton="true"  ShowEditButton="false" ShowDeleteButton="false" />
                </Columns>

            </asp:GridView>

            <!--IMPORTANTE PARA ASIGNAR ATRIBUTO-->
            <asp:Label ID="lblIDCliente" runat="server" />

        </div>
        </div>
       </div>

    <!--BUSQUEDA DE EMPLEADO-->

    <div>
     <div class="col-9">
    <label for="inputEmail4" class="form-label">Asigne a un empleado por su Legajo: </label>
        <asp:TextBox type="text" runat="server"  class="form-control" id="txtBuscarEmpleadoxID" />
        <asp:Button ID="btnBuscarEmpleadoxLegajo" runat="server" OnClick="btnBuscarEmpleadoxLegajo_Click" Text="Buscar" />  
   
        <div class="row" > 
            <asp:GridView ID="dgvEmpleados" CssClass="table table-success table-striped" runat="server"
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
            <asp:Label ID="lblLegajoEmpleado" runat="server" />
        
        </div>
        </div>
       </div>

    <!--ESPECIALIDAD DEL INCIDENTE-->
    <div class="col-md-6">
         <label for="inputEmail4" class="form-label">Especialidad</label>
         <asp:DropDownList runat="server" ID="ddlEspecialidad" CssClass="btn btn-outline-dark dropdown-toggle" AutoPostBack="true" >
         </asp:DropDownList>
             </div>

    <!--PRIORIDAD DEL INCIDENTE-->
    <div class="col-md-6">
         <label for="inputEmail4" class="form-label">Prioridad</label>
         <asp:DropDownList runat="server" ID="ddlPrioridad" CssClass="btn btn-outline-dark dropdown-toggle" AutoPostBack="true" >
         </asp:DropDownList>
             </div>
    

    <!--DETALLES DEL INCIDENTE-->
     <div class="col-9">
    <label for="inputEmail4" class="form-label">Describa los detalles del incidente: </label>
        <asp:TextBox type="text" runat="server"  class="form-control" id="txtDetalles" Height="50px" />
        <asp:Button ID="btnCrearIncidente" runat="server" OnClick="btnCrearIncidente_Click" Text="Crear Incidente" />  
     </div>




    
</asp:Content>
