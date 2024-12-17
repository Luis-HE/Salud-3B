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
    public partial class frmParametrosArtProd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void GuardarUnidadMedida(object sender, EventArgs e)
        {
            EntidadUnidadMedida entUnid = new EntidadUnidadMedida();
            //entUnid.cod_unidad_medida = 1;
            entUnid.siglas = txt_siglas.Text;
            entUnid.nombre_medida = txtdesc_unidadMed.Text;
            entUnid.cod_unidad_sunat = "";
            if(txtdesc_unidadMed.Text.Trim().Length==0)
            {
                return;
            }
            else
            {
                LogicaUnidadMedida.CreateUnidadMedida(entUnid);
                lblmesjUnMed.Text = "Ok";
            }
            
        }
         
    }
}