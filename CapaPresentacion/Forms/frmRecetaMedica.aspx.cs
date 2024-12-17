using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.Data;

using CapaEntidad;
using CapaLogicaNegocio;

namespace CapaPresentacion.Forms
{
    public partial class frmRecetaMedica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                 SetGridView();                
            }
        }
        protected void CargarItemsCatalogo(object sender, EventArgs e)
        {
            if (txtId_ItemCatalogo.Text.Trim().Length == 0 || txtCantidad_item.Text.Trim().Length==0)
            {
                return;
            }
            else
            {
                CreateNewRowGridReceta();
                //clean fields
                txtId_ItemCatalogo.Text = "";
                txtDescrip_catalogo.Text = "";
                txtPrecio_item.Text = "0";
                txtCantidad_item.Text = "";
                txtIdGrupo_item.Text = "";
                txtIdClase_item.Text = "";
                txtConcentracion.Text = "";
                txtViaAdministracion.Text = "";
                txtFrecuencia.Text = "";
                txtTratamiento.Text = "";
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
            dt.Columns.Add(new DataColumn("Col9", typeof(string)));
            dt.Columns.Add(new DataColumn("Col10", typeof(string)));
            dt.Columns.Add(new DataColumn("Col11", typeof(string)));
            
            ViewState["CurrentTable"] = dt;
            grdDetalleReceta.DataSource = dt;
            grdDetalleReceta.DataBind();
        }
        public void CreateNewRowGridReceta()
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
                    drCurrentRow["Col5"] = txtConcentracion.Text;
                    drCurrentRow["Col6"] = txtViaAdministracion.Text;
                    drCurrentRow["Col7"] = txtFrecuencia.Text;
                    drCurrentRow["Col8"] = txtTratamiento.Text;
                    drCurrentRow["Col9"] = txtPrecio_item.Text;
                    drCurrentRow["Col10"] = txtIdGrupo_item.Text;
                    drCurrentRow["Col11"] = txtIdClase_item.Text;
                }
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;
                grdDetalleReceta.DataSource = dtCurrentTable;
                grdDetalleReceta.DataBind();
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
                grdDetalleReceta.DataSource = dt;
                grdDetalleReceta.DataBind();
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
        protected void CalcularVenta(object sender, GridViewRowEventArgs e)
        {
            double MontoTotal = 0;
            foreach (GridViewRow gvr in grdDetalleReceta.Rows)
            {
                MontoTotal = MontoTotal + (Convert.ToInt32(gvr.Cells[2].Text) * Convert.ToDouble(gvr.Cells[8].Text));
            }
 
            lblTotalFacBol.Text = MontoTotal.ToString("N");            
        }
        protected void GuardarReceta(object sender, EventArgs e)
        {
            EntidadConsultorioRecetaMedica ent = new EntidadConsultorioRecetaMedica();
            ent.fecha_hasta_vigencia = txtFechaVigencia.Text;
            ent.dni_empleado = txtDniEmpleado.Text;
            ent.cod_persona_pago = 1;
            ent.num_admision = Convert.ToInt32(txtNumeroAdmision.Text);
            ent.num_doc_cliente = txtDNIPaciente.Text;
            ent.cod_persona = 1;
            ent.alergico = chkAlergico.Checked;
            ent.indicaciones = txtAnotaciones.Text;
            ent.fecha_receta = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            if(grdDetalleReceta.Rows.Count==0 || txtNombrePaciente.Text.Trim().Length==0)
            {
                return;
            }
            else
            {
                LogicaConsultorioRecetaMedica.InsertarRecetaMedica(ent);
                lblId_Receta.Text = LogicaConsultorioRecetaMedica.GetLastIdRegReceta(txtDNIPaciente.Text, DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)[0].id_receta.ToString();
                GuardarDetalleReceta();
                lblMsj.Text = "¡registro exitoso!";
            }
            
           // CleanFields();
            btnGuardar.Enabled = false;
        }
        protected void GuardarDetalleReceta()
        {
            foreach (GridViewRow row in grdDetalleReceta.Rows)
            {
                EntidadConsultorioRecetaMedicaDetalle entDetalle = new EntidadConsultorioRecetaMedicaDetalle();
                entDetalle.id_receta = Convert.ToInt32(lblId_Receta.Text);
                entDetalle.codigo_item_catalogo = row.Cells[1].Text;
                entDetalle.id_grupo = Convert.ToInt32(row.Cells[9].Text);
                entDetalle.id_clase = Convert.ToInt32(row.Cells[10].Text);
                entDetalle.cantidad_receta = Convert.ToInt32(row.Cells[2].Text);
                entDetalle.forma_farmaceutica ="";
                entDetalle.estado = 0;
                entDetalle.descripcion_item = row.Cells[3].Text;
                entDetalle.concentracion = row.Cells[4].Text;
                entDetalle.via_administracion = row.Cells[5].Text;
                entDetalle.frecuencia = row.Cells[6].Text;
                entDetalle.tratamiento = row.Cells[7].Text;
                LogicaConsultorioRecetaMedicaDetalle.InsertarRecetaMedicaDetalle(entDetalle);
              }
        }
        //private void CleanFields()
        //{
        //    //clean gridCompras
        //    DataTable dt = (DataTable)ViewState["CurrentTable"];
        //    dt.Clear();
        //    grdDetalleReceta.DataSource = dt;
        //    grdDetalleReceta.DataBind();

        //    txtDniEmpleado.Text = "";
        //    txtNombreEmpleado.Text = "";
        //    txtNumeroAdmision.Text = "";
        //    txtFechaVigencia.Text = "";
        //    txtDNIPaciente.Text = "";
        //    txtNombrePaciente.Text = "";
        //    txtEdadPaciente.Text = "";
        //    txtDireccionPaciente.Text = "";
        //    txtTelefonoPaciente.Text = "";
        //    txtEmailPaciente.Text = "";
        //    chkAlergico.Checked = false;
        //    txtAnotaciones.Text = "";

        //}
         
        protected void btnEnviar_Click(object sender, EventArgs e)
        {         
            //link button column is excluded from the list
            int colCount = grdDetalleReceta.Columns.Count - 1;
            //Create a table
            PdfPTable table = new PdfPTable(colCount);
            table.HorizontalAlignment = 0;
            table.WidthPercentage = 100;
            //create an array to store column widths
            int[] colWidths = new int[grdDetalleReceta.Columns.Count];

            PdfPCell cell;
            string cellText;

            //create the header row
            for (int colIndex = 0; colIndex < colCount; colIndex++)
            {
                     //set the column width
                    colWidths[colIndex] = (int)grdDetalleReceta.Columns[colIndex].ItemStyle.Width.Value;

                    //fetch the header text
                    cellText = Server.HtmlDecode(grdDetalleReceta.HeaderRow.Cells[colIndex].Text);

                    //create a new cell with header text
                    cell = new PdfPCell(new Phrase(cellText));

                    //set the background color for the header cell
                    cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#d1dbe0"));

                    //add the cell to the table. we dont need to create a row and add cells to the row
                    //since we set the column count of the table to 4, it will automatically create row for
                    //every 4 cells
                    table.AddCell(cell); 
            }
            //export rows from GridView to table
            for (int rowIndex = 0; rowIndex < grdDetalleReceta.Rows.Count; rowIndex++)
            {
                if (grdDetalleReceta.Rows[rowIndex].RowType == DataControlRowType.DataRow)
                {
                    for (int j = 0; j < grdDetalleReceta.Columns.Count - 1; j++)
                    {
                        //fetch the column value of the current row
                        cellText = Server.HtmlDecode(grdDetalleReceta.Rows[rowIndex].Cells[j].Text);

                        //create a new cell with column value
                        cell = new PdfPCell(new Phrase(cellText));

                        //Set Color of Alternating row
                        if (rowIndex % 2 != 0)
                        {
                            cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#9ab2ca"));
                        }
                        else
                        {
                            cell.BackgroundColor = new BaseColor(System.Drawing.ColorTranslator.FromHtml("#f1f5f6"));
                        }
                        //add the cell to the table
                        table.AddCell(cell);
                    }
                }
            }

            //Create the PDF Document
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);

            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);

            //open the stream
            pdfDoc.Open();
            string imageURLLogo = Server.MapPath("~/Images/") + "Logo_Factura.png";
            // string imageURLFirma = Server.MapPath("~/Images/") + "Firma_Medico.png";
            iTextSharp.text.Image imgLogo = iTextSharp.text.Image.GetInstance(imageURLLogo);
            // iTextSharp.text.Image imgFirma = iTextSharp.text.Image.GetInstance(imageURLFirma);
            imgLogo.ScaleToFit(400f, 200f);
            //imgLogo.SetAbsolutePosition(0,0);
            imgLogo.Alignment = Element.ALIGN_LEFT;
            imgLogo.SpacingAfter = 1f;
            pdfDoc.Add(imgLogo);

            pdfDoc.Add(new Paragraph("___________________________________________________________"));
            pdfDoc.Add(new Paragraph("Médico Tratante: " + txtNombreEmpleado.Text));
            pdfDoc.Add(new Paragraph("DNI: " + txtDNIPaciente.Text));
            pdfDoc.Add(new Paragraph("Paciente: " + txtNombrePaciente.Text));
            pdfDoc.Add(new Paragraph("Dirección: " + txtDireccionPaciente.Text));
            pdfDoc.Add(new Paragraph("Teléfono: " + txtTelefonoPaciente.Text));
            pdfDoc.Add(new Paragraph("E-mail: " + txtEmailPaciente.Text));
            pdfDoc.Add(new Paragraph("........................................................................................................................"));
            pdfDoc.Add(new Paragraph(txtAnotaciones.Text));
            pdfDoc.Add(new Paragraph(""));

            //add the GRIDVIEW to the document
            pdfDoc.Add(table);
            pdfDoc.Add(new Paragraph("Fecha: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm") ));
            //pdfDoc.Add(new Paragraph("Vigencia: " + txtVigencia.Text));

            //close the document stream
            pdfDoc.Close();

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;" + "filename=RecetaMedica.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Write(pdfDoc);
            Response.End();

        }
        protected void GetPaciente(object sender,EventArgs e)
        {
            int num_admision = Convert.ToInt32(txtNumeroAdmision.Text);

            txtDNIPaciente.Text = LogicaModeloBuscaPacAdmitido.GetListPacienteTriaje(num_admision)[0].num_doc_cliente;
            txtNombrePaciente.Text = LogicaModeloBuscaPacAdmitido.GetListPacienteTriaje(num_admision)[0].paciente;
            txtEdadPaciente.Text = LogicaModeloBuscaPacAdmitido.GetListPacienteTriaje(num_admision)[0].edad.ToString();
            txtDireccionPaciente.Text = LogicaModeloBuscaPacAdmitido.GetListPacienteTriaje(num_admision)[0].direccion;
            txtTelefonoPaciente.Text = LogicaModeloBuscaPacAdmitido.GetListPacienteTriaje(num_admision)[0].telefono;
            txtEmailPaciente.Text = LogicaModeloBuscaPacAdmitido.GetListPacienteTriaje(num_admision)[0].email;
        }
    }
}