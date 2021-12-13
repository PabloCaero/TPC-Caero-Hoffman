<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmBuscarClientePorDNI.aspx.cs" Inherits="TPC_Caero_Hoffman.frmBuscarClientePorDNI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<!--BOTON VOLVER ATRÁS-->
  


    <br />
    <div style="text-align: right; width:990px" >
       <asp:Button Text="Menú Principal" CssClass="btn btn-dark" ID="btnMenuPrincipal" OnClick="btnMenuPrincipal_Click" runat="server" />
    </div>

    <div>
    <h3>Buscar Cliente</h3>
    </div>
    
         <div>
         <label for="inputEmail4" class="form-label">Por DNI</label>
         </div>

     <div class="alinear"> 
         <div>
         <asp:TextBox type="text" runat="server"  class="form-control" id="txtBuscarClientexDNI" />
         </div>        
         <asp:Button ID="btnBuscarClientexDNI" CssClass="btn btn-primary mb-2" runat="server" OnClick="btnBuscarClientexDNI_Click" Text="Buscar" />          
      </div>

          <label for="inputEmail4" class="form-label">Por Apellido</label>
         <div class="alinear">
             <div>
        <asp:TextBox type="text" runat="server"  class="form-control" id="txtBuscarClientexApellido" />
               </div>
        <asp:Button ID="btnBuscarClientexApellido" runat="server" CssClass="btn btn-primary mb-2" OnClick="btnBuscarClientexApellido_Click" Text="Buscar" />
              </div>

        <div class="row" > 
            <asp:GridView ID="dgvClientes" CssClass="table table-hover table-info" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="DNI" HeaderText="DNI"/>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre"/>
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido"/>
                    <asp:BoundField DataField="Direccion.Calle" HeaderText="Calle"/>
                    <asp:BoundField DataField="Direccion.Numero" HeaderText="Altura"/>
                    <asp:BoundField DataField="Direccion.Localidad" HeaderText="Localidad"/>
                    <asp:BoundField DataField="Direccion.Provincia" HeaderText="Provincia"/>
                </Columns>

            </asp:GridView>
        </div>
      
       

</asp:Content>
