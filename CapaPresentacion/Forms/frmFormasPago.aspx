<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmFormasPago.aspx.cs" Inherits="CapaPresentacion.Forms.frmFormasPago" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function GetValuesCaja()
        {
            var numDoc = document.getElementById("<%= txtNumero_doc.ClientID %>");
            var serie = document.getElementById("<%= txtSerie_doc.ClientID %>");
            var tipoDoc = document.getElementById("<%= txtTipo_doc.ClientID %>");
            var UnidNegocio = document.getElementById("<%= txtUnidadnegocio.ClientID %>");
          
            numDoc.value = window.opener.document.getElementById("lblNum_doc_cobranza").innerHTML;
            serie.value = window.opener.document.getElementById("lblSerie_cobranza").innerHTML;
            tipoDoc.value = window.opener.document.getElementById("drpTipoDocumento").value;
            UnidNegocio.value = window.opener.document.getElementById("drpUnidadNegocio").value;
 
        }
        function CerrarPantalla()
        {
            window.close();
        }
    </script>
</head>
<body onload="GetValuesCaja()">
    <form id="form1" runat="server">
     <table style="margin:auto">
         <tr>
             <td style="text-align:right">Unidad de Negocio:</td>
             <td><asp:TextBox ID="txtUnidadnegocio" runat="server" CssClass="textBoxDisabled" Width="50px" ClientIDMode="Static"></asp:TextBox></td>
         </tr>
         <tr>
             <td style="text-align:right">N° de Documento</td>
             <td><asp:TextBox ID="txtTipo_doc" runat="server" CssClass="textBoxDisabled" Width="50px" ClientIDMode="Static"></asp:TextBox>
                 <asp:TextBox ID="txtSerie_doc" runat="server" CssClass="textBoxDisabled" Width="50px" ClientIDMode="Static"></asp:TextBox>
                 <asp:TextBox ID="txtNumero_doc" runat="server" CssClass="textBoxDisabled" Width="100px" ClientIDMode="Static" ></asp:TextBox>
             </td>
         </tr>
         <tr>
             <td style="text-align:right">Monto pagado:</td>
             <td><asp:TextBox ID="txtMonto_pago" runat="server" Width="115px" CssClass="txtboxNumber" Text="0"></asp:TextBox></td>
         </tr>
         <tr>
             <td style="text-align: right">Forma de pago:</td>
             <td><asp:DropDownList ID="drpFormapago" runat="server" CssClass="dropDownList" Width="235px">
                 <asp:ListItem Value="1">Efectivo</asp:ListItem>
                 <asp:ListItem Value="2">Tarjeta de Débito</asp:ListItem>
                 <asp:ListItem Value="3">Tarjeta de Crédito</asp:ListItem>
                 </asp:DropDownList></td>
         </tr>
         <tr>
             <td style="text-align:right">Tipo de Moneda:</td>
             <td><asp:DropDownList ID="drpTipomoneda" runat="server" CssClass="dropDownList" Width="235px">
                 <asp:ListItem Value="1">Soles</asp:ListItem>
                 <asp:ListItem Value="2">Dolares</asp:ListItem>
                 </asp:DropDownList></td>
         </tr>
         
         <tr>
             <td></td>
             <td>
                 <asp:Button ID="btnMostrarLista" runat="server" Text="Listar" CssClass="button" OnClick="Listarregostros" />
                 <asp:Button ID="btnGuardarFormaPago" runat="server" Text="Guardar" CssClass="button" OnClick="GuardarFormaPago" />
                 <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" CssClass="button" OnClientClick="CerrarPantalla()" />
             </td>
         </tr>
     </table>
        <asp:GridView ID="grdFormasPago" runat="server" AutoGenerateColumns="false" CssClass="gridView">
            <Columns>
                <asp:BoundField DataField="id_reg_formapago" HeaderText="Id" />
                <asp:BoundField DataField="fecha_pago" HeaderText="Fecha de Pago" />
                <asp:BoundField DataField="monto_pago" HeaderText="Monto" />
                <asp:BoundField DataField="forma_de_pago" HeaderText="Forma" />
                <asp:BoundField DataField="tipo_moneda" HeaderText="Moneda" />
                <asp:BoundField DataField="numero_documento" HeaderText="N° Documento" />
                <asp:BoundField DataField="serie" HeaderText="Serie" />
                <asp:BoundField DataField="tipo_documento" HeaderText="Tipo Doc." />
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Button ID="btnBorrarFila" runat="server"   CssClass ="buttonIconDelete" ToolTip="Borrar Registro" OnClick="BorrarFila" />
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
    </form>
</body>
</html>
