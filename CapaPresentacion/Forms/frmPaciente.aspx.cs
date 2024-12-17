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
    public partial class frmPaciente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BuscarClientePersona(object sender, EventArgs e)
        {
            BindClientePersonas();
        }
         private void BindClientePersonas()
        {
            grdClientePersonas.DataSource = LogicaClientePersona.ListClientePersona(txtDni_cliente.Text);
            grdClientePersonas.DataBind();
        }
        protected void ModificarPaciente(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            TextBox txtapaterno = (TextBox)row.FindControl("txtapaterno");
            TextBox txtamaterno = (TextBox)row.FindControl("txtamaterno");
            TextBox txtnombres = (TextBox)row.FindControl("txtnombres");
            TextBox txttelefono = (TextBox)row.FindControl("txttelefono");
            TextBox txtemail = (TextBox)row.FindControl("txtemail");
            TextBox txtcelular = (TextBox)row.FindControl("txtcelular");
            TextBox txtgenero = (TextBox)row.FindControl("txtgenero");
            TextBox txtdirecion = (TextBox)row.FindControl("txtdirecion");
            TextBox txtGrupoSang = (TextBox)row.FindControl("txtGrupoSang");
            TextBox txtfechanace = (TextBox)row.FindControl("txtfechanace");

            EntidadClientePersona entCp = new EntidadClientePersona();
            entCp.num_doc_cliente = row.Cells[0].Text;
            entCp.apellido_paterno = txtapaterno.Text;
            entCp.apellido_materno = txtamaterno.Text;
            entCp.nombres = txtnombres.Text;
            entCp.telefono1 = txttelefono.Text;
            entCp.email = txtemail.Text;
            entCp.telefono2 = txtcelular.Text;
            entCp.genero = txtgenero.Text;
            entCp.direccion = txtdirecion.Text;
            entCp.grupo_sanguineo = txtGrupoSang.Text;
            entCp.fecha_nace = txtfechanace.Text;
            LogicaClientePersona.UpdateClientePersona(entCp);
            BindClientePersonas();
        }
        protected void ListarPacientes(object sender, EventArgs e)
        {
            grdReportedePacientes.DataSource =  LogicaClientePersona.ListClientePersona();
            grdReportedePacientes.DataBind();
        }
        protected void ExportarExcel(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=ListadePacientes.xls");//ojo revisar solo funciona con .XLS
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                grdReportedePacientes.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in grdReportedePacientes.HeaderRow.Cells)
                {
                    cell.BackColor = grdReportedePacientes.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in grdReportedePacientes.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = grdReportedePacientes.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = grdReportedePacientes.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                grdReportedePacientes.RenderControl(hw);
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