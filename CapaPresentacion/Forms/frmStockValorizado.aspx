<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmStockValorizado.aspx.cs" Inherits="CapaPresentacion.Forms.frmStockValorizado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />

    <script src="../Scripts/JQuery-1.4.2.min.js"></script>
     <script src="../Scripts/FilterGridview.js"></script>
<script type="text/javascript">
    //======Function para filtrar filas en un gridview , usa el FilterGridview.js
    function SetupFilter(textboxID, gridID, columnName) {
        $('#' + textboxID).keyup(function () {
            var index;
            var text = $("#" + textboxID).val();

            $('#' + gridID + ' tbody tr').each(function () {
                $(this).children('th').each(function () {
                    if ($(this).html() == columnName)
                        index = $(this).index();
                });

                $(this).children('td').each(function () {
                    if ($(this).index() == index) {
                        var tdText = $(this).children(0).html() == null ? $(this).html() : $(this).children(0).html();

                        if (tdText.indexOf(text, 0) > -1) {
                            $(this).closest('tr').show();
                        } else {
                            $(this).closest('tr').hide();
                        }
                    };
                });
            });
        });
    };
    $(function () { SetupFilter("txtFiltrarDescripcion", "grdStock", "Descripción"); });
</script>
<script type="text/javascript">
    //======Function para filtrar filas en un gridview , usa el FilterGridview.js
    function SetupFilter(textboxID, gridID, columnName) {
        $('#' + textboxID).keyup(function () {
            var index;
            var text = $("#" + textboxID).val();

            $('#' + gridID + ' tbody tr').each(function () {
                $(this).children('th').each(function () {
                    if ($(this).html() == columnName)
                        index = $(this).index();
                });

                $(this).children('td').each(function () {
                    if ($(this).index() == index) {
                        var tdText = $(this).children(0).html() == null ? $(this).html() : $(this).children(0).html();

                        if (tdText.indexOf(text, 0) > -1) {
                            $(this).closest('tr').show();
                        } else {
                            $(this).closest('tr').hide();
                        }
                    };
                });
            });
        });
    };
    $(function () { SetupFilter("txtFiltarNombreComercial", "grdStock", "Nombre_comercial"); });
</script>
    <fieldset class="fieldset">
        <legend class="legend">Inventario Valorizado</legend>
        <table style="margin:auto">
            <tr>
                <td>Filtrar x Descripcion Principal</td>
                <td><asp:TextBox ID="txtFiltrarDescripcion" runat="server" CssClass="textbox" Width="200px" ClientIDMode="Static"></asp:TextBox></td>
                <td>Filtrar x Descripcion Secundaria</td>
                <td><asp:TextBox ID="txtFiltarNombreComercial" runat="server" CssClass="textbox" Width="200px" ClientIDMode="Static"></asp:TextBox></td>
                <td><asp:Button ID="btnCerrarStock" runat="server" Text="Cerrar" CssClass="button" OnClick="CerrarStock" /></td>
            </tr>
        </table>
        <asp:GridView ID="grdStock" runat="server" AutoGenerateColumns="false" CssClass="gridView" OnRowDataBound="OnRowColorGridCell" ClientIDMode="Static" >
            <Columns>
             <asp:BoundField DataField="codigo_item_catalogo" HeaderText="Cod. de Artículo" />
             <asp:BoundField DataField="descripcion_principal" HeaderText="Descripción" />
             <%--<asp:BoundField DataField="stock_minimo" HeaderText="Limite Mínimo" />--%>
             <asp:TemplateField HeaderText="Limite Mínimo">
             <ItemTemplate>
                 <asp:TextBox ID="txtStockMinimo" runat="server" Width="50px" Text='<%# Eval("stock_minimo")%>'></asp:TextBox>
             </ItemTemplate>
            </asp:TemplateField>
             <asp:BoundField DataField="cantidad" HeaderText="Existencia" />
            <%--<asp:TemplateField HeaderText="Existencia">
             <ItemTemplate>
                 <asp:TextBox ID="txtCantidadStock" runat="server" Width="50px" CssClass="txtboxNumber" Text='<%# Eval("cantidad")%>'></asp:TextBox>
             </ItemTemplate>
            </asp:TemplateField>--%>
             <asp:BoundField DataField="Unidad_medida" HeaderText="Unid. Medida" />
             <%--<asp:BoundField DataField="precio_actual" HeaderText="Precio Unitario" DataFormatString="{0:C}" />--%>
              <asp:TemplateField HeaderText="Precio Unitario">
             <ItemTemplate>
                 <asp:TextBox ID="txtPrecioActual" runat="server" Width="50px" CssClass="txtboxNumber" Text='<%# Eval("precio_actual")%>'></asp:TextBox>
             </ItemTemplate>
            </asp:TemplateField>
             <asp:BoundField DataField="costo_inventario" HeaderText="Costo Inventario" DataFormatString="{0:C}" />
             <asp:BoundField DataField="descripcion_secundaria" HeaderText="Nombre_comercial" />
             <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnEditar" runat="server" CssClass="buttonIconEdit" OnClick="ModificarItem" ToolTip="Modificar" />
                </ItemTemplate>
            </asp:TemplateField>
            
            </Columns>
        </asp:GridView>


    </fieldset>
</asp:Content>
 
