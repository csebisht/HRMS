using Microsoft.AspNet.Identity;
using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using WEBAPP.DAL;
using WEBAPP.Models;

namespace WEBAPP.Controllers
{
    [Authorize]
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CompanyListSearch(int[] Year)
        {
            List<Company> objCompanyList = new List<Company>();
            List<User> objUserList = new List<User>();
            objUserList = DataMapper.MapUserData(SPWrapper.GetUserList());

            //Get Logged IN UserName
            var Username = User.Identity.GetUserName();
            // Get Logged IN User Details();
            User objUser = objUserList.Where(x => x.Email.ToUpper() == Username.ToUpper()).FirstOrDefault();

            if (objUser.IsAdmin)
            {
                objCompanyList = DataMapper.MapCompanyData(SPWrapper.GetCompanyList()).Where(x => x.IsDeleted == false).ToList();
            }
            else
            {
                objCompanyList = DataMapper.MapCompanyData(SPWrapper.GetCompanyListByUser(Username)).Where(x => x.IsDeleted == false).ToList();
            }


            var Result = new List<Company>();


            if (Year != null)
            {
                foreach (var item in Year)
                {

                    Result.AddRange(FilterCompanyList("Year", item.ToString(), new Company()).CompanyList);
                }
            }

            return View("CompanyList", Result);
        }






        [OutputCache(Duration = 120)]
        public List<User> GetUserList()
        {
            List<User> objUserList = new List<User>();
            objUserList = DataMapper.MapUserData(SPWrapper.GetUserList());
            return objUserList;
        }



        public List<Company> FilterCompanyByUser(List<Company> objCompanyList)
        {
            List<User> objUserList = GetUserList();
            //Get Logged IN UserName
            var Username = User.Identity.GetUserName();
            // Get Logged IN User Details();
            User objUser = objUserList.Where(x => x.Email.ToUpper() == Username.ToUpper()).FirstOrDefault();
            if (!objUser.IsAdmin)
            {
                objCompanyList = objCompanyList.Where(x => x.AllotedTo.ToUpper() == Username.ToUpper() && x.IsDeleted == false).ToList();
            }
            return objCompanyList;
        }
        public List<Company> GetCompanyMaster()
        {
            List<User> objUserList = new List<User>();
            List<Company> objCompanyList = new List<Company>();
            objUserList = GetUserList();
            //Get Logged IN UserName
            var Username = User.Identity.GetUserName();
            // Get Logged IN User Details();
            User objUser = objUserList.Where(x => x.Email.ToUpper() == Username.ToUpper()).FirstOrDefault();
            if (objUser.IsAdmin)
            {
                objCompanyList = DataMapper.MapCompanyMaster(SPWrapper.GetCompanyList()).Where(x => x.IsDeleted == false).ToList();
            }
            else
            {
                objCompanyList = DataMapper.MapCompanyMaster(SPWrapper.GetCompanyListByUser(Username)).Where(x => x.IsDeleted == false).ToList();
            }


            return objCompanyList;

        }

        public List<Company> GetCompanies()
        {
            List<User> objUserList = new List<User>();
            List<Company> objCompanyList = new List<Company>();
            objUserList = GetUserList();
            //Get Logged IN UserName
            var Username = User.Identity.GetUserName();
            // Get Logged IN User Details();
            User objUser = objUserList.Where(x => x.Email.ToUpper() == Username.ToUpper()).FirstOrDefault();
            if (objUser.IsAdmin)
            {
                objCompanyList = DataMapper.MapCompanyDataForListing(SPWrapper.GetCompanyList()).Where(x => x.IsDeleted == false).ToList();
            }
            else
            {
                objCompanyList = DataMapper.MapCompanyDataForListing(SPWrapper.GetCompanyListByUser(Username)).Where(x => x.IsDeleted == false).ToList();
            }


            return objCompanyList;

        }
        public List<Company> GetCompaniesForExport()
        {
            List<User> objUserList = new List<User>();
            List<Company> objCompanyList = new List<Company>();
            objUserList = GetUserList();
            //Get Logged IN UserName
            var Username = User.Identity.GetUserName();
            // Get Logged IN User Details();
            User objUser = objUserList.Where(x => x.Email.ToUpper() == Username.ToUpper()).FirstOrDefault();
            if (objUser.IsAdmin)
            {
                objCompanyList = DataMapper.MapCompanyDataForExport(SPWrapper.GetCompanyList()).Where(x => x.IsDeleted == false).ToList();
            }
            else
            {
                objCompanyList = DataMapper.MapCompanyDataForExport(SPWrapper.GetCompanyListByUser(Username)).Where(x => x.IsDeleted == false).ToList();
            }


            return objCompanyList;

        }


        public List<Company> GetCompaniesWithDetails()
        {
            List<User> objUserList = new List<User>();
            List<Company> objCompanyList = new List<Company>();
            objUserList = GetUserList();
            //Get Logged IN UserName
            var Username = User.Identity.GetUserName();
            // Get Logged IN User Details();
            User objUser = objUserList.Where(x => x.Email.ToUpper() == Username.ToUpper()).FirstOrDefault();
            if (objUser.IsAdmin)
            {
                objCompanyList = DataMapper.MapCompanyData(SPWrapper.GetCompanyList()).Where(x => x.IsDeleted == false).ToList();
            }
            else
            {
                objCompanyList = DataMapper.MapCompanyData(SPWrapper.GetCompanyListByUser(Username)).Where(x => x.IsDeleted == false).ToList();
            }

            return objCompanyList;
        }


        [HttpGet]
        public ActionResult CompanyList()

        {
            Company objCompany = new Company();
            objCompany = GetCommonData(objCompany);
            objCompany.CompanyList = GetCompanyMaster();
            return View(objCompany);
        }

        [HttpGet]
        public ActionResult CompanyListv2()

        {
            Company objCompany = new Company();
            objCompany = GetCommonData(objCompany);
            objCompany.CompanyList = GetCompanyMaster();
            return View(objCompany);
        }

        [HttpPost]
        public JsonResult GetDetails()
        {

            List<Company> data = new List<Company>();
            var start = (Convert.ToInt32(Request["start"]));
            var Length = (Convert.ToInt32(Request["length"])) == 0 ? 10 : (Convert.ToInt32(Request["length"]));
            var searchvalue = Request["search[value]"] ?? "";
            var sortcoloumnIndex = Convert.ToInt32(Request["order[0][column]"]);
            var SortColumn = "";
            var SortOrder = "";
            var sortDirection = Request["order[0][dir]"] ?? "asc";
            var recordsTotal = 0;
            var username = User.Identity.GetUserName().ToUpperInvariant() == "ADMIN@AE.IN" ? "" : User.Identity.GetUserName();

            try
            {
                switch (sortcoloumnIndex)
                {
                    case 0:
                        SortColumn = "CompanyName";
                        break;
                    case 1:
                        SortColumn = "CreatedOn ";
                        break;
                    case 2:
                        SortColumn = "DateGiven";
                        break;

                    default:
                        SortColumn = "AllotedTo";
                        break;
                }
                if (sortDirection == "asc")
                    SortOrder = "asc";
                else
                    SortOrder = "desc";
                data = GetCompanies(start, searchvalue, Length, SortColumn, sortDirection, username).ToList();
                recordsTotal = data.Count > 0 ? data.Count : 0;
            }
            catch (Exception ex)
            {
            }
            return Json(new { data = data, recordsTotal = recordsTotal, recordsFiltered = recordsTotal }, JsonRequestBehavior.AllowGet);
        }



        public List<Company> GetCompanies(int start, string searchvalue, int length, string sortColumn, string sortDirection, string username)
        {
            return DataMapper.MapCompanyDataForListing(SPWrapper.GetCompanyListByPage(start, searchvalue, length, sortColumn, sortDirection, username)).Where(x => x.IsDeleted == false).ToList();
        }

        [HttpGet]
        public ActionResult Export()

        {
            Company objCompany = new Company();
            objCompany = GetCommonData(objCompany);
            objCompany.CompanyList = GetCompaniesForExport();
            return View(objCompany);
        }

