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
    public partial class frmConvenios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                drpCiaAseguradora.DataSource = LogicaProveedorSeguro.ListProveedorSeguro();
                drpCiaAseguradora.DataValueField = "id_cia_seguro";
                drpCiaAseguradora.DataTextField = "nombre_seguro";
                drpCiaAseguradora.DataBind();

                FillConvenios();
                txtfecha_convenio.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }

        protected void btnGuardarConvenio_Click(object sender, EventArgs e)
        {
            EntidadConvenio entcon = new EntidadConvenio();
            entcon.id_reg_convenio = Convert.ToInt32(DateTime.Now.ToString("yyyyMM")+ drpCiaAseguradora.SelectedItem.Value); //año mes idciaseguro
            entcon.id_cia_seguro = Convert.ToInt32(drpCiaAseguradora.SelectedItem.Value);            
            entcon.fecha_convenio = txtfecha_convenio.Text;
            entcon.duracion = txt_duracion.Text;
            entcon.firmante = txt_firmante.Text;
            entcon.observacion = txt_observacion.Text;
            LogicaConvenio.InsertConvenio(entcon);
            FillConvenios();
            txtfecha_convenio.Text = "";
            txt_duracion.Text = "";
            txt_firmante.Text = "";
            txt_observacion.Text = "";
        }
        private void FillConvenios()
        {
            grdConvenios.DataSource = LogicaConvenio.ListConvenios();
            grdConvenios.DataBind();
        }
        protected void DetalleConvenio(object sender, EventArgs e)
        {
            //grdListaServicios.DataSource = LogicaCatalogo.ListItemsCatalogo("Servicio");
            //grdListaServicios.DataBind();
            ModalPopupExtender1.Show();            
        }
        protected void GuardarDetalleConvenio(object sender, EventArgs e)
        {
            EntidadDetalleConvenio entDetConv = new EntidadDetalleConvenio();
            decimal factor = 0;

            foreach (GridViewRow rows in grdConvenios.Rows)
            {
                entDetConv.id_regConvenio = Convert.ToInt32(rows.Cells[0].Text);
                entDetConv.id_ciaSeg = Convert.ToInt32(rows.Cells[1].Text);
                entDetConv.porcentaje_cubre = 0;
                entDetConv.cod_item_catalogo = "";
                entDetConv.precio_venta= 0;                       
                factor = Convert.ToDecimal(txtFactor.Text);
                entDetConv.factor_calculo = factor;
                entDetConv.id_grupo = 1;
                entDetConv.id_clase = 1;

            }
            foreach (GridViewRow rowsServ in grdListaServicios.Rows)
            {
                TextBox txtporcentaje = (TextBox)rowsServ.FindControl("txtPorcentaje");
                TextBox txtPrecio = (TextBox)rowsServ.FindControl("txtPrecio");

                entDetConv.cod_item_catalogo = rowsServ.Cells[0].Text;             
                entDetConv.porcentaje_cubre = entDetConv.porcentaje_cubre = Convert.ToDecimal(txtporcentaje.Text);
                //ojo modificar formula de acuerdo al NEGOCIO
                entDetConv.precio_venta = Convert.ToDecimal(txtPrecio.Text) - Convert.ToDecimal(txtPrecio.Text) * (Convert.ToDecimal(txtporcentaje.Text) / 100) + factor;

                LogicaDetalleConvenio.InsertDetalleConvenio(entDetConv);
            }
            // btnGuardarDetalleConvenio.Enabled = false;
            grdListaServicios.DataSource = null;
            grdListaServicios.DataBind();
        }
       
        protected void CerrarConvenio(object sender, EventArgs e)
        {
            Response.Redirect("~/frmMenu.aspx");
        }
        protected void CerrarDetalle(object sender, EventArgs e)
        {
            ModalPopupExtender1.Hide();
        }
    }
}