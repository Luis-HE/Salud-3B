<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmListar_CatalogoCie.aspx.cs" Inherits="CapaPresentacion.Forms.frmListar_CatalogoCie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript">
        function GetSelectedValue(cod_cie,descripcion)
        {
            var varcodCie = document.getElementById("<%= hdCodcie.ClientID %>");
            varcodCie.value = cod_cie;
           var varDescrip = document.getElementById("<%=hdDescripcion.ClientID%>");
            varDescrip.value = descripcion;
           
            window.opener.document.getElementById("txtCod_ciediez").value = varcodCie.value;
            window.opener.document.getElementById("txtNombre_ciediez").value = varDescrip.value;
            
            self.close();
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table style="margin:auto">
            <tr>
                <td>Nombre:</td>
                <td><asp:TextBox ID="txtFiltar_nombre" runat="server" Width="300px" CssClass="textbox"></asp:TextBox>
                    <asp:Button ID="btnBuscarCieDiez" runat="server" Text=" " CssClass="btnOpenPopup" ToolTip="Buscar" OnClick="BuscarCieDiez" />
                </td>
            </tr>
        </table>
        <asp:GridView ID="grdCatalogoCieDiez" runat="server" AutoGenerateColumns="false" CssClass="gridViewCita">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                         <a href="#" onclick="javascript:GetSelectedValue('<%# Eval("codigo_ciediez") %>','<%# Eval("nombre") %>');">Select</a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="codigo_ciediez" HeaderText="Código" />
                <asp:BoundField DataField="nombre" HeaderText="Descripción" />
            </Columns>
            <EmptyDataTemplate>
                        <table style="width:100%">
                            <tr>
                                <td>No data Found</td>
                            </tr>
                        </table>
                  </EmptyDataTemplate> 
        </asp:GridView>
        <asp:HiddenField ID="hdCodcie" runat="server" />
        <asp:HiddenField ID="hdDescripcion" runat="server" />
    </form>
</body>
</html>
