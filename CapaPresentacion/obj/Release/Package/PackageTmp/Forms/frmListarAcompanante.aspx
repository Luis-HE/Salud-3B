<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmListarAcompanante.aspx.cs" Inherits="CapaPresentacion.Forms.frmListarAcompanante" %>

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
     <script type="text/javascript">
     function GetSelectedValue(id,nombres)
        {
           var varid = document.getElementById("<%= hdId.ClientID %>");
            varid.value = id;
            var varNombre = document.getElementById("<%=hdNombre.ClientID%>");
            varNombre.value = nombres;
 
         window.opener.document.getElementById("txtIdAcompanante").value = varid.value;
         window.opener.document.getElementById("txtNombreAcompanante").value = varNombre.value ;
 
            self.close(); 
        } 
        
    </script> 
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
      <table>
          <tr>
              <td style="text-align:right">DNI/RUC:</td>
              <td><asp:TextBox ID="txtDniRuc" runat="server" onkeyPress="return soloNumeros(event)" MaxLength="15" CssClass="textbox" Width="100px"></asp:TextBox>
                  <asp:Button ID="btnBuscarAcompanante" runat="server" Text=" " CssClass="btnOpenPopup" OnClick="BuscarAcompanante"    />
              </td>
          </tr>
           <tr>
              <td style="text-align:right">Tipo Persona:</td>
              <td><asp:DropDownList ID="drpTipoPersona" runat="server" CssClass="dropDownList" Width="110px">
                  <asp:ListItem Value="1">Natural</asp:ListItem>
                  <asp:ListItem Value="2">Juridica</asp:ListItem>
                  </asp:DropDownList></td>
          </tr>
          <tr>
              <td style="text-align:right">Nombres:</td>
              <td><asp:TextBox ID="txtNombre" runat="server" CssClass="textbox" Width="300px"></asp:TextBox></td>
          </tr>
          <tr>
              <td style="text-align:right">Apellidos:</td>
              <td><asp:TextBox ID="txtApellidos" runat="server" CssClass="textbox" Width="300px"></asp:TextBox></td>
          </tr>
         
           <tr>
              <td style="text-align:right">Parentesco:</td>
              <td><asp:DropDownList ID="drpParentesco" runat="server" CssClass="dropDownList" Width="110px">
                  <asp:ListItem Value="1">Padre</asp:ListItem>
                  <asp:ListItem Value="2">Madre</asp:ListItem>
                  <asp:ListItem Value="3">Hijo(a)</asp:ListItem>
                  <asp:ListItem Value="4">Hijo(a) Adoptivo(a)</asp:ListItem>
                  <asp:ListItem Value="5">Hermano(a)</asp:ListItem>
                  <asp:ListItem Value="6">Abuelo(a)</asp:ListItem>
                  <asp:ListItem Value="7">Tio(a)</asp:ListItem>
                  <asp:ListItem Value="8">Nieto(a)</asp:ListItem>
                  <asp:ListItem Value="9">Padrastro</asp:ListItem>
                  <asp:ListItem Value="10">Madrastra</asp:ListItem>
                  <asp:ListItem Value="11">Sobrino(a)</asp:ListItem>
                  <asp:ListItem Value="12">Primo(a)</asp:ListItem>
                  <asp:ListItem Value="13">Bis-abuelo(a)</asp:ListItem>
                  <asp:ListItem Value="14">Yerno</asp:ListItem>
                  <asp:ListItem Value="15">Nuera</asp:ListItem>
                  <asp:ListItem Value="16">Amigo(a)</asp:ListItem> 
                  <asp:ListItem Value="17">Esposo(a)</asp:ListItem>          
                  </asp:DropDownList></td>
          </tr>
          <tr>
              <td style="text-align:right">Nombre Contacto:</td>
              <td><asp:TextBox ID="txtNombreContacto" runat="server" CssClass="textbox" Width="300px"></asp:TextBox></td>
          </tr>
           
          <tr>
              <td style="text-align:right">Ocupacion:</td>
              <td><asp:TextBox ID="txtOcupacion" runat="server" CssClass="textbox" Width="300px"></asp:TextBox></td>
          </tr>
          <tr>
              <td style="text-align:right">Teléfono:</td>
              <td><asp:TextBox ID="txtTelefono" runat="server" CssClass="textbox" Width="100px"></asp:TextBox></td>
          </tr>
           <tr>
              <td style="text-align:right">Grupo étnico:</td>
              <td><asp:DropDownList ID="drpGrupoEtnico" runat="server" CssClass="dropDownList" Width="110px">
                  <asp:ListItem Value="1">Blanco</asp:ListItem>
                  <asp:ListItem Value="2">Caucasico</asp:ListItem>
                  <asp:ListItem Value="3">Mestizo</asp:ListItem>
                  <asp:ListItem Value="4">Negro</asp:ListItem>
                  <asp:ListItem Value="5">Otros</asp:ListItem>
                  </asp:DropDownList></td>
          </tr>
           <tr>
              <td style="text-align:right">Idioma:</td>
              <td><asp:DropDownList ID="drpIdioma" runat="server" CssClass="dropDownList" Width="110px">
                  <asp:ListItem Value="1">Castellano</asp:ListItem>
                  <asp:ListItem Value="2">Ingles</asp:ListItem>
                  <asp:ListItem Value="3">Frances</asp:ListItem>
                  <asp:ListItem Value="4">Aleman</asp:ListItem>
                   <asp:ListItem Value="5">Chino Mandarin</asp:ListItem>
                  </asp:DropDownList></td>
          </tr>
          <tr>
              <td style="text-align:right">Religión:</td>
              <td><asp:DropDownList ID="drpReligion" runat="server" CssClass="dropDownList" Width="110px">
                  <asp:ListItem Value="1">Católica</asp:ListItem>
                  <asp:ListItem Value="2">Evangelica</asp:ListItem>
                  <asp:ListItem Value="3">Testigo de Jehova</asp:ListItem>
                  <asp:ListItem Value="4">Ateo</asp:ListItem>                  
                  </asp:DropDownList></td>
          </tr>
          <tr>
              <td style="text-align:right">Estado Civil:</td>
              <td><asp:DropDownList ID="drpEstadoCivil" runat="server" CssClass="dropDownList" Width="110px">
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
            <td style="text-align:right">Género:</td>
            <td><asp:DropDownList ID="drpGenero" runat="server" CssClass="dropDownList" Width="110px">
                <asp:ListItem Value="1">Masculino</asp:ListItem>
                <asp:ListItem Value="2">Femenino</asp:ListItem>
                </asp:DropDownList> </td>
        </tr>
           <tr>
              <td style="text-align:right">Edad:</td>
              <td><asp:TextBox ID="txtEdad" runat="server" CssClass="textbox" Width="300px"></asp:TextBox></td>
          </tr> 
          <tr>
              <td style="text-align:right">Grado de Instrucción:</td>
              <td><asp:DropDownList ID="drpGradoInstruccion" runat="server" CssClass="dropDownList" Width="110px">
                  <asp:ListItem Value="1">Sin Instrucción</asp:ListItem>
                  <asp:ListItem Value="2">Inicial</asp:ListItem>
                  <asp:ListItem Value="3">Primaria Completa</asp:ListItem>
                  <asp:ListItem Value="4">Primaria Incompleta</asp:ListItem>  
                   <asp:ListItem Value="5">Secundaria Completa</asp:ListItem>     
                   <asp:ListItem Value="6">Secundaria Incompleta</asp:ListItem>     
                   <asp:ListItem Value="7">Superior Completo</asp:ListItem>   
                   <asp:ListItem Value="8">Superior Incompleto</asp:ListItem>                      
                  </asp:DropDownList></td>
          </tr> 
          <tr>
              <td style="text-align:right">Condición Ocupación:</td>
              <td><asp:DropDownList ID="drpCondicionOcupacion" runat="server" CssClass="dropDownList" Width="110px">
                  <asp:ListItem Value="1">Trabajador Estable</asp:ListItem>
                  <asp:ListItem Value="2">Eventual</asp:ListItem>
                  <asp:ListItem Value="3">Sin Ocupación</asp:ListItem>
                  <asp:ListItem Value="4">Jubilado</asp:ListItem> 
                   <asp:ListItem Value="5">Estudiante</asp:ListItem>                   
                  </asp:DropDownList></td>
          </tr>
          <tr>
              <td style="text-align:right">Seguro de Salud:</td>
              <td><asp:DropDownList ID="drpSeguroSalud" runat="server" CssClass="dropDownList" Width="110px">
                  <asp:ListItem Value="1">SIS</asp:ListItem>
                  <asp:ListItem Value="2">ESSALUD</asp:ListItem>
                  <asp:ListItem Value="3">FF.AA</asp:ListItem>
                  <asp:ListItem Value="4">PNP</asp:ListItem>   
                  <asp:ListItem Value="5">PRIVADO</asp:ListItem>   
                  <asp:ListItem Value="6">SIN SEGURO</asp:ListItem>                
                  </asp:DropDownList></td>
          </tr>    
          <tr>
              <td></td>
              <td><asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="button" OnClick="InsertarAcompanante" /></td>
          </tr>
      </table>
        <asp:GridView ID="grdAcompanantes" runat="server" AutoGenerateColumns="false" CssClass="gridViewCita">
            <Columns>
                 <asp:TemplateField>
                    <ItemTemplate>
                         <a href="#" onclick="javascript:GetSelectedValue(<%# Eval("id_reg_acompnante") %>,'<%# Eval("nombre_acompanante") %>');">Select</a>
                    </ItemTemplate>
                </asp:TemplateField>
               <asp:BoundField DataField="id_reg_acompnante" HeaderText="Id" />
               <asp:BoundField DataField="dni_ruc_acompanante" HeaderText="DNI/RUC" />
               <asp:BoundField DataField="nombre_acompanante" HeaderText="Nombre" />
            </Columns>
            <EmptyDataTemplate>
                        <table style="width:100%">
                            <tr>
                                <td>No data Found</td>
                            </tr>
                        </table>
            </EmptyDataTemplate> 
        </asp:GridView>
        <asp:HiddenField ID="hdId" runat="server" />
        <asp:HiddenField ID="hdNombre" runat="server" />
    </form>
</body>
</html>
