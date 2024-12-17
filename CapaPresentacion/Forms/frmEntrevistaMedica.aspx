<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmEntrevistaMedica.aspx.cs" Inherits="CapaPresentacion.Forms.frmEntrevistaMedica" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
 <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
 <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript" src="../Scripts/jquery.min.js"> </script>
<script type="text/javascript">
   $(document).ready(function() {
       //$('input[type="text"]').attr("disabled", "disabled");// to disable all textbox, color gray by defaul. But makes it empty to value of control
       $("#txtDni_empleado").attr("readonly", true);
       $("#txt_codPersona_pago").attr("readonly", true);
       $("#txtNombre_empleado").attr("readonly", true);

       $("#txtCod_ciediez").attr("readonly", true);
       $("#txtNombre_ciediez").attr("readonly", true);
 
    return false; //to prevent from postback
    });
</script>
 <script type="text/javascript"> 
     function OpenListMedicosReferentes()
    {
        window.open("../Forms/frmListar_Medicos_Referentes.aspx", 'Lista Medicos', 'height=550,width=600,left=265,top=165,resizable=No,toolbar=No')
    }
    function OpenListCatalogoCie()
    {
        window.open("../Forms/frmListar_CatalogoCie.aspx", 'Lista Cie10', 'height=550,width=600,left=265,top=165,resizable=No,toolbar=No')
    }
    function OpenListEmpleados()
    {
        window.open("../Forms/frmListar_Medicos.aspx", 'Lista Empresas', 'height=550,width=600,left=265,top=165,resizable=No,toolbar=No')
    }
</script>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
        <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanelEntrevista" ID="tbPanelEntrevista">
         <HeaderTemplate><asp:Label ID="Label1" runat="server" Text="Entrevista Médica" Width="150px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
        <ContentTemplate>
            <table style="margin:auto">
               <tr>
                    <td></td>
                    <td></td>
                </tr>  
              </table>
            <asp:GridView ID="grdListaPacientesAdmitidos" runat="server" CssClass="gridViewCita" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="numero_admision" HeaderText="N° admin." />
                    <asp:BoundField DataField="fecha_admision" HeaderText="Fecha y Hora" />
                    <asp:BoundField DataField="paciente" HeaderText="Paciente" />
                    <asp:BoundField DataField="descripcion_item" HeaderText="Descripción" />
                    <asp:BoundField DataField="tipo_admision" HeaderText="Tipo admisión" />
                    <asp:BoundField DataField="tipo_paciente" HeaderText="Tipo paciente" />
                    <asp:BoundField DataField="fecha_nace" HeaderText="Fecha nacimiento" />
                    <asp:BoundField DataField="grupo_sanguineo" HeaderText="G. Sanguineo" />
            <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnVerDetalle" runat="server" CssClass="btnOpenPopup"  ToolTip="Detalles" OnClick="VerDetallesAdmision"/>
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
        <table>
            <tr>
                <td style="text-align:right">Medico que refiere:</td>
                <td><asp:TextBox ID="txt_cmp" runat="server" Width="100px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                    <asp:Button ID="btnBuscarMedicoReferente" runat="server" Text=" " CssClass="btnOpenPopup" OnClientClick="OpenListMedicosReferentes()" ToolTip="Buscar Médicos"/>
                    <asp:TextBox ID="txtNombeMedico" runat="server" Width="300px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                    
                </td>
            </tr>
            <tr>
                <td style="text-align:right">Orden Médica</td>
                <td><asp:TextBox ID="TextBox1" runat="server" CssClass="textbox" Width="400px" Height="50px" TextMode="MultiLine"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">Alérgias:</td>
                <td><asp:TextBox ID="TextBox2" runat="server" CssClass="textbox" Width="400px"></asp:TextBox></td>
            </tr>
           <tr>
                <td style="text-align:right">Historia de las Molestias:</td>
                <td><asp:TextBox ID="TextBox3" runat="server" CssClass="textbox" Width="400px" Height="50px" TextMode="MultiLine"></asp:TextBox></td>
           </tr>
            <tr>
                <td style="text-align:right">Tecnólogo:</td>
                <td><asp:TextBox ID="txtDni_empleado" runat="server" Width="100px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                    <asp:Button ID="btnBuscarMedico" runat="server" Text=" " CssClass="btnOpenPopup" OnClientClick="OpenListEmpleados()" ToolTip="Buscar Médicos"/>
                    <asp:TextBox ID="txtCodPersona_pago" runat="server" Width="20px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                    <asp:TextBox ID="txtNombre_empleado" runat="server" Width="235px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                </td>
            </tr>
             <tr>
                 <td></td>
                 <td><asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="button" OnClick="GuardarEntrevistaMedica" />
                     <asp:Button ID="btnCerrarEntrevista" runat="server" Text="Cerrar" CssClass="button" OnClick="CerrarEntrevista" />
                 </td>
             </tr>
        </table>


        </ContentTemplate>
     </ajaxToolkit:TabPanel>
     <ajaxToolkit:TabPanel runat="server" HeaderText="TabImagenes" ID="tbPanelImagenes">
         <HeaderTemplate><asp:Label ID="Label2" runat="server" Text="Imágenes Médicas" Width="150px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
         <ContentTemplate>

         </ContentTemplate>
     </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>

</asp:Content>
 
