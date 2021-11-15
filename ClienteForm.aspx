<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ClienteForm.aspx.cs" Inherits="TPC_Caero_Hoffman.ClienteForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <form class="row g-3">
     <div class="col-md-6">
    <label for="inputEmail4" class="form-label">Nombre/s</label>
    <asp:TextBox type="text" class="form-control" runat="server" ID="txtNombre" />

  </div>
  <div class="col-md-6">
    <label for="inputAddress" class="form-label">Apellido/s</label>
    <asp:TextBox type="text" runat="server"  class="form-control" id="txtApellido" />
  </div>
          <div class="col-md-6">
    <label for="inputAddress" class="form-label">DNI</label>
    <asp:TextBox type="text" runat="server" class="form-control" id="txtDNI">
  </div>
  <div class="col-md-6">
    <label for="inputEmail4" class="form-label">Email</label>
    <input type="email" class="form-control" id="txtEmail">
  </div>
  <div class="col-md-6">
    <label for="inputAddress" class="form-label">Dirección</label>
    <input type="text" class="form-control" id="txtDireccion" placeholder="1234 Main St">
  </div>
  <div class="col-md-6">
    <label for="inputCity" class="form-label">Localidad</label>
    <input type="text" class="form-control" id="txtLocalidad">
  </div>
   <div class="col-md-6">
    <label for="inputCity" class="form-label">Provincia</label>
    <input type="text" class="form-control" id="txtProvincia">
  </div>
  <div class="col-md-2">
    <label for="inputZip" class="form-label">Código Postal</label>
    <input type="text" class="form-control" id="txtCodigoPostal">
  </div>
  <div class="col-12">
    <button type="submit" class="btn btn-primary">Cargar Cliente</button>
  </div>
</form>

    <!--TEXT BOX Y BOTON ACEPTAR
    
        

    <div class="div-form">
        <asp:Label Text="DNI: " runat="server" />
        <asp:TextBox runat="server" ID="txtDNI" />
    </div>

    <div class="div-form">
        <asp:Button Text="Aceptar" ID="btnAceptar" OnClick="btnAceptar_Click" runat="server" />

    </div>-->

</asp:Content>
