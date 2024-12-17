<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmPedido.aspx.cs" Inherits="CapaPresentacion.Forms.frmPedido" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />

      <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
        <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanelPedido" ID="tbPanelPedido">
         <HeaderTemplate><asp:Label ID="Label1" runat="server" Text="Pedidos" Width="150px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
        <ContentTemplate>
            <fieldset class="fieldset">
         <legend class="legend">Pedido</legend>
         <table>
             <tr>
                 <td style="text-align:right">Centro de Costo:</td>
                 <td><asp:DropDownList ID="drpCentroCosto" runat="server" CssClass="dropDownList" Width="410px">
                     <asp:ListItem Value="01">Producción</asp:ListItem>
                     <asp:ListItem Value="02">Marketing</asp:ListItem>
                     <asp:ListItem Value="03">Administración</asp:ListItem>
                     </asp:DropDownList> </td>
 
             </tr>

             <tr>
                 <td style="text-align:right">Fecha Límite de Entrega:</td>
                 <td><asp:TextBox ID="txtfecha_entrega" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                     <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfecha_entrega" Format="dd/MM/yyyy" CssClass="calendar" />
                 </td>
             </tr>
             <tr>
                 <td style="text-align:right">Concepto:</td>
                 <td><asp:TextBox ID="txtConcepto" runat="server" CssClass="textbox" Width="400px" TextMode="MultiLine" Height="50px"></asp:TextBox></td>
             </tr>
             <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="button" />
                    <asp:Button ID="btnCerrarPedido" runat="server" Text="Cerrar" CssClass="button" OnClick="CerrarPedido" />
                </td>
            </tr>

         </table>
     </fieldset>
    <fieldset class="fieldset">
        <legend class="legend">Detalle del Pedido</legend>
    </fieldset>
        </ContentTemplate>
     </ajaxToolkit:TabPanel>
     <ajaxToolkit:TabPanel runat="server" HeaderText="TabEvaluacionPedidos" ID="tbPanelAprobarPedido">
         <HeaderTemplate><asp:Label ID="Label2" runat="server" Text="Aprobar Pedidos" Width="150px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
         <ContentTemplate>

         </ContentTemplate>
     </ajaxToolkit:TabPanel>

    </ajaxToolkit:TabContainer>
  
</asp:Content>
 