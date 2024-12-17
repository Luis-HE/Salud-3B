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
    public partial class frmAdmision : System.Web.UI.Page
    {
        public static int OpcionTieneCita = 0;
        public static string lblhora;
        public static int num_cita;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = Session["Username"].ToString();
            if (!IsPostBack)
            {
                FillListas();
                BindTurnos();
                SetGridView();
            }
        }
        protected void FillListas()
        {
            drpEspecialidad.DataSource = LogicaEspecialidad.ListEspecialidad();
            drpEspecialidad.DataValueField = "cod_especialidad";
            drpEspecialidad.DataTextField = "nom_especialidad";
            drpEspecialidad.DataBind();

            drpCiaAseguradora.DataSource = LogicaProveedorSeguro.ListProveedorSeguro();
            drpCiaAseguradora.DataValueField = "id_cia_seguro";
            drpCiaAseguradora.DataTextField = "nombre_seguro";
            drpCiaAseguradora.DataBind();

        }
        private void SetGridView()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Col1", typeof(string)));
            dt.Columns.Add(new DataColumn("Col2", typeof(string)));
            dt.Columns.Add(new DataColumn("Col3", typeof(string)));
            dt.Columns.Add(new DataColumn("Col4", typeof(string)));
            dt.Columns.Add(new DataColumn("Col5", typeof(string)));
            dt.Columns.Add(new DataColumn("Col6", typeof(string)));
            dt.Columns.Add(new DataColumn("Col7", typeof(string)));
            dt.Columns.Add(new DataColumn("Col8", typeof(string)));
            ViewState["CurrentTable"] = dt;
            grdDetalleAdmision.DataSource = dt;
            grdDetalleAdmision.DataBind();
        }
        public void CreateNewRowGridAdmision()
        {
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                for (int i = 0; i <= dtCurrentTable.Rows.Count; i++)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["Col1"] = i + 1;
                    drCurrentRow["Col2"] = lblhora;
                    drCurrentRow["Col3"] = txtId_ItemCatalogo.Text;
                    drCurrentRow["Col4"] = txtDescrip_catalogo.Text;
                    drCurrentRow["Col5"] = txtPrecio_item.Text;
                    drCurrentRow["Col6"] = txtCantidad_item.Text;
                    drCurrentRow["Col7"] = txtIdGrupo_item.Text;
                    drCurrentRow["Col8"] = txtIdClase_item.Text;
                 }
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;
                grdDetalleAdmision.DataSource = dtCurrentTable;
                grdDetalleAdmision.DataBind();
            }
        }
        protected void CargarItemsCatalogo(object sender, EventArgs e)
        {
            if (txtId_ItemCatalogo.Text.Trim().Length == 0)
            {
                return;
            }
            else
            {
                CreateNewRowGridAdmision();
                //clean fields
                txtId_ItemCatalogo.Text = "";
                txtDescrip_catalogo.Text = "";
                txtPrecio_item.Text = "0";
                txtIdGrupo_item.Text = "";
                txtIdClase_item.Text = "";
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
                grdDetalleAdmision.DataSource = dt;
                grdDetalleAdmision.DataBind();
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
        //============ Admision==============
        protected void GuardarAdmision(object sender, EventArgs e)
        {
            EntidadAdmision entAdmin = new EntidadAdmision();

            entAdmin.fecha_admision = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            entAdmin.nombre_usuario = lblUsuario.Text;
            entAdmin.observacion = txtObs_atencion.Text;
            entAdmin.monto_adelanto = Convert.ToDecimal(txtMonto_adelanto.Text);
            entAdmin.cobertura = Convert.ToDecimal(txtCobertura.Text);
            entAdmin.tipo_admision = drpTipoAtencion.SelectedItem.Text;
            entAdmin.tipo_paciente = drpTipoPaciente.SelectedItem.Text;
            entAdmin.id_cia_seguro = Convert.ToInt32(drpCiaAseguradora.SelectedItem.Value);
            entAdmin.numero_doc_cliente = txtDni_cliente.Text;
            entAdmin.id_cita = num_cita ;  
            entAdmin.paciente_vip = false;
            entAdmin.codigo_persona = 1;
            entAdmin.cod_carta_garantia = txtNumCartaGrantia.Text;
            entAdmin.nomb_garante = txtGarante.Text;
            entAdmin.id_reg_acompanante = Convert.ToInt32(txtIdAcompanante.Text);
            if (grdDetalleAdmision.Rows.Count == 0)
            {
                return;
            }
            else
            {
                if (OpcionTieneCita == 1)
                {//el paciente TIENE CITA
                    LogicaAdmision.InsertAdmision(entAdmin);
                }
                else
                {// el paciente NO TIENE CITA
                    LogicaAdmision.InsertAdmisionAmbulatoria(entAdmin);
                }

                lblNumero_atencion.Text = LogicaAdmision.GetLastIdRegAtencion(txtDni_cliente.Text, Convert.ToInt32(drpCiaAseguradora.SelectedItem.Value), DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)[0].numero_admision.ToString();

                GuardarDetalleAdmision();
                lblMsj.Text = "¡registro exitoso!";
            }
            CleanFields();
            btnGuardarAdmision.Enabled = false;
        }
        protected void GuardarDetalleAdmision()
        {
            foreach (GridViewRow row in grdDetalleAdmision.Rows)
            {
                EntidadDetalleAdmision entDetadmin = new EntidadDetalleAdmision();
                entDetadmin.num_admision = Convert.ToInt32(lblNumero_atencion.Text);
                entDetadmin.codigo_item = row.Cells[2].Text;
                entDetadmin.estado = "Admitido";
                entDetadmin.descrip_item = row.Cells[3].Text; 
                entDetadmin.precio_atencion = Convert.ToDecimal(row.Cells[4].Text); 
                entDetadmin.hora = row.Cells[1].Text;
                entDetadmin.codigo_especialidad = Convert.ToInt32(drpEspecialidad.SelectedItem.Value);
                entDetadmin.id_grupo = Convert.ToInt32(row.Cells[6].Text);
                entDetadmin.id_clase = Convert.ToInt32(row.Cells[7].Text);
                LogicaDetalleAdmision.InsertDetalleAdmision(entDetadmin);
                LogicaTurno.OcuparTurno(txtDni_cliente.Text, lblhora, DateTime.Now.ToString("dd/MM/yyyy"), Convert.ToInt32(drpEspecialidad.SelectedItem.Value), row.Cells[2].Text);
            }               
        }
        private void CleanFields()
        {
            //clean gridCompras
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            dt.Clear();
            grdDetalleAdmision.DataSource = dt;
            grdDetalleAdmision.DataBind();
        }
        protected void BuscarTurnos(object sender, EventArgs e)
        {
            BindTurnos();
        }
        protected void BindTurnos()
        {
            grdTurnos.DataSource = LogicaTurno.ListTurnos(DateTime.Now.ToString("dd/MM/yyyy"), Convert.ToInt32(drpEspecialidad.SelectedItem.Value));
            grdTurnos.DataBind();
        }
        protected void OnRowColorGridCell(object sender, GridViewRowEventArgs e)
        {
            Button btnOpenCitado = e.Row.FindControl("btnOpenCitado") as Button;
            Button btnCrearAdmision = e.Row.FindControl("btnCreaAdmision") as Button;
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[4].Text == "Disponible")
                {
                    e.Row.Cells[2].BackColor = System.Drawing.Color.Green;
                    btnOpenCitado.Visible = false;
                }
                if (e.Row.Cells[2].Text.Trim().Length > 0)
                {
                    btnCrearAdmision.Visible = false;
                }
            }
            
             
        }
        protected void OpenNuevaAdmision(object sender, EventArgs e)
        {
            Button btnNuevaAdmision = (sender as Button);
            GridViewRow row = (btnNuevaAdmision.NamingContainer as GridViewRow);
            lblhora = row.Cells[0].Text;

            OpcionTieneCita = 0;

            //validando que el turno ya esta ocupado
            //if (row.Cells[2].Text.Trim().Length > 0)
            //{
            //    return;
            //}
            //else
            //{
                txtDni_cliente.Text = "";
                txtNombre_cliente.Text = "";
                txtCobertura.Text = "0";
                txtNumCartaGrantia.Text = "";
                txtMonto_adelanto.Text = "0";
                txtIdAcompanante.Text = "1";
                txtNombreAcompanante.Text = "Ninguno";
                txtGarante.Text = "";
                txtObs_atencion.Text = "";
                lblNumero_atencion.Text = "";
                lblMsj.Text = "";
                btnGuardarAdmision.Enabled = true;

                ModalPopupExtender1.Show();
               
           // }

        }
        protected void CerrarNuevaAdmision(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
        }

        //=======================ADMISION de CITADOS=====================

        protected void OpenPopupCitado(object sender, EventArgs e)
        {
            Button btnCitado = (sender as Button);
            GridViewRow row = (btnCitado.NamingContainer as GridViewRow);
            lblhora = row.Cells[0].Text;

            List<EntidadModeloBuscaPacCitado> lst = new List<EntidadModeloBuscaPacCitado>();
            lst = LogicaModeloBuscaPacCitado.ListarPaccitado(row.Cells[2].Text, DateTime.Now.ToString("dd/MM/yyyy"), row.Cells[0].Text);

            OpcionTieneCita = 1;

            num_cita = lst[0].numero_cita;
            txtDni_cliente.Text = lst[0].dni_cliente;
            txtNombre_cliente.Text = lst[0].nombre_cliente;
            drpTipoPaciente.SelectedItem.Text = lst[0].tipo_paciente;
            drpCiaAseguradora.SelectedItem.Value = lst[0].cod_cia_seguro.ToString();
            drpCiaAseguradora.SelectedItem.Text = lst[0].plan_asegurador; 
            txtId_ItemCatalogo.Text = lst[0].cod_item_catalogo;
            txtDescrip_catalogo.Text = lst[0].descripcion_item;
            txtPrecio_item.Text = lst[0].precio_citado.ToString();
            txtIdGrupo_item.Text = lst[0].id_grupo.ToString();
            txtIdClase_item.Text = lst[0].id_clase.ToString();
            txtCobertura.Text = "0";
            txtNumCartaGrantia.Text = "";
            txtMonto_adelanto.Text = "0";
            drpTipoAtencion.Text = "Ambulatoria";
            txtIdAcompanante.Text = "1";
            txtNombreAcompanante.Text = "Ninguno";
            txtGarante.Text = "";
            txtObs_atencion.Text = lst[0].observacion;
            ModalPopupExtender1.Show();
        }
        protected void CerrarPantalla(object sender, EventArgs e)
        {
            Response.Redirect("~/frmMenu.aspx");
        }

    }
}