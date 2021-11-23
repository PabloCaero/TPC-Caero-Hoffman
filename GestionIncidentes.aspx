<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionIncidentes.aspx.cs" Inherits="TPC_Caero_Hoffman.GestionIncidentes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <!--GRID VIEW DE INCIDENTES Y AGREGAR INCIDENTES-->
    <div>
         <asp:GridView ID="dgvIncidentes" CssClass="table table-success table-striped" runat="server" AutoGenerateColumns="false">
                  <Columns>  
                  <asp:BoundField DataField="ID" HeaderText="Numero de Incidente"/>   
                  <asp:BoundField DataField="Cliente.Nombre" HeaderText="Nombre de Cliente"/>
                  <asp:BoundField DataField="Cliente.Apellido" HeaderText="Apellido del Cliente"/>
                  <asp:BoundField DataField="Empleado.Legajo" HeaderText="Legajo de Empleado Asignado"/>
                  <asp:BoundField DataField="Empleado.Nombre" HeaderText="Nombre de Empleado"/>
                  <asp:BoundField DataField="Empleado.Apellido" HeaderText="Apellido de Empleado"/>
                  <asp:BoundField DataField="Estado.Nombre_Estado" HeaderText="Estado"/>
                  <asp:BoundField DataField="Detalles" HeaderText="Detalles"/>

            </Columns>
         </asp:GridView>     
    </div>

</asp:Content>
