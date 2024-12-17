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
    public partial class frmCitaPacientes : System.Web.UI.Page
    {
        public static string lblhora;
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = Session["Username"].ToString();
            if (!IsPostBack)
            {
                drpEspecialidad.DataSource = LogicaEspecialidad.ListEspecialidad();
                drpEspecialidad.DataValueField = "cod_especialidad";
                drpEspecialidad.DataTextField = "nom_especialidad";
                drpEspecialidad.DataBind();

                drpCiaAseguradora.DataSource = LogicaProveedorSeguro.ListProveedorSeguro();
                drpCiaAseguradora.DataValueField = "id_cia_seguro";
                drpCiaAseguradora.DataTextField = "nombre_seguro";
                drpCiaAseguradora.DataBind();
 
                txtfechabusqueda.Text = DateTime.Now.ToString("dd/MM/yyyy");
                SetGridView();
            }
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
            grdDetalleCita.DataSource = dt;
            grdDetalleCita.DataBind();
        }
        public void CreateNewRowGridCita()
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
                grdDetalleCita.DataSource = dtCurrentTable;
                grdDetalleCita.DataBind();
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
                grdDetalleCita.DataSource = dt;
                grdDetalleCita.DataBind();
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
        protected void CargarItemsCatalogo(object sender, EventArgs e)
        {
            if (txtId_ItemCatalogo.Text.Trim().Length == 0)
            {
                return;
            }
            else
            {
                CreateNewRowGridCita();
                //clean fields
                txtId_ItemCatalogo.Text = "";
                txtDescrip_catalogo.Text = "";
                txtPrecio_item.Text = "0";
                txtIdGrupo_item.Text = "";
                txtIdClase_item.Text = "";

            }
        }
        protected void BuscarTurnos(object sender, EventArgs e)
        {
            BindData();
        }
        private void BindData()
        {
            grdTurnos.DataSource = LogicaTurno.ListTurnos(txtfechabusqueda.Text,Convert.ToInt32(drpEspecialidad.SelectedItem.Value));
            grdTurnos.DataBind();
        }
        protected void OnRowColorGridCell(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[5].Text == "Disponible")
                {
                    e.Row.Cells[2].BackColor = System.Drawing.Color.Green;
                }
    
            }
        }
        protected void OpenNuevacita(object sender, EventArgs e)
        {
            txtDni_cliente.Text = "";
            txtNombre_cliente.Text = "";
            lblFecha_cita.Text = "";
            txtObservacion.Text = "";
            lblMsj.Text = "";
            lblNumero_cita.Text = "";           

            lblFecha_cita.Text = txtfechabusqueda.Text;
            Button btnNuevaCita = (sender as Button);
            GridViewRow row = (btnNuevaCita.NamingContainer as GridViewRow);
            lblhora = row.Cells[0].Text;
            if (row.Cells[2].Text.Trim().Length > 0)
            {
                return;
            }
            else
            {
                btnGuardarCita.Enabled = true;
                ModalPopupExtender1.Show();
            }
            
        }
        protected void GuardarNuevaCita(object sender, EventArgs e)
        {
            EntidadCita entcita = new EntidadCita();
            entcita.fecha_registro = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            entcita.num_doc_cliente = txtDni_cliente.Text;
            entcita.id_cia_seguro = Convert.ToInt32(drpCiaAseguradora.SelectedItem.Value);
            entcita.tipo_paciente = drpTipoPaciente.SelectedItem.Text;
            entcita.cod_persona = 1;
            entcita.fecha_cita = lblFecha_cita.Text;
            entcita.observacion = txtObservacion.Text;
            entcita.nombre_usuario = lblUsuario.Text;
            if(grdDetalleCita.Rows.Count==0)
            {
                return;
            }
            else
            {
                LogicaCita.InsertCita(entcita);
                lblNumero_cita.Text = LogicaCita.GetLastIdRegCita(txtDni_cliente.Text, lblFecha_cita.Text, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)[0].id_cita.ToString();
                GuardarDetalleCita();
                lblMsj.Text = "¡registro exitoso!";
            }
            CleanFields();
            btnGuardarCita.Enabled = false;
        }
        protected void GuardarDetalleCita()
        {
            foreach(GridViewRow row in grdDetalleCita.Rows)
            {
                EntidadDetalleCita entDetCita = new EntidadDetalleCita();
                entDetCita.id_cita = Convert.ToInt32(lblNumero_cita.Text);
                entDetCita.estado = "Citado";
                entDetCita.cod_item_catalogo = row.Cells[2].Text;
                entDetCita.descrip_item = row.Cells[3].Text;
                entDetCita.precio_cita = Convert.ToDecimal(row.Cells[4].Text);  
                entDetCita.hora_cita = row.Cells[1].Text;
                entDetCita.codigo_especialidad = Convert.ToInt32(drpEspecialidad.SelectedItem.Value);
                entDetCita.id_grupo = Convert.ToInt32(row.Cells[6].Text);
                entDetCita.id_clase = Convert.ToInt32(row.Cells[7].Text);
                entDetCita.confirmado = true;
                LogicaDetalleCita.InsertDetalleCita(entDetCita);
                LogicaTurno.OcuparTurno(txtDni_cliente.Text, lblhora, lblFecha_cita.Text, Convert.ToInt32(drpEspecialidad.SelectedItem.Value), row.Cells[2].Text);
            }
        }
        private void CleanFields()
        {
            //clean gridCompras
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            dt.Clear();
            grdDetalleCita.DataSource = dt;
            grdDetalleCita.DataBind();
        }
        protected void CerrarNuevaCita(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
        }
        protected void CancelaTurnoCita(object sender, EventArgs e)
        {
            Button btnBorraturno = (sender as Button);
            GridViewRow row = (btnBorraturno.NamingContainer as GridViewRow);
            LogicaTurno.DesocuparTurno(Convert.ToInt32(row.Cells[7].Text), row.Cells[0].Text,Convert.ToInt32(drpEspecialidad.SelectedItem.Value));
            //CAMBIAR DE ESTADO EL DETALLE DE LA CITA
            LogicaDetalleCita.ActualizaEstadoDetalleCita(row.Cells[2].Text, Convert.ToInt32(drpEspecialidad.SelectedItem.Value), row.Cells[0].Text, txtfechabusqueda.Text);
            //Refresh gridview
            BindData();
        }
        protected void BuscarPacienteCitado(object sender, EventArgs e)
        {
            grdPacientesCitados.DataSource = LogicaClientePersona.ListClientePersona(txtBuscarxDNI.Text);
            grdPacientesCitados.DataBind();
        }
        protected void SelecionarPaciente(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
              
            grdCita.DataSource = LogicaCita.ListCitas(row.Cells[1].Text);
            grdCita.DataBind();
        }
        protected void Show_Hide_ChildGrid(object sender, EventArgs e)
        {
            ImageButton imgShowHide = (sender as ImageButton);
            GridViewRow row = (imgShowHide.NamingContainer as GridViewRow);
            if (imgShowHide.CommandArgument == "Show")
            {
                row.FindControl("panelCitaDetalle").Visible = true;
                imgShowHide.CommandArgument = "Hide";
                imgShowHide.ImageUrl = "~/Images/minus.png";

                int id_cita = Convert.ToInt32(grdCita.Rows[row.RowIndex].Cells[1].Text);
                GridView gvDetallecita = row.FindControl("grdCitaDetalle") as GridView;
                gvDetallecita.DataSource = LogicaDetalleCita.ListDetalleCita(id_cita);
                gvDetallecita.DataBind();
            }
            else
            {
                row.FindControl("panelCitaDetalle").Visible = false;
                imgShowHide.CommandArgument = "Show";
                imgShowHide.ImageUrl = "~/Images/plus.png";
            }
        }
        protected void CerrarPantalla(object sender, EventArgs e)
        {
            Response.Redirect("~/frmMenu.aspx");
        }
    }
}