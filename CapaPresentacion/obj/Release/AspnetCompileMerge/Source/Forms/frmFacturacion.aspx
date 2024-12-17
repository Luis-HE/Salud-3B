<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmFacturacion.aspx.cs" Inherits="CapaPresentacion.Forms.frmFacturacion" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" >

        <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanel1" ID="TabPanel1">
            <HeaderTemplate ><asp:Label ID="lblpage1" runat="server" Text="Facturación" Width="150px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
            <ContentTemplate>
                <fieldset class="fieldset">
                 <legend class="legend">Factura</legend>                
                 <table>
                      <tr>
                        <td style="text-align:right">Fec. Emision:</td>
                        <td><asp:TextBox ID="txtfecha" runat="server" Width="100px" CssClass="textbox"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfecha" CssClass="calendar" Format="dd/MM/yyyy" />
                            Fec. Cobranza:
                            <asp:TextBox ID="txtfechaCobranza" runat="server" Width="100px" CssClass="textbox"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtfechaCobranza" CssClass="calendar" Format="dd/MM/yyyy" />
                        </td>
                    </tr>       
                 </table>
                </fieldset>
                
            </ContentTemplate>
        </ajaxToolkit:TabPanel>

        <ajaxToolkit:TabPanel ID="TabPanel2" runat="server" HeaderText="TabPanel2">
            <HeaderTemplate><asp:Label ID="lblpage2" runat="server" Text="Tramas TEDEF" Width="150px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
            <ContentTemplate>
                <fieldset class="fieldset">
                    <legend class="legend">Tramas</legend>

                    <table style="margin:auto">
                        <tr>
                            <td style="text-align:right">Mes Facturado:</td>
                            <td><asp:DropDownList ID="drpMes" runat="server" CssClass="dropDownList" Width="200px">
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
                                 
                                </asp:DropDownList></td>
                            <td style="text-align:right">Tabla:</td>
                            <td>
                                <asp:DropDownList ID="drpTablas" runat="server" CssClass="dropDownList" Width="200px">
                                    <asp:ListItem Value="1">Tabla 1</asp:ListItem>
                                    <asp:ListItem Value="2">Tabla 2</asp:ListItem>
                                    <asp:ListItem Value="3">Tabla 3</asp:ListItem>
                                    <asp:ListItem Value="4">Tabla 4</asp:ListItem>
                                    <asp:ListItem Value="5">Tabla 5</asp:ListItem>
                                    <asp:ListItem Value="6">Tabla 6</asp:ListItem>
                                    <asp:ListItem Value="7">Tabla 7</asp:ListItem>
                                     
                                </asp:DropDownList></td>
                            <td>
                                <asp:Button ID="btnBuscarTrama" runat="server" Text="Listar Datos" CssClass="button" OnClick="ListarTablas" />
                                <asp:Button ID="btnGenerar" runat="server" Text="Generar Trama" CssClass="button" OnClick="GenerarTramas" />
                                <asp:Button ID="btnCerrarTrama" runat="server" Text="Cerrar" CssClass="button" OnClick="CerrarTrama" />
                            </td>
                        </tr>
                    </table>
                    <asp:GridView ID="grdTramas" runat="server" AutoGenerateColumns="false" CssClass="gridView">
                        <Columns>
                            <asp:BoundField DataField="colUno" HeaderText="Columna1" />
                            <asp:BoundField DataField="colDos" HeaderText="Columna2" />
                            <asp:BoundField DataField="colTres" HeaderText="Columna3" />
                            <asp:BoundField DataField="colCuatro" HeaderText="Columna4" />
                            <asp:BoundField DataField="colCinco" HeaderText="Columna5" />
                            <asp:BoundField DataField="colSeis" HeaderText="Columna6" />
                            <asp:BoundField DataField="colSiete" HeaderText="Columna7" />
                            <asp:BoundField DataField="colOcho" HeaderText="Columna8" />
                            <asp:BoundField DataField="colNueve" HeaderText="Columna9" />
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
 
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
        <ajaxToolkit:TabPanel ID="TabPanel3" runat="server" HeaderText="TabPanel3">
            <HeaderTemplate><asp:Label ID="lablpage3" runat="server" Text="Devoluciones" Width="150px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
            <ContentTemplate>
                <fieldset class="fieldset">
                    <legend class="legend">Devoluciones</legend>
                    
                </fieldset>
 
            </ContentTemplate>
        </ajaxToolkit:TabPanel>
 
    </ajaxToolkit:TabContainer>
        
</asp:Content>
