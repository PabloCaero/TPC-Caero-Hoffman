<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCambiarContraseña.aspx.cs" Inherits="TPC_Caero_Hoffman.frmCambiarContraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <!--BOTON VOLVER ATRÁS-->
    <br />
    <div style="text-align: right; width:990px" >
       <asp:Button Text="Menú Principal" CssClass="btn btn-dark" ID="btnMenuPrincipal" OnClick="btnMenuPrincipal_Click" runat="server" />
    </div>

    <div>
    <h3>Cambiar Contraseña</h3>
    </div>
    
    <br />
    <div class="d-grid gap-2 col-6 mx-auto" style="border: solid; border-radius:10px 10px  ; text-align: center; background-color: black ">
  <div class="d-grid gap-2 col-6 mx-auto">
      <br />
      <asp:Label Text="Escriba su contraseña anterior: " runat="server"  ForeColor="White" />
      <asp:TextBox runat="server" type="password" ID="txtContrasenaAnterior" CssClass="form-control"/>
  </div>
  <div class="d-grid gap-2 col-6 mx-auto">
     <asp:Label Text="Escriba su nueva contraseña: " runat="server"  ForeColor="White" />
     <asp:TextBox runat="server" type="password" CssClass="form-control" id="txtContrasenaNueva"/>
    
  </div>
       
      
  <div>
      <asp:Button Text="Cambiar" OnClick="btnCambiarContrasena_Click" runat="server" type="submit" CssClass="btn btn-primary mb-3" ID="Button1"/>
  </div>
     </div>
    <div class="d-grid gap-2 col-6 mx-auto" style="border: none; background-color: yellow ; border-radius:10px 10px">
              <asp:Label ID="lblContrasenaCambiada" CssClass="center" runat="server" Font-Bold="true"/>                                   
              </div>


</asp:Content>
