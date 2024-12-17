<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmHospitalizacion.aspx.cs" Inherits="CapaPresentacion.Forms.frmHospitalizacion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
   <script type="text/javascript" src="../Scripts/jquery.min.js"> </script>
   <script type="text/javascript" src="../Scripts/SoloNumeros.js"></script>
  <script type="text/javascript" src="../Scripts/TexboxEnterNextControl.js"></script>

     <script src="../Scripts/SoloNumeros.js"></script>
 <script type="text/javascript"> 
    function OpenListEmpleados()
    {
        window.open("../Forms/frmListar_Medicos.aspx", 'Lista Empresas', 'height=550,width=600,left=265,top=165,resizable=No,toolbar=No')
    }
    function OpenListCatalogoCie()
    {
        window.open("../Forms/frmListar_CatalogoCie.aspx", 'Lista Empresas', 'height=550,width=600,left=265,top=165,resizable=No,toolbar=No')
    }
    function OpenListAcompanante()
    {
        window.open("../Forms/frmListarAcompanante.aspx", 'Lista Acompañantes', 'height=550,width=600,left=265,top=0,resizable=No,toolbar=No')
    }
</script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
 <fieldset class="fieldset">
     <legend class="legend">Hospitalización</legend>
 <table style="width:100%;">
        <tr>
            <td style="text-align:center"><h3>Camas de Hospitalización</h3></td>
         </tr>
        <tr>
            <td style="text-align:center">
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Cantidad Total:<asp:Label ID="lblCantidadTotal" runat="server" Text="0" CssClass="label" Width="100px"></asp:Label> <br />
             Cantidad Diponibles:<asp:Label ID="lblCantidadDisponible" runat="server" Text="0" CssClass="label" Width="100px"></asp:Label><br />
             &nbsp;Cantidad Ocupadas:<asp:Label ID="lblCantidadOcupada" runat="server" Text="0" CssClass="label" Width="100px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:DataList ID="dtListCamas" runat="server" RepeatColumns="5" Width="100%" OnItemDataBound="On_ItemDataBound"   >
                    <ItemTemplate>
                        <table style="width:100%;border:2px solid #1f497d;">
                         <tr>
                         <td><asp:HiddenField ID="hidIdCama" runat="server" Value='<%# Eval("id_cama") %>' /><br/>
                             <asp:Label ID="lbldescripcion" runat="server" CssClass="label" Width="200px" Text='<%#Eval("descripcion") %>'></asp:Label> <br/>                          
                             <asp:Label ID="lblUbicacion" runat="server" CssClass="label" Width="200px"  Text='<%#Eval("ubicacion") %>' ></asp:Label><br/>
                             <asp:Label ID="lblEstado" runat="server" CssClass="label" Width="200px"  Text='<%#Eval("estado") %>'></asp:Label><br/>
                         </td>                          
                        </tr>
                            <tr>
                                <td style="text-align:center"><asp:Button ID="btnOcupar" runat="server" Text="Ocupar" CssClass="button" OnClick="OpenHospitalizar" /></td>
                            </tr>
                      </table>
                    </ItemTemplate>
                </asp:DataList>
            </td>             
        </tr>
    </table>

     <asp:Button ID="btnBotonModal" runat="server" Style="display:none" />
     <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnBotonModal" PopupControlID="Panel1" BackgroundCssClass="modalBackground" CancelControlID="btnCerrarPopUp">

     </ajaxToolkit:ModalPopupExtender>
     <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" Style="display:none">
         <asp:UpdatePanel runat="server">
             <ContentTemplate>
                 <div class="modalPopupHeader">Hospitalización...</div>
                 <table>
            <tr>
                 <td style="text-align:right">N° de Historia Clínica:</td>
                 <td><asp:Label ID="lblNumeroHistoriaClinica" runat="server" Text="" CssClass="label"></asp:Label></td>
             </tr>
             <tr>
                 <td style="text-align:right">N° de Documento del Paciente:</td>
                 <td><asp:Label ID="lblNumeroDocumento" runat="server" Text="" CssClass="label"></asp:Label></td>
             </tr>
             <tr>
                 <td style="text-align:right">Origen:</td>
                 <td><asp:DropDownList ID="drpOrigen" runat="server" CssClass="dropDownList" Width="200px"></asp:DropDownList></td>
             </tr>
              <tr>
                 <td style="text-align:right">N° de Cama:</td>
                 <td><asp:Label ID="lblIdCama" runat="server" Text="" CssClass="label"></asp:Label> </td>
             </tr>
             <tr>
                 <td style="text-align:right">Piso:</td>
                 <td><asp:Label ID="lblIdPiso" runat="server" Text="" CssClass="label"></asp:Label> </td>
             </tr>
              <tr>
                 <td style="text-align:right">Edad:</td>
                 <td><asp:TextBox ID="txtEdad" runat="server" CssClass="textbox"></asp:TextBox> </td>
             </tr>
              <tr>
                 <td style="text-align:right">Recien nacido:</td>
                 <td>SI <asp:RadioButton ID="rdNacidoSi" runat="server" GroupName="Nacido" />
                     NO <asp:RadioButton ID="rdNacidoNo" runat="server" GroupName="Nacido" />
                 </td>
             </tr>
              <tr>
                 <td style="text-align:right">Médico que Autoriza Ingreso:</td>
                 <td><asp:TextBox ID="txtDni_empleado" runat="server" Width="100px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                    <asp:Button ID="btnBuscarMedico" runat="server" Text=" " CssClass="btnOpenPopup" OnClientClick="OpenListEmpleados()" ToolTip="Buscar Médicos"/>                  
                    <asp:TextBox ID="txtNombre_empleado" runat="server" Width="235px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                </td>
             </tr>
               <tr>
                 <td style="text-align:right">Servicio que Ingresa:</td>
                 <td><asp:DropDownList ID="drpServicioIngresa" runat="server" CssClass="dropDownList" Width="200px"></asp:DropDownList></td>
             </tr>
             <tr>
               <td style="text-align:right">Diagnóstico(CIE10):</td>
                <td><asp:TextBox ID="txtCod_ciediez" runat="server" Width="100px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                    <asp:Button ID="btnBuscarCiediez" runat="server" Text=" " CssClass="btnOpenPopup" OnClientClick="OpenListCatalogoCie()" ToolTip="Buscar CIE10"/>
                    <asp:TextBox ID="txtNombre_ciediez" runat="server" Width="600px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                </td>
            </tr>
            <tr>
               <td style="text-align:right">Acompañante:</td>
                 <td><asp:TextBox ID="txtIdAcompanante" runat="server" Width="100px" Text="1"  CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                 <asp:Button ID="btnBuscaAcompanante" runat="server" Text=" " CssClass="btnOpenPopup" ToolTip="Buscar" OnClientClick="OpenListAcompanante()"   />
                  <asp:TextBox ID="txtNombreAcompanante" runat="server" Text="Ninguno" Width="370px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                 </td>
            </tr>
             <tr>
                 <td style="text-align:right">Destino:</td>
                 <td><asp:TextBox ID="txtDestino" runat="server" Width="400px" Height="50px" CssClass="textbox" TextMode="MultiLine"></asp:TextBox></td>
             </tr>
             <tr>
                 <td style="text-align:right">Tipo Alta:</td>
                 <td><asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropDownList" Width="200px"></asp:DropDownList></td>
             </tr>
             <tr>
                 <td style="text-align:right">Condición de Alta:</td>
                 <td>
                     <asp:TextBox ID="txtCondicion" runat="server" CssClass="textbox" Width="400px"></asp:TextBox></td>
             </tr>

             <tr>
                 <td></td>
                 <td>
                     <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="button" OnClick="GuardarHospitalizar" />
                    <asp:Label ID="lblMsj" runat="server" Text="" ForeColor="Green" Font-Bold="true"></asp:Label>
                     <asp:Button ID="btnCerrarPopUp" runat="server" Text="Cerrar" CssClass="button" OnClick="CerrarHospitalizar" />
                 </td>
             </tr>
         </table>
             </ContentTemplate>
         </asp:UpdatePanel>
         
     </asp:Panel>
 </fieldset>
</asp:Content>
 
 
 
