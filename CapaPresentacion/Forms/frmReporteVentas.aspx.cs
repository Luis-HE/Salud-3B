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
    public partial class frmReporteVentas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void listarReporte(object sender, EventArgs e)
        {
            grdReporteVentas.DataSource = LogicaReporte_Ventas.ListarReporteVentas(txtfecha1.Text + " 00:01", txtfecha2.Text + " 23:59");
            grdReporteVentas.DataBind();
        }

        protected void CerrarPantalla(object sender, EventArgs e)
        {
            Response.Redirect("~/frmMenu.aspx");
        }
    }
}