﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using CapaEntidad;
using CapaLogicaNegocio;
namespace CapaPresentacion.Forms
{
    public partial class frmParametrosCompraVenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                txtcod_tcambio.Text = DateTime.Now.ToString("ddMMyyyy");
            }
            
        }
    }
}