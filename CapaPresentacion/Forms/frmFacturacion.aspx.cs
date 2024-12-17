using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using CapaEntidad;
using CapaLogicaNegocio;
using System.Text;

namespace CapaPresentacion.Forms
{
    public partial class frmFacturacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void ListarTablas(object sender, EventArgs e)
        {
            grdTramas.DataSource = LogicaTramaSiete.ListTramaSiete(Convert.ToInt32(drpMes.SelectedItem.Value),Convert.ToInt32(drpTablas.SelectedItem.Value));
            grdTramas.DataBind();
        }
        protected void GenerarTramas(object sender, EventArgs e)
        {
            string webRootPath = Server.MapPath("~");
            string fileName = "20552144415" + Convert.ToInt32(drpTablas.SelectedItem.Value).ToString("000");
            string filePath = Path.GetFullPath(Path.Combine(webRootPath, "C:/TRAMAS_TEDEF/" + fileName + ".txt"));
            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                foreach (GridViewRow row in grdTramas.Rows)
                {
                    foreach (TableCell cell in row.Cells)
                    {
                        sw.Write(cell.Text);
                    }
                    sw.Write(Environment.NewLine);
                }
            }
        }
        protected void CerrarTrama(object sender, EventArgs e)
        {
            Response.Redirect("~/frmMenu.aspx");
        }
    }
}