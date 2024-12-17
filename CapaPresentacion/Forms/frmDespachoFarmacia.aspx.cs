using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using CapaEntidad;
using CapaLogicaNegocio;
using System.IO;
using System.Text;
using System.Drawing;

namespace CapaPresentacion.Forms
{
    public partial class frmDespachoFarmacia : System.Web.UI.Page
    {
 
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUsuario.Text = Session["Username"].ToString();
            if (!IsPostBack)
            {
                drpUnidadNegocio.DataSource = LogicaUnidadNegocio.ReadUnidadNegocio();
                drpUnidadNegocio.DataValueField = "id_unidad_negocio";
                drpUnidadNegocio.DataTextField = "nombre_unid_negocio";
                drpUnidadNegocio.DataBind();

                drpTipoDocumento.DataSource = LogicaCorrelativoDocumentos.ListCorrelativoDocumentosSeries(Convert.ToInt32(drpUnidadNegocio.SelectedItem.Value));
                drpTipoDocumento.DataValueField = "tipo_documento";
                drpTipoDocumento.DataTextField = "descripcion";
                drpTipoDocumento.DataBind();
            }

        }
       
        protected void BuscarPacienteAdmitido(object sender, EventArgs e)
        {
            grdHistorialAtenciones.DataSource = LogicaModeloBuscaPacAtendido.BuscarPacientesAtendidos(txtBuscaxDni.Text);
            grdHistorialAtenciones.DataBind();           
           
        }
        protected void VerDetalleAtencion(object sender, EventArgs e)
        {
            txtDni_cliente.Text = txtBuscaxDni.Text;
            LinkButton btnDetalles = (sender as LinkButton);
            GridViewRow row = (btnDetalles.NamingContainer as GridViewRow);

            List<EntidadModeloBuscaPacAtendido> lista = LogicaModeloBuscaPacAtendido.BuscarPacientesAtendidos(txtDni_cliente.Text).Where(numAtencion => numAtencion.numero_admision == Convert.ToInt32(row.Cells[1].Text)).ToList();
            if(lista.Count==0)
            {
                return;
            }
            else
            {
                lblNumAdmision_cobranza.Text = lista[0].numero_admision.ToString();
                txtNombre_cliente.Text = lista[0].paciente;
                txtDir_boleta.Text = lista[0].direccion;
                txtObs_cobranza.Text = lista[0].anotaciones;

                grdDetalleDocumento.DataSource = LogicaModeloBuscaPacAtendido.ListDetalleRecetaMedicamentos(txtDni_cliente.Text, lista[0].numero_admision);
                grdDetalleDocumento.DataBind();
            }
            
        }
         
