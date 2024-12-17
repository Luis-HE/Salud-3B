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
    public partial class frmListar_Medicos_Referentes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                grdMedicosReferentes.DataSource = null;
                grdMedicosReferentes.DataBind();
            }

        }
        protected void BuscarMedico(object sender, EventArgs e)
        {
            grdMedicosReferentes.DataSource = LogicaMedicoReferente.ListMedicoReferente(txtBuscaApelPaterno.Text) ;
            grdMedicosReferentes.DataBind();
        }
    }
}