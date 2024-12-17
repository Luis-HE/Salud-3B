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
    public partial class frmEntrevistaMedica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindData();
            }
        }
        private void BindData()
        {
            grdListaPacientesAdmitidos.DataSource = LogicaModeloBuscaPacAdmitido.BuscarPacientesAdmitidosRadiologia(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            grdListaPacientesAdmitidos.DataBind();
        }
        
        protected void VerDetallesAdmision(object sender, EventArgs e)
        {
            
           
        }
        protected void GuardarEntrevistaMedica(object sender, EventArgs e)
        {

        }
        protected void CerrarEntrevista(object sender, EventArgs e)
        {
            Response.Redirect("~/frmMenu.aspx");
        }
    }
}