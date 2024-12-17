<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmCaja.aspx.cs" Inherits="CapaPresentacion.Forms.frmCaja" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
   <script type="text/javascript" src="../Scripts/jquery.min.js"> </script>
   <script type="text/javascript" src="../Scripts/SoloNumeros.js"></script>
  <script type="text/javascript" src="../Scripts/TexboxEnterNextControl.js"></script>
   
  
  <script type="text/javascript">
   $(document).ready(function() {
       //$('input[type="text"]').attr("disabled", "disabled");// to disable all textbox, color gray by defaul. But makes it empty to value of control
       $("#txtCliente_boleta").attr("readonly", true);

       $("#txtRuc_factura").attr("readonly", true);
       $("#txtCliente_factura").attr("readonly", true);
       $("#txtDir_factura").attr("readonly", true);
             
    return false; //to prevent from postback
    });
</script>
<script type="text/javascript">
    function OpenListPacientes()
    {
        window.open("../Forms/frmListar_Pacientes.aspx", 'Lista Pacientes', 'height=640,width=600,left=265,top=0,resizable=No,toolbar=No')
    }
    function OpenCatalogoItems()
    {
        window.open("../Forms/frmListar_Catalogo.aspx", 'Lista Items', 'height=550,width=800,left=265,top=165,resizable=No,toolbar=No')
    }
    function OpenListClienteEmpresas()
    {
        window.open("../Forms/frmListar_ClienteEmpresa.aspx", 'Lista Empresas', 'height=550,width=600,left=265,top=165,resizable=No,toolbar=No')
    }
    function OpenFormasDePago()
    {
        window.open("../Forms/frmFormasPago.aspx", 'Formas de Pago', 'height=550,width=600,left=265,top=165,resizable=No,toolbar=No')
    }
    
