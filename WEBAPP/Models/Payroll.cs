using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEBAPP.Models
{
    public class Payroll
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public int CompanyId { get; set; }
        public int DesignationId { get; set; }
        public decimal WorkingDays { get; set; }
        public decimal LeaveDays { get; set; }
        public decimal OvertimeDays { get; set; }
        public decimal PaidLeaveDays { get; set; }
        public decimal TotalWorkingDays { get; set; }
        public decimal SalaryAmount { get; set; }
        public decimal GrossSalaryAmount { get; set; }
        public decimal DeductionAmount { get; set; }
        public string DeductionDetails { get; set; }
        public decimal IncentiveAmount { get; set; }
        public decimal AdvancePaidAmount { get; set; }
        public decimal AdvanceDeductedAmount { get; set; }
        public decimal AdditionalPaidAmount { get; set; }
        public decimal AdditionalDeductedAmount { get; set; }
        public string AdditionalPaidDetails { get; set; }
        public string AdditionalDeductedDetails { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal NetSalaryAmount { get; set; }
        
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public SelectList DDLUser { get; set; }
        public SelectList DDLCompany { get; set; }
        public string CompanyName { get; set; }
        public string EmployeeName { get; set; }
    }
}