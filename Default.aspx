<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPC_Caero_Hoffman._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  
     <!--GRID VIEW DE CLIENTES Y BOTON A FORM AGREGAR CLIENTE-->
    <div>
     <asp:GridView ID="dgvClientes" CssClass="table" runat="server"></asp:GridView>
            <div>
    <a href="/ClienteForm">Agregar Cliente</a>
            </div>
    </div>
      <!--GRID VIEW DE INCIDENTES Y AGREGAR INCIDENTES-->
    <div>
         <asp:GridView ID="dgvIncidentes" CssClass="table" runat="server"></asp:GridView>
         <div>
            <a href="/IncidenteForm">Agregar Incidente</a>
        </div>
    </div>

</asp:Content>
