using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeePayrollMultiThreading
{
    public class EmployyeePayrollModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public decimal salary { get; set; }
        public DateTime Start_Date { get; set; }
        public char Gender { get; set; }
        public string Employee_Address { get; set; }
        public string Department { get; set; }
        public string Phone_Number { get; set; }
        public decimal Basic_Pay { get; set; }
        public decimal Deductions { get; set; }
        public decimal Taxable_Pay { get; set; }
        public decimal Income_Tax { get; set; }
        public decimal Net_Pay { get; set; }
    }
}
