<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmPersonal.aspx.cs" Inherits="CapaPresentacion.Forms.frmPersonal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript" src="../Scripts/jquery.min.js"> </script>
   <script type="text/javascript" src="../Scripts/SoloNumeros.js"></script>
  <script type="text/javascript" src="../Scripts/TexboxEnterNextControl.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <fieldset class="fieldset">
        <legend class="legend">Registro de Personal</legend>
        <table style="margin:auto">
        <tr>
            <td style="text-align:right">N° de DNI:</td>
            <td><asp:TextBox ID="txtDni" runat="server" CssClass="textbox" Width="100px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align:right">Apellidos:</td>
            <td><asp:TextBox ID="txtApellidos" runat="server" CssClass="textbox" Width="300px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align:right">Nombres:</td>
            <td><asp:TextBox ID="txtNombres" runat="server" CssClass="textbox" Width="300px"></asp:TextBox></td>
        </tr>
        <%--<tr>
            <td style="text-align:right">Area</td>
            <td><asp:DropDownList ID="drpArea" runat="server">

                </asp:DropDownList></td>
        </tr>--%>
        <tr>
            <td style="text-align:right">Teléfono:</td>
            <td><asp:TextBox ID="txtTelefono" runat="server" CssClass="textbox" Width="100px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align:right">Celular:</td>
            <td><asp:TextBox ID="txtCelular" runat="server" CssClass="textbox" Width="100px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align:right">Email:</td>
            <td><asp:TextBox ID="txtEmail" runat="server" CssClass="textbox" Width="300px"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btnGuardarEmpleado" runat="server" CssClass="button" Text="Guardar" OnClick="GuardarEmpleado" />
                <asp:Label ID="lblMsj" runat="server" Text="" ForeColor="Green" Font-Bold="true"></asp:Label>
                <asp:Button ID="btnListarEnpleado" runat="server" CssClass="button" Text="Listar Personal" OnClick="ListarEmpleado" />
                <asp:Button ID="btnCerrarEmpleado" runat="server" CssClass="button" Text="Cerrar" OnClick="CerrarPantalla" />
            </td>
        </tr>         
    </table>
    <asp:GridView ID="grdEmpleados" runat="server" AutoGenerateColumns="false" CssClass="gridView">
        <Columns>
            <asp:BoundField DataField="dni_empleado" HeaderText="DNI" />
            <asp:TemplateField HeaderText="Apellidos">
             <ItemTemplate>
                 <asp:TextBox ID="txtApellidos" runat="server" Width="200px"  Text='<%# Eval("apellidos")%>'></asp:TextBox>
             </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombres">
             <ItemTemplate>
                 <asp:TextBox ID="txtNombres" runat="server" Width="200px"  Text='<%# Eval("nombres")%>'></asp:TextBox>
             </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Teléfono">
             <ItemTemplate>
                 <asp:TextBox ID="txtTelefono" runat="server" Width="150px"  Text='<%# Eval("telefono")%>'></asp:TextBox>
             </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Celular">
             <ItemTemplate>
                 <asp:TextBox ID="txtCelular" runat="server" Width="150px"  Text='<%# Eval("celular")%>'></asp:TextBox>
             </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="E-mail">
             <ItemTemplate>
                 <asp:TextBox ID="txtEmail" runat="server" Width="200px"  Text='<%# Eval("email")%>'></asp:TextBox>
             </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnEditar" runat="server" CssClass="buttonIconEdit" OnClick="ModificarPersonal" ToolTip="Modificar" />
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
    </fieldset>
</asp:Content>