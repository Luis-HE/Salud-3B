<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmReporteProduccion.aspx.cs" Inherits="CapaPresentacion.Forms.frmReporteProduccion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <table style="margin-top:-2px; margin-left:-2px; width:100%;" >
        <tr>
            <td style="width:99%;" ><img alt="" src="../Images/barra_menu.png"  style="margin-top:-2px;margin-left:-2px; width:100%; height:25px;" /> </td>
            <td style="width:1%;"> <asp:Button ID="btnCerrarPantalla" runat="server" Text=" " CssClass="btnCloseWindow" CausesValidation="false" OnClick="CerrarPantalla" /> </td>
        </tr>
    </table>
<asp:Image ID="imgGauge" runat="server" />
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="LoadXML" />
    <asp:GridView ID="grdTestxml" runat="server" AutoGenerateColumns="true">

    </asp:GridView>


</asp:Content>
