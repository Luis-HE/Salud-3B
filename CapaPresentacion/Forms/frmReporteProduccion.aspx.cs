using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;

namespace CapaPresentacion.Forms
{
    public partial class frmReporteProduccion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                imgGauge.ImageUrl = "data:image/png;base64," + OtherClasses.GaugeClass.strbase64Guage(69.5);
            }
        }
        protected void LoadXML(object sender, EventArgs e)
        {
            using (DataSet dtset = new DataSet())
            {
                 dtset.ReadXml(@"C:\ACTIVADOR\SampleXML_Employee.xml");
                //O
                //dtset.ReadXml(Server.MapPath("Clientes.xml"));
                //O
                // dtset.ReadXml(Request.PhysicalApplicationPath + "Clientes.xml");

                grdTestxml.DataSource = dtset;
                grdTestxml.DataBind();
            }
        }
        protected void CerrarPantalla(object sender, EventArgs e)
        {
            Response.Redirect("~/frmMenu.aspx");
        }
    }
}