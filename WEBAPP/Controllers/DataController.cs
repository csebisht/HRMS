using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Mvc;
using WEBAPP.Models;
using WEBAPP.DAL;
using NLog;
using System.Globalization;
using System.Text;
using Newtonsoft.Json.Linq;
using System.IO;
using static WEBAPP.Models.Data;

namespace WEBAPP.Controllers
{
    public class DataController : Controller
    {

        private string Summary = string.Empty;
        private static Logger logger = LogManager.GetCurrentClassLogger();
        // GET: Data
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ImportExcel importExcel)
        {

            if (ModelState.IsValid)
            {
                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("/Content/Upload/"), importExcel.file.FileName) ;
                importExcel.file.SaveAs(path);


                string excelConnectionString = @"Provider='Microsoft.ACE.OLEDB.12.0';Data Source='" + path + "';Extended Properties='Excel 12.0 Xml;IMEX=1'";
                OleDbConnection excelConnection = new OleDbConnection(excelConnectionString);

                //Sheet Name
                excelConnection.Open();
                string tableName = excelConnection.GetSchema("Tables").Rows[0]["TABLE_NAME"].ToString();

                //End

                OleDbCommand cmd = new OleDbCommand("Select * from [" + tableName + "]", excelConnection);



                OleDbDataReader dReader;
                dReader = cmd.ExecuteReader();

                DataTable dtexcel = new DataTable();

                string query = "SELECT  * FROM [" + tableName + "]";



                OleDbDataAdapter daexcel = new OleDbDataAdapter(query, excelConnection);

                daexcel.Fill(dtexcel);
                excelConnection.Close();
                if (!ValidateExcel(dtexcel.Rows[0]))
                {
                    ViewBag.Result = Summary;
                    return View();
                }

                foreach (DataRow row in dtexcel.Rows)
                {

                    Company objcompany = new Company();

                    try
                    {
                        objcompany.CompanyName = row["NameofCompany"].ToString();
                        // Check duplicacy                      
                        objcompany.CompanyList = DataMapper.MapCompanyDataForListing(SPWrapper.GetCompanyList()).Where(x => x.IsDeleted == false).ToList();
                        
                       
                        
                        if (objcompany.CompanyList.Any(x => x.CompanyName.ToUpper() == objcompany.CompanyName.ToUpper()))
                        {
                            Summary += System.Environment.NewLine + " CompanyName" + objcompany.CompanyName + " Company Already Exists";
                        }
                        else
                        {
                            objcompany.AllotedTo = row["AlottedTo"].ToString();
                            objcompany.Summary = row["Summary"].ToString();
                            objcompany.MTCorSTC = row["MTC/STC"].ToString();
                            if (row["Dategiven"].ToString() != "")
                            {
                                objcompany.DateGiven = Convert.ToDateTime(row["Dategiven"].ToString());
                            }
                            objcompany.Remarks = row["Remarks"].ToString();
                            objcompany.ResearchSource = row["Source"].ToString();
                            objcompany.Sector = row["Sector"].ToString().Trim();
                            objcompany.ThirdParty = row["ThirdParty"].ToString();
                            objcompany.TransferredFrom = row["TransferredFrom"].ToString();
                            objcompany.HiringArea = row["HiringArea(City/Plant)"].ToString();
                            //objcompany.City = row["City(CorporateOffice)"].ToString();
                            objcompany.CreatedOn = DateTime.Now;
                            objcompany.UpdatedOn = DateTime.Now;
                            objcompany.CreatedBy = "SYSTEM";
                            objcompany.Id = SPWrapper.SaveCompany(objcompany);
                            // Save Past Recruitment Details
                            SavePastRecruiterDetails(row, objcompany);
                            // Save Employee Details
                            SaveEmployeeDetails(row, objcompany);
                            // Save Hiring Details
                            SaveHiringDetails(row, objcompany);
                            // Save Call Notes
                            SaveCallNotes(row, objcompany);
                            // Save Address 
                            SaveAddress(row, objcompany);
                            // Save Event Details 
                            SaveEventDetails(row, objcompany);
                            // Save Stream And Package
                            SaveStreamPackage(row, objcompany);
                            // Save Extra Contacts
                            SaveExtraContacts(row, objcompany);
                            // Save Extra Call Notes
                            SaveExtraCallNotes(row, objcompany);
                            // Save Follow Date
                            SaveFollowUp(row, objcompany);
                            logger.Info("CompanyID-{0}|CompanyName{1}-Saved", objcompany.Id, objcompany.CompanyName);
                        }

                    }
                    catch (Exception ex)
                    {
                        Summary += ex.Message;
                        logger.Error("CompanyName{0}- Basic Failed Ex{1}", objcompany.CompanyName, ex.Message);

                    }

                    finally
                    {
                        excelConnection.Close();
                        ViewBag.Result = Summary;

                    }
                }
            }
            if (Summary == "")
            {
                ViewBag.Result = "Data Uploaded Successfully!";
            }
            return View();
        }

        public string GetCompanyStreamXml(string Data)
        {
            string t_Company = "<NewDataSet>";
            if (Data != null)
            {
                var JPList = JArray.Parse(Data);
                if (JPList.Count > 0)
                {
                    foreach (var item in JPList)
                    {
                        if (item.HasValues)
                        {
                            dynamic jPObject = JObject.Parse(item.ToString());
                            t_Company +=
                                "<CompanyStream>" +
                                    "<Course>" + jPObject.Course + "</Course>" +
                                     "<Stream>" + jPObject.Stream + "</Stream>" +
                                      "<PayPackageID>" + jPObject.PayPackageID + "</PayPackageID>" +
                                "</CompanyStream>";
                        }
                    }
                }
            }
            t_Company += "</NewDataSet>";
            return t_Company;
        }
        public bool SaveStreamPackage(DataRow row, Company objcompany)
        {

            var StreamRequired = row["StreamRequired"].ToString();
            var PayPackages = row["PayPackages"].ToString();

            string[] SR = StreamRequired.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            string[] PP = PayPackages.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);



            if (SR.Length == PP.Length)
            {
                try
                {
                    for (int i = 0; i < SR.Length; i++)
                    {
                        string Json;
                        if (SR[i].Split('-').Length == 2)
                        {
                            string C = SR[i].Split('-')[0].Trim();
                            string S = SR[i].Split('-')[1].Trim();
                            string Pay = PP[i].Trim();


                            Json = "[{'Course':'" + C + "'," + "'Stream':'" + S + "','PayPackageID':'" + Pay + "'}]";

                        }
                        else
                        {
                            var C = SR[i];
                            var Pay = PP[i];
                            Json = "[{'Course':'" + C + "'," + "'Stream':'','PayPackageID':'" + Pay + "'}]";

                        }

                        CompanyStream objCompanyStream = new CompanyStream();
                        objCompanyStream.CompanyId = objcompany.Id;
                        objCompanyStream.CreatedOn = DateTime.Now;
                        objCompanyStream.StreamId = "";
                        objCompanyStream.CoursesId = "";
                        objCompanyStream.UpdatedOn = DateTime.Now;
                        objCompanyStream.CreatedBy = "SYSTEM";
                        objCompanyStream.UpdatedBy = "SYSTEM";
                        objCompanyStream.IsDeleted = false;
                        objCompanyStream.t_JsonString = GetCompanyStreamXml(Json);
                        SPWrapper.CompanyStream(objCompanyStream);

                        logger.Info("CompanyID-{0}|CompanyName{1}- CompanyStream Saved", objcompany.Id, objcompany.CompanyName);
                    }
                }
                catch (Exception ex)
                {
                    Summary += System.Environment.NewLine + " CompanyName" + objcompany.CompanyName + "-  Contact Details Ex" + ex.Message;
                    SPWrapper.DeleteCompany(objcompany.Id);
                    logger.Error("CompanyID-{0}|CompanyName{1}- Contact Details Failed EX{2}", objcompany.Id, objcompany.CompanyName, ex.Message);

                }
            }
            else
            {
                SPWrapper.DeleteCompany(objcompany.Id);

                Summary += System.Environment.NewLine + " CompanyName" + objcompany.CompanyName + "- Stream and Package count doesnot match";
                logger.Error("CompanyID-{0}|CompanyName{1}- Stream and Package count doesnot match", objcompany.Id, objcompany.CompanyName);
                return false;
            }

            return true;
        }

        public bool ValidateExcel(DataRow row)
        {
            try

            {
                row["StreamRequired"].ToString();
                row["PayPackages"].ToString();
                row["ContactPerson"].ToString();
                row["HiringArea(City/Plant)"].ToString();
                row["ContactPerson"].ToString();
                row["Designation"].ToString();
                row["EmailID"].ToString();
                row["PastRecruiterDetails"].ToString();
                row["CallNotes"].ToString();
                row["VisitDetails"].ToString();
                row["NameofCompany"].ToString();
                row["AlottedTo"].ToString();
                row["Summary"].ToString();
                row["MTC/STC"].ToString();
                row["Dategiven"].ToString();
                row["Remarks"].ToString();
                row["Source"].ToString();
                row["Sector"].ToString();
                row["ThirdParty"].ToString();
                row["TransferredFrom"].ToString();
                row["GuestLecture"].ToString();
                row["AdvisoryBoard"].ToString();
                row["ExtraContactPersons"].ToString();
                row["PREVIOUSCALLNOTES"].ToString();
                row["Follow-upDate"].ToString();
                row["JDReceived"].ToString();
            }
            catch (Exception ex)
            {
                Summary += ex.Message;
                return false;
            }

            return true;
        }

        public bool SaveEventDetails(DataRow row, Company objcompany)
        {
            string rows;
            string GuestLecture;
            string AdvisoryBoard;
            try
            {
                rows = row["VisitDetails"].ToString();
                GuestLecture = row["GuestLecture"].ToString();
                AdvisoryBoard = row["AdvisoryBoard"].ToString();

            }
            catch (Exception ex)
            {
                Summary += ex.Message;
                return false;
            }
            if (GuestLecture == "GLR")
            {
                EventHistory objEventHistory = new EventHistory
                {

                    CompanyID = objcompany.Id,
                    CreatedBy = "SYSTEM",
                    EventDate = null,
                    EventTypeId = 4,
                    Visitor = "",
                    Status = true,
                    Description = "Guest Lecture Required",
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    UpdatedBy = "SYSTEM"

                };
                SPWrapper.CompanyEvent(objEventHistory);

                logger.Info("CompanyID-{0}|CompanyName{1}- Guest Lecture Details Saved", objcompany.Id, objcompany.CompanyName);
            }

            if (AdvisoryBoard == "ABR")
            {
                EventHistory objEventHistory = new EventHistory
                {
                    CompanyID = objcompany.Id,
                    CreatedBy = "SYSTEM",
                    EventDate = null,
                    EventTypeId = 1,
                    Visitor = "",
                    Status = true,
                    Description = "Advisory Board Required",
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    UpdatedBy = "SYSTEM"

                };
                SPWrapper.CompanyEvent(objEventHistory);

                logger.Info("CompanyID-{0}|CompanyName{1}- Advisory Details Saved", objcompany.Id, objcompany.CompanyName);
            }

            if (!String.IsNullOrEmpty(rows))
            {
                string[] lines = rows.Split(new[] { "~" }, StringSplitOptions.RemoveEmptyEntries);
                if (lines.Count() > 0)
                {
                    foreach (var item in lines)
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(item))
                            {
                                if (item.Split('|').Count() == 2)
                                {
                                    string date = item.Split('|')[0].Trim().Replace("\n", "");
                                    string desc = item.Split('|')[1].Trim();
                                    EventHistory objEventHistory = new EventHistory
                                    {
                                        CompanyID = objcompany.Id,
                                        CreatedBy = "SYSTEM",
                                        EventDate = ParseDate(date),
                                        EventTypeId = 7,
                                        Visitor = "",
                                        Status = true,
                                        Description = desc,
                                        CreatedOn = DateTime.Now,
                                        UpdatedOn = DateTime.Now,
                                        UpdatedBy = "SYSTEM"

                                    };
                                    SPWrapper.CompanyEvent(objEventHistory);

                                    logger.Info("CompanyID-{0}|CompanyName{1}- Visit Details Saved", objcompany.Id, objcompany.CompanyName);
                                }
                                else
                                {
                                    SPWrapper.DeleteCompany(objcompany.Id);
                                    Summary += System.Environment.NewLine + " CompanyName" + objcompany.CompanyName + "- VisitDetails- Invalid Data format";


                                }

                            }
                        }

                        catch (Exception ex)

                        {
                            logger.Error("CompanyID-{0}|CompanyName{1}- Visit Details Failed Ex{2}", objcompany.Id, objcompany.CompanyName, ex.Message);
                            return false;
                        }
                    }
                }


            }
            return true;

        }


        public bool SaveFollowUp(DataRow row, Company objcompany)
        {
            var Date = row["Follow-upDate"].ToString().Trim();
            if (!String.IsNullOrEmpty(Date))
            {
                try
                {
                    string desc = "Follow Up";
                    CallNote objCallNote = new CallNote
                    {
                        CompanyID = objcompany.Id,
                        ActivityDate = ParseDate(Date),
                        CallContactId = 0,
                        Description = desc,
                        Type = 1,
                        UserID = "SYSTEM",
                        CreatedOn = new DateTime(2010, 1, 1),
                        UpdatedOn = DateTime.Now

                    };
                    SPWrapper.SaveCallNote(objCallNote);
                    logger.Info("CompanyID-{0}|CompanyName{1}- Call Notes Saved", objcompany.Id, objcompany.CompanyName);
                }
                catch (Exception ex)
                {

                    SPWrapper.DeleteCompany(objcompany.Id);

                    Summary += System.Environment.NewLine + " CompanyName" + objcompany.CompanyName + "- Followup Date- Invalid Date format";
                    logger.Error("CompanyID-{0}|CompanyName{1}- call Notes Failed Ex{2}", objcompany.Id, objcompany.CompanyName, ex.Message);
                    return false;
                }



            }
            return true;

        }
        public bool SaveCallNotes(DataRow row, Company objcompany)
        {
            var rows = row["CallNotes"].ToString().Trim();

            if (!String.IsNullOrEmpty(rows))
            {

                string[] lines = rows.Split(new[] { "~" }, StringSplitOptions.None);
                if (lines.Count() > 0)
                {
                    foreach (var item in lines)
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(item))
                            {
                                if (item.Split('|').Count() == 2)
                                {
                                    string date = item.Split('|')[0].Trim().Replace("\n", "");
                                    string desc = item.Split('|')[1].Trim();
                                    CallNote objCallNote = new CallNote
                                    {
                                        CompanyID = objcompany.Id,
                                        ActivityDate = ParseDate(date),
                                        CallContactId = 0,
                                        Description = desc,
                                        Type = 2,
                                        UserID = "SYSTEM",
                                        CreatedOn = new DateTime(2010, 1, 1),
                                        UpdatedOn = DateTime.Now

                                    };
                                    SPWrapper.SaveCallNote(objCallNote);

                                    logger.Info("CompanyID-{0}|CompanyName{1}- Call Notes Saved", objcompany.Id, objcompany.CompanyName);
                                }
                                else
                                {


                                    SPWrapper.DeleteCompany(objcompany.Id);
                                    Summary += System.Environment.NewLine + " CompanyName" + objcompany.CompanyName + "- CallNotes- Invalid Data format";


                                }

                            }
                        }

                        catch (Exception ex)

                        {

                            SPWrapper.DeleteCompany(objcompany.Id);
                            Summary += System.Environment.NewLine + " CompanyName" + objcompany.CompanyName + "- CallNotes- Invalid Data format";
                            logger.Error("CompanyID-{0}|CompanyName{1}- call Notes Failed Ex{2}", objcompany.Id, objcompany.CompanyName, ex.Message);
                            return false;
                        }
                    }
                }


            }
            return true;

        }

        public bool SaveAddress(DataRow row, Company objcompany)
        {
            var rows = row["Address"].ToString().Trim();
            if (!String.IsNullOrEmpty(rows))
            {
                if (rows.Contains('~'))
                {
                    string[] lines = rows.Split(new[] { "~" }, StringSplitOptions.None);
                    if (lines.Count() > 0)
                    {
                        foreach (var item in lines)
                        {
                            try
                            {
                                if (!string.IsNullOrEmpty(item))
                                {
                                    if (item.Split('|').Count() == 5)
                                    {
                                        string Title = item.Split('|')[0].Trim().Replace("\n", "");
                                        string Address = item.Split('|')[1].Trim();
                                        string Location = item.Split('|')[2].Trim();
                                        string Sublocation = item.Split('|')[3].Trim();
                                        string contactNumber = item.Split('|')[4].Trim();
                                        CompanyAddress objAddress = new CompanyAddress
                                        {
                                            CompanyID = objcompany.Id,
                                            Title = Title,
                                            Address = Address,
                                            City = Location,
                                            SubLocation = Sublocation,
                                            IsActive = true,
                                            ContactNumber = contactNumber

                                        };
                                        SPWrapper.SaveCompanyAddress(objAddress);
                                        logger.Info("CompanyID-{0}|CompanyName{1}- Company Addrres Saved", objcompany.Id, objcompany.CompanyName);
                                    }
                                    else
                                    {
                                        SPWrapper.DeleteCompany(objcompany.Id);
                                        Summary += System.Environment.NewLine + " CompanyName" + objcompany.CompanyName + "- Company Address- count Mismatch";


                                    }

                                }
                            }

                            catch (Exception ex)

                            {
                                SPWrapper.DeleteCompany(objcompany.Id);
                                Summary += System.Environment.NewLine + " CompanyName" + objcompany.CompanyName + "- Company Address- count Mismatch";
                                logger.Error("CompanyID-{0}|CompanyName{1}- call Notes Failed Ex{2}", objcompany.Id, objcompany.CompanyName, ex.Message);
                                return false;
                            }
                        }
                    }

                }
                else
                {
                    SPWrapper.DeleteCompany(objcompany.Id);
                    Summary += System.Environment.NewLine + " CompanyName" + objcompany.CompanyName + "Invalid Address- Split(~) not found";
                }



            }
            else
            {
                SPWrapper.DeleteCompany(objcompany.Id);
                Summary += System.Environment.NewLine + " CompanyName" + objcompany.CompanyName + "No Address found!";
            }
            return true;

        }

        public DateTime ParseDate(string date)
        {
            var ci = new CultureInfo("en-US");
            //var formats = new[] { "dd-M-yyyy", "d-M-yy", "M-d-yyyy", "dd-MM-yyyy", "MM-dd-yyyy", "M.d.yyyy", "dd.MM.yyyy", "MM.dd.yyyy" }

            var formats = new[] { "dd-M-yyyy", "d-M-yy", "dd-MM-yyyy", "d-M-yyyy", "dd-MM-yyyy hh:mm:ss" }
        .Union(ci.DateTimeFormat.GetAllDateTimePatterns()).ToArray();

            DateTime newdate = DateTime.ParseExact(date, formats, ci, DateTimeStyles.AssumeLocal);
            return newdate;
        }

        public bool SaveHiringDetails(DataRow row, Company objcompany)
        {
            var rows = row["HiredFrom"].ToString().Trim();
            if (!String.IsNullOrEmpty(rows))
            {
                string[] lines = rows.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);

                foreach (var item in lines)
                {
                    try
                    {
                        string CollegeCode = item.Split('-')[0].Trim();
                        string Year = item.Split('-').Length == 2 ? item.Split('-')[1].Trim() : "";
                        PastHiring objPastHiring = new PastHiring
                        {
                            CompanyID = objcompany.Id,
                            CollegeCode = CollegeCode,
                            Hiringyear = Year,
                            CreatedOn = DateTime.Now,
                            UpdatedOn = DateTime.Now,
                            UpdatedBy = "SYSTEM",
                            CreatedBy = "SYSTEM",
                            Remarks = "",
                            IsDeleted = false
                        };
                        SPWrapper.SavePastHiring(objPastHiring);

                        logger.Info("CompanyID-{0}|CompanyName{1}- Hiring Details Saved", objcompany.Id, objcompany.CompanyName);

                    }

                    catch (Exception ex)

                    {
                        logger.Error("CompanyID-{0}|CompanyName{1}- Hiring Details Failed Ex{2}", objcompany.Id, objcompany.CompanyName, ex.Message);
                        return false;
                    }
                }

            }
            return true;
        }


        private bool SaveExtraContacts(DataRow row, Company objcompany)
        {
            var ExtraContacts = row["ExtraContactPersons"].ToString().Trim();
            if (ExtraContacts != "")
            {
                try
                {
                    string[] CP = ExtraContacts.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < CP.Length; i++)
                    {

                        CompanyExtraContacts objExtraContacts = new CompanyExtraContacts
                        {
                            CompanyId = objcompany.Id,
                            Value = CP[i]
                        };
                        SPWrapper.SaveCompanyExtraContacts(objExtraContacts);
                        logger.Info("CompanyID-{0}|CompanyName{1}- Extra Contact Persons Saved", objcompany.Id, objcompany.CompanyName);
                    }
                }
                catch (Exception ex)
                {
                    Summary += System.Environment.NewLine + " CompanyName" + objcompany.CompanyName + "-  Extra Call Notes Ex" + ex.Message;
                    SPWrapper.DeleteCompany(objcompany.Id);
                    logger.Error("CompanyID-{0}|CompanyName{1}- Extra Contact Persons EX{2}", objcompany.Id, objcompany.CompanyName, ex.Message);

                }
            }


            return true;
        }


        private bool SaveExtraCallNotes(DataRow row, Company objcompany)
        {
            if (row["PREVIOUSCALLNOTES"] != null)
            {
                string callnotes = row["PREVIOUSCALLNOTES"].ToString();
                SaveCallNotes(callnotes, objcompany);
            }

            for (int i = 0; i < 30; i++)
            {
                try
                {

                    var colName = "PREVIOUSCALLNOTES" + i;
                    if (row[colName] != null)
                    {
                        string callnotes = row[colName].ToString();
                        SaveCallNotes(callnotes, objcompany);
                    }
                }
                catch (Exception ex)
                {
                    logger.Error("CompanyID-{0}|CompanyName{1}- Extra Call Notes Failed EX{2}", objcompany.Id, objcompany.CompanyName, ex.Message);
                }

            }




            return true;
        }


        private bool SaveCallNotes(string input, Company objcompany)
        {
            var ContactPerson = input;
            if (ContactPerson != "")
            {
                try
                {
                    string[] CP = ContactPerson.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 0; i < CP.Length; i++)
                    {
                        ExtraCallNotes objExtraCallNotes = new ExtraCallNotes
                        {
                            CompanyId = objcompany.Id,
                            Value = CP[i]
                        };
                        SPWrapper.SaveExtraCallNotes(objExtraCallNotes);
                        logger.Info("CompanyID-{0}|CompanyName{1}- Extra Call Notes Saved", objcompany.Id, objcompany.CompanyName);
                    }
                }
                catch (Exception ex)
                {
                    Summary += System.Environment.NewLine + " CompanyName" + objcompany.CompanyName + "-  Extra Call Notes Ex" + ex.Message;
                    SPWrapper.DeleteCompany(objcompany.Id);
                    logger.Error("CompanyID-{0}|CompanyName{1}- Extra Call Notes Failed EX{2}", objcompany.Id, objcompany.CompanyName, ex.Message);
                    return false;
                }

            }
            return true;
        }
        private bool SaveEmployeeDetails(DataRow row, Company objcompany)
        {
            var ContactPerson = row["ContactPerson"].ToString().Trim();
            var Designation = row["Designation"].ToString().Trim();
            var EmailID = row["EmailID"].ToString().Trim();

            string[] CP = ContactPerson.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            string[] D = Designation.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            string[] E = EmailID.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            if (CP.Length == D.Length && D.Length == E.Length)
            {
                try
                {
                    for (int i = 0; i < CP.Length; i++)
                    {
                        CompanyContact objContact = new CompanyContact();
                        objContact.Description = "NA";
                        objContact.CompanyID = objcompany.Id;

                        var contact = CP[i].Split('|');
                        if (contact.Length == 4)
                        {
                            objContact.ContactName = contact[0].Trim();
                            objContact.MobileNumber = contact[1].Trim();
                            objContact.PhoneNumber = contact[2].Trim();
                            objContact.ColorCode = contact[3].Trim();
                            objContact.Designation = D[i].Trim();
                            objContact.EmailID = E[i].Trim();
                            objContact.CreatedOn = DateTime.Now;
                            objContact.UpdatedOn = DateTime.Now;
                            objContact.CreatedBy = "SYSTEM";
                            objContact.UpdatedBy = "SYSTEM";
                            SPWrapper.SaveContact(objContact);
                            logger.Info("CompanyID-{0}|CompanyName{1}- Contact Details Saved", objcompany.Id, objcompany.CompanyName);
                        }
                        else
                        {
                            Summary += System.Environment.NewLine + " CompanyName" + objcompany.CompanyName + "-  Contact Details must contain 4 Name|mobile|phone|color";
                            SPWrapper.DeleteCompany(objcompany.Id);
                        }



                    }
                }
                catch (Exception ex)
                {
                    Summary += System.Environment.NewLine + " CompanyName" + objcompany.CompanyName + "-  Contact Details Ex" + ex.Message;
                    SPWrapper.DeleteCompany(objcompany.Id);
                    logger.Error("CompanyID-{0}|CompanyName{1}- Contact Details Failed EX{2}", objcompany.Id, objcompany.CompanyName, ex.Message);

                }
            }
            else
            {
                SPWrapper.DeleteCompany(objcompany.Id);

                Summary += System.Environment.NewLine + " CompanyName" + objcompany.CompanyName + "- Contact Details- Email,Designation and Emailid Count Do not match";
                logger.Error("CompanyID-{0}|CompanyName{1}- Contact Details- Email,Designation and Emailid Count Do not match", objcompany.Id, objcompany.CompanyName);
                return false;
            }

            return true;
        }

        public bool SaveJDDetails(DataRow row, Company objcompany)
        {

            var JD = row["JDReceived"].ToString();

            if (!string.IsNullOrEmpty(JD))
            {
                string[] lines = JD.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in lines)
                {
                    try
                    {
                        if (item.Split('-').Length == 2)
                        {
                            string Type = item.Split('-')[0].Trim();
                            string Year = item.Split('-')[1].Trim();
                            JobDescription objJobDescription = new JobDescription
                            {
                                CompanyID = objcompany.Id,
                                Title = "No",
                                Type = "",
                                Year = Year,
                                CreatedOn = DateTime.Now,
                                UpdatedOn = DateTime.Now,
                                UpdatedBy = "SYSTEM",
                                CreatedBy = "SYSTEM",
                                IsActive = true,
                                IsDeleted = false
                            };

                            SPWrapper.SavejobDescription(objJobDescription);
                            logger.Info("CompanyID-{0}|CompanyName{1}- PR Details Saved", objcompany.Id, objcompany.CompanyName);
                        }
                        else
                        {
                            Summary += System.Environment.NewLine + " CompanyName" + objcompany.CompanyName + "Incorrect PR Details Format, Use Format as [OCC-2019]";
                            SPWrapper.DeleteCompany(objcompany.Id);
                        }
                    }

                    catch (Exception ex)

                    {
                        Summary += System.Environment.NewLine + " CompanyName" + objcompany.CompanyName + "-  PR Details Ex" + ex.Message;

                        SPWrapper.DeleteCompany(objcompany.Id);
                        logger.Error("CompanyID-{0}|CompanyName{1}- PR Details Failed Ex{2}", objcompany.Id, objcompany.CompanyName, ex.Message);
                        return false;
                    }
                }
            }
            return true;
        }
        public bool SavePastRecruiterDetails(DataRow row, Company objcompany)
        {

            var RD = row["PastRecruiterDetails"].ToString();

            if (!string.IsNullOrEmpty(RD))
            {
                string[] lines = RD.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var item in lines)
                {
                    try
                    {
                        if (item.Split('-').Length == 2)
                        {
                            string Type = item.Split('-')[0].Trim();
                            string Year = item.Split('-')[1].Trim();
                            JobDescription objJobDescription = new JobDescription
                            {
                                CompanyID = objcompany.Id,
                                Title = "Yes",
                                Type = Type,
                                Year = Year,
                                CreatedOn = DateTime.Now,
                                UpdatedOn = DateTime.Now,
                                UpdatedBy = "SYSTEM",
                                CreatedBy = "SYSTEM",
                                IsActive = true,
                                IsDeleted = false
                            };

                            SPWrapper.SavejobDescription(objJobDescription);
                            logger.Info("CompanyID-{0}|CompanyName{1}- PR Details Saved", objcompany.Id, objcompany.CompanyName);
                        }
                        else
                        {
                            Summary += System.Environment.NewLine + " CompanyName" + objcompany.CompanyName + "Incorrect PR Details Format, Use Format as [OCC-2019]";
                            SPWrapper.DeleteCompany(objcompany.Id);
                        }
                    }

                    catch (Exception ex)

                    {
                        Summary += System.Environment.NewLine + " CompanyName" + objcompany.CompanyName + "-  PR Details Ex" + ex.Message;

                        SPWrapper.DeleteCompany(objcompany.Id);
                        logger.Error("CompanyID-{0}|CompanyName{1}- PR Details Failed Ex{2}", objcompany.Id, objcompany.CompanyName, ex.Message);
                        return false;
                    }
                }
            }
            return true;
        }
        [HttpPost]
        public ActionResult Reset()
        {
            Session["ExcelData"] = null;
            return RedirectToAction("Index");
        }




    }
}