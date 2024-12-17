<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmParametrosAcceso.aspx.cs" Inherits="CapaPresentacion.Forms.frmParametrosAcceso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    
     <table style="margin-top:-2px; margin-left:-2px; width:100%;" >
        <tr>
            <td style="width:99%;" ><img alt="" src="../Images/barra_menu.png"  style="margin-top:-2px;margin-left:-2px; width:100%; height:25px;" /> </td>
            <td style="width:1%;"> <asp:Button ID="btnCerrarPantalla" runat="server" Text=" " CssClass="btnCloseWindow" CausesValidation="false" OnClick="CerrarPantalla" /> </td>
        </tr>
    </table>
    <fieldset class="fieldset">
        <legend class="legend">Cuentas de Usuario</legend>
        <table>
            <tr>
                <td style="text-align:right">DNI:</td>
                <td><asp:TextBox ID="txtdni_usuario" runat="server" CssClass="textbox" Width="100px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">Nombre de Usuario:</td>
                <td><asp:TextBox ID="txtnomb_usuario" runat="server" CssClass="textbox" Width="100px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">Contraseña:</td>
                <td><asp:TextBox ID="txtclave_usuario" runat="server" CssClass="textbox" Width="100px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">Nivel de Acceso:</td>
                <td><asp:DropDownList ID="DropDownList1" runat="server" Width="110px" CssClass="dropDownList">
                    <asp:ListItem Value="1">1</asp:ListItem>
                    <asp:ListItem Value="1">2</asp:ListItem>
                    <asp:ListItem Value="1">3</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align:right">Estado:</td>
                <td><asp:RadioButton ID="rdEstado_usuario" runat="server" /></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnGuardarUsuario" runat="server" Text="Guardar" CssClass="button" /></td>
            </tr>
        </table>
    </fieldset>

</asp:Content>
