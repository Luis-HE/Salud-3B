<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master"  CodeBehind="frmLogin.aspx.cs" Inherits="CapaPresentacion.frmLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="Styles/StyleLogin.css" rel="stylesheet" type="text/css" />
 
       <div class="BackgroundLogin">
           <br />
        <table>
            <tr>
                <td colspan="2" style="text-align:center;"><h2>Iniciar Sesión</h2></td>
            </tr>
            <tr>
                <td style="text-align:right">Nombre de Usuario:</td>
                <td><asp:TextBox ID="txtnomUsuario" runat="server" Width="150px" CssClass="textbox"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">Contraseña:</td>
                <td><asp:TextBox ID="txtClave" runat="server" TextMode="Password" Width="150px" CssClass="textbox"></asp:TextBox></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="button" Width="160px" OnClick="btnIngresar_Click" /></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Label ID="lblmessage" runat="server" Text="" ForeColor="Red" Font-Bold="true"></asp:Label></td>
            </tr>
        </table>
      </div> 
</asp:Content>
 
