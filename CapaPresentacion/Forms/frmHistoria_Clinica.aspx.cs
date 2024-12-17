using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using CapaEntidad;
using CapaLogicaNegocio;


namespace CapaPresentacion.Forms
{
    public partial class frmHistoria_Clinica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void ListarHistorialAtenciones(object sender, EventArgs e)
        {
            grdHistorialAtenciones.DataSource = Logica_HC_Lista_Atenciones.ListarAtencionesHC(txtDni_paciente.Text);
            grdHistorialAtenciones.DataBind();
        }
        protected void SelecionarRegistro(object sender, EventArgs e)
        {
            LinkButton btnSelect = (sender as LinkButton);
            GridViewRow row = (btnSelect.NamingContainer as GridViewRow);

            List<EntidadBuscaHistoriaClinica> lst = new List<EntidadBuscaHistoriaClinica>();
            lst = LogicaBuscaHistoriaClinica.BuscarHistoriaClinica(Convert.ToInt32(row.Cells[2].Text));
            if (lst[0].Ficha1_col0 == "1")
            {
                repeaterFicha1.DataSource = lst;
                repeaterFicha1.DataBind();
                //buscar control dentro del Repeater
                //grdDiagnosticoFicha2.DataSource = null;
                //grdDiagnosticoFicha2.DataBind();
            }
            else if (lst[0].Ficha2_col0 == "2")
            {
                repeaterFicha2.DataSource = lst;
                repeaterFicha2.DataBind();
            }
            else if (lst[0].Ficha3_col0 == "3")
            {
                repeaterFicha3.DataSource = lst;
                repeaterFicha3.DataBind();
            }
            else if (lst[0].Ficha4_col0 == "4")
            {
                repeaterFicha4.DataSource = lst;
                repeaterFicha4.DataBind();
            }
            else if (lst[0].Ficha5_col0 == "5")
            {
                repeaterFicha5.DataSource = lst;
                repeaterFicha5.DataBind();
            }
            else if (lst[0].Ficha6_col0 == "6")
            {
                repeaterFicha6.DataSource = lst;
                repeaterFicha6.DataBind();
            }
            else if (lst[0].Ficha7_col0 == "7")
            {
                repeaterFicha7.DataSource = lst;
                repeaterFicha7.DataBind();
            }
            else if (lst[0].Ficha8_col0 == "8")
            {
                repeaterFicha8.DataSource = lst;
                repeaterFicha8.DataBind();
            }
            
        }
        
    }
}