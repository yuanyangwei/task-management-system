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
    public partial class UserPortfolio : System.Web.UI.Page
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

        protected void BindGridView()
        {
            GridView1.DataSource = LoginDAL.PopulateAllUserInfo();
            GridView1.DataBind();
        }


        // row edit event
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        protected void RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && GridView1.EditIndex == e.Row.RowIndex)
            {
                DropDownList ddlDesignation = (DropDownList)e.Row.FindControl("ddlDesignation");
                DataSet ds1 = new DataSet();
                ds1 = LoginDAL.PopulatePosition();

                ddlDesignation.DataSource = ds1;
                ddlDesignation.DataTextField = "Position";
                ddlDesignation.DataValueField = "Position";
                ddlDesignation.DataBind();
                string selectedPosition = DataBinder.Eval(e.Row.DataItem, "Position").ToString();
                ddlDesignation.Items.FindByValue(selectedPosition).Selected = true;

                DropDownList ddlDepartment = (DropDownList)e.Row.FindControl("ddlDepartment");
                DataSet ds = new DataSet();
                ds = LoginDAL.PopulateDepartment();

                ddlDepartment.DataSource = ds;
                ddlDepartment.DataTextField = "Department";
                ddlDepartment.DataValueField = "Department";
                ddlDepartment.DataBind();
                string selectedDepartment = DataBinder.Eval(e.Row.DataItem, "Department").ToString();
                ddlDepartment.Items.FindByValue(selectedDepartment).Selected = true;

                DropDownList ddlRoleType = (DropDownList)e.Row.FindControl("ddlRoleType");
                DataSet ds2 = new DataSet();
                ds2 = LoginDAL.PopulateRoleType();

                ddlRoleType.DataSource = ds2;
                ddlRoleType.DataTextField = "roleType";
                ddlRoleType.DataValueField = "roleType";
                ddlRoleType.DataBind();
                string selectedRoleType = DataBinder.Eval(e.Row.DataItem, "roleType").ToString();
                ddlRoleType.Items.FindByValue(selectedRoleType).Selected = true;

            }
        }
         

        // row update event
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

            string designation = (GridView1.Rows[e.RowIndex].FindControl("ddlDesignation") as DropDownList).SelectedItem.Value;
            string department = (GridView1.Rows[e.RowIndex].FindControl("ddlDepartment") as DropDownList).SelectedItem.Value;
            string roleType = (GridView1.Rows[e.RowIndex].FindControl("ddlRoleType") as DropDownList).SelectedItem.Value;
            string account_status = (GridView1.Rows[e.RowIndex].FindControl("dllAcctStatus") as DropDownList).SelectedItem.Value;
            if (account_status == "Locked")
                account_status = "true";
            else
                account_status = "false";
            string username = (GridView1.Rows[e.RowIndex].FindControl("lblUsername") as Label).Text;
            LoginDAL.UpdateUserInfo(designation, department, roleType, account_status, username);
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

    }
}