using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaEntidad;
using CapaLogicaNegocio;
using System.Data;

namespace CapaPresentacion.Forms
{
    public partial class frmIngresoMaterial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = Session["Username"].ToString();
            if (!IsPostBack)
            {
                drpUnidadNegocio.DataSource = LogicaUnidadNegocio.ReadUnidadNegocio();
                drpUnidadNegocio.DataValueField = "id_unidad_negocio";
                drpUnidadNegocio.DataTextField = "nombre_unid_negocio";
                drpUnidadNegocio.DataBind();

                BindAlmacenes();
                SetGridView();
            }
        }
        protected void CargarListaCompras(object sender, EventArgs e)
        {
            if (txtId_ItemCatalogo.Text.Trim().Length == 0 )
            {
                return;
            }
            else
            {
                CreateNewRowGridCompras();
                //clean fields
                txtId_ItemCatalogo.Text = "";
                txtDescrip_catalogo.Text = "";
                txtCantidad_entra.Text = "0";
                txtPrecio_entra.Text = "0";
                txtPrecio_item.Text = "0";
                txtNumero_documento.Text = "";
                txtIdClase_item.Text = "";
                txtIdGrupo_item.Text = "";
                txtFechaVence.Text = "";

            }
        }
        private void BindAlmacenes()
        {
            drpAlmacenes.DataSource = LogicaAlmacen.ReadAlmacen();
            drpAlmacenes.DataValueField = "codigo_almacen";
            drpAlmacenes.DataTextField = "nombre";           
            drpAlmacenes.DataBind();
        }
        private void SetGridView()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Col1", typeof(string)));
            dt.Columns.Add(new DataColumn("Col2", typeof(string)));
            dt.Columns.Add(new DataColumn("Col3", typeof(string)));
            dt.Columns.Add(new DataColumn("Col4", typeof(string)));
            dt.Columns.Add(new DataColumn("Col5", typeof(string)));
            dt.Columns.Add(new DataColumn("Col6", typeof(string)));
            dt.Columns.Add(new DataColumn("Col7", typeof(string)));
            dt.Columns.Add(new DataColumn("Col8", typeof(string)));
            dt.Columns.Add(new DataColumn("Col9", typeof(string)));
            dt.Columns.Add(new DataColumn("Col10", typeof(string)));
            dt.Columns.Add(new DataColumn("Col11", typeof(string)));
            dt.Columns.Add(new DataColumn("Col12", typeof(string)));
            dt.Columns.Add(new DataColumn("Col13", typeof(string)));
            ViewState["CurrentTable"] = dt;
            grdListaCompras.DataSource = dt;
            grdListaCompras.DataBind();
        }
        public void CreateNewRowGridCompras()
        {
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                for (int i = 0; i <= dtCurrentTable.Rows.Count; i++)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["Col1"] = i + 1;
                    drCurrentRow["Col2"] = txtId_ItemCatalogo.Text;
                    drCurrentRow["Col3"] = txtDescrip_catalogo.Text;
                    drCurrentRow["Col4"] = txtCantidad_entra.Text;
                    drCurrentRow["Col5"] = txtPrecio_entra.Text;
                    drCurrentRow["Col6"] = txtPrecio_item.Text;
                    drCurrentRow["Col7"] = drpAlmacenes.SelectedItem.Value;
                    drCurrentRow["Col8"] = txtNumero_documento.Text;
                    drCurrentRow["Col9"] = drpDocsContables.SelectedItem.Value;
                    drCurrentRow["Col10"] = txtNumeroLote.Text;
                    drCurrentRow["Col11"] = txtFechaVence.Text;
                    drCurrentRow["Col12"] = txtIdClase_item.Text;
                    drCurrentRow["Col13"] = txtIdGrupo_item.Text;

                }
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;
                grdListaCompras.DataSource = dtCurrentTable;
                grdListaCompras.DataBind();
            }
        }
        protected void BorrarFila(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvRow = (GridViewRow)btn.NamingContainer;
            int rowID = gvRow.RowIndex;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    //Remove the Selected Row data and reset row number  
                    dt.Rows.Remove(dt.Rows[rowID]);
                    ResetRowID(dt);
                }
                dt.AcceptChanges();
                //Store the current data in ViewState for future reference
                ViewState["CurrentTable"] = dt;
                //Re bind the GridView for the updated data  
                grdListaCompras.DataSource = dt;
                grdListaCompras.DataBind();
            }
        }
        private void ResetRowID(DataTable dt)
        {
            int rowNumber = 1;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    row[0] = rowNumber;
                    rowNumber++;
                }
            }
        }
        protected void GuardarCompras(object sender, EventArgs e)
        {
            if (grdListaCompras.Rows.Count == 0)
            {
                return;
            }
            else
            {
                EntidadMovimientoCatalogo entMovCatalogo = new EntidadMovimientoCatalogo();
               foreach (GridViewRow row in grdListaCompras.Rows)
                {
                    entMovCatalogo.cod_item_catalogo = row.Cells[1].Text;
                    entMovCatalogo.fecha_movimiento = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                    entMovCatalogo.cantidad = Convert.ToInt32(row.Cells[3].Text);
                    entMovCatalogo.codigo_usuario = lblUsuario.Text;
                    entMovCatalogo.precio_entrada = Convert.ToDecimal(row.Cells[4].Text);
                    entMovCatalogo.precio_venta = Convert.ToDecimal(row.Cells[5].Text);
                    entMovCatalogo.codigo_almacen = Convert.ToInt32(row.Cells[6].Text);
                    entMovCatalogo.numero_documento = row.Cells[7].Text;
                    entMovCatalogo.tipo_documento = row.Cells[8].Text;
                    entMovCatalogo.tipo_movimiento = "Entrada";
                    entMovCatalogo.motivo = txtMotivo.Text;
                    entMovCatalogo.ruc_proveedor = txt_ruc_proveedor.Text;
                    entMovCatalogo.cod_persona_pago = Convert.ToInt32(txt_cod_persona.Text);
                    entMovCatalogo.numero_lote = txtNumeroLote.Text;
                    entMovCatalogo.fecha_vence = txtFechaVence.Text;
                    entMovCatalogo.id_clase = Convert.ToInt32(row.Cells[11].Text);
                    entMovCatalogo.id_grupo = Convert.ToInt32(row.Cells[12].Text);
                    entMovCatalogo.id_unidad_negocio = Convert.ToInt32(drpUnidadNegocio.SelectedItem.Value);

                    LogicaMovimientoCatalogo.InsertMovimientoCatalogo(entMovCatalogo);
                    //updating kardex
                    LogicaKardex.UpdateKardex(Convert.ToInt32(row.Cells[3].Text), Convert.ToDecimal(row.Cells[5].Text), row.Cells[1].Text, Convert.ToInt32(row.Cells[6].Text));

                 }
                CleanFields();
             }
            
        }
        private void CleanFields()
        {
            //clean gridCompras
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            dt.Clear();
            grdListaCompras.DataSource = null;
            grdListaCompras.DataBind();
        }
        protected void ListarReporteProductos(object sender, EventArgs e)
        {
            grdReporteProductosMovLogistico.DataSource = LogicaReporteProductosCatalogo.ListReporteProductosCatalogo();
            grdReporteProductosMovLogistico.DataBind();
        }
        protected void CerrarPantalla(object sender, EventArgs e)
        {
            Response.Redirect("~/frmMenu.aspx");         
            
        }
    }
}