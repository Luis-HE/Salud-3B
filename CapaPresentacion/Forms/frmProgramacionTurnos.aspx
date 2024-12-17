<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmProgramacionTurnos.aspx.cs" Inherits="CapaPresentacion.Forms.frmProgramacionTurnos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="MainContent">
<link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
    
    <script src="../Scripts/JQuery-1.4.2.min.js"></script>
    <script type="text/javascript" src="../Scripts/FilterGridview.js"></script>
 
   <script type="text/javascript" src="../Scripts/jquery.min.js"> </script>
  <script type="text/javascript" src="../Scripts/TexboxEnterNextControl.js"></script>
    <script type="text/javascript">
   $(document).ready(function() {
       //$('input[type="text"]').attr("disabled", "disabled");// to disable all textbox, color gray by defaul. But makes it empty to value of control
       $("#txtDni_empleado").attr("readonly", true);
       $("#txtNombre_empleado").attr("readonly", true);
 
       return false; //to prevent from postback
    });
</script> 
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
                   <td style="text-align:right">Especialidad:</td>
                    <td><asp:DropDownList ID="drpEspecialidad" runat="server" CssClass="dropDownList" Width="210px">
                        </asp:DropDownList>                        
                    </td>
               </tr>
              <tr>
                    <td style="text-align:right">Fecha:</td>
                    <td><asp:TextBox ID="txtfechabusqueda" runat="server" Width="200px" CssClass="textbox" MaxLength="10"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfechabusqueda" Format="dd/MM/yyyy" CssClass="calendar" />
                    </td>
                </tr>
              <tr>
                     <td style="text-align:right">Médico del Turno:</td>
                 <td><asp:TextBox ID="txtDni_empleado" runat="server" Width="100px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                    <asp:Button ID="btnBuscarMedico" runat="server" Text=" " CssClass="btnOpenPopup" OnClientClick="OpenListEmpleados()" ToolTip="Buscar Médicos"/>
                    <asp:TextBox ID="txtNombre_empleado" runat="server" Width="235px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                </td>
                 </tr>
    </table>
    <ajaxToolkit:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0">
  <ajaxToolkit:TabPanel runat="server" HeaderText="TabProgramaCitas" ID="tabProgramaCitas">
      <HeaderTemplate><asp:Label ID="Label1" runat="server" Text="Programacion Masiva" Width="200px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
      <ContentTemplate>
             <table style="margin:auto">
                 <tr>
                     <td></td>
                     <td><asp:Button ID="btnistarTurnos" runat="server" CssClass="button" Text="Preparar Turnos" OnClick="ListarTurnosProgramar" CausesValidation="false" /></td>
                 </tr>
             </table>
             <asp:GridView ID="grdListaTurnosProgramar" runat="server" AutoGenerateColumns="false" CssClass="gridViewCita" ShowFooter="true">
                 <Columns>
                     <asp:TemplateField >
                         <HeaderTemplate>
                             <asp:CheckBox ID="chkHeader" runat="server" AutoPostBack="true" OnCheckedChanged="SelectAll" Checked="true" />
                         </HeaderTemplate>
                         <ItemTemplate>
                             <asp:CheckBox ID="chkIncluir" runat="server" Checked="true" />
                         </ItemTemplate>
                     </asp:TemplateField>
                      <asp:BoundField DataField="hora" HeaderText="Hora" />
                      <asp:BoundField DataField="id_turno" HeaderText="Id" />
                      <asp:BoundField DataField="dni_empleado" HeaderText="Médico" />
                     <asp:BoundField DataField="cod_persona" HeaderText="Cod." />
                     <asp:BoundField DataField="dni_paciente" HeaderText="Turno" />
                     <asp:BoundField DataField="id_item" HeaderText="Servicio" />
                     <asp:BoundField DataField="cod_especialidad" HeaderText="Especialidad" /> 
                     <asp:BoundField DataField="estado" HeaderText="Estado" />                                 
                      <asp:TemplateField HeaderText="Fecha">
                          <ItemTemplate>
                              <asp:TextBox ID="txtFecha" runat="server" Width="100px" Text='<%# Eval("fecha")%>' ></asp:TextBox>
                          </ItemTemplate>
                          <FooterTemplate>
                              <asp:Button ID="btnProgramarTurnos" runat="server" Text="Programar" CssClass="button" OnClick="ProgramarTurnos" CausesValidation="false" />                              
                          </FooterTemplate>
                      </asp:TemplateField>
                 </Columns>
                 <EmptyDataTemplate>
                        <table style="width:100%">
                            <tr>
                                <td>No data Found</td>
                            </tr>
                        </table>
                       </EmptyDataTemplate> 
             </asp:GridView>
         </ContentTemplate>

  </ajaxToolkit:TabPanel>
  <ajaxToolkit:TabPanel runat="server" HeaderText="TabAdminTurnos" ID="tbAdminTurnos">
         <HeaderTemplate><asp:Label ID="Label3" runat="server" Text="Programacion por Hora" Width="200px" ForeColor="#1F497D"></asp:Label></HeaderTemplate>
        <ContentTemplate>
            <table style="margin:auto">
                <tr>
                    <td>Hora:</td>
                    <td> <asp:TextBox ID="txtHora" runat="server" Text="00:00" CssClass="textbox" Width="50px"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="btnInsertarHora" runat="server" Text="Insertar Hora" CssClass="button" OnClick="InsertarHora" />
                        <asp:Label ID="lblMsj" runat="server" Text="" ForeColor="Green" Font-Bold="true"></asp:Label>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
     </ajaxToolkit:TabPanel>
  
    </ajaxToolkit:TabContainer>

</asp:Content>
