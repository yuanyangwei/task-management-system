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
    public partial class UpdateProfileDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateData();
            }
            ValidationBox();
        }

        protected void btn_Edit_Click(object sender, EventArgs e)
        {
            if (ValidationBox() == true)
            {
                if (txtContact.Text == LoginDAL.getContactByUsername(Session["Username"].ToString()) && txtEmail.Text == LoginDAL.getEmailByUsername(Session["Username"].ToString())) //No change has been make
                {
                    Response.Write("<script language='javascript'>alert('No account information has been updated');" + "</script>");
                }
                else
                {
                    LoginDAL.UpdateUserProfile(txtEmail.Text.ToLower(), txtContact.Text, Session["Username"].ToString());
                    Response.Write("<script language='javascript'>alert('Account has been updated successfully!');" + "</script>");
                }
            }
        }

        protected bool ValidationBox()
        {
            string email = LoginDAL.CheckEmailExist(txtEmail.Text.ToLower().Trim());
            string contactNo = LoginDAL.CheckContactExist(txtContact.Text);

            if (txtContact.Text == LoginDAL.getContactByUsername(Session["Username"].ToString()))
                contactNo = "";

            if (txtEmail.Text == LoginDAL.getEmailByUsername(Session["Username"].ToString()))
                email = "";

            if (txtContact.Text != "" && txtEmail.Text != "")
            {
                RequiredFieldValidator9.InitialValue = email;
                RequiredFieldValidator9.ErrorMessage = "Email adddress has been registered, please use another Email!";
                RequiredFieldValidator3.InitialValue = contactNo;
                RequiredFieldValidator3.ErrorMessage = "Contact number has been registered, please use another contact number!";
            }

            if (contactNo == "" && email == "") //all new value
                return true;
            else
                return false;

            //if (txtContact.Text != "" && txtEmail.Text != "")
            //{
            //    RequiredFieldValidator9.InitialValue = email;
            //    RequiredFieldValidator9.ErrorMessage = "Email adddress has been registered, please use another Email!";
            //    RequiredFieldValidator3.InitialValue = contactNo;
            //    RequiredFieldValidator3.ErrorMessage = "Contact number has been registered, please use another contact number!";
            //}

            //if (txtContact.Text != LoginDAL.getContactByUsername(Session["Username"].ToString()) && contactNo == "" || txtEmail.Text != LoginDAL.getEmailByUsername(Session["Username"].ToString()) && email == "")
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            //if (contactNo == "" && email == "") //all new value
            //    return true;
            //else
            //    return false;
        }

        protected void PopulateData()
        {
            txtContact.Text = string.Empty;
            txtEmail.Text = string.Empty;

            DataSet ds = new DataSet();
            ds = LoginDAL.GetUserInfoByUsername(Session["Username"].ToString());

            txtContact.Text = ds.Tables[0].Rows[0]["phone_no"].ToString();
            txtDepartment.Text = ds.Tables[0].Rows[0]["department"].ToString();
            txtDesignation.Text = ds.Tables[0].Rows[0]["position"].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0]["email"].ToString();
            txtFName.Text = ds.Tables[0].Rows[0]["full_name"].ToString();
        }
    }
}