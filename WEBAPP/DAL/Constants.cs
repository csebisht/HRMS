using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEBAPP.DAL
{
    public class DBFields
    {
        //Common
        public static string Id = "Id";
        public static string CreatedOn = "CreatedOn";
        public static string CreatedBy = "CreatedBy";
        public static string UpdatedOn = "UpdatedOn";
        public static string UpdatedBy = "UpdatedBy";
        public static string IsDeleted = "IsDeleted";
        public static string json = "t_json";
        public static string IpAddress = "IpAddress";
        public static string StartDate= "StartDate";
        public static string EndDate = "EndDate";
        public static string Query = "Query";
        public static string start = "Pageno";
        public static string searchvalue = "filter";
        public static string length = "pagesize";
        public static string sortColumn = "sorting";
        public static string sortDirection = "sortorder";
        



        //User

        public static string Email = "Email";
        public static string EmailConfirmed = "EmailConfirmed";
        public static string PasswordHash = "PasswordHash";
        public static string SecurityStamp = "SecurityStamp";
        public static string PhoneNumber = "PhoneNumber";
        public static string UserName = "UserName";
        public static string FirstName = "FirstName";
        public static string LastName = "LastName";
        public static string Address = "Address";

        public static string DOB = "DOB";
        public static string Gender = "Gender";
        public static string IsAdmin = "IsAdmin";

        public static string IsValid = "IsValid";
        public static string OTP = "OTP";
        public static string TwoFactorEnabled = "TwoFactorEnabled";
        public static string Barcode = "Barcode";
        public static string FatherName = "FatherName";
        public static string CompanyId = "CompanyId";
        public static string Designatation = "Designatation";
        public static string UANNumber = "UANNumber";
        public static string ESICNumber = "ESICNumber";
        public static string AdharNumber = "AdharNumber";
        public static string SalaryDate = "SalaryDate";
        public static string EmployeeId = "EmployeeId";



        //Company   
        public static string CompanyName = "CompanyName";
        public static string EmployeeName = "EmployeeName";
        public static string AllotedTo = "AllotedTo";
        public static string JdReceived = "JdReceived";
        public static string PastRecruitments = "PastRecruitments";
        public static string CurrentRecruiter = "CurrentRecruiter";
        public static string HiredFrom = "HiredFrom";
        public static string Summary = "Summary";
        public static string MTCorSTC = "MTCorSTC";
        public static string ContactNumber = "ContactNumber";
        public static string Address1 = "Address1";
        public static string Address2 = "Address2";
        public static string Remarks = "Remarks";
        public static string GuestLecture = "GuestLecture";
        public static string AdvisoryBoard = "AdvisoryBoard";
        public static string City = "City";
        public static string SubLocation = "SubLocation";
        public static string HiringArea = "HiringArea";
        public static string PlantorRegdOffice = "PlantorRegdOffice";
        public static string TransferredFrom = "TransferredFrom";
        public static string Sector = "Sector";
        public static string DateGiven = "DateGiven";
        public static string ResearchSource = "ResearchSource";
        public static string StreamRequired = "StreamRequired";
        public static string PayPackage = "PayPackage";
        public static string SummerTraining = "SummerTraining";
        public static string UserRemarks = "UserRemarks";
        public static string ThirdParty = "ThirdParty";
        public static string IsActive = "IsActive";

        // Call Notes
        public static string Description = "Description";
        public static string UserID = "UserID";
        public static string CompanyID = "CompanyID";
        public static string Type = "Type";
        public static string ActivityDate = "ActivityDate";
        public static string IsFollowUp = "IsFollowUp";
        public static string RemindMe = "RemindMe";

        //Company Contacts
        public static string Anniversary = "Anniversary";
        public static string ColorCode = "ColorCode";
        public static string ContactID = "ContactID";
        public static string Department = "Department";
        public static string Designation = "Designation";
        public static string EmailID = "EmailID";
        public static string MobileNumber = "MobileNumber";
        public static string ContactName = "ContactName";

        //Course
        public static string CourseName = "CourseName";
        public static string CourseId = "CourseId";
        public static string StreamName = "StreamName";
        public static string Year = "Year";
        public static string Title = "Title";
        public static string jdDescription = "jdDescription";
        public static string PayPackageID = "PayPackageID";


        //Master
        public static string Name = "Name";
        public static string Location = "Location";


        //pastrecruit

        public static string RecuritYear = "RecuritYear";
        public static string Code = "Code";
        public static string Hiringyear = "Hiringyear";
        public static string CollegeCode = "CollegeCode";
        public static string CollegeId = "CollegeId";
        public static string CompanyDescription = "CompanyDescription";
        public static string CompanyYear = "CompanyYear";
        public static string t_StreamId = "StreamId";


        public static string EventTypeId = "EventTypeId";
        public static string EventDate = "EventDate";
        public static string Status = "Status";
        public static string EventId = "EventId";
        public static string EventType = "EventType";
        public static string ContactId = "ContactId";
        public static string Visitor = "Visitor";
        public static string CallContactId = "CallContactId";



        //CompanyAddress

        public static string CityId = "CityId";
        public static string StateId = "StateId";
        public static string Value = "Value";



    }

    public class StoredProcedures
    {
        public static string GetCompanyContacts = "sp_GetCompanyContacts";
        public static string GetCompanyContactsById = "sp_GetCompanyContactsById";
        public static string GetCompanyContactsForReminder = "sp_GetCompanyContactsForReminder";
        public static string GetCallNotes = "sp_GetCallNotes";
        public static string GetCallNotesById = "sp_GetCallNotesById";
        public static string GetCallNotesByDates = "sp_GetCallNotesByDates";
        public static string GetCallNotesForReminder = "sp_GetCallNotesForReminder";
        public static string GetUsers = "sp_GetUserList";
        public static string GetCompanyList = "sp_GetCompanyList";
        public static string GetCompanyListByPage = "GetCompanies";
        public static string GetCompanyById = "sp_GetCompanyById";
        public static string GetCompanyByQuery = "sp_GetCompanyByQuery";
        public static string GetCompanyListByUser = "sp_GetCompanyListByUser";
        public static string SaveUser = "sp_SaveUser";
        public static string SaveCallNote = "sp_SaveCallNote";
        public static string SaveCompany = "sp_SaveCompany";
        public static string SaveCourse = "sp_SaveCourse";
        public static string GetCourseList = "sp_GetCourseList";
        public static string SaveStream = "sp_SaveStream";
        public static string GetStreamList = "sp_GetStreamList";
        public static string SaveJdDescription = "sp_SaveJdDescription";
        public static string GetJdDescription = "sp_GetJdDescription";
        public static string GetJdDescriptionById = "sp_GetJdDescriptionById";

        public static string SaveColor = "sp_SaveColor";
        public static string SaveSector = "sp_SaveSector";
        public static string SaveCollege = "sp_SaveCollege";
        public static string GetSectorMasters = "sp_GetSectorMasters";
        public static string GetColorMasters = "sp_GetColorMasters";
        public static string GetCollegeMasters = "sp_GetCollegeMasters";


        public static string SavePastRecruitment = "sp_SavePastRecruitment";
        public static string SavePastHiring = "sp_SavePastHiring";
        public static string SaveCompanystatus = "sp_SaveCompanystatus";
        public static string SaveCompanyStream = "sp_SaveCompanyStream";
        public static string getCompanyStreamList = "sp_getCompanyStreamList";
        public static string getCompanyStreamListById = "sp_getCompanyStreamListById";


        public static string GetPastRecruitment = "sp_getPastRecruitment";
        public static string GetPastRecruitmentById = "sp_getPastRecruitmentById";
        public static string GetPastHiring = "sp_getPastHiring";
        public static string GetPastHiringById = "sp_getPastHiringById";
        public static string GetCompanystatus = "sp_getCompanystatus";

        public static string EventMasterList = "get_EventMasterList";
        public static string SaveCompanyEvent = "sp_SaveCompanyEvent";
        public static string EventHistoryList = "get_EventHistoryList";
        public static string EventHistoryListById = "get_EventHistoryListById";

        public static string SaveContact = "sp_SaveContact";
        public static string GetPreviousNotes = "sp_GetPreviousNotes";
        public static string SaveCompanyAddress = "sp_SaveCompanyAddress";
        public static string GetCompanyAddress = "sp_GetCompanyAddress";
        public static string GetCompanyAddressById = "sp_GetCompanyAddressById";
        public static string GetCity = "sp_GetCity";
        public static string GetSublocation = "sp_GetSublocation";
        public static string SaveCity = "sp_SaveCity";
        public static string SaveSublocation = "sp_SaveSublocation";


        public static string GetCompanyExtraContacts = "sp_GetCompanyExtraContacts";
        public static string GetExtraCallNotes = "sp_GetExtraCallNotes";
        public static string SaveCompanyExtraContacts = "sp_SaveCompanyExtraContacts";
        public static string SaveExtraCallNotes = "sp_SaveExtraCallNotes";

        public static string SaveLoginHistory = "sp_SaveLoginHistory";
        public static string GetLoginHistory = "sp_GetLoginHistory";

        public static string SaveThirdPartyMasters = "sp_SaveThirdPartyMasters";
        public static string GetThirdPartyMasters = "sp_GetThirdPartyMasters";
        public static string AddPayroll = "sp_AddPayroll";
        public static string UpdatePayroll = "sp_UpdatePayroll";
        public static string PayrollList = "sp_GetPayrollData";
    }
}