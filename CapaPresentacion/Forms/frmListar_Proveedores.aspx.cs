using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaLogicaNegocio;
using CapaEntidad;

namespace CapaPresentacion.Forms
{
    public partial class frmListar_Proveedores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BuscarProveedores(object sender, EventArgs e)
        {
            BindProveedor();
        }
        protected void GuardarProveedor(object sender, EventArgs e)
        {
            EntidadProveedor entProv = new EntidadProveedor();
            entProv.ruc_proveedor = txtRuc_proveedor.Text;           
            entProv.razon_social = txtRazon_social.Text;
            entProv.razon_comercial = txtRazon_comercial.Text;
            entProv.direccion = txtDireccion.Text;
            entProv.telefono = txtTelefono.Text;
            entProv.email = txtEmail.Text;
            entProv.representante = txtContacto.Text;
            entProv.cod_persona_pago = 2;
            entProv.numero_cuenta = "";
            entProv.nombre_banco = "";
            if(txtRazon_social.Text.Trim().Length==0 || txtRuc_proveedor.Text.Trim().Length==0)
            {
                return;
            }
            else
            {
                LogicaProveedor.CreateProveedor(entProv);
                BindProveedor();
            }           

        }
        private void BindProveedor()
        {
            grdProveedores.DataSource = LogicaProveedor.ReadProveedor(txtRuc_proveedor.Text);
            grdProveedores.DataBind();
        }
    }
}