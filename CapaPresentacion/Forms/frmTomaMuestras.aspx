<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmTomaMuestras.aspx.cs" Inherits="CapaPresentacion.Forms.frmTomaMuestras" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
 <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
 <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />

<script type="text/javascript">
    function OpenListPacientes()
    {
        window.open("../Forms/frmListar_Pacientes.aspx", 'Lista Pacientes', 'height=650,width=600,left=265,top=0,resizable=No,toolbar=No')
    }
    function OpenListEmpleados()
    {
        window.open("../Forms/frmListar_Medicos.aspx", 'Lista Medicos', 'height=550,width=600,left=265,top=165,resizable=No,toolbar=No')
    }
    function OpenCatalogoItems()
    {
        window.open("../Forms/frmListar_Catalogo.aspx", 'Lista Items', 'height=550,width=800,left=265,top=165,resizable=No,toolbar=No')
    }
</script>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table style="margin-top:-2px; margin-left:-2px; width:100%;" >
        <tr>
            <td style="width:99%;" ><img alt="" src="../Images/barra_menu.png"  style="margin-top:-2px;margin-left:-2px; width:100%; height:25px;" /> </td>
            <td style="width:1%;"> <asp:Button ID="btnCerrarPantalla" runat="server" Text=" " CssClass="btnCloseWindow" CausesValidation="false" OnClick="CerrarPantalla" /> </td>
        </tr>
    </table>
    
     <table style="margin:auto">
             
             <tr>
                <td style="text-align:right">Médico:</td>
                <td><asp:TextBox ID="txtDni_empleado" runat="server"  Width="100px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDni_empleado" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ErrorMessage="completar..."></asp:RequiredFieldValidator>
                    <asp:Button ID="btnBuscarMedico" runat="server" Text=" " CssClass="btnOpenPopup" OnClientClick="OpenListEmpleados()" CausesValidation="false"/>
                    <asp:TextBox ID="txtNombre_empleado" runat="server" Width="235px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                </td>
            </tr>
         <tr>
             <td></td>
             <td>Procedencia Interna:
                 <asp:RadioButton ID="rdProcInterna" runat="server" Checked="true" CssClass="radioButton" GroupName="Grupo1" />
                 Procedencia Externa:
                 <asp:RadioButton ID="rdProcexterna" runat="server" CssClass="radioButton" GroupName="Grupo1" />
             </td>
         </tr>
                 <tr>
                    <td style="text-align:right">N° de DNI de paciente:</td>
                      <td><asp:TextBox ID="txtBuscaxDni" runat="server" Width="100px" CssClass="textbox" MaxLength="8" onkeyPress="return soloNumeros(event)"></asp:TextBox>
                      <asp:Button ID="btnBuscaPacienteAdmitido" runat="server" Text=" "  CssClass="btnOpenPopup" OnClick="BuscarPacienteAdmitido" ToolTip="Buscar Paciente" CausesValidation="False" /> 
                                  
                  </td>
                </tr>
                  
           </table>
    <asp:GridView ID="grdHistorialAtenciones" runat="server" CssClass="gridViewCita" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="VerDetalleAtencion" CausesValidation="false">Select</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="numero_admision" HeaderText="N° de Cuenta" />
             <asp:BoundField DataField="fecha_atencion" HeaderText="Fecha Atencion" />
            <asp:BoundField DataField="num_doc_cliente" HeaderText="DNI/CE" />            
            <asp:BoundField DataField="paciente" HeaderText="Paciente" />           
            <asp:BoundField DataField="direccion" HeaderText="Dirección" />
            <asp:BoundField DataField="anotaciones" HeaderText="Receta" />
            <asp:BoundField DataField="medico" HeaderText="Médico" />
            <asp:BoundField DataField="fecha_nace" HeaderText="Fecha Nace" />
            
        </Columns>
        <EmptyDataTemplate>
                        <table style="width:100%">
                            <tr>
                                <td>No data Found</td>
                            </tr>
                        </table>
        </EmptyDataTemplate> 
    </asp:GridView>

    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server">
         <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanelTomaMuestra" ID="tbPanelRealizaInforme">
         <HeaderTemplate><asp:Label ID="Label1" runat="server" Text="Toma de Muestras" Width="150px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
        <ContentTemplate>
            <table>
                <tr>
                    <td style="text-align:right">N° de DNI:</td>
                    <td><asp:TextBox ID="txtDni_cliente" runat="server" CssClass="textBoxDisabled" Width="60px" ClientIDMode="Static"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDni_cliente" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ErrorMessage="completar..."></asp:RequiredFieldValidator>
                        <%--<asp:Button ID="btnBuscarPaciente" runat="server" Text=" " CssClass="btnOpenPopup" ToolTip="Buscar Paciente" OnClientClick="OpenListPacientes()" CausesValidation="false" />--%>
                        <asp:TextBox ID="txtNombre_cliente" runat="server" CssClass="textBoxDisabled"  Width="410px" ClientIDMode="Static"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td style="text-align:right">Edad del Paciente:</td>
                    <td><asp:Label ID="lblEdad" runat="server"  CssClass="label" Width="100px"></asp:Label> años</td>
                </tr>
                <tr>
                    <td style="text-align:right">N° de Admision:</td>
                    <td><asp:Label ID="lblNumeroAdmision" runat="server" CssClass="label" Width="100px" Text="0" ></asp:Label></td>
                </tr>
                <tr>
                    <td style="text-align:right">N°  Historia Clinica:</td>
                    <td><asp:Label ID="lblHistoriaClinica" runat="server" CssClass="label" Width="100px" ></asp:Label></td>
                </tr>
                <tr>
                    <td>Fecha de Muestra:</td>
                    <td>
                        <asp:Label ID="lblfechaMuestra" runat="server"  CssClass="label" Width="100px"></asp:Label>
                        Hora: <asp:Label ID="lblHoraMuestra" runat="server" CssClass="label" Width="50px" ></asp:Label>
                    </td>
                </tr>
                
                <tr>
                    <td style="text-align:right">Usuario:</td>
                    <td><asp:Label ID="lblUsuario" runat="server" CssClass="label" Width="100px" ></asp:Label></td>
                </tr>
                <tr>
                     <td></td>
                    <td>
                        <fieldset>
                            <legend>detalle</legend>
                            <table>
                                <tr>
                                    <td>
                  <asp:GridView ID="grdDetalleLaboratorio" runat="server" CssClass="gridView" AutoGenerateColumns="false" OnRowDataBound="CalcularVenta" >                   
                     <Columns>
                            <asp:BoundField DataField="codigo_item_catalogo" HeaderText="Código"   />
                            <asp:TemplateField HeaderText="Cantidad">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtCantidad" runat="server" Width="40px" Text='<%# Eval("cantidad")%>'></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="descripcion_item" HeaderText="Descripción" HtmlEncode="false" />
                            <asp:BoundField DataField="precio_unitario" HeaderText="Precio Unit." />
                            <asp:BoundField DataField="precio_venta" HeaderText="Valor Venta" />
                            <asp:BoundField DataField="id_grupo" HeaderText="Grupo"   />
                            <asp:BoundField DataField="id_clase" HeaderText="Clase"   />
                          <asp:TemplateField HeaderText="">
                         <ItemTemplate>
                             <asp:CheckBox ID="chkAcepta" runat="server" Checked="true"  />
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
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </td>
                </tr>                
            </table>
        </ContentTemplate>
     </ajaxToolkit:TabPanel>
     <ajaxToolkit:TabPanel runat="server" HeaderText="TabInformeMedico" ID="tbPanelInformeMedico">
         <HeaderTemplate><asp:Label ID="Label2" runat="server" Text="Informe Médico" Width="150px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
         <ContentTemplate>

         </ContentTemplate>
     </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>
    <table style="margin:auto">
        <tr>
                    <td></td>
                    <td><asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="button" OnClick="GuardarLaboratorio" />
                        <asp:Label ID="lblMsj" runat="server" Text="" ForeColor="Green" Font-Bold="true"></asp:Label>
                        <asp:Label ID="lblIdRegLaboratorio" runat="server" Text="" CssClass="label"></asp:Label>                         
                    </td>
                     <td> <asp:Button ID="btnImprimirInforme" runat="server" Text="Generar Pdf" OnClick="Imprimir" CausesValidation="false" /> </td>
                    <td> <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="button" OnClick="Limpiar" CausesValidation="false" /> </td>
                </tr>
    </table>
</asp:Content>
 
