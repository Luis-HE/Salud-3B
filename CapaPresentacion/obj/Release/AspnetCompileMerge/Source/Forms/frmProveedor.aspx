<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmProveedor.aspx.cs" Inherits="CapaPresentacion.Forms.frmProveedor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/JQuery-1.4.2.min.js"></script>
    <script src="../Scripts/PasarConEnter.js"></script>
    <script src="../Scripts/SoloNumeros.js"></script>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <table style="margin-top:-2px; margin-left:-2px;" >
        <tr>
            <td><img alt="" src="../Images/barra_menu.png" width="1060" height="25" style="margin-top:-2px;margin-left:-2px" /> </td>
            <td > <asp:Button ID="btnCerrarPantalla" runat="server" Text=" " CssClass="btnCloseWindow" CausesValidation="false" OnClick="CerrarPantalla" /> </td>
        </tr>
    </table>

    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
        <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanelProveedor" ID="tbProveedor">
         <HeaderTemplate><asp:Label ID="Label1" runat="server" Text="Registro de Proveedores" Width="150px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
        <ContentTemplate>
            <table>
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
            <td><asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="button" OnClick="GuardarProveedor" />
               
            </td>
        </tr>
    </table> 
            <asp:GridView ID="grdProveedores" runat="server" AutoGenerateColumns="false" CssClass="gridViewCita">
           <Columns>
               <asp:BoundField DataField="ruc_proveedor" HeaderText="RUC" />
                 <asp:TemplateField HeaderText="Razon Social">
                     <ItemTemplate>
                      <asp:TextBox ID="txtRazonsocial" runat="server" Width="200px" Text='<%# Eval("razon_social")%>'></asp:TextBox>
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
               <asp:TemplateField HeaderText="Email">
                     <ItemTemplate>
                      <asp:TextBox ID="txtemail" runat="server" Width="150px" Text='<%# Eval("email")%>'></asp:TextBox>
                   </ItemTemplate>                      
                </asp:TemplateField>
               <asp:TemplateField HeaderText="Teléfono">
                     <ItemTemplate>
                      <asp:TextBox ID="txttelefono" runat="server" Width="100px" Text='<%# Eval("telefono")%>'></asp:TextBox>
                   </ItemTemplate>                      
                </asp:TemplateField>
               <asp:TemplateField HeaderText="Representante Legal">
                     <ItemTemplate>
                      <asp:TextBox ID="txtrepresentante" runat="server" Width="200px" Text='<%# Eval("representante")%>'></asp:TextBox>
                   </ItemTemplate>                     
                </asp:TemplateField>
                <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnEditar" runat="server" CssClass="buttonIconEdit" OnClick="ModificarProveedor" ToolTip="Modificar" />
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
        </ContentTemplate>
     </ajaxToolkit:TabPanel>
     <ajaxToolkit:TabPanel runat="server" HeaderText="TabreporteProveedor" ID="tbReporteProveedor">
         <HeaderTemplate><asp:Label ID="Label2" runat="server" Text="Reporte de Proveedores" Width="150px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
         <ContentTemplate>
             <table style="margin:auto">
                 <tr>
                     <td>
                         <asp:Button ID="btnReporteProveedor" runat="server" Text="Listar Proveedor" CssClass="button" OnClick="Listarproveedores" />
                         <asp:Button ID="btnExportarExcel" runat="server" Text="Exportar a Excel" CssClass="button" OnClick="ExportarExcel" />
                     </td>
                 </tr>
             </table>
             <asp:GridView ID="grdReporteProveedores" runat="server" AutoGenerateColumns="false" CssClass="gridView">
                 <Columns>
                     <asp:BoundField DataField="ruc_proveedor" HeaderText="RUC" />
                     <asp:BoundField DataField="razon_social" HeaderText="Razon Social" />
                     <asp:BoundField DataField="razon_comercial" HeaderText="Razon Comercial" />
                     <asp:BoundField DataField="direccion" HeaderText="Dirección" />
                     <asp:BoundField DataField="email" HeaderText="Email" />
                     <asp:BoundField DataField="telefono" HeaderText="Telefóno" />
                     <asp:BoundField DataField="representante" HeaderText="Representante" />

                 </Columns>
             </asp:GridView>
         </ContentTemplate>
     </ajaxToolkit:TabPanel>


    </ajaxToolkit:TabContainer>
</asp:Content>

