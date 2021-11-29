<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="TPC_Caero_Hoffman.frmLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <div class="d-grid gap-2 col-6 mx-auto" style="border: solid; border-radius:10px 10px  ; text-align: center; background-color: black ">
  <div class="d-grid gap-2 col-6 mx-auto">
      <br />
      <asp:Label Text="Usuario" runat="server" Font-Bold="true" ForeColor="White"/>
       
      <asp:TextBox runat="server" ID="txtNombreUsuario" CssClass="form-control"/>
  </div>
  <div class="d-grid gap-2 col-6 mx-auto">
      <asp:Label Text="Contraseña" runat="server"  Font-Bold="true" ForeColor="White"/>
      <asp:TextBox runat="server" type="password" CssClass="form-control" id="txtPassword"/>
    
  </div>
       
  <div>
       <p><a href="#">Olvide mi contraseña</a></p>
      <asp:Button Text="Ingresar" OnClick="btnIngresar_Click" runat="server" type="submit" CssClass="btn btn-primary mb-3" ID="btnIngresar"/>
  </div>
     </div>







</asp:Content>
