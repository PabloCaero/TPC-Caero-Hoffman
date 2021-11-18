<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmModificarCliente.aspx.cs" Inherits="TPC_Caero_Hoffman.frmModificarCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    <h2>Modificar Cliente</h2>
    </div>
    <div>
     <div class="col-9">
    <label for="inputEmail4" class="form-label">Ingrese DNI</label>
        <asp:TextBox type="text" runat="server"  class="form-control" id="txtBuscarClientexDNI" />
        <asp:Button ID="btnBuscarClientexDNI" runat="server" OnClick="btnBuscarClientexDNI_Click" Text="Buscar" />  
        </div>
       </div>

      <div class="row">
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
    <asp:TextBox type="text" runat="server" class="form-control" id="txtDNI"/>
  </div>
  <div class="col-md-6">
    <label for="inputEmail4" class="form-label">Email</label>
    <asp:TextBox type="text" runat="server" class="form-control" id="txtEmail"/>
  </div>
     <div class="col-md-6">
    <label for="inputEmail4" class="form-label">Teléfono</label>
    <asp:TextBox type="text" runat="server" class="form-control" id="txtTelefono"/>
  </div>
         <div class="col-md-6">
    <label for="inputEmail4" class="form-label">Fecha de Nacimiento</label>
    <asp:TextBox type="text" runat="server" class="form-control" id="txtFechaNacimiento" placeholder="DD/MM/AAAA"/>
  </div>
  <div class="col-md-6">
    <label for="inputAddress" class="form-label">Calle</label>
    <asp:TextBox type="text" runat="server" class="form-control" id="txtCalle"/>
  </div>
        <div class="col-md-2">
    <label for="inputAddress" class="form-label">Altura</label>
    <asp:TextBox type="text" runat="server" class="form-control" id="txtAltura" placeholder="1234"/>
  </div>
        <div class="col-md-2">
    <label for="inputZip" class="form-label">Código Postal</label>
    <asp:TextBox type="text" runat="server" class="form-control" id="txtCodigoPostal"/>
  </div>
  <div class="col-md-6">
    <label for="inputCity" class="form-label">Localidad</label>
    <asp:TextBox type="text" runat="server" class="form-control" id="txtLocalidad"/>
  </div>
   <div class="col-md-6">
    <label for="inputCity" class="form-label">Provincia</label>
    <asp:TextBox type="text" runat="server" class="form-control" id="txtProvincia"/>
  </div>
  
  <div class="col-md-6">
      <asp:Button ID="btnModificarCliente" runat="server" OnClick="btnModificarCliente_Click" Text="Cargar Cliente" />
  </div>
</div>

</asp:Content>
