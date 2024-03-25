using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using WEBAPP.Models;

namespace WEBAPP.DAL
{
    public static class DataMapper
    {
        public static List<LoginHistory> MapLoginHistory(DataSet pobjDS)
        {
            List<LoginHistory> lobjLoginHistoryList = new List<LoginHistory>();
            if (pobjDS != null && pobjDS.Tables.Count > 0 && pobjDS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < pobjDS.Tables[0].Rows.Count; i++)
                {
                    LoginHistory lobjLoginHistory = new LoginHistory();
                    lobjLoginHistory.Email = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Email]);
                    lobjLoginHistory.IpAddress = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.IpAddress]);
                    lobjLoginHistory.CreatedOn = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.CreatedOn]);
                    lobjLoginHistoryList.Add(lobjLoginHistory);
                }
            }
            return lobjLoginHistoryList;
        }
        public static List<User> MapUserData(DataSet pobjDS)
        {
            List<User> lobjUserList = new List<User>();
            if (pobjDS != null && pobjDS.Tables.Count > 0 && pobjDS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < pobjDS.Tables[0].Rows.Count; i++)
                {
                    User lobjUser = new User();
                    lobjUser.Id = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Id]);
                    lobjUser.Address = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Address]);
                    lobjUser.CreatedOn = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.CreatedOn]);
                    lobjUser.CreatedBy = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.CreatedBy]);
                    lobjUser.DOB = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.DOB]);
                    lobjUser.Email = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Email]);
                    lobjUser.FirstName = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.FirstName]);
                    lobjUser.Gender = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Gender]);
                    lobjUser.IsDeleted = Convert.ToBoolean(pobjDS.Tables[0].Rows[i][DBFields.IsDeleted]);
                    lobjUser.LastName = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.LastName]);
                    lobjUser.PhoneNumber = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.PhoneNumber]);
                    lobjUser.UpdatedBy = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.UpdatedBy]);
                    lobjUser.UpdatedOn = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.UpdatedOn]);
                    lobjUser.UserName = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.UserName]);
                    lobjUser.IsAdmin = Convert.ToBoolean(pobjDS.Tables[0].Rows[i][DBFields.IsAdmin]);
                    lobjUser.OTP = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.OTP]);
                    lobjUser.Barcode = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Barcode]);
                    lobjUser.FatherName = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.FatherName]);
                    lobjUser.CompanyId = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.CompanyId]);
                    lobjUser.Designatation = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Designatation]);
                    lobjUser.UANNumber = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.UANNumber]);
                    lobjUser.ESICNumber = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.ESICNumber]);
                    lobjUser.AdharNumber = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.AdharNumber]);
                    lobjUser.SalaryDate = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.SalaryDate]);
                     
                    if (pobjDS.Tables[0].Rows[i][DBFields.IsValid] != DBNull.Value)
                    {
                        lobjUser.IsValid = Convert.ToBoolean(pobjDS.Tables[0].Rows[i][DBFields.IsValid]);

                    }
                    lobjUser.TwoFactorEnabled = Convert.ToBoolean(pobjDS.Tables[0].Rows[i][DBFields.TwoFactorEnabled]);
                    lobjUserList.Add(lobjUser);
                }
            }
            return lobjUserList;
        }




        public static List<CallNote> MapCallNotesData(DataSet pobjDS)
        {
            List<CallNote> lobjCallNoteList = new List<CallNote>();
            if (pobjDS != null && pobjDS.Tables.Count > 0 && pobjDS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < pobjDS.Tables[0].Rows.Count; i++)
                {
                    CallNote lobjCallnote = new CallNote();
                    lobjCallnote.ActivityDate = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.ActivityDate]);
                    lobjCallnote.CompanyID = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.CompanyID]);
                    lobjCallnote.CreatedOn = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.CreatedOn]);
                    lobjCallnote.Description = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Description]);
                    lobjCallnote.Id = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.Id]);

                    lobjCallnote.Type = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.Type]);
                    lobjCallnote.UpdatedOn = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.UpdatedOn]);
                    lobjCallnote.UserID = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.UserID]);
                    lobjCallnote.CallContactId = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.CallContactId]);
                    if (pobjDS.Tables[0].Rows[i][DBFields.RemindMe] != DBNull.Value)
                    {
                        lobjCallnote.RemindMe = Convert.ToBoolean(pobjDS.Tables[0].Rows[i][DBFields.RemindMe]);
                    }

                    if (pobjDS.Tables[0].Rows[i][DBFields.Status] != DBNull.Value)
                    {
                        lobjCallnote.Status = Convert.ToBoolean(pobjDS.Tables[0].Rows[i][DBFields.Status]);
                    }
                    lobjCallNoteList.Add(lobjCallnote);
                }
            }
            return lobjCallNoteList;
        }

        public static List<Course> MapCourseData(DataSet pobjDS)
        {
            List<Course> lobjCourseList = new List<Course>();
            if (pobjDS != null && pobjDS.Tables.Count > 0 && pobjDS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < pobjDS.Tables[0].Rows.Count; i++)
                {
                    Course lobjCourse = new Course();
                    lobjCourse.Id = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.Id]);
                    lobjCourse.CourseName = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.CourseName]);

                    lobjCourseList.Add(lobjCourse);
                }
            }
            return lobjCourseList;
        }
        public static List<Stream> MapStreamData(DataSet pobjDS)
        {
            List<Stream> lobjStreamList = new List<Stream>();
            if (pobjDS != null && pobjDS.Tables.Count > 0 && pobjDS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < pobjDS.Tables[0].Rows.Count; i++)
                {
                    Stream lobjStream = new Stream
                    {
                        Id = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.Id]),
                        CourseId = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.CourseId]),
                        StreamName = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.StreamName]),
                        CourseName = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.CourseName]),
                        CreatedOn = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.CreatedOn])
                    };

                    lobjStreamList.Add(lobjStream);
                }
            }
            return lobjStreamList;
        }
        public static List<CompanyContact> MapCompanyContact(DataSet pobjDS)
        {
            List<CompanyContact> lobjCompanyContactList = new List<CompanyContact>();
            if (pobjDS != null && pobjDS.Tables.Count > 0 && pobjDS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < pobjDS.Tables[0].Rows.Count; i++)
                {
                    CompanyContact lobjCompanyContact = new CompanyContact
                    {
                        Address = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Address]),

                        Anniversary = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Anniversary]),

                        ColorCode = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.ColorCode]),
                        CompanyID = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.CompanyID]),
                        ContactID = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.ContactID]),
                        ContactName = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.ContactName]),
                        CreatedBy = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.CreatedBy]),
                        CreatedOn = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.CreatedOn]),
                        Department = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Department]),
                        Description = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Description]),
                        Designation = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Designation]),

                        DOB = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.DOB]),

                        EmailID = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.EmailID]),
                        IsActive = Convert.ToBoolean(pobjDS.Tables[0].Rows[i][DBFields.IsActive]),
                        MobileNumber = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.MobileNumber]),
                        PhoneNumber = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.PhoneNumber]),
                        UpdatedBy = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.UpdatedBy]),
                        UpdatedOn = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.UpdatedOn])
                    };
                    lobjCompanyContactList.Add(lobjCompanyContact);
                }
            }
            return lobjCompanyContactList;
        }
        public static List<JobDescription> MapJobDescription(DataSet pobjDS)
        {
            List<JobDescription> lobjCompanyContactList = new List<JobDescription>();
            if (pobjDS != null && pobjDS.Tables.Count > 0 && pobjDS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < pobjDS.Tables[0].Rows.Count; i++)
                {
                    JobDescription lobjCompanyContact = new JobDescription
                    {
                        Id = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.Id]),
                        CompanyID = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.CompanyID]),
                        Title = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Title]),
                        Year = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Year]),
                        jdDescription = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.jdDescription]),
                        CreatedBy = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.CreatedBy]),
                        CreatedOn = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.CreatedOn]),

                        IsActive = Convert.ToBoolean(pobjDS.Tables[0].Rows[i][DBFields.IsActive]),
                        Type = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Type]),
                        UpdatedBy = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.UpdatedBy]),
                        UpdatedOn = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.UpdatedOn])
                    };
                    lobjCompanyContactList.Add(lobjCompanyContact);
                }
            }
            return lobjCompanyContactList;
        }
        public static List<PreviousNotes> MapPreviousNotes(DataSet pobjDS)
        {

            List<PreviousNotes> lobjCompanyContactList = new List<PreviousNotes>();
            //IEnumerable<DataRow> sequence = pobjDS.Tables[0].AsEnumerable();
            if (pobjDS != null && pobjDS.Tables.Count > 0 && pobjDS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < pobjDS.Tables[0].Rows.Count; i++)
                {
                    PreviousNotes lobjCompanyContact = new PreviousNotes();
                    lobjCompanyContact.Id = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.Id]);
                    lobjCompanyContact.CompanyName = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.CompanyName]);
                    //lobjCompanyContact.Title = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Title]);
                    foreach (DataRow dr in pobjDS.Tables[0].Rows)
                    {
                        List<string> lister = new List<string>();
                        foreach (DataColumn dc in pobjDS.Tables[0].Columns)
                        {
                            if (pobjDS.Tables[0].Columns.Count > 2)
                            {
                                string str1 = string.Empty;
                                str1 = dr[dc].ToString();
                                lister.Add(str1);

                            }

                        }
                        lobjCompanyContact.PreviousNote = lister;
                        break;
                    }
                    lobjCompanyContactList.Add(lobjCompanyContact);
                }
            }
            return lobjCompanyContactList;
        }


        public static List<Company> MapCompanyDataForEdit(DataSet pobjDS)
        {
            List<Company> lobjCompanyList = new List<Company>();
            List<CompanyStream> lobjCompanyStreamList = new List<CompanyStream>();
            List<CallNote> lobjCallNoteList = new List<CallNote>();
            List<PreviousNotes> lobjPreviousNotesList = new List<PreviousNotes>();
            List<CompanyContact> lobjCompanyContactList = new List<CompanyContact>();
            List<JobDescription> lobjJobDescriptionList = new List<JobDescription>();

            List<PastRecruitment> lobjPastRecruitmentList = new List<PastRecruitment>();
            List<PastHiring> lobjPastHiringList = new List<PastHiring>();
            List<CompanyStatus> lobjCompanyStatusList = new List<CompanyStatus>();
            List<Stream> lobjstreamer = new List<Stream>();
            List<CompanyAddress> lobjCompanyAddressList = new List<CompanyAddress>();
            List<EventHistory> lobjCompanyEventHistory = new List<EventHistory>();
            //List<ExtraCallNotes> lobjExtraCallNotes = new List<ExtraCallNotes>();
            List<CompanyExtraContacts> lobjExtraContacts = new List<CompanyExtraContacts>();

            int CompanyID = Convert.ToInt32(pobjDS.Tables[0].Rows[0]["ID"].ToString());
            lobjstreamer = DataMapper.MapStreamData(SPWrapper.GetStreamList());
            lobjPastRecruitmentList = MapPastRecruitment(SPWrapper.GetPastRecruitment());
            lobjPastHiringList = MapPastHiring(SPWrapper.GetPastHiringById(CompanyID));
            lobjCompanyStatusList = MapCompanystatus(SPWrapper.GetCompanystatus());
            lobjCompanyStreamList = MapCompanyStream(SPWrapper.GetCompanyStreamById(CompanyID));
            lobjCallNoteList = MapCallNotesData(SPWrapper.GetCallNoteById(CompanyID));
            lobjCompanyContactList = MapCompanyContact(SPWrapper.GetCompanyContactsById(CompanyID));
            lobjJobDescriptionList = MapJobDescription(SPWrapper.GetJobDescriptionById(CompanyID));
            lobjPreviousNotesList = MapPreviousNotes(SPWrapper.GetPreviousNotes());
            lobjCompanyAddressList = MapCompanyAddress(SPWrapper.GetCompanyAddressById(CompanyID));
            lobjCompanyEventHistory = MapCompanyHistory(SPWrapper.GetCompanyHistoryById(CompanyID));


            if (pobjDS != null && pobjDS.Tables.Count > 0 && pobjDS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < pobjDS.Tables[0].Rows.Count; i++)
                {
                    Company lobjCompany = new Company
                    {
                        Address1 = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Address1]),
                        Address2 = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Address2]),

                        City = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.City]),
                        CompanyName = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.CompanyName]),
                        AllotedTo = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.AllotedTo]),
                        CreatedBy = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.CreatedBy]),
                        CreatedOn = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.CreatedOn]),

                        DateGiven = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.DateGiven]),


                        HiringArea = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.HiringArea]),
                        Id = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.Id]),
                        IsActive = Convert.ToBoolean(pobjDS.Tables[0].Rows[i][DBFields.IsActive]),
                        IsDeleted = Convert.ToBoolean(pobjDS.Tables[0].Rows[i][DBFields.IsDeleted]),

                        MTCorSTC = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.MTCorSTC]),

                        PlantorRegdOffice = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.PlantorRegdOffice]),
                        Remarks = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Remarks]),
                        ResearchSource = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.ResearchSource]),
                        Sector = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Sector]),

                        SubLocation = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.SubLocation]),
                        Summary = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Summary]),
                        SummerTraining = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.SummerTraining]),
                        ThirdParty = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.ThirdParty]),
                        ColorCode = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.ColorCode]),
                        TransferredFrom = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.TransferredFrom]),
                        UpdatedBy = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.UpdatedBy]),
                        UpdatedOn = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.UpdatedOn]),


                    };

                    //lobjCompany.CompanyExtraCallNotes = MapExtraCallNotes(SPWrapper.GetExtraCallNotesList(lobjCompany.Id));
                    lobjCompany.CompanyExtraContacts = MapCompanyExtraContacts(SPWrapper.GetCompanyExtraContactsList(lobjCompany.Id));



                    lobjCompany.CallNoteList = lobjCallNoteList.Where(x => x.CompanyID == lobjCompany.Id).OrderByDescending(x => x.ActivityDate).ToList();
                    lobjCompany.CompanyContactList = lobjCompanyContactList.Where(x => x.CompanyID == lobjCompany.Id).ToList();
                    lobjCompany.CompanyContactList.Add(new CompanyContact { ContactName = "Others", ContactID = 0 });
                    lobjCompany.JobDescriptionList = lobjJobDescriptionList.Where(x => x.CompanyID == lobjCompany.Id).ToList();
                    lobjCompany.CompanyStreamList = lobjCompanyStreamList.Where(x => x.CompanyId == lobjCompany.Id).ToList();
                    lobjCompany.PastRecruitmentList = lobjPastRecruitmentList.Where(x => x.CompanyID == lobjCompany.Id).ToList();
                    lobjCompany.PastHiringList = lobjPastHiringList.Where(x => x.CompanyID == lobjCompany.Id).ToList();
                    lobjCompany.CompanyStatusList = lobjCompanyStatusList.Where(x => x.CompanyID == lobjCompany.Id).ToList();
                    lobjCompany.MyStream = lobjstreamer;
                    //  lobjCompany.PreviousNotesList = lobjPreviousNotesList.ToList();
                    lobjCompany.objCollegeMasterList = new SelectList(DataMapper.MapCollegeMaster(SPWrapper.GetCollegeMasters()).ToList().Select(m => new { m.Id, m.Name }).ToList(), "Id", "Name");
                    lobjCompany.ddlSector = new SelectList(DataMapper.MapSectorMaster(SPWrapper.GetSectorMasters()).ToList().Select(m => new { m.Id, m.Name }).ToList(), "Id", "Name");
                    lobjCompany.ddlcolor = new SelectList(Enum.GetValues(typeof(Color)).OfType<Color>().ToList());
                    lobjCompany.CompanyAddressList = lobjCompanyAddressList.Where(x => x.CompanyID == lobjCompany.Id).ToList();
                    lobjCompany.CompanyEventHistory = lobjCompanyEventHistory.Where(x => x.CompanyID == lobjCompany.Id).ToList();
                    lobjCompanyList.Add(lobjCompany);
                }
            }
            return lobjCompanyList;
        }

        public static List<Company> MapCompanyMaster(DataSet pobjDS)
        {
            List<Company> lobjCompanyList = new List<Company>();

            if (pobjDS != null && pobjDS.Tables.Count > 0 && pobjDS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < pobjDS.Tables[0].Rows.Count; i++)
                {
                    Company lobjCompany = new Company
                    {
                        Address1 = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Address1]),
                        Address2 = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Address2]),

                        City = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.City]),
                        CompanyName = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.CompanyName]),
                        AllotedTo = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.AllotedTo]),
                        CreatedBy = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.CreatedBy]),
                        CreatedOn = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.CreatedOn]),

                        DateGiven = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.DateGiven]),


                        HiringArea = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.HiringArea]),
                        Id = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.Id]),
                        IsActive = Convert.ToBoolean(pobjDS.Tables[0].Rows[i][DBFields.IsActive]),
                        IsDeleted = Convert.ToBoolean(pobjDS.Tables[0].Rows[i][DBFields.IsDeleted]),

                        MTCorSTC = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.MTCorSTC]),

                        PlantorRegdOffice = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.PlantorRegdOffice]),
                        Remarks = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Remarks]),
                        ResearchSource = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.ResearchSource]),
                        Sector = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Sector]),

                        SubLocation = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.SubLocation]),
                        Summary = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Summary]),
                        SummerTraining = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.SummerTraining]),
                        ThirdParty = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.ThirdParty]),
                        ColorCode = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.ColorCode]),
                        TransferredFrom = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.TransferredFrom]),
                        UpdatedBy = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.UpdatedBy]),
                        UpdatedOn = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.UpdatedOn]),
                    };
                    lobjCompanyList.Add(lobjCompany);
                }
            }
            return lobjCompanyList;
        }

        public static List<Company> MapCompanyData(DataSet pobjDS)
        {
            List<Company> lobjCompanyList = new List<Company>();
            List<CompanyStream> lobjCompanyStreamList = new List<CompanyStream>();
            List<CallNote> lobjCallNoteList = new List<CallNote>();
            List<PreviousNotes> lobjPreviousNotesList = new List<PreviousNotes>();
            List<CompanyContact> lobjCompanyContactList = new List<CompanyContact>();
            List<JobDescription> lobjJobDescriptionList = new List<JobDescription>();

            List<PastRecruitment> lobjPastRecruitmentList = new List<PastRecruitment>();
            List<PastHiring> lobjPastHiringList = new List<PastHiring>();
            List<CompanyStatus> lobjCompanyStatusList = new List<CompanyStatus>();
            List<Stream> lobjstreamer = new List<Stream>();
            List<CompanyAddress> lobjCompanyAddressList = new List<CompanyAddress>();
            List<EventHistory> lobjCompanyEventHistory = new List<EventHistory>();
            List<ExtraCallNotes> lobjExtraCallNotes = new List<ExtraCallNotes>();
            List<CompanyExtraContacts> lobjExtraContacts = new List<CompanyExtraContacts>();


            // lobjstreamer = DataMapper.MapStreamData(SPWrapper.GetStreamList());
            lobjPastRecruitmentList = MapPastRecruitment(SPWrapper.GetPastRecruitment());
            lobjPastHiringList = MapPastHiring(SPWrapper.GetPastHiring());
            lobjCompanyStatusList = MapCompanystatus(SPWrapper.GetCompanystatus());
            lobjCompanyStreamList = MapCompanyStream(SPWrapper.GetCompanyStream());
            lobjCallNoteList = MapCallNotesData(SPWrapper.GetCallNote());
            lobjCompanyContactList = MapCompanyContact(SPWrapper.GetCompanyContacts());
            lobjJobDescriptionList = MapJobDescription(SPWrapper.GetJobDescription());
            lobjPreviousNotesList = MapPreviousNotes(SPWrapper.GetPreviousNotes());
            lobjCompanyAddressList = MapCompanyAddress(SPWrapper.GetCompanyAddress());
            lobjCompanyEventHistory = MapCompanyHistory(SPWrapper.GetCompanyHistory());


            if (pobjDS != null && pobjDS.Tables.Count > 0 && pobjDS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < pobjDS.Tables[0].Rows.Count; i++)
                {
                    Company lobjCompany = new Company
                    {
                        Address1 = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Address1]),
                        Address2 = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Address2]),

                        City = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.City]),
                        CompanyName = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.CompanyName]),
                        AllotedTo = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.AllotedTo]),
                        CreatedBy = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.CreatedBy]),
                        CreatedOn = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.CreatedOn]),

                        DateGiven = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.DateGiven]),


                        HiringArea = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.HiringArea]),
                        Id = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.Id]),
                        IsActive = Convert.ToBoolean(pobjDS.Tables[0].Rows[i][DBFields.IsActive]),
                        IsDeleted = Convert.ToBoolean(pobjDS.Tables[0].Rows[i][DBFields.IsDeleted]),

                        MTCorSTC = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.MTCorSTC]),

                        PlantorRegdOffice = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.PlantorRegdOffice]),
                        Remarks = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Remarks]),
                        ResearchSource = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.ResearchSource]),
                        Sector = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Sector]),

                        SubLocation = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.SubLocation]),
                        Summary = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Summary]),
                        SummerTraining = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.SummerTraining]),
                        ThirdParty = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.ThirdParty]),
                        ColorCode = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.ColorCode]),
                        TransferredFrom = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.TransferredFrom]),
                        UpdatedBy = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.UpdatedBy]),
                        UpdatedOn = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.UpdatedOn]),


                    };

                    //lobjCompany.CompanyExtraCallNotes = MapExtraCallNotes(SPWrapper.GetExtraCallNotesList(lobjCompany.Id));
                    //lobjCompany.CompanyExtraContacts = MapCompanyExtraContacts(SPWrapper.GetCompanyExtraContactsList(lobjCompany.Id));



                    lobjCompany.CallNoteList = lobjCallNoteList.Where(x => x.CompanyID == lobjCompany.Id).OrderByDescending(x => x.ActivityDate).ToList();
                    lobjCompany.CompanyContactList = lobjCompanyContactList.Where(x => x.CompanyID == lobjCompany.Id).ToList();
                    lobjCompany.CompanyContactList.Add(new CompanyContact { ContactName = "Others", ContactID = 0 });
                    lobjCompany.JobDescriptionList = lobjJobDescriptionList.Where(x => x.CompanyID == lobjCompany.Id).ToList();
                    lobjCompany.CompanyStreamList = lobjCompanyStreamList.Where(x => x.CompanyId == lobjCompany.Id).ToList();
                    lobjCompany.PastRecruitmentList = lobjPastRecruitmentList.Where(x => x.CompanyID == lobjCompany.Id).ToList();
                    lobjCompany.PastHiringList = lobjPastHiringList.Where(x => x.CompanyID == lobjCompany.Id).ToList();
                    lobjCompany.CompanyStatusList = lobjCompanyStatusList.Where(x => x.CompanyID == lobjCompany.Id).ToList();
                    //lobjCompany.MyStream = lobjstreamer;
                    //  lobjCompany.PreviousNotesList = lobjPreviousNotesList.ToList();
                    // lobjCompany.objCollegeMasterList = new SelectList(DataMapper.MapCollegeMaster(SPWrapper.GetCollegeMasters()).ToList().Select(m => new { m.Id, m.Name }).ToList(), "Id", "Name");
                    //lobjCompany.ddlSector = new SelectList(DataMapper.MapSectorMaster(SPWrapper.GetSectorMasters()).ToList().Select(m => new { m.Id, m.Name }).ToList(), "Id", "Name");
                    //lobjCompany.ddlcolor = new SelectList(Enum.GetValues(typeof(Color)).OfType<Color>().ToList());
                    lobjCompany.CompanyAddressList = lobjCompanyAddressList.Where(x => x.CompanyID == lobjCompany.Id).ToList();
                    lobjCompany.CompanyEventHistory = lobjCompanyEventHistory.Where(x => x.CompanyID == lobjCompany.Id).ToList();
                    lobjCompanyList.Add(lobjCompany);
                }
            }
            return lobjCompanyList;
        }
        public static List<Company> MapCompanyDataForExport(DataSet pobjDS)
        {
            List<Company> lobjCompanyList = new List<Company>();
            List<CompanyStream> lobjCompanyStreamList = new List<CompanyStream>();
            List<CallNote> lobjCallNoteList = new List<CallNote>();
            List<PreviousNotes> lobjPreviousNotesList = new List<PreviousNotes>();
            List<CompanyContact> lobjCompanyContactList = new List<CompanyContact>();
            List<JobDescription> lobjJobDescriptionList = new List<JobDescription>();

            List<PastRecruitment> lobjPastRecruitmentList = new List<PastRecruitment>();
            List<PastHiring> lobjPastHiringList = new List<PastHiring>();
            List<CompanyStatus> lobjCompanyStatusList = new List<CompanyStatus>();
            List<Stream> lobjstreamer = new List<Stream>();
            List<CompanyAddress> lobjCompanyAddressList = new List<CompanyAddress>();
            List<EventHistory> lobjCompanyEventHistory = new List<EventHistory>();
            List<ExtraCallNotes> lobjExtraCallNotes = new List<ExtraCallNotes>();
            List<CompanyExtraContacts> lobjExtraContacts = new List<CompanyExtraContacts>();


            // lobjstreamer = DataMapper.MapStreamData(SPWrapper.GetStreamList());
            lobjPastRecruitmentList = MapPastRecruitment(SPWrapper.GetPastRecruitment());
            lobjPastHiringList = MapPastHiring(SPWrapper.GetPastHiring());
            lobjCompanyStatusList = MapCompanystatus(SPWrapper.GetCompanystatus());
            lobjCompanyStreamList = MapCompanyStream(SPWrapper.GetCompanyStream());
            lobjCallNoteList = MapCallNotesData(SPWrapper.GetCallNote());
            lobjCompanyContactList = MapCompanyContact(SPWrapper.GetCompanyContacts());
            lobjJobDescriptionList = MapJobDescription(SPWrapper.GetJobDescription());
            lobjPreviousNotesList = MapPreviousNotes(SPWrapper.GetPreviousNotes());
            lobjCompanyAddressList = MapCompanyAddress(SPWrapper.GetCompanyAddress());
            lobjCompanyEventHistory = MapCompanyHistory(SPWrapper.GetCompanyHistory());


            if (pobjDS != null && pobjDS.Tables.Count > 0 && pobjDS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < pobjDS.Tables[0].Rows.Count; i++)
                {
                    Company lobjCompany = new Company
                    {
                        Address1 = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Address1]),
                        Address2 = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Address2]),

                        City = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.City]),
                        CompanyName = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.CompanyName]),
                        AllotedTo = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.AllotedTo]),
                        CreatedBy = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.CreatedBy]),
                        CreatedOn = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.CreatedOn]),

                        DateGiven = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.DateGiven]),


                        HiringArea = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.HiringArea]),
                        Id = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.Id]),
                        IsActive = Convert.ToBoolean(pobjDS.Tables[0].Rows[i][DBFields.IsActive]),
                        IsDeleted = Convert.ToBoolean(pobjDS.Tables[0].Rows[i][DBFields.IsDeleted]),

                        MTCorSTC = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.MTCorSTC]),

                        PlantorRegdOffice = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.PlantorRegdOffice]),
                        Remarks = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Remarks]),
                        ResearchSource = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.ResearchSource]),
                        Sector = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Sector]),

                        SubLocation = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.SubLocation]),
                        Summary = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Summary]),
                        SummerTraining = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.SummerTraining]),
                        ThirdParty = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.ThirdParty]),
                        ColorCode = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.ColorCode]),
                        TransferredFrom = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.TransferredFrom]),
                        UpdatedBy = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.UpdatedBy]),
                        UpdatedOn = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.UpdatedOn]),

                    };

                    //lobjCompany.CompanyExtraCallNotes = MapExtraCallNotes(SPWrapper.GetExtraCallNotesList(lobjCompany.Id));
                    //lobjCompany.CompanyExtraContacts = MapCompanyExtraContacts(SPWrapper.GetCompanyExtraContactsList(lobjCompany.Id));



                    lobjCompany.CallNoteList = lobjCallNoteList.Where(x => x.CompanyID == lobjCompany.Id).OrderByDescending(x => x.ActivityDate).Take(10).ToList();
                    if (lobjCallNoteList.Count > 0)
                        lobjCompany.FollowUpDate = lobjCallNoteList[0].ActivityDate.ToString("dd-MM-yyyy");
                    lobjCompany.CompanyContactList = lobjCompanyContactList.Where(x => x.CompanyID == lobjCompany.Id).ToList();
                    lobjCompany.CompanyContactList.Add(new CompanyContact { ContactName = "Others", ContactID = 0 });
                    lobjCompany.JobDescriptionList = lobjJobDescriptionList.Where(x => x.CompanyID == lobjCompany.Id).ToList();
                    lobjCompany.CompanyStreamList = lobjCompanyStreamList.Where(x => x.CompanyId == lobjCompany.Id).ToList();
                    lobjCompany.PastRecruitmentList = lobjPastRecruitmentList.Where(x => x.CompanyID == lobjCompany.Id).ToList();
                    lobjCompany.PastHiringList = lobjPastHiringList.Where(x => x.CompanyID == lobjCompany.Id).ToList();
                    lobjCompany.CompanyStatusList = lobjCompanyStatusList.Where(x => x.CompanyID == lobjCompany.Id).ToList();
                    //lobjCompany.MyStream = lobjstreamer;
                    //  lobjCompany.PreviousNotesList = lobjPreviousNotesList.ToList();
                    // lobjCompany.objCollegeMasterList = new SelectList(DataMapper.MapCollegeMaster(SPWrapper.GetCollegeMasters()).ToList().Select(m => new { m.Id, m.Name }).ToList(), "Id", "Name");
                    //lobjCompany.ddlSector = new SelectList(DataMapper.MapSectorMaster(SPWrapper.GetSectorMasters()).ToList().Select(m => new { m.Id, m.Name }).ToList(), "Id", "Name");
                    //lobjCompany.ddlcolor = new SelectList(Enum.GetValues(typeof(Color)).OfType<Color>().ToList());
                    lobjCompany.CompanyAddressList = lobjCompanyAddressList.Where(x => x.CompanyID == lobjCompany.Id).ToList();
                    lobjCompany.CompanyEventHistory = lobjCompanyEventHistory.Where(x => x.CompanyID == lobjCompany.Id).ToList();
                    lobjCompanyList.Add(lobjCompany);
                }
            }
            return lobjCompanyList;
        }


        public static List<Company> MapCompanyDataForListing(DataSet pobjDS)
        {
            List<Company> lobjCompanyList = new List<Company>();
            //List<CompanyStream> lobjCompanyStreamList = new List<CompanyStream>();
            List<CallNote> lobjCallNoteList = new List<CallNote>();
            //List<PreviousNotes> lobjPreviousNotesList = new List<PreviousNotes>();
            List<CompanyContact> lobjCompanyContactList = new List<CompanyContact>();
            //List<JobDescription> lobjJobDescriptionList = new List<JobDescription>();

            //List<PastRecruitment> lobjPastRecruitmentList = new List<PastRecruitment>();
            //List<PastHiring> lobjPastHiringList = new List<PastHiring>();
            //List<CompanyStatus> lobjCompanyStatusList = new List<CompanyStatus>();
            //List<Stream> lobjstreamer = new List<Stream>();
            //List<CompanyAddress> lobjCompanyAddressList = new List<CompanyAddress>();
            //List<EventHistory> lobjCompanyEventHistory = new List<EventHistory>();
            //List<ExtraCallNotes> lobjExtraCallNotes = new List<ExtraCallNotes>();
            //List<CompanyExtraContacts> lobjExtraContacts = new List<CompanyExtraContacts>();


            //lobjstreamer = DataMapper.MapStreamData(SPWrapper.GetStreamList());
            //lobjPastRecruitmentList = MapPastRecruitment(SPWrapper.GetPastRecruitment());
            //lobjPastHiringList = MapPastHiring(SPWrapper.GetPastHiring());
            //lobjCompanyStatusList = MapCompanystatus(SPWrapper.GetCompanystatus());
            //lobjCompanyStreamList = MapCompanyStream(SPWrapper.GetCompanyStream());
            lobjCallNoteList = MapCallNotesData(SPWrapper.GetCallNote());
            lobjCompanyContactList = MapCompanyContact(SPWrapper.GetCompanyContacts());
            //lobjJobDescriptionList = MapJobDescription(SPWrapper.GetJobDescription());
            //lobjPreviousNotesList = MapPreviousNotes(SPWrapper.GetPreviousNotes());
            //lobjCompanyAddressList = MapCompanyAddress(SPWrapper.GetCompanyAddress());
            //lobjCompanyEventHistory = MapCompanyHistory(SPWrapper.GetCompanyHistory());


            if (pobjDS != null && pobjDS.Tables.Count > 0 && pobjDS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < pobjDS.Tables[0].Rows.Count; i++)
                {
                    Company lobjCompany = new Company
                    {
                        Address1 = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Address1]),
                        Address2 = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Address2]),

                        City = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.City]),
                        CompanyName = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.CompanyName]),
                        AllotedTo = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.AllotedTo]),
                        CreatedBy = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.CreatedBy]),
                        CreatedOn = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.CreatedOn]),

                        DateGiven = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.DateGiven]),


                        HiringArea = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.HiringArea]),
                        Id = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.Id]),
                        IsActive = Convert.ToBoolean(pobjDS.Tables[0].Rows[i][DBFields.IsActive]),
                        IsDeleted = Convert.ToBoolean(pobjDS.Tables[0].Rows[i][DBFields.IsDeleted]),

                        MTCorSTC = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.MTCorSTC]),

                        PlantorRegdOffice = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.PlantorRegdOffice]),
                        Remarks = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Remarks]),
                        ResearchSource = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.ResearchSource]),
                        Sector = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Sector]),

                        SubLocation = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.SubLocation]),
                        Summary = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Summary]),
                        SummerTraining = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.SummerTraining]),
                        ThirdParty = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.ThirdParty]),
                        ColorCode = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.ColorCode]),
                        TransferredFrom = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.TransferredFrom]),
                        UpdatedBy = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.UpdatedBy]),
                        UpdatedOn = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.UpdatedOn]),


                    };

                    //lobjCompany.CompanyExtraCallNotes = MapExtraCallNotes(SPWrapper.GetExtraCallNotesList(lobjCompany.Id));
                    //lobjCompany.CompanyExtraContacts = MapCompanyExtraContacts(SPWrapper.GetCompanyExtraContactsList(lobjCompany.Id));



                    lobjCompany.CallNoteList = lobjCallNoteList.Where(x => x.CompanyID == lobjCompany.Id).OrderByDescending(x => x.ActivityDate).ToList();
                    lobjCompany.CompanyContactList = lobjCompanyContactList.Where(x => x.CompanyID == lobjCompany.Id).ToList();
                    //lobjCompany.CompanyContactList.Add(new CompanyContact { ContactName = "Others", ContactID = 0 });
                    //lobjCompany.JobDescriptionList = lobjJobDescriptionList.Where(x => x.CompanyID == lobjCompany.Id).ToList();
                    //lobjCompany.CompanyStreamList = lobjCompanyStreamList.Where(x => x.CompanyId == lobjCompany.Id).ToList();
                    //lobjCompany.PastRecruitmentList = lobjPastRecruitmentList.Where(x => x.CompanyID == lobjCompany.Id).ToList();
                    //lobjCompany.PastHiringList = lobjPastHiringList.Where(x => x.CompanyID == lobjCompany.Id).ToList();
                    //lobjCompany.CompanyStatusList = lobjCompanyStatusList.Where(x => x.CompanyID == lobjCompany.Id).ToList();
                    //lobjCompany.MyStream = lobjstreamer;
                    ////  lobjCompany.PreviousNotesList = lobjPreviousNotesList.ToList();
                    //lobjCompany.objCollegeMasterList = new SelectList(DataMapper.MapCollegeMaster(SPWrapper.GetCollegeMasters()).ToList().Select(m => new { m.Id, m.Name }).ToList(), "Id", "Name");
                    //lobjCompany.ddlSector = new SelectList(DataMapper.MapSectorMaster(SPWrapper.GetSectorMasters()).ToList().Select(m => new { m.Id, m.Name }).ToList(), "Id", "Name");
                    //lobjCompany.ddlcolor = new SelectList(Enum.GetValues(typeof(Color)).OfType<Color>().ToList());
                    //lobjCompany.CompanyAddressList = lobjCompanyAddressList.Where(x => x.CompanyID == lobjCompany.Id).ToList();
                    //lobjCompany.CompanyEventHistory = lobjCompanyEventHistory.Where(x => x.CompanyID == lobjCompany.Id).ToList();
                    lobjCompanyList.Add(lobjCompany);
                }
            }
            return lobjCompanyList;
        }

        public static List<Master> MapColorMaster(DataSet pobjDS)
        {
            List<Master> lobjMasterList = new List<Master>();
            if (pobjDS != null && pobjDS.Tables.Count > 0 && pobjDS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < pobjDS.Tables[0].Rows.Count; i++)
                {
                    Master lobjMaster = new Master
                    {
                        Id = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.Id]),
                        Description = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Description]),
                        Name = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Name])
                    };


                    lobjMasterList.Add(lobjMaster);
                }
            }
            return lobjMasterList;
        }

        public static List<Master> MapSectorMaster(DataSet pobjDS)
        {
            List<Master> lobjMasterList = new List<Master>();
            if (pobjDS != null && pobjDS.Tables.Count > 0 && pobjDS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < pobjDS.Tables[0].Rows.Count; i++)
                {
                    Master lobjMaster = new Master();
                    lobjMaster.Id = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.Id]);
                    lobjMaster.Name = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Name]);


                    lobjMasterList.Add(lobjMaster);
                }
            }
            return lobjMasterList;
        }


        public static List<EventMaster> MapCompanyEvent(DataSet pobjDS)
        {
            List<EventMaster> lobjMasterList = new List<EventMaster>();
            if (pobjDS != null && pobjDS.Tables.Count > 0 && pobjDS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < pobjDS.Tables[0].Rows.Count; i++)
                {
                    EventMaster lobjMaster = new EventMaster();
                    lobjMaster.EventId = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.EventId]);
                    lobjMaster.EventType = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.EventType]);



                    lobjMasterList.Add(lobjMaster);
                }
            }
            return lobjMasterList;
        }

        public static List<Master> MapCollegeMaster(DataSet pobjDS)
        {
            List<Master> lobjMasterList = new List<Master>();
            if (pobjDS != null && pobjDS.Tables.Count > 0 && pobjDS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < pobjDS.Tables[0].Rows.Count; i++)
                {
                    Master lobjMaster = new Master();
                    lobjMaster.Id = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.Id]);
                    lobjMaster.Location = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Location]);
                    lobjMaster.Name = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Name]);


                    lobjMasterList.Add(lobjMaster);
                }
            }
            return lobjMasterList;
        }

        public static List<EventHistory> MapCompanyHistory(DataSet pobjDS)
        {
            List<EventHistory> lobjCompanyContactList = new List<EventHistory>();
            if (pobjDS != null && pobjDS.Tables.Count > 0 && pobjDS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < pobjDS.Tables[0].Rows.Count; i++)
                {
                    EventHistory lobjCompanyContact = new EventHistory();
                    lobjCompanyContact.Id = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.Id]);
                    lobjCompanyContact.CompanyID = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.CompanyID]);
                    lobjCompanyContact.EventTypeId = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.EventTypeId]);
                    lobjCompanyContact.Status = Convert.ToBoolean(pobjDS.Tables[0].Rows[i][DBFields.Status]);
                    if (pobjDS.Tables[0].Rows[i][DBFields.EventDate] != DBNull.Value)
                    { lobjCompanyContact.EventDate = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.EventDate]); }
                    lobjCompanyContact.Description = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Description]);
                    lobjCompanyContact.CreatedBy = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.CreatedBy]);
                    lobjCompanyContact.CreatedOn = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.CreatedOn]);
                    lobjCompanyContact.UpdatedBy = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.UpdatedBy]);
                    lobjCompanyContact.UpdatedOn = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.UpdatedOn]);
                    lobjCompanyContact.ContactId = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.ContactId]);
                    lobjCompanyContact.Visitor = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Visitor]);
                    lobjCompanyContactList.Add(lobjCompanyContact);
                }
            }
            return lobjCompanyContactList;
        }
        public static List<PastRecruitment> MapPastRecruitment(DataSet pobjDS)
        {
            List<PastRecruitment> lobjCompanyContactList = new List<PastRecruitment>();
            if (pobjDS != null && pobjDS.Tables.Count > 0 && pobjDS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < pobjDS.Tables[0].Rows.Count; i++)
                {
                    PastRecruitment lobjCompanyContact = new PastRecruitment();
                    lobjCompanyContact.Id = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.Id]);
                    lobjCompanyContact.CompanyID = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.CompanyID]);
                    lobjCompanyContact.Code = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Code]);
                    lobjCompanyContact.RecuritYear = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.RecuritYear]);
                    lobjCompanyContact.CreatedBy = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.CreatedBy]);
                    lobjCompanyContact.CreatedOn = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.CreatedOn]);


                    lobjCompanyContact.UpdatedBy = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.UpdatedBy]);
                    lobjCompanyContact.UpdatedOn = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.UpdatedOn]);
                    lobjCompanyContactList.Add(lobjCompanyContact);
                }
            }
            return lobjCompanyContactList;
        }
        public static List<PastHiring> MapPastHiring(DataSet pobjDS)
        {
            List<PastHiring> lobjCompanyContactList = new List<PastHiring>();
            if (pobjDS != null && pobjDS.Tables.Count > 0 && pobjDS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < pobjDS.Tables[0].Rows.Count; i++)
                {
                    PastHiring lobjCompanyContact = new PastHiring();
                    lobjCompanyContact.Id = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.Id]);
                    lobjCompanyContact.CompanyID = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.CompanyID]);
                    lobjCompanyContact.CollegeCode = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.CollegeCode]);
                    lobjCompanyContact.CollegeId = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.CollegeId]);
                    lobjCompanyContact.Hiringyear = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Hiringyear]);
                    lobjCompanyContact.CreatedBy = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.CreatedBy]);
                    lobjCompanyContact.CreatedOn = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.CreatedOn]);
                    lobjCompanyContact.Remarks = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Remarks]);

                    lobjCompanyContact.UpdatedBy = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.UpdatedBy]);
                    lobjCompanyContact.UpdatedOn = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.UpdatedOn]);
                    lobjCompanyContactList.Add(lobjCompanyContact);
                }
            }
            return lobjCompanyContactList;
        }
        public static List<CompanyStatus> MapCompanystatus(DataSet pobjDS)
        {
            List<CompanyStatus> lobjCompanyContactList = new List<CompanyStatus>();
            if (pobjDS != null && pobjDS.Tables.Count > 0 && pobjDS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < pobjDS.Tables[0].Rows.Count; i++)
                {
                    CompanyStatus lobjCompanyContact = new CompanyStatus();
                    lobjCompanyContact.Id = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.Id]);
                    lobjCompanyContact.CompanyID = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.CompanyID]);
                    lobjCompanyContact.CompanyDescription = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.CompanyDescription]);
                    lobjCompanyContact.CompanyYear = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.CompanyYear]);
                    lobjCompanyContact.CreatedBy = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.CreatedBy]);
                    lobjCompanyContact.CreatedOn = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.CreatedOn]);


                    lobjCompanyContact.UpdatedBy = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.UpdatedBy]);
                    lobjCompanyContact.UpdatedOn = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.UpdatedOn]);
                    lobjCompanyContactList.Add(lobjCompanyContact);
                }
            }
            return lobjCompanyContactList;
        }

        public static List<CompanyStream> MapCompanyStream(DataSet pobjDS)
        {
            List<CompanyStream> lobjCompanyStreamList = new List<CompanyStream>();
            if (pobjDS != null && pobjDS.Tables.Count > 0 && pobjDS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < pobjDS.Tables[0].Rows.Count; i++)
                {
                    CompanyStream lobjCompanyStream = new CompanyStream();
                    lobjCompanyStream.Id = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.Id]);
                    lobjCompanyStream.CoursesId = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.CourseId]);
                    lobjCompanyStream.CompanyId = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.CompanyID]);
                    lobjCompanyStream.CourseName = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.CourseName]);
                    lobjCompanyStream.StreamId = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.t_StreamId]);
                    lobjCompanyStream.StreamName = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.StreamName]);
                    lobjCompanyStream.CreatedBy = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.CreatedBy]);
                    lobjCompanyStream.CreatedOn = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.CreatedOn]);

                    if (pobjDS.Tables[0].Rows[i][DBFields.PayPackageID] != DBNull.Value)
                    { lobjCompanyStream.PayPackageID = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.PayPackageID]); }

                    lobjCompanyStreamList.Add(lobjCompanyStream);
                }
            }
            return lobjCompanyStreamList;
        }


        public static List<CompanyAddress> MapCompanyAddress(DataSet pobjDS)
        {
            List<CompanyAddress> lobjCompanyAddressList = new List<CompanyAddress>();
            if (pobjDS != null && pobjDS.Tables.Count > 0 && pobjDS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < pobjDS.Tables[0].Rows.Count; i++)
                {
                    CompanyAddress lobjCompanyAddress = new CompanyAddress();
                    lobjCompanyAddress.Id = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.Id]);
                    lobjCompanyAddress.Title = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Title]);
                    lobjCompanyAddress.Address = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Address]);
                    lobjCompanyAddress.City = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.City]);
                    lobjCompanyAddress.CompanyID = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.CompanyID]);
                    lobjCompanyAddress.SubLocation = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.SubLocation]);
                    lobjCompanyAddress.IsActive = Convert.ToBoolean(pobjDS.Tables[0].Rows[i][DBFields.IsActive]);
                    lobjCompanyAddress.ContactNumber = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.ContactNumber]);
                    lobjCompanyAddressList.Add(lobjCompanyAddress);
                }
            }
            return lobjCompanyAddressList;
        }


        public static List<CityMaster> MapCity(DataSet pobjDS)
        {
            List<CityMaster> lobjCityMasterList = new List<CityMaster>();
            if (pobjDS != null && pobjDS.Tables.Count > 0 && pobjDS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < pobjDS.Tables[0].Rows.Count; i++)
                {
                    CityMaster lobjCityMaster = new CityMaster();
                    lobjCityMaster.Id = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.Id]);
                    lobjCityMaster.StateId = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.StateId]);
                    lobjCityMaster.City = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.City]);
                    lobjCityMasterList.Add(lobjCityMaster);
                }
            }
            return lobjCityMasterList;
        }
        public static List<CompanyDetails> MapCompany(DataSet pobjDS)
        {
            List<CompanyDetails> lobjCompanyMasterList = new List<CompanyDetails>();
            if (pobjDS != null && pobjDS.Tables.Count > 0 && pobjDS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < pobjDS.Tables[0].Rows.Count; i++)
                {
                    CompanyDetails lobjCompanyMaster = new CompanyDetails();
                    lobjCompanyMaster.Id = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.Id]);
                    lobjCompanyMaster.CompanyName = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.CompanyName]);

                    lobjCompanyMasterList.Add(lobjCompanyMaster);
                }
            }
            return lobjCompanyMasterList;
        }


        public static List<Sublocation> MapSubLocation(DataSet pobjDS)
        {
            List<Sublocation> lobjSublocationList = new List<Sublocation>();
            if (pobjDS != null && pobjDS.Tables.Count > 0 && pobjDS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < pobjDS.Tables[0].Rows.Count; i++)
                {
                    Sublocation lobjSublocation = new Sublocation();
                    lobjSublocation.Id = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.Id]);
                    lobjSublocation.SubLocation = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.SubLocation]);
                    lobjSublocation.CityId = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.CityId]);
                    lobjSublocationList.Add(lobjSublocation);
                }
            }
            return lobjSublocationList;
        }

        public static List<CompanyExtraContacts> MapCompanyExtraContacts(DataSet pobjDS)
        {
            List<CompanyExtraContacts> lobjMasterList = new List<CompanyExtraContacts>();
            if (pobjDS != null && pobjDS.Tables.Count > 0 && pobjDS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < pobjDS.Tables[0].Rows.Count; i++)
                {
                    CompanyExtraContacts lobjMaster = new CompanyExtraContacts
                    {
                        Id = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.Id]),
                        Value = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Value]),
                        CompanyId = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.CompanyID])
                    };


                    lobjMasterList.Add(lobjMaster);
                }
            }
            return lobjMasterList;
        }
        public static List<ExtraCallNotes> MapExtraCallNotes(DataSet pobjDS)
        {
            List<ExtraCallNotes> lobjMasterList = new List<ExtraCallNotes>();
            if (pobjDS != null && pobjDS.Tables.Count > 0 && pobjDS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < pobjDS.Tables[0].Rows.Count; i++)
                {
                    ExtraCallNotes lobjMaster = new ExtraCallNotes
                    {

                        ActivityDate = pobjDS.Tables[0].Rows[i][DBFields.ActivityDate] != DBNull.Value ? Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.ActivityDate]) : DateTime.MinValue,


                        CreatedOn = pobjDS.Tables[0].Rows[i][DBFields.CreatedOn] != DBNull.Value ? Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.CreatedOn]) : DateTime.MinValue,

                        Id = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.Id]),

                        Value = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Value]),
                    };


                    lobjMasterList.Add(lobjMaster);
                }
            }
            return lobjMasterList;
        }

        public static List<Master> MapCommonMaster(DataSet pobjDS)
        {
            List<Master> lobjMasterList = new List<Master>();
            if (pobjDS != null && pobjDS.Tables.Count > 0 && pobjDS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < pobjDS.Tables[0].Rows.Count; i++)
                {
                    Master lobjMaster = new Master();
                    lobjMaster.Id = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.Id]);
                    lobjMaster.Name = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Name]);


                    lobjMasterList.Add(lobjMaster);
                }
            }
            return lobjMasterList;
        }

        internal static List<ThirdParty> MapThirdPartylist(DataSet pobjDS)
        {
            List<ThirdParty> lobjThirdParty = new List<ThirdParty>();
            if (pobjDS != null && pobjDS.Tables.Count > 0 && pobjDS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < pobjDS.Tables[0].Rows.Count; i++)
                {
                    ThirdParty thirdParty = new ThirdParty();
                    thirdParty.Id = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.Id]);
                    thirdParty.Name = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Name]);
                    //thirdParty.Status = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Status]);


                    lobjThirdParty.Add(thirdParty);
                }
            }
            return lobjThirdParty;
        }

        internal static List<ThirdParty> MapThirdPartyData(DataSet pobjDS)
        {
            List<ThirdParty> lobjThirdPartyList = new List<ThirdParty>();
            if (pobjDS != null && pobjDS.Tables.Count > 0 && pobjDS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < pobjDS.Tables[0].Rows.Count; i++)
                {
                    ThirdParty lobjThirdParty = new ThirdParty();
                    lobjThirdParty.Id = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.Id]);
                    lobjThirdParty.Name = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.Name]);
                    lobjThirdPartyList.Add(lobjThirdParty);
                }
            }
            return lobjThirdPartyList;
        }
        internal static List<Payroll> MapPayrollData(DataSet pobjDS)
        {
            List<Payroll> lobjPayrollList = new List<Payroll>();
            if (pobjDS != null && pobjDS.Tables.Count > 0 && pobjDS.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < pobjDS.Tables[0].Rows.Count; i++)
                {
                    Payroll lobjPayroll = new Payroll();
                    lobjPayroll.Id = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.Id]);
                    lobjPayroll.EmployeeId =  pobjDS.Tables[0].Rows[i][DBFields.EmployeeId].ToString();
                    lobjPayroll.CompanyId = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.CompanyId]);
                    lobjPayroll.CompanyName = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.CompanyName]);
                    lobjPayroll.EmployeeName = Convert.ToString(pobjDS.Tables[0].Rows[i][DBFields.EmployeeName]);
                    lobjPayroll.CreatedOn = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.CreatedOn]);
                    lobjPayroll.CreatedBy = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.CreatedBy]);
                    lobjPayroll.UpdatedOn = Convert.ToDateTime(pobjDS.Tables[0].Rows[i][DBFields.UpdatedOn]);
                    lobjPayroll.UpdatedBy = Convert.ToInt32(pobjDS.Tables[0].Rows[i][DBFields.UpdatedBy]);

                    lobjPayrollList.Add(lobjPayroll);
                }
            }
            return lobjPayrollList;
        }
    }
}