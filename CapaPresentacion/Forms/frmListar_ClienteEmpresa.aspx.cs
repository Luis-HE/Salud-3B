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
    public partial class frmListar_ClienteEmpresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscarClienteEmpresa_Click(object sender, EventArgs e)
        {
            BindClienteEmpresa();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadClienteEmpresa entCliemp = new EntidadClienteEmpresa();
            entCliemp.ruc_cliente = txtRuc_cliente.Text;
            entCliemp.cod_persona = 2;
            entCliemp.razon_social = txtRazon_social.Text;
            entCliemp.razon_comercial = txtRazon_comercial.Text;
            entCliemp.direccion = txtDireccion.Text;
            entCliemp.telefono = txtTelefono.Text;
            entCliemp.email = txtEmail.Text;
            entCliemp.contacto = txtContacto.Text;
            entCliemp.dni_vendedor = "";
            if(txtRazon_social.Text.Trim().Length==0 || txtRuc_cliente.Text.Trim().Length==0)
            {
                return;
            }
            else
            {
                LogicaClienteEmpresa.InsertClienteEmpresa(entCliemp);
                BindClienteEmpresa();
            }
            
        }
        private void BindClienteEmpresa()
        {
            grdClienteEmpresas.DataSource = LogicaClienteEmpresa.ListClienteEmpresa(txtRuc_cliente.Text);
            grdClienteEmpresas.DataBind();
        }
    }
}