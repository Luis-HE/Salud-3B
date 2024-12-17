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
    public partial class frmGinecoObstetricia : System.Web.UI.Page
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
            Entidad_HC_CE_GINECO_OBSTETRICIA ent = new Entidad_HC_CE_GINECO_OBSTETRICIA();

            Entidad_HC_DG_DIAGNOSTICO entDiagnostico = new Entidad_HC_DG_DIAGNOSTICO();
            if (lblNumeroAdmision.Text.Length == 0)
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
                    ent.id_ginecoobstetricia = Convert.ToInt32(lblNumeroAdmision.Text);
                    ent.numero_historia_clinica = num_historia_clin;
                    ent.numero_doc_cliente = num_doc_cliente;
                    ent.codigo_persona = 1;
                    ent.numero_admision = Convert.ToInt32(lblNumeroAdmision.Text);
                    ent.fecha_registro = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                    ent.hora_registro = DateTime.Now.ToString("HH:mm");
                    ent.edad = txtTriajeEdad.Text;
                    ent.gesta = txtGesta.Text;
                    ent.paridad1 = txtParidad1.Text;
                    ent.paridad2 = txtParidad2.Text;
                    ent.paridad3 = txtParidad3.Text;
                    ent.paridad4 = txtParidad4.Text;
                    ent.fur = txtFur.Text;
                    ent.fpp = txtFpp.Text;
                    ent.edad_gestacion = txtEdadGestacion.Text;
                    ent.antecedentes = txtAntecedente.Text;
                    ent.motivo_consulta = txtMotivoConsulta.Text;
                    ent.tiempo_enfermedad = txtTiempoEnfermedad.Text;
                    ent.examen_clinico = txtExamenClinico.Text;
                    ent.cod_cie_diez = txtCod_ciediez.Text;
                    ent.plan_trabajo = txtPlanTrabajo.Text;
                    ent.tratamiento = txtTratamiento.Text;
                    ent.fecha_proxima_cita = txtproximacita.Text;
                    ent.observaciones = txtObservaciones.Text;
                    ent.dni_empleado = txtDni_empleado.Text;
                    ent.codigo_persona_pago = 1;

                    Logica_HC_CE_GINECO_OBSTETRICIA.InsertarGinecoObstetrica(ent);
                    LogicaModeloBuscaPacAdmitido.ActualizaEstadoAdmision(Convert.ToInt32(lblNumeroAdmision.Text));
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
            }          
             
        }
        protected void Limpiar(object sender, EventArgs e)
        {
            CleanFields();
            ////refrescar la lista
            BuscarPacientes();
        }
        private void CleanFields()
        {
             txtTriajeEdad.Text ="";
             txtGesta.Text="";
             txtParidad1.Text ="";
             txtParidad2.Text = "";
             txtParidad3.Text="";
             txtParidad4.Text="";
             txtFur.Text="";
             txtFpp.Text="";
             txtEdadGestacion.Text="";
             txtAntecedente.Text="";
             txtMotivoConsulta.Text="";
             txtTiempoEnfermedad.Text="";
             txtExamenClinico.Text="";
             txtCod_ciediez.Text="";
             txtNombre_ciediez.Text = "";
             txtPlanTrabajo.Text="";
             txtTratamiento.Text="";
             txtproximacita.Text="";
             txtObservaciones.Text="";
            grdDiagnosticos.DataSource = null;
            grdDiagnosticos.DataBind();
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
        protected void CerrarPantalla(object sender, EventArgs e)
        {
            Response.Redirect("~/frmMenu.aspx");
        }
    }
}