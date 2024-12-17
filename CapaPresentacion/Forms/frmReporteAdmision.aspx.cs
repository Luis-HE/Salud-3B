using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaLogicaNegocio;

namespace CapaPresentacion.Forms
{
    public partial class frmReporteAdmision : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void listarReporte(object sender, EventArgs e)
        {
            grdReporteAdmision.DataSource = LogicaReporte_Admision.ListarReporteAdmision(txtfecha1.Text + " 00:01", txtfecha2.Text + " 23:59");
            grdReporteAdmision.DataBind();

        }
        protected void CerrarPantalla(object sender, EventArgs e)
        {
            Response.Redirect("~/frmMenu.aspx");
        }
    }
}