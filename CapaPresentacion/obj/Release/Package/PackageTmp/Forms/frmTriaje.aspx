<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmTriaje.aspx.cs" Inherits="CapaPresentacion.Forms.frmTriaje" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />

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
        window.open("../Forms/frmListar_Medicos.aspx", 'Lista Empresas', 'height=550,width=600,left=265,top=165,resizable=No,toolbar=No')
    }

    function calculaIMC()
    {
        var talla = document.getElementById("<%=txtTalla.ClientID %>");
        var peso = document.getElementById("<%=txtPeso.ClientID %>");
        var imc = document.getElementById("<%=txtImc.ClientID %>");
        imc.value = (peso.value / ((talla.value) * (talla.value))).toFixed(2);
       
        document.getElementById("<%=txtImc.ClientID %>").value = imc.value;
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
                <td style="text-align:right">Colaborador:</td>
                <td><asp:TextBox ID="txtDni_empleado" runat="server" Width="100px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtDni_empleado" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ErrorMessage="completar..."></asp:RequiredFieldValidator>
                    <asp:Button ID="btnBuscarMedico" runat="server" Text=" " CssClass="btnOpenPopup" OnClientClick="OpenListEmpleados()" CausesValidation="false"/>
                    <asp:TextBox ID="txtNombre_empleado" runat="server" Width="235px" CssClass="textBoxDisabled" ClientIDMode="Static"></asp:TextBox>
                </td>
            </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btnRefrescar" runat="server" Text="Actualizar" CssClass="button" OnClick="RegrescarGridview" CausesValidation="false"/></td>
        </tr>
    </table>
    <asp:GridView ID="grdAdmitidos" runat="server" CssClass="gridViewCita" AutoGenerateColumns="false">
        <Columns>
            <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="SelecionarRegistro" CausesValidation="false">Select</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            <asp:BoundField DataField="numero_admision" HeaderText="N° de Cuenta" />
            <asp:BoundField DataField="tipo_admision" HeaderText="Tipo admisión" />
            <asp:BoundField DataField="numdoc" HeaderText="DNI/CE" />
            <asp:BoundField DataField="apelPater" HeaderText="Apellido Paterno" />
            <asp:BoundField DataField="apelMater" HeaderText="Apellido Materno" />
            <asp:BoundField DataField="fecha_nace" HeaderText="Fecha Nace" />
            <asp:BoundField DataField="mont_adelanto" HeaderText="Adelanto(S/.)" />
            <asp:BoundField DataField="monto_total" HeaderText="Monto Pagado" />
            <asp:BoundField DataField="tipo_doc_pago" HeaderText="Tipo Doc." />
            <asp:BoundField DataField="serie_doc_pago" HeaderText="Serie" />
            <asp:BoundField DataField="num_doc_pago" HeaderText="N° Boleta/Factura" />           
           
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
            <td>
                <fieldset class="fieldset"> 
                    <legend>Información General</legend>   
                    <table>
                        <tr>
                            <td style="text-align:right">N°. de Cuenta:</td>
                            <td><asp:Label ID="lblNumAtencion" runat="server" Text="" CssClass="label" Width="100px"></asp:Label></td>
                        </tr>
                         <tr>
                          <td style="text-align:right">N° Historia Clinica:</td>
                            <td><asp:Label ID="lblNumHistoria" runat="server" Text="" CssClass="label" Width="100px"></asp:Label></td>
                        </tr>
                         <tr>
                          <td style="text-align:right">N° DNI/CE:</td>
                            <td><asp:Label ID="lblNumDocCliente" runat="server" Text="" CssClass="label" Width="100px"></asp:Label></td>
                        </tr>
                          
                        <tr>
                            <td style="text-align:right">Prioridad:</td>
                            <td>
                                <asp:DropDownList ID="drpPrioridad" runat="server" Width="110px" CssClass="dropDownList" >
                                    <asp:ListItem>Prioridad I</asp:ListItem>
                                    <asp:ListItem>Prioridad II</asp:ListItem>
                                    <asp:ListItem>Prioridad III</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                         <tr>
             <td style="text-align:right">Edad:</td>
             <td><asp:TextBox ID="txtEdad" runat="server" Width="100px" CssClass="txtboxNumber"></asp:TextBox>años
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEdad" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ErrorMessage="completar..."></asp:RequiredFieldValidator>
             </td>
         </tr>
         <tr>
             <td style="text-align:right">Talla:</td>
             <td><asp:TextBox ID="txtTalla" runat="server" Width="100px" CssClass="txtboxNumber"></asp:TextBox>mts.
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtTalla" Display="Dynamic" ForeColor="Red" SetFocusOnError="true" ErrorMessage="completar..."></asp:RequiredFieldValidator>
             </td>
         </tr>
         <tr>
             <td style="text-align:right">Peso:</td>
             <td><asp:TextBox ID="txtPeso" runat="server" Width="100px" CssClass="txtboxNumber"></asp:TextBox>kg.
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPeso" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ErrorMessage="completar..."></asp:RequiredFieldValidator>
             </td>
         </tr>
          <tr>
             <td style="text-align:right">Presión arterial:</td>
             <td>Sistólica:<asp:TextBox ID="txtPresion_arterial_sistolica" runat="server" Width="70px" CssClass="txtboxNumber"></asp:TextBox>
                 Diastólica:<asp:TextBox ID="txtPresion_arterial_diastolica" runat="server" Width="70px" CssClass="txtboxNumber"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPresion_arterial_sistolica" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ErrorMessage="completar..."></asp:RequiredFieldValidator>
             </td>
         </tr>
        <tr>
            <td style="text-align:right">Ritmo cardiaco:</td>
            <td><asp:TextBox ID="txt_ritmo_cardiaco" runat="server" Width="100px" CssClass="txtboxNumber"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txt_ritmo_cardiaco" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ErrorMessage="completar..."></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="text-align:right">Temperatura:</td>
            <td>
                <asp:TextBox ID="txt_temperatura" runat="server" Width="100px" CssClass="txtboxNumber"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txt_temperatura" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ErrorMessage="completar..."></asp:RequiredFieldValidator>
            </td>
        </tr>
            <tr>
                <td style="text-align:right">I.M.C. :</td>
                <td><asp:TextBox ID="txtImc" runat="server" Width="100px" CssClass="txtboxNumber"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtImc" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ErrorMessage="completar..."></asp:RequiredFieldValidator>
                    <input id="btnIMC" type="button"  class="buttonIconOk" onclick="calculaIMC()"  />
                </td>
            </tr>
                <tr>
                <td style="text-align:right">F.R. :</td>
                <td><asp:TextBox ID="txtFrecRespira" runat="server" Width="100px" CssClass="txtboxNumber"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtFrecRespira" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ErrorMessage="completar..."></asp:RequiredFieldValidator>
                </td>
            </tr>
                <tr>
                <td style="text-align:right">SPO2:</td>
                <td><asp:TextBox ID="txtspOxigeno" runat="server" Width="100px" CssClass="txtboxNumber"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtspOxigeno" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ErrorMessage="completar..."></asp:RequiredFieldValidator>
                </td>
            </tr>
                 
                       
      </table>
                </fieldset>
            </td>
            <td>
                <fieldset class="fieldset">
                    <legend>Información  Gineco-Obstetricia</legend>
                    <table>
                        <tr>
                            <td style="text-align:right">Problema Principal:</td>
                            <td><asp:TextBox ID="txtGineProblemPrincipal" runat="server" Width="300px" Height="30px" CssClass="textbox" TextMode="MultiLine"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align:right">ANTECEDENTES:</td>
                            <td></td>
                        </tr>
                        <tr>
                            <td style="text-align:right">Tiempo de Embarazo:</td>
                            <td><asp:TextBox ID="txtGineTiempoEmbarazo" runat="server" Width="300px" CssClass="textbox"  ></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align:right">Diabétes Mellitus:</td>
                            <td><asp:TextBox ID="txtGineDiabetes" runat="server" Width="300px" CssClass="textbox"  ></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align:right">Hipertensión arterial crónica:</td>
                            <td><asp:TextBox ID="txtGineHipertensionArterial" runat="server" Width="300px" CssClass="textbox" ></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align:right">Cardiopatia:</td>
                            <td><asp:TextBox ID="txtGineCardiopatia" runat="server" Width="300px" CssClass="textbox"  ></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align:right">Enfermedad Tiroidea:</td>
                            <td><asp:TextBox ID="txtGineEnfermedadTiroidea" runat="server" Width="300px" CssClass="textbox"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align:right">Enfermedad Renal:</td>
                            <td><asp:TextBox ID="txtGineEnfermedadRenal" runat="server" Width="300px" CssClass="textbox"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align:right">Otras Patologías:</td>
                            <td><asp:TextBox ID="txtGineOtrasPatologias" runat="server" Width="300px" CssClass="textbox"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align:right">Amenaza de Aborto:</td>
                            <td><asp:TextBox ID="txtGineAmenazaAborto" runat="server" Width="300px" CssClass="textbox"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align:right">Amenaza de parto pretérmino:</td>
                            <td><asp:TextBox ID="txtGineAmenzaParto" runat="server" Width="300px" CssClass="textbox"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align:right">Embarazo de término en trabajo de parto:</td>
                            <td><asp:TextBox ID="txtGineEmbarazoTermino" runat="server" Width="300px" CssClass="textbox"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align:right">Enfermedad hipertensiva del embarazo:</td>
                            <td><asp:TextBox ID="txtGineEnfermedadHipertensiva" runat="server" Width="300px" CssClass="textbox"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align:right">Hemorragia:</td>
                            <td><asp:TextBox ID="txtGineHemorragia" runat="server" Width="300px" CssClass="textbox"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align:right">Sepsis:</td>
                            <td><asp:TextBox ID="txtGineSepsis" runat="server" Width="300px" CssClass="textbox"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align:right">Otros:</td>
                            <td><asp:TextBox ID="txtGineOtros" runat="server" Width="300px" CssClass="textbox"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align:right">Sintomatología:</td>
                            <td><asp:TextBox ID="txtGineSintomatologia" runat="server" Width="300px" CssClass="textbox"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align:right">Indice de choque(Frecuencia cardiáca/Presión sistólica):</td>
                            <td><asp:TextBox ID="txtGineIndiceChoque" runat="server" Width="300px" CssClass="textbox"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align:right">EVALUACIÓN:</td>
                            <td></td>
                        </tr>
                        <tr>
                            <td style="text-align:right">Diagnóstico probable:</td>
                            <td><asp:TextBox ID="txtGineDiagnosticoProbable" runat="server" Width="300px" CssClass="textbox"></asp:TextBox></td>
                        </tr>
                        <tr>
                            <td style="text-align:right">PLAN TERAPEUTICO:</td>
                            <td></td>
                        </tr>
                        <tr>
                            <td style="text-align:right"></td>
                            <td><asp:TextBox ID="txtGinePlanTerapeutico" runat="server" Width="300px" CssClass="textbox"></asp:TextBox></td>
                        </tr>
                    </table>
                </fieldset>
            </td>
        </tr>
    </table>
  

    <table style="margin:auto">
         <tr>
                            <td></td>
                            <td><asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="button" OnClick="GuardarTriaje" />
                                 <asp:Label ID="lblMsj" runat="server" Text="" ForeColor="Green" Font-Bold="true"></asp:Label>
                                
                            </td>
           </tr>
    </table>
</asp:Content>