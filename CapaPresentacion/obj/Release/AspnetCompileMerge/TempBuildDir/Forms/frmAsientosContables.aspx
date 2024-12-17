<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmAsientosContables.aspx.cs" Inherits="CapaPresentacion.Forms.frmAsientosContables" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
 

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<fieldset class="fieldset">
      <legend class="legend">Asientos Contables</legend>
      <table style="margin:auto">
          <tr>
              <td style="text-align:right">Periodo:</td>
              <td><asp:TextBox ID="txtPeriodo" runat="server" CssClass="textbox" Width="100px"></asp:TextBox></td>
          </tr>
           <tr>
             <td style="text-align:right">Mes:</td>
             <td><asp:DropDownList ID="drpMes" runat="server" Width="110px" CssClass="dropDownList">
                 <asp:ListItem Value="1">Enero</asp:ListItem>
                 <asp:ListItem Value="2">Febrero</asp:ListItem>
                 <asp:ListItem Value="3">Marzo</asp:ListItem>
                 <asp:ListItem Value="4">Abril</asp:ListItem>
                 <asp:ListItem Value="5">Mayo</asp:ListItem>
                 <asp:ListItem Value="6">Junio</asp:ListItem>
                 <asp:ListItem Value="7">Julio</asp:ListItem>
                 <asp:ListItem Value="8">Agosto</asp:ListItem>
                 <asp:ListItem Value="9">Setiembre</asp:ListItem>
                 <asp:ListItem Value="10">Octubre</asp:ListItem>
                 <asp:ListItem Value="11">Noviembre</asp:ListItem>
                 <asp:ListItem Value="12">Diciembre</asp:ListItem>
                 </asp:DropDownList>
              </td>
         </tr>    
          <tr>
              <td style="text-align:right">Cliente (RUC y/o DNI):</td>
              <td><asp:TextBox ID="txtRucDni" runat="server" Width="100px" CssClass="textbox" ></asp:TextBox>
                  <asp:Button ID="btnBuscar" runat="server" Text=" " CssClass="btnOpenPopup" OnClick="ListarAsientos" ToolTip="Listar Asientos" />
              </td>
          </tr>
          <tr>
              <td></td>
              <td><asp:Button ID="btnCerrarAsientos" runat="server" Text="Cerrar" CssClass="button" OnClick="CerrarAsiento" /></td>
          </tr>
      </table>
    <asp:GridView ID="grdAsientosContables" runat="server" AutoGenerateColumns="false" CssClass="gridViewCita">
        <Columns>
             <asp:BoundField DataField="id_regAsiento" HeaderText="Id Registro" />
             <asp:BoundField DataField="fecha_operacion" HeaderText="Fecha" />
             <asp:BoundField DataField="descrip_operacion" HeaderText="Descripción Operación" />
             <asp:BoundField DataField="tipo_doc_contable" HeaderText="Tipo Doc." />
             <asp:BoundField DataField="num_doc_contable" HeaderText="Num. Documento" />
             <asp:BoundField DataField="cod_cuenta_contable" HeaderText="Cta. Contable" />
             <asp:BoundField DataField="descripcion_cuenta" HeaderText="Denominación" />
             <asp:BoundField DataField="debe" HeaderText="Debe" />
             <asp:BoundField DataField="haber" HeaderText="Haber" />
        </Columns>
        <EmptyDataTemplate>
                        <table style="width:100%">
                            <tr>
                                <td>No data Found</td>
                            </tr>
                        </table>
        </EmptyDataTemplate> 
    </asp:GridView>
</fieldset>
</asp:Content>

