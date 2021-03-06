<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmMenuTelefonista.aspx.cs" Inherits="TPC_Caero_Hoffman.frmMenuTelefonista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

  
<!--CORRE BOTONES A LA DERECHA-->
    <br />
    <div class="container">
        <div class="row">
       
        <div class="col" style="text-align: left" >
        <b><asp:Label ID="lblNombreCargo" runat="server" /> </b><br />
        <asp:Label ID="lblNombre" runat="server" /><br />
        <b>Legajo: </b> <asp:Label ID="lblLegajo" runat="server" /><br />      
        </div>

        <div class="col" style="text-align: right; width:990px" >
        <asp:Button Text="Cambiar Contraseña" CssClass="btn btn-dark" ID="btnCambiarContrasena" OnClick="btnCambiarContrasena_Click" runat="server" />
        <asp:Button Text="Cerrar Sesión" ID="btnCerrarSesion" OnClick="btnCerrarSesion_Click" CssClass="btn btn-danger" runat="server" />
        </div>   

      </div>
     </div>
    <br />

    <div class="d-grid gap-2 col-6 mx-auto" style="border:solid; text-align: center; border-radius:10px 10px ">
    <h2>Clientes</h2>
    <asp:Button Text="Ingresar Cliente" ID="btnIngresarCliente" CssClass="btn btn-dark" runat="server" OnClick="btnIngresarCliente_Click" />
    <asp:Button Text="Buscar Cliente" ID="btnBuscarClientexDNI" OnClick="btnBuscarClientexDNI_Click" CssClass="btn btn-dark" runat="server" />
    </div>
    <br />
    <div class="d-grid gap-2 col-6 mx-auto" style="border:solid; text-align: center; border-radius:10px 10px ">
    <h2>Incidentes</h2>
    <asp:Button Text="Crear Incidente" ID="btnCrearIncidente" OnClick="btnCrearIncidente_Click" CssClass="btn btn-dark" runat="server" />
    <asp:Button Text="Modificar Incidente" ID="Button1" CssClass="btn btn-dark" runat="server" OnClick="btnModificarIncidente_Click" />
    <asp:Button Text="Mis Incidentes" ID="btnMisIncidentes" CssClass="btn btn-dark" runat="server" OnClick="btnMisIncidentes_Click" />
    <asp:Button Text="Cerrar/Resolver Incidente" ID="btnCerrarIncidente" CssClass="btn btn-dark" runat="server" OnClick="btnCerrarIncidente_Click" />
    </div>



</asp:Content>
