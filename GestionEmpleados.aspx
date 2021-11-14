<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GestionEmpleados.aspx.cs" Inherits="TPC_Caero_Hoffman.GestionEmpleados" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!--GRID VIEW DE EMPLEADOS-->

    <div>
        <asp:GridView  ID="dgvEmpleados" CssClass="table" runat="server"></asp:GridView>
    </div>


</asp:Content>
