using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEBAPP.Models
{
    public class User
    {


        #region Private Variables
        //private string mstrId = string.Empty;
        //private string mstrEmail = string.Empty;
        //private string mstrUserName = string.Empty;
        //private string mstrPhoneNumber = string.Empty;
        //private string mstrFirstName = string.Empty;
        //private string mstrLastName = string.Empty;
        //private string mstrAddress = string.Empty;
        //private DateTime mdtCreatedOn = DateTime.MinValue.ToUniversalTime();
        //private string mstrCreatedBy = string.Empty;
        //private DateTime mdtUpdatedOn = DateTime.MinValue.ToUniversalTime();
        //private string mstrUpdatedBy = string.Empty;
        //private bool mblnIsDeleted = false;
        //private DateTime mdtDOB = DateTime.MinValue.ToUniversalTime();
        //private string mstrGender = string.Empty;
        //private bool mbIsAdmin = false;
        //private string mstrOTP = string.Empty;
        //private bool mbIsValid = false;
        //private bool mbTwoFactorEnabled = false;


        #endregion

        #region Properties


        /// <summary>
        /// User Id
        /// </summary>

        //public bool TwoFactorEnabled
        //{
        //    get { return mbTwoFactorEnabled; }
        //    set
        //    {
        //        mbTwoFactorEnabled = value;
        //    }

        //}
        //public String OTP
        //{
        //    get { return mstrOTP; }
        //    set
        //    {
        //        mstrOTP = value;
        //    }

        //}
        //public bool IsValid
        //{
        //    get { return mbIsValid; }
        //    set
        //    {
        //        mbIsValid = value;
        //    }

        //}
        //public bool IsAdmin
        //{
        //    get
        //    { return mbIsAdmin; }
        //    set
        //    { mbIsAdmin = value; }
        //}

        ///// <summary>
        ///// User Id
        ///// </summary>


        //public string Id
        //{
        //    get
        //    { return mstrId; }
        //    set
        //    { mstrId = value; }
        //}
        ///// <summary>
        ///// Email
        ///// </summary>
        //public string Email { get; set; }
        ////public string Email
        ////{
        ////    get
        ////    { return mstrEmail; }
        ////    set
        ////    { mstrEmail = value; }
        ////}
        ///// <summary>
        ///// UserName
        ///// </summary>
        //public string UserName
        //{
        //    get
        //    { return mstrUserName; }
        //    set
        //    { mstrUserName = value; }
        //}


        ///// <summary>
        ///// PhoneNumber
        ///// </summary>
        //public string PhoneNumber
        //{
        //    get
        //    { return mstrPhoneNumber; }
        //    set
        //    { mstrPhoneNumber = value; }
        //}

        ///// <summary>
        ///// FirstName
        ///// </summary>
        //public string FirstName
        //{
        //    get
        //    { return mstrFirstName; }
        //    set
        //    { mstrFirstName = value; }
        //}


        ///// <summary>
        ///// LastName
        ///// </summary>
        //public string LastName
        //{
        //    get
        //    { return mstrLastName; }
        //    set
        //    { mstrLastName = value; }
        //}

        ///// <summary>
        ///// Address
        ///// </summary>
        //public string Address
        //{
        //    get
        //    { return mstrAddress; }
        //    set
        //    { mstrAddress = value; }
        //}

        ///// <summary>
        ///// CreatedOn
        ///// </summary>
        //public DateTime CreatedOn
        //{
        //    get
        //    { return mdtCreatedOn; }
        //    set
        //    { mdtCreatedOn = value; }
        //}

        ///// <summary>
        ///// UpdatedOn
        ///// </summary>
        //public DateTime UpdatedOn
        //{
        //    get
        //    { return mdtUpdatedOn; }
        //    set
        //    { mdtUpdatedOn = value; }
        //}

        ///// <summary>
        ///// DOB
        ///// </summary>
        //public DateTime DOB
        //{
        //    get
        //    { return mdtDOB; }
        //    set
        //    { mdtDOB = value; }
        //}


        ///// <summary>
        ///// CreatedBy
        ///// </summary>
        //public string CreatedBy
        //{
        //    get
        //    { return mstrCreatedBy; }
        //    set
        //    { mstrCreatedBy = value; }
        //}


        ///// <summary>
        ///// UpdatedBy
        ///// </summary>
        //public string UpdatedBy
        //{
        //    get
        //    { return mstrUpdatedBy; }
        //    set
        //    { mstrUpdatedBy = value; }
        //}

        ///// <summary>
        ///// IsDeleted
        ///// </summary>
        //public bool IsDeleted
        //{
        //    get
        //    { return mblnIsDeleted; }
        //    set
        //    { mblnIsDeleted = value; }
        //}
        ///// <summary>
        ///// Gender
        ///// </summary>
        //public string Gender
        //{
        //    get
        //    { return mstrGender; }
        //    set
        //    { mstrGender = value; }
        //}

        public bool TwoFactorEnabled
        {
            get;
            set;

        }
        public String OTP
        {
            get; set;

        }
        public bool IsValid
        {
            get; set;

        }
        public bool IsAdmin
        {
            get; set;
        }

        /// <summary>
        /// User Id
        /// </summary>


        public string Id
        {
            get; set;
        }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        //public string Email
        //{
        //    get
        //    { return mstrEmail; }
        //    set
        //    { mstrEmail = value; }
        //}
        /// <summary>
        /// UserName
        /// </summary>
        public string UserName
        {
            get; set;
        }


        /// <summary>
        /// PhoneNumber
        /// </summary>
        public string PhoneNumber
        {
            get; set;
        }

        /// <summary>
        /// FirstName
        /// </summary>
        public string FirstName
        {
            get; set;
        }


        /// <summary>
        /// LastName
        /// </summary>
        public string LastName
        {
            get; set;
        }

        /// <summary>
        /// Address
        /// </summary>
        public string Address
        {
            get; set;
        }

        /// <summary>
        /// CreatedOn
        /// </summary>
        public DateTime CreatedOn
        {
            get; set;
        }

        /// <summary>
        /// UpdatedOn
        /// </summary>
        public DateTime UpdatedOn
        {
            get; set;
        }

        /// <summary>
        /// DOB
        /// </summary>
        public DateTime DOB
        {
            get; set;
        }


        /// <summary>
        /// CreatedBy
        /// </summary>
        public string CreatedBy
        {
            get; set;
        }


        /// <summary>
        /// UpdatedBy
        /// </summary>
        public string UpdatedBy
        {
            get; set;
        }

        /// <summary>
        /// IsDeleted
        /// </summary>
        public bool IsDeleted
        {
            get; set;
        }
        /// <summary>
        /// Gender
        /// </summary>
        public string Gender
        {
            get; set;
        }

        /// <summary>
        /// Barcode
        /// </summary>
        public string Barcode
        {
            get; set;
        }

        /// <summary>
        /// FatherName
        /// </summary>
        public string FatherName
        {
            get; set;
        }

        /// <summary>
        /// CompanyId
        /// </summary>
        public string CompanyId
        {
            get; set;
        }

        /// <summary>
        /// Designatation
        /// </summary>
        public string Designatation
        {
            get; set;
        }

        /// <summary>
        /// UANNumber
        /// </summary>
        public string UANNumber
        {
            get; set;
        }

        /// <summary>
        /// ESICNumber
        /// </summary>
        public string ESICNumber
        {
            get; set;
        }

        /// <summary>
        /// AdharNumber
        /// </summary>
        public string AdharNumber
        {
            get; set;
        }

        /// <summary>
        /// SalaryDate
        /// </summary>
        public string SalaryDate
        {
            get; set;
        }
        public string EmployeeId
        {
            get; set;
        }

        public SelectList ddlCompany { get; set; }

        #endregion
    }
}