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
    public partial class frmAsientosContables : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                txtPeriodo.Text = DateTime.Now.Year.ToString();
            }
        }
        protected void ListarAsientos(object sender, EventArgs e)
        {
            grdAsientosContables.DataSource = LogicaReporteAsientosContables.ListReporteAsientosContables(drpMes.SelectedItem.Text,Convert.ToInt32(txtPeriodo.Text),txtRucDni.Text);
            grdAsientosContables.DataBind();
        }
        protected void CerrarAsiento(object sender, EventArgs e)
        {
            Response.Redirect("~/frmMenu.aspx");
        }
    }
}