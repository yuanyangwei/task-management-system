using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMS.Controller;

namespace TMS
{
    public partial class LoginPage : System.Web.UI.Page
    {
        static int noOfAttempt = 3;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string accountType = LoginDAL.LoginAuthentication(txtUsername.Text, passwordfield.Text, noOfAttempt);
            Session["accountType"] = accountType;
            Session["Username"] = LoginDAL.getUsername(txtUsername.Text, passwordfield.Text);
            Session["RoleType"] = LoginDAL.getRoleType(txtUsername.Text);
            //Session["DueTaskCount"] = 
            //Session["NewTaskCount"] =


            if (accountType.ToLower() == "user")
            {
                if (LoginDAL.checkFirstTimeUser(txtUsername.Text, passwordfield.Text).ToLower() == "true")
                {
                    Response.Redirect(string.Format("~/PasswordReset.aspx"));
                }

                Response.Redirect(string.Format("~/DashBoard.aspx"));

            }
            else if (accountType.ToLower() == "admin")
            {
                Response.Redirect(string.Format("~/UserPortfolio.aspx"));
            }
            else 
            {
                if (noOfAttempt == 1)
                {
                    Response.Write("<script language='javascript'>alert('" + accountType + "');" + "</script>");
                }
                else
                {
                    noOfAttempt -= 1;
                    Response.Write("<script language='javascript'>alert('" + accountType + noOfAttempt + ".');" + "</script>");
                }
            }
            return;
        }       
    }
}