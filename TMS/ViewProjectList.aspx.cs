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
    public partial class ViewProjectList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }
        }

        protected void BindGridView()
        {
            GridView1.DataSource = TaskInfoDAL.GetUnarchivedProjectList(Session["Username"].ToString());
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
            string projectID = (GridView1.Rows[e.RowIndex].FindControl("lblPojectID") as Label).Text;
            string project_des = (GridView1.Rows[e.RowIndex].FindControl("txt_comment") as TextBox).Text;
            string projectStatus = (GridView1.Rows[e.RowIndex].FindControl("ddlStatusType") as DropDownList).SelectedItem.Value;

            TaskInfoDAL.UpdateProjectInfo(projectID, projectStatus, project_des);
            GridView1.EditIndex = -1;
            BindGridView();

        }

        // cancel row edit event

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridView();
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

        protected void RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && GridView1.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddlStatusType = (DropDownList)e.Row.FindControl("ddlStatusType");
                DataSet ds1 = new DataSet();
                ds1 = TaskInfoDAL.GetAllProjectStatus();

                ddlStatusType.DataSource = ds1;
                ddlStatusType.DataTextField = "projectStatus";
                ddlStatusType.DataValueField = "projectStatus";
                ddlStatusType.DataBind();
                string projectStatus = DataBinder.Eval(e.Row.DataItem, "project_status").ToString();
                ddlStatusType.Items.FindByValue(projectStatus).Selected = true;
            }
        }

        protected void Ongoing_Click(object sender, ImageClickEventArgs e)
        {
            BindGridView();
            GridView1.Columns[0].Visible = true;
            btnArchived.Visible = true;
            btnUnarchived.Visible = false;
        }

        protected void Archived_Click(object sender, ImageClickEventArgs e)
        {
            GridView1.DataSource = TaskInfoDAL.GetArchivedProjectList(Session["Username"].ToString());
            GridView1.DataBind();
            GridView1.Columns[0].Visible = false;
            btnArchived.Visible = false;
            btnUnarchived.Visible = true;
        }
    }
}