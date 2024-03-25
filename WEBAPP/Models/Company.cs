using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEBAPP.Models
{
    public class Company
    {

        public List<Company> CompanyList { get; set; } = new List<Company>();
        public List<Stream> MyStream { get; set; }
        public List<CompanyAddress> CompanyAddressList { get; set; }

        public List<ExtraCallNotes> CompanyExtraCallNotes { get; set; }

        public List<CompanyExtraContacts> CompanyExtraContacts { get; set; }
        #region Private Variables
        private int mintId = 0;
        private string mstrCompanyName = string.Empty;


        private string mstrAllotedTo = string.Empty;

        private string mstrSummary = string.Empty;
        private string mstrMTCorSTC = string.Empty;
        private string mstrContactNumber = string.Empty;
        private string mstrAddress1 = string.Empty;
        private string mstrAddress2 = string.Empty;

        //private string mstrRemarks = string.Empty;

        private string mstrCity = string.Empty;
        private string mstrSubLocation = string.Empty;
        private string mstrHiringArea = string.Empty;
        private string mstrPlantorRegdOffice = string.Empty;
        private string mstrTransferredFrom = string.Empty;
        private string mstrSector = string.Empty;
        private DateTime mdtDateGiven = DateTime.Now.Date;
        private string mstrResearchSource = string.Empty;

        private string mstrSummerTraining = string.Empty;
        private string mstrThirdParty = string.Empty;
        private DateTime mdtCreatedOn = DateTime.MinValue;
        private string mstrCreatedBy = string.Empty;
        private DateTime mdtUpdatedOn = DateTime.MinValue;
        private string mstrUpdatedBy = string.Empty;
        private bool mblnIsActive = true;
        private bool mblnIsDeleted = false;
        private string mstrColorCode = string.Empty;
        private List<CallNote> mCallNoteList = new List<CallNote>();
        private List<CompanyContact> mCompanyContactList = new List<CompanyContact>();
        private List<JobDescription> mJobDescriptionList = new List<JobDescription>();

        private List<PastRecruitment> mPastRecruitmentList = new List<PastRecruitment>();
        private List<PastHiring> mPastHiringList = new List<PastHiring>();
        private List<CompanyStatus> mCompanyStatusList = new List<CompanyStatus>();

        private List<EventHistory> mCompanyEventHistory = new List<EventHistory>();

        private List<CompanyStream> mCompanyStreamList = new List<CompanyStream>();
        public SelectList ddlcolor { get; set; }
        public SelectList ddlCity { get; set; }
        public List<PreviousNotes> PreviousNotesList { get; set; }
        public SelectList ddlSector { get; set; }
        public SelectList ddlSubLocation { get; set; }
        public List<Course> CourseDrp { get; set; }
        public int? CourseId { get; set; }

        public int? StreamId { get; set; }
        public SelectList ddlStream { get; set; }
        public int? ColorId { get; set; }
        #endregion
        public string t_JsonString { get; set; }
        public string FollowUpDate { get; set; }
        public SelectList objCollegeMasterList { get; set; }

        public SelectList objCollegeEventList { get; set; }

        public SelectList ddlthirdparty { get; set; }

        public int TotalRecords { get; set; }

        public SelectList ddlCompany { get; set; }
        #region Properties

        public List<CompanyStream> CompanyStreamList
        {
            get
            { return mCompanyStreamList; }
            set
            { mCompanyStreamList = value; }
        }

        public List<EventHistory> CompanyEventHistory
        {
            get
            { return mCompanyEventHistory; }
            set
            { mCompanyEventHistory = value; }
        }


        /// <summary>
        /// CompanyContact List/// </summary>

        public List<CompanyContact> CompanyContactList
        {
            get
            { return mCompanyContactList; }
            set
            { mCompanyContactList = value; }
        }


        public List<PastRecruitment> PastRecruitmentList
        {
            get
            { return mPastRecruitmentList; }
            set
            { mPastRecruitmentList = value; }
        }


        public List<CompanyStatus> CompanyStatusList
        {
            get
            { return mCompanyStatusList; }
            set
            { mCompanyStatusList = value; }
        }
        public List<PastHiring> PastHiringList
        {
            get
            { return mPastHiringList; }
            set
            { mPastHiringList = value; }
        }
        public List<JobDescription> JobDescriptionList
        {
            get
            { return mJobDescriptionList; }
            set
            { mJobDescriptionList = value; }
        }


        public string AllotedTo
        {
            get
            {
                return mstrAllotedTo;
            }
            set
            {
                mstrAllotedTo = value;
            }
        }

        public string ColorCode
        {
            get
            {
                return mstrColorCode;
            }
            set
            {
                mstrColorCode = value;
            }
        }


        /// <summary>
        /// Callnote List         /// </summary>

        public List<CallNote> CallNoteList
        {
            get
            { return mCallNoteList; }
            set
            { mCallNoteList = value; }
        }

        /// <summary>
        /// Company Id
        /// </summary>

        public int Id
        {
            get
            { return mintId; }
            set
            { mintId = value; }
        }
        /// <summary>
        /// CompanyName
        /// </summary>
        [Required]
        public string CompanyName
        {
            get
            { return mstrCompanyName; }
            set
            { mstrCompanyName = value; }
        }


        /// <summary>
        /// Summary
        /// </summary>
        [AllowHtml]

        public string Summary
        {
            get
            { return mstrSummary; }
            set
            { mstrSummary = value; }
        }

        /// <summary>
        /// CreatedOn
        /// </summary>
        public DateTime CreatedOn
        {
            get
            { return mdtCreatedOn; }
            set
            { mdtCreatedOn = value; }
        }

        /// <summary>
        /// UpdatedOn
        /// </summary>
        public DateTime UpdatedOn
        {
            get
            { return mdtUpdatedOn; }
            set
            { mdtUpdatedOn = value; }
        }

        /// <summary>
        /// MTCorSTC
        /// </summary>
        public string MTCorSTC
        {
            get
            { return mstrMTCorSTC; }
            set
            { mstrMTCorSTC = value; }
        }


        /// <summary>
        /// CreatedBy
        /// </summary>
        public string CreatedBy
        {
            get
            { return mstrCreatedBy; }
            set
            { mstrCreatedBy = value; }
        }


        /// <summary>
        /// UpdatedBy
        /// </summary>
        public string UpdatedBy
        {
            get
            { return mstrUpdatedBy; }
            set
            { mstrUpdatedBy = value; }
        }

        /// <summary>
        /// IsDeleted
        /// </summary>
        public bool IsDeleted
        {
            get
            { return mblnIsDeleted; }
            set
            { mblnIsDeleted = value; }
        }
        /// <summary>
        /// ContactNumber
        /// </summary>
        /// 

        public string ContactNumber
        {
            get
            { return mstrContactNumber; }
            set
            { mstrContactNumber = value; }
        }
        /// <summary>
        /// Address1
        /// </summary>
        /// 

        [Display(Name = "Address")]
        public string Address1
        {
            get
            { return mstrAddress1; }
            set
            { mstrAddress1 = value; }
        }
        /// <summary>
        /// Address2
        /// </summary>
        public string Address2
        {
            get
            { return mstrAddress2; }
            set
            { mstrAddress2 = value; }
        }
        /// <summary>
        /// Remarks
        /// </summary>
        /// 
        [AllowHtml]
        public string Remarks { get; set; }
        //{
        //    get
        //    { return mstrRemarks; }
        //    set
        //    { mstrRemarks = value; }
        //}


        /// <summary>
        /// City
        /// </summary>
        /// 
        [Required]
        public string City
        {
            get
            { return mstrCity; }
            set
            { mstrCity = value; }
        }



        public string SubLocation { get => mstrSubLocation; set => mstrSubLocation = value; }
        public string HiringArea { get => mstrHiringArea; set => mstrHiringArea = value; }
        public string PlantorRegdOffice { get => mstrPlantorRegdOffice; set => mstrPlantorRegdOffice = value; }
        public string TransferredFrom { get => mstrTransferredFrom; set => mstrTransferredFrom = value; }
        [Required]
        public string Sector { get => mstrSector; set => mstrSector = value; }


        [Required]
        public DateTime DateGiven { get => mdtDateGiven; set => mdtDateGiven = value; }


        [Required]
        public string ResearchSource { get => mstrResearchSource; set => mstrResearchSource = value; }


        public string SummerTraining { get => mstrSummerTraining; set => mstrSummerTraining = value; }

        public string ThirdParty { get => mstrThirdParty; set => mstrThirdParty = value; }
        public bool IsActive { get => mblnIsActive; set => mblnIsActive = value; }
        #endregion

    }
}