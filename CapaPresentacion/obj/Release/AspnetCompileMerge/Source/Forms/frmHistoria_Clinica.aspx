<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmHistoria_Clinica.aspx.cs" Inherits="CapaPresentacion.Forms.frmHistoria_Clinica" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleHistoriaClinica.css" rel="stylesheet" type="text/css" />
    
     <script type="text/javascript" src="../Scripts/jquery.min.js"> </script>
   <script type="text/javascript" src="../Scripts/SoloNumeros.js"></script>
  <script type="text/javascript" src="../Scripts/TexboxEnterNextControl.js"></script>

    <title>Historia Clínica Electrónica</title>
    

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <table style="margin:auto">
          <tr>
                <td style="text-align:right">N° de DNI del Paciente:</td>
                <td><asp:TextBox ID="txtDni_paciente" runat="server"  Width="100px" CssClass="textbox"  ></asp:TextBox>
                    <asp:Button ID="btnBuscarHistoria" runat="server" Text=" " CssClass="btnOpenPopup" OnClick="ListarHistorialAtenciones" ToolTip="Buscar"/>
                </td>
            </tr>
     </table>
        <asp:GridView ID="grdHistorialAtenciones" runat="server" AutoGenerateColumns="false" CssClass="gridViewCita">
            <Columns>
               <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="SelecionarRegistro" >Ver</asp:LinkButton>
                    </ItemTemplate>
             </asp:TemplateField>
             <asp:BoundField DataField="Col1" HeaderText="Asistencia" />
             <asp:BoundField DataField="Col2" HeaderText="N° de Admisión" />
             <asp:BoundField DataField="Col3" HeaderText="Fecha y Hora de Atención" />
             <asp:BoundField DataField="Col4" HeaderText="Tipo de Atencion" />                     
             <asp:BoundField DataField="Col5" HeaderText="Especialidad o Servicio" />
             <asp:BoundField DataField="Col6" HeaderText="N° de Historia Clínica" /> 
             <asp:BoundField DataField="Col7" HeaderText="Paciente" />
            
            </Columns>
             <EmptyDataTemplate>
                        <table style="width:100%">
                            <tr>
                                <td>No hay registros</td>
                            </tr>
                        </table>
        </EmptyDataTemplate> 
        </asp:GridView>
        <ajaxToolkit:Accordion ID="Accordion1" runat="server" AutoSize="Fill" HeaderCssClass="accordionCabecera" ContentCssClass="accordionContenido">
            <Panes>
                <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server">
                    <Header>ATENCIONES EN CONSULTORIO:</Header>
                    <Content>
                        <asp:Repeater ID="repeaterFicha1" runat="server">
                            <ItemTemplate>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Label ID="lblFicha1_col1" runat="server" Text='<%#Eval("Ficha1_col1") %>'></asp:Label></td>
                                        <td>
                                            <asp:Label ID="lblFicha1_col2" runat="server" Text='<%#Eval("Ficha1_col2") %>'></asp:Label></td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Repeater ID="repeaterFicha2" runat="server">
                            <ItemTemplate>
                        <table id="TablaHistoria" class="table">
                        <thead>
                        <th style="width:30%;background-color: #ecf2f8;"><h5>CAMPOS DE LA FICHA CLÍNICA</h5></th>
                        <th style="width:70%;background-color: #ecf2f8;"><h5>CONTENIDO</h5></th>
                        </thead>
                        <tr>
                        <th style="text-align:right;background-color: #ecf2f8;">Edad:</th>
                        <td><asp:Label ID="Label1" runat="server" Text='<%#Eval("Ficha2_col1") %>'></asp:Label></td> 
                        </tr>
                        <tr>
                        <th style="text-align:right;background-color: #ecf2f8;">Grado de Instrución:</th>
                        <td><asp:Label ID="Label2" runat="server" Text='<%#Eval("Ficha2_col2") %>'></asp:Label></td> 
                        </tr>
                        <tr>
                        <th style="text-align:right;background-color: #ecf2f8;">Centro Educativo:</th>
                        <td><asp:Label ID="Label3" runat="server" Text='<%#Eval("Ficha2_col3") %>'></asp:Label></td> 
                        </tr>
                         <tr>
                        <th style="text-align:right;background-color: #ecf2f8;">Ocupación:</th>
                        <td><asp:Label ID="Label4" runat="server" Text='<%#Eval("Ficha2_col4") %>'></asp:Label></td> 
                        </tr>
                         <tr>
                        <th style="text-align:right;background-color: #ecf2f8;">Id. Acompañante:</th>
                        <td><asp:Label ID="Label5" runat="server" Text='<%#Eval("Ficha2_col5") %>'></asp:Label></td> 
                        </tr>
                         <tr>
                        <th style="text-align:right;background-color: #ecf2f8;">Antecedentes Personales:</th>
                        <td ><asp:Label ID="Label6" runat="server" Text='<%#Eval("Ficha2_col6") %>'></asp:Label></td> 
                        </tr>
                         <tr>
                        <th style="text-align:right;background-color: #ecf2f8;">Antecednetes Familiares:</th>
                        <td><asp:Label ID="Label7" runat="server" Text='<%#Eval("Ficha2_col7") %>'></asp:Label></td> 
                        </tr>
                         <tr>
                        <th style="text-align:right;background-color: #ecf2f8;">Antecedentes Psicosociales:</th>
                        <td><asp:Label ID="Label8" runat="server" Text='<%#Eval("Ficha2_col8") %>'></asp:Label></td> 
                        </tr>
                         <tr>
                        <th style="text-align:right;background-color: #ecf2f8;">Salud Sexual y Reproductiva:</th>
                        <td><asp:Label ID="Label9" runat="server" Text='<%#Eval("Ficha2_col9") %>'></asp:Label></td> 
                        </tr>
                         <tr>
                        <th style="text-align:right;background-color: #ecf2f8;">Salud Bucal:</th>
                        <td><asp:Label ID="Label10" runat="server" Text='<%#Eval("Ficha2_col10") %>'></asp:Label></td> 
                        </tr>
                         <tr>
                        <th style="text-align:right;background-color: #ecf2f8;">Motivo de Consulta:</th>
                        <td><asp:Label ID="Label11" runat="server" Text='<%#Eval("Ficha2_col11") %>'></asp:Label></td> 
                        </tr>
                         <tr>
                        <th style="text-align:right;background-color: #ecf2f8;">Tiempo de Enfermedad:</th>
                        <td><asp:Label ID="Label12" runat="server" Text='<%#Eval("Ficha2_col12") %>'></asp:Label></td> 
                        </tr>
                         <tr>
                        <th style="text-align:right;background-color: #ecf2f8;">Funciones Biológicas:</th>
                        <td><asp:Label ID="Label13" runat="server" Text='<%#Eval("Ficha2_col13") %>'></asp:Label></td> 
                        </tr>
                         <tr>
                        <th style="text-align:right;background-color: #ecf2f8;">Evaluación Antropométrica:</th>
                        <td><asp:Label ID="Label14" runat="server" Text='<%#Eval("Ficha2_col14") %>'></asp:Label></td> 
                        </tr>
                         <tr>
                        <th style="text-align:right;background-color: #ecf2f8;">Evaluación de Riesgo Cardiovascular:</th>
                        <td><asp:Label ID="Label15" runat="server" Text='<%#Eval("Ficha2_col15") %>'></asp:Label></td> 
                        </tr>
                         <tr>
                        <th style="text-align:right;background-color: #ecf2f8;">Funciones Vitales:</th>
                        <td><asp:Label ID="Label16" runat="server" Text='<%#Eval("Ficha2_col16") %>'></asp:Label></td> 
                        </tr>
                         <tr>
                        <th style="text-align:right;background-color: #ecf2f8;">Exámen Físico:</th>
                        <td><asp:Label ID="Label17" runat="server" Text='<%#Eval("Ficha2_col17") %>'></asp:Label></td> 
                        </tr>
                         <tr>
                        <th style="text-align:right;background-color: #ecf2f8;">Tratamiento:</th>
                        <td><asp:Label ID="Label18" runat="server" Text='<%#Eval("Ficha2_col18") %>'></asp:Label></td> 
                        </tr>
                         <tr>
                        <th style="text-align:right;background-color: #ecf2f8;">Exámenes Auxiliares:</th>
                        <td ><asp:Label ID="Label19" runat="server" Text='<%#Eval("Ficha2_col19") %>'></asp:Label></td> 
                        </tr>
                         <tr>
                        <th style="text-align:right;background-color: #ecf2f8;">Referencias si fuera el caso:</th>
                        <td><asp:Label ID="Label20" runat="server" Text='<%#Eval("Ficha2_col20") %>'></asp:Label></td> 
                        </tr>
                        <tr>
                           <th style="text-align:right;background-color: #ecf2f8;">Diagnóstico:</th>
                            <td>
                                <asp:GridView ID="grdDiagnosticoFicha2" runat="server" AutoGenerateColumns="false" CssClass="gridView">
                                    <Columns>
                                        <asp:BoundField DataField="cod_cie10" HeaderText="CIE10"   />
                                        <asp:BoundField DataField="descripcion" HeaderText="Descripción"   />
                                        <asp:BoundField DataField="tipo" HeaderText="Tipo de Diagnóstico"   />
                                    </Columns>
                                    <EmptyDataTemplate>
                                    <table style="width:100%">
                                        <tr>
                                            <td>No hay diagnóstico</td>
                                        </tr>
                                    </table>
                                   </EmptyDataTemplate> 
                                </asp:GridView> 

                            </td>
                         </tr>
                         <tr>
                        <th style="text-align:right;background-color: #ecf2f8;">Fecha de Próxima Cita:</th>
                        <td><asp:Label ID="Label21" runat="server" Text='<%#Eval("Ficha2_col21") %>'></asp:Label></td> 
                        </tr>
                         <tr>
                        <th style="text-align:right;background-color: #ecf2f8;">Médico que Tratante:</th>
                        <td><asp:Label ID="Label22" runat="server" Text='<%#Eval("Ficha2_col22") %>'></asp:Label></td> 
                        </tr>
                      </table>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Repeater ID="repeaterFicha3" runat="server">
                            <ItemTemplate>

                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Repeater ID="repeaterFicha4" runat="server">
                            <ItemTemplate>

                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Repeater ID="repeaterFicha5" runat="server">
                            <ItemTemplate>

                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Repeater ID="repeaterFicha6" runat="server">
                            <ItemTemplate>

                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Repeater ID="repeaterFicha7" runat="server">
                            <ItemTemplate>

                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Repeater ID="repeaterFicha8" runat="server">
                            <ItemTemplate>

                            </ItemTemplate>
                        </asp:Repeater>
                    </Content>
                </ajaxToolkit:AccordionPane>
                <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server">
                    <Header>ATENCIONES EN EMERGENCIA:</Header>
                    <Content>
                        <table>
                            <tr>
                                <td>Consultas:</td>
                                <td></td>
                            </tr>
                        </table>
                    </Content>
                </ajaxToolkit:AccordionPane>
                <ajaxToolkit:AccordionPane ID="AccordionPane3" runat="server">
                    <Header>LABORATORIO:</Header>
                    <Content>
                        <table>
                            <tr>
                                <td>Consultas:</td>
                                <td></td>
                            </tr>
                        </table>
                    </Content>
                </ajaxToolkit:AccordionPane>
                <ajaxToolkit:AccordionPane ID="AccordionPane4" runat="server">
                    <Header>IMÁGENES MÉDICAS:</Header>
                    <Content>
                        <table>
                            <tr>
                                <td>Consultas:</td>
                                <td></td>
                            </tr>
                        </table>
                    </Content>
                </ajaxToolkit:AccordionPane>

            </Panes>
        </ajaxToolkit:Accordion>
    </form>
</body>
</html>
