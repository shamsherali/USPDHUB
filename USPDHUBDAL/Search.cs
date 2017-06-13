using System;
using System.Data;
using System.Data.SqlClient;

namespace USPDHUBDAL
{
    public class Search : DataAccess
    {
        public Search()
        {

        }

        public static DataTable ProfileSimpleSearch(string txtwhat, string txtwhere, int pageSize, int pageIndex)
        {
            DataTable vtable = new DataTable("search");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                // Split and see the values.
                string whatcity = string.Empty;
                string whatstate = string.Empty;
                char[] splitter = { ',' };
                string[] strsplitvalues = txtwhere.Split(splitter);
                if (strsplitvalues.Length == 2)
                {
                    whatcity = strsplitvalues[0].ToString().Trim();
                    whatstate = strsplitvalues[1].ToString().Trim();


                }
                else
                {
                    whatcity = "";
                    whatstate = txtwhere;
                }
                SqlCommand sqlCmd = new SqlCommand("USP_SimpleBusinessSearch11", sqlCon);
                //SqlCommand sqlCmd = new SqlCommand("usp_NewSimpleProfileSearch1", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@whattxt", txtwhat.Trim());
                sqlCmd.Parameters.AddWithValue("@wheretext", whatcity);
                sqlCmd.Parameters.AddWithValue("@wherestate", whatstate);
                sqlCmd.Parameters.AddWithValue("@PageIndex", pageIndex);
                sqlCmd.Parameters.AddWithValue("@PageSize", pageSize);
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

        // This is temporary function needs to be replaced later.
        public static DataTable ProfileSimpleSearch1(string txtwhat, string txtwhere, int pageSize, int pageIndex)
        {
            DataTable vtable = new DataTable("search");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_SimpleBusinessSearch22", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@whattxt", txtwhat);
                sqlCmd.Parameters.AddWithValue("@wheretext", txtwhere);
                sqlCmd.Parameters.AddWithValue("@PageIndex", pageIndex);
                sqlCmd.Parameters.AddWithValue("@PageSize", pageSize);
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

        public static DataTable ProfileSimpleSearch221(string txtwhat, string txtwhere, int pageSize, int pageIndex)
        {
            DataTable vtable = new DataTable("search");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_SimpleBusinessSearch1", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@whattxt", txtwhat);
                sqlCmd.Parameters.AddWithValue("@wheretext", txtwhere);

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

        public static DataTable GetProfileReviewValues(int profileID)
        {
            DataTable vtable = new DataTable("search");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetReviewValuesByID", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@ProfileID", profileID);
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

        // Get StateName

        public static DataTable GetStateName()
        {
            DataTable vtable = new DataTable("search");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetState", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
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

        // GET City Name

        public static DataTable GetCityName(string statename)
        {
            DataTable vtable = new DataTable("search");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_FilterCityByState", sqlCon);
                sqlCmd.Parameters.AddWithValue("@statename", statename);
                sqlCmd.CommandType = CommandType.StoredProcedure;
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


        // Get Industrys

        public static DataTable GetAllMainIndustryCategories()
        {
            DataTable vtable = new DataTable("indus");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_GetIndustryCategories", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
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


        // Filter Alphabets 

        public static DataTable GetFilterAlphabet(string alphabet, string statename)
        {
            DataTable vtable = new DataTable("search");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_Alphabet", sqlCon);
                sqlCmd.Parameters.AddWithValue("@alphabet", alphabet);
                sqlCmd.Parameters.AddWithValue("@statename", statename);
                sqlCmd.CommandType = CommandType.StoredProcedure;
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

        public static int AddFailureSearchScenerio(string whattxt, string wheretxt)
        {
            DataTable vtable = new DataTable("consumer");
            int returnval = 0;
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                SqlCommand sqlCmd = new SqlCommand("usp_InsertFailedSearchDetails", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@whattxt", whattxt);
                sqlCmd.Parameters.AddWithValue("@Wheretxt", wheretxt);

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
        public static int GetSearchBusinessCount(string txtwhat, string txtwhere)
        {
            string whatcity = string.Empty;
            string whatstate = string.Empty;
            char[] splitter = { ',' };
            string[] strsplitvalues = txtwhere.Split(splitter);
            if (strsplitvalues.Length == 2)
            {
                whatcity = strsplitvalues[0].ToString().Trim();
                whatstate = strsplitvalues[1].ToString().Trim();

            }
            else
            {
                whatcity = "";
                whatstate = txtwhere;

            }
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_GetBusinessSearchCount", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@whattxt", txtwhat.Trim());
                sqlCmd.Parameters.AddWithValue("@wheretext", whatcity);
                sqlCmd.Parameters.AddWithValue("@wherestate", whatstate);
                sqlCmd.Connection = sqlCon;
                int count = (int)sqlCmd.ExecuteScalar();
                return count;
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

        public static DataTable SimpleProfileSearch(string txtwhat, string txtwhere)
        {
            DataTable vtable = new DataTable("search");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            string whatcity = string.Empty;
            string whatstate = string.Empty;
            char[] splitter = { ',' };
            if (txtwhere.Length > 0)
            {
                string[] strsplitvalues = txtwhere.Split(splitter);
                if (strsplitvalues.Length == 2)
                {
                    whatcity = strsplitvalues[0].ToString().Trim();
                    whatstate = strsplitvalues[1].ToString().Trim();

                }
                else
                {
                    whatcity = "";
                    whatstate = txtwhere;

                }
            }
            else
            {
                whatcity = "";
                whatstate = "";
            }
            try
            {
                SqlCommand sqlCmd = new SqlCommand("USP_SimpleProfileSearch", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@whattxt", txtwhat.Trim());
                sqlCmd.Parameters.AddWithValue("@wheretext", whatcity);
                sqlCmd.Parameters.AddWithValue("@wherestate", whatstate);

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
        //Method by Pallavi on 22 october
        public static DataTable GetSearchDetails(string profilePhone, string profileName, string profileZipCode, string profileCity, string profileState, string profileStreetAddress1)
        {
            DataTable vtable = new DataTable();
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {



                SqlCommand sqlCmd = new SqlCommand("usp_SimpleProfileSearch11", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Profile_Phone", profilePhone);
                sqlCmd.Parameters.AddWithValue("@Profile_StreetAddress", profileStreetAddress1);
                sqlCmd.Parameters.AddWithValue("@Profile_State", profileState);
                sqlCmd.Parameters.AddWithValue("@Profile_city", profileCity);
                sqlCmd.Parameters.AddWithValue("@Profile_ZipCode", profileZipCode);
                sqlCmd.Parameters.AddWithValue("@Profile_Name", profileName);
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

        public static DataTable NewProfileSimpleSearch(string txtwhat, string txtwhere)
        {
            DataTable vtable = new DataTable("search");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                // Split and see the values.
                string whatcity = string.Empty;
                string whatstate = string.Empty;
                string whattext1 = string.Empty;
                whattext1 = txtwhat.Replace("'", "''");
                char[] splitter = { ',' };
                string[] strsplitvalues = txtwhere.Split(splitter);
                if (strsplitvalues.Length == 2)
                {
                    whatcity = strsplitvalues[0].ToString().Trim();
                    whatstate = strsplitvalues[1].ToString().Trim();

                }
                else
                {
                    whatcity = "";
                    whatstate = txtwhere;
                }
                SqlCommand sqlCmd = new SqlCommand("usp_NewSimpleProfileSearch1", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@whattxt", whattext1.Trim());
                sqlCmd.Parameters.AddWithValue("@wheretext", whatcity);
                sqlCmd.Parameters.AddWithValue("@wherestate", "\"" + whatstate + "\"");
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

        public static DataTable NewProfileSimpleOnlineSearch(string txtwhat)
        {
            DataTable vtable = new DataTable("search");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();
            try
            {
                // Split and see the values.
                string whattext1 = string.Empty;
                whattext1 = txtwhat.Replace("'", "''");
                SqlCommand sqlCmd = new SqlCommand("USP_NewSampleOnlineSearch", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@whattxt", whattext1.Trim());
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

        // Start Release 1.4

        public static DataTable GetBusinessSearchDetails(string businessname, string address, string zipcode, string phonenumber)
        {
            DataTable vtable = new DataTable("search");
            SqlConnection sqlCon = ConnectionManager.Instance.GetSQLConnection();

            try
            {
                // Split and see the values.

                businessname = businessname.Replace("'", "''");
                address = address.Replace("'", "''");
                zipcode = zipcode.Replace("'", "''");
                phonenumber = phonenumber.Replace("'", "''");


                SqlCommand sqlCmd = new SqlCommand("usp_BusinessSearch", sqlCon);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                sqlCmd.Parameters.AddWithValue("@Businessname", businessname);
                sqlCmd.Parameters.AddWithValue("@Address", address);
                sqlCmd.Parameters.AddWithValue("@Zipcode", zipcode);
                sqlCmd.Parameters.AddWithValue("@PhoneNumber", phonenumber);
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

        // End release 1.4
    }
}
