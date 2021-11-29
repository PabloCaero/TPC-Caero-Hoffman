<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCambiarContraseña.aspx.cs" Inherits="TPC_Caero_Hoffman.frmCambiarContraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <!--BOTON VOLVER ATRÁS-->
    <br />
    <div style="text-align: right; width:990px" >
       <asp:Button Text="Menú Principal" CssClass="btn btn-dark" ID="btnMenuPrincipal" OnClick="btnMenuPrincipal_Click" runat="server" />
    </div>

    <div class="col-auto">
      <asp:Label Text="Escriba su contraseña anterior: " runat="server" />
      <asp:TextBox runat="server" type="password" ID="txtContrasenaAnterior" CssClass="form-control"/>
  </div>
  <div class="col-auto">
      <asp:Label Text="Escriba su nueva contraseña: " runat="server" />
      <asp:TextBox runat="server" type="password" CssClass="form-control" id="txtContrasenaNueva"/>
   
  </div>
  <div class="col-auto">
      <asp:Button Text="Ingresar" OnClick="btnCambiarContrasena_Click" runat="server" type="submit" CssClass="btn btn-primary mb-3" ID="btnCambiarContrasena"/>
  </div>

    <asp:Label ID="lblContrasenaCambiada" runat="server" />

</asp:Content>
