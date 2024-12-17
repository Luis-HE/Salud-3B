using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;

using CapaEntidad;
using CapaLogicaNegocio;
using System.Text;
using System.Drawing;

namespace CapaPresentacion.Forms
{
    public partial class frmLiquidacionAtencionPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void grdLiquidacionAtencion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdLiquidacionAtencion.PageIndex = e.NewPageIndex;
            BindLiquidacionAtencion();
        }
        private void BindLiquidacionAtencion()
        {
            grdLiquidacionAtencion.DataSource = LogicaLiquidacionAtencion.ListLiquidacionAtencion(txtDni_cliente.Text);
            grdLiquidacionAtencion.DataBind();

        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            BindLiquidacionAtencion();
        }

        protected void btnExportExcel_Click(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=Liquidacion.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel"; 
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                grdLiquidacionAtencion.AllowPaging = false;

                grdLiquidacionAtencion.RenderControl(hw);
                Response.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/frmMenu.aspx");
        }
    }

}