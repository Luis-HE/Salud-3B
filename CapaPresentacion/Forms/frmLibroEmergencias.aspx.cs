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
    public partial class frmLibroEmergencias : System.Web.UI.Page
    {
        public static int numero_admision;
        public static string num_doc_paciente;
        public static string paciente;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ListarPacientesAdmitidosEmergencia();
                txtHoraTerminaAtencion.Text = DateTime.Now.ToString("HH:mm");
            }
        }
        private void ListarPacientesAdmitidosEmergencia()
        {
            grdAdmitidosXEmergencia.DataSource = LogicaModeloBuscaPacAdmitido.BuscarPacienteAdmitidoLibroEmergencia(DateTime.Now.Day,DateTime.Now.Month,DateTime.Now.Year);
            grdAdmitidosXEmergencia.DataBind();
        }
        protected void RefrescarGridview(object sender, EventArgs e)
        {
            ListarPacientesAdmitidosEmergencia();
        }
        protected void SelecionarRegistro(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            numero_admision = Convert.ToInt32(row.Cells[1].Text);
            lblNumHistoria.Text = row.Cells[3].Text;
            num_doc_paciente = row.Cells[3].Text;
            paciente = row.Cells[4].Text;
            txtGenero.Text = row.Cells[6].Text;
            txtDireccionDomilicio.Text = row.Cells[7].Text;

            //================calculando la edad======================
            try
            {
                DateTime hoy = DateTime.Now;
                DateTime nace = DateTime.Parse(row.Cells[5].Text);
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
            catch (Exception)
            {

            }
        }
        protected void GuardarLibroEmergencia(object sender, EventArgs e)
        {
            Entidad_HC_EM_LIBRO_EMERGENCIA ent = new Entidad_HC_EM_LIBRO_EMERGENCIA();
            ent.id_libro_emergencia = numero_admision;
            ent.numero_historia_clinica = lblNumHistoria.Text;
            ent.numero_doc_cliente = num_doc_paciente;
            ent.codigo_persona = 1;
            ent.dni_empleado = txtDni_empleado.Text;
            ent.codigo_persona_pago = 1;
            ent.numero_admision = numero_admision;
            ent.fecha_ingreso = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            ent.hora_ingreso = DateTime.Now.ToString("HH:mm");
            ent.nombre_paciente = paciente;
            ent.edad = Convert.ToInt32(txtEdad.Text);
            ent.genero = txtGenero.Text;
            ent.direccion_domiciliaria = txtDireccionDomilicio.Text;
            ent.diagnostico_ingreso = txtDiagnosticoIngreso.Text;
            ent.diagnostico_final = txtDiagnosticoFinal.Text;
            ent.destino_final = txtDestinoFinal.Text;
            ent.hora_termina_atencion = txtHoraTerminaAtencion.Text;
            ent.observaciones = txtObservaciones.Text;
            ent.nombre_acompanante = txtNombreAcompanante.Text;
            if (lblNumHistoria.Text.Trim().Length == 0)
            {
                return;
            }
            else
            {
                Logica_HC_EM_LIBRO_EMERGENCIA.CreateLIBRO_EMERGENCIA(ent);
                lblMsj.Text = "¡registro exitoso!";
            }

            CleanFields();
            ListarPacientesAdmitidosEmergencia();

        }
        private void CleanFields()
        {
            lblNumHistoria.Text = "";
            txtEdad.Text = "";
            txtGenero.Text = "";
            txtDireccionDomilicio.Text = "";
            txtDiagnosticoIngreso.Text = "";
            txtDiagnosticoFinal.Text = "";
            txtDestinoFinal.Text = "";
            txtHoraTerminaAtencion.Text = "";
            txtObservaciones.Text = "";
            //txtIdAcompanante.Text = "";
            txtNombreAcompanante.Text = "";
        }
        protected void CerrarPantalla(object sender, EventArgs e)
        {
            Response.Redirect("~/frmMenu.aspx");
        }
    }
}