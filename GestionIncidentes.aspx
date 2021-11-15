<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionIncidentes.aspx.cs" Inherits="TPC_Caero_Hoffman.GestionIncidentes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <!--GRID VIEW DE INCIDENTES Y AGREGAR INCIDENTES-->
    <div>
         <asp:GridView ID="dgvIncidentes" CssClass="table" runat="server"></asp:GridView>     
    </div>

</asp:Content>
