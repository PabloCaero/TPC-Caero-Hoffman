<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmModificarDetallesIncidente.aspx.cs" Inherits="TPC_Caero_Hoffman.frmModificarDetallesIncidente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <!--BOTON VOLVER ATRÁS-->
    <br />
    <div style="text-align: right; width:990px" >
       <asp:Button Text="Menú Principal" CssClass="btn btn-dark" ID="btnMenuPrincipal" OnClick="btnMenuPrincipal_Click" runat="server" />
    </div>

    <div>
    <h3>Modificar Detalles de Incidente</h3>
    </div>
    
     <div class="col-9">
    <label for="inputEmail4" class="form-label">Buscar por ID de Incidente</label>
        <asp:TextBox type="text" runat="server"  class="form-control" id="txtBuscarIncidentexID" />
        <asp:Button ID="btnBuscarIncidentexID" runat="server" OnClick="btnBuscarIncidentexID_Click" Text="Buscar" />  
   
           <label for="inputEmail4" class="form-label">Buscar por Apellido Cliente</label>
        <asp:TextBox type="text" runat="server"  class="form-control" id="txtBuscarIncidentexApeCliente" />
        <asp:Button ID="btnBuscarIncidentexApeCliente" runat="server" OnClick="btnBuscarIncidentexApeCliente_Click" Text="Buscar" /> 

         <label for="inputEmail4" class="form-label">Buscar por Apellido Empleado</label>
        <asp:TextBox type="text" runat="server"  class="form-control" id="txtBuscarIncidentexApeEmpleado" />
        <asp:Button ID="btnBuscarIncidentexApeEmpleado" runat="server" OnClick="btnBuscarIncidentexApeEmpleado_Click" Text="Buscar" /> 


         <div>
        <div class="row" > 
            <asp:GridView ID="dgvIncidentes" CssClass="table table-success table-striped" runat="server" AutoGenerateColumns="false"
                OnRowEditing="dgvIncidentes_RowEditing"
                OnRowUpdating="dgvIncidentes_RowUpdating"
                
                DataKeyNames="ID" OnRowCancelingEdit="dgvIncidentes_RowCancelingEdit"
                >
                <Columns>
                  

                 <asp:TemplateField HeaderText="ID">
                        <ItemTemplate> 
                            <asp:Label Text=<%# Bind("ID")%> runat="server" ID="lblID" />
                        </ItemTemplate>             
                    </asp:TemplateField> 
                    
                    <asp:TemplateField HeaderText="Nombre de Cliente">
                        <ItemTemplate> 
                            <asp:Label Text=<%# Bind("Cliente.Nombre")%> runat="server" ID="lblNombreCliente" />
                        </ItemTemplate>             
                    </asp:TemplateField>  

                    <asp:TemplateField HeaderText="Apellido de Cliente">
                        <ItemTemplate> 
                            <asp:Label Text=<%# Bind("Cliente.Apellido")%> runat="server" ID="lblApellidoCliente" />
                        </ItemTemplate>             
                    </asp:TemplateField> 

                    

                  <asp:TemplateField HeaderText="Detalles">
                        <ItemTemplate> 
                            <asp:Label Text=<%# Bind("Detalles")%> runat="server" ID="lblDetalles" />
                        </ItemTemplate>  
                      <EditItemTemplate> 
                            <asp:TextBox runat="server" Height="100px"  ID="txtDetalles" Text=<%# Bind("Detalles")%> />
                        </EditItemTemplate>
                    </asp:TemplateField> 
              
              <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="false" />

                </Columns>

            </asp:GridView>
            <asp:Label ID="lblConfirmacion" Font-Bold="true" runat="server" />
        </div>
        </div>
         </div>

</asp:Content>
