using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CapaPresentacion
{
    public partial class frmMenu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["Username"]!= null)
            {
                lblUserName.Text = Session["Username"].ToString();
            }
            else
            {
                Response.Redirect("~/frmLogin.aspx");
            }
        }
       protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("~/frmLogin.aspx");
        }
    }
}