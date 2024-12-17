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
    public partial class frmLibroMayor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtPeriodo.Text = DateTime.Now.Year.ToString();
            }
        }
        protected void Mayorizar(object sender, EventArgs e)
        {
            grdLibroMayorCabecera.DataSource = LogicaReporteLibroMayor.ListReporteLibroMayorCabecera(drpMes.SelectedItem.Text,Convert.ToInt32(txtPeriodo.Text),txtRucDni.Text);
            grdLibroMayorCabecera.DataBind();

            foreach (GridViewRow rowCabecera in grdLibroMayorCabecera.Rows)
            {
                ImageButton imgPlus = rowCabecera.FindControl("imgPlus") as ImageButton;
                imgPlus.ImageUrl = "~/Images/minus.png";
                rowCabecera.FindControl("pnlDetails").Visible = true;
                string cod_cuenta = grdLibroMayorCabecera.Rows[rowCabecera.RowIndex].Cells[1].Text;
                GridView gvLibroMayorDetalle = rowCabecera.FindControl("grdLibroMayorDetalle") as GridView;
                gvLibroMayorDetalle.DataSource = LogicaReporteLibroMayor.ListReporteLibroMayorDetalle("", 0, cod_cuenta);
                gvLibroMayorDetalle.DataBind();

                //totalizando  los asientos
                double totalDebe = 0;
                double totalHaber = 0;
                foreach (GridViewRow rowDetalle in gvLibroMayorDetalle.Rows)
                {
                    //if (rowDetalle.Cells[3].Text.Trim().Length != 6)
                    //{
                    //    totalDebe = totalDebe + Convert.ToDouble(rowDetalle.Cells[3].Text);
                    //}
                    //if (rowDetalle.Cells[4].Text.Trim().Length != 6)
                    //{
                    //    totalHaber = totalHaber + Convert.ToDouble(rowDetalle.Cells[4].Text);
                    //}
                }
                gvLibroMayorDetalle.FooterRow.Cells[3].Text = totalDebe.ToString();
                gvLibroMayorDetalle.FooterRow.Cells[4].Text = totalHaber.ToString();

                //fin totalizacion
            }
        }
        protected void CerrarMayorizacion(object sender, EventArgs e)
        {
            Response.Redirect("~/frmMenu.aspx");
        }
    }
}