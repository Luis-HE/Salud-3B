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
    public partial class frmListar_Pacientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                drpUbigeo.DataSource = LogicaUbigeo.ListarUbigeo();
                drpUbigeo.DataValueField = "id_ubigeo";
                drpUbigeo.DataTextField = "nomb_departamento";
                drpUbigeo.DataBind();

                drpNacionalidad.DataSource = LogicaNacionalidad.ListNaciones();
                drpNacionalidad.DataValueField = "cod_nacionalidad";
                drpNacionalidad.DataTextField = "nomb_nacionalidad";
                drpNacionalidad.DataBind();
            }
        }

        protected void btnBuscarClientePersona_Click(object sender, EventArgs e)
        {
            BindClientePersonas();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            EntidadClientePersona entcp = new EntidadClientePersona();
            entcp.num_doc_cliente = txtDni_cliente.Text;
            entcp.cod_persona = 1;
            entcp.apellido_paterno = txtApel_paterno.Text;
            entcp.nombres = txtNombre_cliente.Text;
            entcp.apellido_materno = txtapel_materno.Text;
            entcp.telefono1 = txttelef_fijo.Text;
            entcp.telefono2 = txtTelef_movil.Text;
            entcp.email = txtEmail.Text;
            entcp.genero = drpGenero.SelectedItem.Text;
            entcp.dni_vendedor = "";
            entcp.direccion = txtDireccion.Text;
            entcp.grupo_sanguineo = drpGrupoSanguineo.SelectedItem.Text;
            entcp.fecha_nace = txtFecha_nace.Text;
            entcp.cod_nacionalidad = Convert.ToInt32(drpNacionalidad.SelectedItem.Value);
            entcp.id_ubigeo =  drpUbigeo.SelectedItem.Value ;
            entcp.estado_civil = drpEstadoCivil.SelectedItem.Text;
            entcp.nombre_padre = txtnombrePadre.Text;
            entcp.nombre_madre = txtnombreMadre.Text;
            entcp.religion = drpReligion.SelectedItem.Text;
            entcp.ocupacion = drpOcupacion.SelectedItem.Text;
            entcp.grupo_etnico = drpGrupoEtnico.SelectedItem.Text;

            LogicaClientePersona.InsertClientePersona(entcp);
            BindClientePersonas();
            btnGuardar.Enabled = false;
        }
        private void BindClientePersonas()
        {
            grdClientePersonas.DataSource = LogicaClientePersona.ListClientePersona(txtDni_cliente.Text);
            grdClientePersonas.DataBind();
        }

    }
}