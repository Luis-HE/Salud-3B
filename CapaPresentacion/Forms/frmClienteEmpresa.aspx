<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmClienteEmpresa.aspx.cs" Inherits="CapaPresentacion.Forms.frmClienteEmpresa" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script src="../Scripts/JQuery-1.4.2.min.js"></script>
    <script src="../Scripts/PasarConEnter.js"></script>
    <script src="../Scripts/SoloNumeros.js"></script>
    <script type="text/javascript" src="../Scripts/noty/jquery-1.8.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/noty/packaged/jqueryNotify.js"></script>
    <script type="text/javascript" src="../Scripts/noty/PopUpMessage.js"></script>

    <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
 
    <script type="text/javascript">
        function ValidarNulls()
        {
            var strRuc = document.getElementById("<%=txtruc.ClientID%>");
            if (strRuc.value.length == 0) {
                PopUpMessage('error', "mensaje rojo");
                strRuc.focus();
                return false; 
            }
            else
                return true;
            
        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <fieldset class="fieldset">
        <legend class="legend">Registro de Clientes</legend>
    <table>
        <tr>
            <td style="text-align:right">Ruc:</td>
            <td><asp:TextBox ID="txtruc" runat="server" CssClass="textbox" Width="100px" MaxLength="11" onkeyPress="return soloNumeros(event)"></asp:TextBox>
                <asp:Button ID="btnBuscarClienteEmpresa" runat="server" Text=" " CssClass="btnOpenPopup" OnClick="BuscarClienteEmpresa" />
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
            <td style="text-align:right">Contacto:</td>
            <td><asp:TextBox ID="txtContacto" runat="server" CssClass="textbox" Width="400px"></asp:TextBox></td>
        </tr>    
        <tr>
            <td></td>
            <td><asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="button" OnClick="btnGuardar_Click" OnClientClick="return ValidarNulls()" />
                <asp:Button ID="btnCerrar" runat="server" Text="Cerrar" CssClass="button" OnClick="btnCerrar_Click" />
            </td>
        </tr>
    </table>
   </fieldset>    
<asp:GridView ID="grdClientesEmpresas" runat="server" AutoGenerateColumns="false" CssClass="gridView"  >
            <Columns>
                <asp:BoundField DataField="ruc_cliente" HeaderText="RUC" />
                <asp:TemplateField HeaderText="Razon Social">
                    <ItemTemplate>
                        <asp:TextBox ID="txtrazonsocial" runat="server" Width="200px" Text='<%# Eval("razon_social")%>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Razon Comercial">
                    <ItemTemplate>
                        <asp:TextBox ID="txtrazoncomercial" runat="server" Width="200px" Text='<%# Eval("razon_comercial")%>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Dirección">
                    <ItemTemplate>
                        <asp:TextBox ID="txtdireccion" runat="server" Width="200px" Text='<%# Eval("direccion")%>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Teléfono">
                    <ItemTemplate>
                        <asp:TextBox ID="txttelefono" runat="server" Width="100px" Text='<%# Eval("telefono")%>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <asp:TextBox ID="txtemail" runat="server" Width="150px" Text='<%# Eval("email")%>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Contacto">
                    <ItemTemplate>
                        <asp:TextBox ID="txtcontacto" runat="server" Width="200px" Text='<%# Eval("contacto")%>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnEditar" runat="server" CssClass="buttonIconEdit" OnClick="ModificarClienteEmpresa" ToolTip="Modificar" />
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
</asp:Content>
 