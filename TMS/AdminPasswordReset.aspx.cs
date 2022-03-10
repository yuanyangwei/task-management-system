using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMS.Controller;

namespace TMS
{
    public partial class AdminPasswordReset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btn_update_Click(object sender, EventArgs e)
        {
            LoginDAL.UpdatePassword(txtPassword.Text, 0, Session["Username"].ToString());
            Response.Write("<script language='javascript'>alert('Password has been reset successfully!');" + "</script>");
        }
    }
}