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
    public partial class frmFormasPago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        private void BindFormasPago()
        {
            grdFormasPago.DataSource = LogicaFormasPago.ListFormasPago(DateTime.Now.ToString("dd/MM/yyyy"),txtTipo_doc.Text,txtSerie_doc.Text,txtNumero_doc.Text,Convert.ToInt32(txtUnidadnegocio.Text));
            grdFormasPago.DataBind();
        }
        protected void Listarregostros(object sender, EventArgs e)
        {
            BindFormasPago();
        }
        protected void GuardarFormaPago(object sender, EventArgs e)
        {
            EntidadFormasPago entForP = new EntidadFormasPago();
            entForP.fecha_pago = DateTime.Now.ToString("dd/MM/yyyy") + ' ' + DateTime.Now.ToString("HH:mm");
            entForP.monto_pago = Convert.ToDecimal(txtMonto_pago.Text);
            entForP.forma_de_pago = drpFormapago.SelectedItem.Text;
            entForP.tipo_moneda = drpTipomoneda.SelectedItem.Text;
            entForP.numero_documento = txtNumero_doc.Text;
            entForP.serie = txtSerie_doc.Text;
            entForP.tipo_documento = txtTipo_doc.Text;
            entForP.id_unidad_negocio = Convert.ToInt32(txtUnidadnegocio.Text);
            LogicaFormasPago.InsertFormasPago(entForP);
            BindFormasPago();
        }
        protected void BorrarFila(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvRow = (GridViewRow)btn.NamingContainer;
            LogicaFormasPago.DeleteFormasPago(Convert.ToInt32(gvRow.Cells[0].Text));

            //refrescando la lista de registros
            BindFormasPago();
        }
    }
}