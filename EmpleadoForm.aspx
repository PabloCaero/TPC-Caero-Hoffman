<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmpleadoForm.aspx.cs" Inherits="TPC_Caero_Hoffman.EmpleadoForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 <script>    
        function validar() {
            var nombre = document.getElementById("txtNombre").value;
            var apellido = document.getElementById("txtApellido").value;
            var nombreusuario = document.getElementById("txtNombreUsuario").value;
            var contrasena = document.getElementById("txtContrasena").value;
            var dni = document.getElementById("txtDNI").value;
            var email = document.getElementById("txtEmail").value;
            var telefono = document.getElementById("txtTelefono").value;
            var fechanacimiento = document.getElementById("txtFechaNacimiento").value;
            var calle = document.getElementById("txtCalle").value;
            var altura = document.getElementById("txtAltura").value;
            var codigopostal = document.getElementById("txtCodigoPostal").value;
            var localidad = document.getElementById("txtLocalidad").value;
            var provincia = document.getElementById("txtProvincia").value;
            var valido = true;

            if (nombre === "") {
                $("#txtNombre").removeClass("is-valid");
                $("#txtNombre").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtNombre").removeClass("is-invalid");
                $("#txtNombre").addClass("is-valid");
            }

            if (apellido === "") {
                $("#txtApellido").removeClass("is-valid");
                $("#txtApellido").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtApellido").removeClass("is-invalid");
                $("#txtApellido").addClass("is-valid");
            }

            if (nombreusuario === "") {
                $("#txtNombreUsuario").removeClass("is-valid");
                $("#txtNombreUsuario").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtNombreUsuario").removeClass("is-invalid");
                $("#txtNombreUsuario").addClass("is-valid");
            }

            if (dni === "") {
                $("#txtDNI").removeClass("is-valid");
                $("#txtDNI").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtDNI").removeClass("is-invalid");
                $("#txtDNI").addClass("is-valid");
            }

            if (email === "") {
                $("#txtEmail").removeClass("is-valid");
                $("#txtEmail").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtEmail").removeClass("is-invalid");
                $("#txtEmail").addClass("is-valid");
            }

            if (email === "") {
                $("#txtEmail").removeClass("is-valid");
                $("#txtEmail").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtEmail").removeClass("is-invalid");
                $("#txtEmail").addClass("is-valid");
            }

            if (telefono === "") {
                $("#txtTelefono").removeClass("is-valid");
                $("#txtTelefono").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtTelefono").removeClass("is-invalid");
                $("#txtTelefono").addClass("is-valid");
            }

            if (fechanacimiento === "") {
                $("#txtFechaNacimiento").removeClass("is-valid");
                $("#txtFechaNacimiento").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtFechaNacimiento").removeClass("is-invalid");
                $("#txtFechaNacimiento").addClass("is-valid");
            }


            if (calle === "") {
                $("#txtCalle").removeClass("is-valid");
                $("#txtCalle").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtCalle").removeClass("is-invalid");
                $("#txtCalle").addClass("is-valid");
            }

            if (altura === "") {
                $("#txtAltura").removeClass("is-valid");
                $("#txtAltura").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtAltura").removeClass("is-invalid");
                $("#txtAltura").addClass("is-valid");
            }

            if (codigopostal === "") {
                $("#txtCodigoPostal").removeClass("is-valid");
                $("#txtCodigoPostal").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtCodigoPostal").removeClass("is-invalid");
                $("#txtCodigoPostal").addClass("is-valid");
            }

            if (localidad === "") {
                $("#txtLocalidad").removeClass("is-valid");
                $("#txtLocalidad").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtLocalidad").removeClass("is-invalid");
                $("#txtLocalidad").addClass("is-valid");
            }

            if (provincia === "") {
                $("#txtProvincia").removeClass("is-valid");
                $("#txtProvincia").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtProvincia").removeClass("is-invalid");
                $("#txtProvincia").addClass("is-valid");
            }

            if (!valido) {
                return false;
            }

            return true;

        }

 </script>



