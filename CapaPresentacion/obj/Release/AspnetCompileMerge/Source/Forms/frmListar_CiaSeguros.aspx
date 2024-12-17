<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmListar_CiaSeguros.aspx.cs" Inherits="CapaPresentacion.Forms.frmListar_CiaSeguros" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
   <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function GetSelectedValue(Id_cia,ruc_pro, nombre_prov)
        {
            var idcia = document.getElementById("<%= hd_idcia.ClientID %>");
            idcia.value = Id_cia;
           var ruc = document.getElementById("<%=hd_ruc.ClientID%>");
            ruc.value = ruc_pro;
           var nombrePro = document.getElementById("<%=hd_nombre.ClientID%>");
            nombrePro.value = nombre_prov;
            window.opener.document.getElementById("txt_Id_cia_seguro").value = idcia.value;
            window.opener.document.getElementById("txtRuc_cia").value = ruc.value;
            window.opener.document.getElementById("txtNombre_cia").value = nombrePro.value;

            self.close();
         }
    </script>
</head>
<body>
    <form id="form1" runat="server">
 
        <asp:GridView ID="grdListaProveedorSeguro" runat="server" AutoGenerateColumns="false" CssClass="gridViewCita" >
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                         <a href="#" onclick="javascript:GetSelectedValue(<%# Eval("id_cia_seguro") %>,<%# Eval("ruc_proveedor") %>,'<%# Eval("nombre_seguro") %>');">Select</a>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:BoundField DataField="id_cia_seguro" HeaderText="Id" />
                 <asp:BoundField DataField="ruc_proveedor" HeaderText="Ruc" />
                 <asp:BoundField DataField="nombre_seguro" HeaderText="Nombre" />
            </Columns>
            <EmptyDataTemplate>
                        <table style="width:100%">
                            <tr>
                                <td>No data Found</td>
                            </tr>
                        </table>
                  </EmptyDataTemplate> 
        </asp:GridView>
  
        <asp:HiddenField ID="hd_idcia" runat="server" />
        <asp:HiddenField ID="hd_ruc" runat="server" />
        <asp:HiddenField ID="hd_nombre" runat="server" />
    </form>
</body>
</html>
