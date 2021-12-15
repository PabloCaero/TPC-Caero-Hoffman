<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmMenuAdministrador.aspx.cs" Inherits="TPC_Caero_Hoffman._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    
  
    <!--CORRE BOTONES A LA DERECHA-->
    <br />
    <div class="container">
        <div class="row">
       
        <div class="col" style="text-align: left">
        <b><asp:Label ID="lblNombreCargo" runat="server" /> </b><br />
        <asp:Label ID="lblNombre" runat="server" /><br />
        <b>Legajo: </b> <asp:Label ID="lblLegajo" runat="server" /><br />      
        </div>

        <div class="col" style="text-align: right; width:990px" >
        <asp:Button Text="Cambiar Contraseña" CssClass="btn btn-dark" ID="btnCambiarContrasena" OnClick="btnCambiarContrasena_Click" runat="server" />
        <asp:Button Text="Cerrar Sesión" CssClass="btn btn-danger" ID="btnCerrarSesion" OnClick="btnCerrarSesion_Click" runat="server" />

            
        </div>   

      </div>
     </div>
    <br />

    <div class="d-grid gap-2 col-6 mx-auto" style="border:solid; border-radius:10px 10px ">
        <div style="text-align: center">
        <h2>Clientes</h2>
            </div>
    <asp:Button Text="Ingresar Cliente" ID="btnIngresarCliente" CssClass="btn btn-dark" runat="server" OnClick="btnIngresarCliente_Click" />
    <asp:Button Text="Buscar Cliente" ID="btnBuscarClientexDNI" OnClick="btnBuscarClientexDNI_Click" CssClass="btn btn-dark" runat="server" />
    <asp:Button Text="Modificar Cliente" ID="btnModificarCliente" OnClick="btnModificarCliente_Click" CssClass="btn btn-dark" runat="server" />
    <asp:Button Text="Eliminar Cliente" ID="brnEliminarCliente" CssClass="btn btn-dark" runat="server" OnClick="brnEliminarCliente_Click" />
    </div>
    <br />
    <div class="d-grid gap-2 col-6 mx-auto" style="border:solid; border-radius:10px 10px ">
    <div style="text-align: center">
        <h2>Incidentes</h2>
            </div>
    <asp:Button Text="Crear Incidente" ID="btnCrearIncidente" OnClick="btnCrearIncidente_Click" CssClass="btn btn-dark" runat="server" />
    <asp:Button Text="Buscar Incidente" ID="btnBuscarIncidentexID" OnClick="btnBuscarIncidentexID_Click" CssClass="btn btn-dark" runat="server" />
    <asp:Button Text="Modificar Incidente" ID="btnModificarIncidente" CssClass="btn btn-dark" runat="server" OnClick="btnModificarIncidente_Click" />
    <asp:Button Text="Reasignar Incidente" ID="btnReasignarIncidente" CssClass="btn btn-dark" runat="server" OnClick="btnReasignarIncidente_Click" />
    <asp:Button Text="Cerrar/Resolver Incidente" ID="btnCerrarIncidente" CssClass="btn btn-dark" runat="server" OnClick="btnCerrarIncidente_Click" />
    <asp:Button Text="Reabrir Incidente" ID="Button2" CssClass="btn btn-dark" runat="server" OnClick="btnReabrirIncidente_Click" />
    <asp:Button Text="Reportes de Incidentes" ID="btnReporteIncidentes" CssClass="btn btn-dark" runat="server" OnClick="btnReporteIncidentes_Click" />
    </div>
    <br />
    <div class="d-grid gap-2 col-6 mx-auto" style="border:solid; border-radius:10px 10px">
    <div style="text-align: center">
        <h2>Empleados</h2>
            </div>
    <asp:Button Text="Registrar Empleado" ID="Button1" CssClass="btn btn-dark" runat="server" OnClick="btnRegistrarEmpleado_Click" />
    <asp:Button Text="Buscar Empleado" ID="btnBuscarEmpleado" CssClass="btn btn-dark" runat="server" OnClick="btnBuscarEmpleado_Click" />
    <asp:Button Text="Modificar Empleado" ID="btnModificarEmpleado" OnClick="btnModificarEmpleado_Click" CssClass="btn btn-dark" runat="server" />
    <asp:Button Text="Eliminar Empleado" ID="btnEliminarEmpleado" OnClick="btnEliminarEmpleado_Click" CssClass="btn btn-dark" runat="server" />
    </div>

 
   
</asp:Content>
