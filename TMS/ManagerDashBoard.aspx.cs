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
            ds = TaskInfoDAL.PopulateManagerProjectName(Session["Username"].ToString());
            ddlFilterByProjectType.Items.Add("ALL");

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ddlFilterByProjectType.Items.Add(ds.Tables[0].Rows[i]["project_name"].ToString());
            }
        }

        protected void BindGridView()
        {
            GridView1.DataSource = TaskInfoDAL.GetManagerTaskInfo(ddlFilterByProjectType.SelectedValue, Session["Username"].ToString());
            GridView1.DataBind();
        }


        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Edit")
            {
                LinkButton lnkBtn = (LinkButton)e.CommandSource;    // the button
                GridViewRow myRow = (GridViewRow)lnkBtn.Parent.Parent;  // the row
                GridView myGrid = (GridView)sender; // the gridview
                string ID = myGrid.DataKeys[myRow.RowIndex].Value.ToString(); // value of the datakey 

                Response.Redirect(string.Format("~/ManagerUpdateTask.aspx?id={0}", ID));
            }
        }

        protected void ddlFilterByProjectTypePostCheck()
        {
            string status = "";
            if (ddlFilterByProjectType.SelectedValue != "ALL")
            {
                status = TaskInfoDAL.GetProjectStatus(ddlFilterByProjectType.SelectedValue);

                if (status.ToLower() == "completed" || status.ToLower() == "suspend" || status.ToLower() == "pending")
                {
                    GridView1.Columns[0].Visible = false;
                }
                else
                {
                    GridView1.Columns[0].Visible = true;
                }
            }
            else if (ddlFilterByProjectType.SelectedValue == "ALL" || ddlFilterByProjectType.SelectedValue == "")
            {
                GridView1.Columns[0].Visible = false;
            }
        }

        protected void ddlFilterByProjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlFilterByProjectTypePostCheck();
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