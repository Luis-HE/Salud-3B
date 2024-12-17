<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmEspecialidades.aspx.cs" Inherits="CapaPresentacion.Forms.frmEspecialidades" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
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
    function OpenHistoriaClinica()
    {
        window.open("../Forms/frmHistoria_Clinica.aspx", 'Hitoria Clinica', 'left=0,top=0,resizable=No,toolbar=No')
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
                    <asp:TextBox ID="txtNombre_empleado" runat="server" Width="235px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
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
                <asp:Button ID="btnHistoriaClinica" runat="server" Text="Historia Clínica" CssClass="button" OnClientClick="OpenHistoriaClinica()" CausesValidation="false" />
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
      <HeaderTemplate ><asp:Label ID="lblpage1" runat="server" Text="Oftalmologia" Width="200px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
       <ContentTemplate>
           <table>
               <tr>
                   <td style="text-align:right">Motivo de consulta:</td>
                   <td><asp:TextBox ID="txtMotivoConsulta" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode="MultiLine"></asp:TextBox></td>
               </tr>
               <tr>
                   <td style="text-align:right">Tiempo enfermedad:</td>
                   <td><asp:TextBox ID="txtTiempoEnfermedad" runat="server" Width="200px"  CssClass="textbox" ></asp:TextBox></td>
               </tr>
               <tr>
                   <td style="text-align:right">Examen agudeza visual:</td>
                   <td>LEJOS  <br />                      
                      VOD: <asp:TextBox ID="txtagudezaLejosVod" runat="server" Width="100px"  CssClass="textbox" ></asp:TextBox>
                      VOS: <asp:TextBox ID="txtAgudezaLejosVos" runat="server" Width="100px"  CssClass="textbox" ></asp:TextBox> <br />
                       CERCA <br />
                      VOD: <asp:TextBox ID="txtagudezaCercaVod" runat="server" Width="100px"  CssClass="textbox" ></asp:TextBox>
                      VOS: <asp:TextBox ID="txtagudezaCercaVos" runat="server" Width="100px"  CssClass="textbox" ></asp:TextBox>
                   </td>
               </tr>
                <tr>
                   <td style="text-align:right">Examen externo:</td>
                   <td>OD
                       <asp:TextBox ID="txtexamenOd" runat="server" Width="200px"  CssClass="textbox" ></asp:TextBox> <br />
                       OS
                        <asp:TextBox ID="txtExamenOs" runat="server" Width="200px"  CssClass="textbox" ></asp:TextBox>
                   </td>  
               </tr>
                <tr>
                   <td style="text-align:right">Antecedentes:</td>
                   <td><asp:TextBox ID="txtAntecedentes" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode="MultiLine"></asp:TextBox></td>
               </tr>
               <tr>
                   <td style="text-align:right">Medios transparentes oculares:</td>
                   <td><asp:TextBox ID="txtMediosTrnasparentes" runat="server" Width="400px"   CssClass="textbox"  ></asp:TextBox></td>
               </tr>
               <tr>
                   <td style="text-align:right">Motilidad ocular:</td>
                   <td><asp:TextBox ID="txtMotilidadocular" runat="server" Width="400px"   CssClass="textbox"  ></asp:TextBox></td>
               </tr>
               <tr>
                   <td style="text-align:right">Tonometria ocular:</td>
                   <td>BIDIGITAL
                       <asp:TextBox ID="txtTonometriaBidigital" runat="server" Width="150px"   CssClass="textbox"  ></asp:TextBox>
                       SCHOITZ
                       <asp:TextBox ID="txtTonometriaSchoitz" runat="server" Width="150px"   CssClass="textbox"  ></asp:TextBox>
                       GOLDMAN
                       <asp:TextBox ID="txtTonometriaGoldman" runat="server" Width="150px"   CssClass="textbox"  ></asp:TextBox>
                   </td>
               </tr>
               <tr>
                   <td style="text-align:right">Fondo de ojo:</td>
                   <td>OD
                       <asp:TextBox ID="txtFondoOjoder" runat="server" Width="200px"   CssClass="textbox"  ></asp:TextBox>
                       OI
                       <asp:TextBox ID="txtFondoOjoizq" runat="server" Width="200px"   CssClass="textbox"  ></asp:TextBox>
                   </td>
               </tr>
                <tr>
                   <td style="text-align:right">Indicaciones:</td>
                   <td><asp:TextBox ID="txtIndicaciones" runat="server" Width="400px" Height="50px"  TextMode="MultiLine"  CssClass="textbox"  ></asp:TextBox></td>
               </tr>
                <tr>
                   <td style="text-align:right">Tratamiento:</td>
                   <td><asp:TextBox ID="txtTratamiento" runat="server" Width="400px" Height="50px"  TextMode="MultiLine"  CssClass="textbox"  ></asp:TextBox></td>
               </tr>
           </table>
           
       </ContentTemplate>
  </ajaxToolkit:TabPanel>
  <ajaxToolkit:TabPanel  runat="server" HeaderText="TabPanel2" ID="TabPanel2">
      <HeaderTemplate ><asp:Label ID="Label2" runat="server" Text="Cirugía General" Width="200px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
      <ContentTemplate>
           <table>
               <tr>
                   <td style="text-align:right">Anamnesis:</td>
                   <td><asp:TextBox ID="txtCirAnannesis" runat="server" Width="400px" Height="50px"  CssClass="textbox" TextMode="MultiLine"></asp:TextBox></td>
               </tr>
                <tr>
                   <td style="text-align:right">Antecedentes:</td>
                   <td><asp:TextBox ID="txtCirAntecedentes" runat="server" Width="400px" Height="50px"  CssClass="textbox" TextMode="MultiLine"></asp:TextBox></td>
               </tr>
               <tr>
                   <td style="text-align:right">ExamenFisico:</td>
                   <td><asp:TextBox ID="txtCirExamenFisico" runat="server" Width="400px" Height="50px"  CssClass="textbox" TextMode="MultiLine"></asp:TextBox></td>
               </tr>
               <tr>
                   <td style="text-align:right">Desarrollo Psicomotor:</td>
                   <td><asp:TextBox ID="txtCirDesarrolloPsicomotor" runat="server" Width="400px" Height="50px"  CssClass="textbox" TextMode="MultiLine"></asp:TextBox></td>
               </tr>
               <tr>
                   <td style="text-align:right">Examenes:</td>
                   <td><asp:TextBox ID="txtCirExamenes" runat="server" Width="400px" Height="50px"  CssClass="textbox" TextMode="MultiLine"></asp:TextBox></td>
               </tr>
               <tr>
                   <td style="text-align:right">Tratamiento:</td>
                   <td><asp:TextBox ID="txtCirTratamiento" runat="server" Width="400px" Height="50px"  CssClass="textbox" TextMode="MultiLine"></asp:TextBox></td>
               </tr>
               <tr>
                   <td style="text-align:right">Operacion:</td>
                   <td><asp:TextBox ID="txtCirOperacion" runat="server" Width="400px" Height="50px"  CssClass="textbox" TextMode="MultiLine"></asp:TextBox></td>
               </tr>
               <tr>
                   <td style="text-align:right">Indicaciones:</td>
                   <td><asp:TextBox ID="txtCirIndicaciones" runat="server" Width="400px" Height="50px"  CssClass="textbox" TextMode="MultiLine"></asp:TextBox></td>
               </tr>
               <tr>
                   <td style="text-align:right">Evolucion Post Operatoria:</td>
                   <td><asp:TextBox ID="txtCirEvolucionPost" runat="server" Width="400px" Height="50px"  CssClass="textbox" TextMode="MultiLine"></asp:TextBox></td>
               </tr>
               <tr>
                   <td style="text-align:right">Indicaciones de Alta:</td>
                   <td><asp:TextBox ID="txtCirIndicacionesAlta" runat="server" Width="400px" Height="50px"  CssClass="textbox" TextMode="MultiLine"></asp:TextBox></td>
               </tr>
               
           </table>
      </ContentTemplate>
  </ajaxToolkit:TabPanel>
<ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel3" ID="TabPanel3">
    <HeaderTemplate><asp:Label ID="lblpage3" runat="server" Text="Psicología" Width="200px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
    <ContentTemplate>
         <table>
               <tr>
                   <td style="text-align:right"></td>
                   <td></td>
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
            <td><asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="button" OnClick="GuardarConsulta" />
                <asp:Label ID="lblMsj" runat="server" Text="" ForeColor="Green" Font-Bold="true"></asp:Label>
                <asp:Button ID="btnReceta" runat="server" Text="Receta" CssClass="button" OnClientClick="OpenReceta()" CausesValidation="false" />
                <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="button" OnClick="Limpiar" CausesValidation="false" />
                 
            </td>
        </tr>
    </table>   
    
    
    
    
      
</asp:Content>

