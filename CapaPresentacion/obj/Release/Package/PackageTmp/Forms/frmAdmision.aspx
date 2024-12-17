<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmAdmision.aspx.cs" Inherits="CapaPresentacion.Forms.frmAdmision" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
     <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
   <script type="text/javascript" src="../Scripts/jquery.min.js"> </script>
   <script type="text/javascript" src="../Scripts/SoloNumeros.js"></script>
  <script type="text/javascript" src="../Scripts/TexboxEnterNextControl.js"></script>

     <script src="../Scripts/JQuery-1.4.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/FilterGridview.js"></script>

    <script type="text/javascript">
   $(document).ready(function() {
       //$('input[type="text"]').attr("disabled", "disabled");// to disable all textbox, color gray by defaul. But makes it empty to value of control
       $("#txtDni_cliente").attr("readonly", true);
       $("#txtNombre_cliente").attr("readonly", true);

       $("#txtIdAcompanante").attr("readonly", true);
       $("#txtNombreAcompanante").attr("readonly", true);

       $("#txtId_ItemCatalogo").attr("readonly", true);
       $("#txtDescrip_catalogo").attr("readonly", true);
       $("#txtPrecio_item").attr("readonly", true);
       $("#txtIdGrupo_item").attr("readonly", true);
       $("#txtIdClase_item").attr("readonly", true);
 
    return false; //to prevent from postback
    });
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

    <script type="text/javascript">
    function OpenListPacientes()
    {
        window.open("../Forms/frmListar_Pacientes.aspx", 'Lista Pacientes', 'height=650,width=600,left=265,top=0,resizable=No,toolbar=No')
    }
    function OpenListAcompanante()
    {
        window.open("../Forms/frmListarAcompanante.aspx", 'Lista Acompañantes', 'height=550,width=600,left=265,top=0,resizable=No,toolbar=No')
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

    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
         <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanelAdmision" ID="tbPanelAdmision">
            <HeaderTemplate><asp:Label ID="Label4" runat="server" Text="Admisión" Width="150px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
            <ContentTemplate>
              <table style="margin:auto">
                  <tr>
                      <td style="text-align:right">Especialidad:</td>
                      <td><asp:DropDownList ID="drpEspecialidad" runat="server" Width="200px" CssClass="dropDownList"></asp:DropDownList>
                          <asp:Button ID="btnListarTurnos" runat="server" Text=" " CssClass="btnOpenPopup" ToolTip="Buscar" OnClick="BuscarTurnos" CausesValidation="false" />
                      </td>
                  </tr>
                   <tr>
                   <td style="text-align:right">Filtar por DNI:</td>
                    <td><asp:TextBox ID="txtFiltarxDni" runat="server" CssClass="textbox" Width="100px" ClientIDMode="Static"></asp:TextBox></td>
                </tr>
              </table>
                <asp:GridView ID="grdTurnos" runat="server"  AutoGenerateColumns="false" CssClass="gridViewCita" OnRowDataBound="OnRowColorGridCell" ClientIDMode="Static" >
                    <Columns>
                        <asp:BoundField DataField="hora" HeaderText="Hora" />
                        <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnCreaAdmision" runat="server" CssClass="buttonIconPlus" ToolTip="Admision" OnClick="OpenNuevaAdmision" CausesValidation="false" />
                        </ItemTemplate>
                       </asp:TemplateField>
                        <asp:BoundField DataField="dni_paciente" HeaderText="Paciente" />                      
                        <asp:BoundField DataField="dni_empleado" HeaderText="Médico" />
                        <asp:BoundField DataField="estado" HeaderText="Estado" />
                        <asp:BoundField DataField="id_turno" HeaderText="Id" /> 
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Button ID="btnOpenCitado" runat="server" CssClass="buttonIconOk" ToolTip="Admitir Paciente" OnClick="OpenPopupCitado" CausesValidation="false" />
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
                <asp:Button ID="btnOpemModal" runat="server" Style="display:none"/>
                  <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnOpemModal" BackgroundCssClass="modalBackground" PopupControlID="Panel1">

                 </ajaxToolkit:ModalPopupExtender>
                <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" ScrollBars="Vertical">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
                        
                        <ContentTemplate>
                            <div class="modalPopupHeader">Admisión Ambulatoria</div>
                            <fieldset class="fieldset">
                    <legend class="legend">Datos Generales</legend>
                     <table style="margin:auto">
                          <tr>
                            <td style="text-align:right">N° de DNI:</td>
                            <td><asp:TextBox ID="txtDni_cliente" runat="server" Width="100px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDni_cliente" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ErrorMessage="completar..."></asp:RequiredFieldValidator>
                                <asp:Button ID="btnBuscarPaciente" runat="server" Text=" " CssClass="btnOpenPopup" ToolTip="Buscar" OnClientClick="OpenListPacientes()" CausesValidation="false" />                                
                                <asp:TextBox ID="txtNombre_cliente" runat="server" Width="370px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                            </td>
                        </tr>

                         <tr>
                          <td style="text-align:right">Tipo de Paciente:</td>
                            <td><asp:DropDownList ID="drpTipoPaciente" runat="server" Width="510px" CssClass="dropDownList">
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
                                    <td><asp:TextBox ID="txtCantidad_item" runat="server" Width="100px" Text="1" CssClass="txtboxNumber" MaxLength="5" onkeyPress="return soloNumeros(event)"></asp:TextBox>
                                        <asp:TextBox ID="txtIdGrupo_item" runat="server" Width="20px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                                        <asp:TextBox ID="txtIdClase_item" runat="server" Width="20px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                                        <asp:Button ID="btnImputar" runat="server" CssClass="btnCkeckData"  Text=" " ToolTip="Imputar cantidad" OnClick="CargarItemsCatalogo" />
                                    </td>
                                </tr>
                                   
                            </table>
                    <asp:GridView ID="grdDetalleAdmision" runat="server" CssClass="gridView" AutoGenerateColumns="false" >                   
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
                             <asp:Button ID="btnBorrarFila" runat="server" CssClass="buttonIconDelete" ToolTip="Quitar artículo"  OnClick="BorrarFila" /> 
                         </ItemTemplate>
                
                      </asp:TemplateField>
                      </Columns>
                    </asp:GridView>                      
                </fieldset>
                             </td>
                         </tr>
                         <tr>
                          <td style="text-align:right">Cobertura:</td>
                           <td><asp:TextBox ID="txtCobertura" runat="server" Width="130px" CssClass="txtboxNumber" Text="0"></asp:TextBox> %</td>
                         </tr>
                         <tr>
                             <td style="text-align:right">N°. Carta Garantia:</td>
                             <td><asp:TextBox ID="txtNumCartaGrantia" runat="server" Width="130px" CssClass="textbox"></asp:TextBox></td>
                         </tr>
                          <tr>
                          <td style="text-align:right">Adelanto (S/.):</td>
                           <td><asp:TextBox ID="txtMonto_adelanto" runat="server" Width="130px" CssClass="txtboxNumber" Text="0"></asp:TextBox></td>
                         </tr>                        
                         
                        <tr>
                            <td style="text-align:right">Tipo de Atencion:</td>
                            <td><asp:DropDownList ID="drpTipoAtencion" runat="server" Width="510px" CssClass="dropDownList">
                                <asp:ListItem Value="1">Ambulatoria</asp:ListItem>
                                <asp:ListItem Value="2">Urgencia</asp:ListItem>
                                <asp:ListItem Value="3">Emergencia</asp:ListItem>
                                </asp:DropDownList></td>
                        </tr>         
                        <tr>
                            <td style="text-align:right">Acompañante:</td>
                            <td><asp:TextBox ID="txtIdAcompanante" runat="server" Width="100px" Text="1"  CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                                 <asp:Button ID="btnBuscaAcompanante" runat="server" Text=" " CssClass="btnOpenPopup" ToolTip="Buscar" OnClientClick="OpenListAcompanante()"   />
                                <asp:TextBox ID="txtNombreAcompanante" runat="server" Text="Ninguno" Width="370px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align:right">Garante:</td>
                            <td><asp:TextBox ID="txtGarante" runat="server" Width="500px" CssClass="textbox"></asp:TextBox></td>
                        </tr>                     
                          <tr>
                            <td style="text-align:right">Observación:</td>
                            <td><asp:TextBox ID="txtObs_atencion" runat="server" Width="500px" CssClass="textbox" TextMode="MultiLine" Height="50px"></asp:TextBox></td>
                        </tr>

                         <tr>
                             <td style="text-align:right">Admisionista:</td>
                             <td><asp:Label ID="lblUsuario" runat="server" CssClass="label"></asp:Label> </td>
                         </tr>
                          <tr>
                         <td></td>
                          <td>
                            <asp:Button ID="btnGuardarAdmision" runat="server" Text="Guardar" CssClass="button" OnClick="GuardarAdmision"  />
                            <asp:Label ID="lblMsj" runat="server" Text="" ForeColor="Green" Font-Bold="true"></asp:Label>
                            <asp:Label ID="lblNumero_atencion" runat="server" Text="" CssClass="label"></asp:Label>
                            <%--<asp:Button ID="btnImprimir" runat="server" Text="Imprimir" CssClass="button" CausesValidation="false"    />--%>
                            <asp:Button ID="btnCerrarAdmision" runat="server" Text="Cerrar"  CssClass="button" OnClick="CerrarNuevaAdmision" CausesValidation="false"   /></td>
                         </tr>
                   </table>
                
                </fieldset>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
                 
         
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
    </ajaxToolkit:TabContainer>


</asp:Content>
 
