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
    public partial class frmCatalogoProductoServicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                drpUnidadMedida.DataSource = LogicaUnidadMedida.ReadUnidadMedida();
                drpUnidadMedida.DataValueField = "cod_unidad_medida";
                drpUnidadMedida.DataTextField = "nombre_medida";
                drpUnidadMedida.DataBind();

                drpCategoria.DataSource = LogicaCategoria.ListCategoria();
                drpCategoria.DataValueField = "codigo_categoria";
                drpCategoria.DataTextField = "nombre_categoria";
                drpCategoria.DataBind();

                drpLaboratorios.DataSource = LogicaProveedor.ReadProveedor();
                drpLaboratorios.DataValueField = "ruc_proveedor";
                drpLaboratorios.DataTextField = "razon_comercial";
                drpLaboratorios.DataBind();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadCatalogo entCatal = new EntidadCatalogo();
            if (rdProducto.Checked == true)
            {
                entCatal.tipo_item = "Producto";
                entCatal.cod_item_catalogo = "CUNIVPR" + LogicaCatalogo.CountItemsCatalogo("Producto")[0].AuxCountItems.ToString("00000");// ojo revisar aqui algoritmo para generar codigo
            }
            else if (rdServicio.Checked == true)
            {
                entCatal.tipo_item = "Servicio";
                entCatal.cod_item_catalogo = "CUNIVSR" + LogicaCatalogo.CountItemsCatalogo("Servicio")[0].AuxCountItems.ToString("00000");// ojo revisar aqui algoritmo para generar codigo
            }         
            entCatal.cod_color = Convert.ToInt32(drpColor.SelectedItem.Value);
            entCatal.cod_categoria = Convert.ToInt32(drpCategoria.SelectedItem.Value);
            entCatal.cod_marca = Convert.ToInt32(drpMarca.SelectedItem.Value);
            entCatal.cod_uni_med = Convert.ToInt32(drpUnidadMedida.SelectedItem.Value);
            entCatal.cod_modelo = Convert.ToInt32(drpModelo.SelectedItem.Value);
            entCatal.descripcion_principal = txtDescripcion.Text.Trim();
            entCatal.peso = Convert.ToInt32(txtPeso.Text);
            entCatal.motivo_uso = drpMotivoUso.SelectedItem.Text;
            entCatal.estado = "Activo";
            entCatal.cod_segus = "";
            entCatal.precio = 0;
            entCatal.cuenta_contable = "";
            //entCatal.cod_unid_medida_sunat = drpUnid_sunat.SelectedItem.Text;
            entCatal.descripcion_secundaria = txtDescripcion_Cientifica.Text;
            
            if(txtDescripcion.Text.Trim().Length==0)
            {
                return;
            }
            else
            {
                LogicaCatalogo.InsertCatalogo(entCatal);
                lblMsj.Text = "Registro exitoso!";
                CleanFields();
                BindItemsCatalogo();
            }
            
        }
        private void CleanFields()
        {
            txtDescripcion.Text = "";
            txtDescripcion_Cientifica.Text = "";
            txtPeso.Text = "0";
            lblMsj.Text = "";
            txtDescripcion.Focus();
        }
        private void BindItemsCatalogo()
        {
            //grdCatalogoItems.DataSource = LogicaCatalogo.ListItemsCatalogo("Producto");
            //grdCatalogoItems.DataBind();
        }
        protected void ModificarItem(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            EntidadCatalogo entcat = new EntidadCatalogo();
            entcat.cod_item_catalogo = row.Cells[0].Text;
            TextBox descripcion = (TextBox)row.FindControl("txtDescripcionItem");
            TextBox descripcionCientifica = (TextBox)row.FindControl("txtDescripcionCientifica");
            DropDownList drpUnidadMedida = (DropDownList)row.FindControl("drpUnidadMedida");

            entcat.descripcion_principal = descripcion.Text;
            entcat.descripcion_secundaria = descripcionCientifica.Text;
            entcat.cod_uni_med = Convert.ToInt32(drpUnidadMedida.SelectedItem.Value);
            LogicaCatalogo.ModificarItemCatalogo(entcat);
            BindItemsCatalogo();
        }
        protected void EliminarItem(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            string codigo_item = row.Cells[0].Text;

            EntidadKardex entKar = new EntidadKardex();
            entKar.codigo_item_catalogo = codigo_item;
            entKar.codigo_almacen = 1;
            //eliminar del Kardex primero
            LogicaKardex.DeleteKardex(entKar);
            //Eliminar item del catalogo
            LogicaCatalogo.EliminarItemCatalogo(codigo_item);
            BindItemsCatalogo();
        }
        protected void GridViewRowdDtaBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DropDownList drpUnidadMedida = (DropDownList)e.Row.FindControl("drpUnidadMedida");
                drpUnidadMedida.DataSource = LogicaUnidadMedida.ReadUnidadMedida();
                drpUnidadMedida.DataValueField = "cod_unidad_medida";
                drpUnidadMedida.DataTextField = "nombre_medida";
                drpUnidadMedida.DataBind();
                //Select the Unidad in DropDownList
                string cod_unidadMedida = ((Label)e.Row.FindControl("lblCodUnidMed")).Text;
                drpUnidadMedida.Items.FindByValue(cod_unidadMedida).Selected = true;
                
                //bind others paramaters TBL_CATALOGO
            }
        }
        protected void btnListarProductos_Click(object sender, EventArgs e)
        {
            BindItemsCatalogo();
        }

        protected void btnCerrarPantalla_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/frmMenu.aspx");
        }
    }
}