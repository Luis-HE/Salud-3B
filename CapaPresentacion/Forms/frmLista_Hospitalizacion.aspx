<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/MasterPage.Master" CodeBehind="frmLista_Hospitalizacion.aspx.cs" Inherits="CapaPresentacion.Forms.frmLista_Hospitalizacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
   <script type="text/javascript" src="../Scripts/jquery.min.js"> </script>
   <script type="text/javascript" src="../Scripts/SoloNumeros.js"></script>
  <script type="text/javascript" src="../Scripts/TexboxEnterNextControl.js"></script>
    <script type="text/javascript"> 
    function OpenNotasEnfermeria()
    {
        window.open("../Forms/frmNotas_Enfermeria.aspx", 'Lista Empresas', 'height=550,width=600,left=265,top=165,resizable=No,toolbar=No')
    }
     
</script>

   <fieldset class="fieldset">
     <legend class="legend">Pacientes Hospitalizados</legend>
       <table style="margin:auto">
           <tr>
               <td >
                   <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" CssClass="button" /></td>
           </tr>
       </table>

         <asp:GridView ID="grdHospitalizados" runat="server" AutoGenerateColumns="false" CssClass="gridView">
         <Columns>
             <asp:BoundField DataField="dni_cliente" HeaderText="N°. DNI" />
             <asp:BoundField DataField="apellidos" HeaderText="Apellidos" />
             <asp:BoundField DataField="nombres" HeaderText="Nombres" />
             <asp:BoundField DataField="tipo_admision" HeaderText="Tipo de Atencion" />
             <asp:BoundField DataField="fecha_admision" HeaderText="Fecha de Atención" />
             <asp:BoundField DataField="nombre_familiar" HeaderText="Acompañante" />
             <asp:BoundField DataField="tipo_paciente" HeaderText="Tipo de Paciente" />
             <asp:TemplateField HeaderText="">
                  <ItemTemplate>
                      <asp:ImageButton ID="imgBotonAlta" runat="server" ImageUrl="~/Images/find.png"   />
                  </ItemTemplate>
             </asp:TemplateField> 
             <asp:TemplateField HeaderText="">
                  <ItemTemplate>
                      <asp:ImageButton ID="imgBotonNotasEnf" runat="server" ImageUrl="~/Images/find.png" OnClientClick="OpenNotasEnfermeria()"   />
                  </ItemTemplate>
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
    </fieldset>

</asp:Content>
 