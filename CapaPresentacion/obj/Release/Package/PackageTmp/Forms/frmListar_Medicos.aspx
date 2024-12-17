<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmListar_Medicos.aspx.cs" Inherits="CapaPresentacion.Forms.frmListar_Medicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function GetSelectedValue(dni,apellidos,nombres)
        {
            var vardni = document.getElementById("<%= hd_dni.ClientID %>");
            vardni.value = dni;
            var varapellidos = document.getElementById("<%=hd_apellidos.ClientID%>");
            varapellidos.value = apellidos;
             var varnombres = document.getElementById("<%=hd_nombres.ClientID%>");
            varnombres.value = nombres;

            window.opener.document.getElementById("txtDni_empleado").value = vardni.value;
            window.opener.document.getElementById("txtNombre_empleado").value = varapellidos.value + ' ' + varnombres.value;
 
            self.close();
         }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <table style="margin:auto">
            <tr>
                <td style="text-align:right">Área:</td>
                <td>
                    <asp:DropDownList ID="drpArea" runat="server" CssClass="dropDownList" Width="150px"></asp:DropDownList>

                </td>

            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnBuscarMedico" runat="server" Text="Buscar" CssClass="button" OnClick="BuscarEmpleado" /></td>
            </tr>
        </table>
        <asp:GridView ID="grdMedicos" runat="server" AutoGenerateColumns="false" CssClass="gridViewCita">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                         <a href="#" onclick="javascript:GetSelectedValue('<%# Eval("dni_empleado") %>','<%# Eval("apellidos") %>','<%# Eval("nombres") %>');">Select</a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="dni_empleado" HeaderText="DNI" />
                <asp:BoundField DataField="apellidos" HeaderText="Apellidos" />
                <asp:BoundField DataField="nombres" HeaderText="Nombres" />
            </Columns>
            <EmptyDataTemplate>
                        <table style="width:100%">
                            <tr>
                                <td>No data Found</td>
                            </tr>
                        </table>
            </EmptyDataTemplate> 
        </asp:GridView>
        <asp:HiddenField ID="hd_dni" runat="server" />
        <asp:HiddenField ID="hd_apellidos" runat="server" />
        <asp:HiddenField ID="hd_nombres" runat="server" />
    </form>
</body>
</html>
