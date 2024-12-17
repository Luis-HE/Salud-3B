<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmHojaRiesgoQuirurgico.aspx.cs" Inherits="CapaPresentacion.Forms.frmHojaRiesgoQuirurgico" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
   <script type="text/javascript" src="../Scripts/jquery.min.js"> </script>
   <script type="text/javascript" src="../Scripts/SoloNumeros.js"></script>
  <script type="text/javascript" src="../Scripts/TexboxEnterNextControl.js"></script>
<fieldset class="fieldset">
    <legend class="legend">Hoja de Riesgo Quirurgico</legend>
    <table>
        <tr>
            <td>
                <fieldset>
                    <legend>ANTES DE INDUCCION DE ANESTESIA</legend>
                    <table>
                        <tr>
                            <td>Confirme que el paciente ha sido:
                                <br />
                                <asp:ListBox ID="ListBox1" runat="server" CssClass="listBox" SelectionMode="Multiple" >
                                    <asp:ListItem Value="1">Identificado</asp:ListItem>
                                    <asp:ListItem Value="2">Lugar / sitio del procedimiento</asp:ListItem>
                                    <asp:ListItem Value="3">Procedimiento</asp:ListItem>
                                    <asp:ListItem Value="4">Consentimiento</asp:ListItem>
                                </asp:ListBox>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox" Width="150px" Height="50px" TextMode="MultiLine" ></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td>Lugar / Sitio marcado / No aplicable</td>
                            <td>
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <td>Chequeo completo de la seguridad de anestesia</td>
                            <td>
                                <asp:DropDownList ID="DropDownList2" runat="server">
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <td>Oximetro de pulso funcionando</td>
                            <td>
                                <asp:DropDownList ID="DropDownList3" runat="server">
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <td>El paciente tiene una:</td>
                            <td>¿Alergia conocida?
                                <asp:DropDownList ID="DropDownList4" runat="server">
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>¿Dificultad en la vía respiratoria / riesgo de aspiración?
                                <asp:DropDownList ID="DropDownList5" runat="server">
                                    <asp:ListItem>Si, y equipamiento / asistencia disponible</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>¿Riesgo de perdida de > 500ml de sangre (7ml/kg en niños)?
                                <asp:DropDownList ID="DropDownList6" runat="server">
                                    <asp:ListItem>Si y adecuado acceso intravenoso y planeado fluido</asp:ListItem>
                                    <asp:ListItem>No</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </td>
            <td>
              <fieldset>
                    <legend>ANTES DE LA INCISIÓN</legend>
                </fieldset>
            </td>
            <td>
                <fieldset>
                    <legend>ANTES DE SALIDA DE SALA DE OPERACIONES</legend>
                </fieldset>
            </td>
        </tr>
    </table>



</fieldset>

</asp:Content>
 