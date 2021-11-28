<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="TPC_Caero_Hoffman.frmLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


  <div class="col-auto">
      <asp:Label Text="Usuario" runat="server" />
      <asp:TextBox runat="server" ID="txtNombreUsuario" CssClass="form-control"/>
  </div>
  <div class="col-auto">
      <asp:Label Text="Contraseña" runat="server" />
      <asp:TextBox runat="server" type="password" CssClass="form-control" id="txtPassword"/>
   
  </div>
  <div class="col-auto">
      <asp:Button Text="Ingresar" OnClick="btnIngresar_Click" runat="server" type="submit" CssClass="btn btn-primary mb-3" ID="btnIngresar"/>
  </div>

</asp:Content>
