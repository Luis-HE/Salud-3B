<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmParametrosArtProd.aspx.cs" Inherits="CapaPresentacion.Forms.frmParametrosArtProd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />

    <table style="width:100%">
        <tr>
            <td>
<fieldset class="fieldset">
        <legend class="legend">Categoria o Linea del Artículo</legend>
        <table>
            <tr>
                <td style="text-align:right">Código:</td>
                <td><asp:TextBox ID="txtcod_categoria" runat="server" CssClass="textbox" Width="100px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">Descripción:</td>
                <td><asp:TextBox ID="txtdesc_categoria" runat="server" CssClass="textbox" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnGuardarCategoria" runat="server" Text="Guardar" CssClass="button" /></td>
            </tr>
        </table>
    </fieldset>
            </td>
            <td>
<fieldset class="fieldset">
        <legend class="legend">Unidad de Medida</legend>
        <table>
           <%-- <tr>
                <td style="text-align:right">Código:</td>
                <td><asp:TextBox ID="txtcod_unidadMed" runat="server" CssClass="textbox" Width="100px"></asp:TextBox></td>
            </tr>--%>
            <tr>
                <td style="text-align:right">Descripción:</td>
                <td><asp:TextBox ID="txtdesc_unidadMed" runat="server" CssClass="textbox" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">Siglas:</td>
                <td><asp:TextBox ID="txt_siglas" runat="server" CssClass="textbox" Width="100px"></asp:TextBox></td>
            </tr>            
            <tr>
                <td></td>
                <td><asp:Button ID="btnGuardarUnidMed" runat="server" Text="Guardar" CssClass="button" OnClick="GuardarUnidadMedida" />
                    <asp:Label ID="lblmesjUnMed" runat="server" Text="" ForeColor="Green"></asp:Label>
                </td>
            </tr>
        </table>
    </fieldset>
            </td>
        </tr>
        <tr>
            <td>
   <fieldset class="fieldset">
        <legend class="legend">Laboratorio</legend>
        <table>
           <%-- <tr>
                <td style="text-align:right">Código:</td>
                <td><asp:TextBox ID="txtcod_marca" runat="server" CssClass="textbox" Width="100px"></asp:TextBox></td>
            </tr>--%>
            <%--<tr>
                <td style="text-align:right">Nombre:</td>
                <td><asp:TextBox ID="txtNombreLaboratorio" runat="server" CssClass="textbox" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnGuardarLaboratorio" runat="server" Text="Guardar" CssClass="button" OnClick="GuardarLaboratorio" />
                    <asp:Label ID="lblmsjLab" runat="server" Text="" ForeColor="Green"></asp:Label>
                </td>
            </tr>--%>
        </table>
    </fieldset>
            </td>
            <td>
    <fieldset class="fieldset">
        <legend class="legend">Modelo</legend>
        <table>
            <tr>
                <td style="text-align:right">Código:</td>
                <td><asp:TextBox ID="txtcod_modelo" runat="server" CssClass="textbox" Width="100px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">Descripción:</td>
                <td><asp:TextBox ID="txtdesc_modelo" runat="server" CssClass="textbox" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnGuardarModelo" runat="server" Text="Guardar" CssClass="button" /></td>
            </tr>
        </table>
    </fieldset>
            </td>
        </tr>
        <tr>
            <td>
 <fieldset class="fieldset">
        <legend class="legend">Sucursal</legend>
        <table>
            <tr>
                <td style="text-align:right">Código:</td>
                <td><asp:TextBox ID="txtcod_sucursal" runat="server" CssClass="textbox" Width="100px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">Descripción:</td>
                <td><asp:TextBox ID="txtdesc_sucursal" runat="server" CssClass="textbox" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">Dirección:</td>
                <td><asp:TextBox ID="txtdir_sucursal" runat="server" CssClass="textbox" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">Teléfono:</td>
                <td><asp:TextBox ID="txttelef_sucursal" runat="server" CssClass="textbox" Width="100px"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnGuardarSucursal" runat="server" Text="Guardar" CssClass="button" /></td>
            </tr>
        </table>
    </fieldset>
            </td>
            <td>
<fieldset class="fieldset">
        <legend class="legend">Almacen</legend>
        <table>
            <tr>
                <td style="text-align:right">Código:</td>
                <td><asp:TextBox ID="txtcod_almacen" runat="server" CssClass="textbox" Width="100px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">Sucursal:</td>
                <td><asp:DropDownList ID="drpSucursales" runat="server" Width="310px" CssClass="dropDownList">

                    </asp:DropDownList>
                    <asp:Button ID="btnRefresh" runat="server" Text=":::" Width="20px" />
                </td>
            </tr>
            <tr>
                <td style="text-align:right">Descripción:</td>
                <td><asp:TextBox ID="txtdesc_almacen" runat="server" CssClass="textbox" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">Cod. de Facturación:</td>
                <td><asp:TextBox ID="txtcodfact_almacen" runat="server" CssClass="textbox" Width="100px"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnGuardarAlmacen" runat="server" Text="Guardar" CssClass="button" /></td>
            </tr>
        </table>
    </fieldset>
            </td>
        </tr> 
    </table>
</asp:Content>


