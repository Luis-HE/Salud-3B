<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmTarifario.aspx.cs" Inherits="CapaPresentacion.Forms.frmTarifario" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
     
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   <table style="margin-top:-2px; margin-left:-2px; width:100%;" >
        <tr>
            <td style="width:99%;" ><img alt="" src="../Images/barra_menu.png"  style="margin-top:-2px;margin-left:-2px; width:100%; height:25px;" /> </td>
            <td style="width:1%;"> <asp:Button ID="btnCerrarPantalla" runat="server" Text=" " CssClass="btnCloseWindow" CausesValidation="false" OnClick="CerrarPantalla" /> </td>
        </tr>
    </table>
    
    <fieldset class="fieldset">
      <legend class="legend">Tarifario</legend>
<table style="margin:auto">
        <tr>
            <td style="text-align:right">Plan Asegurador:</td>
            <td> <asp:DropDownList ID="drpCiaAseguradora" runat="server" CssClass="dropDownList" Width="510px"></asp:DropDownList>
            </td>
        </tr>
        <tr>
        <td style="text-align:right">Grupo:</td>
        <td> <asp:DropDownList ID="drpGrupo" runat="server" CssClass="dropDownList" Width="510px"></asp:DropDownList> </td>
        </tr>
    <tr>
        <td></td>
        <td>
            <asp:RadioButton ID="rdServicio" runat="server" Text="Servicio" GroupName="grupoUno" Checked="true" />
            <asp:RadioButton ID="rdProducto" runat="server" Text="Producto" GroupName="grupoUno" />
        </td>
    </tr>
    <tr>
        <td></td>
        <td> <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="button" OnClick="btnBuscar_Click" />
            
        </td>
    </tr>
</table>
      <asp:GridView ID="grdTarifario" runat="server" CssClass="gridView" AutoGenerateColumns="false">
          <Columns>
               <asp:BoundField DataField="cod_item_catalogo" HeaderText="Código" />
               <asp:BoundField DataField="descripcion_principal" HeaderText="Descripcion" />
               <asp:BoundField DataField="precio_base" HeaderText="Precio Base" />
               <asp:TemplateField HeaderText="Precio Venta">
                   <ItemTemplate>
                       <asp:TextBox ID="txtPrecio_venta" runat="server" Text='<%# Eval("precio_venta") %>' CssClass="txtboxNumber" Width="100px"></asp:TextBox>
                   </ItemTemplate>
               </asp:TemplateField>
              <asp:TemplateField>
                  <ItemTemplate>
                      <asp:Button ID="btnActualizaPrecioItem" runat="server"  CssClass="buttonIconEdit" ToolTip="Modificar" OnClick="ModificarItem" />
                  </ItemTemplate>
              </asp:TemplateField>
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