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
    public partial class frmListarAcompanante : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BuscarAcompanante(object sender, EventArgs e)
        {
            BindAcompanante();
        }
        protected void InsertarAcompanante(object sender, EventArgs e)
        {
            EntidadAcompanante entAcom = new EntidadAcompanante();
            //entAcom.id_reg_acompnante = 0;
            entAcom.dni_ruc_acompanante = txtDniRuc.Text;
            entAcom.codigo_persona = Convert.ToInt32(drpTipoPersona.SelectedItem.Value);
            entAcom.nombre_acompanante = txtNombre.Text;
            entAcom.apellido_acompanante = txtApellidos.Text;
            entAcom.parentesco = drpParentesco.SelectedItem.Text;
            entAcom.nombre_contacto = txtNombreContacto.Text;
            entAcom.ocupacion = txtOcupacion.Text;
            entAcom.telefono = txtTelefono.Text;
            entAcom.grupo_etnico = drpGrupoEtnico.SelectedItem.Text;
            entAcom.idioma_principal = drpIdioma.SelectedItem.Text;
            entAcom.religion = drpReligion.SelectedItem.Text;
            entAcom.estado_civil = drpEstadoCivil.SelectedItem.Text;
            entAcom.genero = drpGenero.SelectedItem.Text;
            entAcom.edad = Convert.ToInt32(txtEdad.Text);
            entAcom.grado_instruccion = drpGradoInstruccion.SelectedItem.Text;
            entAcom.condicion_ocupacion = drpCondicionOcupacion.SelectedItem.Text;
            entAcom.seguro_salud = drpSeguroSalud.SelectedItem.Text;

            LogicaAcompanante.InsertarAcompanante(entAcom);
            BindAcompanante();
            btnGuardar.Enabled = false;
        }
        protected void BindAcompanante()
        {
            grdAcompanantes.DataSource = LogicaAcompanante.ListAcompanante(txtDniRuc.Text);
            grdAcompanantes.DataBind();
            
        }
    }
}