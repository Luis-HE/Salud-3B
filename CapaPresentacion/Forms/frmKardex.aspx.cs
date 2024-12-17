using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaEntidad;
using CapaLogicaNegocio;

namespace CapaPresentacion.Forms
{
    public partial class frmKardex : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //BindCatalogoProductos();
            }
            RegisterPostBackControl();
        }
        protected void ListarMovimiento(object sender, EventArgs e)
        {
            grdMovimientosCatalogo.DataSource = LogicaReporteMovimientoCatalogo.ListReporteMovCatalogo(txtId_ItemCatalogo.Text);
            grdMovimientosCatalogo.DataBind();
        }
        protected void CalcularExistencias(object sender, GridViewRowEventArgs e)
        {

            //double precio_Existencia = 0;
            int cantidad_Existencia = 0;
            foreach (GridViewRow gvr in grdMovimientosCatalogo.Rows)
            {
                if (Convert.ToInt32(gvr.Cells[5].Text) > 0)
                {
                    //total salidas
                    gvr.Cells[8].Text = (-1*(Convert.ToInt32(gvr.Cells[2].Text) + Convert.ToInt32(gvr.Cells[5].Text))).ToString();
                }
                else
                {
                    //total entradas
                    gvr.Cells[8].Text = (Convert.ToInt32(gvr.Cells[2].Text) + Convert.ToInt32(gvr.Cells[5].Text)).ToString();
                }

                cantidad_Existencia += Convert.ToInt32(gvr.Cells[8].Text);
                //precio_Existencia += Convert.ToDouble(dr["precio_existe"]); 
            }
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                Label lblSumCantidad_existe = (Label)e.Row.FindControl("lblSumCantidad_existe");
                lblSumCantidad_existe.Text = cantidad_Existencia.ToString();
            }

        }
        protected void ConsolidarReporteMovimiento(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "";
                HeaderCell.ColumnSpan = 2;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "ENTRADAS";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ForeColor = Color.White;
                HeaderCell.ColumnSpan = 3;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "SALIDAS";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ForeColor = Color.White;
                HeaderCell.ColumnSpan = 3;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderCell = new TableCell();
                HeaderCell.Text = "EXISTENCIAS";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ForeColor = Color.White;
                HeaderCell.ColumnSpan = 3;
                HeaderGridRow.Cells.Add(HeaderCell);

                HeaderGridRow.BackColor = ColorTranslator.FromHtml("#1F497D");
                grdMovimientosCatalogo.Controls[0].Controls.AddAt(0, HeaderGridRow);

            }
        }
      
        private void BindCatalogoProductos()
        {
            //grdCatalogoProductos.DataSource = LogicaCatalogo.ListItemsCatalogo("Producto");
            //grdCatalogoProductos.DataBind();
        }
        protected void ListarArticulo(object sender, EventArgs e)
        {
            BindCatalogoProductos();
        }
        protected void CerrarPopUP(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
        }
        protected void Seleccionar(object sender, EventArgs e)
        {
            ////ImageButton imgButon = sender as ImageButton;
            //// GridViewRow gRow = (GridViewRow)imgButon.NamingContainer;
            //txtId_ItemCatalogo.Text = ((sender as LinkButton).NamingContainer as GridViewRow).Cells[1].Text;
            //txt_Nombre_articulo.Text = ((sender as LinkButton).NamingContainer as GridViewRow).Cells[2].Text;
            ////txt_existencia_minima.Text = ((sender as LinkButton).NamingContainer as GridViewRow).Cells[3].Text;
            ////txt_existencia_maxima.Text = ((sender as LinkButton).NamingContainer as GridViewRow).Cells[4].Text;
            //ModalPopupExtender1.Hide();
        }
        private void RegisterPostBackControl()
        {
            foreach (GridViewRow row in grdCatalogoProductos.Rows)
            {
                LinkButton imgButon = row.FindControl("imgBotonSelect") as LinkButton;
                ScriptManager.GetCurrent(this).RegisterPostBackControl(imgButon);
            }
        }
        protected void CerrarPantalla(object sender, EventArgs e)
        {
            Response.Redirect("~/frmMenu.aspx");
        }
    }
}