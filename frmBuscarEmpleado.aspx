<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmBuscarEmpleado.aspx.cs" Inherits="TPC_Caero_Hoffman.frmBuscarEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!--BOTON VOLVER ATRÁS-->
    <br />
    <div style="text-align: right; width:990px" >
       <asp:Button Text="Menú Principal" CssClass="btn btn-dark" ID="btnMenuPrincipal" OnClick="btnMenuPrincipal_Click" runat="server" />
    </div>

     <div>
    <h3>Buscar Empleado</h3>
    </div>
    <div>
     <div class="col-9">
    <label for="inputEmail4" class="form-label">Ingrese Legajo</label>
        <asp:TextBox type="text" runat="server"  class="form-control" id="txtBuscarEmpleadoxID" />
        <asp:Button ID="btnBuscarEmpleadoxLegajo" runat="server" OnClick="btnBuscarEmpleadoxLegajo_Click" Text="Buscar" />  
   
        <div class="row" > 
            <asp:GridView ID="dgvEmpleados" CssClass="table table-success table-striped" runat="server"
                AutoGenerateColumns="false"          
                DataKeyNames="Legajo" 
                >
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

                    <asp:CommandField ButtonType="Link" ShowEditButton="false" ShowDeleteButton="false" />
                </Columns>

            </asp:GridView>
        </div>
        </div>
       </div>

</asp:Content>
