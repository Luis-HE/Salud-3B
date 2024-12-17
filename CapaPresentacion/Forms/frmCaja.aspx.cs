using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Text;

using CapaEntidad;
using CapaLogicaNegocio;
using System.Drawing;
 

namespace CapaPresentacion.Forms
{ 
    public partial class frmCaja : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
             lblUsuario.Text = Session["Username"].ToString();

            if(!IsPostBack)
            {
                SetGridView();

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
        
        //====================Caja================
        protected void BuscarPacienteAdmitido(object sender, EventArgs e)
        {
            List<EntidadModeloBuscaPacAdmitido> lst = new List<EntidadModeloBuscaPacAdmitido>();
            lst = LogicaModeloBuscaPacAdmitido.ListPacientesAdmitidos(txtDni_cliente.Text,DateTime.Now.ToString("dd/MM/yyyy"));

            grdDetalleDocumento.DataSource = lst;
            grdDetalleDocumento.DataBind();

            if(lst.Count==0)
            {
                txtNombre_cliente.Text = "xxxxx No hay registro, verifique xxxxxxx";
            }
            else
            {
                txtNombre_cliente.Text = lst[0].paciente;
                txtDir_boleta.Text = lst[0].direccion;
                lblNumAdmision_cobranza.Text = lst[0].numero_admision.ToString();
                txtObs_cobranza.Text = lst[0].observacion;
            }

           
        }
        protected void GuardarDocumentoContable(object sender, EventArgs e)
        {
            lblSerie_cobranza.Text = drpTipoDocumento.SelectedItem.Text.Substring(0,4);

            EntidadDocumentoContable entoDocCon = new EntidadDocumentoContable();
            if (drpTipoDocumento.SelectedItem.Value == "03")
            {
                if (txtDni_cliente.Text.Trim().Length == 0)
                {
                    return;
                }
                else
                {
                    entoDocCon.cod_persona = 1;
                    entoDocCon.tipo_documento = drpTipoDocumento.SelectedItem.Value;
                    entoDocCon.numero_doc_cliente = txtDni_cliente.Text;
                    entoDocCon.nombre_cliente = txtNombre_cliente.Text;
                    entoDocCon.direccion_cliente = txtDir_boleta.Text;
                }

            }
            else if (drpTipoDocumento.SelectedItem.Value == "01")
            {
                if (txtRuc_factura.Text.Trim().Length == 0)
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
            lblNum_doc_cobranza.Text = LogicaCorrelativoDocumentos.ListCorrelativoDocumento(drpTipoDocumento.SelectedItem.Value, lblSerie_cobranza.Text, Convert.ToInt32(drpUnidadNegocio.SelectedItem.Value))[0].correlativo.ToString();
            entoDocCon.numerodocumento = lblNum_doc_cobranza.Text;
            entoDocCon.tipo_operacion = "Venta interna";
            entoDocCon.fecha_emision = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            entoDocCon.sub_total = Convert.ToDecimal(lblSubtotalFacBol.Text);
            entoDocCon.igv = Convert.ToDecimal(lblIGVFactBol.Text);
            entoDocCon.total = Convert.ToDecimal(lblTotalFacBol.Text);
            entoDocCon.observacion = txtObs_cobranza.Text;
            entoDocCon.descuento_total = Convert.ToDecimal(txtDescuento.Text);// ojo revisar si se da en el proceso Convert.ToDecimal(txtDescuento_cobranza.Text);
            entoDocCon.fecha_cobranza = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            entoDocCon.nombre_usuario = lblUsuario.Text; // ojo revisar en el proceso si rotan frecuentemente a las cajeras
            if (TabContainer1.ActiveTabIndex == 0)
            {
                entoDocCon.numero_admision = Convert.ToInt32(lblNumAdmision_cobranza.Text);
            }
            else if (TabContainer1.ActiveTabIndex == 1)
            {
                entoDocCon.numero_admision = 0;
            }
            else
            {
                return;
            }

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

            if (TabContainer1.ActiveTabIndex == 0)
            {
                if (grdDetalleDocumento.Rows.Count == 0)
                {
                    return;
                }
                else
                {
                     LogicaDocumentoContable.CreateDocumentoContableAdmin(entoDocCon);
                }

            }
            else if (TabContainer1.ActiveTabIndex == 1)
            {
                if (grdDetalleVenta.Rows.Count == 0)
                {
                    return;
                }
                else
                {
                     LogicaDocumentoContable.CreateDocumentoContable(entoDocCon);
                }

            }

            LogicaCorrelativoDocumentos.UpdateCorrelativoDocumento(drpTipoDocumento.SelectedItem.Value, lblSerie_cobranza.Text, Convert.ToInt32(drpUnidadNegocio.SelectedItem.Value));
            GuardarDetalleDocumentoContable();
            lblMsj_cobranza.Text = "Ok!";
            btnGuardarDocContable.Enabled = false;

            // LogicaAsientoContable.InsertAsientoContable(entoDocCon.tipo_documento, lblSerie_cobranza.Text + "-" + Convert.ToInt32(lblNum_doc_cobranza.Text).ToString("00000000"));
            // LogicaLibroMayor.InsertLibroMayor(entoDocCon.tipo_documento, lblSerie_cobranza.Text + "-" + Convert.ToInt32(lblNum_doc_cobranza.Text).ToString("00000000"));
            WriteDocumentoSUNAT();
        }

        protected void GuardarDetalleDocumentoContable()
        {
            EntidadDetalleDocumentoContable entDetDocCon = new EntidadDetalleDocumentoContable();
            if(TabContainer1.ActiveTabIndex==0)
            {
                foreach (GridViewRow row in grdDetalleDocumento.Rows)
                {
                    entDetDocCon.numero_documento = lblNum_doc_cobranza.Text;
                    entDetDocCon.serie = lblSerie_cobranza.Text;
                    entDetDocCon.tipo_documento = drpTipoDocumento.SelectedItem.Value;

                    entDetDocCon.cod_item_catalogo = row.Cells[0].Text;
                    entDetDocCon.descrip_detalle = row.Cells[2].Text; // revisar para palabras con ACENTOS, lo registra mal
                    entDetDocCon.valor_venta = Convert.ToDecimal(row.Cells[4].Text);
                    entDetDocCon.descuento_unit = 0; // revisar si suceden en el proceso
                    entDetDocCon.estado = "Pagado";
                    entDetDocCon.cantidad = Convert.ToInt32(row.Cells[1].Text);
                    entDetDocCon.id_grupo = Convert.ToInt32(row.Cells[5].Text);//Convert.ToInt32(row.Cells[5].Text); ojo si lo pinto el la grilla, no debe imorimirse. mejor jalarlo del List<EntidadModeloBuscaPacAdmitido>, previo hacerlo public
                    entDetDocCon.id_clase = Convert.ToInt32(row.Cells[6].Text);
                    entDetDocCon.id_unidad_negocio = Convert.ToInt32(drpUnidadNegocio.SelectedItem.Value);
                    entDetDocCon.tipo_afectacion_igv = "";
                    entDetDocCon.codigo_producto_sunat = "";
                    entDetDocCon.porcentaje_descuento = 0;
                    entDetDocCon.valor_unitario = Convert.ToDecimal(row.Cells[3].Text); 
                    entDetDocCon.valor_igv = 0;
                    entDetDocCon.valor_isc = 0;
                    entDetDocCon.porcentaje_isc = 0;
                    entDetDocCon.otro_cargo = 0;
                    entDetDocCon.porcentaje_otro_cargo = 0;
                    entDetDocCon.otro_tributo = 0;
                    entDetDocCon.porcentaje_otro_tributo = 0;
                    entDetDocCon.importe_total = 0;

                    LogicaDetalleDocumentoContable.InsertDetalleDocumentoContable(entDetDocCon);
                     
                }
            }
            else if (TabContainer1.ActiveTabIndex == 1)
            {
                foreach (GridViewRow rowVenta in grdDetalleVenta.Rows)
                {
                    entDetDocCon.numero_documento = lblNum_doc_cobranza.Text;
                    entDetDocCon.serie = lblSerie_cobranza.Text;
                    entDetDocCon.tipo_documento = drpTipoDocumento.SelectedItem.Value;

                    entDetDocCon.cod_item_catalogo = rowVenta.Cells[1].Text;
                    entDetDocCon.descrip_detalle = rowVenta.Cells[3].Text; // revisar para palabras con ACENTOS, lo registra mal
                    entDetDocCon.valor_venta = Convert.ToDecimal(rowVenta.Cells[5].Text);
                    entDetDocCon.descuento_unit = 0; // revisar si suceden en el proceso
                    entDetDocCon.estado = "Pagado";
                    entDetDocCon.cantidad = Convert.ToInt32(rowVenta.Cells[2].Text);
                    entDetDocCon.id_grupo = Convert.ToInt32(rowVenta.Cells[6].Text);//Convert.ToInt32(row.Cells[5].Text); ojo si lo pinto el la grilla, no debe imorimirse. mejor jalarlo del List<EntidadModeloBuscaPacAdmitido>, previo hacerlo public
                    entDetDocCon.id_clase = Convert.ToInt32(rowVenta.Cells[7].Text);
                    entDetDocCon.id_unidad_negocio = Convert.ToInt32(drpUnidadNegocio.SelectedItem.Value);
                    entDetDocCon.tipo_afectacion_igv = "";
                    entDetDocCon.codigo_producto_sunat = "";
                    entDetDocCon.porcentaje_descuento = 0;
                    entDetDocCon.valor_unitario = Convert.ToDecimal(rowVenta.Cells[4].Text);
                    entDetDocCon.valor_igv = 0;
                    entDetDocCon.valor_isc = 0;
                    entDetDocCon.porcentaje_isc = 0;
                    entDetDocCon.otro_cargo = 0;
                    entDetDocCon.porcentaje_otro_cargo = 0;
                    entDetDocCon.otro_tributo = 0;
                    entDetDocCon.porcentaje_otro_tributo = 0;
                    entDetDocCon.importe_total = 0;

                    LogicaDetalleDocumentoContable.InsertDetalleDocumentoContable(entDetDocCon);
                     
                }
            }
            else
            {
                return;
            }
               
        }

        protected void CalcularVenta(object sender, GridViewRowEventArgs e)
        {
            double MontoSubTotal = 0;
            double MontoIGV = 0;
            double MontoTotal = 0;
            //double Descuento = 0;
            foreach (GridViewRow gvr in grdDetalleDocumento.Rows)
            {
                MontoTotal = MontoTotal + Convert.ToDouble(gvr.Cells[4].Text);
            }

            MontoSubTotal = MontoTotal / 1.18;
            MontoIGV = MontoTotal - MontoSubTotal;// 0.18 * MontoSubTotal;

            lblSubtotalFacBol.Text = MontoSubTotal.ToString("N");
            lblIGVFactBol.Text = MontoIGV.ToString("N");
            lblTotalFacBol.Text = MontoTotal.ToString("N");
        
            lblNumeroEnLetra.Text = OtherClasses.ClaseConvertidores.NumToLetter(lblTotalFacBol.Text);
        }
        private void WriteDocumentoSUNAT()
        {
            //=== trayendo la CABECERA 
            List<EntidadCabeceraSUNAT> lstCabecera = new List<EntidadCabeceraSUNAT>();
            lstCabecera = LogicaCabeceraSUNAT.ListarCabecera(lblNum_doc_cobranza.Text, lblSerie_cobranza.Text, drpTipoDocumento.SelectedItem.Value);
            //===trayendo el DETALLE
            List<EntidadDetalleSUNAT> lstDetalle = new List<EntidadDetalleSUNAT>();
            lstDetalle = LogicaDetalleSUNAT.listarDetalle(lblNum_doc_cobranza.Text, lblSerie_cobranza.Text, drpTipoDocumento.SelectedItem.Value);
            //===trayendo el CLIENTE
            List<EntidadClienteSUNAT> lstClienteSunat = new List<EntidadClienteSUNAT>();
            lstClienteSunat = LogicaClienteSUNAT.listarClienteSUNAT(lblNum_doc_cobranza.Text, lblSerie_cobranza.Text, drpTipoDocumento.SelectedItem.Value);


            string fileName = "20101260292" + "0000" + Convert.ToInt32(lblNum_doc_cobranza.Text).ToString("0000000000") + DateTime.Now.ToString("ddMMyyyy") + drpTipoDocumento.SelectedItem.Value + "210";
            string filePath = "C:/inbox/" + fileName + ".txt";
            using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
            {
                foreach (var dataListCab in lstCabecera)
                {
                    sw.Write(dataListCab.col1 + "|" +
                    dataListCab.col2 + "|" +
                    dataListCab.col3 + "|" +
                    dataListCab.col4 + "|" +
                    dataListCab.col5 + "|" +
                    dataListCab.col6 + "|" +
                    dataListCab.col7 + "|" +
                    dataListCab.col8 + "|" +
                    dataListCab.col9 + "|" +
                    dataListCab.col10 + "|" +
                    dataListCab.col11 + "|" +
                    dataListCab.col12 + "|" +
                    dataListCab.col13 + "|" +
                    dataListCab.col14 + "|" +
                    dataListCab.col15 + "|" +
                    dataListCab.col16 + "|" +
                    dataListCab.col17 + "|" +
                    dataListCab.col18 + "|" +
                    dataListCab.col19 + "|" +
                    dataListCab.col20 + "|" +
                    dataListCab.col21 + "|" +
                    dataListCab.col22 + "|" +
                    dataListCab.col23 + "|" +
                    dataListCab.col24 + "|" +
                    dataListCab.col25 + "|" +
                    dataListCab.col26 + "|" +
                    dataListCab.col27 + "|" +
                    dataListCab.col28 + "|" +
                    dataListCab.col29 + "|" +
                    dataListCab.col30 + "|" +
                    dataListCab.col31 + "|" +
                    dataListCab.col32 + "|" +
                    dataListCab.col33 + "|" +
                    dataListCab.col34 + "|" +
                    dataListCab.col35 + "|" +
                    dataListCab.col36 + "|" +
                    dataListCab.col37 + "|" +
                    dataListCab.col38 + "|" +
                    dataListCab.col39 + "|" +
                    dataListCab.col40 + "|" +
                    dataListCab.col41 + "|" +
                    dataListCab.col42 + "|" +
                    dataListCab.col43 + "|" +
                    dataListCab.col44 + "|" +
                    dataListCab.col45 + "|" +
                    dataListCab.col46 + "|" +
                    dataListCab.col47 + "|" +
                    dataListCab.col48 + "|" +
                    dataListCab.col49 + "|"  );                    
                }
                sw.Write(Environment.NewLine);
                foreach (var dataListDet in lstDetalle)
                {
                    sw.Write(dataListDet.col1 + "|" +
                    dataListDet.col2 + "|" +
                    dataListDet.col3 + "|" +
                    dataListDet.col4 + "|" +
                    dataListDet.col5 + "|" +
                    dataListDet.col6 + "|" +
                    dataListDet.col7 + "|" +
                    dataListDet.col8 + "|" +
                    dataListDet.col9 + "|" +
                    dataListDet.col10 + "|" +
                    dataListDet.col11 + "|" +
                    dataListDet.col12 + "|" +
                    dataListDet.col13 + "|" +
                    dataListDet.col14 + "|" +
                    dataListDet.col15 + "|" +
                    dataListDet.col16 + "|" +
                    dataListDet.col17 + "|" +
                    dataListDet.col18 + "|" +
                    dataListDet.col19 + "|" +
                    dataListDet.col20 + "|" );
                    sw.Write(Environment.NewLine);
                }
           
                foreach (var dateListClient in lstClienteSunat)
                {
                    sw.Write(dateListClient.col1 + "|" +
                    dateListClient.col2 + "|" +
                    dateListClient.col3 + "|" +
                    dateListClient.col4 + "|" +
                    dateListClient.col5 + "|" +
                    dateListClient.col6 + "|" +
                    dateListClient.col7 + "|" +
                    dateListClient.col8 + "|" +
                    dateListClient.col9 + "|" +
                    dateListClient.col10 + "|" );
                }
               // sw.Write(Environment.NewLine);
                //====aqui FORMAS DE PAG0============
            }
        }
        private void WriteCabeceraDocumento()
        {

            //List<EntidadFacturaElectronicaCabecera> lstCabecera = new List<EntidadFacturaElectronicaCabecera>();
            //lstCabecera = LogicaFacturaElectronicaCabecera.ListFacElectCabecera(lblNum_doc_cobranza.Text, drpTipoDocumento.SelectedItem.Value, lblSerie_cobranza.Text);
            //string webRootPath = Server.MapPath("~");
            //string fileName = "20101260292" + "0001" + Convert.ToInt32(lblNum_doc_cobranza.Text).ToString("0000000000") + DateTime.Now.ToString("ddMMyyyy") + drpTipoDocumento.SelectedItem.Value + "210";
            //// string filePath = Path.GetFullPath(Path.Combine(webRootPath, "C:/inbox/" + fileName + ".txt"));
            //string filePath = "C:/inbox/" + fileName + ".txt";
            //using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
            //{
            //    foreach (var dataList in lstCabecera)
            //    {
            //        sw.Write(dataList.version_doc + "|" +
            //        dataList.id_documento + "|" +
            //        dataList.tipo_documento + "|" +
            //        dataList.tipo_operacion + "|" +
            //        dataList.ruc_emisor + "|" +
            //        dataList.cod_sucursal + "|" +
            //        dataList.fecha_emision + "|" +
            //        dataList.fecha_vence + "|" +
            //        dataList.tipo_moneda + "|" +
            //        dataList.subtotal + "|" +
            //        dataList.descuento_total + "|" +
            //        dataList.base_imponible + "|" +
            //        dataList.isc + "|" +
            //        dataList.igv + "|" +
            //        dataList.total_otro_cargo + "|" +
            //        dataList.total_otro_tributo + "|" +
            //        dataList.total + "|" +
            //        dataList.tiene_doc_referencia + "|" +
            //        dataList.tipo_doc_referencia + "|" +
            //        dataList.serie_doc_referencia + "|" +
            //        dataList.numero_doc_referencia + "|" +
            //        dataList.serie + "|" +
            //        dataList.numero_documento + "|" +
            //        dataList.user_id + "|" +
            //        dataList.observacion + "|" +
            //        dataList.numero_guia_remision + "|" +
            //        dataList.mensaje_detraccion + "|" +
            //        dataList.transferencia_gratuita + "|" +
            //        dataList.doc_relacionado + "|" +
            //        dataList.descuento_global + "|" +
            //        dataList.otros_cargos + "|" +
            //        dataList.anticipo + "|"

            //        );

            //    }
            //}

        }
        private void WriteDetalleDocumento()
        {

            //List<EntidadFacturaElectronicaDetalle> listaDetalle = new List<EntidadFacturaElectronicaDetalle>();
            //listaDetalle = LogicaFacturaElectronicaDetalle.ListFacturaElectronicaDetalle(lblNum_doc_cobranza.Text, drpTipoDocumento.SelectedItem.Value, lblSerie_cobranza.Text);
            //string webRootPath = Server.MapPath("~");
            //string fileName = "20101260292" + "0001" + listaDetalle[0].id_detalle_doc.ToString("0000000000") + DateTime.Now.ToString("ddMMyyyy")+ drpTipoDocumento.SelectedItem.Value + "210" ;
            ////string filePath = Path.GetFullPath(Path.Combine(webRootPath, "C:/inbox/" + fileName + ".txt"));
            //string filePath = "C:/inbox/" + fileName + ".txt";
            //using (StreamWriter sw = new StreamWriter( filePath, false, Encoding.UTF8))
            //{
            //    for (int i = 0; i < listaDetalle.Count; i++)
            //    {
            //        sw.Write(listaDetalle[i].id_detalle_doc + "|" +
            //                 listaDetalle[i].tipo_item + "|" +
            //                 listaDetalle[i].tipo_afectacion + "|" +
            //                 listaDetalle[i].Unidad_medida + "|" +
            //                 listaDetalle[i].codigo_item_catalogo + "|" +
            //                 listaDetalle[i].cod_producto_sunat + "|" +
            //                 listaDetalle[i].descripcion_detalle + "|" +
            //                 listaDetalle[i].cantidad + "|" +
            //                 listaDetalle[i].valor_unitario + "|" +
            //                 listaDetalle[i].descuento + "|" +
            //                 listaDetalle[i].porcentaje_descuento + "|" +
            //                 listaDetalle[i].valor_venta + "|" +
            //                 listaDetalle[i].igv + "|" +
            //                 listaDetalle[i].isc + "|" +
            //                 listaDetalle[i].porcentaje_isc + "|" +
            //                 listaDetalle[i].otros_cargos + "|" +
            //                 listaDetalle[i].porcentaje_otro_cargo + "|" +
            //                 listaDetalle[i].otro_tributo + "|" +
            //                 listaDetalle[i].porcentOtroTributo + "|" +
            //                 listaDetalle[i].importe_total + "|" 
                              
            //                 );
            //    }
            //}
        }
        protected void ListarReporteCaja(object sender, EventArgs e)
        {
            grdReporteCierreCaja.DataSource = LogicaReporteCierreCaja.ListReporteCierreCaja(txtFechaIni.Text +" 00:01",txtFechaFin.Text +" 23:59");
            grdReporteCierreCaja.DataBind();

        }
        protected void CalcularTotalVentaReporteCaja(object sender, GridViewRowEventArgs e)
        {
            //double MontoBrutoventa = 0;
            //double MontoAperturaCaja = 0;
            //double MontoNetoVenta = 0;
            //foreach (GridViewRow gvr in grdReporteCierreCaja.Rows)
            //{
            //    MontoBrutoventa = MontoBrutoventa + Convert.ToDouble(gvr.Cells[4].Text);
            //}
            //MontoNetoVenta = MontoBrutoventa - MontoAperturaCaja;

            //lblTotalBrutoVenta.Text = MontoBrutoventa.ToString();
            //lblMontoApertura.Text = MontoAperturaCaja.ToString();
            //lblTotalNetoVenta.Text = MontoNetoVenta.ToString();
        }
        protected void ExportarExcelReporteCaja(object sender, EventArgs e)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=ReporteCierrerCaja.xls");//ojo revisar solo funciona con .XLS
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                grdReporteCierreCaja.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in grdReporteCierreCaja.HeaderRow.Cells)
                {
                    cell.BackColor = grdReporteCierreCaja.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in grdReporteCierreCaja.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = grdReporteCierreCaja.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = grdReporteCierreCaja.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                grdReporteCierreCaja.RenderControl(hw);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }
        protected void NuevaCobranza(object sender, EventArgs e)
        {
            CleanFields();
        }
        private void CleanFields()
        {           
            //clean others fields
            lblSubtotalFacBol.Text = "0.0";
            lblIGVFactBol.Text = "0.0";
            lblTotalFacBol.Text = "0.0";

            txtDni_cliente.Text = "";
            txtNombre_cliente.Text = "";           
            txtDir_boleta.Text = "";
            txtObs_cobranza.Text = "";
            lblSerie_cobranza.Text = "";
            lblNumAdmision_cobranza.Text = "";

            txtRuc_factura.Text = "";
            txtCliente_factura.Text = "";
            txtDir_factura.Text = "";
            lblNum_doc_cobranza.Text = "";
            lblNumeroEnLetra.Text = "";            
            grdDetalleDocumento.DataSource = null;
            grdDetalleDocumento.DataBind();

            ViewState["Row"] = null;             
            grdDetalleVenta.DataSource = ViewState["Row"];
            grdDetalleVenta.DataBind();

            btnGuardarDocContable.Enabled = true;
            lblMsj_cobranza.Text = "";
        }
        protected void CerrarPantalla(object sender, EventArgs e)
        {
                Response.Redirect("~/frmMenu.aspx");
        }
        //======================venta particular================
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
            grdDetalleVenta.DataSource = dt;
            grdDetalleVenta.DataBind();
        }
        protected void CreateNewRowGrid()
        {
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                for (int i = 0; i <= dtCurrentTable.Rows.Count; i++)
                {
                    drCurrentRow = dtCurrentTable.NewRow();
                    drCurrentRow["Col1"] = i + 1;
                    drCurrentRow["Col2"] = txtId_ItemCatalogo.Text; 
                    drCurrentRow["Col3"] = txtCantidad_item.Text;
                    drCurrentRow["Col4"] = txtDescrip_catalogo.Text;
                    drCurrentRow["Col5"] = txtPrecio_item.Text;
                    drCurrentRow["Col6"] = (Convert.ToDecimal(txtCantidad_item.Text) * Convert.ToDecimal(txtPrecio_item.Text)).ToString("N");
                    drCurrentRow["Col7"] = txtIdGrupo_item.Text;
                    drCurrentRow["Col8"] = txtIdClase_item.Text;
                   
                }
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;
                grdDetalleVenta.DataSource = dtCurrentTable;
                grdDetalleVenta.DataBind();
            }
        }
        protected void CargarItems(object sender, EventArgs e)
        {
            if (txtId_ItemCatalogo.Text.Trim().Length == 0 || txtCantidad_item.Text.Trim().Length==0)
            {
                return;
            }
            else
            {
                CreateNewRowGrid();
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
                grdDetalleVenta.DataSource = dt;
                grdDetalleVenta.DataBind();
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
        protected void CalcularVentaParticular(object sender, GridViewRowEventArgs e)
        {
            double MontoSubTotal = 0;
            double MontoIGV = 0;
            double MontoTotal = 0;
            //double Descuento = 0;
            foreach (GridViewRow gvr in grdDetalleVenta.Rows)
            {
                MontoTotal = MontoTotal + Convert.ToDouble(gvr.Cells[5].Text);
            }

            MontoSubTotal = MontoTotal / 1.18;
            MontoIGV = MontoTotal - MontoSubTotal;// 0.18 * MontoSubTotal;

            lblSubtotalFacBol.Text = MontoSubTotal.ToString("N");
            lblIGVFactBol.Text = MontoIGV.ToString("N");
            lblTotalFacBol.Text = MontoTotal.ToString("N");
            lblNumeroEnLetra.Text = OtherClasses.ClaseConvertidores.NumToLetter(lblTotalFacBol.Text);

        }

        protected void AplicarDescuento(object sender, EventArgs e)
        {
            decimal descuento = 0;
            decimal total = 0;
            descuento =  Convert.ToDecimal(txtDescuento.Text);
            total = Convert.ToDecimal(lblTotalFacBol.Text);
            total = total - (descuento/100)*total;

            lblTotalFacBol.Text = total.ToString("N");
            lblNumeroEnLetra.Text = OtherClasses.ClaseConvertidores.NumToLetter(lblTotalFacBol.Text);

        }
        //===================Impriiendo Tickets ========================
        protected void Anular(object sender, EventArgs e)
        {
            LogicaAnulaDocumentos.AnularDocumentos(Convert.ToInt32(txtNumeroDocumentoAnular.Text), drpTipoDocumento.SelectedItem.Value,drpTipoDocumento.SelectedItem.Text.Substring(0,4),Convert.ToInt32(drpUnidadNegocio.SelectedItem.Value));
        }
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
            ticket.TextoExtremos("N° DE COMPROBANTE: ",String.Concat(lblSerie_cobranza.Text,"-",lblNum_doc_cobranza.Text));
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
            ticket.TextoIzquierdo("FECHA Y HORA : "+DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            ticket.lineasAsteriscos();

            ticket.EncabezadoVenta();
            ticket.lineasAsteriscos();
            foreach (GridViewRow row in grdDetalleDocumento.Rows)
            {
                ticket.AgregaArticulo(row.Cells[2].Text,Convert.ToInt32(row.Cells[1].Text) , Convert.ToDecimal(row.Cells[3].Text),Convert.ToDecimal(row.Cells[4].Text) );
                //ticket.AgregaArticulo("Articulo B", 1, 10, 10);
                //ticket.AgregaArticulo("Articulo que se comprtoe en plaza ver aucaon etaba en lima\nluego se fue de lima para huarmaca", 1, 30, 30);

            }
            ticket.lineasIgual();
            if(drpTipoDocumento.SelectedItem.Value == "03")
            {
                ticket.AgregarTotales("       TOTAL.....", Convert.ToDecimal(lblTotalFacBol.Text));
            }
            if(drpTipoDocumento.SelectedItem.Value=="01")
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
             
             ticket.ImprimirTicket("XP-90"); // ("TICKETERA_MZB1");


        }

    }
}