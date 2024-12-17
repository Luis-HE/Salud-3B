using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaEntidad;
using CapaLogicaNegocio;
using System.IO;
using System.Drawing;

namespace CapaPresentacion.Forms
{
    public partial class frmProveedor : System.Web.UI.Page
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
            if (txtRazon_social.Text.Trim().Length == 0 || txtRuc_proveedor.Text.Trim().Length == 0)
            {
                return;
            }
            else
            {
                LogicaProveedor.CreateProveedor(entProv);
                BindProveedor();
            }
        }
        protected void ModificarProveedor(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            TextBox txtRazonsocial = (TextBox)row.FindControl("txtRazonsocial");
            TextBox txtrazoncomercial = (TextBox)row.FindControl("txtrazoncomercial");
            TextBox txtdireccion = (TextBox)row.FindControl("txtdireccion");
            TextBox txtemail = (TextBox)row.FindControl("txtemail");
            TextBox txttelefono = (TextBox)row.FindControl("txttelefono");
            TextBox txtrepresentante = (TextBox)row.FindControl("txtrepresentante");            

            EntidadProveedor entProv = new EntidadProveedor();
            entProv.ruc_proveedor = row.Cells[0].Text;
            entProv.razon_social = txtRazonsocial.Text;
            entProv.razon_comercial = txtrazoncomercial.Text;
            entProv.direccion = txtdireccion.Text;
            entProv.telefono = txttelefono.Text;
            entProv.email = txtemail.Text;
            entProv.representante = txtrepresentante.Text;
            entProv.cod_persona_pago = 2;
            entProv.numero_cuenta = "";
            entProv.nombre_banco = "";

            LogicaProveedor.UpdateProveedor(entProv);
        }
        private void BindProveedor()
        {
            grdProveedores.DataSource = LogicaProveedor.ReadProveedor(txtRuc_proveedor.Text);
            grdProveedores.DataBind();
        }
        protected void Listarproveedores(object sender, EventArgs e)
        {
            grdReporteProveedores.DataSource = LogicaProveedor.ReadProveedor();
            grdReporteProveedores.DataBind();
        }
        protected void ExportarExcel(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=ListadeProveedores.xls");//ojo revisar solo funciona con .XLS
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                grdReporteProveedores.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in grdReporteProveedores.HeaderRow.Cells)
                {
                    cell.BackColor = grdReporteProveedores.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in grdReporteProveedores.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = grdReporteProveedores.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = grdReporteProveedores.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                grdReporteProveedores.RenderControl(hw);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        protected void CerrarPantalla(object sender, EventArgs e)
        {
            Response.Redirect("~/frmMenu.aspx");
        }
    }
}