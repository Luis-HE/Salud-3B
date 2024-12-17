<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmAccesoRestringido.aspx.cs" Inherits="CapaPresentacion.Forms.frmAccesoRestringido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <br />
    <br />
     <table style="width:100%; text-align:center">
       <tr>
           <td><img alt="" src="../Images/acceso_denegado.jpg" /></td>
       </tr>
         <tr>
             <td><h4 style="color:red">Su nivel de Usuario no le permite tener acceso a este sitio.<br />
                 Si desea tener acceso a este sitio por favor comuníquese con su Jefe.</h4></td>
         </tr>
   </table> 

</asp:Content>