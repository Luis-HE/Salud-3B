using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaEntidad;
using CapaLogicaNegocio;
namespace CapaPresentacion.Forms
{
    public partial class frmListar_Catalogo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                drpCiasSeguros.DataSource = LogicaProveedorSeguro.ListProveedorSeguro();
                drpCiasSeguros.DataValueField = "id_cia_seguro";
                drpCiasSeguros.DataTextField = "nombre_seguro";
                drpCiasSeguros.DataBind();
            }
        }

        protected void BuscarItemNombreGenerico(object sender, EventArgs e)
        {
            if(rdServicio.Checked==true)
            {
                grdCatalogoItems.DataSource = LogicaCatalogo.ListItemsCatalogo(Convert.ToInt32(drpCiasSeguros.SelectedItem.Value), txtBuscar_descrip.Text);
                grdCatalogoItems.DataBind();
            }
            else if(rdProducto.Checked==true)
            {
                grdCatalogoItems.DataSource = LogicaCatalogo.ListItemsCatalogo(1,"Producto", txtBuscar_descrip.Text);
                grdCatalogoItems.DataBind();
            }
            
        }
        protected void BuscarItemNombreComercial(object sender, EventArgs e)
        {
            grdCatalogoItems.DataSource = LogicaCatalogo.ListItemsCatalogo(2, "Producto", txtBuscaNombreComercial.Text);
            grdCatalogoItems.DataBind();
        }
    }
}