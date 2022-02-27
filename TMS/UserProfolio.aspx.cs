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
    public partial class UserProfolio : Page
    {
        private static readonly string TBL_KEY = "tbl";
        private const string ASCENDING = " ASC";
        private const string DESCENDING = " DESC";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
                //PopulateProjectName();
            }
        }

        protected void BindGridView()
        {
            GridView1.DataSource = LoginDAL.PopulateAllUserInfo();
            GridView1.DataBind();
        }

        private void PopulateDepartment()
        {
            DataSet ds = new DataSet();
            ds = LoginDAL.PopulateDepartment();
            
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ddlDepartment.Items.Add(ds.Tables[0].Rows[i]["department"].ToString());
            }
        }

        private void PopulatePosition()
        {
            DataSet ds = new DataSet();
            ds = LoginDAL.PopulatePosition();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                ddlDesignation.Items.Add(ds.Tables[0].Rows[i]["position"].ToString());
            }
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


            //BindGridView();

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

    }
}