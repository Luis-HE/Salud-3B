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
    public partial class frmTomaMuestras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        { 
            lblUsuario.Text = Session["Username"].ToString();
            if(!IsPostBack)
            { 
                lblfechaMuestra.Text = DateTime.Now.ToString("dd/MM/yyyy");
                lblHoraMuestra.Text = DateTime.Now.ToString("HH:mm");
            }
        }
 
 
        protected void BuscarPacienteAdmitido(object sender, EventArgs e)
        {
            if(rdProcInterna.Checked==true)
            {
                grdHistorialAtenciones.DataSource = LogicaModeloBuscaPacAtendido.BuscarPacientesAtendidos(txtBuscaxDni.Text);
                grdHistorialAtenciones.DataBind();
            }
            else if(rdProcexterna.Checked==true)
            {
                grdHistorialAtenciones.DataSource = LogicaModeloBuscaPacAtendido.BuscarPacientesAtendidosExternos(txtBuscaxDni.Text);
                grdHistorialAtenciones.DataBind();
            }
        }
        protected void VerDetalleAtencion(object sender, EventArgs e)
        {  
            LinkButton btnDetalles = (sender as LinkButton);
            GridViewRow row = (btnDetalles.NamingContainer as GridViewRow);
            lblNumeroAdmision.Text = row.Cells[1].Text;
            lblHistoriaClinica.Text = row.Cells[3].Text;
            txtDni_cliente.Text = row.Cells[3].Text;
            txtNombre_cliente.Text = row.Cells[4].Text;
                //================calculando la edad======================
                try
                {
                    DateTime hoy = DateTime.Now;
                    DateTime nace = DateTime.Parse(row.Cells[8].Text);
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
                        lblEdad.Text = anos.ToString();
                        //this->lblmeses->Text = meses.ToString();
                    }
                    else
                    {
                        lblEdad.Text = anos.ToString();
                        //this->lblmeses->Text = meses.ToString();
                    }
                }
                catch (Exception)
                {

                }
            if(rdProcInterna.Checked==true)
            {
                grdDetalleLaboratorio.DataSource = LogicaModeloBuscaPacAtendido.ListDetalleRecetaLaboratorio(txtDni_cliente.Text, Convert.ToInt32(lblNumeroAdmision.Text));
                grdDetalleLaboratorio.DataBind();
            }
            else if(rdProcexterna.Checked==true)
            {
                grdDetalleLaboratorio.DataSource = LogicaModeloBuscaPacAtendido.ListDetalleRecetaLaboratorio(txtDni_cliente.Text);
                grdDetalleLaboratorio.DataBind();
            }            
        }
        protected void CalcularVenta(object sender, GridViewRowEventArgs e)
        {

            double MontoSubTotal = 0;
            double MontoIGV = 0;
            double MontoTotal = 0;
            foreach (GridViewRow gvr in grdDetalleLaboratorio.Rows)
            {
                CheckBox check = (CheckBox)gvr.FindControl("chkAcepta");
                if (check.Checked == true)
                {
                    MontoTotal = MontoTotal + Convert.ToDouble(gvr.Cells[4].Text);
                }

            }
            //    MontoSubTotal = MontoTotal / 1.18;
            //    MontoIGV = MontoTotal - MontoSubTotal;// 0.18 * MontoSubTotal;
            //    lblSubtotalFacBol.Text = MontoSubTotal.ToString("N");
            //    lblIGVFactBol.Text = MontoIGV.ToString("N");
            //    lblTotalFacBol.Text = MontoTotal.ToString("N");

            //    lblNumeroEnLetra.Text = OtherClasses.ClaseConvertidores.NumToLetter(lblTotalFacBol.Text);
            //
        }
        protected void GuardarLaboratorio(object sender, EventArgs e)
        {
            EntidadLaboratorio ent = new EntidadLaboratorio();
            ent.num_historia_clinica = lblHistoriaClinica.Text;
            ent.num_doc_cliente = txtDni_cliente.Text;
            ent.codigo_persona = 1;
            ent.numero_admision = Convert.ToInt32(lblNumeroAdmision.Text);
            ent.fecha_muestra = DateTime.Now.ToString("dd/MM/yyyy HH:mm") ;
            ent.num_informe_lab = "";
            ent.diagnostico = "";
            ent.dni_empleado = txtDni_empleado.Text;
            ent.codigo_persona_pago = 1;
            ent.edad = Convert.ToInt32(lblEdad.Text);
            ent.hora_muestra = lblHoraMuestra.Text;

            if (grdDetalleLaboratorio.Rows.Count == 0)
            {
                return;
            }
            else
            {
                LogicaLaboratorio.InsertarLaboratorio(ent);

                lblIdRegLaboratorio.Text = LogicaLaboratorio.GetLastIdRegLaboratorio(txtDni_cliente.Text, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)[0].id_reg_laboratorio.ToString();

                GuardarLaboratorioDetalle();
                lblMsj.Text = "¡registro exitoso!";
            }

        }
        protected void GuardarLaboratorioDetalle()
        {
            

            foreach (GridViewRow row in grdDetalleLaboratorio.Rows)
            {
                CheckBox check = (CheckBox)row.FindControl("chkAcepta");
                TextBox txtcantidad = (TextBox)row.FindControl("txtCantidad");

                EntidadLaboratorioDetalle entLabDet = new EntidadLaboratorioDetalle();
                entLabDet.id_reg_laboratorio = Convert.ToInt32(lblIdRegLaboratorio.Text);
                entLabDet.numero_historia_clinica = lblHistoriaClinica.Text;
                entLabDet.num_doc_cliente = txtDni_cliente.Text;
                entLabDet.codigo_persona = 1;
                entLabDet.descripcion = row.Cells[2].Text;
                entLabDet.valor_resultado = "";
                if(check.Checked==true)
                {
                    LogicaLaboratorioDetalle.InsertarLaboratorioDetalle(entLabDet);
                }              
            }
        }
        protected void Imprimir(object sender, EventArgs e)
        {

        }
        protected void Limpiar(object sender, EventArgs e)
        {
            grdHistorialAtenciones.DataSource = null;
            grdHistorialAtenciones.DataBind();
            grdDetalleLaboratorio.DataSource = null;
            grdDetalleLaboratorio.DataBind();
            lblNumeroAdmision.Text = "";
            lblHistoriaClinica.Text = "";
            txtDni_cliente.Text = "";
            txtNombre_cliente.Text = "";
            lblfechaMuestra.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblHoraMuestra.Text = DateTime.Now.ToString("HH:mm");
            txtBuscaxDni.Text = "";

        }
        protected void CerrarPantalla(object sender, EventArgs e)
        {
            Response.Redirect("~/frmMenu.aspx");
        }
    }
}