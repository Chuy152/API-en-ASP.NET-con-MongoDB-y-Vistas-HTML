<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Trabajadores.aspx.cs" Inherits="ProyectoFinalU1.Trabajadores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div style="margin: 10px">
        
    
    
    <script type="text/javascript">
        function confirmarEliminacion(id) {
            return confirm("¿Estás seguro de que deseas eliminar este trabajador?");
        }
    </script>
        

<h2>Gestion de Trabajadores</h2>

<asp:GridView ID="gridTrabajadores" runat="server" AutoGenerateColumns="false"
    OnRowCommand="gridTrabajadores_RowCommand" Width="272px">
    <Columns>
        <asp:TemplateField HeaderText="ID" Visible="false">
            <ItemTemplate>
                <asp:Label ID = "lblId" runat = "server" Text = '<%# Eval("Id")%>'></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="nombre" HeaderText="Nombre" />
        <asp:BoundField DataField="puesto" HeaderText="Puesto" />
        <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn-Editar" Text="Editar" CommandName="Editar" />


        <asp:TemplateField>
    <ItemTemplate>
        <asp:Button runat="server" CssClass="btn-Eliminar" Text="Eliminar" 
            OnClientClick='<%# "return confirmarEliminacion(\"" + Eval("Id") + "\");" %>' 
            CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' />
    </ItemTemplate>
</asp:TemplateField>




    </Columns>
    </asp:GridView>

<asp:Button CssClass="btn" ID="btnAgregar" runat="server" Text="Agregar Trabajador" OnClick="btnAgregar_Click" />


    </div>
</asp:Content>