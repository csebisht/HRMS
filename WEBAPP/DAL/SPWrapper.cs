using NLog;
using System;
using System.Configuration;
using System.Data;
using WEBAPP.Models;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace WEBAPP.DAL
{
    public static class SPWrapper
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static DataSet GetUserList()
        {
            DataSet dsTransctionData = new DataSet();
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter;
            try
            {
                adapter = new SqlDataAdapter(StoredProcedures.GetUsers, lobjConn);
                adapter.Fill(ds, "Users");
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetUserList Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();
                 
            }
            return ds;
        }
        public static DataSet GetCompanyStream()
        {
            DataSet dsTransctionData = new DataSet();
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter;
            try
            {
                adapter = new SqlDataAdapter(StoredProcedures.getCompanyStreamList, lobjConn);
                adapter.Fill(ds, "CompanyStream");
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetCompanyStream Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();
            }
            return ds;
        }
        public static DataSet GetCompanyStreamById(int Id)
        {
            DataSet dsTransctionData = new DataSet();
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
           
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.getCompanyStreamListById, lobjConn);
                ocmd.Parameters.AddWithValue(DBFields.Id, Id);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                DataTable table = new DataTable();
                table.Load(ocmd.ExecuteReader());
                ds.Tables.Add(table);
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetCompanyStreamById Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();
            }
            return ds;
        }
        public static DataSet GetPastRecruitment()
        {
            
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter;
            try
            {
                adapter = new SqlDataAdapter(StoredProcedures.GetPastRecruitment, lobjConn);
                adapter.Fill(ds, "PastRecruitment");
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper PastRecruitment Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();
                 
            }
            return ds;
        }
        public static DataSet GetPastRecruitmentById()
        {

            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter;
            try
            {
                adapter = new SqlDataAdapter(StoredProcedures.GetPastRecruitment, lobjConn);
                adapter.Fill(ds, "PastRecruitment");
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper PastRecruitment Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();

            }
            return ds;
        }
        public static DataSet GetCompanystatus()
        {
            DataSet dsTransctionData = new DataSet();
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter;
            try
            {
                adapter = new SqlDataAdapter(StoredProcedures.GetCompanystatus, lobjConn);
                adapter.Fill(ds, "PastRecruitment");
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper PastRecruitment Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();
                 
            }
            return ds;
        }
        public static DataSet GetPastHiring()
        {
            DataSet dsTransctionData = new DataSet();
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter;
            try
            {
                adapter = new SqlDataAdapter(StoredProcedures.GetPastHiring, lobjConn);
                adapter.Fill(ds, "PastRecruitment");
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper PastRecruitment Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();
                 
            }
            return ds;
        }

        public static DataSet GetPastHiringById(int Id)
        {
            DataSet dsTransctionData = new DataSet();
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
           
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.GetPastHiringById, lobjConn);
                ocmd.Parameters.AddWithValue(DBFields.Id, Id);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                DataTable table = new DataTable();
                table.Load(ocmd.ExecuteReader());
                ds.Tables.Add(table);
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper PastRecruitment Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();

            }
            return ds;
        }
        public static DataSet GetCallNote()
        {
            DataSet dsTransctionData = new DataSet();
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter;
            try
            {
                adapter = new SqlDataAdapter(StoredProcedures.GetCallNotes, lobjConn);
                adapter.Fill(ds, "CallNotes");
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetCallNotes Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();
                 
            }
            return ds;
        }


        public static DataSet GetCallNoteForReminder()
        {
            DataSet dsTransctionData = new DataSet();
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter;
            try
            {
                adapter = new SqlDataAdapter(StoredProcedures.GetCallNotesForReminder, lobjConn);
                adapter.Fill(ds, "CallNotesForReminder");
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper CallNotesForReminder Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();

            }
            return ds;
        }
        public static DataSet GetCallNoteById(int Id)
        {
            DataSet dsTransctionData = new DataSet();
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.GetCallNotesById, lobjConn);
                ocmd.Parameters.AddWithValue(DBFields.Id, Id);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                DataTable table = new DataTable();
                table.Load(ocmd.ExecuteReader());
                ds.Tables.Add(table);

            }          
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetCallNotesById Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();

            }
            return ds;
        }


        public static DataSet GetCallNoteByDates(DateTime StarDate,DateTime EndDate)
        {
            DataSet dsTransctionData = new DataSet();
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.GetCallNotesByDates, lobjConn);
                ocmd.Parameters.AddWithValue(DBFields.StartDate, StarDate);
                ocmd.Parameters.AddWithValue(DBFields.EndDate, EndDate);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                DataTable table = new DataTable();
                table.Load(ocmd.ExecuteReader());
                ds.Tables.Add(table);

            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetCallNotesById Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();

            }
            return ds;
        }




        [OutputCache(Duration=600,VaryByParam = "Username")]
        public static DataSet GetCompanyListByUser(string Username)
        {
          
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
           
                 
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.GetCompanyListByUser, lobjConn);
                ocmd.Parameters.AddWithValue(DBFields.Email,Username);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;               
                DataTable table = new DataTable();
                table.Load(ocmd.ExecuteReader());
                ds.Tables.Add(table);
               
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetCompanyListByUser Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();
                 
            }
            return ds;
        }

        [OutputCache(Duration=300)]
        public static DataSet GetCompanyList()
        {
            DataSet dsTransctionData = new DataSet();
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter;
            try
            {
                adapter = new SqlDataAdapter(StoredProcedures.GetCompanyList, lobjConn);
                adapter.Fill(ds, "Companies");
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetCompanyList Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();
                 
                 
            }
            return ds;
        }

        public static DataSet GetCompanyListByPage(int start, string searchvalue, int length, string sortColumn, string sortDirection,string username)
        {
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();


            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.GetCompanyListByPage, lobjConn);
                ocmd.Parameters.AddWithValue(DBFields.start, start);
                ocmd.Parameters.AddWithValue(DBFields.searchvalue, searchvalue);
                ocmd.Parameters.AddWithValue(DBFields.length, length);
                ocmd.Parameters.AddWithValue(DBFields.sortColumn, sortColumn);
                ocmd.Parameters.AddWithValue(DBFields.sortDirection, sortDirection);
                ocmd.Parameters.AddWithValue(DBFields.UserName, username);
                
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                DataTable table = new DataTable();
                table.Load(ocmd.ExecuteReader());
                ds.Tables.Add(table);

            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetCompanyListByPage Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();


            }
            return ds;
        }


        public static DataSet GetCompanyById(int Id)
        {
            DataSet dsTransctionData = new DataSet();
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
          
            try
            {

                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.GetCompanyById, lobjConn);
                ocmd.Parameters.AddWithValue(DBFields.Id, Id);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                DataTable table = new DataTable();
                table.Load(ocmd.ExecuteReader());
                ds.Tables.Add(table);

                
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetCompanyList Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();
                 
            }
            return ds;
        }

        public static DataSet GetCompanyByQuery(string Query,string Value="")
        {
            DataSet dsTransctionData = new DataSet();
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();

            try
            {

                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.GetCompanyByQuery, lobjConn);
                ocmd.Parameters.AddWithValue(DBFields.Query, Query);
                ocmd.Parameters.AddWithValue(DBFields.Value, Value);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                DataTable table = new DataTable();
                table.Load(ocmd.ExecuteReader());
                ds.Tables.Add(table);


            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetCompanyList Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();

            }
            return ds;
        }


        public static DataSet GetCourseList()
        {
            DataSet dsTransctionData = new DataSet();
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter;
            try
            {
                adapter = new SqlDataAdapter(StoredProcedures.GetCourseList, lobjConn);
                adapter.Fill(ds, "Course");
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetCourseList Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();
                 
            }
            return ds;
        }
        public static DataSet GetStreamList()
        {
            DataSet dsTransctionData = new DataSet();
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter;
            try
            {
                adapter = new SqlDataAdapter(StoredProcedures.GetStreamList, lobjConn);
                adapter.Fill(ds, "Stream");
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetCourseList Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();
                 
            }
            return ds;
        }
        public static int SaveCompany(Company pobjCompany)
        {
            int lintId = 0;
            SqlConnection lobjConn = new SqlConnection(connectionString);
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.SaveCompany, lobjConn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                ocmd.Parameters.AddWithValue(DBFields.Id, pobjCompany.Id);
                ocmd.Parameters.AddWithValue(DBFields.CompanyName, string.IsNullOrEmpty(pobjCompany.CompanyName) ? "" : pobjCompany.CompanyName);


                ocmd.Parameters.AddWithValue(DBFields.Summary, string.IsNullOrEmpty(pobjCompany.Summary) ? "" : pobjCompany.Summary);

                ocmd.Parameters.AddWithValue(DBFields.MTCorSTC, string.IsNullOrEmpty(pobjCompany.MTCorSTC) ? "" : pobjCompany.MTCorSTC);
                ocmd.Parameters.AddWithValue(DBFields.AllotedTo, string.IsNullOrEmpty(pobjCompany.AllotedTo) ? "" : pobjCompany.AllotedTo);
                ocmd.Parameters.AddWithValue(DBFields.Address1, string.IsNullOrEmpty(pobjCompany.Address1) ? "" : pobjCompany.Address1);
                ocmd.Parameters.AddWithValue(DBFields.Address2, string.IsNullOrEmpty(pobjCompany.Address2) ? "" : pobjCompany.Address2);

                ocmd.Parameters.AddWithValue(DBFields.Remarks, string.IsNullOrEmpty(pobjCompany.Remarks) ? "" : pobjCompany.Remarks);

                ocmd.Parameters.AddWithValue(DBFields.City, string.IsNullOrEmpty(pobjCompany.City) ? "" : pobjCompany.City);

                ocmd.Parameters.AddWithValue(DBFields.SubLocation, string.IsNullOrEmpty(pobjCompany.SubLocation) ? "" : pobjCompany.SubLocation);
                ocmd.Parameters.AddWithValue(DBFields.HiringArea, string.IsNullOrEmpty(pobjCompany.HiringArea) ? "" : pobjCompany.HiringArea);
                ocmd.Parameters.AddWithValue(DBFields.PlantorRegdOffice, string.IsNullOrEmpty(pobjCompany.PlantorRegdOffice) ? "" : pobjCompany.PlantorRegdOffice);
                ocmd.Parameters.AddWithValue(DBFields.TransferredFrom, string.IsNullOrEmpty(pobjCompany.TransferredFrom) ? "" : pobjCompany.TransferredFrom);

                ocmd.Parameters.AddWithValue(DBFields.Sector, string.IsNullOrEmpty(pobjCompany.Sector) ? "" : pobjCompany.Sector);
                ocmd.Parameters.AddWithValue(DBFields.DateGiven, pobjCompany.DateGiven == null ? DateTime.Now : pobjCompany.DateGiven);
                ocmd.Parameters.AddWithValue(DBFields.ResearchSource, string.IsNullOrEmpty(pobjCompany.ResearchSource) ? "" : pobjCompany.ResearchSource);




                ocmd.Parameters.AddWithValue(DBFields.ThirdParty, string.IsNullOrEmpty(pobjCompany.ThirdParty) ? "" : pobjCompany.ThirdParty);

                ocmd.Parameters.AddWithValue(DBFields.ColorCode, string.IsNullOrEmpty(pobjCompany.ColorCode) ? "" : pobjCompany.ColorCode);
                ocmd.Parameters.AddWithValue(DBFields.IsDeleted, pobjCompany.IsDeleted);
                ocmd.Parameters.AddWithValue(DBFields.IsActive, pobjCompany.IsActive);

                ocmd.Parameters.AddWithValue(DBFields.UpdatedOn, pobjCompany.UpdatedOn == null ? DateTime.Now : pobjCompany.UpdatedOn);
                ocmd.Parameters.AddWithValue(DBFields.UpdatedBy, string.IsNullOrEmpty(pobjCompany.UpdatedBy) ? "" : pobjCompany.UpdatedBy);
                ocmd.Parameters.AddWithValue(DBFields.CreatedOn, pobjCompany.CreatedOn == null ? DateTime.Now : pobjCompany.CreatedOn);
                ocmd.Parameters.AddWithValue(DBFields.CreatedBy, string.IsNullOrEmpty(pobjCompany.CreatedBy) ? "" : pobjCompany.CreatedBy);
                lintId = Convert.ToInt32(ocmd.ExecuteScalar());

                return lintId;
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper SaveCompany Ex - {0}", ex.Message);
                throw ex;
            }
            finally
            {
                lobjConn.Close();
                 
            }
        }


        public static int SaveSector(Master pobjmaster)
        {

            int lintId = 0;
            SqlConnection lobjConn = new SqlConnection(connectionString);
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.SaveSector, lobjConn);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                ocmd.Parameters.AddWithValue(DBFields.Id, pobjmaster.Id);
                ocmd.Parameters.AddWithValue(DBFields.Name, pobjmaster.Name);
                lintId = Convert.ToInt32(ocmd.ExecuteScalar());

                return lintId;
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper SaveSector Ex - {0}", ex.Message);
                throw ex;
            }

        }


        public static int SaveCity(CityMaster pobjmaster)
        {

            int lintId = 0;
            SqlConnection lobjConn = new SqlConnection(connectionString);
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.SaveCity, lobjConn);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                ocmd.Parameters.AddWithValue(DBFields.Id, pobjmaster.Id);
                ocmd.Parameters.AddWithValue(DBFields.City, pobjmaster.City);     
                lintId = Convert.ToInt32(ocmd.ExecuteScalar());
                return lintId;
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper SaveCity Ex - {0}", ex.Message);
                throw ex;
            }

        }


        public static int SaveColor(Master pobjmaster)
        {

            int lintId = 0;
            SqlConnection lobjConn = new SqlConnection(connectionString);
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.SaveColor, lobjConn);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                ocmd.Parameters.AddWithValue(DBFields.Id, pobjmaster.Id);
                ocmd.Parameters.AddWithValue(DBFields.Name, pobjmaster.Name);
                ocmd.Parameters.AddWithValue(DBFields.Description, pobjmaster.Description);
                lintId = Convert.ToInt32(ocmd.ExecuteScalar());

                return lintId;
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper SaveColor Ex - {0}", ex.Message);
                throw ex;
            }

        }


        public static int SaveCollege(Master pobjmaster)
        {

            int lintId = 0;
            SqlConnection lobjConn = new SqlConnection(connectionString);
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.SaveCollege, lobjConn);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                ocmd.Parameters.AddWithValue(DBFields.Id, pobjmaster.Id);
                ocmd.Parameters.AddWithValue(DBFields.Name, pobjmaster.Name);
                ocmd.Parameters.AddWithValue(DBFields.Location, pobjmaster.Location);
                lintId = Convert.ToInt32(ocmd.ExecuteScalar());

                return lintId;
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper SaveCollege Ex - {0}", ex.Message);
                throw ex;
            }

        }


        public static int SaveSublocation(Sublocation pobjmaster)
        {

            int lintId = 0;
            SqlConnection lobjConn = new SqlConnection(connectionString);
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.SaveSublocation, lobjConn);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                ocmd.Parameters.AddWithValue(DBFields.Id, pobjmaster.Id);
                ocmd.Parameters.AddWithValue(DBFields.CityId, pobjmaster.CityId);
                ocmd.Parameters.AddWithValue(DBFields.SubLocation, pobjmaster.SubLocation);
                lintId = Convert.ToInt32(ocmd.ExecuteScalar());
                return lintId;
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper SaveSublocation Ex - {0}", ex.Message);
                throw ex;
            }

        }

        public static int SaveUser(RegisterViewModel pobjUser)
        {
            int lintId = 0;
            SqlConnection lobjConn = new SqlConnection(connectionString);
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.SaveUser, lobjConn);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                ocmd.Parameters.AddWithValue(DBFields.FirstName, pobjUser.FirstName);
                ocmd.Parameters.AddWithValue(DBFields.LastName, pobjUser.LastName);
                ocmd.Parameters.AddWithValue(DBFields.Address, pobjUser.Address);
                ocmd.Parameters.AddWithValue(DBFields.CreatedOn, pobjUser.CreatedOn);
                ocmd.Parameters.AddWithValue(DBFields.CreatedBy, pobjUser.CreatedBy);
                ocmd.Parameters.AddWithValue(DBFields.UpdatedOn, pobjUser.UpdatedOn);
                ocmd.Parameters.AddWithValue(DBFields.UpdatedBy, pobjUser.UpdatedBy);
                ocmd.Parameters.AddWithValue(DBFields.DOB, pobjUser.DOB);
                ocmd.Parameters.AddWithValue(DBFields.Gender, pobjUser.Gender);
                ocmd.Parameters.AddWithValue(DBFields.Id, pobjUser.Id);
                ocmd.Parameters.AddWithValue(DBFields.IsDeleted, pobjUser.IsDeleted);

                ocmd.Parameters.AddWithValue(DBFields.Barcode, pobjUser.Barcode);
                ocmd.Parameters.AddWithValue(DBFields.FatherName, pobjUser.FatherName);
                ocmd.Parameters.AddWithValue(DBFields.CompanyID, pobjUser.CompanyId);
                ocmd.Parameters.AddWithValue(DBFields.Designatation, pobjUser.Designatation);
                ocmd.Parameters.AddWithValue(DBFields.UANNumber, pobjUser.UANNumber);
                ocmd.Parameters.AddWithValue(DBFields.ESICNumber, pobjUser.ESICNumber);
                ocmd.Parameters.AddWithValue(DBFields.AdharNumber, pobjUser.AdharNumber);
                ocmd.Parameters.AddWithValue(DBFields.SalaryDate, pobjUser.SalaryDate);
                lintId = Convert.ToInt32(ocmd.ExecuteScalar());

                return lintId;
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper SaveUser Ex - {0}", ex.Message);
                throw ex;
            }
            finally
            {
                lobjConn.Close();
                 
            }
        }


        public static DataSet GetSectorMasters()
        {
            DataSet dsTransctionData = new DataSet();
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter;
            try
            {
                adapter = new SqlDataAdapter(StoredProcedures.GetSectorMasters, lobjConn);
                adapter.Fill(ds, "Masters");
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetSectorMasters Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();
                 
            }
            return ds;
        }

        public static DataSet GetCompanyEvent()
        {

            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter;
            try
            {
                adapter = new SqlDataAdapter(StoredProcedures.EventMasterList, lobjConn);
                adapter.Fill(ds, "EventMasters");
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetCollegeMasters Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();
                 
            }
            return ds;
        }
        public static DataSet GetCompanyHistory()
        {

            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter;
            try
            {
                adapter = new SqlDataAdapter(StoredProcedures.EventHistoryList, lobjConn);
                adapter.Fill(ds, "EventHistory");
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetCollegeMasters Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();
                 
            }
            return ds;
        }

        public static DataSet GetCompanyHistoryById(int Id)
        {

            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
          
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.EventHistoryListById, lobjConn);
                ocmd.Parameters.AddWithValue(DBFields.Id, Id);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                DataTable table = new DataTable();
                table.Load(ocmd.ExecuteReader());
                ds.Tables.Add(table);
                
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetCollegeMasters Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();

            }
            return ds;
        }
        public static DataSet GetCollegeMasters()
        {
            DataSet dsTransctionData = new DataSet();
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter;
            try
            {
                adapter = new SqlDataAdapter(StoredProcedures.GetCollegeMasters, lobjConn);
                adapter.Fill(ds, "Masters");
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetCollegeMasters Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();
                 
            }
            return ds;
        }
        public static DataSet GetColorMasters()
        {
            DataSet dsTransctionData = new DataSet();
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter;
            try
            {
                adapter = new SqlDataAdapter(StoredProcedures.GetColorMasters, lobjConn);
                adapter.Fill(ds, "Masters");
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetColorMasters Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();
                 
            }
            return ds;
        }

        public static DataSet GetCompanyContacts()
        {
            DataSet dsTransctionData = new DataSet();
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter;
            try
            {
                adapter = new SqlDataAdapter(StoredProcedures.GetCompanyContacts, lobjConn);
                adapter.Fill(ds, "CompanyContacts");
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetCompanyContacts Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();
                 
            }
            return ds;
        }


        public static DataSet GetCompanyContactsById(int Id)
        {
            DataSet dsTransctionData = new DataSet();
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
           
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.GetCompanyContactsById, lobjConn);
                ocmd.Parameters.AddWithValue(DBFields.Id, Id);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                DataTable table = new DataTable();
                table.Load(ocmd.ExecuteReader());
                ds.Tables.Add(table);
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetCompanyContacts Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();

            }
            return ds;
        }


        public static DataSet GetCompanyContactsForReminder()
        {
            DataSet dsTransctionData = new DataSet();
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter;
            try
            {
                adapter = new SqlDataAdapter(StoredProcedures.GetCompanyContactsForReminder, lobjConn);
                adapter.Fill(ds, "CompanyContactsForReminder");
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetCompanyContactsForReminder Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();

            }
            return ds;
        }
        public static DataSet GetPreviousNotes()
        {
            DataSet dsTransctionData = new DataSet();
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter;
            try
            {
                adapter = new SqlDataAdapter(StoredProcedures.GetPreviousNotes, lobjConn);
                adapter.Fill(ds, "PreviousNotes");
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetJobDescription Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();
                 
            }
            return ds;
        }
        public static DataSet GetJobDescription()
        {
            DataSet dsTransctionData = new DataSet();
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter;
            try
            {
                adapter = new SqlDataAdapter(StoredProcedures.GetJdDescription, lobjConn);
                adapter.Fill(ds, "JdDescription");
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetJobDescription Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();
                 
            }
            return ds;
        }

        public static DataSet GetJobDescriptionById(int Id)
        {
            DataSet dsTransctionData = new DataSet();
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
           
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.GetJdDescriptionById, lobjConn);
                ocmd.Parameters.AddWithValue(DBFields.Id, Id);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                DataTable table = new DataTable();
                table.Load(ocmd.ExecuteReader());
                ds.Tables.Add(table);
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetJobDescription Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();

            }
            return ds;
        }

        public static int SavejobDescription(JobDescription pobjJobDescription)
        {
            int lintId = 0;
            SqlConnection lobjConn = new SqlConnection(connectionString);
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.SaveJdDescription, lobjConn);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                ocmd.Parameters.AddWithValue(DBFields.Id, pobjJobDescription.Id);
                ocmd.Parameters.AddWithValue(DBFields.CompanyID, pobjJobDescription.CompanyID);
                ocmd.Parameters.AddWithValue(DBFields.Title, pobjJobDescription.Title);
                ocmd.Parameters.AddWithValue(DBFields.Year, pobjJobDescription.Year);
                ocmd.Parameters.AddWithValue(DBFields.jdDescription, string.IsNullOrEmpty(pobjJobDescription.jdDescription)?"":pobjJobDescription.jdDescription);
                ocmd.Parameters.AddWithValue(DBFields.CreatedBy, pobjJobDescription.CreatedBy);
                ocmd.Parameters.AddWithValue(DBFields.CreatedOn, pobjJobDescription.CreatedOn);
                ocmd.Parameters.AddWithValue(DBFields.UpdatedOn, pobjJobDescription.UpdatedOn);
                ocmd.Parameters.AddWithValue(DBFields.UpdatedBy, pobjJobDescription.UpdatedBy);
                ocmd.Parameters.AddWithValue(DBFields.IsDeleted, pobjJobDescription.IsDeleted);
                ocmd.Parameters.AddWithValue(DBFields.IsActive, pobjJobDescription.IsActive);
                ocmd.Parameters.AddWithValue(DBFields.Type, pobjJobDescription.Type);
                lintId = Convert.ToInt32(ocmd.ExecuteScalar());

                return lintId;
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper SaveUser Ex - {0}", ex.Message);
                throw ex;
            }
            finally
            {
                lobjConn.Close();
            }
        }
        public static int SaveCallNote(CallNote pobjCallNote)
        {
            SqlConnection lobjConn = new SqlConnection(connectionString);
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.SaveCallNote, lobjConn)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                ocmd.Parameters.AddWithValue(DBFields.Id, pobjCallNote.Id);
                ocmd.Parameters.AddWithValue(DBFields.CreatedOn, pobjCallNote.CreatedOn);
                ocmd.Parameters.AddWithValue(DBFields.Description, pobjCallNote.Description);
                ocmd.Parameters.AddWithValue(DBFields.UpdatedOn, pobjCallNote.UpdatedOn);
                ocmd.Parameters.AddWithValue(DBFields.UserID, pobjCallNote.UserID);
                ocmd.Parameters.AddWithValue(DBFields.CompanyID, pobjCallNote.CompanyID);
                ocmd.Parameters.AddWithValue(DBFields.Type, pobjCallNote.Type);
                ocmd.Parameters.AddWithValue(DBFields.ActivityDate, pobjCallNote.ActivityDate);
                ocmd.Parameters.AddWithValue(DBFields.CallContactId, pobjCallNote.CallContactId);
                ocmd.Parameters.AddWithValue(DBFields.RemindMe, pobjCallNote.RemindMe);
                ocmd.Parameters.AddWithValue(DBFields.Status, pobjCallNote.Status);
                int lintId = Convert.ToInt32(ocmd.ExecuteScalar());

                return lintId;
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper SaveUser Ex - {0}", ex.Message);
                throw ex;
            }
            finally
            {
                lobjConn.Close();
            }
        }

        public static int SaveCourse(Course pobjCourse)
        {
            SqlConnection lobjConn = new SqlConnection(connectionString);
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.SaveCourse, lobjConn);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                ocmd.Parameters.AddWithValue(DBFields.Id, pobjCourse.Id);
                ocmd.Parameters.AddWithValue(DBFields.CreatedOn, pobjCourse.CreatedOn);
                ocmd.Parameters.AddWithValue(DBFields.CourseName, pobjCourse.CourseName);
                ocmd.Parameters.AddWithValue(DBFields.UpdatedOn, pobjCourse.UpdatedOn);
                ocmd.Parameters.AddWithValue(DBFields.CreatedBy, pobjCourse.CreatedBy);
                ocmd.Parameters.AddWithValue(DBFields.UpdatedBy, pobjCourse.UpdatedBy);
                ocmd.Parameters.AddWithValue(DBFields.IsDeleted, false);


                int lintId = Convert.ToInt32(ocmd.ExecuteScalar());

                return lintId;
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper SaveCourse Ex - {0}", ex.Message);
                throw ex;
            }
            finally
            {
                lobjConn.Close();
               
            }
        }
        public static int SaveStream(Stream pobjStream)
        {
            SqlConnection lobjConn = new SqlConnection(connectionString);
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.SaveStream, lobjConn);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                ocmd.Parameters.AddWithValue(DBFields.Id, pobjStream.Id);
                ocmd.Parameters.AddWithValue(DBFields.CourseId, pobjStream.CourseId);
                ocmd.Parameters.AddWithValue(DBFields.CreatedOn, pobjStream.CreatedOn);
                ocmd.Parameters.AddWithValue(DBFields.StreamName, pobjStream.StreamName);
                ocmd.Parameters.AddWithValue(DBFields.UpdatedOn, pobjStream.UpdatedOn);
                ocmd.Parameters.AddWithValue(DBFields.CreatedBy, pobjStream.CreatedBy);
                ocmd.Parameters.AddWithValue(DBFields.UpdatedBy, pobjStream.UpdatedBy);
                ocmd.Parameters.AddWithValue(DBFields.IsDeleted, false);


                int lintId = Convert.ToInt32(ocmd.ExecuteScalar());

                return lintId;
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper SaveCourse Ex - {0}", ex.Message);
                throw ex;
            }
            finally
            {
                lobjConn.Close();
               
            }
        }
        public static int SavePastRecruitment(PastRecruitment pobjJobDescription)
        {
            SqlConnection lobjConn = new SqlConnection(connectionString);
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.SavePastRecruitment, lobjConn);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                ocmd.Parameters.AddWithValue(DBFields.Id, pobjJobDescription.Id);
                ocmd.Parameters.AddWithValue(DBFields.CompanyID, pobjJobDescription.CompanyID);
                ocmd.Parameters.AddWithValue(DBFields.Code, pobjJobDescription.Code);
                ocmd.Parameters.AddWithValue(DBFields.RecuritYear, pobjJobDescription.RecuritYear);
                ocmd.Parameters.AddWithValue(DBFields.CreatedBy, pobjJobDescription.CreatedBy);
                ocmd.Parameters.AddWithValue(DBFields.CreatedOn, pobjJobDescription.CreatedOn);
                ocmd.Parameters.AddWithValue(DBFields.UpdatedOn, pobjJobDescription.UpdatedOn);
                ocmd.Parameters.AddWithValue(DBFields.UpdatedBy, pobjJobDescription.UpdatedBy);
                ocmd.Parameters.AddWithValue(DBFields.IsDeleted, pobjJobDescription.IsDeleted);
                int lintId = Convert.ToInt32(ocmd.ExecuteScalar());

                return lintId;
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper SaveUser Ex - {0}", ex.Message);
                throw ex;
            }
            finally
            {
                lobjConn.Close();
                
            }
        }
        public static int CompanyEvent(EventHistory pobjEventHistory)
        {
            SqlConnection lobjConn = new SqlConnection(connectionString);
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.SaveCompanyEvent, lobjConn);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                ocmd.Parameters.AddWithValue(DBFields.Id, pobjEventHistory.Id);
                ocmd.Parameters.AddWithValue(DBFields.Visitor, pobjEventHistory.Visitor);
                ocmd.Parameters.AddWithValue(DBFields.CompanyID, pobjEventHistory.CompanyID);
                ocmd.Parameters.AddWithValue(DBFields.EventTypeId, pobjEventHistory.EventTypeId);
                ocmd.Parameters.AddWithValue(DBFields.EventDate, pobjEventHistory.EventDate == null ? (object)DBNull.Value : pobjEventHistory.EventDate);
                ocmd.Parameters.AddWithValue(DBFields.Description, pobjEventHistory.Description == null ? "" : pobjEventHistory.Description);
                ocmd.Parameters.AddWithValue(DBFields.Status, pobjEventHistory.Status);
                ocmd.Parameters.AddWithValue(DBFields.CreatedBy, pobjEventHistory.CreatedBy);
                ocmd.Parameters.AddWithValue(DBFields.CreatedOn, pobjEventHistory.CreatedOn);
                ocmd.Parameters.AddWithValue(DBFields.UpdatedOn, pobjEventHistory.UpdatedOn);
                ocmd.Parameters.AddWithValue(DBFields.UpdatedBy, pobjEventHistory.UpdatedBy);
                ocmd.Parameters.AddWithValue(DBFields.IsDeleted, pobjEventHistory.IsDeleted);
                ocmd.Parameters.AddWithValue(DBFields.ContactId, pobjEventHistory.ContactId);
                int lintId = Convert.ToInt32(ocmd.ExecuteScalar());

                return lintId;
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper SaveUser Ex - {0}", ex.Message);
                throw ex;
            }
            finally
            {
                lobjConn.Close();
              
            }
        }

        public static int SavePastHiring(PastHiring pobjJobDescription)
        {
            SqlConnection lobjConn = new SqlConnection(connectionString);
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.SavePastHiring, lobjConn);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                ocmd.Parameters.AddWithValue(DBFields.Id, pobjJobDescription.Id);
                ocmd.Parameters.AddWithValue(DBFields.CompanyID, pobjJobDescription.CompanyID);
                ocmd.Parameters.AddWithValue(DBFields.CollegeCode, pobjJobDescription.CollegeCode);
                ocmd.Parameters.AddWithValue(DBFields.Hiringyear, pobjJobDescription.Hiringyear);
                ocmd.Parameters.AddWithValue(DBFields.CreatedBy, pobjJobDescription.CreatedBy);
                ocmd.Parameters.AddWithValue(DBFields.CreatedOn, pobjJobDescription.CreatedOn);
                ocmd.Parameters.AddWithValue(DBFields.UpdatedOn, pobjJobDescription.UpdatedOn);
                ocmd.Parameters.AddWithValue(DBFields.UpdatedBy, pobjJobDescription.UpdatedBy);
                ocmd.Parameters.AddWithValue(DBFields.IsDeleted, pobjJobDescription.IsDeleted);
                ocmd.Parameters.AddWithValue(DBFields.Remarks, pobjJobDescription.Remarks);
                int lintId = Convert.ToInt32(ocmd.ExecuteScalar());

                return lintId;
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper SaveUser Ex - {0}", ex.Message);
                throw ex;
            }
            finally
            {
                lobjConn.Close();
               
            }
        }
        public static int SaveCompanyStatus(CompanyStatus pobjJobDescription)
        {
            SqlConnection lobjConn = new SqlConnection(connectionString);
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.SaveCompanystatus, lobjConn);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                ocmd.Parameters.AddWithValue(DBFields.Id, pobjJobDescription.Id);
                ocmd.Parameters.AddWithValue(DBFields.CompanyID, pobjJobDescription.CompanyID);
                ocmd.Parameters.AddWithValue(DBFields.CompanyDescription, pobjJobDescription.CompanyDescription);
                ocmd.Parameters.AddWithValue(DBFields.CompanyYear, pobjJobDescription.CompanyYear);
                ocmd.Parameters.AddWithValue(DBFields.CreatedBy, pobjJobDescription.CreatedBy);
                ocmd.Parameters.AddWithValue(DBFields.CreatedOn, pobjJobDescription.CreatedOn);
                ocmd.Parameters.AddWithValue(DBFields.UpdatedOn, pobjJobDescription.UpdatedOn);
                ocmd.Parameters.AddWithValue(DBFields.UpdatedBy, pobjJobDescription.UpdatedBy);
                ocmd.Parameters.AddWithValue(DBFields.IsDeleted, pobjJobDescription.IsDeleted);
                int lintId = Convert.ToInt32(ocmd.ExecuteScalar());

                return lintId;
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper SaveUser Ex - {0}", ex.Message);
                throw ex;
            }
            finally
            {
                lobjConn.Close();
               
            }
        }


        public static int SaveContact(CompanyContact pobjContact)
        {
            SqlConnection lobjConn = new SqlConnection(connectionString);
            try

            {

                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.SaveContact, lobjConn);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                ocmd.Parameters.AddWithValue(DBFields.ContactID, pobjContact.ContactID);
                ocmd.Parameters.AddWithValue(DBFields.ColorCode, string.IsNullOrEmpty(pobjContact.ColorCode) ? "" : pobjContact.ColorCode);
                ocmd.Parameters.AddWithValue(DBFields.UpdatedBy, pobjContact.UpdatedBy);
                ocmd.Parameters.AddWithValue(DBFields.CreatedOn, pobjContact.CreatedOn);
                ocmd.Parameters.AddWithValue(DBFields.CreatedBy, pobjContact.CreatedBy);
                ocmd.Parameters.AddWithValue(DBFields.UpdatedOn, pobjContact.UpdatedOn);
                ocmd.Parameters.AddWithValue(DBFields.CompanyID, pobjContact.CompanyID);
                ocmd.Parameters.AddWithValue(DBFields.DOB, string.IsNullOrEmpty(pobjContact.DOB) ? "" : pobjContact.DOB);
                ocmd.Parameters.AddWithValue(DBFields.Anniversary, string.IsNullOrEmpty(pobjContact.Anniversary) ? "" : pobjContact.Anniversary);
                ocmd.Parameters.AddWithValue(DBFields.IsActive, pobjContact.IsActive);
                ocmd.Parameters.AddWithValue(DBFields.IsDeleted, pobjContact.IsDeleted);

                ocmd.Parameters.AddWithValue(DBFields.PhoneNumber, string.IsNullOrEmpty(pobjContact.PhoneNumber) ? "" : pobjContact.PhoneNumber);
                ocmd.Parameters.AddWithValue(DBFields.MobileNumber, string.IsNullOrEmpty(pobjContact.MobileNumber) ? "" : pobjContact.MobileNumber);
                ocmd.Parameters.AddWithValue(DBFields.Designation, string.IsNullOrEmpty(pobjContact.Designation) ? "": pobjContact.Designation);
                
                ocmd.Parameters.AddWithValue(DBFields.Address, string.IsNullOrEmpty(pobjContact.Address) ? "" : pobjContact.Address);
                ocmd.Parameters.AddWithValue(DBFields.Department, string.IsNullOrEmpty(pobjContact.Department) ? "" : pobjContact.Department);

                ocmd.Parameters.AddWithValue(DBFields.ContactName, string.IsNullOrEmpty(pobjContact.ContactName) ? "" : pobjContact.ContactName);
                ocmd.Parameters.AddWithValue(DBFields.Description, string.IsNullOrEmpty(pobjContact.Description) ? "" : pobjContact.Description);
                ocmd.Parameters.AddWithValue(DBFields.EmailID, string.IsNullOrEmpty(pobjContact.EmailID) ? "" : pobjContact.EmailID);

                int lintId = Convert.ToInt32(ocmd.ExecuteScalar());

                return lintId;
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper SaveContact Ex - {0}", ex.Message);
                throw ex;
            }
            finally
            {
                lobjConn.Close();
             
            }
        }

        public static int CompanyStream(CompanyStream pobjCompanyStream)
        {
            SqlConnection lobjConn = new SqlConnection(connectionString);
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.SaveCompanyStream, lobjConn);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                ocmd.Parameters.AddWithValue(DBFields.Id, pobjCompanyStream.Id);
                ocmd.Parameters.AddWithValue(DBFields.CompanyID, pobjCompanyStream.CompanyId);
                ocmd.Parameters.AddWithValue(DBFields.CourseId, pobjCompanyStream.CoursesId);
                ocmd.Parameters.AddWithValue(DBFields.t_StreamId, pobjCompanyStream.StreamId);
                ocmd.Parameters.AddWithValue(DBFields.CreatedOn, pobjCompanyStream.CreatedOn);
                ocmd.Parameters.AddWithValue(DBFields.UpdatedOn, pobjCompanyStream.UpdatedOn);
                ocmd.Parameters.AddWithValue(DBFields.CreatedBy, pobjCompanyStream.CreatedBy);
                ocmd.Parameters.AddWithValue(DBFields.UpdatedBy, pobjCompanyStream.UpdatedBy);
                ocmd.Parameters.AddWithValue(DBFields.IsDeleted, false);
                ocmd.Parameters.AddWithValue(DBFields.json, pobjCompanyStream.t_JsonString);
                int lintId = Convert.ToInt32(ocmd.ExecuteScalar());
                return lintId;
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper SaveCourse Ex - {0}", ex.Message);
                throw ex;
            }
            finally
            {
                lobjConn.Close();
               
            }

        }

        public static int SaveCompanyAddress(CompanyAddress pobjCompanyAddress)
        {
            SqlConnection lobjConn = new SqlConnection(connectionString);
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.SaveCompanyAddress, lobjConn);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                ocmd.Parameters.AddWithValue(DBFields.Id, pobjCompanyAddress.Id);
                ocmd.Parameters.AddWithValue(DBFields.CompanyID, pobjCompanyAddress.CompanyID);
                ocmd.Parameters.AddWithValue(DBFields.City, pobjCompanyAddress.City);
                ocmd.Parameters.AddWithValue(DBFields.Title, pobjCompanyAddress.Title);
                ocmd.Parameters.AddWithValue(DBFields.Address, pobjCompanyAddress.Address);
                ocmd.Parameters.AddWithValue(DBFields.SubLocation,  String.IsNullOrEmpty(pobjCompanyAddress.SubLocation)?"": pobjCompanyAddress.SubLocation);
                ocmd.Parameters.AddWithValue(DBFields.IsActive, pobjCompanyAddress.IsActive);
                ocmd.Parameters.AddWithValue(DBFields.ContactNumber, pobjCompanyAddress.ContactNumber);
                int lintId = Convert.ToInt32(ocmd.ExecuteScalar());
                return lintId;
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper SaveCompanyAddresss Ex - {0}", ex.Message);
                throw ex;
            }
            finally
            {
                lobjConn.Close();
                
            }
        }



        public static DataSet GetCompanyAddress()
        {
           
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter;
            try
            {
                adapter = new SqlDataAdapter(StoredProcedures.GetCompanyAddress, lobjConn);
                adapter.Fill(ds, "CompanyAddress");
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetCompanyAddress Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();
               
            }
            return ds;
        }


        public static DataSet GetCompanyAddressById(int Id)
        {

            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
           
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.GetCompanyAddressById, lobjConn);
                ocmd.Parameters.AddWithValue(DBFields.Id, Id);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                DataTable table = new DataTable();
                table.Load(ocmd.ExecuteReader());
                ds.Tables.Add(table);
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetCompanyAddress Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();

            }
            return ds;
        }

        public static DataSet GetCity()
        {
           
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter;
            try
            {
                adapter = new SqlDataAdapter(StoredProcedures.GetCity, lobjConn);
                adapter.Fill(ds, "City");
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetCity Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();
               
            }
            return ds;
        }

        public static DataSet GetSublocation()
        {
            
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter;
            try
            {
                adapter = new SqlDataAdapter(StoredProcedures.GetSublocation, lobjConn);
                adapter.Fill(ds, "SubLocation");
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper SubLocation Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();
                
            }
            return ds;
        }

        public static int DeleteCompany(int id)
        {
            SqlConnection lobjConn = new SqlConnection(connectionString);
            lobjConn.Open();
            SqlCommand comm = new SqlCommand("delete from companymaster where id=" + id, lobjConn);
            try
            {
                comm.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                logger.Error("SPWrapper DeleteCompany Ex - {0}", ex.Message);
                return 0;
            }
            finally
            {
                lobjConn.Close();
            }

            return 1;    

        }

        public static int DeleteCommon(int id,string tableName,string Field)
        {
            SqlConnection lobjConn = new SqlConnection(connectionString);
            lobjConn.Open();
            SqlCommand comm = new SqlCommand("delete from " + tableName + " where "+ Field +" = " + id, lobjConn);
            try
            {
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper DeleteCommon Ex - {0}", ex.Message);
                return 0;
            }
            finally
            {
                lobjConn.Close();
            }

            return 1;

        }

        public static int UpdateStatus(int id, string Status)
        {
            SqlConnection lobjConn = new SqlConnection(connectionString);
            lobjConn.Open();
            SqlCommand comm = new SqlCommand("update CallNotes set [Status] = "+"'"+Status + "'"+" where ID = "+id, lobjConn);
            try
            {
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper updatestatus Ex - {0}", ex.Message);
                return 0;
            }
            finally
            {
                lobjConn.Close();
            }

            return 1;

        }


        public static int RemindMe(int id, string Status)
        {
            SqlConnection lobjConn = new SqlConnection(connectionString);
            lobjConn.Open();
            SqlCommand comm = new SqlCommand("update CallNotes set [RemindMe] = " + "'" + Status + "'" + " where ID = " + id, lobjConn);
            try
            {
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper RemindMe Ex - {0}", ex.Message);
                return 0;
            }
            finally
            {
                lobjConn.Close();
            }

            return 1;

        }

        public static int SaveOTP(string OTP,string EmailiD,int IsValid )
        {
            SqlConnection lobjConn = new SqlConnection(connectionString);
            lobjConn.Open();

            SqlCommand comm = new SqlCommand("update AspnetUsers set OTP ="+OTP+ " , IsValid = "+ IsValid + " where Email =" + "'" + EmailiD + "'", lobjConn);
            try
            {
                comm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper SaveOTP Ex - {0}", ex.Message);
                return 0;
            }
            finally
            {
                lobjConn.Close();
            }

            return 1;

        }

        public static int SaveLoginHistory(string IpAddress, string EmailId)
        {
            int lintId = 0;
            SqlConnection lobjConn = new SqlConnection(connectionString);
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.SaveLoginHistory, lobjConn);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                ocmd.Parameters.AddWithValue(DBFields.Email,EmailId);
                ocmd.Parameters.AddWithValue(DBFields.IpAddress, IpAddress);
                lintId = Convert.ToInt32(ocmd.ExecuteScalar());

                return lintId;
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper SaveLoginHistory Ex - {0}", ex.Message);
                throw ex;
            }
            finally
            {
                lobjConn.Close();

            }
        }


        public static DataSet GetLoginHistory(string EmailId,string sDate)
        {

            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();

            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.GetLoginHistory, lobjConn);
                ocmd.Parameters.AddWithValue(DBFields.Email, EmailId);
                ocmd.Parameters.AddWithValue(DBFields.CreatedOn, sDate);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                DataTable table = new DataTable();
                table.Load(ocmd.ExecuteReader());
                ds.Tables.Add(table);
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetLoginHistory Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();

            }
            return ds;
        }

        public static DataSet GetCompanyExtraContactsList(int Id)
        {
           
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
           
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.GetCompanyExtraContacts, lobjConn);
                ocmd.Parameters.AddWithValue(DBFields.Id, Id);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                DataTable table = new DataTable();
                table.Load(ocmd.ExecuteReader());
                ds.Tables.Add(table);             
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetCompanyExtraContactsList Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();
                 
            }
            return ds;
        }
        public static DataSet GetExtraCallNotesList(int Id)
        {
           
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
           
            try
            {

                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.GetExtraCallNotes, lobjConn);
                ocmd.Parameters.AddWithValue(DBFields.Id, Id);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                DataTable table = new DataTable();
                table.Load(ocmd.ExecuteReader());
                ds.Tables.Add(table);            
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetExtraCallNotesList Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();
                 
            }
            return ds;
        }
        public static int SaveCompanyExtraContacts(CompanyExtraContacts pobjmaster)
        {

            int lintId = 0;
            SqlConnection lobjConn = new SqlConnection(connectionString);
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.SaveCompanyExtraContacts, lobjConn);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                ocmd.Parameters.AddWithValue(DBFields.Id, pobjmaster.Id);
                ocmd.Parameters.AddWithValue(DBFields.Value, pobjmaster.Value);
                ocmd.Parameters.AddWithValue(DBFields.CompanyID, pobjmaster.CompanyId);
                lintId = Convert.ToInt32(ocmd.ExecuteScalar());

                return lintId;
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper SaveCompanyExtraContacts Ex - {0}", ex.Message);
                throw ex;
            }
            finally
            {
                lobjConn.Close();
                 
            }

        }
        public static int SaveExtraCallNotes(ExtraCallNotes pobjmaster)
        {

            int lintId = 0;
            SqlConnection lobjConn = new SqlConnection(connectionString);
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.SaveExtraCallNotes, lobjConn);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                ocmd.Parameters.AddWithValue(DBFields.Id, pobjmaster.Id);
                ocmd.Parameters.AddWithValue(DBFields.Value, pobjmaster.Value);
                ocmd.Parameters.AddWithValue(DBFields.CompanyID, pobjmaster.CompanyId);
                lintId = Convert.ToInt32(ocmd.ExecuteScalar());

                return lintId;
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper SaveExtraCallNotes Ex - {0}", ex.Message);
                throw ex;
            }
            finally
            {
                lobjConn.Close();
                 
            }

        }

        public static DataSet GetThirdPartyMasters()
        {
            DataSet dsTransctionData = new DataSet();
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter;
            try
            {
                adapter = new SqlDataAdapter(StoredProcedures.GetThirdPartyMasters, lobjConn);
                adapter.Fill(ds, "Masters");
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetThirdPartyMasters Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();

            }
            return ds;
        }

        public static int SaveThirdParty(ThirdParty pobjThirdParty)
        {
            SqlConnection lobjConn = new SqlConnection(connectionString);
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.SaveThirdPartyMasters, lobjConn);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                ocmd.Parameters.AddWithValue(DBFields.Id, pobjThirdParty.Id);
                ocmd.Parameters.AddWithValue(DBFields.Name, pobjThirdParty.Name);
                ocmd.Parameters.AddWithValue(DBFields.CreatedOn, pobjThirdParty.CreatedOn);
                ocmd.Parameters.AddWithValue(DBFields.UpdatedOn, pobjThirdParty.UpdatedOn);
                ocmd.Parameters.AddWithValue(DBFields.CreatedBy, pobjThirdParty.CreatedBy);
                ocmd.Parameters.AddWithValue(DBFields.UpdatedBy, pobjThirdParty.UpdatedBy);


                int lintId = Convert.ToInt32(ocmd.ExecuteScalar());

                return lintId;
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper SaveCourse Ex - {0}", ex.Message);
                throw ex;
            }
            finally
            {
                lobjConn.Close();

            }
        }

        public static int AddPayroll(Payroll pobjUser)
        {
            int lintId = 0;
            SqlConnection lobjConn = new SqlConnection(connectionString);
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.AddPayroll, lobjConn);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                ocmd.Parameters.AddWithValue("@EmployeeId", pobjUser.EmployeeId);
                ocmd.Parameters.AddWithValue("@CompanyId", pobjUser.CompanyId);
                ocmd.Parameters.AddWithValue("@DesignationId", pobjUser.DesignationId);
                ocmd.Parameters.AddWithValue("@WorkingDays", pobjUser.WorkingDays);
                ocmd.Parameters.AddWithValue("@LeaveDays", pobjUser.LeaveDays);
                ocmd.Parameters.AddWithValue("@OvertimeDays", pobjUser.OvertimeDays);
                ocmd.Parameters.AddWithValue("@PaidLeaveDays", pobjUser.PaidLeaveDays);
                ocmd.Parameters.AddWithValue("@TotalWorkingDays", pobjUser.TotalWorkingDays);
                ocmd.Parameters.AddWithValue("@SalaryAmount", pobjUser.SalaryAmount);
                ocmd.Parameters.AddWithValue("@GrossSalaryAmount", pobjUser.GrossSalaryAmount);
                ocmd.Parameters.AddWithValue("@DeductionAmount", pobjUser.DeductionAmount);

                ocmd.Parameters.AddWithValue("@DeductionDetails", pobjUser.DeductionDetails);
                ocmd.Parameters.AddWithValue("@IncentiveAmount", pobjUser.IncentiveAmount);
                ocmd.Parameters.AddWithValue("@AdvancePaidAmount", pobjUser.AdvancePaidAmount);
                ocmd.Parameters.AddWithValue("@AdvanceDeductedAmount", pobjUser.AdvanceDeductedAmount);
                ocmd.Parameters.AddWithValue("@AdditionalPaidAmount", pobjUser.AdditionalPaidAmount);
                ocmd.Parameters.AddWithValue("@AdditionalDeductedAmount", pobjUser.AdditionalDeductedAmount);
                ocmd.Parameters.AddWithValue("@AdditionalPaidDetails", pobjUser.AdditionalPaidDetails);
                ocmd.Parameters.AddWithValue("@AdditionalDeductedDetails", pobjUser.AdditionalDeductedDetails);
                ocmd.Parameters.AddWithValue("@Month", pobjUser.Month);
                ocmd.Parameters.AddWithValue("@Year", pobjUser.Year);
                ocmd.Parameters.AddWithValue("@NetSalaryAmount", pobjUser.NetSalaryAmount);
                ocmd.Parameters.AddWithValue("@CreatedBy", pobjUser.CreatedBy);
                ocmd.Parameters.AddWithValue("@UpdatedBy", pobjUser.UpdatedBy);

                lintId = Convert.ToInt32(ocmd.ExecuteScalar());

                return lintId;
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper AddPayroll Ex - {0}", ex.Message);
                throw ex;
            }
            finally
            {
                lobjConn.Close();

            }
        }
        public static int UpdatePayroll(Payroll pobjUser)
        {
            int lintId = 0;
            SqlConnection lobjConn = new SqlConnection(connectionString);
            try
            {
                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.UpdatePayroll, lobjConn);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                ocmd.Parameters.AddWithValue("@Id", pobjUser.Id);
                ocmd.Parameters.AddWithValue("@EmployeeId", pobjUser.EmployeeId);
                ocmd.Parameters.AddWithValue("@CompanyId", pobjUser.CompanyId);
                ocmd.Parameters.AddWithValue("@DesignationId", pobjUser.DesignationId);
                ocmd.Parameters.AddWithValue("@WorkingDays", pobjUser.WorkingDays);
                ocmd.Parameters.AddWithValue("@LeaveDays", pobjUser.LeaveDays);
                ocmd.Parameters.AddWithValue("@OvertimeDays", pobjUser.OvertimeDays);
                ocmd.Parameters.AddWithValue("@PaidLeaveDays", pobjUser.PaidLeaveDays);
                ocmd.Parameters.AddWithValue("@TotalWorkingDays", pobjUser.TotalWorkingDays);
                ocmd.Parameters.AddWithValue("@SalaryAmount", pobjUser.SalaryAmount);
                ocmd.Parameters.AddWithValue("@GrossSalaryAmount", pobjUser.GrossSalaryAmount);
                ocmd.Parameters.AddWithValue("@DeductionAmount", pobjUser.DeductionAmount);

                ocmd.Parameters.AddWithValue("@DeductionDetails", pobjUser.DeductionDetails);
                ocmd.Parameters.AddWithValue("@IncentiveAmount", pobjUser.IncentiveAmount);
                ocmd.Parameters.AddWithValue("@AdvancePaidAmount", pobjUser.AdvancePaidAmount);
                ocmd.Parameters.AddWithValue("@AdvanceDeductedAmount", pobjUser.AdvanceDeductedAmount);
                ocmd.Parameters.AddWithValue("@AdditionalPaidAmount", pobjUser.AdditionalPaidAmount);
                ocmd.Parameters.AddWithValue("@AdditionalDeductedAmount", pobjUser.AdditionalDeductedAmount);
                ocmd.Parameters.AddWithValue("@AdditionalPaidDetails", pobjUser.AdditionalPaidDetails);
                ocmd.Parameters.AddWithValue("@AdditionalDeductedDetails", pobjUser.AdditionalDeductedDetails);
                ocmd.Parameters.AddWithValue("@Month", pobjUser.Month);
                ocmd.Parameters.AddWithValue("@Year", pobjUser.Year);
                ocmd.Parameters.AddWithValue("@NetSalaryAmount", pobjUser.NetSalaryAmount);
                
                ocmd.Parameters.AddWithValue("@UpdatedBy", pobjUser.UpdatedBy);

                lintId = Convert.ToInt32(ocmd.ExecuteScalar());

                return lintId;
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper AddPayroll Ex - {0}", ex.Message);
                throw ex;
            }
            finally
            {
                lobjConn.Close();

            }



        }
        public static DataSet GetPayrollData()
        {
            DataSet dsTransctionData = new DataSet();
            SqlConnection lobjConn = new SqlConnection(connectionString);
            DataSet ds = new DataSet();
            SqlDataAdapter adapter=new SqlDataAdapter();
            try
            {


                lobjConn.Open();
                SqlCommand ocmd = new SqlCommand(StoredProcedures.PayrollList, lobjConn);
                ocmd.Parameters.AddWithValue(DBFields.Id, 1);
                ocmd.CommandType = System.Data.CommandType.StoredProcedure;
                DataTable table = new DataTable();
                table.Load(ocmd.ExecuteReader());
                ds.Tables.Add(table);


             
            }
            catch (Exception ex)
            {
                logger.Error("SPWrapper GetThirdPartyMasters Ex - {0}", ex.Message);
                throw ex;
                //logging
            }
            finally
            {
                lobjConn.Close();

            }
            return ds;
        }
    }
}
