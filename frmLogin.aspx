<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="TPC_Caero_Hoffman.frmLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    
    <script>    
        function validar() {
            var nombreUsuario = document.getElementById("txtNombreUsuario").value;
            var password = document.getElementById("txtPassword").value;
            var valido = true;

            if (nombreUsuario === "") {
                $("#txtNombreUsuario").removeClass("is-valid");
                $("#txtNombreUsuario").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtNombreUsuario").removeClass("is-invalid");
                $("#txtNombreUsuario").addClass("is-valid");
            }

            if (password === "") {
                $("#txtPassword").removeClass("is-valid");
                $("#txtPassword").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtPassword").removeClass("is-valid");
                $("#txtPassword").addClass("is-invalid");
            }

            if (!valido) {
                return false;
            }

            return true;

        }

    </script>






    <br />
    <div class="d-grid gap-2 col-6 mx-auto" style="border: solid; border-radius:10px 10px  ; text-align: center; background-color: black">
  <div class="d-grid gap-2 col-6 mx-auto">
      <br />
      <asp:Label Text="Usuario" runat="server" Font-Bold="true" ForeColor="White"/>
       
      <asp:TextBox runat="server" ID="txtNombreUsuario" ClientIDMode="Static" CssClass="form-control"/>
  </div>
  <div class="d-grid gap-2 col-6 mx-auto">
      <asp:Label Text="Contraseña" runat="server"  Font-Bold="true" ForeColor="White"/>
      <asp:TextBox runat="server" type="password" ClientIDMode="Static" CssClass="form-control" id="txtPassword"/>
      <asp:Label ID="lblMensaje" runat="server" Font-Bold="true" ForeColor="Red" />
    
  </div>
       
  <div>
       <p><a href="frmOlvideMiContraseña">Olvide mi contraseña</a></p>
      <asp:Button Text="Ingresar" OnClientClick="return validar()" OnClick="btnIngresar_Click" runat="server" type="submit" CssClass="btn btn-primary mb-3" ID="btnIngresar"/>
  </div>
     </div>







</asp:Content>
