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
    public partial class frmClienteEmpresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadClienteEmpresa entCliemp = new EntidadClienteEmpresa();
            entCliemp.ruc_cliente = txtruc.Text;
            entCliemp.cod_persona = 2;
            entCliemp.razon_social = txtRazon_social.Text;
            entCliemp.razon_comercial = txtRazon_comercial.Text;
            entCliemp.direccion = txtDireccion.Text;
            entCliemp.telefono = txtTelefono.Text;
            entCliemp.email = txtEmail.Text;
            entCliemp.contacto = txtContacto.Text;
            entCliemp.dni_vendedor = "";
            if (txtRazon_social.Text.Trim().Length == 0 || txtruc.Text.Trim().Length == 0)
            {
                return;
            }
            else
            {
                LogicaClienteEmpresa.InsertClienteEmpresa(entCliemp);
                BindClientesEmpresas();
            }

        }
        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/frmMenu.aspx");
        }


        protected void ModificarClienteEmpresa(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;

            TextBox Textrazonsocial = (TextBox)row.FindControl("txtrazonsocial");
            TextBox Textrazoncomercial = (TextBox)row.FindControl("txtrazoncomercial");
            TextBox Textdireccion = (TextBox)row.FindControl("txtdireccion");
            TextBox Texttelefono = (TextBox)row.FindControl("txttelefono");
            TextBox Textemail = (TextBox)row.FindControl("txtemail");
            TextBox Textcontacto = (TextBox)row.FindControl("txtcontacto");

            EntidadClienteEmpresa entCliemp = new EntidadClienteEmpresa();
            entCliemp.ruc_cliente = row.Cells[0].Text;
            entCliemp.cod_persona = 2;
            entCliemp.razon_social = Textrazonsocial.Text;
            entCliemp.razon_comercial = Textrazoncomercial.Text;
            entCliemp.direccion = Textdireccion.Text;
            entCliemp.telefono = Texttelefono.Text;
            entCliemp.email = Textemail.Text;
            entCliemp.contacto = Textcontacto.Text;
            entCliemp.dni_vendedor = "";

            LogicaClienteEmpresa.UpdateClienteEmpresa(entCliemp);
            BindClientesEmpresas();
        }

        protected void BuscarClienteEmpresa(object sender, EventArgs e)
        {
            BindClientesEmpresas();
        }
        private void BindClientesEmpresas()
        {
            grdClientesEmpresas.DataSource = LogicaClienteEmpresa.ListClienteEmpresa(txtruc.Text);
            grdClientesEmpresas.DataBind();
        }

    }
}