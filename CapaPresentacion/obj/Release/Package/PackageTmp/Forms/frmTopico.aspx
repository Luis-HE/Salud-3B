<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmTopico.aspx.cs" Inherits="CapaPresentacion.Forms.frmTopico" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
   <script type="text/javascript" src="../Scripts/jquery.min.js"> </script>
  <script type="text/javascript" src="../Scripts/TexboxEnterNextControl.js"></script>
 <script type="text/javascript"> 
    function OpenListEmpleados()
    {
        window.open("../Forms/frmListar_Medicos.aspx", 'Lista Empresas', 'height=550,width=600,left=265,top=165,resizable=No,toolbar=No')
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
                <td><asp:TextBox ID="txtDni_empleado" runat="server" Width="100px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtDni_empleado" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ErrorMessage="completar..."></asp:RequiredFieldValidator>
                    <asp:Button ID="btnBuscarMedico" runat="server" Text=" " CssClass="btnOpenPopup" OnClientClick="OpenListEmpleados()" CausesValidation="false"/>
                    <asp:TextBox ID="txtNombre_empleado" runat="server" Width="235px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                </td>
            </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btnRefrescar" runat="server" Text="Actualizar" CssClass="button" OnClick="RefrescarGridview" CausesValidation="false"/></td>
        </tr>
    </table>
    <asp:GridView ID="grdAdmitidos" runat="server" CssClass="gridViewCita" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="SelecionarRegistro" CausesValidation="false">Select</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            <asp:BoundField DataField="numero_admision" HeaderText="N° de Cuenta" />
            <asp:BoundField DataField="tipo_admision" HeaderText="Tipo admisión" />
            <asp:BoundField DataField="num_doc_cliente" HeaderText="N° Historia Clínica" />
            <asp:BoundField DataField="num_doc_cliente" HeaderText="DNI/CE" />
            <asp:BoundField DataField="paciente" HeaderText="Paciente" />
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
    
     <table>
         <tr>
             <td style="text-align:right">N° Historia Clinica:</td>
                <td><asp:Label ID="lblNumHistoria" runat="server" Text="" CssClass="label" Width="100px"></asp:Label></td>
           </tr>
         <tr>
             <td style="text-align:right">Filiacion:</td>
             <td><asp:TextBox ID="txtFiliacion" runat="server" Width="400px" CssClass="textbox"></asp:TextBox></td>
         </tr>
         <tr>
             <td style="text-align:right">Anamnesis, enfermedad actual, motivo principal de la consulta:</td>
             <td><asp:TextBox ID="txtAnamnesis" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode="MultiLine"></asp:TextBox></td>
         </tr>
         <tr>
             <td style="text-align:right">Antecedentes:</td>
             <td><asp:TextBox ID="txtAntecedentes" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode="MultiLine"></asp:TextBox></td>
         </tr>
         <tr>
             <td style="text-align:right">Examen físico:</td>
             <td><asp:TextBox ID="txtExamenFisico" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode="MultiLine"></asp:TextBox></td>
         </tr>
         <tr>
             <td style="text-align:right">Consentimiento Informado:</td>
             <td><asp:TextBox ID="txtIdConsentimientoInformado" runat="server" Text="0" Width="100px" CssClass="textbox"></asp:TextBox>
                 <asp:FileUpload ID="fUploadConsentimientoInf" runat="server" />
                 
             </td>
         </tr>
         <tr>
             <td style="text-align:right">Autorización de procedimiento quirugico:</td>
             <td><asp:TextBox ID="txtIdAutorizacionProcedimiento" runat="server" Text="0" Width="100px" CssClass="textbox"></asp:TextBox>
                 <asp:FileUpload ID="fUploadAutorizacionQuirurgica" runat="server" />
                  
             </td>
         </tr>
         <tr>
             <td style="text-align:right">Exámenes auxiliares:</td>
             <td><asp:TextBox ID="txtExamenesAuxiliares" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode="MultiLine"></asp:TextBox></td>
         </tr>
         <tr>
             <td style="text-align:right">Diagnóstico presuntivo:</td>
             <td><asp:TextBox ID="txtDiagnosticoPresuntivo" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode="MultiLine"></asp:TextBox></td>
         </tr>
         <tr>
             <td style="text-align:right">Plan de trabajo:</td>
             <td><asp:TextBox ID="txtPlanTrabajo" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode="MultiLine"></asp:TextBox></td>
         </tr>
         <tr>
             <td style="text-align:right">Terapéutica y seguimiento:</td>
             <td><asp:TextBox ID="txtTerapeutica" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode="MultiLine"></asp:TextBox></td>
         </tr>
         <tr>
             <td style="text-align:right">Epicrisis y/o resumen de Historia Clínica:</td>
             <td><asp:TextBox ID="txtEpicrisis" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode="MultiLine"></asp:TextBox></td>
         </tr>
         <tr>
             <td style="text-align:right">Historia Clinica Perinatal :</td>
             <td><asp:TextBox ID="txtIdHostoriaPerinatal" runat="server" Text="0" Width="100px" CssClass="textbox"></asp:TextBox>
                 <asp:TextBox ID="txtNombreDocumentoHistoriaPerinatal"  Width="290px" runat="server" CssClass="textbox"></asp:TextBox>
             </td>
         </tr>
         <tr>
             <td style="text-align:right">Partograma:</td>
             <td><asp:TextBox ID="txtIdPartograma" runat="server" Text="0" Width="100px" CssClass="textbox"></asp:TextBox>
                 <asp:TextBox ID="txtNombreDocumentoPartograma" runat="server" Width="290px" CssClass="textbox"></asp:TextBox>
             </td>
         </tr>
         <tr>
             <td style="text-align:right">Priodidad:</td>
             <td><asp:DropDownList ID="drpPrioridad" runat="server" Width="110px" CssClass="dropDownList">
                   <asp:ListItem>Prioridad I</asp:ListItem>
                   <asp:ListItem>Prioridad II</asp:ListItem>
                   <asp:ListItem>Prioridad III</asp:ListItem>
                 </asp:DropDownList></td>
         </tr>
     </table>
  
     <table style="margin:auto">
         <tr>
                            <td></td>
                            <td><asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="button" OnClick="GuardarAtencionEmergencia" />
                                 <asp:Label ID="lblMsj" runat="server" Text="" ForeColor="Green" Font-Bold="true"></asp:Label>
                                 
                            </td>
           </tr>
    </table> 
     
     
        
 </asp:Content>