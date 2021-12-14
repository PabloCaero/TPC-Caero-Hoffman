<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCrearIncidentePropio.aspx.cs" Inherits="TPC_Caero_Hoffman.frmCrearIncidentePropio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script>    
        function validar() {
            var detalles = document.getElementById("txtDetalles").value;
            var valido = true;

            if (detalles === "") {
                $("#txtDetalles").removeClass("is-valid");
                $("#txtDetalles").addClass("is-invalid");
                valido = false;
            }
            else {
                $("#txtDetalles").removeClass("is-invalid");
                $("#txtDetalles").addClass("is-valid");
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

     <h3>Crear Incidente</h3>


    <!--BUSQUEDA DE CLIENTE-->
   
        

    <div class="container">
        <div class="row justify-content-center">
            <div class="col-md-6">
         <label for="inputEmail4" class="form-label">Por DNI</label>
     <div class="alinear"> 
         <div>
         <asp:TextBox type="text" runat="server"  class="form-control" id="txtBuscarClientexDNI" />
         </div>        
         <asp:Button ID="btnBuscarClientexDNI" CssClass="btn btn-primary mb-2" runat="server" OnClick="btnBuscarClientexDNI_Click" Text="Buscar" />          
      </div>
               </div>

              <div class="col-md-4">
          <label for="inputEmail4" class="form-label">Por Apellido</label>
         <div class="alinear">
             <div>
        <asp:TextBox type="text" runat="server"  class="form-control" id="txtBuscarClientexApellido" />
               </div>
        <asp:Button ID="btnBuscarClientexApellido" runat="server" CssClass="btn btn-primary mb-2" OnClick="btnBuscarClientexApellido_Click" Text="Buscar" />
              </div>
                  </div>
            </div>
        </div>
    <br />
    <div class="d-grid gap-2 col-6 mx-auto" style="border: none; background-color: yellow ; border-radius:10px 10px">
            <asp:Label ID="lblClienteSeleccionado" CssClass="center" runat="server" Font-Bold="true"/>
              </div>
    <br />

        <div class="row" > 
            <asp:GridView ID="dgvClientes" CssClass="table table-hover table-info" runat="server"
                AutoGenerateColumns="false"        
                DataKeyNames="IDCliente" OnSelectedIndexChanging="dgvClientes_SelectedIndexChanging">
                <Columns>
                    <asp:BoundField DataField="IDCliente" HeaderText="ID" />
                    <asp:BoundField DataField="DNI" HeaderText="DNI"/>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre"/>
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido"/>
                    <asp:CommandField ButtonType="Link" ShowSelectButton="true"  ShowEditButton="false" ShowDeleteButton="false" />
                </Columns>

            </asp:GridView>

            <!--IMPORTANTE PARA ASIGNAR ATRIBUTO-->
            <asp:Label ID="lblIDCliente" runat="server" Visible="false" />
          
   
        </div>
       

    <!--ESPECIALIDAD DEL INCIDENTE-->
    <div class="container">
        <div class ="row justify-content-center">
    <div class="col-md-6">
         <label for="inputEmail4" class="form-label">Especialidad</label>
         <asp:DropDownList runat="server" ID="ddlEspecialidad" CssClass="btn btn-info dropdown-toggle dropdown-toggle-split" AutoPostBack="true" >
         </asp:DropDownList>
             </div>

    <!--PRIORIDAD DEL INCIDENTE-->
    <div class="col-md-4">
         <label for="inputEmail4" class="form-label">Prioridad</label>
         <asp:DropDownList runat="server" ID="ddlPrioridad" CssClass="btn btn-info dropdown-toggle dropdown-toggle-split" AutoPostBack="true" >
         </asp:DropDownList>
             </div>
            </div>
        </div>

    <br />
    <!--DETALLES DEL INCIDENTE-->
     

     <div class="container">
        <div class="row">
            <div class="alinear">
         <div class="col">
        <asp:TextBox type="text" runat="server" PlaceHolder="DETALLES DEL INCIDENTE"  ClientIDMode="Static"  CssClass="form-control" id="txtDetalles" Height="80px" />
           </div>
        <asp:Button ID="btnCrearIncidente" CssClass="btn btn-primary btn-lg" runat="server" OnClick="btnCrearIncidente_Click" Text="Crear Incidente" />          
           
                </div>
            </div>
          </div>
              
           



      <br />

          <div class="d-grid gap-2 col-6 mx-auto" style="border: none; background-color: yellow ; border-radius:10px 10px">
              <asp:Label ID="lblConfirmacion" CssClass="center" runat="server" Font-Bold="true"/>                                   
              </div>

</asp:Content>
