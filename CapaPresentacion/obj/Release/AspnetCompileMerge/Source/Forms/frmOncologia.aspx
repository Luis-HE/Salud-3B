<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.Master" CodeBehind="frmOncologia.aspx.cs" Inherits="CapaPresentacion.Forms.frmOncologia" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

 
 <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <table>
      <tr>
          <td></td>
          <td><asp:Button ID="btnListar" runat="server" Text="Listar" OnClick="btnListar_Click" />
              <asp:TextBox ID="txtResult" runat="server"></asp:TextBox>
          </td>
      </tr>       
  </table>
 <table >
     <tr>
         <td >
             <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server"  AutoDataBind="true" />
             <%--<CR:CrystalReportSource ID="cystalReportSource1" runat="server">
                 <Report FileName="~/FormsReports/Reporte.rpt">
                    
                 </Report>
             </CR:CrystalReportSource>--%>
         </td>
     </tr>
 </table>
</asp:Content>

