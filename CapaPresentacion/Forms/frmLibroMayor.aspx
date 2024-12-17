<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmLibroMayor.aspx.cs" Inherits="CapaPresentacion.Forms.frmLibroMayor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
 <%--Jquery necesario para NESTED Gridview--%>
 <script type="text/javascript" src="../Scripts/jquery.1.8.3.jquery.min.js"></script>
<script type="text/javascript">
    $(function () {
        $("[src*=minus]").each(function () {
            $(this).closest("tr").after("<tr><td></td><td colspan = '999'>" + $(this).next().html() + "</td></tr>");
            $(this).next().remove()
        });
    });
 
</script>
<%-- fin Jquery--%>


     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>  
    <fieldset class="fieldset">
        <legend class="legend">Libro Mayor</legend>
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
                  <asp:Button ID="btnMayorizar" runat="server" Text=" " CssClass="btnOpenPopup" OnClick="Mayorizar" ToolTip="Listar Asientos" />
              </td>
          </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnCerrarMayorizacion" runat="server" Text="Cerrar" CssClass="button" OnClick="CerrarMayorizacion" /></td>
            </tr>
      </table>
        <asp:GridView ID="grdLibroMayorCabecera" runat="server" AutoGenerateColumns="false" CssClass="gridView" >
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="imgPlus" runat="server" ImageUrl="~/Images/plus.png" />
                        <asp:Panel ID="pnlDetails" runat="server" Visible="false" Style="position: relative">
                            <asp:GridView ID="grdLibroMayorDetalle" runat="server" AutoGenerateColumns="false" CssClass="gridViewCita" ShowFooter="true" >
                            <Columns>
                                <asp:BoundField DataField="fecha" HeaderText="fecha" HeaderStyle-Width="100px"  />
                                <asp:BoundField DataField="cuenta_contable" HeaderText="Cuenta" HeaderStyle-Width="50px" />
                                <asp:BoundField DataField="descripcion_cuenta" HeaderText="Descripcion" FooterText="Total" FooterStyle-Font-Bold="true" FooterStyle-HorizontalAlign="Right" HeaderStyle-Width="500px" />                             
                                <asp:BoundField DataField="debe" HeaderText="Debe" HeaderStyle-Width="50px"  />
                                <asp:BoundField DataField="haber" HeaderText="Haber" HeaderStyle-Width="50px"  />
                            </Columns>
                            <EmptyDataTemplate>
                                <table style="width:100%">
                                    <tr>
                                        <td>No data details found</td>
                                    </tr>
                                </table>
                            </EmptyDataTemplate> 
                        </asp:GridView>
                        </asp:Panel>                                   
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="cuenta_contable" HeaderText="Cuenta" ItemStyle-Font-Bold="true" />                
                <asp:BoundField DataField="descripcion_cuenta" HeaderText="Descripcion" ItemStyle-Font-Bold="true" />
            </Columns>
            <EmptyDataTemplate>
                <table style="width:100%">
                    <tr>
                        <td>No data found</td>
                    </tr>
                </table>
          </EmptyDataTemplate> 
        </asp:GridView>
    </fieldset>
</asp:Content>
 