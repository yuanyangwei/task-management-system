using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMS.Controller;

namespace TMS
{
    public partial class DueTaskReminderList : System.Web.UI.Page
    {
        private static readonly string TBL_KEY = "tbl";
        private const string ASCENDING = " ASC";
        private const string DESCENDING = " DESC";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }


        //method for binding GridView

        protected void RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && GridView1.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddlStatusType = (DropDownList)e.Row.FindControl("ddlStatusType");
                DataSet ds1 = new DataSet();
                ds1 = TaskInfoDAL.PopulateTaskStatus();

                ddlStatusType.DataSource = ds1;
                ddlStatusType.DataTextField = "taskStatus";
                ddlStatusType.DataValueField = "taskStatus";
                ddlStatusType.DataBind();
                string selectedStatusType = DataBinder.Eval(e.Row.DataItem, "task_status").ToString();
                ddlStatusType.Items.FindByValue(selectedStatusType).Selected = true;
            }
        }

        protected void BindGridView()
        {
            GridView1.DataSource = TaskInfoDAL.GetOverdueTaskInfo(Session["Username"].ToString());
            GridView1.DataBind();
        }

        // row edit event
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        // row update event
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string taskID = (GridView1.Rows[e.RowIndex].FindControl("lblTaskID") as Label).Text;
            string comment = (GridView1.Rows[e.RowIndex].FindControl("txt_comment") as TextBox).Text;
            string taskStatus = (GridView1.Rows[e.RowIndex].FindControl("ddlStatusType") as DropDownList).SelectedItem.Value;

            TaskInfoDAL.UpdateTaskInfo(taskID, comment, taskStatus);
            Session["DueTaskCount"] = TaskInfoDAL.GetTaskDueCount(Session["Username"].ToString());
            GridView1.EditIndex = -1;
            BindGridView();

        }

        // cancel row edit event

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridView();
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(string.Format("~/CreateTask.aspx"));
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                BindGridView();
                GridView1.PageIndex = e.NewPageIndex;
                GridView1.DataBind();
            }
            catch (Exception ex) { }
        }
    }
}