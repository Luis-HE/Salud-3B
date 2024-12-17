<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmCitaPacientes.aspx.cs" Inherits="CapaPresentacion.Forms.frmCitaPacientes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
 

    <script src="../Scripts/JQuery-1.4.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/FilterGridview.js"></script>
 
   <script type="text/javascript" src="../Scripts/jquery.min.js"> </script>
  <script type="text/javascript" src="../Scripts/TexboxEnterNextControl.js"></script>
         <%--Jquery necesario para NESTED Gridview--%>
 <script type="text/javascript" src="../Scripts/jquery.1.8.3.jquery.min.js"></script>
<script type="text/javascript">
    $(function () {
        $("[src*=minus]").each(function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>");
            $(this).next().remove()
        });
    });
</script>
<%-- fin Jquery--%>

  <script type="text/javascript">
   $(document).ready(function() {
       //$('input[type="text"]').attr("disabled", "disabled");// to disable all textbox, color gray by defaul. But makes it empty to value of control
       $("#txtDni_cliente").attr("readonly", true);
       $("#txtNombre_cliente").attr("readonly", true);

       $("#txtId_ItemCatalogo").attr("readonly", true);
       $("#txtDescrip_catalogo").attr("readonly", true);
       $("#txtPrecio_item").attr("readonly", true);
       $("#txtIdGrupo_item").attr("readonly", true);
       $("#txtIdClase_item").attr("readonly", true);

       return false; //to prevent from postback
    });
