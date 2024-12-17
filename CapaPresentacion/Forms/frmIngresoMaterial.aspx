<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmIngresoMaterial.aspx.cs" Inherits="CapaPresentacion.Forms.frmIngresoMaterial" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/JQuery-1.4.2.min.js"></script>
    <script src="../Scripts/PasarConEnter.js"></script>
    <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/SoloNumeros.js"></script>
    <script type="text/javascript">
   $(document).ready(function() {
       //$('input[type="text"]').attr("disabled", "disabled");// to disable all textbox, color gray by defaul. But makes it empty to value of control
       $("#txtId_ItemCatalogo").attr("readonly", true);
       $("#txtDescrip_catalogo").attr("readonly", true);
       $("#txtIdGrupo_item").attr("readonly", true);
       $("#txtIdClase_item").attr("readonly", true);
       
       $("#txt_ruc_proveedor").attr("readonly", true);
       $("#txt_cod_persona").attr("readonly", true);
       $("#txt_RazonSocial").attr("readonly", true);
             
    return false; //to prevent from postback
    });
</script>
     <script type="text/javascript">
    
    function OpenCatalogoItems()
    {
        window.open("../Forms/frmListar_Catalogo.aspx", 'Lista Items', 'height=550,width=800,left=265,top=165,resizable=No,toolbar=No')
    }
    function OpenListProveedores()
    {
        window.open("../Forms/frmListar_Proveedores.aspx", 'Lista Proveedor', 'height=550,width=600,left=265,top=165,resizable=No,toolbar=No')
    }
    function CallConfirmBox()
    {
        var result = confirm("¿Desea realizar esta acción?");
        if (result) {
            return true;
        }
        else {
            return false;
        }
    }
