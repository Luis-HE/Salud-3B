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
    public partial class frmPersonal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             
        }
        protected void GuardarEmpleado(object sender, EventArgs e)
        {
            EntidadEmpleado entEmp = new EntidadEmpleado();
            entEmp.dni_empleado = txtDni.Text;
            entEmp.apellidos = txtApellidos.Text;
            entEmp.nombres = txtNombres.Text;
            entEmp.cod_area = 2;
            entEmp.telefono = txtTelefono.Text;
            entEmp.celular = txtCelular.Text;
            entEmp.email = txtEmail.Text;
            entEmp.cod_personaPago = 1;
            entEmp.num_cuenta = "";
            entEmp.nombre_banco = "";
            entEmp.porcentaje_comision = 0;
            entEmp.num_ruc = "";
            entEmp.tipo_contrato = "Planilla"; 
            if(txtDni.Text.Trim().Length==0 || txtApellidos.Text.Trim().Length==0 || txtNombres.Text.Trim().Length==0)
            {
                return;
            }
            else
            {
                LogicaEmpleado.InsertEmpleado(entEmp);
                btnGuardarEmpleado.Enabled = false;
                lblMsj.Text = "Ok";
                BindEmpleados();
            }
            
        }
        private void BindEmpleados()
        {
            grdEmpleados.DataSource = LogicaEmpleado.ListEmpleados();
            grdEmpleados.DataBind();
        }
        protected void ListarEmpleado(object sender, EventArgs e)
        {
            BindEmpleados();
        }
        protected void ModificarPersonal(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            TextBox txtApellidos = (TextBox)row.FindControl("txtApellidos");
            TextBox txtNombres = (TextBox)row.FindControl("txtNombres");
            TextBox txtTelefono = (TextBox)row.FindControl("txtTelefono");
            TextBox txtCelular = (TextBox)row.FindControl("txtCelular");
            TextBox txtEmail = (TextBox)row.FindControl("txtEmail");           
   
            EntidadEmpleado entEmp = new EntidadEmpleado();
            entEmp.dni_empleado = row.Cells[0].Text;
            entEmp.apellidos = txtApellidos.Text;
            entEmp.nombres = txtNombres.Text; 
            entEmp.telefono = txtTelefono.Text;
            entEmp.celular = txtCelular.Text;
            entEmp.email = txtEmail.Text;
            LogicaEmpleado.UpdateEmpleado(entEmp);
            BindEmpleados();
        }
        protected void CerrarPantalla(object sender, EventArgs e)
        {
            Response.Redirect("~/frmMenu.aspx");
        }
    }
}