using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaEntidad;
using CapaLogicaNegocio;

namespace CapaPresentacion.Forms
{
    public partial class frmHospitalizacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                dtListCamas.DataSource = LogicaCama.ListCamas();
                dtListCamas.DataBind();                 
            }
             
        }
        protected void On_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            Button btnData = (Button)e.Item.FindControl("btnOcupar");
            Label lblestado = (Label)e.Item.FindControl("lblEstado");
            if (lblestado.Text == "Ocupado")
            {
                lblestado.BackColor = System.Drawing.Color.Red;
                btnData.Enabled = false;
            }
            else
            {
                lblestado.BackColor = System.Drawing.Color.Green;
            }
        }

        protected void GuardarHospitalizar(object sender, EventArgs e)
        {
            //DateTime fecha_hospitaliza = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"), new CultureInfo("es-ES"));
            //fecha_hospitaliza = fecha_hospitaliza.AddDays(Convert.ToInt32(txtCantidadDias.Text));
            //string fecha_alta = fecha_hospitaliza.ToString("dd/MM/yyyy");

            EntidadHospitalizacion entHospi = new EntidadHospitalizacion();
            //entHospi.id_registro_hospitalizacion = 0;
            entHospi.numero_historia_clinica = "";
            entHospi.numero_doc_cliente = "";
            entHospi.codigo_persona = 1;
            entHospi.tipo_movimiento = "";
            entHospi.fecha_ingreso_egreso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            entHospi.hora_ingreso_egreso = DateTime.Now.ToString("HH:mm");
            entHospi.origen_ingreso_egreso = "";
            entHospi.id_cama = 0;// Convert.ToInt32(hidIdCama.Value);
            entHospi.id_piso = 0;
            entHospi.edad = 0;
            entHospi.recien_nacido = false;
            entHospi.medico_autoriza_ingreso_egreso = "";
            entHospi.servicio_ingresa_egresa = "";
            entHospi.cod_cie_diez = txtCod_ciediez.Text;
            entHospi.id_reg_acompanante = 0;
            entHospi.destino_egreso = "";
            entHospi.tipo_alta = "";
            entHospi.condicion_alta = "";
            entHospi.numero_admision = 0;
            //entHospi.fecha_hospitaliza = + ' ' + ;
            //entHospi.fecha_alta = fecha_alta;
            //entHospi.dni_empleado = txtDni_empleado.Text;
            //entHospi.cod_persona_pago = Convert.ToInt32(txtCodPersona_pago.Text);
            //entHospi.dni_medico_opera = txtdniMedOpera.Text;
            //entHospi.nom_medico_opera = txtNomMedOpera.Text;
            //entHospi.razon_admision = txtRazonHospitaliza.Text;
            //entHospi.observacion = txtObservacion.Text;            
            //entHospi.estado_registro = "Activo";

            LogicaHospitalizacion.InsertHospitalizacion(entHospi);
            lblMsj.Text = "¡registro exitoso!";

            //Ocupar la CAMA despues de guardar el registro
        }
        protected void CerrarHospitalizar(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
        }
        protected void OpenHospitalizar(object sender, EventArgs e)
        {
            //ImageButton imgButon = sender as ImageButton;
            //GridViewRow gRow = (GridViewRow)imgButon.NamingContainer;
            //lblDniPaciente.Text = gRow.Cells[0].Text;
            ModalPopupExtender1.Show();
        }
        protected void CerrarPantallaHospitalizacion(object sender, EventArgs e)
        {
            Response.Redirect("~/frmMenu.aspx");
        }
    }
}