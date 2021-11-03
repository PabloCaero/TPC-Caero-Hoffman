<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="IncidenteForm.aspx.cs" Inherits="TPC_Caero_Hoffman.IncidenteForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!--ESTILOS-->
    <style> 
     .div-form{
         margin: 10px;
     }

    </style>

    <!--TEXT BOX Y BOTON ACEPTAR-->
     <div class="div-form">
        <asp:Label Text="ID Empleado: " runat="server" />
        <asp:TextBox runat="server" ID="txtIDEmpleado" />
    </div>
        
    <div class="div-form">
        <asp:Label Text="ID Cliente: " runat="server" />
        <asp:TextBox runat="server" ID="txtIDCliente" />
    </div>

    <div class="div-form">
        <asp:Label Text="Detalles: " runat="server" />
        <asp:TextBox runat="server" ID="txtDetalles" />
    </div>

    <div class="div-form">
        <asp:Label Text="Estado: " runat="server" />
        <asp:TextBox runat="server" ID="txtEstado" />
    </div>

    <div class="div-form">
        <asp:Label Text="Comentario Final: " runat="server" />
        <asp:TextBox runat="server" ID="txtComentarioFinal" />
    </div>

    <div class="div-form">
        <asp:Button Text="Aceptar" ID="btnAceptar" OnClick="btnAceptar_Click" runat="server" />

    </div>


</asp:Content>
