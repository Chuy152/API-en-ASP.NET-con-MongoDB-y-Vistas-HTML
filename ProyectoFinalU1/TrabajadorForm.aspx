<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TrabajadorForm.aspx.cs" Inherits="ProyectoFinalU1.TrabajadorForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <script type="text/javascript">
        // Para el botón de guardar trabajador:
        function validarCamposTrabajador() {
            var nombre = document.getElementById('<%= txtNombre.ClientID %>').value;
            var puesto = document.getElementById('<%= txtPuesto.ClientID %>').value;

            // Validación para nombre y puesto
            if (!nombre || !puesto) {
                alert("Debe ingresar un nombre y un puesto.");
                return false;
            }

            // Validación para nombre (solo letras)
            var nombreRegex = /^[A-Za-z\s]+$/;
            if (!nombreRegex.test(nombre)) {
                alert("El nombre solo puede contener letras y espacios.");
                return false;
            }

            return true;
        }


            // Para el botón de agregar pago:
        function validarCamposPago() {
            var fecha = document.getElementById('<%= txtFechaPago.ClientID %>').value;
            var monto = document.getElementById('<%= txtMontoPago.ClientID %>').value;

            // Verifica si la fecha y monto no están vacíos
            if (!fecha || !monto) {
                alert("Debe ingresar fecha y monto.");
                return false;
            }

            // Verificar que el monto sea un número y sea mayor que 0
            if (isNaN(monto) || monto <= 0) {
                alert("El monto debe ser un número positivo.");
                return false;
            }

            return true;
        }

    </script>




    <div style="margin:10px">

<h2>Gestión de Trabajador</h2>
    

    <label class="form-label">Nombre:</label>
    <asp:TextBox CssClass="form-input" ID="txtNombre" runat="server" /><br/>
    
    <label class="form-label">Puesto:</label>
    <asp:TextBox CssClass="form-input" ID="txtPuesto" runat="server" /><br/>
    
    <br />
    <asp:Button CssClass="btn" ID="btnGuardar" runat="server" Text="Guardar Trabajador" OnClientClick="return validarCamposTrabajador();" OnClick="btnGuardar_Click" />

    <hr/>

    <h3>Historial de Pagos</h3>
    
    <asp:GridView ID="gridPagos" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:yyyy-MM-dd}" />
            <asp:BoundField DataField="Monto" HeaderText="Monto" DataFormatString="{0:C}" />
        </Columns>
    </asp:GridView>

    <h4>Agregar Pago</h4>

<asp:Label class="form-label" runat="server" Text="Fecha:" />
<asp:TextBox CssClass="form-input" ID="txtFechaPago" runat="server" TextMode="Date" /><br/>

<asp:Label class="form-label" runat="server" Text="Monto:" />
<asp:TextBox CssClass="form-input"  ID="txtMontoPago" runat="server" /><br/>
    <br />
<asp:Button CssClass="btn" ID="btnAgregarPago" runat="server" Text="Agregar Pago" OnClientClick="return validarCamposPago();" OnClick="btnAgregarPago_Click" />
<asp:Button CssClass="btn" ID="btnVolver" runat="server" Text="Volver a Lista" OnClick="btnVolver_Click" />

        </div>


</asp:Content>
