<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmDespachoFarmacia.aspx.cs" Inherits="CapaPresentacion.Forms.frmDespachoFarmacia" %>

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
       $("#txtDni_cliente").attr("readonly", true);
       $("#txtNombre_cliente").attr("readonly", true);
     
       $("#txtRuc_factura").attr("readonly", true);
       $("#txtCliente_factura").attr("readonly", true);
       $("#txtDir_factura").attr("readonly", true);

       $("#txtId_ItemCatalogo").attr("readonly", true);
       $("#txtDescrip_catalogo").attr("readonly", true);
       $("#txtPrecio_item").attr("readonly", true);
             
    return false; //to prevent from postback
    });
</script>
    <script type="text/javascript">
    
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
    function OpenListPacientes()
    {
        window.open("../Forms/frmListar_Pacientes.aspx", 'Lista Pacientes', 'height=550,width=600,left=265,top=165,resizable=No,toolbar=No')
    }
</script>
<script type="text/javascript">
    function PrintDocumentosContables()
    {
         var ddlDpcumentoContable = document.getElementById("<%=drpTipoDocumento.ClientID %>");
        
        if (ddlDpcumentoContable.value == "03")
        {
            var pnlDocumentos = document.getElementById("<%=pnlDocumentoContable.ClientID %>");
            var printWindow = window.open('', '', 'height=800,width=900');
            printWindow.document.write('<html><head>');
            printWindow.document.write('<link rel="stylesheet" href="../Styles/StyleControls.css" type="text/css" />');
            printWindow.document.write('</head><body >');
            printWindow.document.write('<img id="imgLogo" alt="logo" src="../Images/Logo_factura.png" />');
            printWindow.document.write('<br />');
            printWindow.document.write('<br />');
            printWindow.document.write('<br />');
            printWindow.document.write('<br />');

            printWindow.document.write('<table>');
            printWindow.document.write('<tr>');
            printWindow.document.write('<td style="width:200px;">CLIENTE:</td>');
            printWindow.document.write('<td>');
             printWindow.document.write(document.getElementById("<%=txtNombre_cliente.ClientID %>").value);
            printWindow.document.write('</td>');
            printWindow.document.write('</tr>');
            printWindow.document.write('<tr>');
            printWindow.document.write('<td style="width:200px;">N° de DNI/CE:</td>');
            printWindow.document.write('<td>');
            printWindow.document.write(document.getElementById("<%=txtDni_cliente.ClientID %>").value);
            printWindow.document.write('</td>');
            printWindow.document.write('</tr>');
            printWindow.document.write('<tr>');
            printWindow.document.write('<td style="width:200px;">DIRECCIÓN:</td>');
            printWindow.document.write('<td>');
            printWindow.document.write(document.getElementById("<%=txtDir_boleta.ClientID %>").value);
            printWindow.document.write('</td>');
            printWindow.document.write('</tr>');
            printWindow.document.write('<tr>');
            printWindow.document.write('<td style="width:200px;">MONEDA:</td>');
            printWindow.document.write('<td>NUEVOS SOLES</td>');
             printWindow.document.write('</tr>');
            printWindow.document.write('</table>');
 
            printWindow.document.write(pnlDocumentos.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () { printWindow.print(); }, 500);
            return false;  
        }
        if (ddlDpcumentoContable.value == "01")
        {
           var pnlDocumentos = document.getElementById("<%=pnlDocumentoContable.ClientID %>");
            var printWindow = window.open('', '', 'height=800,width=900');
            printWindow.document.write('<html><head>');
            printWindow.document.write('<link rel="stylesheet" href="../Styles/StyleControls.css" type="text/css" />');
            printWindow.document.write('</head><body >');
            printWindow.document.write('<img id="imgLogo" alt="logo" src="../Images/Logo_factura.png" />');
            printWindow.document.write('<br />');
            printWindow.document.write('<br />');
            printWindow.document.write('<br />');
            printWindow.document.write('<br />');

            printWindow.document.write('<table>');
            printWindow.document.write('<tr>');
            printWindow.document.write('<td style="width:200px;">N° de RUC:</td>');
            printWindow.document.write('<td>');
             printWindow.document.write(document.getElementById("<%=txtRuc_factura.ClientID %>").value);
            printWindow.document.write('</td>');
            printWindow.document.write('</tr>');
            printWindow.document.write('<tr>');
            printWindow.document.write('<td style="width:200px;">RAZON SOCIAL:</td>');
            printWindow.document.write('<td>');
            printWindow.document.write(document.getElementById("<%=txtCliente_factura.ClientID %>").value);
            printWindow.document.write('</td>');
            printWindow.document.write('</tr>');
            printWindow.document.write('<tr>');
            printWindow.document.write('<td style="width:200px;">DIRECCIÓN:</td>');
            printWindow.document.write('<td>');
            printWindow.document.write(document.getElementById("<%=txtDir_factura.ClientID %>").value);
            printWindow.document.write('</td>');
            printWindow.document.write('</tr>');
            printWindow.document.write('<tr>');
            printWindow.document.write('<td style="width:200px;">MONEDA:</td>');
            printWindow.document.write('<td>NUEVOS SOLES</td>');
             printWindow.document.write('</tr>');
            printWindow.document.write('</table>');
 
            printWindow.document.write(pnlDocumentos.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () { printWindow.print(); }, 500);
            return false; 
        }   
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
                <asp:DropDownList ID="drpTipoDocumento" runat="server" CssClass="dropDownList" Width="200px" ClientIDMode="Static"></asp:DropDownList></td>
        </tr>
    </table>
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
     <ajaxToolkit:TabPanel runat="server" HeaderText="tabPanelVentaFarmacia" ID="tblPanelVentaFarmacia">
         <HeaderTemplate><asp:Label ID="Label4" runat="server" Text="Ventas" Width="150px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
         <ContentTemplate>
             <table style="margin:auto">
              <tr>
                    <td style="text-align:right">Buscar x N° de DNI:</td>
                      <td><asp:TextBox ID="txtBuscaxDni" runat="server" Width="100px" CssClass="textbox" MaxLength="8" onkeyPress="return soloNumeros(event)"></asp:TextBox>
                      <asp:Button ID="btnBuscaPacienteAdmitido" runat="server" Text=" "  CssClass="btnOpenPopup" OnClick="BuscarPacienteAdmitido" ToolTip="Buscar Paciente" CausesValidation="False" />              
                  </td>
                </tr>
   
           </table>
    <asp:GridView ID="grdHistorialAtenciones" runat="server" CssClass="gridViewCita" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="VerDetalleAtencion" CausesValidation="false">Select</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="numero_admision" HeaderText="N° de Cuenta" />
             <asp:BoundField DataField="fecha_atencion" HeaderText="Fecha Atencion" />
            <asp:BoundField DataField="num_doc_cliente" HeaderText="DNI/CE" />            
            <asp:BoundField DataField="paciente" HeaderText="Paciente" />           
            <asp:BoundField DataField="direccion" HeaderText="Dirección" />
            <asp:BoundField DataField="anotaciones" HeaderText="Receta" />
            <asp:BoundField DataField="medico" HeaderText="Médico" />
             <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnBuscaMedicamentoConfirmado" runat="server" CssClass="buttonIconOk" ToolTip="Buscar Medicamentos" OnClick="BuscaMedicamentoConfirmado" CausesValidation="false" />
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
                <fieldset>
                 <table>
                    <tr>
                        <td style="text-align:right">N° de DNI:</td>
                        <td><asp:TextBox ID="txtDni_cliente" runat="server" Width="100px" CssClass="textBoxDisabled" MaxLength="8" onkeyPress="return soloNumeros(event)" ClientIDMode="Static"></asp:TextBox>
                           
                        </td>

                        <td style="text-align:right">Ruc:</td>
                        <td><asp:TextBox ID="txtRuc_factura" runat="server" Width="100px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                            <asp:Button ID="btnBuscarClienteEmpresa" runat="server" Text=" "  CssClass="btnOpenPopup" OnClientClick="OpenListClienteEmpresas()" ToolTip="Buscar Empresas" />
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
                         <td style="text-align:right">Observación:</td>
                         <td colspan="3"><asp:TextBox ID="txtObs_cobranza" runat="server" CssClass="textbox" Width="910px"></asp:TextBox></td>
                     </tr>
                     <tr>
                         <td style="text-align:right">Usuario:</td>
                         <td><asp:Label ID="lblUsuario" runat="server" CssClass="label"></asp:Label></td>
                     </tr>
                     <tr>
                         <td style="text-align:right"> N° de doc. Contable:</td>
                         <td>
                             <asp:Label ID="lblSerie_cobranza" runat="server"  CssClass="label" ClientIDMode="Static"></asp:Label>
                             <asp:Label ID="lblNum_doc_cobranza" runat="server" CssClass="label"  ClientIDMode="Static"></asp:Label>
                             N° de Admisión: <asp:Label ID="lblNumAdmision_cobranza" runat="server"  CssClass="label" ClientIDMode="Static"></asp:Label> 

                         </td>
                     </tr>                                                               
                </table>
 
                </fieldset>
             <br />
                <fieldset class="fieldset">
                    <legend class="legend">Detalle del Despacho</legend>
                   
                    <table style="float:right">
                        <tr>
                            <td></td>
                            <td><%--Descuento total S/. :<asp:TextBox ID="txtAplicarDescuento" runat="server" Text="0" CssClass="txtboxNumber" Width="50px"></asp:TextBox>--%>
                                <asp:Button ID="btnConfirmaMedicamento" runat="server" Text="Confirmar" CssClass="button" ToolTip="Confirmar Medicamentos" OnClick="ConfirmarMedicamento"  />
                            </td>
                            <td><asp:Button ID="btnGuardarDocContable" runat="server" Text="Guardar" CssClass="button" OnClick="GuardarDocumentoContable"  />
                                <asp:Label ID="lblMsj_cobranza" runat="server"  ForeColor="Green" Font-Bold="True"></asp:Label> 
                            </td>
                            <td><asp:Button ID="btnImprimirFacBol" runat="server" Text="Imprimir" CssClass="button" OnClick="ImprimirDocumentosContables"  /></td>
                            <td><asp:Button ID="btnFormasPago" runat="server" Text="Formas de Pago" CssClass="button" OnClientClick="OpenFormasDePago()" /></td>
                            <td> <asp:Button ID="btnBuevoDespachoFarmacia" runat="server" Text="Nuevo" CssClass="button" OnClick="NuevoDespachoFarmacia" CausesValidation="False" /> </td>
                        </tr>    
                    </table>
              <asp:Panel ID="pnlDocumentoContable" runat="server">
                    <asp:GridView ID="grdDetalleDocumento" runat="server" CssClass="gridView" AutoGenerateColumns="false" OnRowDataBound="CalcularVenta" >                   
                     <Columns>
                            <asp:BoundField DataField="codigo_item_catalogo" HeaderText="Código"   />
                            <asp:TemplateField HeaderText="Cantidad">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCantidad" runat="server" Width="40px" Text='<%# Eval("cantidad")%>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="descripcion_item" HeaderText="Descripción" HtmlEncode="false" />
                            <asp:BoundField DataField="precio_unitario" HeaderText="Precio Unit." />
                            <asp:BoundField DataField="precio_venta" HeaderText="Valor Venta" />
                            <asp:BoundField DataField="id_grupo" HeaderText="Grupo"   />
                            <asp:BoundField DataField="id_clase" HeaderText="Clase"   />
                          <asp:TemplateField HeaderText="">
                         <ItemTemplate>
                             <asp:CheckBox ID="chkAcepta" runat="server" Checked="true"  />
                         </ItemTemplate>                
                      </asp:TemplateField>
                      </Columns>
                    </asp:GridView>
               <br />
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
                         <td style="text-align:right">Descuento:</td>
                        <td style="text-align:right"><asp:Label ID="lblDescuentoFacBol" runat="server" Text="0"></asp:Label></td>
                    </tr>
                    <tr>
                        <td style="text-align:right">Monto Total:</td>
                        <td style="text-align:right"><asp:Label ID="lblTotalFacBol" runat="server" Text="0"></asp:Label></td>
                    </tr>
                </table>
                </asp:Panel>
                </fieldset>           
         </ContentTemplate>
     </ajaxToolkit:TabPanel>

     <ajaxToolkit:TabPanel runat="server" HeaderText="tabPanelReporteVentaFarmacia" ID="tblPanelReporteVentaFarmacia">
         <HeaderTemplate><asp:Label ID="Label1" runat="server" Text="Reporte de Despachos" Width="150px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
         <ContentTemplate>
             <table style="margin:auto">
                 <tr>
                     <td style="text-align:right">Fecha Inicio:</td>
                     <td><asp:TextBox ID="txtfechaIni" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                         <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfechaIni" Format="dd/MM/yyyy" CssClass="calendar"/>
                     </td>
                     <td style="text-align:right">Fecha Fin:</td>
                     <td><asp:TextBox ID="txtfechaFin" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                         <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtfechaFin" Format="dd/MM/yyyy" CssClass="calendar" />
                     </td>
                     <td><asp:Button ID="btnListarReporte" runat="server" Text="Listar" CssClass="button" OnClick="ListarReporteVentasFarmacia" />
                         <asp:Button ID="btnExportarExcel" runat="server" Text="Exportar Excel" CssClass="button" OnClick="ExportarReporteVentas" />
                         
                     </td>
                 </tr>
             </table>
             <asp:GridView ID="grdreporteVentasFarmacia" runat="server" AutoGenerateColumns="false" CssClass="gridView" OnRowDataBound="CalcularVentaTotalReporteFarmacia">
                 <Columns>
                     <asp:BoundField DataField="codigo_item_catalogo" HeaderText="Código" />
                     <asp:BoundField DataField="fecha_emision" HeaderText="Fecha" />
                     <asp:BoundField DataField="descripcion_principal" HeaderText="Descripción"  />
                     <asp:BoundField DataField="monto_total" HeaderText="Monto" />
                     <%--<asp:TemplateField HeaderText="...">
                <ItemTemplate>
                  <asp:Label ID="lblMontoVenta" runat="server" Text='<%# Eval("monto_total") %>' />
                 </ItemTemplate> 
                 <FooterTemplate>
                     <asp:Label ID="lblTotalVenta" runat="server" ></asp:Label>
                 </FooterTemplate>
             </asp:TemplateField>--%>
                     
                     <asp:BoundField DataField="numero_documento" HeaderText="N° Documento" />
                     <asp:BoundField DataField="tipo_documento" HeaderText="Tipo" />
                 </Columns>
                 <EmptyDataTemplate>
                        <table style="width:100%">
                            <tr>
                                <td>No data Found</td>
                            </tr>
                        </table>
                 </EmptyDataTemplate> 
             </asp:GridView>
             <table style="margin:auto" >
                 <tr>
                     <td style="text-align:right"> Venta Total: </td>
                     <td><asp:Label ID="lblTotalVenta" runat="server" Text="0.0"></asp:Label></td>
                 </tr>
             </table>
            
         </ContentTemplate>
     </ajaxToolkit:TabPanel>

    </ajaxToolkit:TabContainer>



</asp:Content>
 