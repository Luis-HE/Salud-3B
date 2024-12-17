<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmConsultorio.aspx.cs" Inherits="CapaPresentacion.Forms.frmConsultorio" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
   <script type="text/javascript" src="../Scripts/jquery.min.js"> </script>
   <script type="text/javascript" src="../Scripts/SoloNumeros.js"></script>
  <script type="text/javascript" src="../Scripts/TexboxEnterNextControl.js"></script>
<script type="text/javascript">
   $(document).ready(function() {
       //$('input[type="text"]').attr("disabled", "disabled");// to disable all textbox, color gray by defaul. But makes it empty to value of control
       $("#txtDni_empleado").attr("readonly", true);
       $("#txtNombre_empleado").attr("readonly", true);

       $("#txtTriajeNombres").attr("readonly", true);
       $("#txtTriajeSexo").attr("readonly", true);
       $("#txtTriajeEdad").attr("readonly", true);
       $("#txtTriajeGrupoEtnico").attr("readonly", true);
       $("#txtTrijaeFechaNace").attr("readonly", true);
       $("#txtProcedencia").attr("readonly", true);
       $("#txtIdAcompanante").attr("readonly", true);
       $("#txtTriajeAcompanante").attr("readonly", true);

       $("#txtCod_ciediez").attr("readonly", true);
       $("#txtNombre_ciediez").attr("readonly", true);
 
    return false; //to prevent from postback
    });
