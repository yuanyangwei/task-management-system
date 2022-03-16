using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace TMS.Controller
{
    public class TaskInfoDAL : Page
    {
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TMS"].ConnectionString);

        public static DataSet GetTaskInfo(string projectName, string username) 
        {
            con.Open();
            string assignee = LoginDAL.GetFullNameByUsername(username);
            string strCommandText = "";
            if (projectName == "ALL")
            {
                strCommandText = "SELECT task_id, T.project_id, project_name, task_name, task_desc, task_comment, task_status, priority, FORMAT(start_date, 'yyyy-MM-dd') as start_date, FORMAT(due_date, 'yyyy-MM-dd') as due_date, assigner, assignee FROM TaskInfo T INNER JOIN ProjectInfo P on P.project_id = T.project_id WHERE assignee ='" + assignee + "' ORDER BY project_name ASC";

            }
            else
            {
                strCommandText = "SELECT task_id, T.project_id, project_name, task_name, task_desc, task_comment, task_status, priority, FORMAT(start_date, 'yyyy-MM-dd') as start_date, FORMAT(due_date, 'yyyy-MM-dd') as due_date, assigner, assignee FROM TaskInfo T INNER JOIN ProjectInfo P on P.project_id = T.project_id WHERE project_name = '" + projectName + "' and assignee ='" + assignee + "' ORDER BY project_name ASC";

            }
            SqlDataAdapter mycustInfoAdapter = new SqlDataAdapter(strCommandText, con);
            con.Close();

            DataSet myDS = new DataSet();
            mycustInfoAdapter.Fill(myDS);
            //Bind the data read to the gridview control         
            return myDS;
        }
        
        public static DataSet PopulateProjectName(string username) // Need Change
        {
            con.Open();
            string assignee = LoginDAL.GetFullNameByUsername(username);
            string strCommandText = "SELECT DISTINCT T.project_id, project_name FROM TaskInfo T INNER JOIN ProjectInfo P on P.project_id = T.project_id WHERE assignee ='" + assignee + "' ORDER BY project_name ASC";
            SqlDataAdapter myProjectNameInfoAdapter = new SqlDataAdapter(strCommandText, con);
            con.Close();

            DataSet myDS = new DataSet();
            myProjectNameInfoAdapter.Fill(myDS);
            //Bind the data read to the gridview control         
            return myDS;
        }

        public static DataSet PopulateTaskStatus() // Need Change
        {
            con.Open();
            string strCommandText = "SELECT taskStatus FROM Parameter WHERE taskStatus IS　NOT　NULL";
            SqlDataAdapter myProjectNameInfoAdapter = new SqlDataAdapter(strCommandText, con);
            con.Close();

            DataSet myDS = new DataSet();
            myProjectNameInfoAdapter.Fill(myDS);
            //Bind the data read to the gridview control         
            return myDS;
        }

        public static string GetProjectStatus(string ProjectName) 
        {
            con.Open();
            string strCommandText = "SELECT DISTINCT project_status FROM ProjectInfo WHERE project_name ='" + ProjectName + "' ORDER BY project_status ASC";
            SqlDataAdapter myprojectStatusInfoAdapter = new SqlDataAdapter(strCommandText, con);
            SqlCommand passComm = new SqlCommand(strCommandText, con);
            var status = passComm.ExecuteScalar();
            con.Close();

            if (status == null)
                return "";
            else
                return status.ToString();
        }

        public static DataSet GetAllProjectStatus()
        {
            con.Open();
            string strCommandText = "SELECT projectStatus FROM Parameter WHERE projectStatus IS　NOT　NULL";
            SqlDataAdapter InfoAdapter = new SqlDataAdapter(strCommandText, con);
            con.Close();

            DataSet myDS = new DataSet();
            InfoAdapter.Fill(myDS);
            //Bind the data read to the gridview control         
            return myDS;
        }

        public static string GetTaskDueCount(string ProjectName)
        {
            con.Open();
            string strCommandText = "SELECT DISTINCT project_status FROM ProjectInfo WHERE project_name ='" + ProjectName + "' ORDER BY project_status ASC";
            SqlDataAdapter myprojectStatusInfoAdapter = new SqlDataAdapter(strCommandText, con);
            SqlCommand passComm = new SqlCommand(strCommandText, con);
            var status = passComm.ExecuteScalar();
            con.Close();

            if (status == null)
                return "";
            else
                return status.ToString();
        }

        public static string GetProjectID(string ProjectName)
        {
            con.Open();
            string strCommandText = "SELECT project_id FROM ProjectInfo WHERE project_name ='" + ProjectName + "'";
            SqlDataAdapter myprojectStatusInfoAdapter = new SqlDataAdapter(strCommandText, con);
            SqlCommand passComm = new SqlCommand(strCommandText, con);
            var projectID = passComm.ExecuteScalar();
            con.Close();

            if (projectID == null)
                return "";
            else
                return projectID.ToString();
        }

        public static string GetNewTaskCount(string username)
        {
            con.Open();
            string strCommandText = "SELECT COUNT(*) FROM TaskInfo WHERE assignee = '" + username + "' AND task_status = 'Pending'";
            SqlDataAdapter myprojectStatusInfoAdapter = new SqlDataAdapter(strCommandText, con);
            SqlCommand passComm = new SqlCommand(strCommandText, con);
            var status = passComm.ExecuteScalar();
            con.Close();

            if (status == null)
                return "";
            else
                return status.ToString();
        }

        public static string GetProjectNameByDepartment(string ProjectName, string username)
        {
            string department = LoginDAL.getDepartmentName(username);

            con.Open();
            string strCommandText = "SELECT DISTINCT project_name FROM ProjectInfo WHERE project_name ='" + ProjectName + "' AND department = '" + department + "'";
            SqlDataAdapter myprojectStatusInfoAdapter = new SqlDataAdapter(strCommandText, con);
            SqlCommand passComm = new SqlCommand(strCommandText, con);
            var projectname = passComm.ExecuteScalar();
            con.Close();
            
            if (projectname == null)
                return "";
            else
                return projectname.ToString();
        }

        public static DataSet GetUnarchivedProjectList(string username)
        {
            string department = LoginDAL.getDepartmentName(username);

            con.Open();
            string strCommandText = "SELECT project_id, project_name, project_des, project_status, department FROM ProjectInfo WHERE project_status <> 'Completed' and department = '" + department + "'";
            SqlDataAdapter myProjectNameInfoAdapter = new SqlDataAdapter(strCommandText, con);
            con.Close();

            DataSet myDS = new DataSet();
            myProjectNameInfoAdapter.Fill(myDS);
            //Bind the data read to the gridview control         
            return myDS;
        }

        public static DataSet GetArchivedProjectList(string username)
        {
            string department = LoginDAL.getDepartmentName(username);

            con.Open();
            string strCommandText = "SELECT project_id, project_name, project_des, project_status, department FROM ProjectInfo WHERE project_status = 'Completed' and department = '" + department + "'";
            SqlDataAdapter myProjectNameInfoAdapter = new SqlDataAdapter(strCommandText, con);
            con.Close();

            DataSet myDS = new DataSet();
            myProjectNameInfoAdapter.Fill(myDS);
            //Bind the data read to the gridview control         
            return myDS;
        }

        public static DataSet GetOngoingProjectList(string username)
        {
            string department = LoginDAL.getDepartmentName(username);

            con.Open();
            string strCommandText = "SELECT project_id, project_name, project_des, project_status, department FROM ProjectInfo WHERE project_status = 'Ongoing' and department = '" + department + "'";
            SqlDataAdapter myProjectNameInfoAdapter = new SqlDataAdapter(strCommandText, con);
            con.Close();

            DataSet myDS = new DataSet();
            myProjectNameInfoAdapter.Fill(myDS);
            //Bind the data read to the gridview control         
            return myDS;
        }
        
        public static void CreateNewProject(string projectName, string projectDesc, string projectStatus, string username)
        {
            string department = LoginDAL.getDepartmentName(username);
            string strCommandText = "INSERT INTO dbo.ProjectInfo (project_name,project_des,project_status,department) VALUES (@project_name,@project_des,@project_status,@department)";

            SqlCommand myCommand = new SqlCommand(strCommandText, con);
            myCommand.Parameters.AddWithValue("@project_name", projectName);
            myCommand.Parameters.AddWithValue("@project_des", projectDesc);
            myCommand.Parameters.AddWithValue("@project_status", projectStatus);
            myCommand.Parameters.AddWithValue("@department", department);

            con.Open();
            myCommand.ExecuteNonQuery();
            con.Close();
        }

        public static void CreateTask(string projectName, string task_name, string task_desc, string task_comment, string task_status, string priority, string start_date, string due_date, string assigner, string assignee)
        {
            string project_id = TaskInfoDAL.GetProjectID(projectName);
            string assignerFullName = LoginDAL.GetFullNameByUsername(assigner);
            DateTime ?start_date1 = null;
            DateTime ?due_date1 = null;

            IFormatProvider culture = new CultureInfo("en-US", true);

            if (start_date != "" && start_date != null)
            {
                start_date1 = DateTime.Parse(start_date, culture);
            }

            if (due_date != "" && due_date != null)
            {
                due_date1 = DateTime.Parse(due_date, culture);
            }

            string strCommandText = "INSERT INTO TaskInfo(project_id, task_name, task_desc, task_comment, task_status, priority, start_date, due_date, assigner, assignee) VALUES (@project_id, @task_name, @task_desc, @task_comment, @task_status, @priority, @start_date, @due_date, @assigner, @assignee)";

            SqlCommand myCommand = new SqlCommand(strCommandText, con);
            myCommand.Parameters.AddWithValue("@project_id", project_id);
            myCommand.Parameters.AddWithValue("@task_name", task_name);
            myCommand.Parameters.AddWithValue("@task_desc", task_desc);
            myCommand.Parameters.AddWithValue("@task_comment", task_comment);
            myCommand.Parameters.AddWithValue("@task_status", task_status);
            myCommand.Parameters.AddWithValue("@priority", priority);
            myCommand.Parameters.AddWithValue("@start_date", start_date1);
            myCommand.Parameters.AddWithValue("@due_date", due_date1);
            myCommand.Parameters.AddWithValue("@assigner", assignerFullName);
            myCommand.Parameters.AddWithValue("@assignee", assignee);
            con.Open();
            myCommand.ExecuteNonQuery();
            con.Close();
        }

        public static void UpdateTaskInfo(string task_id, string task_comment, string task_status)
        {
            con.Open();
            // TODO use SqlCommand, write an update statement using CustUserName and newEmail, then executeNonQuery()

            string strCommandText = "UPDATE TaskInfo SET task_comment = @task_comment, task_status = @task_status WHERE task_id = @task_id";
            SqlCommand cmd = new SqlCommand(strCommandText, con);
            cmd.Parameters.AddWithValue("@task_comment", task_comment);
            cmd.Parameters.AddWithValue("@task_status", task_status);
            cmd.Parameters.AddWithValue("@task_id", task_id);

            //Create Adaptder
            SqlDataAdapter myAdapter = new SqlDataAdapter(cmd);
            con.Close();

            //Create Dataset to store results of query
            DataSet myDS = new DataSet();
            //Fill the dataset with the results
            myAdapter.Fill(myDS);
            //Bind the data read to the gridview control
        }

        public static void UpdateProjectInfo(string project_id, string projectStatus, string projectDesc)
        {
            con.Open();
            // TODO use SqlCommand, write an update statement using CustUserName and newEmail, then executeNonQuery()

            string strCommandText = "UPDATE ProjectInfo SET project_des = @project_des, project_status = @project_status, lastupdate_date = @lastupdate_date WHERE project_id = @project_id";
            SqlCommand cmd = new SqlCommand(strCommandText, con);
            cmd.Parameters.AddWithValue("@project_des", projectDesc);
            cmd.Parameters.AddWithValue("@project_status", projectStatus);
            cmd.Parameters.AddWithValue("@project_id", project_id);
            cmd.Parameters.AddWithValue("@lastupdate_date", DateTime.Now);

            //Create Adaptder
            SqlDataAdapter myAdapter = new SqlDataAdapter(cmd);
            con.Close();

            //Create Dataset to store results of query
            DataSet myDS = new DataSet();
            //Fill the dataset with the results
            myAdapter.Fill(myDS);
            //Bind the data read to the gridview control
        }
    }
}