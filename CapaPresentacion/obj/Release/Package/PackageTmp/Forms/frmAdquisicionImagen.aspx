<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmAdquisicionImagen.aspx.cs" Inherits="CapaPresentacion.Forms.frmAdquisicionImagen" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
 <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
 <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
         <ajaxToolkit:TabPanel runat="server" HeaderText="TabPanelRealizaEstudio" ID="tbPanelrealizaEstudio">
         <HeaderTemplate><asp:Label ID="Label1" runat="server" Text="Realización de Estudios" Width="150px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
        <ContentTemplate>

        </ContentTemplate>
     </ajaxToolkit:TabPanel>
     <ajaxToolkit:TabPanel runat="server" HeaderText="TabReconstruccion" ID="tbPanelReconstruccion">
         <HeaderTemplate><asp:Label ID="Label2" runat="server" Text="Reconstrucciones" Width="150px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
         <ContentTemplate>

         </ContentTemplate>
     </ajaxToolkit:TabPanel>

    </ajaxToolkit:TabContainer>
</asp:Content>
 