</script>

    <script type="text/javascript">
        function PrintPanelCierrecaja()
        {
            var fechaInicio = document.getElementById("<%=txtFechaIni.ClientID %>");
            var fechaFin = document.getElementById("<%=txtFechaFin.ClientID %>");
            var panel = document.getElementById("<%=panelPrint.ClientID %>");
            var printWindow = window.open('', '', 'height=800,width=900');
            printWindow.document.write('<html><head>');
            printWindow.document.write('</head><body >');
            printWindow.document.write('<center>');
            printWindow.document.write('REPORTE DE CIERRE DE CAJA');
            printWindow.document.write('</center>');
            printWindow.document.write('<br />');
            printWindow.document.write('Movimiento de Ventas del: ');
            printWindow.document.write(fechaInicio.value);
            printWindow.document.write('  al:');
            printWindow.document.write(fechaFin.value);
            printWindow.document.write('<br />');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }
        function PrintDocumentosContables()
        {
            //========Obteniendo el tipo de comprobante====
            var drpTipoDocumento = document.getElementById("<%=drpTipoDocumento.ClientID %>")
            var tipoDocumento = drpTipoDocumento.options[drpTipoDocumento.selectedIndex].value;
           
            
            var today = new Date();
            var date = today.getDate() + '-' + (today.getMonth() + 1) + '-' + today.getFullYear();
           
            var printWindow = window.open('', '', 'height=800,width=800');
            printWindow.document.write('<html><head>');
            printWindow.document.write('<link rel="stylesheet" href="../Styles/styleTicket.css" type="text/css" />');
           
            printWindow.document.write('</head><body >');
            printWindow.document.write('<div class="ticket">')
            printWindow.document.write('<table>');
            printWindow.document.write('<tr>');
            printWindow.document.write('<td>');
            printWindow.document.write('<img id="imgLogo" alt="logo" src="../Images/Logo_factura.png" style=" width: 175px;" />');
            printWindow.document.write('</td>');
            printWindow.document.write('</tr>');
            printWindow.document.write('<tr>');
            printWindow.document.write('<td>RUC: 20101260292</td>');
            printWindow.document.write('</tr>');
            printWindow.document.write('<tr>');
            printWindow.document.write('<td>DIRECCIÓN: Cal. Nucleo de Servicio 9 Mz A. Lt. 4 LIMA - ATE</td>');
            printWindow.document.write('</tr>');
            printWindow.document.write('<tr>');
            printWindow.document.write('<td>TELÉFONO: 4801679</td>');
            printWindow.document.write('</tr>');
            printWindow.document.write('<tr>');
            printWindow.document.write('<td>CELULAR / WHATSAPP: 913232130</td>');
            printWindow.document.write('</tr>');
            printWindow.document.write('</table>');

            printWindow.document.write('<table>');
            printWindow.document.write('<tr>');
            printWindow.document.write('<td> N° DE COMPROBANTE:<td>');
            printWindow.document.write('<td>');
            printWindow.document.write(document.getElementById("<%=lblNum_doc_cobranza.ClientID %>").innerHTML);
            printWindow.document.write('</td>');
            printWindow.document.write('</tr>');
            if(tipoDocumento=="03")
            {
                printWindow.document.write('<tr>');
                printWindow.document.write('<td> CLIENTE:<td>');
                printWindow.document.write('<td>');
                printWindow.document.write(document.getElementById("<%=txtNombre_cliente.ClientID %>").value);
                printWindow.document.write('</td>');
                printWindow.document.write('</tr>');
            }
            else if (tipoDocumento == "01")
            {
                printWindow.document.write('<tr>');
                printWindow.document.write('<td> RUC:<td>');
                printWindow.document.write('<td>');
                printWindow.document.write(document.getElementById("<%=txtRuc_factura.ClientID %>").value);
                printWindow.document.write('</td>');
                printWindow.document.write('</tr>');
                 printWindow.document.write('<tr>');
                printWindow.document.write('<td> CLIENTE:<td>');
                printWindow.document.write('<td>');
                printWindow.document.write(document.getElementById("<%=txtCliente_factura.ClientID %>").value);
                printWindow.document.write('</td>');
                printWindow.document.write('</tr>');
            }
            
            printWindow.document.write('<tr>');
            printWindow.document.write('<td>FECHA Y HORA:<td>');
            printWindow.document.write('<td>');
            printWindow.document.write(date);
            printWindow.document.write('</td>');
            printWindow.document.write('</tr>');           
            printWindow.document.write('</table>');

            printWindow.document.write('<table> ');
            printWindow.document.write('<thead> <tr> <th>CANT. </th><th>DESCRIPCIÓN </th><th>TOTAL</th></tr></thead> ');
            printWindow.document.write('<tbody>');
            //=======PINTAR AQUI LAS FILAS DEL Gridview=====       
            var gridViewInterna = document.getElementById("<%=grdDetalleDocumento.ClientID %>");                  
            var gridViewExterna = document.getElementById("<%=grdDetalleVenta.ClientID %>");
          
            if (gridViewInterna != null)
             {
                for (i = 1; i < gridViewInterna.rows.length; i++)
                {
                    printWindow.document.write('<tr>');
                    printWindow.document.write('<td>');
                    printWindow.document.write(gridViewInterna.rows[i].cells[2].innerHTML);
                    printWindow.document.write('</td>');
                    printWindow.document.write('<td>');
                    printWindow.document.write(gridViewInterna.rows[i].cells[3].innerHTML);
                    printWindow.document.write('</td>');
                    printWindow.document.write('<td>');
                    printWindow.document.write(gridViewInterna.rows[i].cells[5].innerHTML);
                    printWindow.document.write('</td>');
                    printWindow.document.write('</tr>');
                }
             }
            if (gridViewExterna != null)
             {
                for (i = 1; i < gridViewExterna.rows.length; i++)
                    {
                        printWindow.document.write('<tr>');
                        printWindow.document.write('<td>');
                        printWindow.document.write(gridViewExterna.rows[i].cells[2].innerHTML);
                        printWindow.document.write('</td>');
                        printWindow.document.write('<td>');  
                        printWindow.document.write(gridViewExterna.rows[i].cells[3].innerHTML);
                        printWindow.document.write('</td>');
                        printWindow.document.write('<td>');
                        printWindow.document.write(gridViewExterna.rows[i].cells[5].innerHTML);
                        printWindow.document.write('</td>');                
                        printWindow.document.write('</tr>');                 
                    }
              }
            
            //=========fin del gridview===========
            printWindow.document.write('</tbody>')
            printWindow.document.write('</table>');
            if (tipoDocumento=="03")
            {
                printWindow.document.write('<table> ');  
                printWindow.document.write('<tr>');
                printWindow.document.write('<td>TOTAL:<td>');
                printWindow.document.write('<td>');
                printWindow.document.write(document.getElementById("<%=lblTotalFacBol.ClientID %>").innerHTML);            
                printWindow.document.write('</td>');
                printWindow.document.write('</tr>');
                printWindow.document.write('</table>');
            }
           else if (tipoDocumento == "01")
            {
                printWindow.document.write('<table>');
                printWindow.document.write('<tr>');
                printWindow.document.write('<td>SUBTOTAL:<td>');
                printWindow.document.write('<td>');
                printWindow.document.write(document.getElementById("<%=lblSubtotalFacBol.ClientID %>").innerHTML);
                printWindow.document.write('</td>');
                printWindow.document.write('</tr>');
                printWindow.document.write('<tr>');
                printWindow.document.write('<td>IGV:<td>');
                printWindow.document.write('<td>');
                printWindow.document.write(document.getElementById("<%=lblIGVFactBol.ClientID %>").innerHTML);
                printWindow.document.write('</td>');
                printWindow.document.write('</tr>');
                printWindow.document.write('<tr>');
                printWindow.document.write('<td>TOTAL:<td>');
                printWindow.document.write('<td>');
                printWindow.document.write(document.getElementById("<%=lblTotalFacBol.ClientID %>").innerHTML);
                printWindow.document.write('</td>');
                printWindow.document.write('</tr>');
                printWindow.document.write('</table>');             

           }
            printWindow.document.write('<br />');
            printWindow.document.write('<br />');
            printWindow.document.write('<br />');

            printWindow.document.write('<table>');
            printWindow.document.write('<tr>');
            printWindow.document.write('<td>Ubique su comprobante aquí:</td>');
            printWindow.document.write('</tr>');
            printWindow.document.write('<tr>');
            printWindow.document.write('<td>https://fe.esavdoc.com/consulta</td>');
            printWindow.document.write('</tr>');
            printWindow.document.write('</table>'); 

            printWindow.document.write('</div>');
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
             
        }
  </script>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
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
        <tr>
            <td style="text-align:right">Tipo de Documento:</td>
            <td>
                <asp:DropDownList ID="drpTipoDocumento" runat="server" CssClass="dropDownList" Width="200px" ClientIDMode="Static"  ></asp:DropDownList>
                 
            </td>
        </tr>
    </table>
