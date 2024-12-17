<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmRecetaMedica.aspx.cs" Inherits="CapaPresentacion.Forms.frmRecetaMedica"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

 

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
      <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/jquery.min.js"> </script>
   <script type="text/javascript" src="../Scripts/SoloNumeros.js"></script>
  <script type="text/javascript" src="../Scripts/TexboxEnterNextControl.js"></script>
    
     <script type="text/javascript">
    
    function OpenCatalogoItems()
    {
        window.open("../Forms/frmListar_Catalogo.aspx", 'Lista Items', 'height=550,width=800,left=265,top=165,resizable=No,toolbar=No')
    }

</script>
<script type="text/javascript">
   $(document).ready(function() {
       //$('input[type="text"]').attr("disabled", "disabled");// to disable all textbox, color gray by defaul. But makes it empty to value of control
       $("#txtDniEmpleado").attr("readonly", true);
       $("#txtNombreEmpleado").attr("readonly", true);
       $("#txtNumeroAdmision").attr("readonly", true);

       $("#txtDNIPaciente").attr("readonly", true);
       $("#txtNombrePaciente").attr("readonly", true);
       $("#txtEdadPaciente").attr("readonly", true);
       $("#txtDireccionPaciente").attr("readonly", true);
       $("#txtTelefonoPaciente").attr("readonly", true);
       $("#txtEmailPaciente").attr("readonly", true);

       $("#txtId_ItemCatalogo").attr("readonly", true);
       $("#txtDescrip_catalogo").attr("readonly", true);
       $("#txtPrecio_item").attr("readonly", true);
             
    return false; //to prevent from postback
    });
</script>
   
