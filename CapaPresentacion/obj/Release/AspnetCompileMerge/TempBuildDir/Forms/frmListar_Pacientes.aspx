<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmListar_Pacientes.aspx.cs" Inherits="CapaPresentacion.Forms.frmListar_Pacientes" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Scripts/SoloNumeros.js"></script>
   <script type="text/javascript" src="../Scripts/jquery.min.js"> </script>
  <script type="text/javascript" src="../Scripts/TexboxEnterNextControl.js"></script>
 
    
</head>
<body>
    <%--coloco este bloque script AQUI por que sale error si lo coloco en el HEAD, cuando coloco MASK a la fecha nacimiento--%>
    <script type="text/javascript">
     function GetSelectedValue(dni,apaterno, amaterno,nombre)
        {
            var vardni = document.getElementById("<%= hd_dni.ClientID %>");
            vardni.value = dni;
            var varapaterno = document.getElementById("<%=hd_apaterno.ClientID%>");
            varapaterno.value = apaterno;
            var varamaterno = document.getElementById("<%=hd_amaterno.ClientID%>");
            varamaterno.value = amaterno;
             var varnombre = document.getElementById("<%=hd_nombre.ClientID%>");
            varnombre.value = nombre;

            window.opener.document.getElementById("txtDni_cliente").value = vardni.value;
            window.opener.document.getElementById("txtNombre_cliente").value = varapaterno.value +' '+ varamaterno.value +' '+ varnombre.value;
 
            self.close();
        } 
        
    </script> 
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table style="margin:auto">
        <tr>
            <td style="text-align:right">N° de DNI/CE:</td>
            <td><asp:TextBox ID="txtDni_cliente" runat="server" onkeyPress="return soloNumeros(event)" MaxLength="15" CssClass="textbox" Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDni_cliente" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ErrorMessage="completar..."></asp:RequiredFieldValidator>
                <asp:Button ID="btnBuscarClientePersona" runat="server" Text=" " CssClass="btnOpenPopup" OnClick="btnBuscarClientePersona_Click" CausesValidation="false" />
            </td>
        </tr>
        <tr>
            <td style="text-align:right">Apellido Paterno:</td>
            <td><asp:TextBox ID="txtApel_paterno" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtApel_paterno" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ErrorMessage="completar..."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align:right">Apellido Materno:</td>
            <td><asp:TextBox ID="txtapel_materno" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtapel_materno" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ErrorMessage="completar..."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align:right">Nombres:</td>
            <td><asp:TextBox ID="txtNombre_cliente" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNombre_cliente" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ErrorMessage="completar..."></asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td style="text-align:right">Telefono fijo:</td>
            <td><asp:TextBox ID="txttelef_fijo" runat="server" CssClass="textbox" Width="100px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align:right">Telefono Movil:</td>
            <td><asp:TextBox ID="txtTelef_movil" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtTelef_movil" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ErrorMessage="completar..."></asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td style="text-align:right">E-mail:</td>
            <td><asp:TextBox ID="txtEmail" runat="server" CssClass="textbox" Width="300px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align:right">Género:</td>
            <td><asp:DropDownList ID="drpGenero" runat="server" CssClass="dropDownList" Width="110px">
                <asp:ListItem Value="1">Masculino</asp:ListItem>
                <asp:ListItem Value="2">Femenino</asp:ListItem>
                </asp:DropDownList> </td>
        </tr>     
         <tr>
            <td style="text-align:right">Dirección:</td>
            <td><asp:TextBox ID="txtDireccion" runat="server" CssClass="textbox" Width="300px"></asp:TextBox></td>
        </tr>
        <tr>
            <td style="text-align:right">Grupo Sanguineo:</td>
            <td><asp:DropDownList ID="drpGrupoSanguineo" runat="server" CssClass="dropDownList" Width="110px">
                <asp:ListItem Value="1">O+</asp:ListItem>
                <asp:ListItem Value="2">O-</asp:ListItem>
                <asp:ListItem Value="3">A+</asp:ListItem>
                <asp:ListItem Value="4">A-</asp:ListItem>
                <asp:ListItem Value="5">B+</asp:ListItem>
                <asp:ListItem Value="6">B-</asp:ListItem>
                <asp:ListItem Value="7">AB+</asp:ListItem>
                <asp:ListItem Value="8">AB-</asp:ListItem>
                </asp:DropDownList> </td>
        </tr>
         <tr>
            <td style="text-align:right">Fecha Nacimiento:</td>
            <td><asp:TextBox ID="txtFecha_nace" runat="server" CssClass="textbox" Width="100px" Text="00/00/0000"  ></asp:TextBox>
                <ajaxToolkit:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="txtFecha_nace" Mask="99/99/9999" MaskType="Date" MessageValidatorTip="true" />
                <ajaxToolkit:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlToValidate="txtFecha_nace" ControlExtender="MaskedEditExtender1" IsValidEmpty="false" EmptyValueMessage="Ingrese fecha" InvalidValueMessage="Error fecha" ForeColor="Red"></ajaxToolkit:MaskedEditValidator>
            </td>
        </tr> 
         <tr>
            <td style="text-align:right">Nacionalidad:</td>
            <td> <asp:DropDownList ID="drpNacionalidad" runat="server" CssClass="dropDownList" Width="110px"></asp:DropDownList> </td>
        </tr>   
        <tr>
            <td style="text-align:right">Ubigeo:</td>
            <td> <asp:DropDownList ID="drpUbigeo" runat="server" CssClass="dropDownList" Width="310px"></asp:DropDownList> </td>
        </tr>
       <tr>
            <td style="text-align:right">Estado Civil:</td>
            <td><asp:DropDownList ID="drpEstadoCivil" runat="server"  CssClass="dropDownList" Width="110px">
                <asp:ListItem Value="1">Soltero(a)</asp:ListItem>
                  <asp:ListItem Value="2">Conviviente</asp:ListItem>
                  <asp:ListItem Value="3">Casado(a)</asp:ListItem>
                  <asp:ListItem Value="4">Separado(a)</asp:ListItem>  
                   <asp:ListItem Value="5">Divorciado(a)</asp:ListItem>     
                   <asp:ListItem Value="6">Viudo(a)</asp:ListItem>     
                   <asp:ListItem Value="7">Otros</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
         <tr>
          <td style="text-align:right">Nombre del Padre:</td>
           <td><asp:TextBox ID="txtnombrePadre" runat="server" CssClass="textbox" Width="300px"></asp:TextBox></td>
       </tr>
        <tr>
          <td style="text-align:right">Nombre de la Madre:</td>
           <td><asp:TextBox ID="txtnombreMadre" runat="server" CssClass="textbox" Width="300px"></asp:TextBox></td>
       </tr>
        <tr>
            <td style="text-align:right">Religion:</td>
            <td>
                <asp:DropDownList ID="drpReligion" runat="server"  CssClass="dropDownList" Width="110px">
                   <asp:ListItem Value="1">Católica</asp:ListItem>
                  <asp:ListItem Value="2">Evangelica</asp:ListItem>
                  <asp:ListItem Value="3">Testigo de Jehova</asp:ListItem>
                  <asp:ListItem Value="4">Ateo</asp:ListItem>    
                </asp:DropDownList></td>
        </tr>
          <tr>
            <td style="text-align:right">Ocupacion</td>
            <td>
                <asp:DropDownList ID="drpOcupacion" runat="server"  CssClass="dropDownList" Width="110px">
                   <asp:ListItem Value="1">Trabajador Estable</asp:ListItem>
                  <asp:ListItem Value="2">Eventual</asp:ListItem>
                  <asp:ListItem Value="3">Sin Ocupación</asp:ListItem>
                  <asp:ListItem Value="4">Jubilado</asp:ListItem> 
                   <asp:ListItem Value="5">Estudiante</asp:ListItem>     
                </asp:DropDownList></td>
        </tr>
           <tr>
              <td style="text-align:right">Grupo étnico:</td>
              <td><asp:DropDownList ID="drpGrupoEtnico" runat="server" CssClass="dropDownList" Width="110px">
                  <asp:ListItem Value="1">Mestizo</asp:ListItem>
                  <asp:ListItem Value="2">Quechua</asp:ListItem>
                  <asp:ListItem Value="3">Blanco</asp:ListItem>
                  <asp:ListItem Value="4">Afrodescendiente</asp:ListItem>
                  <asp:ListItem Value="5">Aimara</asp:ListItem>
                  <asp:ListItem Value="6">Nativo o Indigena de la Amazonia</asp:ListItem>
                  <asp:ListItem Value="7">Asháninca</asp:ListItem>
                  <asp:ListItem Value="8">Aimara</asp:ListItem>
                  <asp:ListItem Value="9">Parte de otro pueblo indígena u originario</asp:ListItem>
                  <asp:ListItem Value="10">Awajún</asp:ListItem>
                  <asp:ListItem Value="11">Shipibo Konibo</asp:ListItem>
                  <asp:ListItem Value="12">Nikkei</asp:ListItem>
                  <asp:ListItem Value="13">Tusan</asp:ListItem>
                  <asp:ListItem Value="14">Otro</asp:ListItem>
                  <asp:ListItem Value="15">No sabe/No responde</asp:ListItem>
                  </asp:DropDownList></td>
          </tr>      
        
        <tr>
            <td></td>
            <td><asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" CssClass="button" /></td>
        </tr>
         
    </table>
        <asp:GridView ID="grdClientePersonas" runat="server" AutoGenerateColumns="false" CssClass="gridViewCita">
           <Columns>
               <asp:TemplateField>
                    <ItemTemplate>
                         <a href="#" onclick="javascript:GetSelectedValue('<%# Eval("num_doc_cliente") %>','<%# Eval("apellido_paterno") %>','<%# Eval("apellido_materno") %>','<%# Eval("nombres") %>');">Select</a>
                    </ItemTemplate>
                </asp:TemplateField>
               <asp:BoundField DataField="num_doc_cliente" HeaderText="DNI/CE" />
               <asp:BoundField DataField="apellido_paterno" HeaderText="Apellido Paterno" />
               <asp:BoundField DataField="apellido_materno" HeaderText="Apellido Materno" />
               <asp:BoundField DataField="nombres" HeaderText="Nombres" />
           </Columns>
            <EmptyDataTemplate>
                        <table style="width:100%">
                            <tr>
                                <td>No data Found</td>
                            </tr>
                        </table>
                    </EmptyDataTemplate> 
        </asp:GridView>
        <asp:HiddenField ID="hd_dni" runat="server" />
        <asp:HiddenField ID="hd_apaterno" runat="server" />
        <asp:HiddenField ID="hd_amaterno" runat="server" />
        <asp:HiddenField ID="hd_nombre" runat="server" />

    </form>
</body>
</html>
