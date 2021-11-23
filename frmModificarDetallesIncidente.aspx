<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmModificarDetallesIncidente.aspx.cs" Inherits="TPC_Caero_Hoffman.frmModificarDetallesIncidente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div>
    <h2>Modificar Detalles de Incidente</h2>
    </div>
    
     <div class="col-9">
    <label for="inputEmail4" class="form-label">Buscar por ID de Incidente</label>
        <asp:TextBox type="text" runat="server"  class="form-control" id="txtBuscarIncidentexID" />
        <asp:Button ID="btnBuscarIncidentexID" runat="server" OnClick="btnBuscarIncidentexID_Click" Text="Buscar" />  
   
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
        </div>
        </div>
         </div>

</asp:Content>
