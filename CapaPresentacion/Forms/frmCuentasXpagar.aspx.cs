using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace CapaPresentacion.Forms
{
    public partial class frmCuentasXpagar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                OtherClasses.ClaseFunciones.FillMonths(drpMes);
            }
        }
        protected void ListarCompras(object sender, EventArgs e)
        {
            grdListaCompras.DataSource = null;
            grdListaCompras.DataBind();
        }
    }
    
}