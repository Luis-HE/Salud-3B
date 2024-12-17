using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaEntidad;
using CapaLogicaNegocio;

namespace CapaPresentacion.Forms
{
    public partial class frmStockValorizado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["NivelAcceso"].ToString() == "3")
                {
                    Binddata();
                }
                else
                {
                    Response.Redirect("~/Forms/frmAccesoRestringido.aspx");
                }
            }
 
        }
        private void Binddata()
        {

            grdStock.DataSource = LogicaReporteStock.ListReporteStock() ;
            grdStock.DataBind();
        }
        protected void OnRowColorGridCell(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtStockMin = (TextBox)e.Row.FindControl("txtStockMinimo"); 
               if (Convert.ToInt32(e.Row.Cells[3].Text) <= Convert.ToInt32(txtStockMin.Text))
                {
                    e.Row.BackColor = System.Drawing.Color.Red;
                }

                //if (Convert.ToInt32(e.Row.Cells[3].Text) == Convert.ToInt32(e.Row.Cells[2].Text))
                //{
                //    e.Row.BackColor = System.Drawing.Color.Red;
                //}
                //else
                //{
                //    e.Row.BackColor = System.Drawing.ColorTranslator.FromHtml("#B6B6B4");
                //}
            }
        }
        protected void ModificarItem(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            TextBox txtStockMin = (TextBox)row.FindControl("txtStockMinimo");
            TextBox txtPrecioActual = (TextBox)row.FindControl("txtPrecioActual"); 

            LogicaKardex.ActualizaStockMinimo(Convert.ToInt32(txtStockMin.Text),Convert.ToDecimal(txtPrecioActual.Text), row.Cells[0].Text);
            Binddata();
        }
        
        protected void CerrarStock(object sender, EventArgs e)
        {
            Response.Redirect("~/frmMenu.aspx");
        }
    }
}