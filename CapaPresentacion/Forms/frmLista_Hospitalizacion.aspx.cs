using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion.Forms
{
    public partial class frmLista_Hospitalizacion : System.Web.UI.Page
    {
         
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                grdHospitalizados.DataSource = null;   
                grdHospitalizados.DataBind();
            }
        }
    }
}