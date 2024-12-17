<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmReporteProduccionMedicos.aspx.cs" Inherits="CapaPresentacion.Forms.frmReporteProduccionMedicos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
    <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
   <script type="text/javascript" src="../Scripts/jquery.min.js"> </script>
   <script type="text/javascript" src="../Scripts/SoloNumeros.js"></script>
  <script type="text/javascript" src="../Scripts/TexboxEnterNextControl.js"></script>
  
   <script type="text/javascript"> 
    function OpenListEmpleados()
    {
        window.open("../Forms/frmListar_Medicos.aspx", 'Lista Medicos', 'height=550,width=600,left=265,top=165,resizable=No,toolbar=No')
    }
   
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
            <td style="text-align:right">Unidad de Negocio:</td>
            <td><asp:DropDownList ID="drpUnidadNegocio" runat="server" CssClass="dropDownList" Width="200px" ClientIDMode="Static"></asp:DropDownList></td>
        </tr>
        <tr>
                <td style="text-align:right">Médico:</td>
                <td><asp:TextBox ID="txtDni_empleado" runat="server"  Width="100px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                    <asp:Button ID="btnBuscarMedico" runat="server" Text=" " CssClass="btnOpenPopup" OnClientClick="OpenListEmpleados()" />
                    <asp:TextBox ID="txtNombre_empleado" runat="server" Width="235px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td></td>
            <td> <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="button" OnClick="ListarReporte" /> </td>
        </tr>
    </table>
    <asp:GridView ID="grdReporteMedicos" runat="server" AutoGenerateColumns="false" CssClass="gridViewCita">
      <Columns>
          <asp:BoundField DataField="num_doc_cliente" HeaderText="N° DNI" />
          <asp:BoundField DataField="apellido_paterno" HeaderText="Apellido Paterno" />
          <asp:BoundField DataField="apellido_materno" HeaderText="Apellido Materno" />
          <asp:BoundField DataField="nombres" HeaderText="Nombres" />
          <asp:BoundField DataField="fecha_atencion" HeaderText="Fecha de Atención" />
          <asp:BoundField DataField="hora_atencion" HeaderText="Hora de Atención" />
          <asp:BoundField DataField="descripcion_servicio" HeaderText="Servicio" />
          <asp:BoundField DataField="monto_pagar" HeaderText="Pago (S/.)" />
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

 