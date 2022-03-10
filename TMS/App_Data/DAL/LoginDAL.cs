using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace TMS.Controller
{
    public class LoginDAL : Page
    {
        static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TMS"].ConnectionString);

        public static string LoginAuthentication(string username, string password, int noOfAttemps)
        {
            con.Open();
            string strCommandText = "select account_type from LoginUser where username ='" + username + "' and password ='" + password + "'";
            SqlDataAdapter mycustInfoAdapter = new SqlDataAdapter(strCommandText, con);
            SqlCommand passComm = new SqlCommand(strCommandText, con);
            var userAcctType = passComm.ExecuteScalar();

            con.Close();

            if (userAcctType == null)
            {
                con.Open();
                string strCommandText1 = "select account_status from LoginUser where username ='" + username + "'";
                SqlDataAdapter mycustInfoAdapter1 = new SqlDataAdapter(strCommandText1, con);
                SqlCommand passComm1 = new SqlCommand(strCommandText1, con);
                var account_status = passComm1.ExecuteScalar();
                con.Close();

                if (account_status != null && account_status.ToString().ToLower() == "true")
                {
                    return "Your account has been locked because the number of consecutive log-in failures exceeded the maximum allowed, please contact your administrator for support.";
                }

                if (noOfAttemps == 1)
                {
                    //Lock the account
                    con.Open();
                    string updateStrCommandText = "UPDATE LoginUser SET account_status = @account_status WHERE username = @username";
                    SqlCommand cmd = new SqlCommand(updateStrCommandText, con);
                    cmd.Parameters.AddWithValue("@account_status", 1);
                    cmd.Parameters.AddWithValue("@username", username);

                    //Create Adaptder
                    SqlDataAdapter myAdapter = new SqlDataAdapter(cmd);
                    con.Close();

                    //Create Dataset to store results of query
                    DataSet myDS = new DataSet();
                    //Fill the dataset with the results
                    myAdapter.Fill(myDS);

                    return "Your account has been locked, please contact your administrator for support.";
                }

                return "Invalid Username or Password, please try again! Number of attempt left: ";
            }
            else
            {
                return userAcctType.ToString();
            }
        }

        public static string getUsername(string username, string password)
        {
            con.Open();
            string strCommandText = "select username from LoginUser where username ='" + username + "' and password ='" + password + "'";
            SqlDataAdapter mycustInfoAdapter = new SqlDataAdapter(strCommandText, con);
            SqlCommand passComm = new SqlCommand(strCommandText, con);
            var userName = passComm.ExecuteScalar();
            con.Close();

            if (userName == null)
                return "";
            else
                return userName.ToString();
        }

        public static string getRoleType(string username)
        {
            con.Open();
            string strCommandText = "select roleType from staff_info where username ='" + username + "'";
            SqlDataAdapter mycustInfoAdapter = new SqlDataAdapter(strCommandText, con);
            SqlCommand passComm = new SqlCommand(strCommandText, con);
            var roleType = passComm.ExecuteScalar();
            con.Close();

            if (roleType == null)
                return "";
            else
                return roleType.ToString();
        }

        public static string getDepartmentName(string username)
        {
            con.Open();
            string strCommandText = "select department from staff_info where username ='" + username + "'";
            SqlDataAdapter mycustInfoAdapter = new SqlDataAdapter(strCommandText, con);
            SqlCommand passComm = new SqlCommand(strCommandText, con);
            var roleType = passComm.ExecuteScalar();
            con.Close();

            if (roleType == null)
                return "";
            else
                return roleType.ToString();
        }

        public static string getCustNameByEmail(string email)
        {
            con.Open();
            string strCommandText = "select full_name from staff_info where email ='" + email + "'";
            SqlDataAdapter mycustInfoAdapter = new SqlDataAdapter(strCommandText, con);
            SqlCommand passComm = new SqlCommand(strCommandText, con);
            var custname = passComm.ExecuteScalar();
            con.Close();

            if (custname == null)
                return "";
            else
                return custname.ToString();
        }

        public static string getUserNameByEmail(string email)
        {
            con.Open();
            string strCommandText = "select username from staff_info where email ='" + email + "'";
            SqlDataAdapter mycustInfoAdapter = new SqlDataAdapter(strCommandText, con);
            SqlCommand passComm = new SqlCommand(strCommandText, con);
            var username = passComm.ExecuteScalar();
            con.Close();

            if (username == null)
                return "";
            else
                return username.ToString();
        }
        public static string checkFirstTimeUser(string username, string password)
        {
            con.Open();
            string strCommandText = "select first_visit from LoginUser where username ='" + username + "' and password ='" + password + "'";
            SqlDataAdapter mycustInfoAdapter = new SqlDataAdapter(strCommandText, con);
            SqlCommand passComm = new SqlCommand(strCommandText, con);
            var first_visit = passComm.ExecuteScalar();
            con.Close();

            if (first_visit == null)
                return "";
            else
                return first_visit.ToString();
        }

        public static void UpdatePassword(string password, int first_visit, string username)
        {
            con.Open();
            // TODO use SqlCommand, write an update statement using CustUserName and newEmail, then executeNonQuery()

            string strCommandText = "UPDATE LoginUser SET password = @password, first_visit = @first_visit, account_status = 0 WHERE username = @username";
            SqlCommand cmd = new SqlCommand(strCommandText, con);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@first_visit", first_visit);
            cmd.Parameters.AddWithValue("@username", username);

            //Create Adaptder
            SqlDataAdapter myAdapter = new SqlDataAdapter(cmd);
            con.Close();

            //Create Dataset to store results of query
            DataSet myDS = new DataSet();
            //Fill the dataset with the results
            myAdapter.Fill(myDS);
            //Bind the data read to the gridview control
        }

        public static void CreateUser(string email, string full_name, string phone_no, string position, string department, string roleType, string username, string password, string account_type)
        {
            string strCommandText = "INSERT INTO staff_info (email,full_name,phone_no,position,department,roleType,username) VALUES (@email,@full_name,@phone_no,@position,@department,@roleType,@username)";

            SqlCommand myCommand = new SqlCommand(strCommandText, con);
            myCommand.Parameters.AddWithValue("@email", email);
            myCommand.Parameters.AddWithValue("@full_name", full_name);
            myCommand.Parameters.AddWithValue("@phone_no", phone_no);
            myCommand.Parameters.AddWithValue("@position", position);
            myCommand.Parameters.AddWithValue("@department", department);
            myCommand.Parameters.AddWithValue("@roleType", roleType);
            myCommand.Parameters.AddWithValue("@username", username);

            string strCommandText1 = "INSERT INTO dbo.LoginUser (username,account_status,password,account_type,first_visit) VALUES (@username,@account_status,@password,@account_type,@first_visit)";

            SqlCommand myCommand1 = new SqlCommand(strCommandText1, con);
            myCommand1.Parameters.AddWithValue("@username", username);
            myCommand1.Parameters.AddWithValue("@account_status", 0);
            myCommand1.Parameters.AddWithValue("@password", password);
            myCommand1.Parameters.AddWithValue("@account_type", account_type);
            myCommand1.Parameters.AddWithValue("@first_visit", 1);

            con.Open();
            myCommand1.ExecuteNonQuery();
            myCommand.ExecuteNonQuery();
            con.Close();
        }

        public static DataSet PopulateDepartment() //get all feedback status is Pending
        {
            con.Open();
            string strCommandText = "SELECT department FROM Parameter WHERE department IS NOT NULL ORDER BY department ASC";
            SqlDataAdapter myProjectNameInfoAdapter = new SqlDataAdapter(strCommandText, con);
            con.Close();

            DataSet myDS = new DataSet();
            myProjectNameInfoAdapter.Fill(myDS);
            //Bind the data read to the gridview control         
            return myDS;
        }

        public static DataSet PopulatePosition() //get all feedback status is Pending
        {
            con.Open();
            string strCommandText = "SELECT position FROM Parameter WHERE position IS NOT NULL ORDER BY position ASC";
            SqlDataAdapter myProjectNameInfoAdapter = new SqlDataAdapter(strCommandText, con);
            con.Close();

            DataSet myDS = new DataSet();
            myProjectNameInfoAdapter.Fill(myDS);
            //Bind the data read to the gridview control         
            return myDS;
        }

        public static DataSet PopulateAllUserInfo() //get all feedback status is Pending
        {
            con.Open();
            string strCommandText = "SELECT employee_id, email, full_name, phone_no, position, department, roleType, S.username,account_status FROM staff_info S INNER JOIN LoginUser L on S.username = L.username ORDER BY full_name ASC";
            SqlDataAdapter myProjectNameInfoAdapter = new SqlDataAdapter(strCommandText, con);
            con.Close();

            DataSet myDS = new DataSet();
            myProjectNameInfoAdapter.Fill(myDS);
            //Bind the data read to the gridview control         
            return myDS;
        }

        public static string CheckUsernameExist(string username)
        {
            con.Open();
            string strCommandText = "select username from staff_info where username ='" + username + "'"; 
            SqlDataAdapter mycustInfoAdapter = new SqlDataAdapter(strCommandText, con);
            SqlCommand passComm = new SqlCommand(strCommandText, con);
            var name = passComm.ExecuteScalar();
            con.Close();

            if (name == null)
                return "";
            else
                return name.ToString();
        }

        public static string CheckEmailExist(string email)
        {
            con.Open();
            string strCommandText = "select email from staff_info where email ='" + email + "'";
            SqlDataAdapter mycustInfoAdapter = new SqlDataAdapter(strCommandText, con);
            SqlCommand passComm = new SqlCommand(strCommandText, con);
            var emailAdd = passComm.ExecuteScalar();
            con.Close();

            if (emailAdd == null)
                return "";
            else
                return emailAdd.ToString();
        }

        public static string CheckContactExist(string contact)
        {
            con.Open();
            string strCommandText = "select phone_no from staff_info where phone_no ='" + contact + "'";
            SqlDataAdapter mycustInfoAdapter = new SqlDataAdapter(strCommandText, con);
            SqlCommand passComm = new SqlCommand(strCommandText, con);
            var contactNo = passComm.ExecuteScalar();
            con.Close();

            if (contactNo == null)
                return "";
            else
                return contactNo.ToString();
        }

        public static void UpdateUserInfo(string designation, string department, string roleType, string accountLock, string username)
        {
            con.Open();
            // TODO use SqlCommand, write an update statement using CustUserName and newEmail, then executeNonQuery()

            string strCommandText = "UPDATE staff_info SET position = @position, department = @department, roleType = @roleType WHERE username = @username";
            SqlCommand cmd = new SqlCommand(strCommandText, con);
            cmd.Parameters.AddWithValue("@position", designation);
            cmd.Parameters.AddWithValue("@department", department);
            cmd.Parameters.AddWithValue("@roleType", roleType);
            cmd.Parameters.AddWithValue("@username", username);

            string strCommandText1 = "UPDATE LoginUser SET account_status = @account_status WHERE username = @username";
            SqlCommand cmd1 = new SqlCommand(strCommandText1, con);
            cmd1.Parameters.AddWithValue("@account_status", accountLock);
            cmd1.Parameters.AddWithValue("@username", username);


            //Create Adaptder
            SqlDataAdapter myAdapter = new SqlDataAdapter(cmd);
            SqlDataAdapter myAdapter1 = new SqlDataAdapter(cmd1);
            con.Close();

            //Create Dataset to store results of query
            DataSet myDS = new DataSet();
            DataSet myDS1 = new DataSet();
            //Fill the dataset with the results
            myAdapter.Fill(myDS);
            myAdapter1.Fill(myDS1);
            //Bind the data read to the gridview control
        }
        //public static DataSet GetAllCustInfo() //get all feedback status is Pending
        //{
        //    con.Open();
        //    string strCommandText = "SELECT username,password,fName,lName,nationality,finNRIC,FORMAT(dateOfBirth, 'yyyy-MM-dd') as dateOfBirth,contact,emailAddress,FORMAT(submissionDate, 'yyyy-MM-dd') as submissionDate, FORMAT(lastUpdateDate, 'yyyy-MM-dd') as lastUpdateDate FROM CustomerInfo";
        //    SqlDataAdapter mycustInfoAdapter = new SqlDataAdapter(strCommandText, con);
        //    con.Close();

        //    DataSet myDS = new DataSet();
        //    mycustInfoAdapter.Fill(myDS);
        //    //Bind the data read to the gridview control         
        //    return myDS;
        //}

        //public static void UpdateCustInfobyID(string username, string contact, string password, string email) //get all feedback status is Pending
        //{
        //    con.Open();
        //    // TODO use SqlCommand, write an update statement using CustUserName and newEmail, then executeNonQuery()

        //    string strCommandText = "UPDATE CustomerInfo SET contact = @contact, lastUpdateDate = @lastUpdateDate, emailAddress = @emailAddress, password = @password WHERE username = @username";
        //    SqlCommand cmd = new SqlCommand(strCommandText, con);
        //    cmd.Parameters.AddWithValue("@username", username);
        //    cmd.Parameters.AddWithValue("@contact", contact);
        //    cmd.Parameters.AddWithValue("@password", password);
        //    cmd.Parameters.AddWithValue("@emailAddress", email);
        //    cmd.Parameters.AddWithValue("@lastUpdateDate", DateTime.Today);

        //    //Create Adaptder
        //    SqlDataAdapter myAdapter = new SqlDataAdapter(cmd);
        //    con.Close();

        //    //Create Dataset to store results of query
        //    DataSet myDS = new DataSet();
        //    //Fill the dataset with the results
        //    myAdapter.Fill(myDS);
        //    //Bind the data read to the gridview control
        //}

        //public static void UpdateCustLoginInfobyID(string userID, string password)
        //{
        //    con.Open();
        //    string strCommandText = "Update Login SET password = @password where userId = @userID";
        //    SqlCommand cmd = new SqlCommand(strCommandText, con);
        //    cmd.Parameters.AddWithValue("userID", userID);
        //    cmd.Parameters.AddWithValue("password", password);

        //    SqlDataAdapter myAdapter = new SqlDataAdapter(cmd);
        //    con.Close();

        //    //Create Dataset to store results of query
        //    DataSet myDS = new DataSet();
        //    //Fill the dataset with the results
        //    myAdapter.Fill(myDS);
        //    //Bind the data read to the gridview control
        //}

        //public static void CreateFavoriteList(string username, int appListID, string lodgementDate, string expiryDate, string appType, string appProductName)
        //{
        //    string strCommandText = "INSERT INTO FavoriteList(appListID,appLodgementDate,expiryDate,username,appType,appProductName) VALUES (@appListID,@appLodgementDate,@expiryDate,@username,@appType,@appProductName)";

        //    SqlCommand myCommand = new SqlCommand(strCommandText, con);
        //    myCommand.Parameters.AddWithValue("@appListID", appListID);
        //    myCommand.Parameters.AddWithValue("@appLodgementDate", lodgementDate);
        //    myCommand.Parameters.AddWithValue("@expiryDate", expiryDate);
        //    myCommand.Parameters.AddWithValue("@username", username);
        //    myCommand.Parameters.AddWithValue("@appType", appType);
        //    myCommand.Parameters.AddWithValue("@appProductName", appProductName);

        //    con.Open();
        //    myCommand.ExecuteNonQuery();
        //    con.Close();
        //}

        //public static string GetFavList(string username, int appListID, string lodgementDate, string expiryDate, string appType, string appProductName) //get all feedback status is Pending
        //{
        //    con.Open();
        //    string strCommandText = "select appListID from FavoriteList where username ='" + username + "' and appListID = '" + appListID + "' and appLodgementDate = '" + lodgementDate + "' and expiryDate = '" + expiryDate + "' and appType = '" + appType + "' and appProductName = '" + appProductName + "'";
        //    SqlCommand passComm = new SqlCommand(strCommandText, con);
        //    var appListID1 = passComm.ExecuteScalar();
        //    con.Close();

        //    if (appListID1 == null)
        //        return "";
        //    else
        //        return appListID1.ToString();
        //}

        //public static DataSet GetFavListByUsername(string username) //get all feedback status is Pending
        //{
        //    con.Open();
        //    string strCommandText = "select appListID,FORMAT(appLodgementDate, 'yyyy-MM-dd') as appLodgementDate, FORMAT(expiryDate, 'yyyy-MM-dd') as expiryDate,appType,appProductName from FavoriteList where username ='" + username + "'";
        //    SqlDataAdapter mycustInfoAdapter = new SqlDataAdapter(strCommandText, con);
        //    con.Close();

        //    DataSet myDS = new DataSet();
        //    mycustInfoAdapter.Fill(myDS);
        //    //Bind the data read to the gridview control         
        //    return myDS;
        //}
        //public static void RemoveFavbyID(string username, string appListID, string lodgementDate, string expiryDate, string appType, string appProductName)
        //{
        //    con.Open();
        //    string strCommandText = "Delete from FavoriteList where username = @username and appListID = @appListID and expiryDate = @expiryDate and appLodgementDate = @appLodgementDate and appType = @appType and appProductName = @appProductName";
        //    SqlCommand cmd = new SqlCommand(strCommandText, con);
        //    cmd.Parameters.AddWithValue("username", username);
        //    cmd.Parameters.AddWithValue("appListID", appListID);
        //    cmd.Parameters.AddWithValue("expiryDate", expiryDate);
        //    cmd.Parameters.AddWithValue("appLodgementDate", lodgementDate);
        //    cmd.Parameters.AddWithValue("appType", appType);
        //    cmd.Parameters.AddWithValue("appProductName", appProductName);

        //    SqlDataAdapter myAdapter = new SqlDataAdapter(cmd);
        //    con.Close();

        //    //Create Dataset to store results of query
        //    DataSet myDS = new DataSet();
        //    //Fill the dataset with the results
        //    myAdapter.Fill(myDS);
        //    //Bind the data read to the gridview control
        //}
    }
}