<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmEliminarEmpleado.aspx.cs" Inherits="TPC_Caero_Hoffman.frmEliminarEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


     <!--BOTON VOLVER ATRÁS-->
    <br />
    <div style="text-align: right; width:990px" >
       <asp:Button Text="Menú Principal" CssClass="btn btn-dark" ID="btnMenuPrincipal" OnClick="btnMenuPrincipal_Click" runat="server" />
    </div>

      <div>
    <h3>Eliminar Empleado</h3>
    </div>
      <div class="container">
        <div class="row justify-content-center">
            <div class="col-md-6">
         <label for="inputEmail4" class="form-label">Por Legajo</label>
     <div class="alinear"> 
         <div>
         <asp:TextBox type="text" runat="server"  class="form-control" id="txtBuscarEmpleadoxID" />
         </div>        
         <asp:Button ID="btnBuscarEmpleadoxLegajo" CssClass="btn btn-primary mb-2" runat="server" OnClick="btnBuscarEmpleadoxLegajo_Click" Text="Buscar" />          
      </div>
               </div>

              <div class="col-md-4">
          <label for="inputEmail4" class="form-label">Por Apellido</label>
         <div class="alinear">
             <div>
        <asp:TextBox type="text" runat="server"  class="form-control" id="txtBuscarEmpleadoxApellido" />
               </div>
        <asp:Button ID="btnBuscarEmpleadoxApellido" runat="server" CssClass="btn btn-primary mb-2" OnClick="btnBuscarEmpleadoxApellido_Click" Text="Buscar" />
              </div>
                  </div>
            </div>
        </div>
        <div class="row" > 
            <asp:GridView ID="dgvEmpleados" CssClass="table table-hover table-info" runat="server"
                AutoGenerateColumns="false"          
                DataKeyNames="Legajo" 
                OnRowDeleting="rowDeletingEvent">
                <Columns>

                    <asp:TemplateField HeaderText="Legajo">
                        <ItemTemplate> 
                            <asp:Label Text=<%# Bind("Legajo")%> runat="server" ID="lblLegajo" />
                        </ItemTemplate>             
                    </asp:TemplateField>

                       <asp:TemplateField HeaderText="Cargo">
                    <ItemTemplate> 
                            <asp:Label Text=<%# Bind("Cargo.Nombre_Cargo")%> runat="server" ID="lblCargo" />
                        </ItemTemplate>              
                    </asp:TemplateField>
   
                    <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate> 
                            <asp:Label Text=<%# Bind("Nombre")%> runat="server" ID="lblNombre" />
                        </ItemTemplate>              
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Apellido">
                    <ItemTemplate> 
                            <asp:Label Text=<%# Bind("Apellido")%> runat="server" ID="lblApellido" />
                        </ItemTemplate>              
                    </asp:TemplateField>

       
                    <asp:CommandField ButtonType="Link" ShowEditButton="false" ShowDeleteButton="true" />
                </Columns>

            </asp:GridView>
              <br />

          <div class="d-grid gap-2 col-6 mx-auto" style="border: none; background-color: yellow ; border-radius:10px 10px">
              <asp:Label ID="lblConfirmacion" CssClass="center" runat="server" Font-Bold="true"/>                                   
              </div>
        </div>
      

</asp:Content>
