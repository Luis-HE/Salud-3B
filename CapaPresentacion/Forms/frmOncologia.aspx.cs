using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CrystalDecisions.CrystalReports.Engine;
//using CrystalDecisions.ReportAppServer.Controllers;
//using CrystalDecisions.ReportAppServer.ClientDoc;
//using CrystalDecisions.ReportAppServer.DataDefModel;


using CapaEntidad;
using CapaLogicaNegocio;

namespace CapaPresentacion.Forms
{
    public partial class frmOncologia : System.Web.UI.Page
    {
        //ReportDocument boReportDocument;
        //CrystalDecisions.ReportAppServer.ReportDefModel.FieldObject boFieldObject;
        //ISCDReportClientDocument boReportClientDocument;
        //CrystalDecisions.ReportAppServer.ReportDefModel.Section boSection;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private static DataTable ConvertListToDataTable(List<string[]> list)
        {
            // New table.
            DataTable table = new DataTable();

            // Get max columns.
            int columns = 0;
            foreach (var array in list)
            {
                if (array.Length > columns)
                {
                    columns = array.Length;
                }
            }

            // Add columns.
            for (int i = 0; i < columns; i++)
            {
                table.Columns.Add();
            }

            // Add rows.
            foreach (var array in list)
            {
                table.Rows.Add(array);
            }

            return table;
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {

            List<EntidadEspecialidad> listEsp = new List<EntidadEspecialidad>();
            listEsp = LogicaEspecialidad.ListEspecialidad();
            List<string[]> list = new List<string[]>();
            for (int i = 0; i < listEsp.Count; i++)
            {
                list.Add(new string[] {
                   listEsp[i].cod_especialidad.ToString(),
                   listEsp[i].nom_especialidad
                      });

            }
            DataTable dtable = ConvertListToDataTable(list);
            System.Data.DataSet ds = new System.Data.DataSet();
            ds.Tables.Add(dtable);
            //=================================================================== 
            FormsReports.Reporte rpt = new FormsReports.Reporte();
            rpt.Load(Server.MapPath("~/FormsReports/Reporte.rpt"));

            //FormulaFieldDefinition ffld = rpt.DataDefinition.FormulaFields["codigo_especilidad"];
            // TextObject tobj = ((CrystalDecisions.CrystalReports.Engine.TextObject)rpt.Section1.ReportObjects["Text1"]) ;

            //CrystalDecisions.CrystalReports.Engine.TextObject tobj;
            // tobj = (TextObject)rpt.ReportDefinition.ReportObjects["Column1"];
            //((CrystalDecisions.CrystalReports.Engine.TextObject)rpt.ReportDefinition.ReportObjects["Column1"]).Text = tobj;
            TextObject col1 = (TextObject)rpt.ReportDefinition.ReportObjects["Column1"];
            TextObject col2 = (TextObject)rpt.ReportDefinition.ReportObjects["Column2"];
            col1.Text = "Column1";
            col2.Text = "Column2";
            //ctrl.Text = "Valor que pasará al reporte"; //texto para el control del reporte.
            txtResult.Text = "paso 1";
            //rpt.Database.Tables[0].SetDataSource(dtable);
           // rpt.SetDataSource(ds.Tables[0]);
            CrystalReportViewer1.ReportSource = rpt;
            txtResult.Text = "paso 2";
            // CrystalReportViewer1.DataBind();
            txtResult.Text = "paso 3";
            
            //========================================================================   



        }
    }
}