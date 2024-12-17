<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmLibroEmergencias.aspx.cs" Inherits="CapaPresentacion.Forms.frmLibroEmergencias" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

 <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
   <script type="text/javascript" src="../Scripts/jquery.min.js"> </script>
   <script type="text/javascript" src="../Scripts/SoloNumeros.js"></script>
  <script type="text/javascript" src="../Scripts/TexboxEnterNextControl.js"></script>

  <script type="text/javascript"> 
    function OpenListEmpleados()
    {
        window.open("../Forms/frmListar_Medicos.aspx", 'Lista Empresas', 'height=550,width=600,left=265,top=165,resizable=No,toolbar=No')
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
                <td style="text-align:right">Médico:</td>
                <td><asp:TextBox ID="txtDni_empleado" runat="server" Width="100px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtDni_empleado" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ErrorMessage="completar..."></asp:RequiredFieldValidator>
                    <asp:Button ID="btnBuscarMedico" runat="server" Text=" " CssClass="btnOpenPopup" OnClientClick="OpenListEmpleados()" CausesValidation="false"/>
                    <asp:TextBox ID="txtNombre_empleado" runat="server" Width="235px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                </td>
            </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btnRefrescar" runat="server" Text="Actualizar" CssClass="button" OnClick="RefrescarGridview" CausesValidation="false"/></td>
        </tr>
    </table>
    <asp:GridView ID="grdAdmitidosXEmergencia" runat="server" CssClass="gridViewCita" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="SelecionarRegistro" CausesValidation="false">Select</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            <asp:BoundField DataField="numero_admision" HeaderText="N° de Cuenta" />
            <asp:BoundField DataField="tipo_admision" HeaderText="Tipo admisión" />
            <asp:BoundField DataField="num_doc_cliente" HeaderText="DNI/CE" />
            <asp:BoundField DataField="paciente" HeaderText="Paciente" />
            <asp:BoundField DataField="fecha_nace" HeaderText="Fecha Nace" />
            <asp:BoundField DataField="genero" HeaderText="Género" />
             <asp:BoundField DataField="direccion" HeaderText="Dirección" />
           
        </Columns>
        <EmptyDataTemplate>
                        <table style="width:100%">
                            <tr>
                                <td>No data Found</td>
                            </tr>
                        </table>
        </EmptyDataTemplate> 
    </asp:GridView>
<table>
    <tr>
             <td style="text-align:right">N° Historia Clinica:</td>
                <td><asp:Label ID="lblNumHistoria" runat="server" Text="" CssClass="label" Width="100px"></asp:Label></td>
           </tr>
    <tr>
        <td style="text-align:right">Edad:</td>
        <td><asp:TextBox ID="txtEdad" runat="server" Width="100px"  CssClass="textbox"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="text-align:right">Género:</td>
        <td><asp:TextBox ID="txtGenero" runat="server" Width="100px"  CssClass="textbox"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="text-align:right">Dirección domiciliaria:</td>
        <td><asp:TextBox ID="txtDireccionDomilicio" runat="server" Width="400px"  CssClass="textbox"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="text-align:right">Diagnóstico de ingreso:</td>
        <td><asp:TextBox ID="txtDiagnosticoIngreso" runat="server" Width="400px"  Height="50px" CssClass="textbox" TextMode="MultiLine"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="text-align:right">Diagnóstico final:</td>
        <td><asp:TextBox ID="txtDiagnosticoFinal" runat="server" Width="400px"  Height="50px" CssClass="textbox" TextMode="MultiLine"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="text-align:right">Destino final:</td>
        <td><asp:TextBox ID="txtDestinoFinal" runat="server" Width="400px" CssClass="textbox"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="text-align:right">Hora que termina la atención:</td>
        <td><asp:TextBox ID="txtHoraTerminaAtencion" runat="server" Width="100px" CssClass="textbox"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="text-align:right">Observaciones:</td>
        <td><asp:TextBox ID="txtObservaciones" runat="server" Width="400px"  Height="50px" CssClass="textbox" TextMode="MultiLine"></asp:TextBox></td>
    </tr>
    <tr>
        <td style="text-align:right">Acompañante:</td>
        <td><%--<asp:TextBox ID="txtIdAcompanante" runat="server" Width="50px"  CssClass="textBoxDisabled"></asp:TextBox>--%>
            <asp:TextBox ID="txtNombreAcompanante" runat="server" Width="340px"  CssClass="textbox"></asp:TextBox></td>
    </tr>
    <tr>
        <td></td>
        <td><asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="button" OnClick="GuardarLibroEmergencia" />
            <asp:Label ID="lblMsj" runat="server" Text="" ForeColor="Green" Font-Bold="true"></asp:Label>
            
        </td>
       </tr>
</table>
 
 </asp:Content>
