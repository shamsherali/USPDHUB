using System;
using System.Data;
using System.Data.SqlClient;

namespace USPDHUBDAL
{
    public class Utilities : DataAccess
    {
        public Utilities()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public static DataTable GetAllCitiesByState(string statename, string countyname)
        {
            DataTable cities = new DataTable("cities");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetCitiesByState", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@statename", statename);
                sqlCmd.Parameters.AddWithValue("@countryname", countyname);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(cities);

                return cities;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static DataTable GetAllStatesByCountry(string countyname)
        {
            DataTable states = new DataTable("states");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetStatesByCountry", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@countryname", countyname);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(states);

                return states;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static DataTable GetAllShortStatesByCountry(string countyname)
        {
            DataTable states = new DataTable("states");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetShortStatesByCountry", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@countryname", countyname);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(states);

                return states;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static DataTable GetAllZipcodesByCities(string cityname)
        {
            DataTable zips = new DataTable("zips");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetZipcodesByCityname", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Cityname", cityname);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(zips);

                return zips;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static int AddReferAFriendDetails(int userID, string rFirstname, string rlastname, string ffirstname, string fLastname, string femail, string message, bool conFlag, int tempprofileid, int iD)
        {
            DataTable vtable = new DataTable("friend");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_AddReferAFriendDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@UserID", userID);
                sqlCmd.Parameters.AddWithValue("@RFirstname", rFirstname);
                sqlCmd.Parameters.AddWithValue("@RLastname", rlastname);
                sqlCmd.Parameters.AddWithValue("@FFirstname", ffirstname);
                sqlCmd.Parameters.AddWithValue("@FLastname", fLastname);
                sqlCmd.Parameters.AddWithValue("@FEmail", femail);
                sqlCmd.Parameters.AddWithValue("@ConsumerFlag", conFlag);
                sqlCmd.Parameters.AddWithValue("@ReferMsg", message);
                sqlCmd.Parameters.AddWithValue("@Profile_ID", tempprofileid);
                sqlCmd.Parameters.AddWithValue("@ID", iD);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);
                if (vtable != null)
                {
                    returnval = Convert.ToInt32(vtable.Rows[0][0]);
                }

                return returnval;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        public static DataTable GetConfigDetailsbyName(string configName)
        {
            DataTable config = new DataTable("config");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetWOWzzyConfigsByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ConfigName", configName);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(config);

                return config;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }
        //Validate Zip code
        public static DataTable VaildateUserZipCode(string zipCode)
        {
            DataTable dtZipCode = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand objcmd = new SqlCommand();
                objcmd.Connection = sqlCon;
                objcmd.CommandType = CommandType.StoredProcedure;
                objcmd.CommandText = "Usp_ValidateZipcode ";
                objcmd.Parameters.AddWithValue("@Zip_Code", zipCode);
                SqlDataAdapter objda = new SqlDataAdapter(objcmd);
                objda.Fill(dtZipCode);
                return dtZipCode;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static DataTable Getlatitudeandlongitudebycity(string city, string state)
        {
            DataTable dtcityinfo = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand objcmd = new SqlCommand();
                objcmd.Connection = sqlCon;
                objcmd.CommandType = CommandType.StoredProcedure;
                objcmd.CommandText = "usp_GetCityInfo";
                objcmd.Parameters.AddWithValue("@City", city);
                objcmd.Parameters.AddWithValue("@State", state);
                SqlDataAdapter objda = new SqlDataAdapter(objcmd);
                objda.Fill(dtcityinfo);
                return dtcityinfo;


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        public static void UpdateOptoutstatusbyUserId(int userID, bool optoutFlag)
        {
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand objcmd = new SqlCommand();
                objcmd.Connection = sqlCon;
                objcmd.CommandType = CommandType.StoredProcedure;
                objcmd.CommandText = "Alrt_UpdateUserOptoutStatus";
                objcmd.Parameters.AddWithValue("@OptoutStatus", optoutFlag);
                objcmd.Parameters.AddWithValue("@User_ID", userID);
                objcmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        //Start Unsubscribe General Email...!--Suresh

        public static void UnsubscribeGeneralMail(string emailID, string optOutFlag)
        {

            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_UnsubscribeGeneralMail", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Contact_EmailAddress", emailID);
                sqlCmd.Parameters.AddWithValue("@OptOut_Flag", optOutFlag);
                sqlCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        //End Unsubscribe General Email...!--Suresh

        //Start:- Get Unsubscribe user status...! Suresh

        public static DataTable GetUnsubscribeuserstatus(string emailID)
        {
            DataTable vtable = new DataTable("friend");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("Usp_GetUnsubscribestaus", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@EmailID", emailID);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);

                return vtable;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

        //End:- Unsubscribe user status....! Suresh
        public static DataTable GetCitySttateForZipCode(string zipCode)
        {
            DataTable vtable = new DataTable("validate");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetCityStateForZipCode", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Zipcode", zipCode);
                SqlDataAdapter sqlAdptr = new SqlDataAdapter(sqlCmd);
                sqlAdptr.Fill(vtable);

                return vtable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                ConnectionManager.Instance.ReleaseSQLConnection(sqlCon);
            }
        }

    }
}
