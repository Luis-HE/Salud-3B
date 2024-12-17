using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion.Forms
{
    public partial class frmPedido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CerrarPedido(object sender, EventArgs e)
        {
            Response.Redirect("~/frmMenu.aspx");
        }
    }
}