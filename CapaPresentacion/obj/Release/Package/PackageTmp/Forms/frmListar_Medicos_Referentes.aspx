<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmListar_Medicos_Referentes.aspx.cs" Inherits="CapaPresentacion.Forms.frmListar_Medicos_Referentes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
   <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
 
</head>
<body>
    <form id="form1" runat="server">
      <table style="margin:auto">
          <tr>
              <td style="text-align:right">Apellido Paterno:</td>
              <td><asp:TextBox ID="txtBuscaApelPaterno" runat="server" CssClass="textbox" Width="200px"></asp:TextBox>
                  <asp:Button ID="btnBuscarMedico" runat="server" Text=" " CssClass="btnOpenPopup" ToolTip="Buscar" OnClick="BuscarMedico" />
              </td>
          </tr>
      </table>
        <asp:GridView ID="grdMedicosReferentes" runat="server">
            <Columns>

            </Columns>
            <EmptyDataTemplate>
                        <table style="width:100%">
                            <tr>
                                <td>No data Found</td>
                            </tr>
                        </table>
            </EmptyDataTemplate> 
        </asp:GridView>
    </form>
</body>
</html>