        [HttpPost]
        public ActionResult Export(string DOB, String Contact, string Filter, string CallDone, string CallCompleted, string Global, int[] Year,string SNotYear, string[] ColorCode, string[] SearchStream, string[] SearchSector, string[] SearchCollege, string State, string City, string Pincode, string Package, string SummerTraining, string ResearchSource, string TransferredFrom, string FollowUpDateFrom, string FollowUpDateTo, string SubLocation, string EventStatus, string VisitStatus, string EventTypeId, string sCityId, string VisitDetails, string AcceptGift, string IsActive, string AllotedTo)
        {


            Company objCompany = new Company();

            objCompany.CompanyList = GetCompaniesForExport();

            var Result = new Company();

            if (SearchSector != null)
            {
                foreach (var item in SearchSector)
                {
                    Result.CompanyList = FilterCompanyList("Sector", item.ToString(), objCompany).CompanyList;

                    objCompany.CompanyList = Result.CompanyList;
                }
            }

            if (AllotedTo != null & AllotedTo != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("AllotedTo", AllotedTo, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }
            if (Global != null & Global != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("Global", Global, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }
            if (AcceptGift != null & AcceptGift != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("AcceptGift", AcceptGift, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (VisitDetails != null & VisitDetails != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("VisitDetails", VisitDetails, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (sCityId != null & sCityId != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("CityId", sCityId, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (IsActive != null & IsActive != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("IsActive", IsActive, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (EventTypeId != null & EventTypeId != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("EventTypeId", EventTypeId, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (VisitStatus != null & VisitStatus != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("VisitStatus", VisitStatus, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (EventStatus != null & EventStatus != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("EventStatus", EventStatus, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }


            if ((FollowUpDateFrom != null & FollowUpDateFrom != string.Empty) && (FollowUpDateTo != null & FollowUpDateTo != string.Empty))
            {


                string[] DatePair = new string[] { FollowUpDateFrom, FollowUpDateTo };
                Result.CompanyList = FilterCompanyList("FollowUpDateFromAndTo", "", objCompany, DatePair).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            //if (FollowUpDateFrom != null & FollowUpDateFrom != string.Empty)
            //{



            //    Result.CompanyList = FilterCompanyList("FollowUpDateFrom", FollowUpDateFrom, objCompany).CompanyList;
            //    objCompany.CompanyList = Result.CompanyList;

            //}
            //if (FollowUpDateTo != null & FollowUpDateTo != string.Empty)
            //{



            //    Result.CompanyList = FilterCompanyList("FollowUpDateTo", FollowUpDateTo, objCompany).CompanyList;
            //    objCompany.CompanyList = Result.CompanyList;

            //}



            if (TransferredFrom != null & TransferredFrom != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("TransferredFrom", TransferredFrom, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (ResearchSource != null & ResearchSource != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("ResearchSource", ResearchSource, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (SummerTraining != null & SummerTraining != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("SummerTraining", SummerTraining, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (Package != null & Package != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("Package", Package, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (SearchStream != null)
            {

                foreach (var item in SearchStream)
                {

                    Result.CompanyList = FilterCompanyList("Stream", item.ToString(), objCompany).CompanyList;
                    objCompany.CompanyList = Result.CompanyList;
                }

            }


            if (ColorCode != null && ColorCode.Length > 0)
            {



                foreach (var item in ColorCode)
                {

                    if (item != "")
                    {
                        Result.CompanyList = FilterCompanyList("Color", item.ToString(), objCompany).CompanyList;
                        objCompany.CompanyList = Result.CompanyList;
                    }

                }

            }

            if (SearchCollege != null)
            {

                foreach (var item in SearchCollege)
                {

                    Result.CompanyList = FilterCompanyList("College", item.ToString(), objCompany).CompanyList;
                    objCompany.CompanyList = Result.CompanyList;
                }

            }

            if (State != null & State != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("State", State.ToString(), objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (SubLocation != null & SubLocation != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("SubLocation", SubLocation, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (City != null & City != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("City", City.ToString(), objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (CallDone != null & CallDone != string.Empty)
            {


                Result.CompanyList = FilterCompanyList("CallDone", CallDone.ToString(), objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (CallCompleted != null & CallCompleted != string.Empty)
            {


                Result.CompanyList = FilterCompanyList("CallCompleted", CallCompleted.ToString(), objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (DOB != null & DOB != string.Empty)
            {


                Result.CompanyList = FilterCompanyList("DOB", DOB.ToString(), objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (Contact != null & Contact != string.Empty)
            {


                Result.CompanyList = FilterCompanyList("Contact", Contact.ToString(), objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (Pincode != null & Pincode != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("Pincode", Pincode.ToString(), objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (Year != null)
            {
                foreach (var item in Year)
                {

                    Result.CompanyList.AddRange(FilterCompanyList("Year", item.ToString(), objCompany).CompanyList);

                }

                objCompany.CompanyList = Result.CompanyList;

            }
            if (!string.IsNullOrEmpty(SNotYear))
            {
                foreach (Company item in Result.CompanyList.ToList())
                {
                    if (item.JobDescriptionList.Any(x => x.Year == SNotYear))
                    {
                        Result.CompanyList.Remove(item);
                    };

                }
            }
            if (Global != "" & Global != null)
            {
                Result.CompanyList = FilterCompanyList("Global", Global, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;
            }
            if (Filter == "All")
            {
                Result = objCompany;
            }
            if (Filter == "Today")
            {
                Result.CompanyList = objCompany.CompanyList.FindAll(z => z.CallNoteList.Where(c => c.ActivityDate.Date > DateTime.Now.Date && c.Type != 6).Count() == 0).Where(x => x.CallNoteList.Any(z => z.ActivityDate.Date == DateTime.Now.Date)).ToList();
            }
            if (Filter == "Past")
            {
                Result.CompanyList = objCompany.CompanyList.FindAll(z => z.CallNoteList.Where(c => c.ActivityDate.Date > DateTime.Now.Date && c.Type != 6).Count() == 0).ToList();
            }
            if (Filter == "ThisMonth")
            {
                Result.CompanyList = objCompany.CompanyList.Where(x => x.CallNoteList.Any(z => z.Type == 1 && z.ActivityDate.Month == DateTime.Now.Month && z.ActivityDate.Year == DateTime.Now.Month)).ToList();
            }
            if (Filter == "Important")
            {
                Result.CompanyList = objCompany.CompanyList.Where(z => z.CallNoteList.Count() > 0 && z.CallNoteList.First().Type == 3).ToList();
                //Result.CompanyList = objCompany.CompanyList.Where(x => x.CallNoteList.Any(z => z.Type == 3 && z.ActivityDate.ToString("MM-dd-yyyy")==DateTime.Now.ToString("MM-dd-yyyy"))).ToList();
            }
            if (Filter == "Positive")

            {

                Result.CompanyList = objCompany.CompanyList.Where(z => z.CallNoteList.Count() > 0 && z.CallNoteList.First().Type == 4).ToList();


                //   objCompany.CompanyList.Where(x => x.CallNoteList.Any(z => z.Type == 4 && z.ActivityDate.ToString("MM-dd-yyyy") == DateTime.Now.ToString("MM-dd-yyyy"))).ToList();
            }
            if (Filter == "Coordination")
            {
                Result.CompanyList = objCompany.CompanyList.Where(z => z.CallNoteList.Count() > 0 && z.CallNoteList.First().Type == 2).ToList();
                // Result.CompanyList = objCompany.CompanyList.Where(x => x.CallNoteList.Any(z => z.Type == 2 && z.ActivityDate.ToString("MM-dd-yyyy") == DateTime.Now.ToString("MM-dd-yyyy"))).ToList();
            }
            if (Filter == "Deleted")
            {

                Result.CompanyList = DataMapper.MapCompanyDataForListing(SPWrapper.GetCompanyList()).Where(x => x.IsDeleted == true).ToList();
            }



            Result = GetCommonData(Result);
            Result.CompanyList = Result.CompanyList.Distinct().ToList();
            return View(Result);
        }


        [HttpPost]
        public ActionResult CompanyList(string MTCorSTC, string CompanyName, string DOB, String Contact, string Filter, string CallDone, string CallCompleted, string Global, int[] Year, string[] ColorCode, string[] SearchStream, string[] SearchSector, string[] SearchCollege, string State, string City, string Pincode, string Package, string SummerTraining, string ResearchSource, string TransferredFrom, string FollowUpDateFrom, string FollowUpDateTo, string SubLocation, string EventStatus, string VisitStatus, string EventTypeId, string sCityId, string VisitDetails, string AcceptGift, string IsActive, string ThirdParty, string AllotedTo, string DateGiven)
        {
            Company objCompany = new Company();
            var Result = new Company();
            //optimised Search
            if (Filter == "Today" || Filter == "Past")
            {
                Result.CompanyList = FilterCompanyByUser(DataMapper.MapCompanyMaster(SPWrapper.GetCompanyByQuery(Filter)));
                Result = GetCommonData(Result);
                Result.CompanyList = Result.CompanyList.Distinct().ToList();
                return View(Result);

                //  Result.CompanyList = objCompany.CompanyList.FindAll(z => z.CallNoteList.Where(c => c.ActivityDate.Date > DateTime.Now.Date).Count() == 0).Where(x => x.CallNoteList.Any(z => z.ActivityDate.Date == DateTime.Now.Date)).ToList();
            }


            if (CompanyName != null && CompanyName != string.Empty)
            {
                Result.CompanyList = DataMapper.MapCompanyMaster(SPWrapper.GetCompanyByQuery("CompanyName", CompanyName));
                //DataMapper.MapCompanyDataForListing(SPWrapper.GetCompanyList()).Where(x => x.IsDeleted == false && x.CompanyName.ToUpper().Contains(CompanyName.ToUpper())).ToList();
                Result = GetCommonData(Result);
                objCompany.CompanyList = Result.CompanyList;
                return View(Result);
            }

            objCompany.CompanyList = GetCompaniesWithDetails();

            

            if (MTCorSTC != null && MTCorSTC != string.Empty)
            {
                Result.CompanyList = FilterCompanyList("MTCorSTC", MTCorSTC, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (SearchSector != null)
            {
                foreach (var item in SearchSector)
                {
                    Result.CompanyList = FilterCompanyList("Sector", item.ToString(), objCompany).CompanyList;

                    objCompany.CompanyList = Result.CompanyList;
                }
            }
            if (ThirdParty != null & ThirdParty != string.Empty)
            {

                Result.CompanyList = FilterCompanyList("ThirdParty", ThirdParty, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }
            if (AllotedTo != null && AllotedTo != string.Empty)
            {

                Result.CompanyList = FilterCompanyList("AllotedTo", AllotedTo, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }
            if (DateGiven != null & DateGiven != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("DateGiven", DateGiven, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (Global != null & Global != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("Global", Global, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }
            if (AcceptGift != null & AcceptGift != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("AcceptGift", AcceptGift, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (VisitDetails != null & VisitDetails != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("VisitDetails", VisitDetails, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (sCityId != null & sCityId != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("CityId", sCityId, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (IsActive != null & IsActive != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("IsActive", IsActive, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (EventTypeId != null & EventTypeId != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("EventTypeId", EventTypeId, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (VisitStatus != null & VisitStatus != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("VisitStatus", VisitStatus, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (EventStatus != null & EventStatus != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("EventStatus", EventStatus, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }


            if ((FollowUpDateFrom != null & FollowUpDateFrom != string.Empty) && (FollowUpDateTo != null & FollowUpDateTo != string.Empty))
            {


                string[] DatePair = new string[] { FollowUpDateFrom, FollowUpDateTo };
                Result.CompanyList = FilterCompanyList("FollowUpDateFromAndTo", "", objCompany, DatePair).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }


            //if (FollowUpDateFrom != null & FollowUpDateFrom != string.Empty)
            //{



            //    Result.CompanyList = FilterCompanyList("FollowUpDateFrom", FollowUpDateFrom, objCompany).CompanyList;
            //    objCompany.CompanyList = Result.CompanyList;

            //}
            //if (FollowUpDateTo != null & FollowUpDateTo != string.Empty)
            //{



            //    Result.CompanyList = FilterCompanyList("FollowUpDateTo", FollowUpDateTo, objCompany).CompanyList;
            //    objCompany.CompanyList = Result.CompanyList;

            //}

            if (TransferredFrom != null & TransferredFrom != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("TransferredFrom", TransferredFrom, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (ResearchSource != null & ResearchSource != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("ResearchSource", ResearchSource, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (SummerTraining != null & SummerTraining != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("SummerTraining", SummerTraining, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (Package != null & Package != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("Package", Package, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (SearchStream != null)
            {

                foreach (var item in SearchStream)
                {

                    Result.CompanyList = FilterCompanyList("Stream", item.ToString(), objCompany).CompanyList;
                    objCompany.CompanyList = Result.CompanyList;
                }

            }


            if (ColorCode != null && ColorCode.Length > 0)
            {



                foreach (var item in ColorCode)
                {

                    if (item != "")
                    {
                        Result.CompanyList = FilterCompanyList("Color", item.ToString(), objCompany).CompanyList;
                        objCompany.CompanyList = Result.CompanyList;
                    }

                }

            }

            if (SearchCollege != null)
            {

                foreach (var item in SearchCollege)
                {

                    Result.CompanyList = FilterCompanyList("College", item.ToString(), objCompany).CompanyList;
                    objCompany.CompanyList = Result.CompanyList;
                }

            }

            if (State != null & State != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("State", State.ToString(), objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (SubLocation != null & SubLocation != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("SubLocation", SubLocation, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (City != null & City != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("City", City.ToString(), objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (CallDone != null & CallDone != string.Empty)
            {


                Result.CompanyList = FilterCompanyList("CallDone", CallDone.ToString(), objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }


            if (CallCompleted != null & CallCompleted != string.Empty)
            {


                Result.CompanyList = FilterCompanyList("CallCompleted", CallCompleted.ToString(), objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }


            if (DOB != null & DOB != string.Empty)
            {


                Result.CompanyList = FilterCompanyList("DOB", DOB.ToString(), objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (Contact != null & Contact != string.Empty)
            {


                Result.CompanyList = FilterCompanyList("Contact", Contact.ToString(), objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (Pincode != null & Pincode != string.Empty)
            {



                Result.CompanyList = FilterCompanyList("Pincode", Pincode.ToString(), objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;

            }

            if (Year != null)
            {
                foreach (var item in Year)
                {

                    Result.CompanyList.AddRange(FilterCompanyList("Year", item.ToString(), objCompany).CompanyList);

                }

                objCompany.CompanyList = Result.CompanyList;

            }
            if (Global != "" & Global != null)
            {
                Result.CompanyList = FilterCompanyList("Global", Global, objCompany).CompanyList;
                objCompany.CompanyList = Result.CompanyList;
            }
            if (Filter == "All")
            {
                Result = objCompany;
            }

            if (Filter == "Past")
            {
                Result.CompanyList = objCompany.CompanyList.FindAll(z => z.CallNoteList.Where(c => c.ActivityDate.Date > DateTime.Now.Date && c.Type != 6).Count() == 0).ToList();
            }
            if (Filter == "ThisMonth")
            {
                Result.CompanyList = objCompany.CompanyList.Where(x => x.CallNoteList.Any(z => z.Type == 1 && z.ActivityDate.Month == DateTime.Now.Month)).ToList();
            }
            if (Filter == "Important")
            {
                Result.CompanyList = objCompany.CompanyList.Where(z => z.CallNoteList.Count() > 0 && z.CallNoteList.First().Type == 3).ToList();
                //Result.CompanyList = objCompany.CompanyList.Where(x => x.CallNoteList.Any(z => z.Type == 3 && z.ActivityDate.ToString("MM-dd-yyyy")==DateTime.Now.ToString("MM-dd-yyyy"))).ToList();
            }
            if (Filter == "Positive")

            {

                Result.CompanyList = objCompany.CompanyList.Where(z => z.CallNoteList.Count() > 0 && z.CallNoteList.First().Type == 4).ToList();


                //   objCompany.CompanyList.Where(x => x.CallNoteList.Any(z => z.Type == 4 && z.ActivityDate.ToString("MM-dd-yyyy") == DateTime.Now.ToString("MM-dd-yyyy"))).ToList();
            }
            if (Filter == "Coordination")
            {
                Result.CompanyList = objCompany.CompanyList.Where(z => z.CallNoteList.Count() > 0 && z.CallNoteList.First().Type == 2).ToList();
                // Result.CompanyList = objCompany.CompanyList.Where(x => x.CallNoteList.Any(z => z.Type == 2 && z.ActivityDate.ToString("MM-dd-yyyy") == DateTime.Now.ToString("MM-dd-yyyy"))).ToList();
            }
            if (Filter == "Deleted")
            {

                Result.CompanyList = DataMapper.MapCompanyDataForListing(SPWrapper.GetCompanyList()).Where(x => x.IsDeleted == true).ToList();
            }



            Result = GetCommonData(Result);
            Result.CompanyList = Result.CompanyList.Distinct().ToList();
            return View(Result);
        }


        //Global Search
        public Company FilterCompanyList(string Type, string Query, Company objcompany, string[] paramArray = null)
        {


            var Result = new Company();
            if (Type == "Global")
            {
                Query = Query.ToUpper();
                foreach (var item in objcompany.CompanyList)
                {

                    //if (item.Address1.ToUpper().Contains(Query) || item.Address2.Contains(Query)
                    //    || item.City.ToUpper().Contains(Query)
                    //    || item.ColorCode.ToUpper().Contains(Query) || item.CompanyName.ToUpper().Contains(Query)
                    //    || item.ContactNumber.ToUpper().Contains(Query)
                    //    || item.HiringArea.ToUpper().Contains(Query)
                    //    || item.MTCorSTC.ToUpper().Contains(Query)
                    //    || item.PlantorRegdOffice.ToUpper().Contains(Query)
                    //    || item.Remarks.ToUpper().Contains(Query) || item.ResearchSource.ToUpper().Contains(Query)
                    //    || item.Sector.ToUpper().Contains(Query)
                    //    || item.SubLocation.ToUpper().Contains(Query) || item.Summary.ToUpper().Contains(Query)
                    //    || item.SummerTraining.ToUpper().Contains(Query) || item.ThirdParty.ToUpper().Contains(Query)
                    //    || item.TransferredFrom.ToUpper().Contains(Query)
                    //    || item.AllotedTo.ToUpper().Contains(Query)
                    //    || item.CompanyContactList.Any(x => (x.MobileNumber!=null && x.MobileNumber.Contains(Query)) ||( x.PhoneNumber != null && x.PhoneNumber.Contains(Query)) ||  (x.ContactName != null && x.ContactName.ToUpper().Contains(Query)) || (x.EmailID!=null && x.EmailID.ToUpper().Contains(Query)) || (x.PhoneNumber!=null && x.PhoneNumber.Contains(Query)) || (x.Address!=null && x.Address.Contains(Query)))
                    //   )
                    if (item.PastRecruitmentList.Any(x => x.Code.ToUpper().Contains(Query))
                    || item.CompanyContactList.Any(x => (x.MobileNumber != null && x.MobileNumber.Contains(Query)) || (x.PhoneNumber != null && x.PhoneNumber.Contains(Query)) || (x.ContactName != null && x.ContactName.ToUpper().Contains(Query)) || (x.EmailID != null && x.EmailID.ToUpper().Contains(Query)) || (x.PhoneNumber != null && x.PhoneNumber.Contains(Query)) || (x.Address != null && x.Address.Contains(Query)))
                   )
                    {
                        Result.CompanyList.Add(item);
                    }


                }
            }

            if (Type == "MTCorSTC")
            {
                foreach (var item in objcompany.CompanyList)
                {
                    Query = Query.ToUpper();
                    if (item.MTCorSTC.ToUpper().Contains(Query))
                    {
                        Result.CompanyList.Add(item);
                    };

                }
            }

            if (Type == "AllotedTO")
            {
                foreach (var item in objcompany.CompanyList)
                {
                    Query = Query.ToUpper();
                    if (item.AllotedTo.ToUpper().Contains(Query))
                    {
                        Result.CompanyList.Add(item);
                    };

                }


            }
            if (Type == "ThirdParty")
            {
                foreach (var item in objcompany.CompanyList)
                {
                    Query = Query.ToUpper();
                    if (item.ThirdParty.ToUpper().Contains(Query))
                    {
                        Result.CompanyList.Add(item);
                    };

                }


            }
            if (Type == "DateGiven")
            {
                foreach (var item in objcompany.CompanyList)
                {

                    if (item.DateGiven.ToString("MM-dd-yyyy") == Query)
                    {
                        Result.CompanyList.Add(item);
                    };

                }


            }


            if (Type == "DOB")
            {
                foreach (var item in objcompany.CompanyList)
                {

                    if (item.CompanyContactList.Any(x => x.DOB == Query))
                    {
                        Result.CompanyList.Add(item);
                    };

                }


            }

            if (Type == "Contact")
            {
                foreach (var item in objcompany.CompanyList)
                {
                    if (item.CompanyContactList.Count > 0)
                    {
                        if (item.CompanyContactList.Any(x => x.MobileNumber.Contains(Query) || x.PhoneNumber.Contains(Query)))
                        {
                            Result.CompanyList.Add(item);
                        };
                    }


                }
            }




            if (Type == "IsActive")
            {
                Query = Query.ToUpper();
                foreach (var item in objcompany.CompanyList)
                {
                    if (Query == "YES" && item.IsActive == true)
                    {
                        Result.CompanyList.Add(item);
                    }
                    if (Query == "NO" && item.IsActive == false)
                    {
                        Result.CompanyList.Add(item);
                    }


                }
            }


            if (Type == "TransferredFrom")
            {
                Query = Query.ToUpper();
                foreach (var item in objcompany.CompanyList)
                {
                    if (item.TransferredFrom.ToUpper().Contains(Query))
                    {
                        Result.CompanyList.Add(item);
                    };

                }
            }

            if (Type == "ResearchSource")
            {
                Query = Query.ToUpper();
                foreach (var item in objcompany.CompanyList)
                {
                    if (item.ResearchSource.ToUpper().Contains(Query))
                    {
                        Result.CompanyList.Add(item);
                    };

                }
            }
            if (Type == "SummerTraining")
            {
                Query = Query.ToUpper();
                foreach (var item in objcompany.CompanyList)
                {
                    if (item.SummerTraining.ToUpper().Contains(Query))
                    {
                        Result.CompanyList.Add(item);
                    };

                }
            }


            if (Type == "EventTypeId")
            {

                foreach (var item in objcompany.CompanyList)
                {
                    if (item.CompanyEventHistory.Any(x => x.EventTypeId == Convert.ToInt32(Query)))
                    {
                        Result.CompanyList.Add(item);
                    };

                }
            }


            if (Type == "EventStatus")
            {

                foreach (var item in objcompany.CompanyList)
                {
                    if (item.CompanyEventHistory.Any(x => x.EventTypeId != 7 && x.Status == Convert.ToBoolean(Query)))
                    {
                        Result.CompanyList.Add(item);
                    };

                }
            }



            if (Type == "VisitDetails")
            {
                Query = Query.ToUpper();
                foreach (var item in objcompany.CompanyList)
                {
                    if (item.CompanyEventHistory.Any(x => x.EventTypeId == 7 && x.Description.ToUpper().Contains(Query)))
                    {
                        Result.CompanyList.Add(item);
                    };

                }
            }


            if (Type == "VisitStatus")
            {

                foreach (var item in objcompany.CompanyList)
                {
                    if (item.CompanyEventHistory.Any(x => x.EventTypeId == 7 && x.Status == Convert.ToBoolean(Query)))
                    {
                        Result.CompanyList.Add(item);
                    };

                }
            }

            if (Type == "FollowUpDateFromAndTo")
            {

                foreach (var item in objcompany.CompanyList)
                {
                    if (item.CallNoteList.Count() > 0 && item.CallNoteList.Where(x => x.Type != 6 && x.Status == false && x.ActivityDate.Date >= ParseDate(paramArray[0]).Date && x.ActivityDate.Date <= ParseDate(paramArray[1]).Date).Count() > 0)
                    {
                        Result.CompanyList.Add(item);
                    };

                }
            }

            if (Type == "FollowUpDateFrom")
            {

                foreach (var item in objcompany.CompanyList)
                {
                    if (item.CallNoteList.Count() > 0 && item.CallNoteList.Where(x => x.Type != 6 && x.Status == true && x.ActivityDate.Date >= ParseDate(Query).Date).Count() > 0)
                    {
                        Result.CompanyList.Add(item);
                    };

                }
            }
            if (Type == "FollowUpDateTo")
            {

                foreach (var item in Result.CompanyList)
                {
                    if (item.CallNoteList.Count() > 0 && item.CallNoteList.Where(x => x.Type != 6 && x.Status == true && x.ActivityDate.Date <= ParseDate(Query).Date).Count() > 0)
                    {
                        Result.CompanyList.Add(item);
                    };

                }
            }
            if (Type == "CallDone")
            {

                foreach (var item in objcompany.CompanyList)
                {

                    if (item.CallNoteList.Any(x => x.CreatedOn.ToString("MM-dd-yyyy") == Query && x.Type != 6))
                    {
                        Result.CompanyList.Add(item);
                    };

                }
            }

            if (Type == "CallCompleted")
            {

                foreach (var item in objcompany.CompanyList)
                {

                    if (item.CallNoteList.Any(x => x.ActivityDate.ToString("MM-dd-yyyy") == Query && x.Status == true && x.Type != 6))
                    {
                        Result.CompanyList.Add(item);
                    };

                }
            }

            if (Type == "Year")
            {

                foreach (var item in objcompany.CompanyList)
                {
                    if (item.JobDescriptionList.Any(x => x.Year == Query))
                    {
                        Result.CompanyList.Add(item);
                    };

                }
            }

            if (Type == "Sector")
            {
                Query = Query.ToUpper();

                foreach (var item in objcompany.CompanyList)
                {
                    if (item.Sector.ToUpper() == Query)
                    {
                        Result.CompanyList.Add(item);
                    };

                }
            }


            if (Type == "Stream")
            {

                foreach (var item in objcompany.CompanyList)
                {
                    if (item.CompanyStreamList.Any(x => x.StreamId == Query))
                    {
                        Result.CompanyList.Add(item);
                    };

                }
            }


            if (Type == "Color")
            {
                Query = Query.ToUpper();
                foreach (var item in objcompany.CompanyList)
                {

                    if (item.ColorCode.ToUpper() == Query)
                    {
                        Result.CompanyList.Add(item);
                    };

                }
            }

            if (Type == "College")
            {

                foreach (var item in objcompany.CompanyList)
                {
                    if (item.PastHiringList.Any(x => x.CollegeCode.ToLower() == Query.ToLower()))
                    {
                        Result.CompanyList.Add(item);
                    };

                }
            }

            if (Type == "Package")
            {

                foreach (var item in objcompany.CompanyList)
                {
                    if (item.CompanyStreamList.Any(x => x.PayPackageID == Query))
                    {
                        Result.CompanyList.Add(item);
                    };

                }
            }

            if (Type == "SubLocation")
            {
                Query = Query.ToUpper();

                foreach (var item in objcompany.CompanyList)
                {
                    if (item.SubLocation.ToUpper().Contains(Query))
                    {
                        Result.CompanyList.Add(item);
                    }
                    if (item.CompanyAddressList.Any(x => x.SubLocation.ToUpper() == Query))
                    {
                        Result.CompanyList.Add(item);
                    };



                }
            }
            if (Type == "CityId")
            {
                Query = Query.ToUpper();

                foreach (var item in objcompany.CompanyList)
                {
                    if (item.City == Query)
                    {
                        Result.CompanyList.Add(item);
                    }
                    if (item.CompanyAddressList.Any(x => x.City.ToUpper() == Query))
                    {
                        Result.CompanyList.Add(item);
                    };



                }
            }



            if (Type == "State" || Type == "City" || Type == "Pincode")
            {
                Query = Query.ToUpper();

                foreach (var item in objcompany.CompanyList)
                {
                    if (item.SubLocation.ToUpper().Contains(Query) || item.Address1.ToUpper().Contains(Query) || item.Address2.ToUpper().Contains(Query) || item.City.ToUpper().Contains(Query))
                    {
                        Result.CompanyList.Add(item);
                    };

                }
            }

            if (Type == "AcceptGift")
            {
                Query = Query.ToUpper();

                foreach (var item in objcompany.CompanyList)
                {
                    if (item.Address1.ToUpper().Contains(Query))
                    {
                        Result.CompanyList.Add(item);
                    };

                }
            }



            Result.CompanyList = Result.CompanyList.Distinct().ToList();
            return Result;
        }



        public ActionResult AddCourse()
        {
            Course model = new Course();
            return View("AddCourse", model);
        }

        public ActionResult EditCourse(int id)
        {
            Course model = new Course();
            List<Course> list = DataMapper.MapCourseData(SPWrapper.GetCourseList());
            model = list.Find(x => x.Id == id);
            return View("EditCourse", model);
        }
        public ActionResult CourseList()
        {
            List<Course> model = DataMapper.MapCourseData(SPWrapper.GetCourseList());
            return View("CourseList", model);
        }
        public ActionResult SaveCourse(Course model)
        {
            model.UpdatedOn = DateTime.Now;
            model.CreatedOn = DateTime.Now;
            model.CreatedBy = User.Identity.GetUserId();
            model.UpdatedBy = User.Identity.GetUserId();
            SPWrapper.SaveCourse(model);
            return RedirectToAction("CourseList", model);
        }
        public ActionResult StreamList()
        {
            List<Stream> model = new List<Stream>();
            model = DataMapper.MapStreamData(SPWrapper.GetStreamList());
            return View("StreamList", model);
        }
        public ActionResult AddStream()
        {
            Stream model = new Stream();
            List<Course> Coursemodel = new List<Course>();
            // model.CourseDrp= new SelectList(Coursemodel = DataMapper.MapCourseData(SPWrapper.GetCourseList()));
            model.CourseDrp = DataMapper.MapCourseData(SPWrapper.GetCourseList());
            return View("AddStream", model);
        }
        public ActionResult EditStream(int id)
        {
            Stream model = new Stream();
            List<Course> Coursemodel = new List<Course>();
            var listmodel = DataMapper.MapStreamData(SPWrapper.GetStreamList());
            model = listmodel.Find(x => x.Id == id);
            model.CourseDrp = DataMapper.MapCourseData(SPWrapper.GetCourseList());
            return View("EditStream", model);

        }
        public ActionResult SaveStream(Stream model)
        {
            model.UpdatedOn = DateTime.Now;
            model.CreatedOn = DateTime.Now;
            model.CreatedBy = User.Identity.GetUserId();
            model.UpdatedBy = User.Identity.GetUserId();
            SPWrapper.SaveStream(model);

            model.CourseDrp = DataMapper.MapCourseData(SPWrapper.GetCourseList());

            return RedirectToAction("StreamList", model);
        }


        public ActionResult GetStream(int Id)
        {

            var list = DataMapper.MapCourseData(SPWrapper.GetCourseList());
            var model = list.Find(x => x.Id == Id);
            return Json(model, JsonRequestBehavior.AllowGet);

        }

        public ActionResult getCallNote(int Id)
        {
            List<CallNote> objCallNotes = new List<CallNote>();
            CallNote objCallNote = new CallNote();
            objCallNotes = DataMapper.MapCallNotesData(SPWrapper.GetCallNote());
            objCallNote = objCallNotes.Find(x => x.Id == Id);
            objCallNote.t_ActivityDate = objCallNote.ActivityDate.ToString("dd-MM-yyyy");
            objCallNote.CallId = objCallNote.Id;
            return Json(objCallNote, JsonRequestBehavior.AllowGet);
        }

        protected bool CheckDate(String date)

        {

            try

            {

                DateTime dt = DateTime.Parse(date);

                return true;

            }
            catch

            {

                return false;

            }

        }

        [HttpPost]
        public ActionResult AddNotes(CallNote objCallNote)
        {
            if (objCallNote.ActivityDate == DateTime.MinValue)
            {
                objCallNote.ActivityDate = DateTime.Now;
            }
            if (objCallNote.Type == 6)
            {
                objCallNote.RemindMe = true;
            }
            objCallNote.Id = objCallNote.CallId;
            objCallNote.CreatedOn = DateTime.Now;
            objCallNote.UpdatedOn = DateTime.Now;
            objCallNote.UserID = User.Identity.GetUserId();
            SPWrapper.SaveCallNote(objCallNote);
            return RedirectToAction("CompanyList");
        }




        [HttpPost]
        public ActionResult AddContact(CompanyContact objContact)
        {
            objContact.CreatedOn = DateTime.Now;
            objContact.UpdatedOn = DateTime.Now;
            objContact.CreatedBy = User.Identity.GetUserId();
            objContact.UpdatedBy = User.Identity.GetUserId();
            SPWrapper.SaveContact(objContact);
            return RedirectToAction("CompanyList");
        }

        public ActionResult getContact(int Id)
        {
            List<CompanyContact> objCompanyContacts = new List<CompanyContact>();
            CompanyContact objCompanyContact = new CompanyContact();
            objCompanyContacts = DataMapper.MapCompanyContact(SPWrapper.GetCompanyContacts());
            objCompanyContact = objCompanyContacts.Find(x => x.ContactID == Id);
            return Json(objCompanyContact, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddJD(JobDescription objJobDescription)
        {
            //objJobDescription.Type = objCallNote.IsFollowUp == true ? 0 : 1;
            objJobDescription.Year = objJobDescription.jdYear;
            objJobDescription.CreatedOn = DateTime.Now;
            objJobDescription.UpdatedOn = DateTime.Now;
            objJobDescription.CreatedBy = User.Identity.GetUserId();
            objJobDescription.UpdatedBy = User.Identity.GetUserId();
            objJobDescription.IsActive = false;
            objJobDescription.IsDeleted = false;
            SPWrapper.SavejobDescription(objJobDescription);
            return RedirectToAction("CompanyList");
        }
        public JsonResult EditJD(int Id)
        {
            List<JobDescription> lobjJobDescriptionList = new List<JobDescription>();
            lobjJobDescriptionList = DataMapper.MapJobDescription(SPWrapper.GetJobDescription());
            JobDescription objCompany = new JobDescription();
            objCompany = lobjJobDescriptionList.Find(x => x.Id == Id);
            return Json(objCompany, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EditNotes(CallNote objCallNote)
        {
            objCallNote.Type = objCallNote.IsFollowUp == true ? 0 : 1;
            objCallNote.UpdatedOn = DateTime.Now;
            objCallNote.Description = objCallNote.Description;
            return View();
        }

        public JsonResult EditgetCompanyStreamdata(int? id)
        {
            List<CompanyStream> model = new List<CompanyStream>();
            CompanyStream Objmodel = new CompanyStream();
            model = DataMapper.MapCompanyStream(SPWrapper.GetCompanyStream());
            Objmodel = model.Where(m => m.Id == id).FirstOrDefault();
            //JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            //string result = javaScriptSerializer.Serialize(model);
            return Json(Objmodel, JsonRequestBehavior.AllowGet);

            //objCallNote.Type = objCallNote.IsFollowUp == true ? 0 : 1;
            //objCallNote.UpdatedOn = DateTime.Now;
            //objCallNote.Description = objCallNote.Description;
            //var khj = "";
            //return Json(khj,JsonRequestBehavior.AllowGet);
        }


        public ActionResult AddEmployee()
        {

            return View();
        }

        public ActionResult Create()
        {
            Company objcompany = new Company();
            objcompany = GetCommonData(objcompany);
            return PartialView(objcompany);
        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult Create(Company objCompany)
        {
            Company objCompanynew = new Company();
            Company objcompany = new Company();
            List<Company> objCompanyList = new List<Company>();
            objCompany.CreatedOn = DateTime.Now;
            objCompany.CreatedBy = User.Identity.GetUserId();
            objCompany.UpdatedOn = DateTime.Now;
            int CompanyId = SPWrapper.SaveCompany(objCompany);
            if (CompanyId == -1)
            {
                objCompanynew = GetCommonData(objCompanynew);
                ViewBag.Message = "Company with same name already exits!";
                return Json(objCompanynew, JsonRequestBehavior.AllowGet);
            }
            objCompanyList = DataMapper.MapCompanyDataForEdit(SPWrapper.GetCompanyById(CompanyId));
            objCompanynew = objCompanyList[0];
            objCompanynew = GetCommonData(objCompanynew);
            // objCompanynew.CompanyEventHistory = DataMapper.MapCompanyHistory(SPWrapper.GetCompanyHistoryById(CompanyId)).ToList().Where(m => m.CompanyID == CompanyId).ToList();
            return View(objCompanynew);
        }


        public ActionResult Edit(int Id)
        {

            List<Company> objCompanyList = new List<Company>();
            objCompanyList = DataMapper.MapCompanyDataForEdit(SPWrapper.GetCompanyById(Id));
            Company objCompany = new Company();
            objCompany = objCompanyList.Find(x => x.Id == Id);
            //objCompany.PreviousNotesList = objCompany.PreviousNotesList.Where(x => x.Id == Id).ToList();
            // objCompany.CompanyEventHistory = DataMapper.MapCompanyHistory(SPWrapper.GetCompanyHistoryById(Id)).ToList().ToList();
            objCompany = GetCommonData(objCompany);
            return PartialView(objCompany);
            // return View("Edit",objCompany);

        }

        [OutputCache(Duration = 3600)]
        public Company GetCommonData(Company objCompany)
        {
            objCompany.MyStream = DataMapper.MapStreamData(SPWrapper.GetStreamList());
            objCompany.ddlSector = new SelectList(DataMapper.MapSectorMaster(SPWrapper.GetSectorMasters()).ToList(), "Name", "Name");
            objCompany.ddlCity = new SelectList(DataMapper.MapCity(SPWrapper.GetCity()).ToList(), "City", "City");
            objCompany.ddlCompany= new SelectList(DataMapper.MapCompany(SPWrapper.GetCompanyList()).ToList(), "Companies", "Companies");
            objCompany.ddlSubLocation = new SelectList(DataMapper.MapSubLocation(SPWrapper.GetSublocation()).ToList(), "SubLocation", "SubLocation");
            objCompany.ddlcolor = new SelectList(DataMapper.MapColorMaster(SPWrapper.GetColorMasters()).ToList(), "Name", "Name");
            objCompany.CourseDrp = DataMapper.MapCourseData(SPWrapper.GetCourseList());
            objCompany.objCollegeMasterList = new SelectList(DataMapper.MapCollegeMaster(SPWrapper.GetCollegeMasters()).ToList(), "Name", "Name");
            objCompany.objCollegeEventList = new SelectList(DataMapper.MapCompanyEvent(SPWrapper.GetCompanyEvent()).ToList(), "EventId", "EventType");
            objCompany.ddlthirdparty = new SelectList(DataMapper.MapCommonMaster(SPWrapper.GetThirdPartyMasters()).ToList(), "Name", "Name");
            return objCompany;
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
        public ActionResult AddCompanyStream(CompanyStream objCompanyStream)
        {

            // objCompanyList = DataMapper.MapCompanyData(SPWrapper.GetCompanyList());
            objCompanyStream.CreatedOn = DateTime.Now;
            objCompanyStream.StreamId = "";
            objCompanyStream.CoursesId = "";
            objCompanyStream.UpdatedOn = DateTime.Now;
            objCompanyStream.CreatedBy = User.Identity.GetUserId();
            objCompanyStream.UpdatedBy = User.Identity.GetUserId();
            objCompanyStream.IsDeleted = false;
            objCompanyStream.t_JsonString = GetCompanyStreamXml(objCompanyStream.t_JsonString);
            SPWrapper.CompanyStream(objCompanyStream);
            return RedirectToAction("CompanyList");
        }

        public JsonResult GetStreamFromCourse(string CourseId)
        {
            List<Stream> model = new List<Stream>();
            model = DataMapper.MapStreamData(SPWrapper.GetStreamList());
            model = model.Where(m => m.CourseId == CourseId).ToList();
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }



        public JsonResult GetSublocation(String City)
        {
            List<CityMaster> city = new List<CityMaster>();
            city = DataMapper.MapCity(SPWrapper.GetCity());
            List<Sublocation> model = new List<Sublocation>();
            model = DataMapper.MapSubLocation(SPWrapper.GetSublocation());
            if (City != null)
            {

                int CityID = city.Where(c => c.City == City).FirstOrDefault().Id;
                model = model.Where(m => m.CityId == CityID).ToList();
            }
            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            string result = javaScriptSerializer.Serialize(model);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(Company objCompany, string Submit)
        {
            if (Submit == "Save")
            {
                if (objCompany.IsActive == false)
                {
                    objCompany.ColorCode = "Orange";
                }
                objCompany.UpdatedBy = User.Identity.GetUserId();
                objCompany.UpdatedOn = DateTime.Now;
            }
            if (Submit == "Delete")
            {
                objCompany.IsDeleted = true;
                objCompany.UpdatedBy = User.Identity.GetUserId();
                objCompany.UpdatedOn = DateTime.Now;
            }
            if (Submit == "Restore")
            {
                objCompany.IsDeleted = false;
                objCompany.UpdatedBy = User.Identity.GetUserId();
                objCompany.ColorCode = "";
                objCompany.UpdatedOn = DateTime.Now;
            }
            SPWrapper.SaveCompany(objCompany);
            return RedirectToAction("CompanyList");
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Delete(Company objCompany)
        {
            objCompany.IsDeleted = true;
            objCompany.UpdatedBy = User.Identity.GetUserId();
            objCompany.UpdatedOn = DateTime.Now;
            SPWrapper.SaveCompany(objCompany);
            return RedirectToAction("CompanyList");
        }



        public ActionResult ColorMaster()
        {
            List<Master> objMasterList = DataMapper.MapColorMaster(SPWrapper.GetColorMasters());

            return View(objMasterList);
        }

        [HttpPost]
        public ActionResult ColorMaster(Master objMaster)
        {

            SPWrapper.SaveColor(objMaster);
            List<Master> objMasterList = DataMapper.MapColorMaster(SPWrapper.GetColorMasters());

            return View(objMasterList);
        }


        [HttpPost]
        public ActionResult SectorMaster(Master objMaster)
        {

            SPWrapper.SaveSector(objMaster);
            List<Master> objMasterList = DataMapper.MapSectorMaster(SPWrapper.GetSectorMasters());

            return View(objMasterList);
        }


        [HttpPost]
        public ActionResult CollegeMaster(Master objMaster)
        {

            SPWrapper.SaveCollege(objMaster);
            List<Master> objMasterList = DataMapper.MapCollegeMaster(SPWrapper.GetCollegeMasters());

            return View(objMasterList);
        }

        public ActionResult getColorMaster(int Id)
        {
            Master objmaster = new Master();
            List<Master> objMasterList = new List<Master>();
            objMasterList = DataMapper.MapColorMaster(SPWrapper.GetColorMasters());
            objmaster = objMasterList.Find(x => x.Id == Id);
            return Json(objmaster, JsonRequestBehavior.AllowGet);
        }




        public ActionResult SectorMaster()
        {

            List<Master> objMasterList = DataMapper.MapSectorMaster(SPWrapper.GetSectorMasters());

            return View(objMasterList);
        }


        public ActionResult getSectorMaster(int Id)
        {
            Master objmaster = new Master();
            List<Master> objMasterList = DataMapper.MapSectorMaster(SPWrapper.GetSectorMasters());
            objmaster = objMasterList.Find(x => x.Id == Id);
            return Json(objmaster, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CollegeMaster()
        {
            List<Master> objMasterList = DataMapper.MapCollegeMaster(SPWrapper.GetCollegeMasters());

            return View(objMasterList);
        }

        public ActionResult getCollegeMaster(int Id)
        {
            Master objmaster = new Master();
            List<Master> objMasterList = new List<Master>();
            objMasterList = DataMapper.MapCollegeMaster(SPWrapper.GetCollegeMasters());
            objmaster = objMasterList.Find(x => x.Id == Id);
            return Json(objmaster, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddPastRecruitments(PastRecruitment objJobDescription)
        {
            //objJobDescription.Type = objCallNote.IsFollowUp == true ? 0 : 1;
            objJobDescription.CreatedOn = DateTime.Now;
            objJobDescription.UpdatedOn = DateTime.Now;
            objJobDescription.CreatedBy = User.Identity.GetUserId();
            objJobDescription.UpdatedBy = User.Identity.GetUserId();
            objJobDescription.IsDeleted = false;
            SPWrapper.SavePastRecruitment(objJobDescription);
            return RedirectToAction("CompanyList");
        }
        public JsonResult EditPastRecruitments(int Id)
        {
            List<PastRecruitment> lobjJobDescriptionList = new List<PastRecruitment>();
            lobjJobDescriptionList = DataMapper.MapPastRecruitment(SPWrapper.GetPastRecruitment());
            PastRecruitment objCompany = new PastRecruitment();
            objCompany = lobjJobDescriptionList.Find(x => x.Id == Id);
            return Json(objCompany, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddHired(PastHiring objJobDescription, string[] MultiHiringyear)
        {
            //objJobDescription.Type = objCallNote.IsFollowUp == true ? 0 : 1;
            //  objJobDescription.CollegeCode = Convert.ToString(objJobDescription.CollegeId);
            objJobDescription.CreatedOn = DateTime.Now;
            objJobDescription.UpdatedOn = DateTime.Now;
            objJobDescription.Hiringyear = string.Join(",", MultiHiringyear);
            objJobDescription.CreatedBy = User.Identity.GetUserId();
            objJobDescription.UpdatedBy = User.Identity.GetUserId();
            objJobDescription.IsDeleted = false;
            SPWrapper.SavePastHiring(objJobDescription);
            return RedirectToAction("CompanyList");
        }
        public JsonResult EditHired(int Id)
        {
            List<PastHiring> lobjJobDescriptionList = new List<PastHiring>();
            lobjJobDescriptionList = DataMapper.MapPastHiring(SPWrapper.GetPastHiring());
            PastHiring objCompany = new PastHiring();
            objCompany = lobjJobDescriptionList.Find(x => x.Id == Id);

            return Json(objCompany, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddCompanyStatus(CompanyStatus objJobDescription)
        {
            //objJobDescription.Type = objCallNote.IsFollowUp == true ? 0 : 1;
            objJobDescription.CreatedOn = DateTime.Now;
            objJobDescription.UpdatedOn = DateTime.Now;
            objJobDescription.CreatedBy = User.Identity.GetUserId();
            objJobDescription.UpdatedBy = User.Identity.GetUserId();
            objJobDescription.IsDeleted = false;
            SPWrapper.SaveCompanyStatus(objJobDescription);
            return RedirectToAction("CompanyList");
        }
        public JsonResult EditCompanyStatus(int Id)
        {
            List<CompanyStatus> lobjJobDescriptionList = new List<CompanyStatus>();
            lobjJobDescriptionList = DataMapper.MapCompanystatus(SPWrapper.GetCompanystatus());
            CompanyStatus objCompany = new CompanyStatus();
            objCompany = lobjJobDescriptionList.Find(x => x.Id == Id);
            return Json(objCompany, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddCompanyEvent(EventHistory objEventHistory)
        {
            //objEventHistory.Status = objEventHistory.Status == true ? 0 : 1;
            objEventHistory.Visitor = string.IsNullOrEmpty(objEventHistory.Visitor) ? "" : objEventHistory.Visitor;
            // objCompanyList = DataMapper.MapCompanyData(SPWrapper.GetCompanyList());
            objEventHistory.CreatedOn = DateTime.Now;
            objEventHistory.UpdatedOn = DateTime.Now;
            objEventHistory.CreatedBy = User.Identity.GetUserId();
            objEventHistory.UpdatedBy = User.Identity.GetUserId();
            objEventHistory.IsDeleted = false;

            SPWrapper.CompanyEvent(objEventHistory);
            return RedirectToAction("CompanyList");
        }
        public JsonResult EditCompanyEvent(int Id)
        {
            List<EventHistory> lobjJobDescriptionList = new List<EventHistory>();
            lobjJobDescriptionList = DataMapper.MapCompanyHistory(SPWrapper.GetCompanyHistory());


            EventHistory objEventhistory = new EventHistory();
            objEventhistory = lobjJobDescriptionList.Find(x => x.Id == Id);
            objEventhistory.t_EventDate = objEventhistory.EventDate.HasValue ? objEventhistory.EventDate.Value.ToString("yyyy-MM-dd") : "";
            return Json(objEventhistory, JsonRequestBehavior.AllowGet);
        }

        public JsonResult EditCompanyAddress(int Id)
        {
            List<CompanyAddress> lobjCompanyAddressList = new List<CompanyAddress>();
            lobjCompanyAddressList = DataMapper.MapCompanyAddress(SPWrapper.GetCompanyAddress());

            CompanyAddress objCompanyAdd = new CompanyAddress();
            objCompanyAdd = lobjCompanyAddressList.Find(x => x.Id == Id);
            return Json(objCompanyAdd, JsonRequestBehavior.AllowGet);
        }


        public ActionResult SaveCompanyAddress(CompanyAddress model)
        {
            SPWrapper.SaveCompanyAddress(model);
            return RedirectToAction("CompanyList", model);
        }


        public JsonResult GetDailyCalls()
        {
            Company objcompany = new Company();
            objcompany.CompanyList = GetCompanies();


            var Calldone = objcompany.CompanyList.Sum(z => z.CallNoteList.Where(x => x.ActivityDate.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd") && x.Status == true && x.Type != 6).Count());
            //var Callpending = objcompany.CompanyList.Sum(x => x.CallNoteList.Where(c => c.ActivityDate.ToString("yyyy-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd") && c.Status == false && c.Type != 6).Count());


            //var Calldone = objcompany.CompanyList.FindAll(z => z.CallNoteList.Any(x => x.CreatedOn.ToString("yyyy-MM-dd") == DateTime.Now.Date.ToString("yyyy-MM-dd")&&x.Type!=6)).Count();
            var Callpending = objcompany.CompanyList.FindAll(z => z.CallNoteList.Where(c => c.ActivityDate.Date > DateTime.Now.Date && c.Type != 6).Count() == 0).Count();
            //var Calltoday = objcompany.CompanyList.FindAll(z => z.CallNoteList.Any(x => x.ActivityDate.ToStrin("yyyy-MM-dd") == DateTime.Now.Date.ToString("yyyy-MM-dd"))).Count();
            return Json(new { callDone = Calldone, callPending = Callpending }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult GetMonthlyCalls()
        {
            Company objcompany = new Company();
            objcompany.CompanyList = GetCompanies();

            var Calldone = objcompany.CompanyList.FindAll(z => z.CallNoteList.Any(x => x.CreatedOn.ToString("yyyy-MM") == DateTime.Now.Date.ToString("yyyy-MM"))).Count();
            var Callpending = objcompany.CompanyList.FindAll(z => z.CallNoteList.Any(x => x.CreatedOn.ToString("yyyy-MM") == DateTime.Now.Date.ToString("yyyy-MM") && x.ActivityDate < DateTime.Now.ToLocalTime())).Count();

            return Json(new { callDone = Calldone, callPending = Callpending }, JsonRequestBehavior.AllowGet);

        }




        public JsonResult GetPlannerCalls(DateTime Start, DateTime End)
        {
            Company objcompany = new Company();
            objcompany.CompanyList = GetCompanies();
            List<Planner> lstPlanner = new List<Planner>();
            while (Start < End)
            {

                var Calldone = objcompany.CompanyList.Sum(z => z.CallNoteList.Where(x => x.ActivityDate.ToString("yyyy-MM-dd") == Start.ToString("yyyy-MM-dd") && x.Status == true && x.Type != 6).Count());
                var Callpending = objcompany.CompanyList.Sum(x => x.CallNoteList.Where(c => c.ActivityDate.Date == Start.Date && c.Status == false && c.Type != 6).Count());
                Planner obj1 = new Planner();
                obj1.title = string.Format("Done:{0}", Calldone);
                obj1.start = Start.ToString("yyyy-MM-ddTHH:mm:ss");
                //obj1.color = "green";
                lstPlanner.Add(obj1);



                Planner obj2 = new Planner();
                obj2.title = string.Format("Pending:{0}", Callpending);
                obj2.start = Start.ToString("yyyy-MM-ddTHH:mm:ss");
                //obj2.color = "red";
                lstPlanner.Add(obj2);




                Start = Start.AddDays(1);
            }

            return Json(lstPlanner, JsonRequestBehavior.AllowGet);

        }
        //backup 2 feb 2021
        //public JsonResult GetPlannerCalls(DateTime Start, DateTime End)
        //{
        //    Company objcompany = new Company();
        //    objcompany.CompanyList = GetCompanies();
        //    List<Planner> lstPlanner = new List<Planner>();
        //    while (Start < End)
        //    {

        //        var Calldone = objcompany.CompanyList.FindAll(z => z.CallNoteList.Any(x => x.CreatedOn.ToString("yyyy-MM-dd") == Start.ToString("yyyy-MM-dd") && x.Type!=6)).Count();
        //        var Callpending = objcompany.CompanyList.FindAll(z => z.CallNoteList.Where(c => c.ActivityDate.Date == Start.Date && c.Type != 6).Count() > 0).Count();

        //        if (DateTime.Now.ToString("yyyy-MM-dd") == Start.ToString("yyyy-MM-dd"))
        //        {
        //            Calldone = objcompany.CompanyList.FindAll(z => z.CallNoteList.Any(x => x.CreatedOn.ToString("yyyy-MM-dd") == DateTime.Now.Date.ToString("yyyy-MM-dd") && x.Type != 6)).Count();
        //            var CompanyList = FilterCompanyByUser(DataMapper.MapCompanyMaster(SPWrapper.GetCompanyByQuery("Today")));
        //            Callpending = CompanyList.Distinct().ToList().Count();                   
        //        }

        //        Planner obj1 = new Planner();
        //        obj1.title = string.Format("Done:{0}", Calldone);
        //        obj1.start = Start.ToString("yyyy-MM-ddTHH:mm:ss");
        //        //obj1.color = "green";
        //        lstPlanner.Add(obj1);



        //        Planner obj2 = new Planner();
        //        obj2.title = string.Format("Pending:{0}", Callpending);
        //        obj2.start = Start.ToString("yyyy-MM-ddTHH:mm:ss");
        //        //obj2.color = "red";
        //        lstPlanner.Add(obj2);




        //        Start = Start.AddDays(1);
        //    }

        //    return Json(lstPlanner, JsonRequestBehavior.AllowGet);

        //}
        public class Planner
        {

            public string title { get; set; }
            public string start { get; set; }
            public string color { get; set; }
        }
        public ActionResult DeleteCommon(int Id, string Tablename, string Field)
        {
            if (Tablename == "CompanyVisit")
            {
                SPWrapper.DeleteCommon(Id, "EventHistory", Field);

            }
            else
            {

                SPWrapper.DeleteCommon(Id, Tablename, Field);
            }
            return RedirectToAction("CompanyList");
        }

        public ActionResult UpdateStatus(int Id, string Status)
        {
            SPWrapper.UpdateStatus(Id, Status);
            return RedirectToAction("CompanyList");
        }

        public ActionResult RemindMe(int Id, string Status)
        {
            SPWrapper.RemindMe(Id, Status);
            return RedirectToAction("CompanyList");
        }





        public ActionResult CityList()
        {
            List<CityMaster> objCityList = new List<CityMaster>();

            objCityList = DataMapper.MapCity(SPWrapper.GetCity());
            return View(objCityList);
        }

        public ActionResult SubLocationList()
        {
            List<Sublocation> objSublocationList = new List<Sublocation>();
            objSublocationList = DataMapper.MapSubLocation(SPWrapper.GetSublocation());
            return View(objSublocationList);
        }

        public ActionResult SaveCity(CityMaster objCity)
        {
            SPWrapper.SaveCity(objCity);
            return RedirectToAction("CityList");


        }

        public ActionResult SaveSublocation(Sublocation objsublocation)

        {
            SPWrapper.SaveSublocation(objsublocation);
            return RedirectToAction("SubLocationList");

        }


        public ActionResult getCity(int Id)
        {
            List<CityMaster> objCityMasterList = new List<CityMaster>();
            objCityMasterList = DataMapper.MapCity(SPWrapper.GetCity());
            CityMaster objcitymaster = new CityMaster();
            objcitymaster = objCityMasterList.Find(x => x.Id == Id);
            return Json(objcitymaster, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getSublocationForEdit(int Id)


        {
            List<Sublocation> objSublocationList = new List<Sublocation>();
            objSublocationList = DataMapper.MapSubLocation(SPWrapper.GetSublocation());
            Sublocation objsublocation = new Sublocation();
            objsublocation = objSublocationList.Find(x => x.Id == Id);
            return Json(objsublocation, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult ExtraCallNotes()
        {
            ViewBag.CompanyList = GetCompanyMaster();
            return View();
        }

        public ActionResult ExtraCallNotes(int? Id = 0)
        {
            List<ExtraCallNotes> objExtraCallNotesList = new List<ExtraCallNotes>();
            ViewBag.CompanyList = GetCompanyMaster();
            objExtraCallNotesList = DataMapper.MapExtraCallNotes(SPWrapper.GetExtraCallNotesList(Id.Value));
            return View(objExtraCallNotesList);
        }

        public ActionResult GetReminders()
        {
            var Username = User.Identity.GetUserName();
            List<Company> objCompanyList = new List<Company>();
            objCompanyList = GetCompanyMaster();
            List<CallNote> objCallNotesList = new List<CallNote>();
            objCallNotesList = DataMapper.MapCallNotesData(SPWrapper.GetCallNoteForReminder());
            List<Reminder> objReminderList = new List<Reminder>();
            foreach (var item in objCallNotesList)
            {

                if (objCompanyList.Where(x => x.Id == item.CompanyID).Count() > 0)
                {

                    Reminder objRem = new Reminder
                    {
                        CompanyName = objCompanyList.Where(x => x.Id == item.CompanyID).FirstOrDefault()?.CompanyName,
                        Type = "C",
                        Title = "Call Reminder",
                        Id = item.Id,
                    };
                    objReminderList.Add(objRem);
                }

            }
            List<CompanyContact> objCompanyContactList = new List<CompanyContact>();
            objCompanyContactList = DataMapper.MapCompanyContact(SPWrapper.GetCompanyContactsForReminder());
            foreach (var item in objCompanyContactList)
            {

                if (objCompanyList.Where(x => x.Id == item.CompanyID).Count() > 0)
                {
                    Reminder objRem = new Reminder
                    {
                        CompanyName = objCompanyList.Where(x => x.Id == item.CompanyID).FirstOrDefault()?.CompanyName,
                        Type = "BA",
                        Title = "Birthday/Anniversary",
                        Id = item.ContactID,
                    };
                    objReminderList.Add(objRem);
                }


            }
            return Json(objReminderList, JsonRequestBehavior.AllowGet);
        }




        public class Reminder
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Type { get; set; }
            public bool RemindMe { get; set; }
            public string CompanyName { get; set; }
            public string Key { get; set; }
        }

        //public void ExportData()
        //{



        //    IWorkbook workbook;

        //    if (extension == "xlsx")
        //    {
        //        workbook = new XSSFWorkbook();
        //    }
        //    else if (extension == "xls")
        //    {
        //        workbook = new HSSFWorkbook();
        //    }
        //    else
        //    {
        //        throw new Exception("This format is not supported");
        //    }

        //    ISheet sheet1 = workbook.CreateSheet("Sheet 1");

        //    //make a header row
        //    IRow row1 = sheet1.CreateRow(0);

        //    for (int j = 0; j < dt.Columns.Count; j++)
        //    {

        //        ICell cell = row1.CreateCell(j);
        //        String columnName = dt.Columns[j].ToString();
        //        cell.SetCellValue(columnName);
        //    }

        //    //loops through data
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        IRow row = sheet1.CreateRow(i + 1);
        //        for (int j = 0; j < dt.Columns.Count; j++)
        //        {

        //            ICell cell = row.CreateCell(j);
        //            String columnName = dt.Columns[j].ToString();
        //            cell.SetCellValue(dt.Rows[i][columnName].ToString());
        //        }
        //    }

        //    using (var exportData = new MemoryStream())
        //    {
        //        Response.Clear();
        //        workbook.Write(exportData);
        //        if (extension == "xlsx") //xlsx file format
        //        {
        //            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //            Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "ContactNPOI.xlsx"));
        //            Response.BinaryWrite(exportData.ToArray());
        //        }
        //        else if (extension == "xls")  //xls file format
        //        {
        //            Response.ContentType = "application/vnd.ms-excel";
        //            Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", "ContactNPOI.xls"));
        //            Response.BinaryWrite(exportData.GetBuffer());
        //        }
        //        Response.End();
        //    }
        //}

        public void ExportData1()
        {

            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("select Id,CompanyName,AllotedTo from CompanyMaster where IsActive=1 and IsDeleted=0"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (System.Data.DataTable dt = new System.Data.DataTable())
                        {
                            sda.Fill(dt);

                            Application xlApp;
                            Workbook xlWorkBook;
                            Worksheet xlWorkSheet;
                            object misValue = System.Reflection.Missing.Value;

                            xlApp = new Application();
                            xlWorkBook = xlApp.Workbooks.Add(misValue);

                            xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
                            xlWorkBook.Worksheets.Add(dt);

                            Response.Clear();
                            Response.Buffer = true;
                            Response.Charset = "";
                            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                            Response.AddHeader("content-disposition", "attachment;filename=MDF.xlsx");
                            using (System.IO.MemoryStream MyMemoryStream = new System.IO.MemoryStream())
                            {
                                xlWorkBook.SaveAs(MyMemoryStream);
                                MyMemoryStream.WriteTo(Response.OutputStream);
                                Response.Flush();
                                Response.End();
                            }

                        }
                    }
                }
            }
        }


        //}


        public ActionResult ExportData()
        {



            string data = null;
            int i = 0;
            int j = 0;

            Application xlApp;
            Workbook xlWorkBook;
            Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
            xlWorkSheet.Cells[1, 1] = "ID";
            xlWorkSheet.Cells[1, 2] = "CompanyName";
            xlWorkSheet.Cells[1, 3] = "AllotedTo";

            xlWorkSheet.get_Range("A1", "E" + "1").Font.Bold = true;
            xlWorkSheet.get_Range("A1", "E" + "1").Font.Underline = true;
            // xlWorkSheet.get_Range("A1", "E" + "1").Font.Background = "green";
            xlWorkSheet.get_Range("A1", "E" + "1").VerticalAlignment = XlVAlign.xlVAlignCenter;


            DataSet ds = new DataSet();
            ds = SPWrapper.GetCompanyList();

            for (i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                for (j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
                {
                    var asas = ds.Tables[0].Columns[j].ToString();
                    if (asas == "ID")
                    {
                        data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                        xlWorkSheet.Cells[i + 2, j + 1] = data;
                    }
                    if (asas == "CompanyName")
                    {
                        data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                        xlWorkSheet.Cells[i + 2, j + 1] = data;
                    }
                    if (asas == "AllotedTo")
                    {
                        data = ds.Tables[0].Rows[i].ItemArray[j].ToString();
                        xlWorkSheet.Cells[i + 2, 2 + 1] = data;
                    }

                }
            }

            //  xlWorkBook.SaveAs(@"D:\Export\MDF.xls", XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
            return RedirectToAction("Index", "Home");

        }


        //public void ExportData()
        //{

        //    using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["excelconn"].ToString()))
        //    {
        //        con.Open();
        //        SqlCommand cmd = new SqlCommand("select Name,type,data from Excelfiledemo where id=@id", con);
        //        cmd.Parameters.AddWithValue("id", GridView1.SelectedRow.Cells[1].Text);
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        if (dr.Read())
        //        {
        //            Response.Clear();
        //            Response.Buffer = true;
        //            Response.ContentType = dr["type"].ToString();
        //            // to open file prompt Box open or Save file  
        //            Response.AddHeader("content-disposition", "attachment;filename=" + dr["Name"].ToString());
        //            Response.Charset = "";
        //            Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //            Response.BinaryWrite((byte[])dr["data"]);
        //            Response.End();
        //        }
        //    }

        //}

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }


        public DateTime ParseDate(string date)
        {
            var ci = new CultureInfo("en-US");
            //var formats = new[] { "dd-M-yyyy", "d-M-yy", "M-d-yyyy", "dd-MM-yyyy", "MM-dd-yyyy", "M.d.yyyy", "dd.MM.yyyy", "MM.dd.yyyy" }

            var formats = new[] { "dd-M-yyyy", "d-M-yy", "dd-MM-yyyy", "d-M-yyyy", "dd-MM-yyyy hh:mm:ss", "MM-dd-yyyy" }
        .Union(ci.DateTimeFormat.GetAllDateTimePatterns()).ToArray();

            DateTime newdate = DateTime.ParseExact(date, formats, ci, DateTimeStyles.AssumeLocal);
            return newdate;
        }

        public ActionResult AddThirdParty()
        {
            ThirdParty model = new ThirdParty();
            return View("AddThirdParty", model);
        }

        public ActionResult EditThirdParty(int id)
        {
            ThirdParty model = new ThirdParty();
            List<ThirdParty> list = DataMapper.MapThirdPartyData(SPWrapper.GetThirdPartyMasters());
            model = list.Find(x => x.Id == id);
            return View("EditThirdParty", model);
        }
        public ActionResult ThirdPartyList()
        {
            List<ThirdParty> model = DataMapper.MapThirdPartyData(SPWrapper.GetThirdPartyMasters());
            return View("ThirdPartyList", model);
        }
        public ActionResult SaveThirdParty(ThirdParty model)
        {
            model.UpdatedOn = DateTime.Now;
            model.CreatedOn = DateTime.Now;
            model.CreatedBy = User.Identity.GetUserId();
            model.UpdatedBy = User.Identity.GetUserId();
            SPWrapper.SaveThirdParty(model);
            return RedirectToAction("ThirdPartyList", model);
        }

    }

}

