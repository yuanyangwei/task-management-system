using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMS.Controller;

namespace TMS
{
    public partial class UserRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateDepartment();
                PopulatePosition();
                ResetTextField();
            }
            ValidationBox();
        }

        protected void btn_create_Click(object sender, EventArgs e)
        {
            if (ValidationBox() == true)
            {
                Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
                RegexOptions.CultureInvariant | RegexOptions.Singleline);
                bool isValidEmail = regex.IsMatch(txtEmail.Text);
                if (!isValidEmail && txtEmail.Text != "")
                {
                    Response.Write("<script language='javascript'>alert('Invalid email address!');" + "</script>");
                }
                else 
                { 
                    string newpassword = GetRandomString();
                    LoginDAL.CreateUser(txtEmail.Text.ToLower(), txtFName.Text, txtContact.Text, ddlDesignation.SelectedValue, ddlDepartment.SelectedValue, ddlRoleType.SelectedValue, txtUserName.Text.ToLower(), newpassword, ddlAccessType.SelectedValue);
                    SendMail(txtEmail.Text.ToLower(), newpassword, txtFName.Text);
                    ResetTextField();
                    Response.Write("<script language='javascript'>alert('Account has been set up successfully!');" + "</script>");
                }
            }   
        }

        protected void ResetTextField()
        {
            txtContact.Text = "";
            txtEmail.Text = "";
            txtFName.Text = "";
            txtUserName.Text = "";
        }

        protected bool ValidationBox()
        {
            string email = LoginDAL.CheckEmailExist(txtEmail.Text.ToLower().Trim());
            string username = LoginDAL.CheckUsernameExist(txtUserName.Text.ToLower().Trim());
            string contactNo = LoginDAL.CheckContactExist(txtContact.Text);

            if (txtContact.Text != "" && txtEmail.Text != "" && txtUserName.Text != "")
            {
                RequiredFieldValidator9.InitialValue = email;
                RequiredFieldValidator9.ErrorMessage = "Email adddress has been registered, please use another Email!";
                RequiredFieldValidator7.InitialValue = username;
                RequiredFieldValidator7.ErrorMessage = "Username has been registered, please use another username!";
                RequiredFieldValidator3.InitialValue = contactNo;
                RequiredFieldValidator3.ErrorMessage = "Contact number has been registered, please use another contact number!";
            }

            if (username == "" && contactNo == "" && email == "") //all new value
                return true;
            else
                return false;
        }
        public static string GetRandomString()
        {
            string path = Path.GetRandomFileName();
            path = path.Replace(".", ""); // Remove period.
            return path;
        }

        protected void SendMail(string toEmail, string newpassword, string custname)
        {
            var currentDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            string projectDirectory = currentDirectory.FullName;
            SmtpSection smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            using (MailMessage mm = new MailMessage(smtpSection.From, toEmail))
            {
                string Body = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("EmailTemplateNewAcctPassword.html"));
                Body = Body.Replace("#customerName#", custname);
                Body = Body.Replace("#newpassword#", newpassword);

                mm.IsBodyHtml = true;
                //create Alrternative HTML view
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(Body, null, "text/html");

                //Add Image
                LinkedResource theEmailImage = new LinkedResource(projectDirectory + "\\Image\\Icon.PNG");
                theEmailImage.ContentId = "myImageID";

                //Add the Image to the Alternate view
                htmlView.LinkedResources.Add(theEmailImage);

                //Add view to the Email Message
                mm.AlternateViews.Add(htmlView);
                mm.Subject = "Account Password Reset Request";
                //mm.Body = Body;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = smtpSection.Network.Host;
                smtp.EnableSsl = smtpSection.Network.EnableSsl;
                NetworkCredential networkCred = new NetworkCredential(smtpSection.Network.UserName, smtpSection.Network.Password);
                smtp.UseDefaultCredentials = smtpSection.Network.DefaultCredentials;
                smtp.Credentials = networkCred;
                smtp.Port = smtpSection.Network.Port;
                smtp.Send(mm);
            }
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
    }
}
