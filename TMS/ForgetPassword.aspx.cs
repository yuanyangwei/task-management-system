using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TMS.Controller;

namespace TMS
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Login_Click(object sender, EventArgs e)
        {
            Response.Redirect(string.Format("~/LoginPage.aspx"));
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            string custname = LoginDAL.getCustNameByEmail(txtEmail.Text.ToLower());

            if (custname != "")
            {
                string newpassword = GetRandomString();

                SendMail(txtEmail.Text.ToLower(), newpassword, custname);
                LoginDAL.UpdatePassword(newpassword, 1, LoginDAL.getUserNameByEmail(txtEmail.Text.ToLower()));
                Response.Write("<script language='javascript'>alert('Email has been send successfully!');" + "</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>alert('Email address not found!');" + "</script>");
            }
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
                string Body = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("EmailTemplateResetPassword.html"));
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
    }
}