        protected void GuardarDocumentoContable(object sender, EventArgs e)
        {
            lblSerie_cobranza.Text = drpTipoDocumento.SelectedItem.Text.Substring(0, 4);
            EntidadDocumentoContable entoDocCon = new EntidadDocumentoContable();
            if (drpTipoDocumento.SelectedItem.Value == "03")
            {
                if(txtDni_cliente.Text.Trim().Length==0)
                {
                    return;
                }
                else
                {
                    entoDocCon.cod_persona = 1;
                    entoDocCon.tipo_documento = drpTipoDocumento.SelectedItem.Value;
                    entoDocCon.numero_doc_cliente = txtDni_cliente.Text; //txtDni_boleta.Text;
                    entoDocCon.nombre_cliente = txtNombre_cliente.Text; //txtCliente_boleta.Text;
                    entoDocCon.direccion_cliente = txtDir_boleta.Text;
                }
                
            }
           else if (drpTipoDocumento.SelectedItem.Value == "01")
            {
                if(txtRuc_factura.Text.Trim().Length==0)
                {
                    return;
                }
                else
                {
                    entoDocCon.cod_persona = 2;
                    entoDocCon.tipo_documento = drpTipoDocumento.SelectedItem.Value;
                    entoDocCon.numero_doc_cliente = txtRuc_factura.Text;
                    entoDocCon.nombre_cliente = txtCliente_factura.Text;
                    entoDocCon.direccion_cliente = txtDir_factura.Text;
                }
                
            }
            entoDocCon.serie = lblSerie_cobranza.Text; 
            lblNum_doc_cobranza.Text = LogicaCorrelativoDocumentos.ListCorrelativoDocumento(entoDocCon.tipo_documento, lblSerie_cobranza.Text, Convert.ToInt32(drpUnidadNegocio.SelectedItem.Value))[0].correlativo.ToString();
            entoDocCon.numerodocumento = lblNum_doc_cobranza.Text;
            entoDocCon.tipo_operacion = "Venta interna";
            entoDocCon.fecha_emision = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            entoDocCon.sub_total = Convert.ToDecimal(lblSubtotalFacBol.Text);
            entoDocCon.igv = Convert.ToDecimal(lblIGVFactBol.Text);
            entoDocCon.total = Convert.ToDecimal(lblTotalFacBol.Text);
            entoDocCon.observacion = txtObs_cobranza.Text;
            entoDocCon.descuento_total = Convert.ToDecimal(lblDescuentoFacBol.Text);// ojo revisar si se da en el proceso Convert.ToDecimal(txtDescuento_cobranza.Text);
            entoDocCon.fecha_cobranza = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            entoDocCon.nombre_usuario = lblUsuario.Text; 
            entoDocCon.numero_admision = Convert.ToInt32(lblNumAdmision_cobranza.Text);
            entoDocCon.id_unidad_negocio = Convert.ToInt32(drpUnidadNegocio.SelectedItem.Value);
            entoDocCon.numero_doc_referencia = "";
            entoDocCon.tipo_moneda = "";
            entoDocCon.total_base_imponible = 0;
            entoDocCon.total_isc = 0;
            entoDocCon.total_otro_cargo = 0;
            entoDocCon.total_otro_tributo = 0;
            entoDocCon.tiene_doc_referencia = 0;// ojo cuaneo es nota de credito o debito
            entoDocCon.tipo_doc_referencia = "";
            entoDocCon.serie_doc_referencia = "";
            entoDocCon.condicion_pago = "";
            entoDocCon.numero_orden_compra = "";
            entoDocCon.numero_guia_remision = "";
            entoDocCon.mensaje_detraccion = 0;
            entoDocCon.transferencia_gratuita = 0;
            entoDocCon.documento_relacionado = 0;
            entoDocCon.descuento_global = 0;
            entoDocCon.otro_cargo_global = 0;
            entoDocCon.anticipo = 0;
            if(grdDetalleDocumento.Rows.Count==0)
            {
                return;
            }
            else
            {
                LogicaDocumentoContable.CreateDocumentoContable(entoDocCon);
                LogicaCorrelativoDocumentos.UpdateCorrelativoDocumento(entoDocCon.tipo_documento, lblSerie_cobranza.Text, Convert.ToInt32(drpUnidadNegocio.SelectedItem.Value));
                GuardarDetalleDocumentoContable();
                lblMsj_cobranza.Text = "Registro Ok!";
                btnGuardarDocContable.Enabled = false;
                WriteCabeceraDocumento();
            }
            
        }       
        protected void CalcularVenta(object sender, GridViewRowEventArgs e)
        {
            
            double MontoSubTotal = 0;
            double MontoIGV = 0;
            double MontoTotal = 0;
            foreach (GridViewRow gvr in grdDetalleDocumento.Rows)
            {
                CheckBox check = (CheckBox)gvr.FindControl("chkAcepta");
                if (check.Checked==true)
                {
                    MontoTotal = MontoTotal + Convert.ToDouble(gvr.Cells[4].Text);
                }
                
            }
            MontoSubTotal = MontoTotal / 1.18;
            MontoIGV = MontoTotal - MontoSubTotal;// 0.18 * MontoSubTotal;
            lblSubtotalFacBol.Text = MontoSubTotal.ToString("N");
            lblIGVFactBol.Text = MontoIGV.ToString("N");
            lblTotalFacBol.Text = MontoTotal.ToString("N");

            lblNumeroEnLetra.Text = OtherClasses.ClaseConvertidores.NumToLetter(lblTotalFacBol.Text);
        }
        protected void ConfirmarMedicamento(object sender, EventArgs e)
        {
            foreach(GridViewRow row in grdDetalleDocumento.Rows)
            {
                CheckBox check = (CheckBox)row.FindControl("chkAcepta");
                if(check.Checked==true)
                {
                    LogicaConsultorioRecetaMedicaDetalle.ActualizarEstadoItemReceta(row.Cells[0].Text, Convert.ToInt32(lblNumAdmision_cobranza.Text));
                    lblMsj_cobranza.Text = "Ok!";
                }                
            }
            
         }
        protected void GuardarDetalleDocumentoContable()
        {
            EntidadDetalleDocumentoContable entDetDocCon = new EntidadDetalleDocumentoContable();
            EntidadMovimientoCatalogo entMovCatalogo = new EntidadMovimientoCatalogo();
            
            foreach (GridViewRow row in grdDetalleDocumento.Rows)
            {
                CheckBox check = (CheckBox)row.FindControl("chkAcepta");
                TextBox txtcantidad = (TextBox)row.FindControl("txtCantidad");

                entDetDocCon.numero_documento = lblNum_doc_cobranza.Text;
                entDetDocCon.serie = lblSerie_cobranza.Text;
                entDetDocCon.tipo_documento = drpTipoDocumento.SelectedItem.Value;
                entMovCatalogo.tipo_documento = drpTipoDocumento.SelectedItem.Value;

                entDetDocCon.cod_item_catalogo = row.Cells[0].Text;
                entDetDocCon.descrip_detalle =  row.Cells[2].Text; // revisar para palabras con ACENTOS, lo registra mal
                entDetDocCon.valor_venta = Convert.ToDecimal(row.Cells[4].Text);
                entDetDocCon.descuento_unit = 0; // revisar si suceden en el proceso
                entDetDocCon.estado = "Pagado";
                entDetDocCon.cantidad = Convert.ToInt32(txtcantidad.Text);
                entDetDocCon.id_grupo = Convert.ToInt32(row.Cells[5].Text);
                entDetDocCon.id_clase = Convert.ToInt32(row.Cells[6].Text);
                entDetDocCon.id_unidad_negocio = Convert.ToInt32(drpUnidadNegocio.SelectedItem.Value);
                entDetDocCon.tipo_afectacion_igv = "";
                entDetDocCon.codigo_producto_sunat = "";
                entDetDocCon.porcentaje_descuento = 0;
                entDetDocCon.valor_unitario = 0;
                entDetDocCon.valor_igv = 0;
                entDetDocCon.valor_isc = 0;
                entDetDocCon.porcentaje_isc = 0;
                entDetDocCon.otro_cargo = 0;
                entDetDocCon.porcentaje_otro_cargo = 0;
                entDetDocCon.otro_tributo = 0;
                entDetDocCon.porcentaje_otro_tributo = 0;
                entDetDocCon.importe_total = 0;

                if (check.Checked==true)
                {
                    LogicaDetalleDocumentoContable.InsertDetalleDocumentoContable(entDetDocCon);
                }
                               
                ////updating Kardex
                //LogicaKardex.UpdateKardex(Convert.ToInt32(row.Cells[1].Text) * -1,Convert.ToDecimal(row.Cells[3].Text), row.Cells[0].Text, 1);
                ////insert Movimiento Catalgogo               
                //entMovCatalogo.cod_item_catalogo = row.Cells[0].Text;
                //entMovCatalogo.fecha_movimiento = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                //entMovCatalogo.cantidad = Convert.ToInt32(row.Cells[1].Text);
                //entMovCatalogo.codigo_usuario = lblUsuario.Text;
                //entMovCatalogo.precio_entrada = Convert.ToDecimal(row.Cells[3].Text);
                //entMovCatalogo.precio_venta = Convert.ToDecimal(row.Cells[3].Text);
                //entMovCatalogo.codigo_almacen = 1; // ojo revisar cuando hay varios almacenes
                //entMovCatalogo.numero_documento = lblSerie_cobranza.Text + "-" + Convert.ToInt32(lblNum_doc_cobranza.Text).ToString("00000000");
                //entMovCatalogo.tipo_movimiento = "Salida";
                //entMovCatalogo.motivo = "Venta de Artículos"; 
                //entMovCatalogo.ruc_proveedor = "10000000000";// ojo revisar para metodos logisticos(despachos)
                //entMovCatalogo.cod_persona_pago = 2;// ojo revisar para metodos logisticos(despachos)
                //entMovCatalogo.numero_lote = "";// ojo revisar para metodos logisticos(despachos)
                //entMovCatalogo.fecha_vence = "";
                //entMovCatalogo.id_grupo = Convert.ToInt32(row.Cells[5].Text);
                //entMovCatalogo.id_clase = Convert.ToInt32(row.Cells[6].Text);
                //entMovCatalogo.id_unidad_negocio = 1;
                //LogicaMovimientoCatalogo.InsertMovimientoCatalogo(entMovCatalogo);
 
            }
            WriteDetalleDocumento();           
        }
        private void CleanFields()
        {
            //clean grdDetalleDocumento
            ViewState["Row"] = null;
            grdDetalleDocumento.DataSource = ViewState["Row"];
            grdDetalleDocumento.DataBind();
            //clean others fields
            lblSubtotalFacBol.Text = "0.0";
            lblIGVFactBol.Text = "0.0";
            lblTotalFacBol.Text = "0.0";

            txtDni_cliente.Text = "";
            txtNombre_cliente.Text="";
            txtDir_boleta.Text = "";
            txtObs_cobranza.Text = "";

            lblNumAdmision_cobranza.Text = "";

            txtRuc_factura.Text = "";
            txtCliente_factura.Text = "";
            txtDir_factura.Text = "";
            lblNum_doc_cobranza.Text = "";
            lblNumeroEnLetra.Text = "";
            txtBuscaxDni.Text = "";
            grdHistorialAtenciones.DataSource = null;
            grdHistorialAtenciones.DataBind();
            btnGuardarDocContable.Enabled = true; 
        }
        private void WriteCabeceraDocumento()
        {
            //List<EntidadFacturaElectronicaCabecera> lstCabecera = new List<EntidadFacturaElectronicaCabecera>();
            //lstCabecera = LogicaFacturaElectronicaCabecera.ListFacElectCabecera(lblNum_doc_cobranza.Text, "03", lblSerie_cobranza.Text);
            //string webRootPath = Server.MapPath("~");
            //string fileName = "20552144415" + "-03" + "-" + lblSerie_cobranza.Text + "-" + Convert.ToInt32(lblNum_doc_cobranza.Text).ToString("00000000");
            //string filePath = Path.GetFullPath(Path.Combine(webRootPath, "D:/SFS_v1.2/sunat_archivos/sfs/DATA/" + fileName + ".CAB"));
            //using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
            //{
            //    foreach (var dataList in lstCabecera)
            //    {

            //        sw.Write(dataList.tipo_operacion + "|" +
            //            dataList.fecha_emision + "|" +
            //            dataList.hora_emision + "|" +
            //            dataList.fecha_vencimiento + "|" +
            //            dataList.cod_domicilio_fiscal + "|" +
            //            dataList.tipo_doc_cliente + "|" +
            //            dataList.numero_doc_cliente + "|" +
            //            dataList.nombre_cliente + "|" +
            //            dataList.tipo_moneda + "|" +
            //            dataList.suma_tributo + "|" +
            //            dataList.total_valor_venta + "|" +
            //            dataList.total_precio_venta + "|" +
            //            dataList.total_descuento + "|" +
            //            dataList.suma_otro_cargo + "|" +
            //            dataList.total_anticipo + "|" +
            //            dataList.importe_total_venta + "|" +
            //            dataList.version_ubl + "|" +
            //            dataList.customizacion_documento + "|"
            //            );

            //    }
            //}

        }
        private void WriteDetalleDocumento()
        {
            //List<EntidadFacturaElectronicaDetalle> listaDetalle = new List<EntidadFacturaElectronicaDetalle>();
            //listaDetalle = LogicaFacturaElectronicaDetalle.ListFacturaElectronicaDetalle(lblNum_doc_cobranza.Text, "03", lblSerie_cobranza.Text);
            //string webRootPath = Server.MapPath("~");
            //string fileName = "20552144415" + "-03" + "-" + lblSerie_cobranza.Text + "-" + Convert.ToInt32(lblNum_doc_cobranza.Text).ToString("00000000");
            //string filePath = Path.GetFullPath(Path.Combine(webRootPath, "D:/SFS_v1.2/sunat_archivos/sfs/DATA/" + fileName + ".DET"));
            //using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
            //{
            //    for (int i = 0; i < listaDetalle.Count; i++)
            //    {
            //        sw.Write(listaDetalle[i].cod_unid_medida + "|" +
            //            listaDetalle[i].cant_unidades + "|" +
            //            listaDetalle[i].cod_producto + "|" +
            //            listaDetalle[i].cod_producto_sunat + "|" +
            //            listaDetalle[i].descrip_item_catalogo + "|" +
            //            listaDetalle[i].valor_unitario + "|" +
            //            listaDetalle[i].sumatoria_tributo_item + "|" +
            //            listaDetalle[i].cod_tipo_tributo_igv + "|" +
            //            listaDetalle[i].monto_igv + "|" +
            //            listaDetalle[i].base_imponible_item + "|" +
            //            listaDetalle[i].nombre_tributo_item + "|" +
            //            listaDetalle[i].cod_tipo_tributo_item + "|" +
            //            listaDetalle[i].afectacion_igv_item + "|" +
            //            listaDetalle[i].porcentaje_igv + "|" +
            //            listaDetalle[i].cod_tributo_isc + "|" +
            //            listaDetalle[i].monto_isc_item + "|" +
            //            listaDetalle[i].base_imponible_isc_item + "|" +
            //            listaDetalle[i].nombre_tributo_isc_item + "|" +
            //            listaDetalle[i].cod_tipo_tributo_isc_item + "|" +
            //            listaDetalle[i].tipo_sistema_isc + "|" +
            //            listaDetalle[i].porcentaje_isc + "|" +
            //            listaDetalle[i].cod_tipo_tributo_otro + "|" +
            //            listaDetalle[i].monto_tributo_otro_item + "|" +
            //            listaDetalle[i].base_inponible_tributo_otro_item + "|" +
            //            listaDetalle[i].nombre_tributo_otro_item + "|" +
            //            listaDetalle[i].cod_tipo_tributo_otro_item + "|" +
            //            listaDetalle[i].porcentaje_tributo_otro_item + "|" +
            //            listaDetalle[i].precio_venta_unitario + "|" +
            //            listaDetalle[i].valor_venta_item + "|" +
            //            listaDetalle[i].valor_referencial_item + "|" + "\r\n"
            //            );
            //    }
            //}
        }
        protected void ListarReporteVentasFarmacia(object sender, EventArgs e)
        {
            grdreporteVentasFarmacia.DataSource = LogicaReporteVentas.ListReporteVentasFarmacia(txtfechaIni.Text,txtfechaFin.Text);
            grdreporteVentasFarmacia.DataBind();
        }
        protected void CalcularVentaTotalReporteFarmacia(object sender, GridViewRowEventArgs e)
        {
            double ventaTotal = 0;
            foreach (GridViewRow gvr in grdreporteVentasFarmacia.Rows)
            {
                ventaTotal = ventaTotal + Convert.ToDouble(gvr.Cells[3].Text);

            }
            
            lblTotalVenta.Text = ventaTotal.ToString();
        }
        protected void ExportarReporteVentas(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=ReporteVentasFarmacia.xls");//ojo revisar solo funciona con .XLS
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                grdreporteVentasFarmacia.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in grdreporteVentasFarmacia.HeaderRow.Cells)
                {
                    cell.BackColor = grdreporteVentasFarmacia.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in grdreporteVentasFarmacia.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = grdreporteVentasFarmacia.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = grdreporteVentasFarmacia.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                grdreporteVentasFarmacia.RenderControl(hw);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        protected void BuscaMedicamentoConfirmado(object sender, EventArgs e)
        {
            txtDni_cliente.Text = txtBuscaxDni.Text;
            Button btnMedicaento = (sender as Button);
            GridViewRow row = (btnMedicaento.NamingContainer as GridViewRow);

            List<EntidadModeloBuscaPacAtendido> lista = LogicaModeloBuscaPacAtendido.BuscarPacientesAtendidos(txtDni_cliente.Text).Where(numAtencion => numAtencion.numero_admision == Convert.ToInt32(row.Cells[1].Text)).ToList();
            if (lista.Count == 0)
            {
                return;
            }
            else
            {
                lblNumAdmision_cobranza.Text = lista[0].numero_admision.ToString();
                txtNombre_cliente.Text = lista[0].paciente;
                txtDir_boleta.Text = lista[0].direccion;
                txtObs_cobranza.Text = lista[0].anotaciones;

                grdDetalleDocumento.DataSource = LogicaModeloBuscaPacAtendido.ListDetalleRecetaMedicamentosConfirmados(txtDni_cliente.Text, lista[0].numero_admision);
                grdDetalleDocumento.DataBind();
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        protected void NuevoDespachoFarmacia(object sender, EventArgs e)
        {
            btnGuardarDocContable.Enabled = true;
            CleanFields();
        }
        protected void CerrarPantalla(object sender, EventArgs e)
        {
            Response.Redirect("~/frmMenu.aspx");
        }
        //Impriiendo Tickets
        protected void ImprimirDocumentosContables(object sender, EventArgs e)
        {
            PrintClass.CrearTicket ticket = new PrintClass.CrearTicket();

            ticket.TextoCentro("FUNDACION SAN FELIPE");
            // ticket.TextoIzquierdo("EXPEDIDO EN:  LOCAL PRINCIPAL");
            ticket.TextoIzquierdo("RUC: 20101260292");
            ticket.TextoIzquierdo("DIRECCIÓN: Cal. Nucleo de Servicio 9 Mz A. Lt. 4 LIMA - ATE");
            ticket.TextoIzquierdo("TELÉFONO: 345-7565");
            ticket.TextoIzquierdo("CELULAR / WHATSAPP: 991340845");
            //ticket.TextoIzquierdo("E-MAIL:  policlinoc@gmail.com");
            ticket.TextoIzquierdo("");
            ticket.TextoExtremos("N° DE COMPROBANTE: ", String.Concat(lblSerie_cobranza.Text, "-", lblNum_doc_cobranza.Text));
            ticket.lineasAsteriscos();
            if (drpTipoDocumento.SelectedItem.Value == "03")
            {
                ticket.TextoIzquierdo(String.Concat("CLIENTE: ", txtNombre_cliente.Text));
            }
            if (drpTipoDocumento.SelectedItem.Value == "01")
            {
                ticket.TextoIzquierdo(String.Concat("RUC: ", txtRuc_factura.Text));
                ticket.TextoIzquierdo(String.Concat("CLIENTE: ", txtCliente_factura.Text));
            }
            ticket.TextoIzquierdo("");
            ticket.TextoIzquierdo("FECHA Y HORA : " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            ticket.lineasAsteriscos();

            ticket.EncabezadoVenta();
            ticket.lineasAsteriscos();
            foreach (GridViewRow row in grdDetalleDocumento.Rows)
            {
                ticket.AgregaArticulo(row.Cells[2].Text, Convert.ToInt32(row.Cells[1].Text), Convert.ToDecimal(row.Cells[3].Text), Convert.ToDecimal(row.Cells[4].Text));
                //ticket.AgregaArticulo("Articulo B", 1, 10, 10);
                //ticket.AgregaArticulo("Articulo que se comprtoe en plaza ver aucaon etaba en lima\nluego se fue de lima para huarmaca", 1, 30, 30);

            }
            ticket.lineasIgual();
            if (drpTipoDocumento.SelectedItem.Value == "03")
            {
                ticket.AgregarTotales("       TOTAL.....", Convert.ToDecimal(lblTotalFacBol.Text));
            }
            if (drpTipoDocumento.SelectedItem.Value == "01")
            {
                ticket.AgregarTotales("       SUBTOTAL.....", Convert.ToDecimal(lblSubtotalFacBol.Text));
                ticket.AgregarTotales("       IGV.....", Convert.ToDecimal(lblIGVFactBol.Text));
                ticket.AgregarTotales("       TOTAL.....", Convert.ToDecimal(lblTotalFacBol.Text));
            }

            //ticket.TextoIzquierdo(""); 
            //ticket.AgregarTotales("       EFECTIVO.....", 200);
            // ticket.AgregarTotales("       VUELTO.....", 90);

            // ticket.TextoIzquierdo("");
            //ticket.TextoIzquierdo(String.Concat("Cantidad de Items: ", grdDetalleDocumento.Rows.Count.ToString())); 
            ticket.TextoIzquierdo("");
            ticket.TextoIzquierdo(String.Concat("CAJERA: ", lblUsuario.Text));
            ticket.TextoCentro("¡GRACIAS POR SU COMPRA!");
            ticket.TextoIzquierdo("");
            ticket.TextoCentro("Vea su documento electrónico en:");
            ticket.TextoCentro("www.dmz.com.pe/documentos");
            //ticket.CortaTicket();

            ticket.ImprimirTicket("Microsoft XPS Document Writer"); // ("TICKETERA_MZB1");
        }
    }
}