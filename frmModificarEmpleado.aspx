<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmModificarEmpleado.aspx.cs" Inherits="TPC_Caero_Hoffman.frmModificarEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    <h2>Modificar Empleado</h2>
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
                OnRowCancelingEdit="rowCancelEditEvent" 
                OnRowEditing="rowEditingEvent" 
                OnRowUpdating="rowUpdatingEvent">
                <Columns>

                    <asp:TemplateField HeaderText="Legajo">
                        <ItemTemplate> 
                            <asp:Label Text=<%# Bind("Legajo")%> runat="server" ID="lblLegajo" />
                        </ItemTemplate>             
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="Cargo">
                    <ItemTemplate> 
                            <asp:Label Text=<%# Bind("Cargo.Nombre_Cargo")%> runat="server" ID="lblNombreCargo" />
                        </ItemTemplate>                  
                    </asp:TemplateField>
   
                    <asp:TemplateField HeaderText="DNI">
                        <ItemTemplate> 
                            <asp:Label Text=<%# Bind("DNI")%> runat="server" ID="lblDNI" />
                        </ItemTemplate>              
                        <EditItemTemplate> 
                            <asp:TextBox runat="server" ID="txtDNI" Text=<%# Bind("DNI")%> />
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate> 
                            <asp:Label Text=<%# Bind("Nombre")%> runat="server" ID="lblNombre" />
                        </ItemTemplate>              
                        <EditItemTemplate> 
                            <asp:TextBox runat="server" ID="txtNombre" Text=<%# Bind("Nombre")%> />
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Apellido">
                    <ItemTemplate> 
                            <asp:Label Text=<%# Bind("Apellido")%> runat="server" ID="lblApellido" />
                        </ItemTemplate>              
                        <EditItemTemplate> 
                            <asp:TextBox runat="server" ID="txtApellido" Text=<%# Bind("Apellido")%> />
                        </EditItemTemplate>
                    </asp:TemplateField>

     
                     <asp:TemplateField HeaderText="Email">
                    <ItemTemplate> 
                            <asp:Label Text=<%# Bind("Email")%> runat="server" ID="lblEmail" />
                        </ItemTemplate>              
                        <EditItemTemplate> 
                            <asp:TextBox runat="server" ID="txtEmail" Text=<%# Bind("Email")%> />
                        </EditItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Telefono">
                    <ItemTemplate> 
                            <asp:Label Text=<%# Bind("Telefono")%> runat="server" ID="lblTelefono" />
                        </ItemTemplate>              
                        <EditItemTemplate> 
                            <asp:TextBox runat="server" ID="txtTelefono" Text=<%# Bind("Telefono")%> />
                        </EditItemTemplate>
                    </asp:TemplateField>

     

                    <asp:CommandField ButtonType="Link" ShowEditButton="true" ShowDeleteButton="false" />
                </Columns>

            </asp:GridView>
        </div>
        </div>
       </div>


</asp:Content>
