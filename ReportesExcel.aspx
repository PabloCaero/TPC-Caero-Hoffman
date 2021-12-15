<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReportesExcel.aspx.cs" Inherits="TPC_Caero_Hoffman.ReportesExcel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <!--BOTON VOLVER ATRÁS-->
    <br />
    <div style="text-align: right; width:990px" >
       <asp:Button Text="Menú Principal" CssClass="btn btn-dark" ID="btnMenuPrincipal" OnClick="btnMenuPrincipal_Click" runat="server" />
    </div>

    <div>
    <h3>Reportes de Incidentes por Estado</h3>
    </div>
    
     <label for="inputEmail4" class="form-label">Seleccione un estado: </label>
     <div class="container">
         <div class="col-md-6">
             <div class="alinear">
                 <div>
         <asp:DropDownList runat="server" ID="ddlEstados" CssClass="btn btn-info dropdown-toggle dropdown-toggle-split" AutoPostBack="true" >
         </asp:DropDownList>
                     </div>
        <asp:Button ID="btnBuscarIncidentes" CssClass="btn btn-primary mb-2" runat="server" OnClick="btnBuscarIncidentes_Click" Text="Buscar" />
         <asp:Button ID="btnExportar" CssClass="btn btn-success mb-2" runat="server" OnClick="btnExportar_Click" Text="Exportar" />  
                 </div>
          
               
                 </div>     
         </div>
         
             <br /> 
            
         
   
         <div>
            
        <div class="row" > 
            <asp:GridView ID="dgvIncidentes" CssClass="table table-hover table-info" runat="server" AutoGenerateColumns="False" >
                <Columns>
                   
                  <asp:BoundField DataField="ID" HeaderText="Numero de Incidente"/>   
                  <asp:BoundField DataField="Fecha_inicio" HeaderText="Fecha de Inicio" DataFormatString="{0:d}"  HtmlEncode=false />   
                  <asp:BoundField DataField="Cliente.Nombre" HeaderText="Nombre de Cliente"/>
                  <asp:BoundField DataField="Cliente.Apellido" HeaderText="Apellido del Cliente"/>
                  <asp:BoundField DataField="Empleado.Legajo" HeaderText="Legajo de Empleado Asignado"/>
                  <asp:BoundField DataField="Empleado.Nombre" HeaderText="Nombre de Empleado"/>
                  <asp:BoundField DataField="Empleado.Apellido" HeaderText="Apellido de Empleado"/>
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
