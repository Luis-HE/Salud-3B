<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmGuiaRemision.aspx.cs" Inherits="CapaPresentacion.Forms.frmGuiaRemision" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
  <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanelGuiaRemision" ID="tbPanelGuiaRemision">
         <HeaderTemplate><asp:Label ID="Label1" runat="server" Text="Guia de Remisión" Width="150px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
        <ContentTemplate>
            <table style="width:100%">
        <tr>
            <td>
             <fieldset class="fieldset">
      <legend class="legend">Guia de Remisión - REMITENTE</legend>
      <table>
          <tr>
              <td style="text-align:right">Inicio del Traslado:</td>
              <td><asp:TextBox ID="txt_fechaTraslado" runat="server" Width="100px" CssClass="textbox"></asp:TextBox></td>
          </tr>
          <tr>
              <td style="text-align:right">Destinatario:</td>
              <td><asp:TextBox ID="txt_destinatario" runat="server" Width="300px" CssClass="textbox"></asp:TextBox> </td>
          </tr>
          <tr>
              <td style="text-align:right">RUC:</td>
              <td><asp:TextBox ID="txtruc_guia" runat="server" Width="100px" CssClass="textbox"></asp:TextBox> </td>
          </tr>
          <tr>
              <td style="text-align:right">N°. de DNI:</td>
              <td><asp:TextBox ID="txtdni_guia" runat="server" Width="100px" CssClass="textbox"></asp:TextBox> </td>
          </tr>
          <tr>
              <td style="text-align:right">Punto de Partida:</td>
              <td><asp:TextBox ID="txt_ptopartida" runat="server" Width="300px" CssClass="textbox"></asp:TextBox> </td>
          </tr>
          <tr>
              <td style="text-align:right">Punto de Llegada:</td>
              <td><asp:TextBox ID="txt_ptollegada" runat="server" Width="300px" CssClass="textbox"></asp:TextBox> </td>
          </tr>
          <tr>
              <td style="text-align:right">Motivo del Taslado:</td>
              <td>
                  <asp:DropDownList ID="drpMotivoTraslado" runat="server" Width="310px" CssClass="dropDownList">
                      <asp:ListItem Value="01">Venta</asp:ListItem>
                      <asp:ListItem Value="02">Compra</asp:ListItem>
                      <asp:ListItem Value="03">Consignación</asp:ListItem>
                      <asp:ListItem Value="04">Venta con entrega a terceros</asp:ListItem>
                      <asp:ListItem Value="05">Venta sujeta a confirmación por el comprador</asp:ListItem>
                      <asp:ListItem Value="06">Traslado entre establecimientos de la misma empresa</asp:ListItem>
                      <asp:ListItem Value="07">Devolución</asp:ListItem>
                      <asp:ListItem Value="08">Recojo de bienes</asp:ListItem>
                      <asp:ListItem Value="09">Importación</asp:ListItem>
                      <asp:ListItem Value="10">Exportación</asp:ListItem>
                      <asp:ListItem Value="11">Traslado zona primaria</asp:ListItem>
                      <asp:ListItem Value="12">Traslado por emisor itinerario</asp:ListItem>
                      <asp:ListItem Value="13">Traslado de bienes para transformación</asp:ListItem>                    
                  </asp:DropDownList>
              </td>
          </tr>
       </table>
  </fieldset>
            </td>
            <td>
             <fieldset class="fieldset">
        <legend class="legend">Datos del Transportista</legend>
        <table>
            <tr>
                <td style="text-align:right">RUC:</td>
                <td><asp:TextBox ID="txtruc_tansportista" runat="server" Width="100px" CssClass="textbox"></asp:TextBox> </td>
            </tr>
            <tr>
                 <td style="text-align:right">Razon Social/Apellidos y Nombres:</td>
                <td><asp:TextBox ID="txt_apellNombre" runat="server" Width="300px" CssClass="textbox"></asp:TextBox> </td>
            </tr>
            <tr>
                <td style="text-align:right">Marca del Vehículo:</td>
                <td><asp:TextBox ID="txtmarca" runat="server" Width="100px" CssClass="textbox"></asp:TextBox></td>
            </tr>
            <tr>
                 <td style="text-align:right">Placa:</td>
                <td><asp:TextBox ID="txtplaca" runat="server" Width="100px" CssClass="textbox"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="text-align:right">Licencia de Conducir:</td>
                <td><asp:TextBox ID="txtlicencia" runat="server" Width="100px" CssClass="textbox"></asp:TextBox></td>
            </tr> 
            <tr>
                <td></td>
                <td><asp:Button ID="btnGuardarGuia" runat="server" Text="Guardar" CssClass="button" />
                    <asp:Button ID="btnImprimir" runat="server" Text="Imprimir" CssClass="button" />

                </td>
            </tr> 
        </table>
    </fieldset>
            </td>
        </tr>
        <tr>
            <td colspan="2">
             <fieldset class="fieldset">
        <legend class="legend">Detalle del Documento</legend>
        <table>
            <tr>
                <td>Cod. Artículo:</td>
                <td>Descripción:</td>
                <td>Unid. Medida:</td>
                <td>Peso:</td>
                <td>Cantidad:</td>
            </tr>
            <tr>
                <td><asp:TextBox ID="txt_codArt" runat="server" Width="100px" CssClass="textbox"></asp:TextBox>
                    <asp:Button ID="btn_Popup_guia" runat="server" Text=" " CssClass="btnOpenPopup" />
                </td>
                <td><asp:TextBox ID="txt_descripcion" runat="server" Width="400px" CssClass="textbox"></asp:TextBox> </td>
                <td><asp:TextBox ID="txt_unidaMed" runat="server" Width="100px" CssClass="textbox"></asp:TextBox></td>
                <td><asp:TextBox ID="txt_peso" runat="server" Width="100px" CssClass="textbox"></asp:TextBox></td>
                <td><asp:TextBox ID="txt_cantidad" runat="server" Width="100px" CssClass="textbox"></asp:TextBox>
                    <asp:Button ID="btnGuardarDetalle" runat="server" Text="Agregar" CssClass="button" OnClick="btnGuardarDetalle_Click" />
                </td>
            </tr> 
            
        </table>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" CssClass="gridView" Width="100%" OnRowDeleting="DeleteDetalleGuiaRemision">
            <Columns>
                <asp:BoundField DataField="columna1" HeaderText="Cod. Artículo" />
                <asp:BoundField DataField="columna2" HeaderText="Descripcion" />
                <asp:BoundField DataField="columna3" HeaderText="Cantidad" />
                <asp:BoundField DataField="columna4" HeaderText="Unidad de Medida" />
               <%-- <asp:BoundField DataField="columna5" HeaderText="Peso" />--%>
                <asp:CommandField ShowDeleteButton="true" ButtonType="Image" DeleteImageUrl="~/Images/delete.png" />
            </Columns>
            <EmptyDataTemplate>
                <table style="width: 100%;border: medium solid #00F">
                    <tr>
                        <td>Cod. Artículo</td>
                        <td>Descripción</td>
                        <td>Cantidad</td>
                        <td>Unidad de Medida</td>
                        <td>Peso</td>
                    </tr>                  
                </table>
            </EmptyDataTemplate>
        </asp:GridView>
    </fieldset>
            </td>
        </tr>
    </table>
        </ContentTemplate>
     </ajaxToolkit:TabPanel>
     <ajaxToolkit:TabPanel runat="server" HeaderText="TabOrdenTraslado" ID="tbPanelOrdenTraslado">
         <HeaderTemplate><asp:Label ID="Label2" runat="server" Text="Orden de Traslado" Width="150px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
         <ContentTemplate>

         </ContentTemplate>
     </ajaxToolkit:TabPanel>

    </ajaxToolkit:TabContainer>
</asp:Content>
 