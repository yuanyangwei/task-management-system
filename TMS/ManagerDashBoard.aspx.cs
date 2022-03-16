﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMS.Controller;

namespace TMS
{
    public partial class ManagerDashBoard : System.Web.UI.Page
    {
        private static readonly string TBL_KEY = "tbl";
        private const string ASCENDING = " ASC";
        private const string DESCENDING = " DESC";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateProjectName();
                ddlFilterByProjectTypePostCheck();
                BindGridView();
            }
        }

        private void PopulateProjectName()
        {
            DataSet ds = new DataSet();
            ds = TaskInfoDAL.PopulateProjectName(Session["Username"].ToString());
            ddlFilterByProjectType.Items.Add("ALL");

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ddlFilterByProjectType.Items.Add(ds.Tables[0].Rows[i]["project_name"].ToString());
            }
        }

        //method for binding GridView

        //protected void RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.DataRow && GridView1.EditIndex == e.Row.RowIndex)
        //    {
        //        DropDownList ddlStatusType = (DropDownList)e.Row.FindControl("ddlStatusType");
        //        DataSet ds1 = new DataSet();
        //        ds1 = TaskInfoDAL.PopulateTaskStatus();

        //        ddlStatusType.DataSource = ds1;
        //        ddlStatusType.DataTextField = "taskStatus";
        //        ddlStatusType.DataValueField = "taskStatus";
        //        ddlStatusType.DataBind();
        //        string selectedStatusType = DataBinder.Eval(e.Row.DataItem, "task_status").ToString();
        //        ddlStatusType.Items.FindByValue(selectedStatusType).Selected = true;

        //        DropDownList ddlAssignee = (DropDownList)e.Row.FindControl("ddlAssignee");
        //        DataSet ds = new DataSet();
        //        ds = LoginDAL.PopulateAssigneeList(Session["Username"].ToString());

        //        ddlAssignee.DataSource = ds;
        //        ddlAssignee.DataTextField = "full_name";
        //        ddlAssignee.DataValueField = "full_name";
        //        ddlAssignee.DataBind();
        //        string selectedAssignee = DataBinder.Eval(e.Row.DataItem, "assignee").ToString();
        //        ddlAssignee.Items.FindByValue(selectedAssignee).Selected = true;
        //    }
        //}

        protected void BindGridView()
        {
            GridView1.DataSource = TaskInfoDAL.GetTaskInfo(ddlFilterByProjectType.SelectedValue, Session["Username"].ToString());
            GridView1.DataBind();
        }

        // row edit event
        //protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        //{
        //    GridView1.EditIndex = e.NewEditIndex;
        //    BindGridView();
        //}

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                Int16 num = Convert.ToInt16(e.CommandArgument);
                //string id = gv_Feedback.Rows[num].Cells[1].Text;
                string id = gv_Feedback.DataKeys[num]["feedbackID"].ToString();
                string StatusType = ddlStatusType.SelectedValue;

                if (StatusType == "Pending")
                    Response.Redirect(string.Format("~/AdminViewFeedbackPendingDetails.aspx?id={0}&statusType={1}", id, StatusType));
                else
                    Response.Redirect(string.Format("~/AdminViewFeedbackRepliedDetails.aspx?id={0}&statusType={1}", id, StatusType));
            }
        }
        // row update event
        //protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        //{
        //    string taskID = (GridView1.Rows[e.RowIndex].FindControl("lblTaskID") as Label).Text;
        //    string comment = (GridView1.Rows[e.RowIndex].FindControl("txt_comment") as TextBox).Text;
        //    string taskStatus = (GridView1.Rows[e.RowIndex].FindControl("ddlStatusType") as DropDownList).SelectedItem.Value;

        //    TaskInfoDAL.UpdateTaskInfo(taskID, comment, taskStatus);
        //    GridView1.EditIndex = -1;
        //    BindGridView();

        //}

        // cancel row edit event

        //protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        //{
        //    GridView1.EditIndex = -1;
        //    BindGridView();
        //}

        //protected void ddlFilterByProjectTypePostCheck()
        //{
        //    string status = "";
        //    if (ddlFilterByProjectType.SelectedValue != "ALL")
        //    {
        //        status = TaskInfoDAL.GetProjectStatus(ddlFilterByProjectType.SelectedValue);

        //        if (status.ToLower() == "completed" || status.ToLower() == "suspend" || status.ToLower() == "pending")
        //        {
        //            GridView1.Columns[0].Visible = false;
        //        }
        //        else
        //        {
        //            GridView1.Columns[0].Visible = true;
        //        }
        //    }
        //    else if (ddlFilterByProjectType.SelectedValue == "ALL" || ddlFilterByProjectType.SelectedValue == "")
        //    {
        //        GridView1.Columns[0].Visible = false;
        //    }
        //}

        //protected void ddlFilterByProjectType_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ddlFilterByProjectTypePostCheck();
        //    BindGridView();
        //}

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