</script> 
<script type="text/javascript">
 
    function OpenListPacientes()
    {
        window.open("../Forms/frmListar_Pacientes.aspx", 'Lista Pacientes', 'height=650,width=600,left=265,top=0,resizable=No,toolbar=No')
    }
    function OpenCatalogoItems()
    {
        window.open("../Forms/frmListar_Catalogo.aspx", 'Lista Items', 'height=550,width=800,left=265,top=165,resizable=No,toolbar=No')
    }
    function OpenListEmpleados()
    {
        window.open("../Forms/frmListar_Medicos.aspx", 'Lista Empresas', 'height=550,width=600,left=265,top=165,resizable=No,toolbar=No')
    }

    function CallConfirmBox() 
    {
        var result = confirm("¿Desea realizar esta acción?");
        if (result)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
</script>
 
<script type="text/javascript">
    //======Function para filtrar filas en un gridview , usa el FilterGridview.js
    function SetupFilter(textboxID, gridID, columnName) {
        $('#' + textboxID).keyup(function () {
            var index;
            var text = $("#" + textboxID).val();

            $('#' + gridID + ' tbody tr').each(function () {
                $(this).children('th').each(function () {
                    if ($(this).html() == columnName)
                        index = $(this).index();
                });

                $(this).children('td').each(function () {
                    if ($(this).index() == index) {
                        var tdText = $(this).children(0).html() == null ? $(this).html() : $(this).children(0).html();

                        if (tdText.indexOf(text, 0) > -1) {
                            $(this).closest('tr').show();
                        } else {
                            $(this).closest('tr').hide();
                        }
                    };
                });
            });
        });
    };
    $(function () { SetupFilter("txtFiltarxDni", "grdTurnos", "Paciente"); });
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
                    <td style="text-align:right">Fecha:</td>
                    <td><asp:TextBox ID="txtfechabusqueda" runat="server" Width="200px" CssClass="textbox" MaxLength="10"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfechabusqueda" Format="dd/MM/yyyy" CssClass="calendar" />
                    </td>
                </tr>
               <tr>
                   <td style="text-align:right">Especialidad:</td>
                    <td><asp:DropDownList ID="drpEspecialidad" runat="server" CssClass="dropDownList" Width="210px">
                        </asp:DropDownList>                        
                    </td>
               </tr>
               
    </table>
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
        <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanelCitas" ID="tbPanelCitas">
         <HeaderTemplate><asp:Label ID="Label1" runat="server" Text="Citas - Consulta Externa" Width="200px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
        <ContentTemplate>
           <table style="margin:auto">
               <tr>
                   <td></td>
                   <td><asp:Button ID="btnBuscar" runat="server" Text="Buscar Turnos" CssClass="button" OnClick="BuscarTurnos" CausesValidation="false" />
                       </td>
               </tr>               
                 <tr>
                   <td style="text-align:right">Filtar por DNI:</td>
                    <td><asp:TextBox ID="txtFiltarxDni" runat="server" CssClass="textbox" Width="100px" ClientIDMode="Static"></asp:TextBox></td>
                </tr>
            </table>
            <asp:GridView ID="grdTurnos" runat="server" AutoGenerateColumns="False" CssClass="gridViewCita" OnRowDataBound="OnRowColorGridCell" ClientIDMode="Static" >
                <Columns>
                    <asp:BoundField DataField="hora" HeaderText="Hora" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnCreaCita" runat="server" CssClass="buttonIconPlus" ToolTip="Crear Cita" OnClick="OpenNuevacita" CausesValidation="false" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="dni_paciente" HeaderText="Paciente" />
                    <asp:BoundField DataField="dni_empleado" HeaderText="Medico de Turno" />
                    <asp:BoundField DataField="descripcion_item" HeaderText="Servicio" HtmlEncode="false" />   
                   <%-- <asp:BoundField DataField="precio_item" HeaderText="Precio" />   --%>
                    <asp:BoundField DataField="estado" HeaderText="Estado" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnCancelaTurnoCita" runat="server" CssClass="buttonIconDelete"   ToolTip="Cancelar Cita" OnClientClick="return CallConfirmBox();" OnClick="CancelaTurnoCita" CausesValidation="false"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="id_turno" HeaderText="Id. Registro" />
                   <%-- <asp:BoundField DataField="cod_item_catalogo" HeaderText="Código" />--%>
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

        <ajaxToolkit:TabPanel runat="server" HeaderText="TabConfirmarCitas" ID="tbConfirmarCitas">
         <HeaderTemplate><asp:Label ID="Label2" runat="server" Text="Confirmación de Citas" Width="200px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
         <ContentTemplate>
              <table style="margin:auto">
                  <tr>
                      <td>DNI del Paciente:</td>
                      <td><asp:TextBox ID="txtBuscarxDNI" runat="server" Text="" CssClass="textbox" Width="100px"></asp:TextBox>
                          <asp:Button ID="btnBuscaCitado" runat="server" Text=" " CssClass="btnOpenPopup" OnClick="BuscarPacienteCitado" CausesValidation="false" />
                      </td>
                  </tr>
             </table>
             <asp:GridView ID="grdPacientesCitados" runat="server" AutoGenerateColumns="false" CssClass="gridViewCita">
                 <Columns>
                     <asp:TemplateField>
                         <ItemTemplate>
                              <asp:LinkButton ID="LinkButton1" runat="server" OnClick="SelecionarPaciente" CausesValidation="false">Select</asp:LinkButton>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:BoundField DataField="num_doc_cliente" HeaderText="DNI" />
                      <asp:BoundField DataField="apellido_paterno" HeaderText="Apellido paterno" />
                      <asp:BoundField DataField="apellido_materno" HeaderText="Apellido materno" />
                      <asp:BoundField DataField="nombres" HeaderText="Nombres" />
                      <asp:BoundField DataField="telefono1" HeaderText="Telefono1" />
                      <asp:BoundField DataField="telefono2" HeaderText="Telefono2" />
                      <asp:BoundField DataField="email" HeaderText="E-mail" />
                      <asp:BoundField DataField="genero" HeaderText="Género" />
                      <asp:BoundField DataField="direccion" HeaderText="Direccíon" />
                      <asp:BoundField DataField="fecha_nace" HeaderText="Fecha Nace" />
                      <asp:BoundField DataField="estado_civil" HeaderText="Estado Civil" />
                      <asp:BoundField DataField="nombre_padre" HeaderText="Padre" />
                      <asp:BoundField DataField="nombre_madre" HeaderText="Madre" />
                      <asp:BoundField DataField="ocupacion" HeaderText="Ocupacíon" />
                     <asp:BoundField DataField="grupo_etnico" HeaderText="Grupo Etnico" />
                     <asp:BoundField DataField="religion" HeaderText="Religíon" />
                 </Columns>
                 <EmptyDataTemplate>
                        <table style="width:100%">
                            <tr>
                                <td>No data Found</td>
                            </tr>
                        </table>
               </EmptyDataTemplate> 
             </asp:GridView>
             <h4>DETALLE DE LA CITA:</h4>
             <asp:GridView ID="grdCita" runat="server" AutoGenerateColumns="false" CssClass="gridViewCita">
                 <Columns>
                     <asp:TemplateField>
                         <ItemTemplate>
                             <asp:ImageButton ID="imgShow" runat="server" CommandArgument="Show" OnClick="Show_Hide_ChildGrid" ImageUrl="~/Images/plus.png" CausesValidation="false" />
                              <asp:Panel ID="panelCitaDetalle" runat="server" Visible="false" Style="position:relative" >
                                  <asp:GridView ID="grdCitaDetalle" runat="server" AutoGenerateColumns="false" CssClass="gridViewCita">
                                      <Columns>
                                        <asp:BoundField DataField="id_reg_det_cita" HeaderText="Id" />
                                         <asp:BoundField DataField="hora_cita" HeaderText="Hora" />
                                         <asp:BoundField DataField="cod_item_catalogo" HeaderText="Código" />
                                         <asp:BoundField DataField="descrip_item" HeaderText="Descripcion" />
                                         <asp:BoundField DataField="estado" HeaderText="Estado" />
                                         <asp:BoundField DataField="precio_cita" HeaderText="Precio" />
                                      </Columns>
                                      <EmptyDataTemplate>
                                        <table style="width:100%">
                                            <tr>
                                                <td>No data Found</td>
                                            </tr>
                                        </table>
                                    </EmptyDataTemplate> 
                                  </asp:GridView>
                              </asp:Panel>
                         </ItemTemplate>
                     </asp:TemplateField>
                     <asp:BoundField DataField="id_cita" HeaderText="Id" />
                    <asp:BoundField DataField="fecha_cita" HeaderText="Fecha Citado" />
                    <asp:BoundField DataField="tipo_paciente" HeaderText="Tipo de Paciente" />
                     <asp:BoundField DataField="observacion" HeaderText="Observacion" />
                    <asp:BoundField DataField="nombre_usuario" HeaderText="Responsable" />    
                    <asp:BoundField DataField="fecha_registro" HeaderText="Fecha registro" />
                    
                 </Columns>
             </asp:GridView>
         </ContentTemplate>
     </ajaxToolkit:TabPanel>
        

    </ajaxToolkit:TabContainer>
 <asp:Button ID="btnControlModal" runat="server" Style="display:none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnControlModal" PopupControlID="Panel1" BackgroundCssClass="modalBackground" CancelControlID="btnCerrarCita" >

            </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" Style="display:none;" ScrollBars="Vertical">
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="modalPopupHeader">Citas</div>
            <fieldset class="fieldset">
                <legend class="legend">Datos Generales</legend>
                 <table style="margin:auto">
                <tr>
                    <td style="text-align:right">N° de DNI:</td>
                    <td><asp:TextBox ID="txtDni_cliente" runat="server" CssClass="textBoxDisabled" Width="60px" ClientIDMode="Static"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDni_cliente" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ErrorMessage="completar..."></asp:RequiredFieldValidator>
                        <asp:Button ID="btnBuscarPaciente" runat="server" Text=" " CssClass="btnOpenPopup" ToolTip="Buscar Paciente" OnClientClick="OpenListPacientes()" CausesValidation="false" />
                        <asp:TextBox ID="txtNombre_cliente" runat="server" CssClass="textBoxDisabled"  Width="410px" ClientIDMode="Static"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td style="text-align:right">Tipo Paciente:</td>
                     <td><asp:DropDownList ID="drpTipoPaciente" runat="server" Width="200px" CssClass="dropDownList">
                        <asp:ListItem Value="1">Particular</asp:ListItem>
                        <asp:ListItem Value="2">Asegurado</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                
                <tr>
                    <td style="text-align:right">Plan Asegurador:</td>
                    <td> <asp:DropDownList ID="drpCiaAseguradora" runat="server" CssClass="dropDownList" Width="510px"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                             <td style="text-align:right"></td>
                             <td> 
                                 <fieldset class="fieldset">
                    <legend class="legend">Servicios</legend>
                     <table >
                                <tr>
                                    <td style="text-align:left">Código</td>
                                    <td style="text-align:left">Descripción</td>
                                    <td style="text-align:left">Precio Unit.</td>
                                    <td style="text-align:left">Cantidad</td>
                                                    
                                </tr>
                                <tr>
                                     <td><asp:TextBox ID="txtId_ItemCatalogo" runat="server" Width="100px" CssClass="textBoxDisabled" ClientIDMode="Static" ></asp:TextBox></td>
                                     <td><asp:TextBox ID="txtDescrip_catalogo" runat="server" Width="300px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox></td>
                                    <td><asp:TextBox ID="txtPrecio_item" runat="server" Width="100px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                                        <asp:Button ID="btnOpenCatalogo" runat="server" Text=" " CssClass="btnOpenPopup" OnClientClick="OpenCatalogoItems()" ToolTip="Buscar Items"/>
                                    </td>
                                    <td><asp:TextBox ID="txtCantidad_item" runat="server" Width="60px" Text="1" CssClass="txtboxNumber" MaxLength="5" onkeyPress="return soloNumeros(event)"></asp:TextBox>
                                        <asp:TextBox ID="txtIdGrupo_item" runat="server" Width="20px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                                        <asp:TextBox ID="txtIdClase_item" runat="server" Width="20px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                                        <asp:Button ID="btnImputar" runat="server" CssClass="btnCkeckData"  Text=" " ToolTip="Imputar cantidad" OnClick="CargarItemsCatalogo" />
                                    </td>
                                </tr>
                                   
                            </table>
                    <asp:GridView ID="grdDetalleCita" runat="server" CssClass="gridView" AutoGenerateColumns="false" >                   
                      <Columns>
                            <asp:BoundField DataField="Col1" HeaderText="N°" />
                            <asp:BoundField DataField="Col2" HeaderText="Hora" /> 
                            <asp:BoundField DataField="Col3" HeaderText="Código" /> 
                            <asp:BoundField DataField="Col4" HeaderText="Descripcion" />  
                            <asp:BoundField DataField="Col5" HeaderText="Precio" /> 
                            <asp:BoundField DataField="Col6" HeaderText="Cantidad" /> 
                            <asp:BoundField DataField="Col7" HeaderText="IdGrupo" /> 
                            <asp:BoundField DataField="Col8" HeaderText="IdClase" /> 
                          <asp:TemplateField HeaderText="">
                         <ItemTemplate>
                             <asp:Button ID="btnBorrarFila" runat="server" CssClass="buttonIconDelete" ToolTip="Quitar artículo" OnClick="BorrarFila"  /> 
                         </ItemTemplate>
                
                      </asp:TemplateField>
                      </Columns>
                    </asp:GridView>                      
                </fieldset>
                             </td>
                 </tr>
                <tr>
                    <td style="text-align:right">Fecha de Cita</td>
                    <td><asp:Label ID="lblFecha_cita" runat="server" Text="" CssClass="label"></asp:Label>
                       
                    </td>
                </tr>
                <tr>
               <td style="text-align:right">Observacion:</td>
                  <td><asp:TextBox ID="txtObservacion" runat="server" CssClass="textbox" Width="500px" TextMode="MultiLine" Height="50px"></asp:TextBox></td>
              </tr>
                <tr>
                             <td style="text-align:right">Admisionista:</td>
                             <td><asp:Label ID="lblUsuario" runat="server" CssClass="label"></asp:Label> </td>
                         </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnGuardarCita" runat="server" Text="Guardar" CssClass="button" OnClick="GuardarNuevaCita" />
                        <asp:Label ID="lblNumero_cita" runat="server" Text="" CssClass="label"></asp:Label>
                        <asp:Label ID="lblMsj" runat="server" Text="" ForeColor="Green" Font-Bold="true"></asp:Label>
                        <asp:Button ID="btnCerrarCita" runat="server" Text="Cerrar" OnClick="CerrarNuevaCita" CssClass="button" CausesValidation="false" /></td>
                </tr>
            </table>
            </fieldset>
           

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>

</asp:Content>
 
