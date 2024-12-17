<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmRevistaMedica.aspx.cs" Inherits="CapaPresentacion.Forms.frmRevistaMedica" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
      <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />

     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <fieldset class="fieldset">
         <legend class="legend">Revista Médica</legend>
         <table style="margin:auto">
             <tr>
                 <td><asp:Button ID="btnCerrarRevista" runat="server" CssClass="button" Text="Cerrar" OnClick="CerrarRevista" /></td>
             </tr>
         </table>
         <asp:GridView ID="GridView1" runat="server" CssClass="gridView" AutoGenerateColumns="false">
             <Columns>
             <asp:BoundField DataField="Dni" HeaderText="DNI" />
             <asp:BoundField DataField="Nombres" HeaderText="Nombres" />
             <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" />
             <asp:BoundField DataField="Fecha_hospitaliza" HeaderText="Fecha de Hospitalización" />
             <asp:BoundField DataField="Tiempo" HeaderText="Tiempo(dias)" />
             <asp:BoundField DataField="T_transcurrido" HeaderText="Tiempo Transcurrido" />
             <asp:BoundField DataField="Diagnostico" HeaderText="Diagnóstico" />
             <asp:BoundField DataField="Num_cama" HeaderText="Numero de Cama" />
             <asp:BoundField DataField="Costo" HeaderText="Costo Total" />
             <asp:BoundField DataField="Num_visitas" HeaderText="Revista Médica" />
             <asp:TemplateField HeaderText="Acciones">
                  <ItemTemplate>
                      <asp:ImageButton ID="imgBotonRegistraVisita" runat="server" ImageUrl="~/Images/find.png" OnClick="OpenRegistraVisita" ToolTip="Registrar Visita" />
                      <asp:ImageButton ID="imgBotonDetalleVisita" runat="server" ImageUrl="~/Images/notice.png" OnClick="OpenDetalleVisita" ToolTip="Detalle de Visitas" />
                      <asp:ImageButton ID="imgBotonDarAlta" runat="server" ImageUrl="~/Images/success.png" ToolTip="Dar de Alta" />
                  </ItemTemplate>
             </asp:TemplateField>       
              
             </Columns>
         </asp:GridView>
         <asp:Button ID="btnOpenModal" runat="server" Style="display:none"/>
         <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnOpenModal" PopupControlID="Panel1" BackgroundCssClass="modalBackground" CancelControlID="btnCancelarVisita">

         </ajaxToolkit:ModalPopupExtender>
         <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" Style="display:none">
             <div class="modalPopupHeader">Detalles...</div>
             <table>
                 <tr>
                     <td style="text-align:right">Estado del Paciente:</td>
                     <td></td>
                 </tr>
                 <tr>
                     <td style="text-align:right">Observaciones:</td>
                     <td></td>
                 </tr>
                 <tr>
                     <td style="text-align:right">Fecha de Revista:</td>
                     <td></td>
                 </tr>
                 <tr>
                     <td style="text-align:right">Hora de Revista:</td>
                     <td></td>
                 </tr>
                 <tr>
                     <td></td>
                     <td>
                         <asp:Button ID="btnGuardarVisita" runat="server" Text="Guardar" CssClass="button" />
                         <asp:Button ID="btnCancelarVisita" runat="server" Text="Cancelar" CssClass="button" />
                     </td>
                 </tr>
             </table>
         </asp:Panel>
         <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender2" runat="server" TargetControlID="btnOpenModal" PopupControlID="Panel2" BackgroundCssClass="modalBackground" CancelControlID="btnCancelarVista">

         </ajaxToolkit:ModalPopupExtender>
         <asp:Panel ID="Panel2" runat="server" CssClass="modalPopup" Style="display:none">
             <div class="modalPopupHeader">Detalles...</div>
             <table>
                 <tr>
                     <td>List Detallada de Visitas:</td>
                     <td></td>
                 </tr>
                 <tr>
                     <td></td>
                     <td>
                         <asp:Button ID="btnCancelarVista" runat="server" Text="Cancelar" CssClass="button" /></td>
                 </tr>
             </table>
         </asp:Panel>
     </fieldset>
 </asp:Content>
