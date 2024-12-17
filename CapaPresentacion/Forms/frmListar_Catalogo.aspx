<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmListar_Catalogo.aspx.cs" Inherits="CapaPresentacion.Forms.frmListar_Catalogo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link href="../Styles/StyleControls.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/StyleModalPopUp.css" rel="stylesheet" type="text/css" />
   <link href="../Styles/StyleCalendar.css" rel="stylesheet" type="text/css" />
 
    <script type="text/javascript">
        function GetSelectedValue(cod_item,descripcion, precio,id_grupo,id_clase)
        {
            var varcodItem = document.getElementById("<%= hd_cod_item.ClientID %>");
            varcodItem.value = cod_item;
           var varDescrip = document.getElementById("<%=hd_descripcion.ClientID%>");
            varDescrip.value = descripcion;
           var varprecio = document.getElementById("<%=hd_precio.ClientID%>");
            varprecio.value = precio;
            var varIdGrupo = document.getElementById("<%=hd_IdGrupo.ClientID%>");
            varIdGrupo.value = id_grupo;
             var varIdClase = document.getElementById("<%=hd_IdClase.ClientID%>");
            varIdClase.value = id_clase;

            window.opener.document.getElementById("txtId_ItemCatalogo").value = varcodItem.value;
            window.opener.document.getElementById("txtDescrip_catalogo").value = varDescrip.value;
            window.opener.document.getElementById("txtPrecio_item").value = varprecio.value;
            window.opener.document.getElementById("txtIdGrupo_item").value = varIdGrupo.value;
            window.opener.document.getElementById("txtIdClase_item").value = varIdClase.value;

            self.close();
        }

    </script>
 
</head>
<body>
    <form id="form1" runat="server">
        <fieldset class="fieldset">
            <legend class="legend">Parámetros de Busqueda</legend>
             <table style="margin:auto">
          <tr>
              <td style="text-align:right">Aseguradora:</td>
              <td><asp:DropDownList ID="drpCiasSeguros" runat="server" CssClass="dropDownList" Width="330px">

                  </asp:DropDownList>

              </td>
          </tr>
          <tr>
              <td></td>
              <td><asp:RadioButton ID="rdServicio" runat="server" Text="Servicio" GroupName="grupoUno" Checked="true" />
                  <asp:RadioButton ID="rdProducto" runat="server" Text="Producto" GroupName="grupoUno" />
              </td>
          </tr>
          <tr>
              <td style="text-align:right">Descripción Principal:</td>
              <td><asp:TextBox ID="txtBuscar_descrip" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>
                  <asp:Button ID="btnBuscarItem" runat="server" Text=" " CssClass="btnOpenPopup" ToolTip="Buscar" OnClick="BuscarItemNombreGenerico" />
              </td>
          </tr>
          <tr>
              <td style="text-align:right">Descripción Secundaria:</td>
              <td><asp:TextBox ID="txtBuscaNombreComercial" runat="server" CssClass="textbox" Width="300px"></asp:TextBox>
                  <asp:Button ID="btnBuscarNombreComercial" runat="server" Text=" " CssClass="btnOpenPopup" ToolTip="Buscar" OnClick="BuscarItemNombreComercial" />
              </td>
          </tr>
      </table>
        </fieldset>
        <asp:GridView ID="grdCatalogoItems" runat="server" AutoGenerateColumns="false" CssClass="gridViewCita">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                         <a href="#" onclick="javascript:GetSelectedValue('<%# Eval("cod_item_catalogo") %>','<%# Eval("descripcion_principal") %>',<%# Eval("precio") %>,<%# Eval("id_grupo") %>,<%# Eval("id_clase") %> );">Select</a>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:BoundField DataField="cod_item_catalogo" HeaderText="Código" />
                 <asp:BoundField DataField="descripcion_principal" HeaderText="Descripción 1" />
                 <asp:BoundField DataField="precio" HeaderText="Precio" />
                 <asp:BoundField DataField="cantidad" HeaderText="Cantidad" />
                 <asp:BoundField DataField="descripcion_secundaria" HeaderText="Descripción 2" />
                <asp:BoundField DataField="id_grupo" HeaderText="Grupo"  />
                <asp:BoundField DataField="id_clase" HeaderText="Clase"  />
            </Columns>
            <EmptyDataTemplate>
                        <table style="width:100%">
                            <tr>
                                <td>No data Found</td>
                            </tr>
                        </table>
            </EmptyDataTemplate> 
        </asp:GridView>
        <asp:HiddenField ID="hd_cod_item" runat="server" />
        <asp:HiddenField ID="hd_descripcion" runat="server" />
        <asp:HiddenField ID="hd_precio" runat="server" />
        <asp:HiddenField ID="hd_IdGrupo" runat="server" />
        <asp:HiddenField ID="hd_IdClase" runat="server" />
    </form>
</body>
</html>
