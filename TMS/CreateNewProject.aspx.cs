using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMS.Controller;

namespace TMS
{
    public partial class CreateNewProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }

            ValidationBox();
        }

        protected void btn_create_Click(object sender, EventArgs e)
        {
            TaskInfoDAL.CreateNewProject(txtProjectName.Text, txtProjectDesc.Text, ddlProjectStatus.SelectedValue, Session["Username"].ToString());
            Response.Write("<script language='javascript'>alert('Project has been created successfully!');" + "</script>");
        }

        protected bool ValidationBox()
        {
            string projectName = TaskInfoDAL.GetProjectNameByDepartment(txtProjectName.Text, Session["Username"].ToString());

            if (txtProjectName.Text != "")
            {
                RequiredFieldValidator9.InitialValue = projectName;
                RequiredFieldValidator9.ErrorMessage = "This project name has been registered.";
            }

            if (projectName == "") //all new value
                return true;
            else
                return false;
        }
    }
}