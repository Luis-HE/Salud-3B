<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmCuentasXpagar.aspx.cs" Inherits="CapaPresentacion.Forms.frmCuentasXpagar" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
      <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
   <script type="text/javascript" src="../Scripts/jquery.min.js"> </script>
   <script type="text/javascript" src="../Scripts/SoloNumeros.js"></script>
  <script type="text/javascript" src="../Scripts/TexboxEnterNextControl.js"></script>
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <table style="margin:auto">
         <tr>
             <td>Mes:</td>
             <td><asp:DropDownList ID="drpMes" runat="server" CssClass="dropDownList" Width="100px">  </asp:DropDownList>
                 <asp:Button ID="btnBuscarCompras" runat="server" Text=" " CssClass="btnOpenPopup" OnClick="ListarCompras" />
             </td>
         </tr>
     </table>
     <asp:GridView ID="grdListaCompras" runat="server" CssClass="gridViewCita">
         <Columns>
             <asp:BoundField DataField="id" HeaderText="Id. Registro" />
             <asp:BoundField DataField="id" HeaderText="Proveedor" />
             <asp:BoundField DataField="id" HeaderText="Fecha Registro" />
             <asp:BoundField DataField="id" HeaderText="Monto Total" />
             <asp:BoundField DataField="id" HeaderText="Tipo Doc." />
             <asp:BoundField DataField="id" HeaderText="N°. Documento" />
         </Columns>
         <EmptyDataTemplate>
                        <table style="width:100%">
                            <tr>
                                <td>No data Found</td>
                            </tr>
                        </table>
         </EmptyDataTemplate> 
     </asp:GridView>
     <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
          <ajaxToolkit:TabPanel runat="server" HeaderText="tabpanelConciliacionCompras" ID="tbConciliacionCompras">
            <HeaderTemplate><asp:Label ID="lblpage1" runat="server" Text="Conciliación de Compras" Width="150px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
            <ContentTemplate>
                <table style="margin:auto">
              <tr>
            <td>Forma de Pago:</td>
            <td>
                <asp:DropDownList ID="drpFormasPagar" runat="server" CssClass="dropDownList">
                    <asp:ListItem Value="1">1 a 7 dias</asp:ListItem>
                    <asp:ListItem Value="2">8 a 15 dias</asp:ListItem>
                    <asp:ListItem Value="3">16 a 21 dias</asp:ListItem>
                    <asp:ListItem Value="4">22 a 30 dias</asp:ListItem>
                    <asp:ListItem Value="5">31 a 45 dias</asp:ListItem>
                    <asp:ListItem Value="6">46 a 60 dias</asp:ListItem>
                    <asp:ListItem Value="6">61 a 90 dias</asp:ListItem>
                    <asp:ListItem Value="6">91 a más </asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
            </ContentTemplate>
        </ajaxToolkit:TabPanel>

        <ajaxToolkit:TabPanel runat="server" HeaderText="tabPanelReporteCtasxPagar" ID="tbPanelReporteCtasxPagar">
            <HeaderTemplate><asp:Label ID="lblpage2" runat="server" Text="Reporte de Ctas. x Pagar" Width="150px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
            <ContentTemplate>

            </ContentTemplate>
        </ajaxToolkit:TabPanel>
     </ajaxToolkit:TabContainer>
 
</asp:Content>