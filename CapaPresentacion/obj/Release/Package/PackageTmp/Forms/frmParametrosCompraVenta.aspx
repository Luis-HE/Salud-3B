<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmParametrosCompraVenta.aspx.cs" Inherits="CapaPresentacion.Forms.frmParametrosCompraVenta" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/SoloNumerosYpunto.js"></script>
    <table style="width:100%">
        <tr>
            <td>
                <fieldset class="fieldset">
        <legend class="legend">Conceptos</legend>
          <table>
            <tr>
                <td style="text-align:right">Código:</td>
                <td><asp:TextBox ID="txtcod_concepto" runat="server" CssClass="textbox" Width="100px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">Descripción:</td>
                <td><asp:TextBox ID="txtdesc_concepto" runat="server" CssClass="textbox" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnGuardarConcepto" runat="server" Text="Guardar" CssClass="button" /></td>
            </tr>
        </table>
    </fieldset>
            </td>
            <td>
               <fieldset class="fieldset">
        <legend class="legend">Documento Contable</legend>
        <table>
            <tr>
                <td style="text-align:right">Código:</td>
                <td><asp:TextBox ID="txtcod_docContable" runat="server" CssClass="textbox" Width="100px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">Descripción:</td>
                <td><asp:TextBox ID="txtdesc_docContable" runat="server" CssClass="textbox" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnGuardarDocContable" runat="server" Text="Guardar" CssClass="button" /></td>
            </tr>
        </table>
    </fieldset>
            </td>
        </tr>
        <tr>  
            <td>
                <fieldset class="fieldset">
        <legend class="legend">Tipo de Cambio</legend>
        <table>
            <tr>
                <td style="text-align:right">Código:</td>
                <td><asp:TextBox ID="txtcod_tcambio" runat="server" CssClass="textbox" Width="100px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">Precio de Compra:</td>
                <td><asp:TextBox ID="txtpreciocompra" runat="server" CssClass="txtboxNumber" Width="100px" Text="0" onkeyPress="return soloNumerosPuntoyComa(event)"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">Precio de Venta:</td>
                <td><asp:TextBox ID="txtprecioventa" runat="server" CssClass="txtboxNumber" Width="100px" Text="0" onkeyPress="return soloNumerosPuntoyComa(event)"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">Valor del IGV(%):</td>
                <td><asp:TextBox ID="txtvalorigv" runat="server" CssClass="txtboxNumber" Width="100px" Text="18" onkeyPress="return soloNumerosPuntoyComa(event)"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnGuardarTCambio" runat="server" Text="Guardar" CssClass="button" /></td>
            </tr>
        </table>
    </fieldset>
            </td>
            <td>
                <fieldset class="fieldset">
        <legend class="legend">Moneda</legend>
        <table>
            <tr>
                <td style="text-align:right">Código:</td>
                <td><asp:TextBox ID="txtcod_moneda" runat="server" CssClass="textbox" Width="100px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">Descripción:</td>
                <td><asp:TextBox ID="txtdesc_moneda" runat="server" CssClass="textbox" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">Símbolo:</td>
                <td><asp:TextBox ID="txtsimbolo_moneda" runat="server" CssClass="textbox" Width="100px"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnGuardarMoneda" runat="server" Text="Guardar" CssClass="button" /></td>
            </tr>
        </table>
    </fieldset>
            </td>
        </tr>
    </table>
</asp:Content>
