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
    public partial class frmProgramacionTurnos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                drpEspecialidad.DataSource = LogicaEspecialidad.ListEspecialidad();
                drpEspecialidad.DataValueField = "cod_especialidad";
                drpEspecialidad.DataTextField = "nom_especialidad";
                drpEspecialidad.DataBind();
            }

        }
        protected void ListarTurnosProgramar(object sender, EventArgs e)
        {
            EntidadProgramadorTurnos entProg = new EntidadProgramadorTurnos();
            entProg.id_turno = Convert.ToInt32(Convert.ToDateTime(txtfechabusqueda.Text).ToString("yyyyMMdd"));//;Convert.ToInt32(DateTime.Now.ToString("yyyyMMdd"));
            entProg.dni_empleado = txtDni_empleado.Text;
            entProg.cod_persona = 1;
            entProg.dni_paciente = "";
            entProg.id_item = "";
            entProg.cod_especialidad = Convert.ToInt32(drpEspecialidad.SelectedItem.Value);
            entProg.estado = "Disponible";
            entProg.fecha = txtfechabusqueda.Text;

            grdListaTurnosProgramar.DataSource = LogicaProgramadorTurnos.ListProgramadorTurnos(entProg);
            grdListaTurnosProgramar.DataBind();
        }
        protected void SelectAll(object sender, EventArgs e)
        {
            CheckBox chckheader = (CheckBox)grdListaTurnosProgramar.HeaderRow.FindControl("chkHeader");

            foreach (GridViewRow row in grdListaTurnosProgramar.Rows)
            {
                CheckBox chckrw = (CheckBox)row.FindControl("chkIncluir");
                if (chckheader.Checked == true)
                {
                    chckrw.Checked = true;
                }
                else
                {
                    chckrw.Checked = false;
                }
            }
        }
        protected void ProgramarTurnos(object sender, EventArgs e)
        {
            EntidadTurno entTurn = new EntidadTurno();

            foreach (GridViewRow rows in grdListaTurnosProgramar.Rows)
            {
                CheckBox check = (CheckBox)rows.FindControl("chkIncluir");

                TextBox txtFecha = (TextBox)rows.FindControl("txtFecha");
                entTurn.hora = rows.Cells[1].Text;
                entTurn.id_turno = Convert.ToInt32(rows.Cells[2].Text);
                entTurn.dni_empleado = rows.Cells[3].Text;
                entTurn.cod_persona_pago = Convert.ToInt32(rows.Cells[4].Text);
                entTurn.dni_paciente = rows.Cells[5].Text.Replace("&nbsp;", "");// otra forma es  NullDisplayText=" "  en Asp:boundfield 
                entTurn.cod_item_catalogo = rows.Cells[6].Text.Replace("&nbsp;", "");
                entTurn.cod_especialidad = Convert.ToInt32(rows.Cells[7].Text);
                entTurn.estado = rows.Cells[8].Text;
                entTurn.fecha = txtFecha.Text;
                if (check.Checked == true)
                {
                    LogicaTurno.InsertTurno(entTurn);
                }

            }
            grdListaTurnosProgramar.DataSource = null;
            grdListaTurnosProgramar.DataBind();
        }
        protected void InsertarHora(object sender, EventArgs e)
        {
            EntidadTurno entTurn = new EntidadTurno();

            entTurn.hora = txtHora.Text;
            entTurn.id_turno = Convert.ToInt32(DateTime.Now.ToString("ddMMyyyy"));
            entTurn.dni_empleado = txtDni_empleado.Text;
            entTurn.cod_persona_pago = 1;
            entTurn.dni_paciente = "";
            entTurn.cod_item_catalogo = "";
            entTurn.cod_especialidad = Convert.ToInt32(drpEspecialidad.SelectedItem.Value);
            entTurn.estado = "Disponible";
            entTurn.fecha = txtfechabusqueda.Text;
            LogicaTurno.InsertTurno(entTurn);
            lblMsj.Text = "¡registro exitoso!";

        }
        protected void CerrarPantalla(object sender, EventArgs e)
        {
             Response.Redirect("~/frmMenu.aspx");             
        }
    }
}