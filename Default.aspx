<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPC_Caero_Hoffman._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    
    <div class="d-grid gap-2 col-6 mx-auto">
    <h1>Clientes</h1>
    <asp:Button Text="Ingresar Cliente" ID="btnIngresarCliente" CssClass="btn btn-dark" runat="server" OnClick="btnIngresarCliente_Click" />
    <asp:Button Text="Buscar Cliente Por DNI" ID="btnBuscarClientexDNI" OnClick="btnBuscarClientexDNI_Click" CssClass="btn btn-dark" runat="server" />
    <asp:Button Text="Modificar Cliente" ID="btnModificarCliente" OnClick="btnModificarCliente_Click" CssClass="btn btn-dark" runat="server" />
    <asp:Button Text="Eliminar Cliente" ID="brnEliminarCliente" CssClass="btn btn-dark" runat="server" OnClick="brnEliminarCliente_Click" />
    </div>

    <div class="d-grid gap-2 col-6 mx-auto">
    <h1>Incidentes</h1>
    <asp:Button Text="Crear Incidente" ID="btnCrearIncidente" OnClick="btnCrearIncidente_Click" CssClass="btn btn-dark" runat="server" />
    <asp:Button Text="Buscar Por Numero de Incidente" ID="btnBuscarIncidentexID" OnClick="btnBuscarIncidentexID_Click" CssClass="btn btn-dark" runat="server" />
    <asp:Button Text="Modificar Incidente" ID="btnModificarIncidente" CssClass="btn btn-dark" runat="server" OnClick="btnModificarIncidente_Click" />
    <asp:Button Text="Reasignar Incidente" ID="btnReasignarIncidente" CssClass="btn btn-dark" runat="server" OnClick="btnReasignarIncidente_Click" />
    <asp:Button Text="Cerrar Incidente" ID="btnCerrarIncidente" CssClass="btn btn-dark" runat="server" OnClick="btnCerrarIncidente_Click" />
    <asp:Button Text="Reabrir Incidente" ID="btnReabrirIncidente" CssClass="btn btn-dark" runat="server" OnClick="btnReabrirIncidente_Click" />
    </div>

    <div class="d-grid gap-2 col-6 mx-auto">
    <h1>Empleados</h1>
    <asp:Button Text="Registrar Empleado" ID="Button1" CssClass="btn btn-dark" runat="server" OnClick="btnRegistrarEmpleado_Click" />
    <asp:Button Text="Buscar Empleado" ID="btnBuscarEmpleado" CssClass="btn btn-dark" runat="server" OnClick="btnBuscarEmpleado_Click" />
    <asp:Button Text="Modificar Empleado" ID="btnModificarEmpleado" OnClick="btnModificarEmpleado_Click" CssClass="btn btn-dark" runat="server" />
    <asp:Button Text="Eliminar Empleado" ID="btnEliminarEmpleado" OnClick="btnEliminarEmpleado_Click" CssClass="btn btn-dark" runat="server" />
    </div>

 
   
</asp:Content>
