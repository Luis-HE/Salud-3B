using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion.Forms
{
    public partial class frmRevistaMedica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Bindata();
            }

        }
        private void Bindata()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Dni", typeof(string));
            dt.Columns.Add("Nombres", typeof(string));
            dt.Columns.Add("Apellidos", typeof(string));
            dt.Columns.Add("Fecha_hospitaliza", typeof(string));
            dt.Columns.Add("Tiempo", typeof(string));
            dt.Columns.Add("T_transcurrido", typeof(string));
            dt.Columns.Add("Diagnostico", typeof(string));
            dt.Columns.Add("Num_cama", typeof(string));
            dt.Columns.Add("Costo", typeof(string));
            dt.Columns.Add("Num_visitas", typeof(string));
            //
            // Here we add five DataRows.
            //
            dt.Rows.Add("10354352", "Rakel", "Burga Perez", DateTime.Now.ToShortDateString(), "15 dias", "02 dias", "Operado del Corazon", "Cama Económica", "S/. 10,000","01 veces");
            dt.Rows.Add("45354352", "Sachin", "Estrada Panduro", DateTime.Now.ToShortDateString(), "15 dias", "10 dias", "Operado del Corazon", "Cama Económica", "S/. 10,000", "03 veces");
            dt.Rows.Add("43454352", "Nitin", "Noida Born", DateTime.Now.ToShortDateString(), "25 dias", "13 dias", "Operado del Corazon", "Cama Económica", "S/. 10,000", "01 veces");
            dt.Rows.Add("45631234", "Adita", "Peron Peron", DateTime.Now.ToShortDateString(), "30 dias", "05 dias", "Operado del Corazon", "Cama Económica", "S/. 10,000", "02 veces");
            dt.Rows.Add("56745364", "Mohan", "Banglore Ston", DateTime.Now.ToShortDateString(), "10 dias", "02 dias", "Operado del Corazon", "Cama Económica", "S/. 10,000", "01 veces");

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
        protected void OpenRegistraVisita(object sender, EventArgs e)
        {
            ModalPopupExtender1.Show();
        }
        protected void OpenDetalleVisita(object sender, EventArgs e)
        {
            ModalPopupExtender2.Show();
        }
        protected void CerrarRevista(object sender, EventArgs e)
        {
            Response.Redirect("~/frmMenu.aspx");
        }
    }
}