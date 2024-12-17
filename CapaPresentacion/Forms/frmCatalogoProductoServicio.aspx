<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmCatalogoProductoServicio.aspx.cs" Inherits="CapaPresentacion.Forms.frmCatalogoProductoServicio" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <fieldset class="fieldset">
        <legend class="legend">Registro de Productos y Servicios</legend>
        <table style="margin:auto">
            <tr>
                <td style="text-align:right">Tipo:</td>
                <td>
                    <asp:RadioButton ID="rdProducto" runat="server" Text="Producto" CssClass="radioButton" GroupName="gnameCatalogo" Checked="true" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RadioButton ID="rdServicio" runat="server" Text="Servicio" CssClass="radioButton" GroupName="gnameCatalogo"/>
                </td>
            </tr>
            <tr>
                <td style="text-align:right">Descripción Principal:</td>
                <td><asp:TextBox ID="txtDescripcion" runat="server" CssClass="textbox" Width="400px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">Descripción Secundaria:</td>
                <td><asp:TextBox ID="txtDescripcion_Cientifica" runat="server" CssClass="textbox" Width="400px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">Categoria:</td>
                <td><asp:DropDownList ID="drpCategoria" runat="server" CssClass="dropDownList" Width="200px">
                    
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align:right">Unidad de Medida:</td>
                <td><asp:DropDownList ID="drpUnidadMedida" runat="server" CssClass="dropDownList" Width="200px">
                    
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align:right">Laborarorio:</td>
                <td><asp:DropDownList ID="drpLaboratorios" runat="server" CssClass="dropDownList" Width="200px">

                    </asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td style="text-align:right">Color:</td>
                <td><asp:DropDownList ID="drpColor" runat="server" CssClass="dropDownList" Width="200px">
                    <asp:ListItem Value="1">No aplica</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align:right">Marca:</td>
                <td><asp:DropDownList ID="drpMarca" runat="server" CssClass="dropDownList" Width="200px">
                    <asp:ListItem Value="1">No aplica</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td style="text-align:right">Modelo:</td>
                <td><asp:DropDownList ID="drpModelo" runat="server" CssClass="dropDownList" Width="200px">
                    <asp:ListItem Value="1">No aplica</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            
            <tr>
                <td style="text-align:right">Motivo de uso:</td>
                <td><asp:DropDownList ID="drpMotivoUso" runat="server" CssClass="dropDownList" Width="200px">
                    <asp:ListItem Value="1">Comprar</asp:ListItem>
                    <asp:ListItem Value="1">Vender</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            
            <tr>
                <td style="text-align:right">Peso:</td>
                <td><asp:TextBox ID="txtPeso" runat="server" CssClass="txtboxNumber" Width="100px" Text="0" ></asp:TextBox></td>
            </tr>
 
            <tr>
                <td></td>
                <td><asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="button" OnClientClick="javascript:return confirm('Desea continuar?');" OnClick="btnGuardar_Click" />
                    <asp:Label ID="lblMsj" runat="server" Text="" ForeColor="Green" Font-Bold="true"></asp:Label>
                    <asp:Button ID="btnListarProductos" runat="server" Text="Listar Productos" CssClass="button"  OnClick="btnListarProductos_Click" />
                    <asp:Button ID="btnCerrarPantalla" runat="server" CssClass="button" Text="Cerrar" OnClick="btnCerrarPantalla_Click" />
                </td>
            </tr>
        </table>
    </fieldset>
    <asp:GridView ID="grdCatalogoItems" runat="server" AutoGenerateColumns="false" CssClass="gridView" OnRowDataBound="GridViewRowdDtaBound" >
        <Columns>
         <asp:BoundField DataField="cod_item_catalogo" HeaderText="Código" />
         <asp:TemplateField HeaderText="Descripción Principal">
             <ItemTemplate>
                 <asp:TextBox ID="txtDescripcionItem" runat="server" Width="400px" Text='<%# Eval("descripcion_principal")%>'></asp:TextBox>
             </ItemTemplate>
         </asp:TemplateField>
        <asp:TemplateField HeaderText="Descripción Secundaria">
             <ItemTemplate>
                 <asp:TextBox ID="txtDescripcionCientifica" runat="server" Width="400px" Text='<%# Eval("descripcion_secundaria")%>'></asp:TextBox>
             </ItemTemplate>
         </asp:TemplateField>
        <asp:TemplateField HeaderText="Unid. Medida">
            <ItemTemplate>
                <asp:Label ID="lblCodUnidMed" runat="server" Text='<%# Eval("cod_uni_med") %>' Visible = "false" />
                <asp:DropDownList ID="drpUnidadMedida" runat="server" > </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btnEditar" runat="server" CssClass="buttonIconEdit" OnClick="ModificarItem" ToolTip="Modificar" />
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btnEliminar" runat="server" CssClass="buttonIconDelete" OnClick="EliminarItem" ToolTip="Eliminar" OnClientClick="javascript:return confirm('Desea eliminar este artículo?');" />
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
 
</asp:Content>
 