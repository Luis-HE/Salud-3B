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
    public partial class frmTopico : System.Web.UI.Page
    {
        public static int Numero_admision;
        public static string numero_dni;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ListarPacientesAdmitidos();
            }
        }
        private void ListarPacientesAdmitidos()
        {
            grdAdmitidos.DataSource = LogicaModeloBuscaPacAdmitido.BuscarPacientesAdmitidosEmergencia(DateTime.Now.Day,DateTime.Now.Month, DateTime.Now.Year);
            grdAdmitidos.DataBind();
        }
        protected void RefrescarGridview(object sender, EventArgs e)
        {
            ListarPacientesAdmitidos();
        }
        protected void SelecionarRegistro(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;

            lblNumHistoria.Text = row.Cells[3].Text;
            Numero_admision = Convert.ToInt32(row.Cells[1].Text);
            numero_dni = row.Cells[4].Text;
        }
        protected void GuardarAtencionEmergencia(object sender, EventArgs e)
        {
            
            Entidad_HC_EM_ATENCION_EMERGENCIA ent = new Entidad_HC_EM_ATENCION_EMERGENCIA();
            ent.id_atencion_emergencia = Numero_admision;
            ent.numero_historia_clinica = lblNumHistoria.Text;
            ent.numero_doc_cliente = numero_dni;
            ent.codigo_persona = 1;
            ent.dni_empleado = txtDni_empleado.Text;
            ent.codigo_persona_pago = 1;
            ent.numero_admision = Numero_admision;
            ent.fecha_atencion = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            ent.hora_atencion = DateTime.Now.ToString("HH:mm");
            ent.filiacion = txtFiliacion.Text;
            ent.anamnesis_enfermedad_actual = txtAnamnesis.Text;
            ent.antecedentes = txtAntecedentes.Text;
            ent.examen_fisico = txtExamenFisico.Text;
            ent.id_consentimiento_informado = Convert.ToInt32(txtIdConsentimientoInformado.Text);
            ent.id_autoriza_procedimiento_quirurgico = Convert.ToInt32(txtIdAutorizacionProcedimiento.Text);
            ent.examenes_auxiliares = txtExamenesAuxiliares.Text;
            ent.diagnostico_presuntivo = txtDiagnosticoPresuntivo.Text;
            ent.plan_trabajo = txtPlanTrabajo.Text;
            ent.terapeutica_seguimiento = txtTerapeutica.Text;
            ent.epicrisis_resumen_historia = txtEpicrisis.Text;
            ent.id_materno_perinatal = Convert.ToInt32(txtIdHostoriaPerinatal.Text);
            ent.id_partograma = Convert.ToInt32(txtIdPartograma.Text);
            ent.prioridad = drpPrioridad.SelectedItem.Text;
            if (lblNumHistoria.Text.Trim().Length==0 || txtDni_empleado.Text.Trim().Length==0)
            {
                return;
            }
            else
            {
                Logica_HC_EM_ATENCION_EMERGENCIA.CreateATENCION_EMERGENCIA(ent);
                lblMsj.Text = "¡registro exitoso!";
                CleanFields();
            }
            ListarPacientesAdmitidos();
        }
        private void CleanFields()
        {
            lblNumHistoria.Text = "";
            txtFiliacion.Text = "";
            txtAnamnesis.Text = "";
            txtAntecedentes.Text = "";
            txtExamenFisico.Text = "";
            txtIdConsentimientoInformado.Text = "0";
            txtIdAutorizacionProcedimiento.Text = "0";
            txtExamenesAuxiliares.Text = "";
            txtDiagnosticoPresuntivo.Text = "";
            txtPlanTrabajo.Text = "";
            txtTerapeutica.Text = "";
            txtEpicrisis.Text = "";
            txtIdHostoriaPerinatal.Text = "0";
            txtNombreDocumentoHistoriaPerinatal.Text = "";
            txtIdPartograma.Text = "0";
            txtNombreDocumentoPartograma.Text = "";

        }
        protected void CerrarPantalla(object sender, EventArgs e)
        {
            Response.Redirect("~/frmMenu.aspx");
        }
    }
}