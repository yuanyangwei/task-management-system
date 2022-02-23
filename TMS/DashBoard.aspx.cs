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
    public partial class DashBoard : Page
    {
        private static readonly string TBL_KEY = "tbl";
        private const string ASCENDING = " ASC";
        private const string DESCENDING = " DESC";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
                PopulateProjectName();
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

        protected void BindGridView()
        {
            GridView1.DataSource = TaskInfoDAL.GetTaskInfo(Session["Username"].ToString());
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

            // find student id of edit row

            //string id = GridView1.DataKeys[e.RowIndex].Value.ToString();

            //// find updated values for update

            //TextBox name = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txt_Name");

            //TextBox branch = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txt_Branch");

            //TextBox city = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txt_City");



            //SqlCommand cmd = new SqlCommand("update tbl_student set Name='" + name.Text + "',
    

            //                                                  Branch = '"+branch.Text+"', City = '"+city.Text+"' where ID = " +id, con);
    

            //con.Open();

            //cmd.ExecuteNonQuery();

            //con.Close();



            //GridView1.EditIndex = -1;

            //BindGridView();

        }

        // cancel row edit event

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGridView();
        }

        //public SortDirection GridViewSortDirection
        //{
        //    get
        //    {
        //        if (ViewState["sortDirection"] == null)
        //            ViewState["sortDirection"] = SortDirection.Ascending;
        //        return (SortDirection)ViewState["sortDirection"];
        //    }
        //    set { ViewState["sortDirection"] = value; }
        //}

        //private void SortGridView(string sortExpression, string direction)
        //{
        //    if (ViewState[TBL_KEY] == null) return;

        //    DataView dv = new DataView((DataTable)ViewState[TBL_KEY]);
        //    dv.Sort = sortExpression + direction;
        //}

        //protected void gvFeedback_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    string sortExpression = e.SortExpression;

        //    if (GridViewSortDirection == SortDirection.Ascending)
        //    {
        //        GridViewSortDirection = SortDirection.Descending;
        //        SortGridView(sortExpression, DESCENDING);
        //    }
        //    else
        //    {
        //        GridViewSortDirection = SortDirection.Ascending;
        //        SortGridView(sortExpression, ASCENDING);
        //    }
        //}

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

        protected void ddlFilterByProjectType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string status = "";
            if (ddlFilterByProjectType.SelectedValue != "ALL")
            { 
                status = TaskInfoDAL.GetProjectStatus(ddlFilterByProjectType.SelectedValue);
            }

            if(status.ToLower() == "completed" || status.ToLower() == "suspend")
            {
                GridView1.Columns[0].Visible = false;
            }
            else
            {
                GridView1.Columns[0].Visible = true;
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect(string.Format("~/CreateTask.aspx"));
        }
    }
}