<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmLiquidacionAtencionPaciente.aspx.cs" Inherits="CapaPresentacion.Forms.frmLiquidacionAtencionPaciente" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
 <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

 <fieldset class="fieldset">
     <legend class="legend">Liquidación Detallada de Consumo</legend>
     <table style="margin:auto">
            <tr>
            <td style="text-align:right">N° de DNI:</td>
             <td><asp:TextBox ID="txtDni_cliente" runat="server"  Width="100px" CssClass="textbox"></asp:TextBox> </td>
           </tr>
         <tr>
             <td style="text-align:right">Mes:</td>
             <td><asp:DropDownList ID="drpMes" runat="server" Width="110px" CssClass="dropDownList">
                 <asp:ListItem Value="1">Enero</asp:ListItem>
                 <asp:ListItem Value="2">Febrero</asp:ListItem>
                 <asp:ListItem Value="3">Marzo</asp:ListItem>
                 <asp:ListItem Value="4">Abril</asp:ListItem>
                 <asp:ListItem Value="5">Mayo</asp:ListItem>
                 <asp:ListItem Value="6">Junio</asp:ListItem>
                 <asp:ListItem Value="7">Julio</asp:ListItem>
                 <asp:ListItem Value="8">Agosto</asp:ListItem>
                 <asp:ListItem Value="9">Setiembre</asp:ListItem>
                 <asp:ListItem Value="10">Octubre</asp:ListItem>
                 <asp:ListItem Value="11">Noviembre</asp:ListItem>
                 <asp:ListItem Value="12">Diciembre</asp:ListItem>
                 </asp:DropDownList>
                 <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="button" OnClick="btnBuscar_Click" />
                    <asp:Button ID="btnExportExcel" runat="server" Text="Exp. a Excel" CssClass="button" OnClick="btnExportExcel_Click" />
                    <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" CssClass="button" OnClick="btnCerrar_Click"  />
             </td>
         </tr>       
   </table>
 <asp:GridView ID="grdLiquidacionAtencion" runat="server" AutoGenerateColumns="false" CssClass="gridView" PageSize="20" AllowPaging="true" OnPageIndexChanging="grdLiquidacionAtencion_PageIndexChanging" >
     <Columns>
         <asp:BoundField DataField="numero_documento" HeaderText="N°. Documento" />
         <asp:BoundField DataField="tipo_documento" HeaderText="Tipo" />
         <asp:BoundField DataField="fecha_emision" HeaderText="Fecha de pago" />
         <asp:BoundField DataField="codigo_item_catalogo" HeaderText="Código item" />
         <asp:BoundField DataField="descrip_item" HeaderText="Descripción" />
         <asp:BoundField DataField="valor_venta" HeaderText="Valor Venta" />
         <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
         <asp:BoundField DataField="tipo_item_catlogo" HeaderText="Tipo item" />
         <asp:BoundField DataField="estado_pago" HeaderText="Estado" />         
     </Columns>
     <EmptyDataTemplate>
                        <table style="width:100%">
                            <tr>
                                <td>No data Found</td>
                            </tr>
                        </table>
                  </EmptyDataTemplate> 
 </asp:GridView>
 </fieldset>
 </asp:Content>
 