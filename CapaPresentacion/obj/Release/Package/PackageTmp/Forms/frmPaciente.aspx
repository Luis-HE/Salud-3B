<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmPaciente.aspx.cs" Inherits="CapaPresentacion.Forms.frmPaciente" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/SoloNumeros.js"></script>


    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   <table style="margin-top:-2px; margin-left:-2px; width:100%;" >
        <tr>
            <td style="width:99%;" ><img alt="" src="../Images/barra_menu.png"  style="margin-top:-2px;margin-left:-2px; width:100%; height:25px;" /> </td>
            <td style="width:1%;"> <asp:Button ID="btnCerrarPantalla" runat="server" Text=" " CssClass="btnCloseWindow" CausesValidation="false" OnClick="CerrarPantalla" /> </td>
        </tr>
    </table>
    
     <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
        <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanelPacientes" ID="tbPanelPaciente">
         <HeaderTemplate><asp:Label ID="Label1" runat="server" Text="Administrar Pacientes" Width="150px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
        <ContentTemplate>
     <table>
         <tr>
            <td style="text-align:right">N° DNI:</td>
            <td><asp:TextBox ID="txtDni_cliente" runat="server" onkeyPress="return soloNumeros(event)" MaxLength="8" CssClass="textbox" Width="100px"></asp:TextBox>
                <asp:Button ID="btnBuscarClientePersona" runat="server" Text=" " CssClass="btnOpenPopup" OnClick="BuscarClientePersona" CausesValidation="false" />
            </td>
        </tr>
       <%-- <tr>
            <td style="text-align:right">Apellido Paterno:</td>
            <td><asp:TextBox ID="txtApel_paterno" runat="server" CssClass="textbox" Width="300px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align:right">Apellido Materno:</td>
            <td><asp:TextBox ID="txtapel_materno" runat="server" CssClass="textbox" Width="300px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align:right">Nombres:</td>
            <td><asp:TextBox ID="txtNombre_cliente" runat="server" CssClass="textbox" Width="300px"></asp:TextBox></td>
        </tr>
        
         <tr>
            <td style="text-align:right">E-mail:</td>
            <td><asp:TextBox ID="txtEmail" runat="server" CssClass="textbox" Width="300px"></asp:TextBox></td>
        </tr>
         <tr>
            <td style="text-align:right">Dirección:</td>
            <td><asp:TextBox ID="txtDireccion" runat="server" CssClass="textbox" Width="300px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align:right">Fecha Nacimiento:</td>
            <td><asp:TextBox ID="txtFecha_nace" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFecha_nace" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" />
                <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlToValidate="txtFecha_nace" ControlExtender="MaskedEditExtender1" IsValidEmpty="false" EmptyValueMessage="Ingrese fecha" InvalidValueMessage="Error fecha" ForeColor="Red"></ajaxToolkit:MaskedEditValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align:right">Telefono fijo:</td>
            <td><asp:TextBox ID="txttelef_fijo" runat="server" CssClass="textbox" Width="100px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align:right">Telefono Movil:</td>
            <td><asp:TextBox ID="txtTelef_movil" runat="server" CssClass="textbox" Width="100px"></asp:TextBox></td>
        </tr>
       
        <tr>
            <td style="text-align:right">Género:</td>
            <td><asp:DropDownList ID="drpGenero" runat="server" CssClass="dropDownList" Width="110px">
                <asp:ListItem Value="1">Masculino</asp:ListItem>
                <asp:ListItem Value="2">Femenino</asp:ListItem>
                </asp:DropDownList> </td>
        </tr>        
         <tr>
            <td style="text-align:right">Grupo sanguíneo:</td>
            <td><asp:TextBox ID="txtGrupo_sanguineo" runat="server" CssClass="textbox" Width="100px"></asp:TextBox></td>
        </tr>
         
        <tr>
            <td></td>
            <td><asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="button" OnClick="btnGuardar_Click" />
                 
            </td>
        </tr>--%>
    </table>
     <asp:GridView ID="grdClientePersonas" runat="server" AutoGenerateColumns="false" CssClass="gridViewCita">
           <Columns>
            <asp:BoundField DataField="num_doc_cliente" HeaderText="DNI" />
             
            <asp:TemplateField HeaderText="Apellido Paterno">
             <ItemTemplate>
                 <asp:TextBox ID="txtapaterno" runat="server" Width="100px" Text='<%# Eval("apellido_paterno")%>'></asp:TextBox>
             </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Apellido Materno">
             <ItemTemplate>
                 <asp:TextBox ID="txtamaterno" runat="server" Width="100px" Text='<%# Eval("apellido_materno")%>'></asp:TextBox>
             </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombres">
             <ItemTemplate>
                 <asp:TextBox ID="txtnombres" runat="server" Width="100px" Text='<%# Eval("nombres")%>'></asp:TextBox>
             </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Telefono">
             <ItemTemplate>
                 <asp:TextBox ID="txttelefono" runat="server" Width="50px" Text='<%# Eval("telefono1")%>'></asp:TextBox>
             </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Email">
             <ItemTemplate>
                 <asp:TextBox ID="txtemail" runat="server" Width="150px" Text='<%# Eval("email")%>'></asp:TextBox>
             </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Celular">
             <ItemTemplate>
                 <asp:TextBox ID="txtcelular" runat="server" Width="100px" Text='<%# Eval("telefono2")%>'></asp:TextBox>
             </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Género">
             <ItemTemplate>
                 <asp:TextBox ID="txtgenero" runat="server" Width="100px" Text='<%# Eval("genero")%>'></asp:TextBox>
             </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Dirección">
             <ItemTemplate>
                 <asp:TextBox ID="txtdirecion" runat="server" Width="200px" Text='<%# Eval("direccion")%>'></asp:TextBox>
             </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Grupo Sanguíneo">
             <ItemTemplate>
                 <asp:TextBox ID="txtGrupoSang" runat="server" Width="50px" Text='<%# Eval("grupo_sanguineo")%>'></asp:TextBox>
             </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fec. Nacimiento">
             <ItemTemplate>
                 <asp:TextBox ID="txtfechanace" runat="server" Width="100px" Text='<%# Eval("fecha_nace")%>'></asp:TextBox>
             </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnEditar" runat="server" CssClass="buttonIconEdit" OnClick="ModificarPaciente" ToolTip="Modificar" CausesValidation="false" />
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
       <ajaxToolkit:TabPanel runat="server" HeaderText="TabReportePacientes" ID="tbPanelReportePaciente">
         <HeaderTemplate><asp:Label ID="Label2" runat="server" Text="Reporte de Pacientes" Width="150px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
         <ContentTemplate>
             <table style="margin:auto">
                 <tr>
                     <td>
                          <asp:Button ID="btnListarPacientes" runat="server" CssClass="button" Text="Listar Pacientes" OnClick="ListarPacientes" CausesValidation="false"  />
                          <asp:Button ID="btnExportarExcel" runat="server" CssClass="button" Text="Exportar a Excel" OnClick="ExportarExcel" CausesValidation="false"  />
                     </td>
                 </tr>
             </table>
             <asp:GridView ID="grdReportedePacientes" runat="server" AutoGenerateColumns="false" CssClass="gridView">
                 <Columns>
                     <asp:BoundField DataField="num_doc_cliente" HeaderText="DNI" />
                     <asp:BoundField DataField="apellido_paterno" HeaderText="Apellido Paterno" />
                     <asp:BoundField DataField="apellido_materno" HeaderText="Apellido Materno" />
                     <asp:BoundField DataField="nombres" HeaderText="Nombres" />
                     <asp:BoundField DataField="fecha_nace" HeaderText="Fecha Nac." />
                     <asp:BoundField DataField="telefono1" HeaderText="Teléfono" />
                     <asp:BoundField DataField="telefono2" HeaderText="Celular" />
                     <asp:BoundField DataField="email" HeaderText="Email" />
                     <asp:BoundField DataField="direccion" HeaderText="Dirección" />
                     <asp:BoundField DataField="grupo_sanguineo" HeaderText="Grupo Sanguíneo" />
                     <asp:BoundField DataField="genero" HeaderText="Género" />
                 </Columns>
             </asp:GridView>
         </ContentTemplate>
     </ajaxToolkit:TabPanel>

    </ajaxToolkit:TabContainer>


</asp:Content>
 
