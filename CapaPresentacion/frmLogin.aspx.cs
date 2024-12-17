using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaEntidad;
using CapaLogicaNegocio;
using System.Web.Security;

namespace CapaPresentacion
{
    public partial class frmLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            int rows = 1;//LogicaUsuario.ReadUsuario(txtnomUsuario.Text, txtClave.Text).Count;
            if (rows == 1)
            {
                Session["Username"] = txtnomUsuario.Text;
                Session["NivelAcceso"] = LogicaUsuario.ReadUsuario(txtnomUsuario.Text, txtClave.Text)[0].nivel_acceso;
                FormsAuthentication.RedirectFromLoginPage(txtnomUsuario.Text, true);
                Response.Redirect("~/frmMenu.aspx");
            }
            else
            {
                lblmessage.Text = "Error de datos de Usuario";
            }

        }
    }
}