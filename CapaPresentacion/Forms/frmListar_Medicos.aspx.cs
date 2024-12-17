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
    public partial class frmListar_Medicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                drpArea.DataSource = LogicaArea.ListArea();
                drpArea.DataValueField = "id_area";
                drpArea.DataTextField = "nombre_area";
                drpArea.DataBind();
            }
           
        }
        protected void BuscarEmpleado(object sender, EventArgs e)
        {
            grdMedicos.DataSource = LogicaEmpleado.ListEmpleados(Convert.ToInt32(drpArea.SelectedItem.Value));
            grdMedicos.DataBind();
        }
    }
}