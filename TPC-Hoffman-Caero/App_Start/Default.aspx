<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPC_Hoffman_Caero._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="dgvClientes" runat="server"></asp:GridView>

    <div>
        <a href="/ClienteForm.aspx">Agregar</a>
    </div>

</asp:Content>
