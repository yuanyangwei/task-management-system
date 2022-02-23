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

namespace TMS
{
    public partial class PasswordReset : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_update_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(strConnString);
            //con.Open();
            //str = "select * from login ";
            //com = new SqlCommand(str, con);
            //SqlDataReader reader = com.ExecuteReader();
            //while (reader.Read())
            //{
            //    if (txt_cpassword.Text == reader["Password"].ToString())
            //    {
            //        up = 1;
            //    }
            //}
            //reader.Close();
            //con.Close();
            //if (up == 1)
            //{
            //    con.Open();
            //    str = "update login set Password=@Password where UserName='" + Session["UserName"].ToString() + "'";
            //    com = new SqlCommand(str, con);
            //    com.Parameters.Add(new SqlParameter("@Password", SqlDbType.VarChar, 50));
            //    com.Parameters["@Password"].Value = txt_npassword.Text;
            //    com.ExecuteNonQuery();
            //    con.Close();
            //    lbl_msg.Text = "Password changed Successfully";
            //}
            //else
            //{
            //    lbl_msg.Text = "Please enter correct Current password";
            //}
        }

        protected void SendMail(string toEmail, string newpassword)
        {
            var currentDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            string projectDirectory = currentDirectory.FullName;
            SmtpSection smtpSection = (SmtpSection)ConfigurationManager.GetSection("system.net/mailSettings/smtp");
            using (MailMessage mm = new MailMessage(smtpSection.From, toEmail))
            {
                string Body = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("EmailTemplateResetPassword.html"));
                Body = Body.Replace("#customerName#", Session[""].ToString());
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