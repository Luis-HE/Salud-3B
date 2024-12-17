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
    public partial class frmTarifario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if(Session["NivelAcceso"].ToString() == "3" )
                //{
                drpCiaAseguradora.DataSource = LogicaProveedorSeguro.ListProveedorSeguro();
                drpCiaAseguradora.DataValueField = "id_cia_seguro";
                drpCiaAseguradora.DataTextField = "nombre_seguro";
                drpCiaAseguradora.DataBind();

                drpGrupo.DataSource = LogicaGrupo.ListGrupo();
                drpGrupo.DataValueField = "id_grupo";
                drpGrupo.DataTextField = "nombre_grupo";
                drpGrupo.DataBind();


                //}
                //else
                //{
                //    Response.Redirect("~/Forms/frmAccesoRestringido.aspx");
                //}


            }
        }
        private void BindDetalleConvenio()
        {
            int cod_categoria=0;
            if(rdProducto.Checked==true)
            {
                cod_categoria = 1;
                grdTarifario.DataSource = LogicaTarifario.ListTarifario(cod_categoria, Convert.ToInt32(drpGrupo.SelectedItem.Value));
                grdTarifario.DataBind();
            }
            if(rdServicio.Checked==true)
            {
                cod_categoria = 2;
                grdTarifario.DataSource = LogicaTarifario.ListTarifario(cod_categoria, Convert.ToInt32(drpCiaAseguradora.SelectedItem.Value), Convert.ToInt32(drpGrupo.SelectedItem.Value));
                grdTarifario.DataBind();
            }
            
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            BindDetalleConvenio();
        }
        protected void ModificarItem(object sender, EventArgs e)
        {
            EntidadDetalleConvenio entdetCon = new EntidadDetalleConvenio();

            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            TextBox txtPrecioActual = (TextBox)row.FindControl("txtPrecio_venta");
            entdetCon.cod_item_catalogo = row.Cells[0].Text;
            entdetCon.porcentaje_cubre = 0;
            entdetCon.precio_venta = Convert.ToDecimal(txtPrecioActual.Text);
            entdetCon.id_ciaSeg = Convert.ToInt32(drpCiaAseguradora.SelectedItem.Value);
            LogicaDetalleConvenio.UpdateDetalleConvenio(entdetCon);
            LogicaCatalogo.ModificarPrecioCatalogo(Convert.ToDecimal(txtPrecioActual.Text), row.Cells[0].Text);

            if (rdProducto.Checked == true)
            {
                //MODIFICAR EN TBL_KARDEX
                LogicaKardex.UpdateKardex(Convert.ToDecimal(txtPrecioActual.Text), row.Cells[0].Text);
            }
            if (rdServicio.Checked == true)
            {
                //MODIFICAR EN TBL_CONVENIO_DETALLE
                LogicaDetalleConvenio.UpdateDetalleConvenio(Convert.ToDecimal(txtPrecioActual.Text), row.Cells[0].Text, Convert.ToInt32(drpCiaAseguradora.SelectedItem.Value));
            }
            BindDetalleConvenio();
        }
        protected void CerrarPantalla(object sender, EventArgs e)
        {
            Response.Redirect("~/frmMenu.aspx");
        }
    }
}