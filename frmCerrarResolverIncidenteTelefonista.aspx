﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmCerrarResolverIncidenteTelefonista.aspx.cs" Inherits="TPC_Caero_Hoffman.frmCerrarResolverIncidenteTelefonista" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!--BOTON VOLVER ATRÁS-->
    <br />
    <div style="text-align: right; width:990px" >
       <asp:Button Text="Menú Principal" CssClass="btn btn-dark" ID="btnMenuPrincipal" OnClick="btnMenuPrincipal_Click" runat="server" />
    </div>

     <div>
    <h3>Cerrar Incidente</h3>
    </div>

    <div class="container">
        <div class="row">
            <label for="inputEmail4" class="form-label">Buscar por ID</label>

            <div class="col-md">
             <div class="alinear">
             <div>
            <asp:TextBox type="text" runat="server" class="form-control" id="txtBuscarIncidentexID" />  
             </div>
              <asp:Button ID="btnBuscarIncidentexID"  CssClass="btn btn-primary mb-2" runat="server" OnClick="btnBuscarIncidentexID_Click" Text="Buscar" />                                
             </div>
             </div>

            <div class="col-md">
            <asp:Button ID="btnAbiertos"  CssClass="btn btn-info mb-2" runat="server" OnClick="btnAbiertos_Click" Text="Abiertos" />
              </div>
            
            <div class="col-md">
            <asp:Button ID="btnEnAnalisis"  CssClass="btn btn-info mb-2" runat="server" OnClick="btnEnAnalisis_Click" Text="En Análisis" />
              </div>

            <div class="col-md">
            <asp:Button ID="btnAsignados"  CssClass="btn btn-info mb-2" runat="server" OnClick="btnAsignados_Click" Text="Asignados" />
              </div>

            <div class="col-md">
            <asp:Button ID="btnReabiertos"  CssClass="btn btn-info mb-2" runat="server" OnClick="btnReabiertos_Click" Text="Reabiertos" />
              </div>

            <div class="col-md">
            <asp:Button ID="btnTodos"  CssClass="btn btn-info mb-2" runat="server" OnClick="btnTodos_Click" Text="Todos" />
              </div>

             </div>  
        </div>
        
     <br />

          <div class="d-grid gap-2 col-6 mx-auto" style="border: none; background-color: yellow ; border-radius:10px 10px">
            <asp:Label ID="lblIncidenteSeleccionado" CssClass="center" runat="server" Font-Bold="true"/>
              </div>

        <br />     

   

        <div class="row" > 
            <asp:GridView ID="dgvIncidentes" CssClass="table table-hover table-info" runat="server" AutoGenerateColumns="false"
          
                DataKeyNames="ID" OnSelectedIndexChanging="dgvIncidentes_SelectedIndexChanging"
                
                >
                <Columns>
                  
                  <asp:BoundField DataField="ID" HeaderText="Numero de Incidente"/>    
                  <asp:BoundField DataField="Cliente.Nombre" HeaderText="Nombre de Cliente"/>
                  <asp:BoundField DataField="Cliente.Apellido" HeaderText="Apellido de Cliente"/>
                  <asp:BoundField DataField="Empleado.Legajo" HeaderText="Legajo de Empelado Asignado"/>
                  <asp:BoundField DataField="Empleado.Nombre" HeaderText="Nombre de Empleado"/>
                  <asp:BoundField DataField="Empleado.Apellido" HeaderText="Apellido de Empleado"/>
                  <asp:BoundField DataField="Estado.Nombre_Estado" HeaderText="Estado"/>
                  <asp:BoundField DataField="Detalles" HeaderText="Detalles"/>
              
              <asp:CommandField ButtonType="Link" ShowSelectButton="true" ShowEditButton="false" ShowDeleteButton="false" />

                </Columns>

            </asp:GridView>
                    


              <!--IMPORTANTE PARA ASIGNAR ATRIBUTO-->
            <asp:Label ID="lblIDIncidente" runat="server" Visible ="false" />
           </div>
        

    
    <!--COMENTARIO FINAL DEL INCIDENTE-->

        <div class="container">
        <div class="row">
         <div class="col-sm-5 col-md-6">
         <asp:TextBox type="text" runat="server" PlaceHolder="COMENTARIO FINAL"   class="form-control" id="txtComentarioFinal" Height="80px" />
           </div>
        
         
        <div class="col-sm-5 offset-sm-2 col-md-6 offset-md-0">
         <asp:Button ID="btnCerrarIncidente" CssClass="btn btn-lg btn-danger" runat="server" OnClick="btnCerrarIncidente_Click" Text="Cerrar Incidente" />  
        <asp:Button ID="btnResolverIncidente" CssClass="btn btn-lg btn-success" runat="server" OnClick="btnResolverIncidente_Click" Text="Resolver Incidente" />            
            </div>

            </div>
          </div>

        <br />

          <div class="d-grid gap-2 col-6 mx-auto" style="border: none; background-color: yellow ; border-radius:10px 10px">
              <asp:Label ID="lblConfirmacion" CssClass="center" runat="server" Font-Bold="true"/>                                   
              </div>


</asp:Content>
