<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmKardex.aspx.cs" Inherits="CapaPresentacion.Forms.frmKardex" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
    $(function () { SetupFilter("txt_Nombre_articulo", "grdCatalogoProductos", "Descripcion"); });
</script>
<script type="text/javascript">
     function OpenCatalogoItems()
    {
        window.open("../Forms/frmListar_Catalogo.aspx", 'Lista Items', 'height=550,width=800,left=265,top=165,resizable=No,toolbar=No')
    }
</script>

     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table style="margin-top:-2px; margin-left:-2px; width:100%;" >
        <tr>
            <td style="width:99%;" ><img alt="" src="../Images/barra_menu.png"  style="margin-top:-2px;margin-left:-2px; width:100%; height:25px;" /> </td>
            <td style="width:1%;"> <asp:Button ID="btnCerrarPantalla" runat="server" Text=" " CssClass="btnCloseWindow" CausesValidation="false" OnClick="CerrarPantalla" /> </td>
        </tr>
    </table>
     
      <fieldset class="fieldset">
        <legend class="legend">Inventario</legend>
        <table>
            <tr>
                <td style="text-align:right">Artículo:</td>
                 <td><asp:TextBox ID="txtId_ItemCatalogo" runat="server" Width="100px" CssClass="textBoxDisabled" ClientIDMode="Static" ></asp:TextBox>
                   <asp:Button ID="btnOpenCatalogo" runat="server" Text=" " CssClass="btnOpenPopup" OnClientClick="OpenCatalogoItems()" ToolTip="Buscar Items"/>
                   <asp:TextBox ID="txtIdGrupo_item" runat="server" Width="20px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                   <asp:TextBox ID="txtIdClase_item" runat="server" Width="20px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                   <asp:TextBox ID="txtDescrip_catalogo" runat="server" Width="300px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>   
               </td>
            </tr>
            
            <tr>
                <td style="text-align:right">Precio:</td>
                <td> <asp:TextBox ID="txtPrecio_item" runat="server" Width="100px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox> </td>
            </tr>
           
            <tr>
                <td></td>
                <td><asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="button" OnClick="ListarMovimiento" />
                     
                </td>
            </tr>
        </table>

        <asp:GridView ID="grdMovimientosCatalogo" runat="server" AutoGenerateColumns="false" CssClass="gridView" OnRowCreated="ConsolidarReporteMovimiento" OnRowDataBound="CalcularExistencias" ShowFooter="true"  FooterStyle-Font-Bold="true">
            <Columns>
             <asp:BoundField DataField="fecha_mov" HeaderText="Fecha" />
             <asp:BoundField DataField="descripcion" HeaderText="Detalle del Movimiento" />

             <asp:BoundField DataField="cant_entra" HeaderText="Cantidad" />
             <asp:BoundField DataField="precio_entra" HeaderText="Precio Unit." />
             <asp:BoundField DataField="total_entra" HeaderText="Costo Entrada" />

             <asp:BoundField DataField="cant_sale" HeaderText="Cantidad" />
             <asp:BoundField DataField="precio_sale" HeaderText="Precio Unit." />
            <asp:BoundField DataField="total_sale" HeaderText="Costo Salida" FooterText="Resumen Existencias:" />
             <asp:TemplateField HeaderText="Cantidad">
                <ItemTemplate>
                  <asp:Label ID="lblCant_existe" runat="server" Text='<%# Eval("cant_existe") %>' />
                 </ItemTemplate> 
                 <FooterTemplate>
                     <asp:Label ID="lblSumCantidad_existe" runat="server" ></asp:Label>
                 </FooterTemplate>
             </asp:TemplateField>
 
             <%--<asp:BoundField DataField="cant_existe" HeaderText="Cantidad" />--%>
             <asp:BoundField DataField="precio_existe" HeaderText="Precio Unit." />
             <asp:BoundField DataField="total_existe" HeaderText="Costo Existencia" />
            
            </Columns>

            <EmptyDataTemplate>
                        <table style="width:100%">
                            <tr>
                                <td>No data Found</td>
                            </tr>
                        </table>
           </EmptyDataTemplate> 
        </asp:GridView>
        <asp:HiddenField ID="hdCant_existe" runat="server" Value="0" />
        <asp:HiddenField ID="hdPrecio_existe" runat="server" Value="0"/>
        <asp:HiddenField ID="hdTotal_existe" runat="server" Value="0" />
        <asp:Button ID="btnOpemModal" runat="server" Style="display:none"/>
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnOpemModal" BackgroundCssClass="modalBackground" PopupControlID="Panel1" CancelControlID="btnCancelar">

        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
            <ContentTemplate>            
            <div class="modalPopupHeader">Artículos</div>
            <table>
                <tr>
                    <td>Nombre del Articulo:</td>
                    <td><asp:TextBox ID="txt_Nombre_articulo" runat="server" Width="300px" CssClass="textbox" ClientIDMode="Static"></asp:TextBox>
                        <asp:Button ID="btnListarArticulo" runat="server" Text="Buscar" CssClass="button" OnClick="ListarArticulo" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="button" OnClick="CerrarPopUP" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="grdCatalogoProductos" runat="server" AutoGenerateColumns="false" CssClass="gridView" ClientIDMode="Static">
                            <Columns>
                                <asp:TemplateField HeaderText="">
                                <ItemTemplate>
                                  <asp:LinkButton ID="imgBotonSelect" runat="server" Text="Select" OnClick="Seleccionar" />
                                 </ItemTemplate>
                                </asp:TemplateField>  
                                <asp:BoundField DataField="cod_item_catalogo" HeaderText="Codigo" />
                                <asp:BoundField DataField="descripcion_principal" HeaderText="Descripcion" />
                                <asp:BoundField DataField="precio" HeaderText="Precio" />                               
                            </Columns>
                            <EmptyDataTemplate>
                                <table style="width:100%">
                                    <tr>
                                        <td>No data Found</td>
                                    </tr>
                                </table>
                           </EmptyDataTemplate> 
                        </asp:GridView>

                    </td>
                </tr>
             </table>
            </ContentTemplate>
          </asp:UpdatePanel>
        </asp:Panel>
    </fieldset>
</asp:Content>
 