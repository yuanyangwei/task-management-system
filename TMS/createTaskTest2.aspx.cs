using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TMS
{
    public partial class CreateTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Calendar1.Visible = false;
                Calendar2.Visible = false;
                hide_calendar_row.Visible = false;
   
            }

           


        }


        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible == false)
            {
                Calendar1.Visible = true;
                hide_calendar_row.Visible = true;
            }
            else
            {
                Calendar1.Visible = false;
                hide_calendar_row.Visible = false;
            }
        }

        protected void ImageButton2_Click1(object sender, ImageClickEventArgs e)
        {
            if (Calendar2.Visible == false)
            {
                Calendar2.Visible = true;
                hide_calendar_row.Visible = true;
            }
            else
            {
                Calendar2.Visible = false;
                hide_calendar_row.Visible = false;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            cal_start.Text = Convert.ToString(Calendar1.SelectedDate);
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            cal_end.Text = Convert.ToString(Calendar2.SelectedDate);
        }

        protected void CreateTaskButton_Click(object sender, EventArgs e)
        {

        }
    }
}