<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmBuscarClientePorDNI.aspx.cs" Inherits="TPC_Caero_Hoffman.frmBuscarClientePorDNI" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <!--BOTON VOLVER ATRÁS-->
    <br />
    <div style="text-align: right; width:990px" >
     <button type="button" onclick="history.go(-1); return false;" class="btn btn-dark">Menú Principal</button>    

    </div>

    <div>
    <h2>Buscar Cliente</h2>
    </div>
    <div>
     <div class="col-9">
    <label for="inputEmail4" class="form-label">Ingrese DNI</label>
        <asp:TextBox type="text" runat="server"  class="form-control" id="txtBuscarClientexDNI" />
        <asp:Button ID="btnBuscarClientexDNI" runat="server" OnClick="btnBuscarClientexDNI_Click" Text="Buscar" />  
   
        <div class="row" > 
            <asp:GridView ID="dgvClientes" CssClass="table table-success table-striped" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="DNI" HeaderText="DNI"/>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre"/>
                    <asp:BoundField DataField="Apellido" HeaderText="Apellido"/>
                    <asp:BoundField DataField="Direccion.Calle" HeaderText="Calle"/>
                    <asp:BoundField DataField="Direccion.Numero" HeaderText="Altura"/>
                    <asp:BoundField DataField="Direccion.Localidad" HeaderText="Localidad"/>
                    <asp:BoundField DataField="Direccion.Provincia" HeaderText="Provincia"/>
                </Columns>

            </asp:GridView>
        </div>
        </div>
       </div>

</asp:Content>
