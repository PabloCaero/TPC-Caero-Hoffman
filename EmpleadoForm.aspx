<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmpleadoForm.aspx.cs" Inherits="TPC_Caero_Hoffman.EmpleadoForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 <div>
    <h2>Registrar Empleado</h2>
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
    <label for="inputEmail4" class="form-label">Nombre de Usuario</label>
    <asp:TextBox type="text" class="form-control" runat="server" ID="txtNombreUsuario" />

  </div>
          <div class="col-md-6">
    <label for="inputEmail4" class="form-label">Contraseña</label>
    <asp:TextBox type="text" class="form-control" runat="server" ID="txtContrasena" />

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
         <label for="inputAddress" class="form-label">Cargo</label>
         <asp:DropDownList runat="server" ID="ddlCargos" CssClass="btn btn-outline-dark dropdown-toggle" AutoPostBack="true" >
         </asp:DropDownList>
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
    <label for="inputAddress" class="form-label">Dirección</label>
    <asp:TextBox type="text" runat="server" class="form-control" id="txtDireccion"/>
  </div>
        <div class="col-md-2">
    <label for="inputAddress" class="form-label">Altura</label>
    <asp:TextBox type="text" runat="server" class="form-control" id="txtAltura" placeholder="1234"/>
  </div>
  <div class="col-md-6">
    <label for="inputCity" class="form-label">Localidad</label>
    <asp:TextBox type="text" runat="server" class="form-control" id="txtLocalidad"/>
  </div>
   <div class="col-md-6">
    <label for="inputCity" class="form-label">Provincia</label>
    <asp:TextBox type="text" runat="server" class="form-control" id="txtProvincia"/>
  </div>
  <div class="col-md-2">
    <label for="inputZip" class="form-label">Código Postal</label>
    <asp:TextBox type="text" runat="server" class="form-control" id="txtCodigoPostal"/>
  </div>
  <div class="col-12">
      <asp:Button Text="Cargar Empleado" runat="server" ID="btnCargarEmpleado" />
  </div>
        </div>

</asp:Content>
