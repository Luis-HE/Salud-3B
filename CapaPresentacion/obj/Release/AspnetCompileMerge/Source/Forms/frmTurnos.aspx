<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmTurnos.aspx.cs" Inherits="CapaPresentacion.Forms.frmTurnos" %>

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

 <table style="margin:auto">
                  <tr>
                      <td style="text-align:right">Especialidad:</td>
                      <td><asp:DropDownList ID="drpEspecialidad" runat="server" Width="200px" CssClass="dropDownList"></asp:DropDownList>
                          
                      </td>
                  </tr> 
                  <tr>
                    <td style="text-align:right">Fecha:</td>
                    <td><asp:TextBox ID="txtfechabusqueda" runat="server" Width="200px" CssClass="textbox" MaxLength="10"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfechabusqueda" Format="dd/MM/yyyy" CssClass="calendar" />
                    </td>
                </tr>
                <tr>
                <td style="text-align:right">Médico:</td>
                <td><asp:TextBox ID="txtDni_empleado" runat="server"  Width="100px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDni_empleado" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ErrorMessage="completar..."></asp:RequiredFieldValidator>
                    <asp:Button ID="btnBuscarMedico" runat="server" Text=" " CssClass="btnOpenPopup" OnClientClick="OpenListEmpleados()" CausesValidation="false"/>
                    <asp:TextBox ID="txtNombre_empleado" runat="server" Width="235px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                </td>
            </tr>
                 <tr>
                     <td></td>
                     <td>
                         <asp:Button ID="btnCrear" runat="server" Text="Crear" CssClass="button"/></td>
                 </tr>
              </table>

 </asp:Content>