using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using CapaEntidad;
using CapaLogicaNegocio;

namespace CapaPresentacion.Forms
{
    public partial class frmEspecialidades : System.Web.UI.Page
    {
        public static string num_historia_clin;
        public static string num_doc_cliente;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetGridView();

                drpEspecialidad.DataSource = LogicaEspecialidad.ListEspecialidad();
                drpEspecialidad.DataValueField = "cod_especialidad";
                drpEspecialidad.DataTextField = "nom_especialidad";
                drpEspecialidad.DataBind();
            }
        }
        private void SetGridView()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Col1", typeof(string)));
            dt.Columns.Add(new DataColumn("Col2", typeof(string)));
            dt.Columns.Add(new DataColumn("Col3", typeof(string)));
            dt.Columns.Add(new DataColumn("Col4", typeof(string)));

            ViewState["CurrentTable"] = dt;
            grdDiagnosticos.DataSource = dt;
            grdDiagnosticos.DataBind();
        }
        protected void CreateNewRowGrid()
        {
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                for (int i = 0; i <= dtCurrentTable.Rows.Count; i++)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["Col1"] = i + 1;
                    drCurrentRow["Col2"] = txtCod_ciediez.Text;
                    drCurrentRow["Col3"] = txtNombre_ciediez.Text;
                    drCurrentRow["Col4"] = drpTipoDiagnostico.SelectedItem.Text;

                }
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;
                grdDiagnosticos.DataSource = dtCurrentTable;
                grdDiagnosticos.DataBind();
            }
        }
        protected void CargarItemsDiagnostico(object sender, EventArgs e)
        {
            if (txtCod_ciediez.Text.Trim().Length == 0)
            {
                return;
            }
            else
            {
                CreateNewRowGrid();
                //clean fields
                txtCod_ciediez.Text = "";
                txtNombre_ciediez.Text = "";
            }
        }
        protected void BorrarFila(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvRow = (GridViewRow)btn.NamingContainer;
            int rowID = gvRow.RowIndex;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    //Remove the Selected Row data and reset row number  
                    dt.Rows.Remove(dt.Rows[rowID]);
                    ResetRowID(dt);
                }
                dt.AcceptChanges();
                //Store the current data in ViewState for future reference
                ViewState["CurrentTable"] = dt;
                //Re bind the GridView for the updated data  
                grdDiagnosticos.DataSource = dt;
                grdDiagnosticos.DataBind();
            }
        }
        private void ResetRowID(DataTable dt)
        {
            int rowNumber = 1;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    row[0] = rowNumber;
                    rowNumber++;
                }
            }
        }
        protected void BuscaPacientesAdmitidos(object sender, EventArgs e)
        {
            BuscarPacientes();
        }
        protected void BuscarPacientes()
        {
            grdListaPacientesAdmitidos.DataSource = LogicaModeloBuscaPacAdmitido.BuscarPacientesAdmitidosConsultorio(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, Convert.ToInt32(drpEspecialidad.SelectedItem.Value));
            grdListaPacientesAdmitidos.DataBind();
        }
        protected void SelecionarRegistro(object sender, EventArgs e)
        {
            LinkButton btnSelect = (sender as LinkButton);
            GridViewRow row = (btnSelect.NamingContainer as GridViewRow);
            lblNumeroAdmision.Text = row.Cells[1].Text;
            num_historia_clin = row.Cells[2].Text;
            num_doc_cliente = row.Cells[3].Text;
            //trayendo datos generales del paciente
            txtTriajeNombres.Text = row.Cells[4].Text;
            txtTriajeSexo.Text = row.Cells[8].Text;
            txtTriajeEdad.Text = row.Cells[12].Text;
            txtTriajeGrupoEtnico.Text = row.Cells[9].Text;
            txtTrijaeFechaNace.Text = row.Cells[5].Text;
            txtProcedencia.Text = "";
            txtIdAcompanante.Text = row.Cells[13].Text;
            txtTriajeAcompanante.Text = row.Cells[14].Text;
            txtGrupoSanguineo.Text = row.Cells[11].Text;
            txttalla.Text = row.Cells[15].Text;
            txtPeso.Text = row.Cells[16].Text;
            txtPresionArterialSistolica.Text = row.Cells[17].Text;
            txtPresionArterialDiastolica.Text = row.Cells[18].Text;
            txtRitmoCardiaco.Text = row.Cells[19].Text;
            txtTemperatura.Text = row.Cells[20].Text;
            txtIMC.Text = row.Cells[21].Text;
            txtFR.Text = row.Cells[22].Text;
            txtSPO.Text = row.Cells[23].Text;

        }
        protected void GuardarConsulta(object sender, EventArgs e)
        {
            Entidad_HC_DG_DIAGNOSTICO entDiagnostico = new Entidad_HC_DG_DIAGNOSTICO();

            //================Oftalmologia ==========================
            Entidad_HC_CE_OFTALMOLOGIA ent = new Entidad_HC_CE_OFTALMOLOGIA();
            ent.id_oftalmologia = Convert.ToInt32(lblNumeroAdmision.Text);
            ent.numero_historia_clinica = num_historia_clin;
            ent.numero_doc_cliente = num_doc_cliente;
            ent.codigo_persona = 1;
            ent.numero_admision = Convert.ToInt32(lblNumeroAdmision.Text);
            ent.fecha_registro = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            ent.hora_registro = DateTime.Now.ToString("HH:mm");
            ent.edad = Convert.ToInt32(txtTriajeEdad.Text);
            ent.motivo_consulta = txtMotivoConsulta.Text;
            ent.tiempo_enfermedad = txtTiempoEnfermedad.Text;
            ent.agudeza_vusal_lejos_vod = txtagudezaLejosVod.Text;
            ent.agudeza_vusal_lejos_vos = txtAgudezaLejosVos.Text;
            ent.agudeza_vusal_cerca_vod = txtagudezaCercaVod.Text;
            ent.agudeza_vusal_cerca_vos = txtagudezaCercaVos.Text;
            ent.examen_externo_od = txtexamenOd.Text;
            ent.examen_externo_os = txtExamenOs.Text;
            ent.antecedentes = txtAntecedentes.Text;
            ent.medios_transparentes_oculares = txtMediosTrnasparentes.Text;
            ent.motilidad_ocular = txtMotilidadocular.Text;
            ent.tonometria_ocular_bidigital = txtTonometriaBidigital.Text;
            ent.tonometria_ocular_schoitz = txtTonometriaSchoitz.Text;
            ent.tonometria_ocular_goldman = txtTonometriaGoldman.Text;
            ent.fondo_ojo_od = txtFondoOjoder.Text;
            ent.fondo_ojo_oi = txtFondoOjoizq.Text;
            ent.cod_cie_diez = txtCod_ciediez.Text;
            ent.indicaciones = txtIndicaciones.Text;
            ent.tratamiento = txtTratamiento.Text;
            ent.dni_empleado = txtDni_empleado.Text;
            ent.codigo_persona_pago = 1;

            //===================Cirugia AMBULATORIA ===============
            Entidad_HC_CE_CIRUGIA_AMBULATORIA entCir = new Entidad_HC_CE_CIRUGIA_AMBULATORIA();
            entCir.id_cirugia_ambulatoria = Convert.ToInt32(lblNumeroAdmision.Text);
            entCir.numero_historia_clinica = num_historia_clin;
            entCir.numero_doc_cliente = num_doc_cliente;
            entCir.codigo_persona = 1;
            entCir.numero_admision = Convert.ToInt32(lblNumeroAdmision.Text);
            entCir.fecha_atencion = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            entCir.hora_atencion = DateTime.Now.ToString("HH:mm");
            entCir.anamnesis = txtCirAnannesis.Text;
            entCir.antecedentes = txtCirAntecedentes.Text;
            entCir.examen_fisico = txtCirExamenFisico.Text;
            entCir.desarrollo_psicomotor = txtCirDesarrolloPsicomotor.Text;
            entCir.examenes = txtCirExamenes.Text;
            entCir.cod_cie_diez = txtCod_ciediez.Text;
            entCir.tratamiento = txtCirTratamiento.Text;
            entCir.operacion = txtCirOperacion.Text;
            entCir.indicaciones = txtCirIndicaciones.Text;
            entCir.evolucion_postoperatoria = txtCirEvolucionPost.Text;
            entCir.indicaciones_alta = txtCirIndicacionesAlta.Text;
            entCir.dni_empleado = txtDni_empleado.Text;
            entCir.codigo_persona_pago = 1;
           

            if (TabContainer1.ActiveTabIndex==0)
            {
                if (lblNumeroAdmision.Text.Trim().Length == 0)
                {
                    return;
                }
                else
                {
                    if (grdDiagnosticos.Rows.Count == 0)
                    {
                        return;
                    }
                    else
                    {
                        Logica_HC_CE_OFTALMOLOGIA.InserOftalmologia(ent);
                        LogicaModeloBuscaPacAdmitido.ActualizaEstadoAdmision(Convert.ToInt32(lblNumeroAdmision.Text));
                    }

                }
            }
            else if (TabContainer1.ActiveTabIndex == 1)
            {
                if (lblNumeroAdmision.Text.Trim().Length == 0)
                {
                    return;
                }
                else
                {
                    if (grdDiagnosticos.Rows.Count == 0)
                    {
                        return;
                    }
                    else
                    {
                        Logica_HC_CE_CIRUGIA_AMBULATORIA.InsertarCirugiaAmbulatoria(entCir);
                        LogicaModeloBuscaPacAdmitido.ActualizaEstadoAdmision(Convert.ToInt32(lblNumeroAdmision.Text));
                    }

                }
            }
            else
            {
                return;
            }
            //insertando los DIAGNOSTICOS
            foreach (GridViewRow row in grdDiagnosticos.Rows)
            {
                entDiagnostico.id_diagnostico = Convert.ToInt32(lblNumeroAdmision.Text);
                entDiagnostico.numero_historia_clinica = num_historia_clin;
                entDiagnostico.numero_doc_cliente = num_doc_cliente;
                entDiagnostico.codigo_persona = 1;
                entDiagnostico.cod_cie_diez = row.Cells[1].Text;
                entDiagnostico.codigo_especialidad = Convert.ToInt32(drpEspecialidad.SelectedItem.Value);
                entDiagnostico.descripcion_diagnostico = row.Cells[2].Text;
                entDiagnostico.fecha_registro = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                entDiagnostico.hora_registro = DateTime.Now.ToString("HH:mm");
                entDiagnostico.dni_empleado = txtDni_empleado.Text;
                entDiagnostico.codigo_persona_pago = 1;
                entDiagnostico.tipo_diagnostico = row.Cells[3].Text;
                Logica_HC_DG_DIAGNOSTICO.InsertarDiagnostico(entDiagnostico);
            }
            lblMsj.Text = "¡registro exitoso!";

        }
        protected void Limpiar(object sender, EventArgs e)
        {
            CleanFields();
            ////refrescar la lista
            BuscarPacientes();
        }
        private void CleanFields()
        {
            //=============OFTALMOLOGIA====================
             txtMotivoConsulta.Text="";
             txtTiempoEnfermedad.Text="";
             txtagudezaLejosVod.Text="";
             txtAgudezaLejosVos.Text="";
             txtagudezaCercaVod.Text="";
             txtagudezaCercaVos.Text="";
             txtexamenOd.Text="";
             txtExamenOs.Text="";
             txtAntecedentes.Text="";
             txtMediosTrnasparentes.Text="";
             txtMotilidadocular.Text="";
             txtTonometriaBidigital.Text="";
             txtTonometriaSchoitz.Text="";
             txtTonometriaGoldman.Text="";
             txtFondoOjoder.Text="";
             txtFondoOjoizq.Text="";
             txtCod_ciediez.Text="";
             txtIndicaciones.Text="";
             txtTratamiento.Text="";

            //================CIRUGIA===========================
             txtCirAnannesis.Text="";
             txtCirAntecedentes.Text="";
             txtCirExamenFisico.Text="";
             txtCirDesarrolloPsicomotor.Text="";
             txtCirExamenes.Text="";
             txtCod_ciediez.Text="";
             txtCirTratamiento.Text="";
             txtCirOperacion.Text="";
             txtCirIndicaciones.Text="";
             txtCirEvolucionPost.Text="";
             txtCirIndicacionesAlta.Text="";

            txtCod_ciediez.Text = "";
            txtNombre_ciediez.Text = "";
            grdDiagnosticos.DataSource = null;
            grdDiagnosticos.DataBind();

        }
        protected void CerrarPantalla(object sender, EventArgs e)
        {
            Response.Redirect("~/frmMenu.aspx");
        }
    }
}