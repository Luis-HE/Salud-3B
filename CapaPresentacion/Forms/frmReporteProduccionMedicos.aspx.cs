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
    public partial class frmReporteProduccionMedicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                drpUnidadNegocio.DataSource = LogicaUnidadNegocio.ReadUnidadNegocio();
                drpUnidadNegocio.DataValueField = "id_unidad_negocio";
                drpUnidadNegocio.DataTextField = "nombre_unid_negocio";
                drpUnidadNegocio.DataBind();
            }
        }
        protected void ListarReporte(object sender, EventArgs e)
        {
            grdReporteMedicos.DataSource = LogicaReporteProduccionMedicos.ListarReportexDNI(txtDni_empleado.Text);
            grdReporteMedicos.DataBind();
        }
        protected void CerrarPantalla(object sender, EventArgs e)
        {
            Response.Redirect("~/frmMenu.aspx");
        }
    }
}