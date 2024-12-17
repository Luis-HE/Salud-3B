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
    public partial class frmTriaje : System.Web.UI.Page
    {
        public static string tipoDocpago;
        public static string numserie;
        public static string numDoc_contable;

        protected void Page_Load(object sender, EventArgs e)
        {
            //lblUsuario.Text = Session["Username"].ToString();

            if (!IsPostBack)
            {
                ListarAdmitidos();
            }

        }
        protected void ListarAdmitidos()
        {
            grdAdmitidos.DataSource = LogicaTriaje.ColaTriaje(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
            grdAdmitidos.DataBind();
        }
        protected void RegrescarGridview(object sender, EventArgs e)
        {
            ListarAdmitidos();
        }
        protected void SelecionarRegistro(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            lblNumAtencion.Text =  row.Cells[1].Text ;
            tipoDocpago =  row.Cells[9].Text ;
            numserie =  row.Cells[10].Text ;
            numDoc_contable =  row.Cells[11].Text ;

            lblNumHistoria.Text = row.Cells[3].Text;
            lblNumDocCliente.Text =  row.Cells[3].Text ;
            //================calculando la edad======================
            try
            {
                DateTime hoy = DateTime.Now;
                DateTime nace = DateTime.Parse(row.Cells[6].Text);
                int mes = hoy.Month;//actualidad
                int ano = hoy.Year;//actualidad
                int anonace = nace.Year;//nacimiento
                int mesnace = nace.Month;//nacimiento
                int meses, anos;//variables
                int a = anonace + 1;
                anos = ano - a;
                int d = 12 - mesnace;
                meses = d + mes;
                if (meses >= 12)
                {
                    anos = anos + 1;
                    meses = meses % 12;
                    txtEdad.Text = anos.ToString();
                    //this->lblmeses->Text = meses.ToString();
                }
                else
                {
                    txtEdad.Text = anos.ToString();
                    //this->lblmeses->Text = meses.ToString();
                }
            }
            catch (Exception )
            {

            }

        }
        protected void GuardarTriaje(object sender, EventArgs e)
        {
            if (lblNumAtencion.Text.Length == 0)
            {
                return;
            }
            else
            {
                EntidadTriaje entTriaje = new EntidadTriaje();
                entTriaje.id_registro_triaje = 1;
                entTriaje.numero_admision= Convert.ToInt32(lblNumAtencion.Text);
                entTriaje.num_hist_clinica = lblNumHistoria.Text;
                entTriaje.num_doc_cliente = lblNumDocCliente.Text;
                entTriaje.cod_persona = 1;
                entTriaje.talla = txtTalla.Text;
                entTriaje.edad = txtEdad.Text;
                entTriaje.peso = txtPeso.Text;
                entTriaje.presion_arterial_sistolica = txtPresion_arterial_sistolica.Text;
                entTriaje.presion_arterial_diastolica = txtPresion_arterial_diastolica.Text;
                entTriaje.temperatura = txt_temperatura.Text;
                entTriaje.prioridad = drpPrioridad.SelectedItem.Text;
                entTriaje.frecuencia_cardiaca = txt_ritmo_cardiaco.Text;
                entTriaje.indice_masa_corporal = txtImc.Text;
                entTriaje.frecuencia_respiratoria = txtFrecRespira.Text;
                entTriaje.num_doc_pago = numDoc_contable;
                entTriaje.serie_doc_pago = numserie;
                entTriaje.tipo_doc_pago = tipoDocpago;
                entTriaje.fecha_atencion = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                entTriaje.sp_oxigeno = txtspOxigeno.Text;
                entTriaje.gineco_problema_principal = txtGineProblemPrincipal.Text;
                entTriaje.gineco_tiempo_embarazo = txtGineTiempoEmbarazo.Text;
                entTriaje.gineco_diabetes_mellitus = txtGineDiabetes.Text;
                entTriaje.gineco_hipertension_arterial = txtGineHipertensionArterial.Text;
                entTriaje.gineco_cardiopatia = txtGineCardiopatia.Text;
                entTriaje.gineco_enf_tiroidea = txtGineEnfermedadTiroidea.Text;
                entTriaje.gineco_enf_renal = txtGineEnfermedadRenal.Text;
                entTriaje.gineco_otras_patologias = txtGineOtrasPatologias.Text;
                entTriaje.gineco_amenaza_aborto = txtGineAmenazaAborto.Text;
                entTriaje.gineco_amenaza_parto = txtGineAmenzaParto.Text;
                entTriaje.gineco_embarazo_termino = txtGineEmbarazoTermino.Text;
                entTriaje.gineco_enf_hipertensiva = txtGineEnfermedadHipertensiva.Text;
                entTriaje.gineco_hemorragia = txtGineHemorragia.Text;
                entTriaje.gineco_sepsis = txtGineSepsis.Text;
                entTriaje.gineco_otros_problemas = txtGineOtros.Text;
                entTriaje.gineco_sintomatologia = txtGineSintomatologia.Text;
                entTriaje.gineco_indice_choque = txtGineIndiceChoque.Text;
                entTriaje.gineco_diagnostico_probable = txtGineDiagnosticoProbable.Text;
                entTriaje.gineco_plan_terapeutico = txtGinePlanTerapeutico.Text;
                entTriaje.hora_atencion = DateTime.Now.ToString("HH:mm"); ;
                entTriaje.dni_empleado = txtDni_empleado.Text;
                entTriaje.codigo_persona_pago = 1;   

                if(lblNumAtencion.Text.Trim().Length==0)
                {
                    return;
                }
                else
                {
                    LogicaTriaje.InsertarTriaje(entTriaje);
                    lblMsj.Text = "¡registro exitoso!";
                }
                CleanFields();
                ListarAdmitidos();        
            }   
        }
        private void CleanFields()
        {
            lblNumAtencion.Text = "";
            txtTalla.Text = "";
            txtEdad.Text = "";
            txtPeso.Text = "";
            txtPresion_arterial_sistolica.Text = "";
            txtPresion_arterial_diastolica.Text = "";
            txt_temperatura.Text = "";
            txt_ritmo_cardiaco.Text = "";
            txtImc.Text = "";
            txtFrecRespira.Text = "";
            lblNumHistoria.Text = "";
            lblNumDocCliente.Text = "";
            txtspOxigeno.Text = "";
        }
       
        protected void CerrarPantalla(object sender, EventArgs e)
        {
            Response.Redirect("~/frmMenu.aspx");
        }
    }
}