<fieldset>
                 <table>

                    <tr>
                        <td style="text-align:right">N° de DNI:</td>
                        <td><asp:TextBox ID="txtDni_cliente" runat="server" Width="100px" CssClass="textbox" MaxLength="8" onkeyPress="return soloNumeros(event)" ClientIDMode="Static"></asp:TextBox>
                            <asp:Button ID="btnBuscaPacienteAdmitido" runat="server" Text=" "  CssClass="btnOpenPopup" OnClick="BuscarPacienteAdmitido" ToolTip="Buscar Paciente"  />
                            <asp:Button ID="Button1" runat="server" Text="..." OnClientClick="OpenListPacientes()" />
                            
                        </td>
                        <td style="text-align:right">Ruc:</td>
                        <td><asp:TextBox ID="txtRuc_factura" runat="server" Width="100px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                            <asp:Button ID="btnBuscarClienteEmpresa" runat="server" Text=" "  CssClass="btnOpenPopup" OnClientClick="OpenListClienteEmpresas()" ToolTip="Buscar Empresas"  />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:right">Paciente:</td>
                        <td><asp:TextBox ID="txtNombre_cliente" runat="server" Width="400px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox></td>
                        <td style="text-align:right">Razon Social:</td>
                        <td><asp:TextBox ID="txtCliente_factura" runat="server" Width="400px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>

                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:right">Dirección:</td>
                        <td><asp:TextBox ID="txtDir_boleta" runat="server" Width="400px" CssClass="textbox"></asp:TextBox></td>
                        <td style="text-align:right">Direccion:</td>
                        <td><asp:TextBox ID="txtDir_factura" runat="server" Width="400px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox></td>
                    </tr>
                     <tr>
                         <td style="text-align:right">Observacion:</td>
                         <td colspan="3"><asp:TextBox ID="txtObs_cobranza" runat="server" CssClass="textbox" Width="910px"></asp:TextBox></td>
                     </tr>
                     <tr>
                         <td style="text-align:right">Usuario:</td>
                         <td><asp:Label ID="lblUsuario" runat="server" CssClass="label"></asp:Label></td>
                     </tr>
                     <tr>
                         <td style="text-align:right">N° de Documento:</td>
                         <td > <asp:Label ID="lblSerie_cobranza" runat="server" CssClass="label" ClientIDMode="Static"></asp:Label>
                             <asp:Label ID="lblNum_doc_cobranza" runat="server" CssClass="label" ClientIDMode="Static" ></asp:Label>                            
                         </td>
                         <td>N° de Cuenta:</td>
                         <td><asp:Label ID="lblNumAdmision_cobranza" runat="server" CssClass="label"></asp:Label></td>
                     </tr>
                                                                    
                </table>
                </fieldset> 
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
   
        <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="TabPanel1" >
            <HeaderTemplate ><asp:Label ID="lblpage1" runat="server" Text="Ventas Internas" Width="150px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
            <ContentTemplate>  
                <asp:GridView ID="grdDetalleDocumento" runat="server" AutoGenerateColumns="False" CssClass="gridView" OnRowDataBound="CalcularVenta" >
                        <Columns>
                            <asp:BoundField DataField="cod_item_catalogo" HeaderText="Código"   />
                            <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                            <asp:BoundField DataField="descripcion_item" HeaderText="Descripción" HtmlEncode="False" />
                            <asp:BoundField DataField="p_unitario" HeaderText="Precio Unit." />
                            <asp:BoundField DataField="p_venta" HeaderText="Valor Venta" />
                            <asp:BoundField DataField="id_grupo" HeaderText="Grupo"   />
                            <asp:BoundField DataField="id_clase" HeaderText="Clase"   />
                        </Columns>
                      
                    </asp:GridView>          
            </ContentTemplate>
        </ajaxToolkit:TabPanel>

        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate><asp:Label ID="lblPage2" runat="server" Text="Otras Ventas" Width="150px" ForeColor="#1F497D"></asp:Label> </HeaderTemplate>
            <ContentTemplate>
                 <fieldset class="fieldset">
            <legend class="legend">Detalle de Venta</legend>
             <table >
                        <tr>
                            <td style="text-align:left">Código</td>
                            <td style="text-align:left">Descripción</td>
                            <td style="text-align:left">Precio Unit.</td>
                            <td style="text-align:left">Cantidad</td>
                                                    
                        </tr>
                        <tr>
                             <td><asp:TextBox ID="txtId_ItemCatalogo" runat="server" Width="100px" CssClass="textBoxDisabled" ClientIDMode="Static" ></asp:TextBox></td>
                             <td><asp:TextBox ID="txtDescrip_catalogo" runat="server" Width="300px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox></td>
                            <td><asp:TextBox ID="txtPrecio_item" runat="server" Width="100px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                                <asp:Button ID="btnOpenCatalogo" runat="server" Text=" " CssClass="btnOpenPopup" OnClientClick="OpenCatalogoItems()" ToolTip="Buscar Items"/>
                            </td>
                            <td><asp:TextBox ID="txtCantidad_item" runat="server" Width="100px" CssClass="txtboxNumber" MaxLength="5" onkeyPress="return soloNumeros(event)"></asp:TextBox>
                                <asp:TextBox ID="txtIdGrupo_item" runat="server" Width="20px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                                <asp:TextBox ID="txtIdClase_item" runat="server" Width="20px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                                <asp:Button ID="btnImputar" runat="server" CssClass="btnCkeckData" OnClick="CargarItems" Text=" " ToolTip="Aregar" />
                            </td>
                        </tr>
                                   
                    </table>
            <asp:GridView ID="grdDetalleVenta" runat="server" CssClass="gridView" AutoGenerateColumns="false" OnRowDataBound="CalcularVentaParticular" >                   
                      <Columns>
                            <asp:BoundField DataField="Col1" HeaderText="N°" />
                            <asp:BoundField DataField="Col2" HeaderText="Código" /> 
                            <asp:BoundField DataField="Col3" HeaderText="Cantidad" /> 
                            <asp:BoundField DataField="Col4" HeaderText="Descripcion" />  
                            <asp:BoundField DataField="Col5" HeaderText="Precio Unit." /> 
                            <asp:BoundField DataField="Col6" HeaderText="Valor Venta" /> 
                            <asp:BoundField DataField="Col7" HeaderText="IdGrupo" /> 
                            <asp:BoundField DataField="Col8" HeaderText="IdClase" /> 
                           
                          <asp:TemplateField HeaderText="">
                         <ItemTemplate>
                             <asp:Button ID="btnBorrarFila" runat="server" CssClass="buttonIconDelete" ToolTip="Quitar artículo"  OnClick="BorrarFila" /> 
                         </ItemTemplate>
                
                      </asp:TemplateField>
                      </Columns>
                     
                    </asp:GridView>                      
                
        </fieldset>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>

        <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
             <HeaderTemplate><asp:Label ID="lblpage3" runat="server" Text="Anular Documentos" Width="150px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
            <ContentTemplate>
                <table style="margin:auto">
                    <tr>
                        <td>Numero de Documento:</td>
                        <td><asp:TextBox ID="txtNumeroDocumentoAnular" runat="server" Width="100px" Text="0" CssClass="txtboxNumber"></asp:TextBox> 
                            <asp:Button ID="btnAnular" runat="server" CssClass="buttonIconDelete" OnClick="Anular"/>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel6" runat="server" HeaderText="TabPanel6">
            <HeaderTemplate><asp:Label ID="lblpage6" runat="server" Text="Cierre de Caja" Width="150px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
            <ContentTemplate>
                <div>
                    
            <table>
            <tr>
                <td style="text-align:right">Fecha de Inicio:</td>
                <td><asp:TextBox ID="txtFechaIni" runat="server" Width="100px" CssClass="textbox"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtFechaIni" Format="dd/MM/yyyy" CssClass="calendar"  />
                </td>
                <td style="text-align:right">Fecha de Fin:</td>
                <td><asp:TextBox ID="txtFechaFin" runat="server" Width="100px" CssClass="textbox"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtFechaFin" Format="dd/MM/yyyy" CssClass="calendar" />
                </td>
                <td><asp:Button ID="btnListarReporte" runat="server" Text="Buscar" CssClass="button" OnClick="ListarReporteCaja" CausesValidation="false" />
                    <asp:Button ID="btnPrint" runat="server" Text="Imprimir" CssClass="button" OnClientClick=" return PrintPanelCierrecaja();" />
                    <asp:Button ID="btnExportExcel" runat="server" Text="Exp. a Excel" CssClass="button" OnClick="ExportarExcelReporteCaja" CausesValidation="false" />
                </td>
            </tr>
          </table>
                 <asp:Panel ID="panelPrint" runat="server">
                   <asp:GridView ID="grdReporteCierreCaja" runat="server" AutoGenerateColumns="false" CssClass="gridView" OnRowDataBound="CalcularTotalVentaReporteCaja" >
                       <Columns>
                           <asp:BoundField DataField="fecha_pago" HeaderText="Fecha" />
                           <asp:BoundField DataField="numero_documento" HeaderText="Doc. cobranza" />
                           <asp:BoundField DataField="Num_doc_cliente" HeaderText="N° Documento" />
                           <asp:BoundField DataField="Nombre_cliente" HeaderText="Cliente" />
                           <asp:BoundField DataField="monto_pago" HeaderText="Pago" />
                           
                       </Columns>
                   </asp:GridView>
                     <table>
                         <tr>
                             <td style="text-align:right">Monto Bruto de Venta:</td>
                             <td><asp:Label ID="lblTotalBrutoVenta" runat="server" Text="0.0"></asp:Label></td>
                         </tr>
                          <tr>
                             <td style="text-align:right">Monto de Apertura:</td>
                             <td><asp:Label ID="lblMontoApertura" runat="server" Text="0.0"></asp:Label></td>
                         </tr>
                          <tr>
                             <td style="text-align:right">Monto Neto de Venta:</td>
                             <td><asp:Label ID="lblTotalNetoVenta" runat="server" Text="0.0"></asp:Label></td>
                         </tr>
                     </table>
                  </asp:Panel>
                </div>
             
            </ContentTemplate>
        </ajaxToolkit:TabPanel>

    </ajaxToolkit:TabContainer>
    <table style="float:left">
                    <tr>
                        <td><asp:Label ID="lblNumeroEnLetra" runat="server"></asp:Label></td>
                    </tr>
                </table>
                <br />
                <table style="float:right">
                    <tr>
                        <td style="text-align:right">Monto Subtotal:</td>
                        <td style="text-align:right"><asp:Label ID="lblSubtotalFacBol" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="text-align:right">Monto IGV:</td>
                        <td style="text-align:right"><asp:Label ID="lblIGVFactBol" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                         <td style="text-align:right">Descuento(%): </td>
                        <td style="text-align:right">
                            <asp:TextBox ID="txtDescuento" runat="server" Text="0" CssClass="txtboxNumber" Width="100px"></asp:TextBox>
                            <asp:Button ID="btnAplicarDescuento" runat="server" Text=" " CssClass="btnCkeckData" OnClick="AplicarDescuento" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align:right">Monto Total:</td>
                        <td style="text-align:right"><asp:Label ID="lblTotalFacBol" runat="server" Text="0"></asp:Label></td>
                    </tr>
                </table>



   <table style="margin:auto" >
                        
                        <tr>
                            <td><asp:Button ID="btnGuardarDocContable" runat="server" Text="Guardar" CssClass="button" OnClick="GuardarDocumentoContable"  />
                                <asp:Label ID="lblMsj_cobranza" runat="server" ForeColor="Green" Font-Bold="True"></asp:Label>
                            </td>
                            <td><asp:Button ID="btnFormaPago" runat="server" Text="Formas de Pago" CssClass="button" OnClientClick="OpenFormasDePago()" /></td>
                            <td><asp:Button ID="btnImprimirFacBol" runat="server" Text="Imprimir" CssClass="button" OnClientClick="return PrintDocumentosContables()"/></td>
                            <td><asp:Button ID="btnNuevaCobranza" runat="server" Text="Nuevo"  CssClass="button" OnClick="NuevaCobranza" /></td>
                             
                        </tr>               
                    </table>
</asp:Content>
 