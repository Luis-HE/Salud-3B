<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmConvenios.aspx.cs" Inherits="CapaPresentacion.Forms.frmConvenios" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
   <script type="text/javascript" src="../Scripts/SoloNumeros.js"></script>

   <script type="text/javascript" src="../Scripts/jquery.min.js"> </script>
  <script type="text/javascript" src="../Scripts/TexboxEnterNextControl.js"></script>

 
 
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   <fieldset class="fieldset">
       <legend class="legend">Convenios</legend>
<table style="margin:auto">
    <tr>
        <td style="text-align:right">Plan Asegurador:</td>
        <td> <asp:DropDownList ID="drpCiaAseguradora" runat="server" CssClass="dropDownList" Width="510px"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="text-align:right">Fecha de Convenio:</td>
        <td>
            <asp:TextBox ID="txtfecha_convenio" runat="server" CssClass="textbox" Width="100px" ></asp:TextBox>
             <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfecha_convenio" Format="dd/MM/yyyy" CssClass="calendar"  />
        </td>
    </tr>
    <tr>
        <td style="text-align:right">Duracion:</td>
        <td><asp:TextBox ID="txt_duracion" runat="server" CssClass="textbox" Width="100px"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="text-align:right">Firmante:</td>
        <td><asp:TextBox ID="txt_firmante" runat="server" CssClass="textbox" Width="500px"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="text-align:right">Observación:</td>
        <td><asp:TextBox ID="txt_observacion" runat="server" CssClass="textbox" Width="500px" TextMode="MultiLine" Height="100px"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="text-align:right"></td>
        <td><asp:Button ID="btnGuardarConvenio" runat="server" Text="Guardar" CssClass="button" OnClick="btnGuardarConvenio_Click"/>
            <asp:Button ID="btnCerrarConvenio" runat="server" Text="Cerrar" CssClass="button" OnClick="CerrarConvenio" />
        </td>
    </tr>
</table>
   </fieldset>
       <asp:GridView ID="grdConvenios" runat="server" AutoGenerateColumns="false" CssClass="gridView">
           <Columns>
               <asp:BoundField DataField="id_reg_convenio" HeaderText="ID" />
               <asp:BoundField DataField="id_cia_seguro" HeaderText="Cod" />               
                <asp:BoundField DataField="fecha_convenio" HeaderText="Fecha" />
                <asp:BoundField DataField="duracion" HeaderText="Duración" />
                <asp:BoundField DataField="firmante" HeaderText="Firmante" />
                <asp:BoundField DataField="observacion" HeaderText="Observación" />
             <asp:TemplateField>
                 <ItemTemplate>
                     <asp:Button ID="btnEditar" runat="server" CssClass="buttonIconEdit" ToolTip="Editar" />
                 </ItemTemplate>
             </asp:TemplateField>
               <asp:TemplateField>
                 <ItemTemplate>
                     <asp:Button ID="btnDetalles" runat="server" CssClass="buttonIconFind" ToolTip="Detalles" OnClick="DetalleConvenio" />
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
    <asp:Button ID="btnControlModal" runat="server" Style="display:none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnControlModal" PopupControlID="Panel1" BackgroundCssClass="modalBackground" CancelControlID="btnCerrarDetalle" >

    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" Style="display:none;" ScrollBars="Vertical">
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
              <table style="margin:auto">
                  <tr>
                      <td style="text-align:right">Factor de cálculo:</td>
                      <td><asp:TextBox ID="txtFactor" runat="server" CssClass="txtboxNumber" Width="100px" Text="0"></asp:TextBox></td>
                  </tr>
              </table>
              <asp:GridView ID="grdListaServicios" runat="server" AutoGenerateColumns="false" ShowFooter="true" CssClass="gridViewCita">
                  <Columns>
                      <asp:BoundField DataField="cod_item_catalogo" HeaderText="Código" />
                      <asp:BoundField DataField="descripcion_principal" HeaderText="Nombre" />
                       
                      <asp:TemplateField HeaderText="Precio">
                          <ItemTemplate>
                              <asp:TextBox ID="txtPrecio" runat="server" Width="100px" Text='<%# Eval("Precio") %>' CssClass="txtboxNumber" onkeyPress="return soloNumeros(event)"  ></asp:TextBox>
                          </ItemTemplate>
                      </asp:TemplateField>                                          
                      <asp:TemplateField HeaderText="Porcentaje">
                          <ItemTemplate>
                              <asp:TextBox ID="txtPorcentaje" runat="server" Width="100px" Text="0" CssClass="txtboxNumber" onkeyPress="return soloNumeros(event)"></asp:TextBox>
                          </ItemTemplate>
                          <FooterTemplate>
                              <asp:Button ID="btnGuardarDetalleConvenio" runat="server" Text="Guardar" CssClass="button" OnClick="GuardarDetalleConvenio" />   
                          </FooterTemplate>
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
              <table style="margin:auto;">
            <tr>
                 <td>
                   <asp:Button ID="btnCerrarDetalle" runat="server" Text="Cerrar" OnClick="CerrarDetalle" CssClass="button" />
                </td>
            </tr>
        </table>
          </ContentTemplate>
      </asp:UpdatePanel>
         
    </asp:Panel>

</asp:Content>