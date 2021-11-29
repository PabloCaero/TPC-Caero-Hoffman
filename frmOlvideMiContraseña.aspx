<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmOlvideMiContraseña.aspx.cs" Inherits="TPC_Caero_Hoffman.frmOlvideMiContraseña" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <!--BOTON VOLVER A LOGIN-->
    <br />
    <div style="text-align: right; width:990px" >
       <asp:Button Text="Login" CssClass="btn btn-dark" ID="btnLogin" OnClick="btnLogin_Click" runat="server" />
    </div>

    
    <br />
    <div class="d-grid gap-2 col-6 mx-auto" style="border: solid; border-radius:10px 10px  ; text-align: center; background-color: black ">
  <div class="d-grid gap-2 col-6 mx-auto">
      <br />
      <asp:Label Text="Ingrese su email para recuperar la contraseña" runat="server"  ForeColor="White" />
      <asp:TextBox runat="server" type="email" ID="txtEmail" CssClass="form-control"/>
  </div>
  
   <asp:Label ID="lblEstadoEnvio" runat="server" ForeColor="White"/> 
  <div>     
      <asp:Button Text="Enviar" OnClick="btnRecuperarPassword_Click" runat="server" type="submit" CssClass="btn btn-primary mb-3" ID="btnRecuperarPassword"/>
  </div>
  </div>


</asp:Content>
