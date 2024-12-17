<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmListar_Proveedores.aspx.cs" Inherits="CapaPresentacion.Forms.frmListar_Proveedores" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/JQuery-1.4.2.min.js"></script>
    <script src="../Scripts/PasarConEnter.js"></script>
    <script src="../Scripts/SoloNumeros.js"></script>

    <script type="text/javascript">
        function GetSelectedValue(ruc,cod_persona,raz_social)
        {
            var varruc = document.getElementById("<%= hd_ruc.ClientID %>");
            varruc.value = ruc;
            var varcodPer = document.getElementById("<%=hd_CodPer.ClientID%>");
            varcodPer.value = cod_persona;
            var varrazsocial = document.getElementById("<%=hd_RazonSocial.ClientID%>");
            varrazsocial.value = raz_social;
           
            window.opener.document.getElementById("txt_ruc_proveedor").value = varruc.value;
            window.opener.document.getElementById("txt_cod_persona").value = varcodPer.value;
            window.opener.document.getElementById("txt_RazonSocial").value = varrazsocial.value;
            self.close();
         }
    </script>
</head>
<body>
    <form id="form1" runat="server">
     <table style="margin:auto">
        <tr>
            <td style="text-align:right">N° RUC:</td>
            <td><asp:TextBox ID="txtRuc_proveedor" runat="server" onkeyPress="return soloNumeros(event)" MaxLength="11" CssClass="textbox" Width="100px"></asp:TextBox>
                <asp:Button ID="btnBuscarProveedor" runat="server" Text=" " CssClass="btnOpenPopup" OnClick="BuscarProveedores" />
            </td>
        </tr>
        <tr>
            <td style="text-align:right">Razon Social:</td>
            <td><asp:TextBox ID="txtRazon_social" runat="server" CssClass="textbox" Width="400px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align:right">Razon Comercial:</td>
            <td><asp:TextBox ID="txtRazon_comercial" runat="server" CssClass="textbox" Width="400px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align:right">Dirección:</td>
            <td><asp:TextBox ID="txtDireccion" runat="server" CssClass="textbox" Width="400px"></asp:TextBox></td>
        </tr>
         <tr>
            <td style="text-align:right">Teléfono:</td>
            <td><asp:TextBox ID="txtTelefono" runat="server" CssClass="textbox" Width="100px"></asp:TextBox></td>
        </tr>
         <tr>
            <td style="text-align:right">E-mail:</td>
            <td><asp:TextBox ID="txtEmail" runat="server" CssClass="textbox" Width="400px"></asp:TextBox></td>
        </tr>
         
        <tr>
            <td style="text-align:right">Representante:</td>
            <td><asp:TextBox ID="txtContacto" runat="server" CssClass="textbox" Width="400px"></asp:TextBox></td>
        </tr>    
        <tr>
            <td></td>
            <td><asp:Button ID="btnGuardar" runat="server" Text="Guardar"  CssClass="button" OnClick="GuardarProveedor" /></td>
        </tr>
         
    </table>
    <asp:GridView ID="grdProveedores" runat="server" AutoGenerateColumns="false" CssClass="gridViewCita">
           <Columns>
               <asp:TemplateField>
                    <ItemTemplate>
                         <a href="#" onclick="javascript:GetSelectedValue(<%# Eval("ruc_proveedor") %>, <%# Eval("cod_persona_pago") %> ,'<%# Eval("razon_social") %>');">Select</a>
                    </ItemTemplate>
                </asp:TemplateField>
               <asp:BoundField DataField="ruc_proveedor" HeaderText="RUC" />
               <asp:BoundField DataField="cod_persona_pago" HeaderText="Cod." />
               <asp:BoundField DataField="razon_social" HeaderText="Razon Social" />
               
           </Columns>
            <EmptyDataTemplate>
                        <table style="width:100%">
                            <tr>
                                <td>No data Found</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate> 
        </asp:GridView>
        <asp:HiddenField ID="hd_ruc" runat="server" />
         <asp:HiddenField ID="hd_CodPer" runat="server" />
        <asp:HiddenField ID="hd_RazonSocial" runat="server" />
    </form>
</body>
</html>