</script>
      <table style="margin-top:-2px; margin-left:-2px; width:100%;" >
        <tr>
            <td style="width:99%;" ><img alt="" src="../Images/barra_menu.png"  style="margin-top:-2px;margin-left:-2px; width:100%; height:25px;" /> </td>
            <td style="width:1%;"> <asp:Button ID="btnCerrarPantalla" runat="server" Text=" " CssClass="btnCloseWindow" CausesValidation="false" OnClick="CerrarPantalla" /> </td>
        </tr>
    </table>
    <table style="margin:auto">
        <tr>
            <td style="text-align:right">Unidad de Negocio:</td>
            <td><asp:DropDownList ID="drpUnidadNegocio" runat="server" CssClass="dropDownList" Width="200px" ClientIDMode="Static"></asp:DropDownList></td>
        </tr>
    </table>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
        <ajaxToolkit:TabPanel runat="server" HeaderText="TabMovLogistico" ID="tbMovLogistico">
            <HeaderTemplate><asp:Label ID="Label4" runat="server" Text="Movimiento Logistico" Width="150px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
              <ContentTemplate>
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
             <td style="text-align:right">N°. de Lote:</td>
              <td><asp:TextBox ID="txtNumeroLote" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                  
              </td>
          </tr>
          <tr>
              <td style="text-align:right">Fecha Vencimiento:</td>
              <td><asp:TextBox ID="txtFechaVence" runat="server"  CssClass="textbox" Width="100px"></asp:TextBox></td>
          </tr>
          <tr>
              <td style="text-align:right">Cantidad:</td>
              <td><asp:TextBox ID="txtCantidad_entra" runat="server" CssClass="txtboxNumber" Text="0" Width="100px" onkeyPress="return soloNumeros(event)" ></asp:TextBox></td>
          </tr>
          <tr>
              <td>Precio de Entrada:</td>
              <td><asp:TextBox ID="txtPrecio_entra" runat="server" CssClass="txtboxNumber" Text="0" Width="100px"></asp:TextBox></td>
          </tr>
          <tr>
              <td style="text-align:right">Precio de Venta:</td>
              <td><asp:TextBox ID="txtPrecio_item" runat="server" Width="100px" CssClass="txtboxNumber" Text="0" ClientIDMode="Static"></asp:TextBox> </td>
          </tr>
          <tr>
              <td style="text-align:right">Almacen:</td>
              <td><asp:DropDownList ID="drpAlmacenes" runat="server" CssClass="dropDownList" Width="390px">
                  
                  </asp:DropDownList>
              </td>
          </tr>
          <tr>
              <td style="text-align:right">Documento:</td>
              <td><asp:DropDownList ID="drpDocsContables" runat="server" CssClass="dropDownList" Width="200px">
                  <asp:ListItem Value="01">Factura</asp:ListItem>
                  <asp:ListItem Value="09">Guia de Remision</asp:ListItem>
                  <asp:ListItem Value="03">Boleta</asp:ListItem>
                  <asp:ListItem Value="12">Ticket</asp:ListItem>
                  </asp:DropDownList>
                  Número:<asp:TextBox ID="txtNumero_documento" runat="server" CssClass="textbox" Width="115px" ></asp:TextBox>
              </td>
          </tr>
          <tr>
              <td style="text-align:right">Proveedor:</td>
              <td><asp:TextBox ID="txt_ruc_proveedor" runat="server" CssClass="textBoxDisabled" Width="80px" Text="10000000000"  ClientIDMode="Static"></asp:TextBox>
                            <asp:Button ID="btnBuscarCia" runat="server" Text=" "  CssClass="btnOpenPopup" ToolTip="Buscar Cia." OnClientClick="OpenListProveedores()" />
                            <asp:TextBox ID="txt_cod_persona" runat="server" CssClass="textBoxDisabled" Width="20px" Text="2"  ClientIDMode="Static"></asp:TextBox>
                            <asp:TextBox ID="txt_RazonSocial" runat="server" CssClass="textBoxDisabled" Width="355px" Text="PARTICULAR"  ClientIDMode="Static"></asp:TextBox>
            </td>
          </tr>
          <tr>
              <td style="text-align:right">Motivo:</td>
              <td><asp:TextBox ID="txtMotivo" runat="server" CssClass="textbox"  Width="500px" Text="Compra de Artículos"></asp:TextBox></td>
          </tr>           
           <tr>
                        <td style="text-align:right">Usuario:</td>
                        <td><asp:Label ID="lblUsuario" runat="server" CssClass="label"></asp:Label> </td>
        </tr>
          <tr>
              <td></td>
              <td><asp:Button ID="btnCargar" runat="server" Text="Cargar" CssClass="button" OnClick="CargarListaCompras" />
                   
              </td>
          </tr>
      </table>
                  <asp:GridView ID="grdListaCompras" runat="server" CssClass="gridViewCita" AutoGenerateColumns="false" ShowFooter="true">
         <Columns>
            <asp:BoundField DataField="Col1" HeaderText="N°." />
            <asp:BoundField DataField="Col2" HeaderText="Código" /> 
            <asp:BoundField DataField="Col3" HeaderText="Descripcion" />  
            <asp:BoundField DataField="Col4" HeaderText="Cantidad" /> 
            <asp:BoundField DataField="Col5" HeaderText="Precio Entrada" /> 
            <asp:BoundField DataField="Col6" HeaderText="Precio Venta" /> 
            <asp:BoundField DataField="Col7" HeaderText="Almacen" /> 
            <asp:BoundField DataField="Col8" HeaderText="Num. Doc." /> 
            <asp:BoundField DataField="Col9" HeaderText="Tipo Doc." />
            <asp:BoundField DataField="Col10" HeaderText="N° Lote" /> 
            <asp:BoundField DataField="Col11" HeaderText="Fecha Vencimiento" />
            <asp:BoundField DataField="Col12" HeaderText="Id Clase" />
            <asp:BoundField DataField="Col13" HeaderText="Id Grupo" />

            <asp:TemplateField HeaderText="">
             <ItemTemplate>
                 <asp:Button ID="btnBorrarFila" runat="server" CssClass="buttonIconDelete" ToolTip="Quitar artículo" OnClick="BorrarFila" /> 
             </ItemTemplate>
                 <FooterTemplate>
                         <asp:Button ID="btnGuardarCompras" runat="server"  Text="Guardar" CssClass="button" OnClientClick="return CallConfirmBox();"  OnClick="GuardarCompras"  />
                   </FooterTemplate>
         </asp:TemplateField>     
        </Columns> 
     </asp:GridView>
              </ContentTemplate>
        </ajaxToolkit:TabPanel>
         <ajaxToolkit:TabPanel runat="server" HeaderText="TabRepProductos" ID="tbRepProductos">
            <HeaderTemplate><asp:Label ID="Label1" runat="server" Text="Reporte de Productos" Width="150px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
              <ContentTemplate>
                  <table style="margin:auto">
                      <tr>
                          <td><asp:Button ID="btnReporteMovLogistico" runat="server" CssClass="button" Text="Listar Productos" OnClick="ListarReporteProductos" /></td>
                      </tr>
                  </table>
                  <asp:GridView ID="grdReporteProductosMovLogistico" runat="server" AutoGenerateColumns="false" CssClass="gridView">
                      <Columns>
                          <asp:BoundField DataField="cod_item" HeaderText="Códigp" />
                          <asp:BoundField DataField="descripcion_principal" HeaderText="Descripcion principal" />
                          <asp:BoundField DataField="descripcion_secundaria" HeaderText="Nombre Comercial" />
                          <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                          <asp:BoundField DataField="numero_lote" HeaderText="N° lote" />
                          <asp:BoundField DataField="fecha_mov" HeaderText="Fecha Ingreso" />
                          <asp:BoundField DataField="fecha_vence" HeaderText="fecha Vence" />
                          <asp:BoundField DataField="precio_entra" HeaderText="Precio" />
                          <asp:BoundField DataField="tipo_doc" HeaderText="Tipo Doc." />
                          <asp:BoundField DataField="numero_doc" HeaderText="N° Doc" />
                          <asp:BoundField DataField="razon_social" HeaderText="Proveedor" />
                      </Columns>
                      <EmptyDataTemplate>
                        <table style="width:100%">
                            <tr>
                                <td>No data Found</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate> 
                  </asp:GridView>
              </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
</asp:Content>
