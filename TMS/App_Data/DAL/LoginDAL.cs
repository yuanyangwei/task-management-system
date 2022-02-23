﻿using System;
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

            return userName.ToString();
        }

        public static string checkFirstTimeUser(string username, string password)
        {
            con.Open();
            string strCommandText = "select first_visit from LoginUser where username ='" + username + "' and password ='" + password + "'";
            SqlDataAdapter mycustInfoAdapter = new SqlDataAdapter(strCommandText, con);
            SqlCommand passComm = new SqlCommand(strCommandText, con);
            var first_visit = passComm.ExecuteScalar();
            con.Close();

            return first_visit.ToString();
        }

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