<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmEliminarCliente.aspx.cs" Inherits="TPC_Caero_Hoffman.frmEliminarCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div>
    <h2>Eliminar Cliente</h2>
    </div>
    <div>
     <div class="col-9">
    <label for="inputEmail4" class="form-label">Ingrese DNI</label>
        <asp:TextBox type="text" runat="server"  class="form-control" id="txtBuscarClientexDNI" />
        <asp:Button ID="btnBuscarClientexDNI" runat="server" OnClick="btnBuscarClientexDNI_Click" Text="Buscar" />  
   
        <div class="row" > 
            <asp:GridView ID="dgvClientes" CssClass="table table-success table-striped" runat="server"
                AutoGenerateColumns="false" 
                
                          
                DataKeyNames="IDCliente" OnRowDeleting="rowDeletingEvent">
                <Columns>

                    <asp:TemplateField HeaderText="ID">
                        <ItemTemplate> 
                            <asp:Label Text=<%# Bind("IDCliente")%> runat="server" ID="lblIDCliente" />
                        </ItemTemplate>             
                    </asp:TemplateField>
   
                    <asp:TemplateField HeaderText="DNI">
                        <ItemTemplate> 
                            <asp:Label Text=<%# Bind("DNI")%> runat="server" ID="lblDNI" />
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

                    <asp:TemplateField HeaderText="Email">
                    <ItemTemplate> 
                            <asp:Label Text=<%# Bind("Email")%> runat="server" ID="lblEmail" />
                        </ItemTemplate>              
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="Telefono">
                    <ItemTemplate> 
                            <asp:Label Text=<%# Bind("Telefono")%> runat="server" ID="lblTelefono" />
                        </ItemTemplate>              
                    </asp:TemplateField>


                    <asp:CommandField ButtonType="Link" ShowEditButton="false" ShowDeleteButton="true" />
                </Columns>

            </asp:GridView>
        </div>
        </div>
       </div>


</asp:Content>
