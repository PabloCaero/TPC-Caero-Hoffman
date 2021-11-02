<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClienteForm.aspx.cs" Inherits="TPC_Hoffman_Caero.ClienteForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <!--ESTILOS-->
    <style>
        .div-form{
            margin: 10px;
        }
    </style>

    <!--CONTROLES PARA EL ALTA-->
    <div class="div-form">
        <asp:Label Text="Nombre: " runat="server" />
        <asp:TextBox runat="server" ID="txtNombre" />
    </div>
    <div class="div-form">
        <asp:Label Text="Apellido: " runat="server" />
        <asp:TextBox runat="server" ID="txtApellido" />
    </div>
      <div class="div-form">
        <asp:Label Text="DNI: " runat="server" />
        <asp:TextBox runat="server" ID="txtDNI" />
    </div>
    <div>
        <asp:Button Text="Aceptar" ID="btnAceptar" OnClick ="btnAceptar_Click" runat ="server" />
    </div>

</asp:Content>
