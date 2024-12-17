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
    public partial class frmConsultorio : System.Web.UI.Page
    {
 
        public static string num_historia_clin;
        public static string num_doc_cliente;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetGridView();

                //drpEspecialidad.DataSource = LogicaEspecialidad.ListEspecialidad();
                //drpEspecialidad.DataValueField = "cod_especialidad";
                //drpEspecialidad.DataTextField = "nom_especialidad";
                //drpEspecialidad.DataBind();               
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
             num_historia_clin =  row.Cells[2].Text ;
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

        protected void GuardarConsultaExterna(object sender, EventArgs e)
        {
            Entidad_HC_CE_ATENCION_NINO entNino = new Entidad_HC_CE_ATENCION_NINO();
            Entidad_HC_CE_ATENCION_ADOLECENTE entAdolecente = new Entidad_HC_CE_ATENCION_ADOLECENTE();
            Entidad_HC_CE_ATENCION_JOVEN entJoven = new Entidad_HC_CE_ATENCION_JOVEN();
            Entidad_HC_CE_ATENCION_ADULTO entAdulto = new Entidad_HC_CE_ATENCION_ADULTO();
            Entidad_HC_CE_ATENCION_ADULTO_MAYOR entAdulMayor = new Entidad_HC_CE_ATENCION_ADULTO_MAYOR();

            Entidad_HC_DG_DIAGNOSTICO entDiagnostico = new Entidad_HC_DG_DIAGNOSTICO();

            //----------------atencion NIÑO--------------
            entNino.id_atencion_nino = Convert.ToInt32(lblNumeroAdmision.Text);
            entNino.numero_historia_clinica = num_historia_clin;
            entNino.numero_doc_cliente = num_doc_cliente;
            entNino.codigo_persona = 1;
            entNino.numero_admision = Convert.ToInt32(lblNumeroAdmision.Text);
            entNino.fecha_atencion = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            entNino.hora_atencion = DateTime.Now.ToString("HH:mm");
            entNino.grado_instruccion = NtxtGradoInstruccion.Text;
            entNino.id_reg_acompanante = Convert.ToInt32(txtIdAcompanante.Text);
            entNino.edad = Convert.ToInt32(txtTriajeEdad.Text);
            entNino.antecedentes_personales = NtxtAntecentePersonal.Text;
            entNino.antecedentes_familiares = NtxtAntecedenteFamiliar.Text;
            entNino.esquema_vacunacion = NtxtEsquemaVacunacion.Text;
            entNino.vigilancia_crecimiento_desarrollo = NtxtVigilanciaDesarrollo.Text;
            entNino.anamnesis = NtxtAnamnesis.Text;
            entNino.problemas_frecuentes_infancia = NtxtProblemasInfancia.Text;
            entNino.evaluacion_alimentacion_actual = NtxtEvaluacionAlimentacion.Text;
            entNino.examen_fisico = NtxtExamenFisico.Text;
            entNino.cod_cie_diez = txtCod_ciediez.Text;
            entNino.tratamiento = NtxtTratamiento.Text;
            entNino.examenes_auxiliares = NtxtExamenesAuxiliares.Text;
            entNino.referencia = NtxtReferencia.Text;
            entNino.fecha_proxima_cita = NtxtFechaProximaCita.Text;
            entNino.dni_empleado = txtDni_empleado.Text;
            entNino.codigo_persona_pago = 1;

            //----------------atencion ADOLECENTE--------------
            entAdolecente.id_atencion_adolecente = Convert.ToInt32(lblNumeroAdmision.Text);
            entAdolecente.numero_historia_clinica = num_historia_clin;
            entAdolecente.numero_doc_cliente = num_doc_cliente;
            entAdolecente.codigo_persona = 1;
            entAdolecente.numero_admision = Convert.ToInt32(lblNumeroAdmision.Text);
            entAdolecente.fecha_atencion = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            entAdolecente.hora_atencion = DateTime.Now.ToString("HH:mm");
            entAdolecente.edad = Convert.ToInt32(txtTriajeEdad.Text);
            entAdolecente.grado_instruccion = AtxtGradoInstruccion.Text;
            entAdolecente.centro_educativo = AtxtCentroEducativo.Text;
            entAdolecente.ocupacion = AtxtOcupacion.Text;
            entAdolecente.id_reg_acompanante = Convert.ToInt32(txtIdAcompanante.Text);
            entAdolecente.antecedentes_personales = AtxtAntecentePersonal.Text;
            entAdolecente.antecedentes_familiares = AtxtAntecedenteFamiliar.Text;
            entAdolecente.antecedentes_psicosociales = AtxtAntecednetePsicosocial.Text;
            entAdolecente.salud_sexual_reproductiva = AtxtSaludSexual.Text;
            entAdolecente.salud_bucal = AtxtSaludBucal.Text;
            entAdolecente.motivo_consulta = AtxtMotivoConsulta.Text;
            entAdolecente.tiempo_enfermedad = AtxtTiempoEnfermedad.Text;
            entAdolecente.funciones_biologicas = AtxtFuncionesBiologicas.Text;
            entAdolecente.evaluacion_antropometrica = AtxtEvaluacionAntropometrica.Text;
            entAdolecente.evaluacion_riesgo_cardiovascular = AtxtEvaluacionCardiovascular.Text;
            entAdolecente.funciones_vitales = AtxtFuncionesVitales.Text;
            entAdolecente.examen_fisico = AtxtExamenFisico.Text;
            entAdolecente.cod_cie_diez = txtCod_ciediez.Text;
            entAdolecente.tratamiento = AtxtTratamiento.Text;
            entAdolecente.examenes_auxiliares = AtxtExamenesAuxiliares.Text;
            entAdolecente.referencia = AtxtReferencia.Text;
            entAdolecente.fecha_proxima_cita = AtxtFechaProximaCita.Text;
            entAdolecente.dni_empleado = txtDni_empleado.Text;
            entAdolecente.codigo_persona_pago = 1;

            //----------------atencion JOVEN--------------
            entJoven.id_atencion_joven = Convert.ToInt32(lblNumeroAdmision.Text);
            entJoven.numero_historia_clinica = num_historia_clin;
            entJoven.numero_doc_cliente = num_doc_cliente;
            entJoven.codigo_persona = 1;
            entJoven.numero_admision = Convert.ToInt32(lblNumeroAdmision.Text);
            entJoven.fecha_atencion = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            entJoven.hora_atencion = DateTime.Now.ToString("HH:mm");
            entJoven.grado_instruccion = JtxtGradoInstruccion.Text;
            entJoven.ocupacion = JtxtOcupacion.Text;
            entJoven.id_reg_acompanante = Convert.ToInt32(txtIdAcompanante.Text);
            entJoven.antecedentes_personales = JtxtAntecentePersonal.Text;
            entJoven.antecedentes_familiares = JtxtAntecedenteFamiliar.Text;
            entJoven.antecedentes_psicosociales = JtxtAntecednetePsicosocial.Text;
            entJoven.salud_sexual_reproductiva = JtxtSaludSexual.Text;
            entJoven.salud_bucal = JtxtSaludBucal.Text;
            entJoven.motivo_consulta = JtxtMotivoConsulta.Text;
            entJoven.tiempo_enfermedad = JtxtTiempoEnfermedad.Text;
            entJoven.funciones_biologicas = JtxtFuncionesBiologicas.Text;
            entJoven.evaluacion_antropometrica = JtxtEvaluacionAntropometrica.Text;
            entJoven.evaluacion_riesgo_cardiovascular = JtxtEvaluacionCardiovascular.Text;
            entJoven.funciones_vitales = JtxtFuncionesVitales.Text;
            entJoven.examen_fisico = JtxtExamenFisico.Text;
            entJoven.cod_cie_diez = txtCod_ciediez.Text;
            entJoven.tratamiento = JtxtTratamiento.Text;
            entJoven.examenes_auxiliares = JtxtExamenesAuxiliares.Text;
            entJoven.referencia = JtxtReferencia.Text;
            entJoven.fecha_proxima_cita = JtxtFechaProximaCita.Text;
            entJoven.dni_empleado = txtDni_empleado.Text;
            entJoven.codigo_persona_pago = 1;

            //----------------atencion ADULTO--------------
            entAdulto.id_atencion_adulto = Convert.ToInt32(lblNumeroAdmision.Text);
            entAdulto.numero_historia_clinica = num_historia_clin;
            entAdulto.numero_doc_cliente = num_doc_cliente;
            entAdulto.codigo_persona = 1;
            entAdulto.numero_admision = Convert.ToInt32(lblNumeroAdmision.Text);
            entAdulto.fecha_atencion = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            entAdulto.hora_atencion = DateTime.Now.ToString("HH:mm");
            entAdulto.grado_instruccion = ADULtxtGradoInstruccion.Text;
            entAdulto.centro_educativo = ADULtxtCentroEducativo.Text;
            entAdulto.ocupacion = ADULtxtOcupacion.Text;
            entAdulto.antecedentes_personales = ADULtxtAntecentePersonal.Text;
            entAdulto.antecedentes_familiares = ADULtxtAntecedenteFamiliar.Text;
            entAdulto.alergia_medicamentos = ADULtxtAlergiaMedicamento.Text;
            entAdulto.sexualidad = ADULtxtSexualidad.Text;
            entAdulto.salud_bucal = ADULtxtSaludBucal.Text;
            entAdulto.motivo_consulta = ADULtxtMotivoConsulta.Text;
            entAdulto.tiempo_enfermedad = ADULtxtTiempoEnfermedad.Text;
            entAdulto.funciones_biologicas = ADULtxtFuncionesBiologicas.Text;
            entAdulto.examen_fisico = ADULtxtExamenFisico.Text;
            entAdulto.cod_cie_diez = txtCod_ciediez.Text;
            entAdulto.tratamiento = ADULtxtTratamiento.Text;
            entAdulto.examenes_auxiliares = ADULtxtExamenesAuxiliares.Text;
            entAdulto.referencia = ADULtxtReferencia.Text;
            entAdulto.fecha_proxima_cita = ADULtxtFechaProximaCita.Text;
            entAdulto.dni_empleado = txtDni_empleado.Text;
            entAdulto.codigo_persona_pago = 1;

            //----------------atencion ADULTO MAYOR--------------
            entAdulMayor.id_atencion_adulto_mayor = Convert.ToInt32(lblNumeroAdmision.Text);
            entAdulMayor.numero_historia_clinica = num_historia_clin;
            entAdulMayor.numero_doc_cliente = num_doc_cliente;
            entAdulMayor.codigo_persona = 1;
            entAdulMayor.numero_admision = Convert.ToInt32(lblNumeroAdmision.Text);
            entAdulMayor.fecha_atencion = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            entAdulMayor.hora_atencion = DateTime.Now.ToString("HH:mm");
            entAdulMayor.grado_instruccion = AMtxtGradoInstruccion.Text;
            entAdulMayor.ocupacion = AMtxtOcupacion.Text;
            entAdulMayor.id_reg_acompanante = Convert.ToInt32(txtIdAcompanante.Text);
            entAdulMayor.antecedentes_personales = AMtxtAntecentePersonal.Text;
            entAdulMayor.antecedentes_familiares = AMtxtAntecedenteFamiliar.Text;
            entAdulMayor.alergia_medicamentos = AMtxtAlergiaMedicamento.Text;
            entAdulMayor.medicamentos_frecuentes = AMtxtMedicamentoFrecuente.Text;
            entAdulMayor.reaccion_adversa_medicamentos = AMtxtReaccionMedicamento.Text;
            entAdulMayor.valoracion_clinica = AMtxtValoracionAdulto.Text;
            entAdulMayor.categorias_adulto_mayor = AMtxtCategoriaAdultoMayor.Text;
            entAdulMayor.salud_bucal = AMtxtSaludBucal.Text;
            entAdulMayor.motivo_consulta = AMtxtMotivoConsulta.Text;
            entAdulMayor.tiempo_enfermedad = AMtxtTiempoEnfermedad.Text;
            entAdulMayor.funciones_biologicas = AMtxtFuncionesBiologicas.Text;
            entAdulMayor.examen_fisico = AMtxtExamenFisico.Text;
            entAdulMayor.tratamiento = AMtxtTratamiento.Text;
            entAdulMayor.examenes_auxiliares = AMtxtExamenesAuxiliares.Text;
            entAdulMayor.referencia = AMtxtReferencia.Text;
            entAdulMayor.fecha_proxima_cita = AMtxtFechaProximaCita.Text;
            entAdulMayor.dni_empleado = txtDni_empleado.Text;
            entAdulMayor.codigo_persona_pago = 1;
            entAdulMayor.cod_cie_diez = txtCod_ciediez.Text;            

            if (TabContainer1.ActiveTabIndex==0)
            {
                if(lblNumeroAdmision.Text.Trim().Length==0)
                {
                    return;
                }
                else
                {
                    if(grdDiagnosticos.Rows.Count==0)
                    {
                        return;
                    }
                    else
                    {
                        Logica_HC_CE_ATENCION_NINO.CreateATENCION_NINO(entNino);                                  
                        LogicaModeloBuscaPacAdmitido.ActualizaEstadoAdmision(Convert.ToInt32(lblNumeroAdmision.Text));
                        
                    }
                    
                }
                
                
            }
            else if(TabContainer1.ActiveTabIndex == 1)
            {
                if (lblNumeroAdmision.Text.Trim().Length == 0)
                {
                    return;
                }
                else
                {
                    if(grdDiagnosticos.Rows.Count==0)
                    {
                        return;
                    }
                    else
                    {
                        Logica_HC_CE_ATENCION_ADOLECENTE.CreateATENCION_ADOLECENTE(entAdolecente);
                        LogicaModeloBuscaPacAdmitido.ActualizaEstadoAdmision(Convert.ToInt32(lblNumeroAdmision.Text));
                        
                    }
                    
                }
                
            }
            else if (TabContainer1.ActiveTabIndex == 2)
            {
                if (lblNumeroAdmision.Text.Trim().Length == 0)
                {
                    return;
                }
                else
                {
                    if(grdDiagnosticos.Rows.Count==0)
                    {
                        return;
                    }
                    else
                    {
                        Logica_HC_CE_ATENCION_JOVEN.CreateATENCION_JOVEN(entJoven);
                        LogicaModeloBuscaPacAdmitido.ActualizaEstadoAdmision(Convert.ToInt32(lblNumeroAdmision.Text));
                        
                    }
                    
                }
                
            }
            else if (TabContainer1.ActiveTabIndex == 3)
            {
                if (lblNumeroAdmision.Text.Trim().Length == 0)
                {
                    return;
                }
                {
                    if(grdDiagnosticos.Rows.Count==0)
                    {
                        return;
                    }
                    else
                    {
                        Logica_HC_CE_ATENCION_ADULTO.CreateATENCION_ADULTO(entAdulto);
                        LogicaModeloBuscaPacAdmitido.ActualizaEstadoAdmision(Convert.ToInt32(lblNumeroAdmision.Text));
                         
                    }
                    
                }
                
            }
            else if (TabContainer1.ActiveTabIndex == 4)
            {
                if (lblNumeroAdmision.Text.Trim().Length == 0)
                {
                    return;
                }
                else
                {
                    if(grdDiagnosticos.Rows.Count==0)
                    {
                        return;
                    }
                    else
                    {
                        Logica_HC_CE_ATENCION_ADULTO_MAYOR.CreateATENCION_ADULTO_MAYOR(entAdulMayor);
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
            txtTriajeNombres.Text = "";
            txtTriajeSexo.Text = "";
            txtTriajeEdad.Text = "";
            txtTriajeGrupoEtnico.Text = "";
            txtTrijaeFechaNace.Text = "";
            txtProcedencia.Text = "";
            txtIdAcompanante.Text = "";
            txtTriajeAcompanante.Text = "";
            txtGrupoSanguineo.Text = "";

            //-----niño(a)
            NtxtGradoInstruccion.Text = "";
            NtxtAntecentePersonal.Text = "";
            NtxtAntecedenteFamiliar.Text = "";
            NtxtEsquemaVacunacion.Text = "";
            NtxtVigilanciaDesarrollo.Text = "";
            NtxtAnamnesis.Text = "";
            NtxtProblemasInfancia.Text = "";
            NtxtEvaluacionAlimentacion.Text = "";
            NtxtExamenFisico.Text = "";
            NtxtTratamiento.Text = "";
            NtxtExamenesAuxiliares.Text = "";
            NtxtReferencia.Text = "";
            NtxtFechaProximaCita.Text = "";

            //-----adolecente
            AtxtGradoInstruccion.Text = "";
            AtxtCentroEducativo.Text = "";
            AtxtOcupacion.Text = "";
            AtxtAntecentePersonal.Text = "";
            AtxtAntecedenteFamiliar.Text = "";
            AtxtAntecednetePsicosocial.Text = "";
            AtxtSaludSexual.Text = "";
            AtxtSaludBucal.Text = "";
            AtxtMotivoConsulta.Text = "";
            AtxtTiempoEnfermedad.Text = "";
            AtxtFuncionesBiologicas.Text = "";
            AtxtEvaluacionAntropometrica.Text = "";
            AtxtEvaluacionCardiovascular.Text = "";
            AtxtFuncionesVitales.Text = "";
            AtxtExamenFisico.Text = "";
            AtxtTratamiento.Text = "";
            AtxtExamenesAuxiliares.Text = "";
            AtxtReferencia.Text = "";
            AtxtFechaProximaCita.Text = "";


            //------Joven
            JtxtGradoInstruccion.Text = "";
            JtxtOcupacion.Text = "";
            JtxtAntecentePersonal.Text = "";
            JtxtAntecedenteFamiliar.Text = "";
            JtxtAntecednetePsicosocial.Text = "";
            JtxtSaludSexual.Text = "";
            JtxtSaludBucal.Text = "";
            JtxtMotivoConsulta.Text = "";
            JtxtTiempoEnfermedad.Text = "";
            JtxtFuncionesBiologicas.Text = "";
            JtxtEvaluacionAntropometrica.Text = "";
            JtxtEvaluacionCardiovascular.Text = "";
            JtxtFuncionesVitales.Text = "";
            JtxtExamenFisico.Text = "";
            JtxtTratamiento.Text = "";
            JtxtExamenesAuxiliares.Text = "";
            JtxtReferencia.Text = "";
            JtxtFechaProximaCita.Text = "";

            //-----Adulto
            ADULtxtGradoInstruccion.Text = "";
            ADULtxtCentroEducativo.Text = "";
            ADULtxtOcupacion.Text = "";
            ADULtxtAntecentePersonal.Text = "";
            ADULtxtAntecedenteFamiliar.Text = "";
            ADULtxtAlergiaMedicamento.Text = "";
            ADULtxtSexualidad.Text = "";
            ADULtxtSaludBucal.Text = "";
            ADULtxtMotivoConsulta.Text = "";
            ADULtxtTiempoEnfermedad.Text = "";
            ADULtxtFuncionesBiologicas.Text = "";
            ADULtxtExamenFisico.Text = "";
            ADULtxtTratamiento.Text = "";
            ADULtxtExamenesAuxiliares.Text = "";
            ADULtxtReferencia.Text = "";
            ADULtxtFechaProximaCita.Text = "";

            //-----Adulto mayor
            AMtxtGradoInstruccion.Text = "";
            AMtxtOcupacion.Text = "";
            AMtxtAntecentePersonal.Text = "";
            AMtxtAntecedenteFamiliar.Text = "";
            AMtxtAlergiaMedicamento.Text = "";
            AMtxtMedicamentoFrecuente.Text = "";
            AMtxtReaccionMedicamento.Text = "";
            AMtxtValoracionAdulto.Text = "";
            AMtxtCategoriaAdultoMayor.Text = "";
            AMtxtSaludBucal.Text = "";
            AMtxtMotivoConsulta.Text = "";
            AMtxtTiempoEnfermedad.Text = "";
            AMtxtFuncionesBiologicas.Text = "";
            AMtxtExamenFisico.Text = "";
            AMtxtTratamiento.Text = "";
            AMtxtExamenesAuxiliares.Text = "";
            AMtxtReferencia.Text = "";
            AMtxtFechaProximaCita.Text = "";

            txtCod_ciediez.Text = "";
            txtNombre_ciediez.Text = "";
            grdDiagnosticos.DataSource = null;
            grdDiagnosticos.DataBind();
        }
        protected void CargarItemsDiagnostico(object sender, EventArgs e)
        {
            if (txtCod_ciediez.Text.Trim().Length == 0 )
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
 
        protected void CerrarPantalla(object sender, EventArgs e)
        {
            Response.Redirect("~/frmMenu.aspx");
        }
    }
}