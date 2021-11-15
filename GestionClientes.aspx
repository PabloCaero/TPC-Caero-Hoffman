<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionClientes.aspx.cs" Inherits="TPC_Caero_Hoffman.GestionClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!--GRID VIEW DE CLIENTES Y BOTON A FORM AGREGAR CLIENTE-->
    <div>
    <asp:GridView ID="dgvClientes" CssClass="table" runat="server"></asp:GridView>
    </div>
  
</asp:Content>
