<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmMenu.aspx.cs" Inherits="CapaPresentacion.frmMenu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width:100%;">
        <tr>
            <td style="text-align:right;color:#1F497D">Usuario(a): &nbsp;<asp:Label ID="lblUserName" runat="server" Text=""></asp:Label></td>
        </tr>
        <tr>
            <td style="text-align:right;"><asp:LinkButton ID="lnkLogOut" runat="server" OnClick="lnkLogOut_Click" ForeColor="Blue" Font-Bold="true" >Cerrar Sesión</asp:LinkButton></td>
        </tr>
    </table>
  
</asp:Content>