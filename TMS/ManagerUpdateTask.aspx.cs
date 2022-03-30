using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMS.Controller;

namespace TMS
{
    public partial class ManagerUpdateTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string id = Request.QueryString["id"];

                Calendar1.Visible = false;
                Calendar2.Visible = false;
                PopulateProjectName();
                PopulateAssigneeList();

                DataSet ds = new DataSet();
                ds = TaskInfoDAL.GetManagerTaskInfoById(id);

                ddlProjectName.SelectedValue = ds.Tables[0].Rows[0]["project_name"].ToString();
                txtTaskName.Text = ds.Tables[0].Rows[0]["task_name"].ToString();
                txtComment.Text = ds.Tables[0].Rows[0]["task_comment"].ToString();
                ddlTaskStatus.SelectedValue = ds.Tables[0].Rows[0]["task_status"].ToString();
                txtDescription.Text = ds.Tables[0].Rows[0]["task_desc"].ToString();
                ddlPriority.SelectedValue = ds.Tables[0].Rows[0]["priority"].ToString();
                ddlAssignee.SelectedValue = ds.Tables[0].Rows[0]["assignee"].ToString();
                txtStart.Text = ds.Tables[0].Rows[0]["start_date"].ToString();
                txtEnd.Text = ds.Tables[0].Rows[0]["due_date"].ToString();
            }
        }

        private void PopulateAssigneeList()
        {
            DataSet ds = new DataSet();
            ds = LoginDAL.PopulateAssigneeList(Session["Username"].ToString());

            ddlAssignee.Items.Add("");
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ddlAssignee.Items.Add(ds.Tables[0].Rows[i]["full_name"].ToString());
            }
        }

        private void PopulateProjectName()
        {
            DataSet ds = new DataSet();
            ds = TaskInfoDAL.GetOngoingProjectList(Session["Username"].ToString());

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ddlProjectName.Items.Add(ds.Tables[0].Rows[i]["project_name"].ToString());
            }
        }


        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible == false)
            {
                Calendar1.Visible = true;
                // hide_calendar_row.Visible = true;
            }
            else
            {
                Calendar1.Visible = false;
                // hide_calendar_row.Visible = false;
            }
        }

        protected void ImageButton2_Click1(object sender, ImageClickEventArgs e)
        {
            if (Calendar2.Visible == false)
            {
                Calendar2.Visible = true;
                //hide_calendar_row.Visible = true;
            }
            else
            {
                Calendar2.Visible = false;
                // hide_calendar_row.Visible = false;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtStart.Text = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
            Calendar1.Visible = false;
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            txtEnd.Text = Calendar2.SelectedDate.ToString("yyyy-MM-dd");
            Calendar2.Visible = false;
        }

        protected void btn_Update_Click(object sender, EventArgs e)
        {
            DateTime? start_date1 = null;
            DateTime? due_date1 = null;

            IFormatProvider culture = new CultureInfo("en-US", true);

            string id = Request.QueryString["id"];
            if (txtStart.Text != "" && txtStart.Text != null && txtEnd.Text != "" && txtEnd.Text != null)
            {
                start_date1 = DateTime.Parse(txtStart.Text, culture);
                due_date1 = DateTime.Parse(txtEnd.Text, culture);

                if (start_date1 >= due_date1)
                {
                    Response.Write("<script language='javascript'>alert('Start date cannot be later than Due Date!');" + "</script>");
                }
                else
                {
                    TaskInfoDAL.UpdateManagerTaskInfoByID(id, ddlProjectName.SelectedValue, txtTaskName.Text, txtDescription.Text, txtComment.Text, ddlTaskStatus.SelectedValue, ddlPriority.SelectedValue, txtStart.Text, txtEnd.Text, ddlAssignee.SelectedValue);
                    Session["NewTaskCount"] = TaskInfoDAL.GetNewTaskCount(Session["Username"].ToString());
                    Session["DueTaskCount"] = TaskInfoDAL.GetTaskDueCount(Session["Username"].ToString());
                    Response.Write("<script language='javascript'>alert('Task updated successfully!');" + "</script>");
                    Response.Redirect(string.Format("~/ManagerDashBoard.aspx"));
                }
            }
            else
            {
                TaskInfoDAL.UpdateManagerTaskInfoByID(id, ddlProjectName.SelectedValue, txtTaskName.Text, txtDescription.Text, txtComment.Text, ddlTaskStatus.SelectedValue, ddlPriority.SelectedValue, txtStart.Text, txtEnd.Text, ddlAssignee.SelectedValue);
                Session["NewTaskCount"] = TaskInfoDAL.GetNewTaskCount(Session["Username"].ToString());
                Session["DueTaskCount"] = TaskInfoDAL.GetTaskDueCount(Session["Username"].ToString());
                Response.Write("<script language='javascript'>alert('Task updated successfully!');" + "</script>");
                Response.Redirect(string.Format("~/ManagerDashBoard.aspx"));
            }
        }

    }
}