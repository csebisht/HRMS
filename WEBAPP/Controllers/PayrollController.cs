using Microsoft.AspNet.Identity;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WEBAPP.DAL;
using WEBAPP.Models;

namespace WEBAPP.Controllers
{
    public class PayrollController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Payroll
        public ActionResult Index()
        {
            return View(DataMapper.MapPayrollData(SPWrapper.GetPayrollData()));
        }

        // GET: Payroll/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payroll payroll = DataMapper.MapPayrollData(SPWrapper.GetPayrollData()).Find(m => m.Id == id);

            if (payroll == null)
            {
                return HttpNotFound();
            }
            return View(payroll);
        }

        // GET: Payroll/Create
        public ActionResult Create()
        {
            Payroll payroll = new Payroll();
            var Username = User.Identity.GetUserName();
            payroll.DDLCompany = new SelectList(DataMapper.MapCompanyData(SPWrapper.GetCompanyList()).Where(x => x.IsDeleted == false).ToList(), "Id", "CompanyName");
            payroll.DDLUser = new SelectList(DataMapper.MapUserData(SPWrapper.GetUserList()), "Id", "FirstName");
            return View(payroll);
        }

        // POST: Payroll/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployeeId,CompanyId,DesignationId,WorkingDays,LeaveDays,OvertimeDays,PaidLeaveDays,TotalWorkingDays,SalaryAmount,GrossSalaryAmount,DeductionAmount,DeductionDetails,IncentiveAmount,AdvancePaidAmount,AdvanceDeductedAmount,AdditionalPaidAmount,AdditionalDeductedAmount,AdditionalPaidDetails,AdditionalDeductedDetails,Month,Year,NetSalaryAmount,CreatedOn,UpdatedOn,CreatedBy,UpdatedBy")] Payroll payroll)
        {
            if (ModelState.IsValid)
            {
                SPWrapper.AddPayroll(payroll);

                return RedirectToAction("Index");
            }

            return View(payroll);
        }

        // GET: Payroll/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payroll payroll = DataMapper.MapPayrollData(SPWrapper.GetPayrollData()).Find(m => m.Id == id);
            var Username = User.Identity.GetUserName();
            payroll.DDLCompany = new SelectList(DataMapper.MapCompanyData(SPWrapper.GetCompanyList()).Where(x => x.IsDeleted == false).ToList(), "Id", "CompanyName");
            payroll.DDLUser = new SelectList(DataMapper.MapUserData(SPWrapper.GetUserList()), "Id", "FirstName");
            if (payroll == null)
            {
                return HttpNotFound();
            }
            return View(payroll);
        }

        // POST: Payroll/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeId,CompanyId,DesignationId,WorkingDays,LeaveDays,OvertimeDays,PaidLeaveDays,TotalWorkingDays,SalaryAmount,GrossSalaryAmount,DeductionAmount,DeductionDetails,IncentiveAmount,AdvancePaidAmount,AdvanceDeductedAmount,AdditionalPaidAmount,AdditionalDeductedAmount,AdditionalPaidDetails,AdditionalDeductedDetails,Month,Year,NetSalaryAmount,CreatedOn,UpdatedOn,CreatedBy,UpdatedBy")] Payroll payroll)
        {
            if (ModelState.IsValid)
            {
                SPWrapper.UpdatePayroll(payroll);
                return RedirectToAction("Index");
            }
            return View(payroll);
        }

        // GET: Payroll/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payroll payroll = DataMapper.MapPayrollData(SPWrapper.GetPayrollData()).Find(m => m.Id == id);

            if (payroll == null)
            {
                return HttpNotFound();
            }
            return View(payroll);
        }

        // POST: Payroll/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Payroll payroll = db.Payrolls.Find(id);
            db.Payrolls.Remove(payroll);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