</script>
    
   <script type="text/javascript"> 
    function OpenListEmpleados()
    {
        window.open("../Forms/frmListar_Medicos.aspx", 'Lista Medicos', 'height=550,width=600,left=265,top=165,resizable=No,toolbar=No')
    }
    function OpenListCatalogoCie()
    {
        window.open("../Forms/frmListar_CatalogoCie.aspx", 'Lista Catalogo CIE10', 'height=550,width=600,left=265,top=165,resizable=No,toolbar=No')
    }
    function OpenReceta()
    {
        window.open("../Forms/frmRecetaMedica.aspx", 'Receta Medica', 'height=1500,width=1000,left=265,top=165,resizable=No,toolbar=No')
    }
    
    function ImprimirHistoria()
    {
        var AtxtAntecedenteFamiliar = document.getElementById("<%=AtxtAntecedenteFamiliar.ClientID %>");
        var AtxtAntecedentePersonal = document.getElementById("<%=AtxtAntecentePersonal.ClientID %>");
        
        var printWindow = window.open('', '', 'height=800,width=900');
        printWindow.document.write('<html>');
        printWindow.document.write('<head>');
        printWindow.document.write('</head>');
        printWindow.document.write('<body>');

        printWindow.document.write('</body>');
        printWindow.document.write('</html>');
        printWindow.document.close();
        setTimeout(function () {
            printWindow.print();
        }, 500);
        return false;
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
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDni_empleado" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ErrorMessage="completar..."></asp:RequiredFieldValidator>
                    <asp:Button ID="btnBuscarMedico" runat="server" Text=" " CssClass="btnOpenPopup" OnClientClick="OpenListEmpleados()" CausesValidation="false"/>
                    <asp:TextBox ID="txtNombre_empleado" runat="server" Width="240px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                </td>
            </tr>
        <tr>
            <td>Especialidad:</td>
            <td><asp:DropDownList ID="drpEspecialidad" runat="server" CssClass="dropDownList" Width="390px">  
              </asp:DropDownList>
                
            </td>
        </tr> 
        <tr>
            <td></td>
            <td><asp:Button ID="btnBuscaPacientesAdmitidos" runat="server" Text="Buscar" CssClass="button" OnClick="BuscaPacientesAdmitidos" CausesValidation="false" />
                
            </td>
             
        </tr>         
    </table>
    
    <asp:GridView ID="grdListaPacientesAdmitidos" runat="server" CssClass="gridViewCita" AutoGenerateColumns="false">
        <Columns>
             <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="SelecionarRegistro" CausesValidation="false">Select</asp:LinkButton>
                    </ItemTemplate>
             </asp:TemplateField>
            <asp:BoundField DataField="numero_admision" HeaderText="N° de Cuenta" />
            <asp:BoundField DataField="num_hist_clinica" HeaderText="N° Historia Clínica" />
             <asp:BoundField DataField="num_doc_cliente" HeaderText="DNI/CE" />
             <asp:BoundField DataField="paciente" HeaderText="Paciente" />
             <asp:BoundField DataField="fecha_nace" HeaderText="Fecha Nace" />
            <asp:BoundField DataField="descripcion_item" HeaderText="Descripción" />
            <asp:BoundField DataField="tipo_admision" HeaderText="Tipo admisión" />
            <asp:BoundField DataField="genero" HeaderText="Género" />
            <asp:BoundField DataField="grupo_etnico" HeaderText="Grupo Etnico" />
            <asp:BoundField DataField="ubigeo" HeaderText="Ubigeo" />
            <asp:BoundField DataField="grupo_sanguineo" HeaderText="Grupo Sanguineo" />
            <asp:BoundField DataField="edad" HeaderText="Edad" />
            <asp:BoundField DataField="id_reg_acompanante" HeaderText="Id_Acompañante" />
            <asp:BoundField DataField="nombre_acompanante" HeaderText="Nombre Acompañante" />
            <asp:BoundField DataField="talla" HeaderText="Talla" />
            <asp:BoundField DataField="peso" HeaderText="Peso" />
             <asp:BoundField DataField="presion_sistolica" HeaderText="P.Sistolica" />
             <asp:BoundField DataField="presion_diastolica" HeaderText="P. Diastolica" />
             <asp:BoundField DataField="frecuencia_cardiaca" HeaderText="F.Cardiaca" />
             <asp:BoundField DataField="temperatura" HeaderText="Temperatura" />
             <asp:BoundField DataField="indice_masa_cuerpo" HeaderText="IMC" />
             <asp:BoundField DataField="frecuencia_respiratoria" HeaderText="FR" />
             <asp:BoundField DataField="sp_oxigeno" HeaderText="SPO2" />

           </Columns>
        <EmptyDataTemplate>
                        <table style="width:100%">
                            <tr>
                                <td>No data Found</td>
                            </tr>
                        </table>
        </EmptyDataTemplate> 
    </asp:GridView>
    <table style="margin:auto;">
         <tr>
            <td><asp:LinkButton ID="lnkBoton" runat="server"  CausesValidation="false" ><a href="frmHistoria_Clinica.aspx" target="_blank">Ver Historia Clínica</a></asp:LinkButton></td>
        </tr>     
    </table>
    <ajaxToolkit:Accordion ID="Accordion1" runat="server" AutoSize="Fill" HeaderCssClass="accordionCabecera" ContentCssClass="accordionContenido">
        <Panes>
            <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server">
                <Header>INFORMACIÓN DE TRIAJE:</Header>
                <Content>
                    
                 <table>
                                     <tr>
                                         <td style="text-align:right">Apellidos y Nombres</td>
                                         <td><asp:TextBox ID="txtTriajeNombres" runat="server" Width="400px" CssClass="textBoxDisabled"></asp:TextBox> </td>
                                         <td style="text-align:right">Género:</td>
                                         <td><asp:TextBox ID="txtTriajeSexo" runat="server" CssClass="textBoxDisabled"></asp:TextBox> </td>
                                     </tr>
                                      
                                     <tr>
                                         <td style="text-align:right">Edad:</td>
                                         <td><asp:TextBox ID="txtTriajeEdad" runat="server" CssClass="textBoxDisabled"></asp:TextBox> </td>
                                          <td style="text-align:right">Grupo Etnico:</td>
                                         <td><asp:TextBox ID="txtTriajeGrupoEtnico" runat="server" CssClass="textBoxDisabled"></asp:TextBox> </td>
                                     </tr>
                                      
                                     <tr>
                                         <td style="text-align:right">Fecha de nacimiento:</td>
                                         <td><asp:TextBox ID="txtTrijaeFechaNace" runat="server" CssClass="textBoxDisabled"></asp:TextBox> 
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; N° de Admisión:<asp:Label ID="lblNumeroAdmision" runat="server" Text="" CssClass="label" Width="100px" ClientIDMode="Static"></asp:Label>
                                         </td>
                                          <td style="text-align:right">Procedencia:</td>
                                         <td><asp:TextBox ID="txtProcedencia" runat="server" CssClass="textBoxDisabled"></asp:TextBox> </td>
                                     </tr>
 
                                     <tr>
                                        <td style="text-align:right">Acompañante:</td>
                                         <td>
                                             <asp:TextBox ID="txtIdAcompanante" Width="50px" runat="server" CssClass="textBoxDisabled"></asp:TextBox>
                                             <asp:TextBox ID="txtTriajeAcompanante" runat="server" Width="340px" CssClass="textBoxDisabled"></asp:TextBox> </td>
                                         <td style="text-align:right">Grupo Sanguineo</td>
                                         <td><asp:TextBox ID="txtGrupoSanguineo" runat="server" CssClass="textbox"></asp:TextBox> </td>
                                     </tr>
                                     <tr>
                                         <td style="text-align:right">Talla:</td>
                                         <td>
                                             <asp:TextBox ID="txttalla" runat="server" CssClass="textbox"  ></asp:TextBox></td>
                                         <td style="text-align:right">Ritmo Cardiaco:</td>
                                         <td ><asp:TextBox ID="txtRitmoCardiaco" runat="server" CssClass="textbox" ></asp:TextBox> </td>
                                     </tr>
                                      <tr>
                                         <td style="text-align:right">Peso:</td>
                                         <td> <asp:TextBox ID="txtPeso" runat="server" CssClass="textbox"  ></asp:TextBox></td>
                                          <td style="text-align:right">Presión Arterial: Sistólica</td>
                                          <td><asp:TextBox ID="txtPresionArterialSistolica" runat="server" CssClass="textbox" Width="35px"></asp:TextBox>
                                             Diastólica<asp:TextBox ID="txtPresionArterialDiastolica" runat="server" CssClass="textbox" Width="35px"></asp:TextBox>
                                          </td>
                                     </tr>
                                     <tr>
                                         <td style="text-align:right">Temperatura:</td>
                                         <td><asp:TextBox ID="txtTemperatura" runat="server" CssClass="textbox"></asp:TextBox></td>
                                         <td style="text-align:right">I.M.C. :</td>
                                         <td><asp:TextBox ID="txtIMC" runat="server" CssClass="textbox"></asp:TextBox></td>
                                     </tr>
                                     <tr>
                                         <td style="text-align:right">SPO2:</td>
                                         <td><asp:TextBox ID="txtSPO" runat="server" CssClass="textbox"></asp:TextBox></td>
                                         <td style="text-align:right">F.R.:</td>
                                         <td><asp:TextBox ID="txtFR" runat="server" CssClass="textbox"></asp:TextBox></td>
                                     </tr>
                                 
                                 </table>
      
                </Content>
            </ajaxToolkit:AccordionPane>            
        </Panes>
    </ajaxToolkit:Accordion>
 <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
        <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
            <HeaderTemplate ><asp:Label ID="lblpage1" runat="server" Text="Atención Integral del Niño(a)" Width="200px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
             
             <ContentTemplate>
                 <table>
                     <tr>
                         <td style="text-align:right">Grado de instrucción:</td>
                         <td><asp:TextBox ID="NtxtGradoInstruccion" runat="server" Width="400px"  CssClass="textbox"></asp:TextBox> </td>
                     </tr>
                   <tr>
                        <td style="text-align:right">Antecedentes personales:</td>
                        <td><asp:TextBox ID="NtxtAntecentePersonal" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                     
                     <tr>
                        <td style="text-align:right">Antecedentes familiares:</td>
                        <td><asp:TextBox ID="NtxtAntecedenteFamiliar" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Esquema de vacunación:</td>
                        <td><asp:TextBox ID="NtxtEsquemaVacunacion" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Vigilancia del crecimiento y desarrollo:</td>
                        <td><asp:TextBox ID="NtxtVigilanciaDesarrollo" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Anamnesis:</td>
                        <td><asp:TextBox ID="NtxtAnamnesis" runat="server" Width="400px" CssClass="textbox"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Problemas frecuentes en la infancia:</td>
                        <td><asp:TextBox ID="NtxtProblemasInfancia" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Evaluación de la alimentación actual:</td>
                        <td><asp:TextBox ID="NtxtEvaluacionAlimentacion" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Exámen físico:</td>
                        <td><asp:TextBox ID="NtxtExamenFisico" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Tratamiento:</td>
                        <td><asp:TextBox ID="NtxtTratamiento" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Exámenes auxiliares:</td>
                        <td><asp:TextBox ID="NtxtExamenesAuxiliares" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Referencias si fuera el caso:</td>
                        <td><asp:TextBox ID="NtxtReferencia" runat="server" Width="400px" CssClass="textbox"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Fecha de la proxima cita:</td>
                        <td><asp:TextBox ID="NtxtFechaProximaCita" runat="server" Width="100px" CssClass="textbox"></asp:TextBox></td>
                    </tr>
                 </table>
                 
             </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel2" ID="TabPanel2">
            <HeaderTemplate><asp:Label ID="lblpage2" runat="server" Text="Atención Integral del Adolecente" Width="200px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
             <ContentTemplate>
                  <table>
                      <tr>
                         <td style="text-align:right">Grado de instrucción:</td>
                         <td><asp:TextBox ID="AtxtGradoInstruccion" runat="server" Width="400px"  CssClass="textbox"></asp:TextBox> </td>
                     </tr>
                      <tr>
                         <td style="text-align:right">Centro Educativo:</td>
                         <td><asp:TextBox ID="AtxtCentroEducativo" runat="server" Width="400px"  CssClass="textbox"></asp:TextBox> </td>
                     </tr>
                      <tr>
                         <td style="text-align:right">Ocupación:</td>
                         <td><asp:TextBox ID="AtxtOcupacion" runat="server" Width="400px"  CssClass="textbox"></asp:TextBox> </td>
                     </tr>
                   <tr>
                        <td style="text-align:right">Antecedentes personales:</td>
                        <td><asp:TextBox ID="AtxtAntecentePersonal" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                     
                     <tr>
                        <td style="text-align:right">Antecedentes familiares:</td>
                        <td><asp:TextBox ID="AtxtAntecedenteFamiliar" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                      <tr>
                         <td style="text-align:right">Antecedentes psicosociales:</td>
                         <td><asp:TextBox ID="AtxtAntecednetePsicosocial" runat="server" Width="400px"  Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox> </td>
                     </tr>
                      <tr>
                         <td style="text-align:right">Salud sexual y reproductiva:</td>
                         <td><asp:TextBox ID="AtxtSaludSexual" runat="server" Width="400px"  Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox> </td>
                     </tr>
                      <tr>
                         <td style="text-align:right">Salud bucal:</td>
                         <td><asp:TextBox ID="AtxtSaludBucal" runat="server" Width="400px"  Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox> </td>
                     </tr>
                      <tr>
                         <td style="text-align:right">Motivo de consulta:</td>
                         <td><asp:TextBox ID="AtxtMotivoConsulta" runat="server" Width="400px"  Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox> </td>
                     </tr>
                     <tr>
                        <td style="text-align:right">Tiempo de enfermedad:</td>
                        <td><asp:TextBox ID="AtxtTiempoEnfermedad" runat="server" Width="400px"   CssClass="textbox" ></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Funciones biologicas:</td>
                        <td><asp:TextBox ID="AtxtFuncionesBiologicas" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Evaluación antropometrica:</td>
                        <td><asp:TextBox ID="AtxtEvaluacionAntropometrica" runat="server" Width="400px" CssClass="textbox"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Evaluación de riesgo cardiovascular:</td>
                        <td><asp:TextBox ID="AtxtEvaluacionCardiovascular" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Funciones vitales:</td>
                        <td><asp:TextBox ID="AtxtFuncionesVitales" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Exámen físico:</td>
                        <td><asp:TextBox ID="AtxtExamenFisico" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Tratamiento:</td>
                        <td><asp:TextBox ID="AtxtTratamiento" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Exámenes auxiliares:</td>
                        <td><asp:TextBox ID="AtxtExamenesAuxiliares" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Referencias si fuera el caso:</td>
                        <td><asp:TextBox ID="AtxtReferencia" runat="server" Width="400px" CssClass="textbox"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Fecha de la proxima cita:</td>
                        <td><asp:TextBox ID="AtxtFechaProximaCita" runat="server" Width="100px" CssClass="textbox"></asp:TextBox></td>
                    </tr>
                 </table>
             </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel3" ID="TabPanel3">
            <HeaderTemplate><asp:Label ID="lblpage3" runat="server" Text="Atención Integral del Joven" Width="200px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
             <ContentTemplate>
                 <table>
                      <tr>
                         <td style="text-align:right">Grado de instrucción:</td>
                         <td><asp:TextBox ID="JtxtGradoInstruccion" runat="server" Width="400px"  CssClass="textbox"></asp:TextBox> </td>
                     </tr>
                     <tr>
                         <td style="text-align:right">Ocupación:</td>
                         <td><asp:TextBox ID="JtxtOcupacion" runat="server" Width="400px"  CssClass="textbox"></asp:TextBox> </td>
                     </tr>
                   <tr>
                        <td style="text-align:right">Antecedentes personales:</td>
                        <td><asp:TextBox ID="JtxtAntecentePersonal" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                     
                     <tr>
                        <td style="text-align:right">Antecedentes familiares:</td>
                        <td><asp:TextBox ID="JtxtAntecedenteFamiliar" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                      <tr>
                         <td style="text-align:right">Antecedentes psicosociales:</td>
                         <td><asp:TextBox ID="JtxtAntecednetePsicosocial" runat="server" Width="400px"  Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox> </td>
                     </tr>
                      <tr>
                         <td style="text-align:right">Salud sexual y reproductiva:</td>
                         <td><asp:TextBox ID="JtxtSaludSexual" runat="server" Width="400px"  Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox> </td>
                     </tr>
                      <tr>
                         <td style="text-align:right">Salud bucal:</td>
                         <td><asp:TextBox ID="JtxtSaludBucal" runat="server" Width="400px"  Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox> </td>
                     </tr>
                      <tr>
                         <td style="text-align:right">Motivo de consulta:</td>
                         <td><asp:TextBox ID="JtxtMotivoConsulta" runat="server" Width="400px"  Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox> </td>
                     </tr>
                     <tr>
                        <td style="text-align:right">Tiempo de enfermedad:</td>
                        <td><asp:TextBox ID="JtxtTiempoEnfermedad" runat="server" Width="400px"   CssClass="textbox" ></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Funciones biologicas:</td>
                        <td><asp:TextBox ID="JtxtFuncionesBiologicas" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Evaluación antropometrica:</td>
                        <td><asp:TextBox ID="JtxtEvaluacionAntropometrica" runat="server" Width="400px" CssClass="textbox"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Evaluación de riesgo cardiovascular:</td>
                        <td><asp:TextBox ID="JtxtEvaluacionCardiovascular" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Funciones vitales:</td>
                        <td><asp:TextBox ID="JtxtFuncionesVitales" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Exámen físico:</td>
                        <td><asp:TextBox ID="JtxtExamenFisico" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Tratamiento:</td>
                        <td><asp:TextBox ID="JtxtTratamiento" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Exámenes auxiliares:</td>
                        <td><asp:TextBox ID="JtxtExamenesAuxiliares" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Referencias si fuera el caso:</td>
                        <td><asp:TextBox ID="JtxtReferencia" runat="server" Width="400px" CssClass="textbox"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Fecha de la proxima cita:</td>
                        <td><asp:TextBox ID="JtxtFechaProximaCita" runat="server" Width="100px" CssClass="textbox"></asp:TextBox></td>
                    </tr>
                 </table>
             </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel4" ID="TabPanel4">
            <HeaderTemplate><asp:Label ID="lblpage4" runat="server" Text="Atención Integral del Adulto" Width="200px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
             <ContentTemplate>
                 <table>
                      <tr>
                         <td style="text-align:right">Grado de instrucción:</td>
                         <td><asp:TextBox ID="ADULtxtGradoInstruccion" runat="server" Width="400px"  CssClass="textbox"></asp:TextBox> </td>
                     </tr>
                     <tr>
                         <td style="text-align:right">Centro educativo:</td>
                         <td><asp:TextBox ID="ADULtxtCentroEducativo" runat="server" Width="400px"  CssClass="textbox"></asp:TextBox> </td>
                     </tr>
                     <tr>
                         <td style="text-align:right">Ocupación:</td>
                         <td><asp:TextBox ID="ADULtxtOcupacion" runat="server" Width="400px"  CssClass="textbox"></asp:TextBox> </td>
                     </tr>
                   <tr>
                        <td style="text-align:right">Antecedentes personales:</td>
                        <td><asp:TextBox ID="ADULtxtAntecentePersonal" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                     
                     <tr>
                        <td style="text-align:right">Antecedentes familiares:</td>
                        <td><asp:TextBox ID="ADULtxtAntecedenteFamiliar" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                      <tr>
                         <td style="text-align:right">Alergia a medicamentos:</td>
                         <td><asp:TextBox ID="ADULtxtAlergiaMedicamento" runat="server" Width="400px"    CssClass="textbox" ></asp:TextBox> </td>
                     </tr>
                      <tr>
                         <td style="text-align:right">Sexualidad:</td>
                         <td><asp:TextBox ID="ADULtxtSexualidad" runat="server" Width="400px"  Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox> </td>
                     </tr>
                      <tr>
                         <td style="text-align:right">Salud bucal:</td>
                         <td><asp:TextBox ID="ADULtxtSaludBucal" runat="server" Width="400px"  Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox> </td>
                     </tr>
                      <tr>
                         <td style="text-align:right">Motivo de consulta:</td>
                         <td><asp:TextBox ID="ADULtxtMotivoConsulta" runat="server" Width="400px"  Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox> </td>
                     </tr>
                     <tr>
                        <td style="text-align:right">Tiempo de enfermedad:</td>
                        <td><asp:TextBox ID="ADULtxtTiempoEnfermedad" runat="server" Width="400px"   CssClass="textbox" ></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Funciones biologicas:</td>
                        <td><asp:TextBox ID="ADULtxtFuncionesBiologicas" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                      
                     <tr>
                        <td style="text-align:right">Exámen físico:</td>
                        <td><asp:TextBox ID="ADULtxtExamenFisico" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Tratamiento:</td>
                        <td><asp:TextBox ID="ADULtxtTratamiento" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Exámenes auxiliares:</td>
                        <td><asp:TextBox ID="ADULtxtExamenesAuxiliares" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Referencias si fuera el caso:</td>
                        <td><asp:TextBox ID="ADULtxtReferencia" runat="server" Width="400px" CssClass="textbox"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Fecha de la proxima cita:</td>
                        <td><asp:TextBox ID="ADULtxtFechaProximaCita" runat="server" Width="100px" CssClass="textbox"></asp:TextBox></td>
                    </tr>
                 </table>
             </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel5" ID="TabPanel5">
            <HeaderTemplate><asp:Label ID="lblpage5" runat="server" Text="Atención Integral del Adulto Mayor" Width="200px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
             <ContentTemplate>
                 <table>
                      <tr>
                         <td style="text-align:right">Grado de instrucción:</td>
                         <td><asp:TextBox ID="AMtxtGradoInstruccion" runat="server" Width="400px"  CssClass="textbox"></asp:TextBox> </td>
                     </tr>
                     <tr>
                         <td style="text-align:right">Ocupación:</td>
                         <td><asp:TextBox ID="AMtxtOcupacion" runat="server" Width="400px"  CssClass="textbox"></asp:TextBox> </td>
                     </tr>
                   <tr>
                        <td style="text-align:right">Antecedentes personales:</td>
                        <td><asp:TextBox ID="AMtxtAntecentePersonal" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                     
                     <tr>
                        <td style="text-align:right">Antecedentes familiares:</td>
                        <td><asp:TextBox ID="AMtxtAntecedenteFamiliar" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                      <tr>
                         <td style="text-align:right">Alergia a medicamentos:</td>
                         <td><asp:TextBox ID="AMtxtAlergiaMedicamento" runat="server" Width="400px"   CssClass="textbox" ></asp:TextBox> </td>
                     </tr>
                      <tr>
                         <td style="text-align:right">Medicamentos de uso frecuente:</td>
                         <td><asp:TextBox ID="AMtxtMedicamentoFrecuente" runat="server" Width="400px"  Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox> </td>
                     </tr>
                      <tr>
                         <td style="text-align:right">Reacción adversa a medicamentos:</td>
                         <td><asp:TextBox ID="AMtxtReaccionMedicamento" runat="server" Width="400px"   CssClass="textbox" ></asp:TextBox> </td>
                     </tr>
                     <tr>
                         <td style="text-align:right">Vaoración clínica del adulto mayor VACAM:</td>
                         <td><asp:TextBox ID="AMtxtValoracionAdulto" runat="server" Width="400px"  Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox> </td>
                     </tr>
                     <tr>
                         <td style="text-align:right">Categorias del adulto mayor:</td>
                         <td><asp:TextBox ID="AMtxtCategoriaAdultoMayor" runat="server" Width="400px"   CssClass="textbox" ></asp:TextBox> </td>
                     </tr>
                      <tr>
                         <td style="text-align:right">Salud bucal:</td>
                         <td><asp:TextBox ID="AMtxtSaludBucal" runat="server" Width="400px"  Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox> </td>
                     </tr>
                      <tr>
                         <td style="text-align:right">Motivo de consulta:</td>
                         <td><asp:TextBox ID="AMtxtMotivoConsulta" runat="server" Width="400px"  Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox> </td>
                     </tr>
                     <tr>
                        <td style="text-align:right">Tiempo de enfermedad:</td>
                        <td><asp:TextBox ID="AMtxtTiempoEnfermedad" runat="server" Width="400px"   CssClass="textbox" ></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Funciones biologicas:</td>
                        <td><asp:TextBox ID="AMtxtFuncionesBiologicas" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                      
                     <tr>
                        <td style="text-align:right">Exámen físico:</td>
                        <td><asp:TextBox ID="AMtxtExamenFisico" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Tratamiento:</td>
                        <td><asp:TextBox ID="AMtxtTratamiento" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Exámenes auxiliares:</td>
                        <td><asp:TextBox ID="AMtxtExamenesAuxiliares" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode ="MultiLine"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Referencias si fuera el caso:</td>
                        <td><asp:TextBox ID="AMtxtReferencia" runat="server" Width="400px" CssClass="textbox"></asp:TextBox></td>
                    </tr>
                     <tr>
                        <td style="text-align:right">Fecha de la proxima cita:</td>
                        <td><asp:TextBox ID="AMtxtFechaProximaCita" runat="server" Width="100px" CssClass="textbox"></asp:TextBox></td>
                    </tr>
                 </table>
             </ContentTemplate>
        </ajaxToolkit:TabPanel>

    </ajaxToolkit:TabContainer>
     <fieldset class="fieldset">
           <legend class="legend" >DIAGNÓSTICO</legend>
         <table>
             <tr>
                 <td><asp:TextBox ID="txtCod_ciediez" runat="server" Width="100px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                  
                    <asp:Button ID="btnBuscarCiediez" runat="server" Text=" " CssClass="btnOpenPopup" ToolTip="Buscar CIE10" OnClientClick="OpenListCatalogoCie()" CausesValidation="false" />
                    <asp:TextBox ID="txtNombre_ciediez" runat="server" Width="550px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                     Tipo de Diagnostico:
                     <asp:DropDownList ID="drpTipoDiagnostico" runat="server" CssClass="dropDownList" Width="110px">
                         <asp:ListItem Value="1">Presuntivo </asp:ListItem>
                         <asp:ListItem Value="2">Definitivo </asp:ListItem>                         
                     </asp:DropDownList>
                    <asp:Button ID="btnImputar" runat="server" CssClass="btnCkeckData"  Text=" " ToolTip="Cargar" OnClick="CargarItemsDiagnostico" CausesValidation="false" />
                </td>
             </tr>
         </table>
         <asp:GridView ID="grdDiagnosticos" runat="server" AutoGenerateColumns="false" CssClass="gridViewCita">
             <Columns>
                <asp:BoundField DataField="Col1" HeaderText="N°" />
                <asp:BoundField DataField="Col2" HeaderText="Código" /> 
                <asp:BoundField DataField="Col3" HeaderText="Descripción" /> 
                <asp:BoundField DataField="Col4" HeaderText="Tipo" />  
                <asp:TemplateField HeaderText="">
                         <ItemTemplate>
                             <asp:Button ID="btnBorrarFila" runat="server" CssClass="buttonIconDelete" ToolTip="Quitar"  OnClick="BorrarFila" CausesValidation="false" /> 
                         </ItemTemplate>
                
            </asp:TemplateField>
             </Columns>
         </asp:GridView>
     </fieldset>

    <table style="margin:auto">
        <tr>
            <td><asp:Button ID="btnGuardarConsultaExterna" runat="server" Text="Guardar" CssClass="button" OnClick="GuardarConsultaExterna" />
                <asp:Label ID="lblMsj" runat="server" Text="" ForeColor="Green" Font-Bold="true"></asp:Label>
                <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" CssClass="button" OnClientClick="ImprimirHistoria()" CausesValidation="false" />
                <asp:Button ID="btnReceta" runat="server" Text="Receta" CssClass="button" OnClientClick="OpenReceta()" CausesValidation="false" />
                <%--<asp:Button ID="btnOrdenImg" runat="server" Text="Ord. Imagenes" CssClass="button" OnClientClick="OpenOrdenImagenesMedicas()" CausesValidation="false" />--%>
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="button" OnClick="Limpiar" CausesValidation="false" />
                
            </td>
        </tr>
    </table>
    
</asp:Content>
 
