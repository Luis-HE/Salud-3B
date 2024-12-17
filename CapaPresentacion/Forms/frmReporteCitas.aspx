<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmReporteCitas.aspx.cs" Inherits="CapaPresentacion.Forms.frmReporteCitas" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
   <script type="text/javascript" src="../Scripts/jquery.min.js"> </script>
   <script type="text/javascript" src="../Scripts/SoloNumeros.js"></script>
  <script type="text/javascript" src="../Scripts/TexboxEnterNextControl.js"></script>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table style="margin-top:-2px; margin-left:-2px; width:100%;" >
        <tr>
            <td style="width:99%;" ><img alt="" src="../Images/barra_menu.png"  style="margin-top:-2px;margin-left:-2px; width:100%; height:25px;" /> </td>
            <td style="width:1%;"> <asp:Button ID="btnCerrarPantalla" runat="server" Text=" " CssClass="btnCloseWindow" CausesValidation="false" OnClick="CerrarPantalla" /> </td>
        </tr>
    </table>  
    
     <table style=" margin:auto">
        <tr> 
            <td style="text-align:right">Desde:</td>
            <td> <asp:TextBox ID="txtfecha1" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfecha1" Format="dd/MM/yyyy" CssClass="calendar"  />
            </td>
            <td style="text-align:right">Hasta:</td>
            <td> <asp:TextBox ID="txtfecha2" runat="server" Width="200px" CssClass="textbox"></asp:TextBox>
                <ajaxToolkit:CalendarExtender ID="CalendarExtender2"  runat="server" TargetControlID="txtfecha2" Format="dd/MM/yyyy" CssClass="calendar"  />
            </td>
            <td></td>
            <td><asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="button" OnClick="listarReporte" /></td>
        </tr>
    </table>
    <asp:GridView ID="grdReporteCitas" runat="server" CssClass="gridViewCita" AutoGenerateColumns="false" >
        <Columns>
            <asp:BoundField DataField="col1" HeaderText="N° de DNI" />
            <asp:BoundField DataField="col2" HeaderText="Apellidos" />
            <asp:BoundField DataField="col3" HeaderText="Nombres" />
            <asp:BoundField DataField="col4" HeaderText="Fecha Registro" />
            <asp:BoundField DataField="col5" HeaderText="Fecha Cita" /> 
             <asp:BoundField DataField="col6" HeaderText="Hora" />
             <asp:BoundField DataField="col7" HeaderText="Servicio" />
             <asp:BoundField DataField="col8" HeaderText="Precio" /> 
             <asp:BoundField DataField="col9" HeaderText="Estado" /> 
        </Columns>
        <EmptyDataTemplate>
                        <table style="width:100%">
                            <tr>
                                <td>No data Found</td>
                            </tr>
                        </table>
                       </EmptyDataTemplate>  
    </asp:GridView>

</asp:Content>