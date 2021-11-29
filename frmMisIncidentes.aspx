﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmMisIncidentes.aspx.cs" Inherits="TPC_Caero_Hoffman.frmMisIncidentes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <!--BOTON VOLVER ATRÁS-->
    <br />
    <div style="text-align: right; width:990px" >
       <asp:Button Text="Menú Principal" CssClass="btn btn-dark" ID="btnMenuPrincipal" OnClick="btnMenuPrincipal_Click" runat="server" />
    </div>

     <div>
    <h3>Mis Incidentes - <asp:Label ID="lblDatosEmpleado" runat="server" /></h3>
    </div>
    
     <div class="col-9">
    <label for="inputEmail4" class="form-label">Seleccione un estado: </label>
         <div class="col-md-6">
         <asp:DropDownList runat="server" ID="ddlEstados" CssClass="btn btn-outline-dark dropdown-toggle" AutoPostBack="true" >
         </asp:DropDownList>
             </div>     
        <asp:Button ID="btnBuscarIncidentes" runat="server" OnClick="btnBuscarIncidentes_Click" Text="Buscar" />
         
         <div>
            
        <div class="row" > 
            <asp:GridView ID="dgvIncidentes" CssClass="table table-success table-striped" runat="server" AutoGenerateColumns="False" >
                <Columns>
                   
                  <asp:BoundField DataField="ID" HeaderText="Numero de Incidente"/>   
                  <asp:BoundField DataField="Fecha_inicio" HeaderText="Fecha de Inicio" DataFormatString="{0:d}"  HtmlEncode=false />   
                  <asp:BoundField DataField="Cliente.Nombre" HeaderText="Nombre de Cliente"/>
                  <asp:BoundField DataField="Cliente.Apellido" HeaderText="Apellido del Cliente"/>
                  <asp:BoundField DataField="Estado.Nombre_Estado" HeaderText="Estado"/>
                  <asp:BoundField DataField="Detalles" HeaderText="Detalles"/>      
                  <asp:BoundField DataField="Fecha_cierre" HeaderText="Fecha de Cierre" DataFormatString="{0:d}"  HtmlEncode=false  NullDisplayText="--" />               
                  <asp:BoundField DataField="ComentarioFinal" HeaderText="Comentario Final"  NullDisplayText="--"/>   
                    
                </Columns>

            </asp:GridView>
          
         
        
          </div>     
        </div>
         </div>

      

</asp:Content>