</head>
<body onload="GetValuesConsultorio()">
    <script type="text/javascript">
        function GetValuesConsultorio()
        {           
            document.getElementById("<%= txtDniEmpleado.ClientID %>").value = window.opener.document.getElementById("txtDni_empleado").value;  
            document.getElementById("<%= txtNombreEmpleado.ClientID %>").value = window.opener.document.getElementById("txtNombre_empleado").value;  
            document.getElementById("<%= txtNumeroAdmision.ClientID %>").value = window.opener.document.getElementById("lblNumeroAdmision").innerHTML;  
   
        }
 </script>
 <script type="text/javascript">
        function PrintRecetaMedica()
        {
            //=====obteniendo los campos de CABECERA====
           
            //========Diseñando la pantalla=======
            var printWindow = window.open('', '', 'height=900,width=1200');
            printWindow.document.write('<html>');
            printWindow.document.write('<head>');
            //printWindow.document.write('<link rel="stylesheet" href="../Styles/styleTicket.css" type="text/css" />');
            printWindow.document.write('</head>');
            printWindow.document.write('<body >');
            printWindow.document.write('<div>');

            printWindow.document.write('<table style="margin:auto;">');
            printWindow.document.write('<tr>');
            printWindow.document.write('<td>');
            printWindow.document.write('<img id="imgLogo" alt="logo" src="../Images/Logo_RECETA.png" style=" width: 500px;"  />');
            printWindow.document.write('</td>');
            printWindow.document.write('</tr>');
            printWindow.document.write('</table>');
            printWindow.document.write('<br />');
            printWindow.document.write('<br />');
            printWindow.document.write('<table>');
            printWindow.document.write('<tr>');
            printWindow.document.write('<td style="text-align:right">MÉDICO TRATANTE:</td>');
            printWindow.document.write('<td>');
            printWindow.document.write(document.getElementById("<%=txtNombreEmpleado.ClientID %>").value);
            printWindow.document.write('</td>'); 
            printWindow.document.write('</tr>');
            printWindow.document.write('<tr>');
            printWindow.document.write('<td style="text-align:right">DNI:</td>');
            printWindow.document.write('<td>');
            printWindow.document.write(document.getElementById("<%=txtDNIPaciente.ClientID %>").value);
            printWindow.document.write('</td>'); 
            printWindow.document.write('</tr>');
            printWindow.document.write('<tr>');
            printWindow.document.write('<td style="text-align:right">PACIENTE:</td>');
            printWindow.document.write('<td>');
            printWindow.document.write(document.getElementById("<%=txtNombrePaciente.ClientID %>").value);
            printWindow.document.write('</td>'); 
            printWindow.document.write('</tr>');
            printWindow.document.write('<tr>');
            printWindow.document.write('<td style="text-align:right">DIRECCIÓN:</td>');
            printWindow.document.write('<td>');
            printWindow.document.write(document.getElementById("<%=txtDireccionPaciente.ClientID %>").value);
            printWindow.document.write('</td>'); 
            printWindow.document.write('</tr>');
            printWindow.document.write('<tr>');
            printWindow.document.write('<td style="text-align:right">TEFÉFONO:</td>');
            printWindow.document.write('<td>');
            printWindow.document.write(document.getElementById("<%=txtTelefonoPaciente.ClientID %>").value);
            printWindow.document.write('</td>'); 
            printWindow.document.write('</tr>');
            printWindow.document.write('<tr>');
            printWindow.document.write('<td style="text-align:right">E-MAIL:</td>');
            printWindow.document.write('<td>');
            printWindow.document.write(document.getElementById("<%=txtEmailPaciente.ClientID %>").value);
            printWindow.document.write('</td>'); 
            printWindow.document.write('</tr>');
             printWindow.document.write('<tr>');
            printWindow.document.write('<td style="text-align:right">EDAD:</td>');
            printWindow.document.write('<td>');
            printWindow.document.write(document.getElementById("<%=txtEdadPaciente.ClientID %>").value);
            printWindow.document.write('</td>'); 
            printWindow.document.write('</tr>');
             printWindow.document.write('<tr>');
            printWindow.document.write('<td style="text-align:right">DIAGNÓSTICO(CIE10):</td>');
            printWindow.document.write('<td>');
            printWindow.document.write(document.getElementById("<%=txtAnotaciones.ClientID %>").value);
            printWindow.document.write('</td>'); 
            printWindow.document.write('</tr>');
            printWindow.document.write('<tr>');
            printWindow.document.write('<td style="text-align:right">VIGENTE HASTA:</td>');
            printWindow.document.write('<td>');
            printWindow.document.write(document.getElementById("<%=txtFechaVigencia.ClientID %>").value);
            printWindow.document.write('</td>'); 
            printWindow.document.write('</tr>');
            printWindow.document.write('</table>');

            printWindow.document.write('<table>');
            printWindow.document.write('<thead><tr> <th style="width: 50px; max-width: 50px;">CANT. </th> <th style="width: 400px; max-width: 400px; word-break: break-all;">DESCRIPCIÓN </th> <th style="width: 150px; max-width: 150px;">VIA ADMINISTRACIÓN </th> <th style="width: 150px; max-width: 150px;">FRECUENCIA </th> <th style="width: 150px; max-width: 150px;">TRATAMIENTO </th>              </tr></thead>');
            //======= imprimir las filas Gridview=====  
            
            printWindow.document.write('<tbody>');
            var gridDetalleReceta = document.getElementById("<%=grdDetalleReceta.ClientID %>");                  
            if (gridDetalleReceta != null)
            {
                for(i=1;i < gridDetalleReceta.rows.length; i++ )
                {
                    printWindow.document.write('<tr>');
                    printWindow.document.write('<td>');
                    printWindow.document.write(gridDetalleReceta.rows[i].cells[2].innerHTML);
                    printWindow.document.write('</td>');
                    printWindow.document.write('<td>');
                    printWindow.document.write(gridDetalleReceta.rows[i].cells[3].innerHTML);
                    printWindow.document.write('</td>');
                    printWindow.document.write('<td>');
                    printWindow.document.write(gridDetalleReceta.rows[i].cells[5].innerHTML);
                    printWindow.document.write('</td>');
                    printWindow.document.write('<td>');
                    printWindow.document.write(gridDetalleReceta.rows[i].cells[6].innerHTML);
                    printWindow.document.write('</td>');
                    printWindow.document.write('<td>');
                    printWindow.document.write(gridDetalleReceta.rows[i].cells[7].innerHTML);
                    printWindow.document.write('</td>');
                    printWindow.document.write('</tr>');
                }
            }
            printWindow.document.write('</tbody>')
            //=========fin del gridview===========
            printWindow.document.write('</table>');

            printWindow.document.write('</div>');
            printWindow.document.write('</body>');
            printWindow.document.write('</html>');

            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;

        }
    </script>




    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <table> 
            <tr>
             <td style="text-align:right">Médico Tratante:</td>
             <td><asp:TextBox ID="txtDniEmpleado" runat="server" Width="100px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                 <asp:TextBox ID="txtNombreEmpleado" runat="server"  Width="400px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
             </td>
         </tr>
         <tr>
            <td style="text-align:right">N° de Admisión:</td>
             <td><asp:TextBox ID="txtNumeroAdmision" runat="server" Width="100px" CssClass="textBoxDisabled"></asp:TextBox></td>
         </tr>
          <tr>
             <td style="text-align:right">Vigencia hasta:</td>
             <td><asp:TextBox ID="txtFechaVigencia" runat="server" Width="100px" CssClass="textbox"></asp:TextBox>
                 <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaVigencia" Format="dd/MM/yyyy" CssClass="calendar"/>
             </td>
         </tr>
         <tr>
             <td></td>
             <td>
                 <fieldset>
                     <legend>Datos del Paciente</legend>
                     <table>
                          <tr>
                              <td style="text-align:right">DNI:</td>
                              <td><asp:TextBox ID="txtDNIPaciente" runat="server" Width="100px" CssClass="textBoxDisabled"></asp:TextBox>
                                  <asp:Button ID="btnGetPaciente" runat="server" Text=" " CssClass="btnCkeckData" ToolTip="Buscar Paciente" OnClick="GetPaciente" />
                                  <asp:TextBox ID="txtNombrePaciente" runat="server" Width="300px" CssClass="textBoxDisabled" ></asp:TextBox>
                              </td>
                          </tr>
                         <tr>
                             <td style="text-align:right">Edad:</td>
                             <td><asp:TextBox ID="txtEdadPaciente" runat="server" Width="100px" CssClass="textBoxDisabled"></asp:TextBox></td>
                         </tr>
                         <tr>
                             <td style="text-align:right">Dirección:</td>
                             <td><asp:TextBox ID="txtDireccionPaciente" runat="server" Width="400px" CssClass="textBoxDisabled"></asp:TextBox></td>
                         </tr>
                         <tr>
                             <td style="text-align:right">Teléfono:</td>
                             <td><asp:TextBox ID="txtTelefonoPaciente" runat="server" Width="100px" CssClass="textBoxDisabled"></asp:TextBox></td>
                         </tr>
                         <tr>
                             <td style="text-align:right">E-Mail:</td>
                             <td><asp:TextBox ID="txtEmailPaciente" runat="server" Width="400px" CssClass="textBoxDisabled"></asp:TextBox></td>
                         </tr>
                     </table>
                 </fieldset>
                 
             </td>
         </tr>
         <tr>
             <td style="text-align:right">Alérgico:</td>
             <td><asp:CheckBox ID="chkAlergico" runat="server"/></td>
         </tr>
         <tr>
             <td style="text-align:right">Indicaciones:</td>
             <td><asp:TextBox ID="txtAnotaciones" runat="server" TextMode="MultiLine" Width="750px" Height="50px" CssClass="textbox"></asp:TextBox></td>
         </tr>
         <tr>
             <td></td>
             <td>
           <fieldset class="fieldset">
            <legend class="legend">Medicamentos</legend>
             <table >
                        <tr>
                            <td style="text-align:left">Código</td>
                            <td style="text-align:left">Descripción</td>
                            <td style="text-align:left">Precio Unit.</td>
                            <td style="text-align:left">Cantidad</td>
                                                    
                        </tr>
                        <tr>
                             <td><asp:TextBox ID="txtId_ItemCatalogo" runat="server" CssClass="textBoxDisabled" ClientIDMode="Static" ></asp:TextBox></td>
                             <td><asp:TextBox ID="txtDescrip_catalogo" runat="server" Width="300px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox></td>
                            <td><asp:TextBox ID="txtPrecio_item" runat="server" Width="100px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                                <asp:Button ID="btnOpenCatalogo" runat="server" Text=" " CssClass="btnOpenPopup" OnClientClick="OpenCatalogoItems()" ToolTip="Buscar Items"/>
                            </td>
                            <td><asp:TextBox ID="txtCantidad_item" runat="server" Width="100px" CssClass="txtboxNumber" MaxLength="5" onkeyPress="return soloNumeros(event)"></asp:TextBox>
                                <asp:TextBox ID="txtIdGrupo_item" runat="server" Width="20px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                                <asp:TextBox ID="txtIdClase_item" runat="server" Width="20px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                                
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:left">Concentración</td>
                            <td style="text-align:left">Vía de Administración</td>
                            <td style="text-align:left">Frecuencia</td>
                            <td style="text-align:left">Tratamiento</td>                                                    
                        </tr>
                        <tr>
                            <td><asp:TextBox ID="txtConcentracion" runat="server" CssClass="textbox"></asp:TextBox> </td>
                            <td><asp:TextBox ID="txtViaAdministracion" runat="server" Width="300px" CssClass="textbox"></asp:TextBox> </td>
                            <td><asp:TextBox ID="txtFrecuencia" runat="server" Width="120px" CssClass="textbox"></asp:TextBox> </td>
                            <td><asp:TextBox ID="txtTratamiento" runat="server" CssClass="textbox"></asp:TextBox> 
                                <asp:Button ID="btnImputar" runat="server" CssClass="btnCkeckData" OnClick="CargarItemsCatalogo" Text=" " ToolTip="Cargar Medicamento" />
                            </td>
                        </tr>
                                   
                    </table>
            <asp:GridView ID="grdDetalleReceta" runat="server" CssClass="gridView" AutoGenerateColumns="false" OnRowDataBound="CalcularVenta" >                   
                      <Columns>
                            <asp:BoundField DataField="Col1" HeaderText="N°" />
                            <asp:BoundField DataField="Col2" HeaderText="Código" /> 
                            <asp:BoundField DataField="Col3" HeaderText="Cantidad" />  
                            <asp:BoundField DataField="Col4" HeaderText="Descripcion" />                             
                            <asp:BoundField DataField="Col5" HeaderText="Concentración" /> 
                            <asp:BoundField DataField="Col6" HeaderText="Via Administración" /> 
                            <asp:BoundField DataField="Col7" HeaderText="Frecuencia" /> 
                            <asp:BoundField DataField="Col8" HeaderText="Tratamiento" />
                            <asp:BoundField DataField="Col9" HeaderText="Precio" /> 
                            <asp:BoundField DataField="Col10" HeaderText="IdGrupo" /> 
                            <asp:BoundField DataField="Col11" HeaderText="IdClase" /> 
                          <asp:TemplateField HeaderText="">
                         <ItemTemplate>
                             <asp:Button ID="btnBorrarFila" runat="server" CssClass="buttonIconDelete" ToolTip="Quitar artículo"  OnClick="BorrarFila" /> 
                         </ItemTemplate>
                
                      </asp:TemplateField>
                      </Columns>
                    </asp:GridView>
             <table style="float:right">
                    <tr> 
                        <td style="text-align:right">Monto Total:</td>
                        <td style="text-align:right"><asp:Label ID="lblTotalFacBol" runat="server" Text="0"></asp:Label></td>
                    </tr>
                </table>
               
        </fieldset>
             </td>
         </tr>       
     </table>
        
        <table style="margin:auto">
            <tr>
             <td><asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="button" OnClick="GuardarReceta"  />
                 <asp:Label ID="lblId_Receta" runat="server" Text="" CssClass="label"></asp:Label>
                 <asp:Label ID="lblMsj" runat="server" Text="" ForeColor="Green" Font-Bold="true"></asp:Label>
             </td>
             <td>                 
                 <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" CssClass="button" OnClientClick="return PrintRecetaMedica()"  />
             </td>
         </tr>
        </table>
    </form>
</body>
</html>
