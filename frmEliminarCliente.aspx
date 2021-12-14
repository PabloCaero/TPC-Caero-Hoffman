﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmEliminarCliente.aspx.cs" Inherits="TPC_Caero_Hoffman.frmEliminarCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <!--BOTON VOLVER ATRÁS-->
    <br />
    <div style="text-align: right; width:990px" >
       <asp:Button Text="Menú Principal" CssClass="btn btn-dark" ID="btnMenuPrincipal" OnClick="btnMenuPrincipal_Click" runat="server" />
    </div>

     <div>
    <h3>Eliminar Cliente</h3>
    </div>
      

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

        <div class="row" > 
            <asp:GridView ID="dgvClientes" CssClass="table table-hover table-info" runat="server"
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

            <br />

          <div class="d-grid gap-2 col-6 mx-auto" style="border: none; background-color: yellow ; border-radius:10px 10px">
              <asp:Label ID="lblConfirmacion" CssClass="center" runat="server" Font-Bold="true"/>                                   
              </div>

        </div>
        


</asp:Content>
