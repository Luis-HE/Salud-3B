<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmListar_ClienteEmpresa.aspx.cs" Inherits="CapaPresentacion.Forms.frmListar_ClienteEmpresa" %>

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
        function GetSelectedValue(ruc,raz_social,direccion)
        {
            var varruc = document.getElementById("<%= hd_ruc.ClientID %>");
            varruc.value = ruc;
           var varrazsocial = document.getElementById("<%=hd_RazonSocial.ClientID%>");
            varrazsocial.value = raz_social;
           var vardir = document.getElementById("<%=hd_Direccion.ClientID%>");
            vardir.value = direccion;
            window.opener.document.getElementById("txtRuc_factura").value = varruc.value;
            window.opener.document.getElementById("txtCliente_factura").value = varrazsocial.value;
            window.opener.document.getElementById("txtDir_factura").value = vardir.value;

            self.close();
         }
    </script>
</head>
<body>
    <form id="form1" runat="server">
         <table style="margin:auto">
        <tr>
            <td style="text-align:right">N° RUC:</td>
            <td><asp:TextBox ID="txtRuc_cliente" runat="server" onkeyPress="return soloNumeros(event)" MaxLength="11" CssClass="textbox" Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRuc_cliente" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ErrorMessage="completar..."></asp:RequiredFieldValidator>
                <asp:Button ID="btnBuscarClienteEmpresa" runat="server" Text=" " CssClass="btnOpenPopup" OnClick="btnBuscarClienteEmpresa_Click" CausesValidation="false" />
            </td>
        </tr>
        <tr>
            <td style="text-align:right">Razon Social:</td>
            <td><asp:TextBox ID="txtRazon_social" runat="server" CssClass="textbox" Width="400px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRazon_social" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ErrorMessage="completar..."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align:right">Razon Comercial:</td>
            <td><asp:TextBox ID="txtRazon_comercial" runat="server" CssClass="textbox" Width="400px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align:right">Dirección:</td>
            <td><asp:TextBox ID="txtDireccion" runat="server" CssClass="textbox" Width="400px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDireccion" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ErrorMessage="completar..."></asp:RequiredFieldValidator>
            </td>
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
            <td style="text-align:right">Contacto:</td>
            <td><asp:TextBox ID="txtContacto" runat="server" CssClass="textbox" Width="400px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtContacto" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ErrorMessage="completar..."></asp:RequiredFieldValidator>
            </td>
        </tr>    
        <tr>
            <td></td>
            <td><asp:Button ID="btnGuardar" runat="server" Text="Guardar"  CssClass="button" OnClick="btnGuardar_Click" /></td>
        </tr>
         
    </table>
    <asp:GridView ID="grdClienteEmpresas" runat="server" AutoGenerateColumns="false" CssClass="gridViewCita">
           <Columns>
               <asp:TemplateField>
                    <ItemTemplate>
                         <a href="#" onclick="javascript:GetSelectedValue(<%# Eval("ruc_cliente") %>,'<%# Eval("razon_social") %>','<%# Eval("direccion") %>');">Select</a>
                    </ItemTemplate>
                </asp:TemplateField>
               <asp:BoundField DataField="ruc_cliente" HeaderText="RUC" />
               <asp:BoundField DataField="razon_social" HeaderText="Razon Social" />
               <asp:BoundField DataField="direccion" HeaderText="Dirección" />
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
        <asp:HiddenField ID="hd_RazonSocial" runat="server" />
        <asp:HiddenField ID="hd_Direccion" runat="server" />
        
    </form>
</body>
</html>