<!--BOTON VOLVER ATRÁS-->
    <br />
    <div style="text-align: right; width:990px" >
       <asp:Button Text="Menú Principal" CssClass="btn btn-dark" ID="btnMenuPrincipal" OnClick="btnMenuPrincipal_Click" runat="server" />
    </div>

 <div>
    <h3>Registrar Empleado</h3>
    </div>
    <div class="row">
     <div class="col-md-6">
    <label for="inputEmail4" class="form-label">Nombre/s</label>
    <asp:TextBox type="text" CssClass="form-control" ClientIDMode="Static" runat="server" ID="txtNombre" />

  </div>
  <div class="col-md-6">
    <label for="inputAddress" class="form-label">Apellido/s</label>
    <asp:TextBox type="text" runat="server"  CssClass="form-control" ClientIDMode="Static" id="txtApellido" />
  </div>
 <div class="col-md-6">
    <label for="inputEmail4" class="form-label">Nombre de Usuario</label>
    <asp:TextBox type="text" CssClass="form-control" ClientIDMode="Static" runat="server" ID="txtNombreUsuario" />

  </div>
          <div class="col-md-6">
    <label for="inputEmail4" class="form-label">Contraseña</label>
    <asp:TextBox type="text" CssClass="form-control" ClientIDMode="Static" runat="server" ID="txtContrasena" />

  </div>

   <div class="col-md-6">
    <label for="inputAddress" class="form-label">DNI</label>
    <asp:TextBox type="text" runat="server" CssClass="form-control" ClientIDMode="Static" id="txtDNI"/>
  </div>
  <div class="col-md-6">
    <label for="inputEmail4" class="form-label">Email</label>
    <asp:TextBox type="text" runat="server" CssClass="form-control" ClientIDMode="Static" id="txtEmail"/>
  </div>

         <div class="col-md-6">
         <label for="inputEmail4" class="form-label">Cargo</label>
             <br />
         <asp:DropDownList runat="server" ID="ddlCargos" CssClass="btn btn-primary dropdown-toggle" AutoPostBack="true" >
         </asp:DropDownList>
             </div>

     <div class="col-md-6">
    <label for="inputEmail4" class="form-label">Teléfono</label>
    <asp:TextBox type="text" runat="server" CssClass="form-control" ClientIDMode="Static" id="txtTelefono"/>
  </div>
         <div class="col-md-6">
    <label for="inputEmail4" class="form-label">Fecha de Nacimiento</label>
    <asp:TextBox type="text" runat="server" CssClass="form-control" ClientIDMode="Static" id="txtFechaNacimiento" placeholder="DD/MM/AAAA"/>
  </div>
  <div class="col-md-6">
    <label for="inputAddress" class="form-label">Calle</label>
    <asp:TextBox type="text" runat="server" CssClass="form-control" ClientIDMode="Static" id="txtCalle"/>
  </div>
        <div class="col-md-2">
    <label for="inputAddress" class="form-label">Altura</label>
    <asp:TextBox type="text" runat="server" CssClass="form-control" ClientIDMode="Static" id="txtAltura" placeholder="1234"/>
  </div>
  <div class="col-md-6">
    <label for="inputCity" class="form-label">Localidad</label>
    <asp:TextBox type="text" runat="server" CssClass="form-control" ClientIDMode="Static" id="txtLocalidad"/>
  </div>
   <div class="col-md-6">
    <label for="inputCity" class="form-label">Provincia</label>
    <asp:TextBox type="text" runat="server" CssClass="form-control" ClientIDMode="Static" id="txtProvincia"/>
  </div>
  <div class="col-md-2">
    <label for="inputZip" class="form-label">Código Postal</label>
    <asp:TextBox type="text" runat="server" CssClass="form-control" ClientIDMode="Static" id="txtCodigoPostal"/>
  </div>
  </div>

  
     <br />
    <div class="container">
        <div class="row align-content-center">
               <asp:Button Text="Cargar Empleado"  CssClass="btn btn-primary btn-lg" runat="server" ID="btnCargarEmpleado" OnClientClick="return validar()" OnClick="btnCargarEmpleado_Click" />     
            </div>
        </div>

     <br />

          <div class="d-grid gap-2 col-6 mx-auto" style="border: none; background-color: yellow ; border-radius:10px 10px">
              <asp:Label ID="lblConfirmacion" CssClass="center" runat="server" Font-Bold="true"/>                                   
              </div>

</asp:Content>
