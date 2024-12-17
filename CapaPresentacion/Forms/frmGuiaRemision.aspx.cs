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
    public partial class frmGuiaRemision : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //MostrarDetalleGuiaRemision();
            }
        }
        protected void btnGuardarDetalle_Click(object sender, EventArgs e)
        {
            EntidadGuiaRemision entGuiaRem = new EntidadGuiaRemision();
            foreach (GridViewRow row in GridView1.Rows)
            {
                entGuiaRem.columna1 = row.Cells[0].Text;
                entGuiaRem.columna2 = row.Cells[1].Text;
                entGuiaRem.columna3 = Convert.ToDecimal(row.Cells[2].Text);
                entGuiaRem.columna4 = Convert.ToInt32(row.Cells[3].Text);

                LogicaGuiaRemision.CreateGuiaRemision(entGuiaRem);
            }
        }
        protected void DeleteDetalleGuiaRemision(object sender, GridViewDeleteEventArgs e)
        {
            EntidadGuiaRemision entGuiaRem = new EntidadGuiaRemision();
            entGuiaRem.columna1 = GridView1.Rows[e.RowIndex].Cells[0].Text;
            LogicaGuiaRemision.DeleteGuiaRemision(entGuiaRem);
            MostrarDetalleGuiaRemision();
        }
        private void MostrarDetalleGuiaRemision()
        {
            GridView1.DataSource = LogicaGuiaRemision.ReadGuiaRemision();
            GridView1.DataBind();
        }
    }
}