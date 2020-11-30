using System;
using System.Net;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace EmployeeePayrollMultiThreading
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to employee payroll multi threading");
            List<EmployyeePayrollModel> employeeList = new List<EmployyeePayrollModel>();
            employeeList.Add(new EmployyeePayrollModel { Name = "Priya", Start_Date = new System.DateTime(2018 - 08 - 12), Gender = 'F', Employee_Address = "Vasai", Department = "Sales", Phone_Number = "7894586954", Basic_Pay = 10000, Deductions = 500, Taxable_Pay = 500, Income_Tax = 500, Net_Pay = 11500 });
            employeeList.Add(new EmployyeePayrollModel { Name = "prudhvi", Start_Date = new System.DateTime(2020 - 04 - 22), Gender = 'M', Employee_Address = "Delhi", Department = "Delivery", Phone_Number = "8547253695", Basic_Pay = 11000, Deductions = 500, Taxable_Pay = 500, Income_Tax = 500, Net_Pay = 12500 });
            employeeList.Add(new EmployyeePayrollModel { Name = "sanjana", Start_Date = new System.DateTime(2019 - 12 - 11), Gender = 'F', Employee_Address = "Mumbai", Department = "HR", Phone_Number = "9856320124", Basic_Pay = 12000, Deductions = 500, Taxable_Pay = 500, Income_Tax = 500, Net_Pay = 13500 });
            employeeList.Add(new EmployyeePayrollModel { Name = "Ravi", Start_Date = new System.DateTime(2018 - 07 - 08), Gender = 'M', Employee_Address = "Bangalore", Department = "Operations", Phone_Number = "7855496315", Basic_Pay = 9000, Deductions = 500, Taxable_Pay = 500, Income_Tax = 500, Net_Pay = 10500 });
            employeeList.Add(new EmployyeePayrollModel { Name = "jennifer", Start_Date = new System.DateTime(2019 - 08 - 17), Gender = 'F', Employee_Address = "Chennai", Department = "Sales", Phone_Number = "8456903257", Basic_Pay = 10000, Deductions = 500, Taxable_Pay = 500, Income_Tax = 500, Net_Pay = 11500 });

            EmployeePayrollRepo employeePayrollRepo = new EmployeePayrollRepo();

            DateTime startTime = DateTime.Now;
            employeePayrollRepo.AddMultipleEmployeeUsingThread(employeeList);
            DateTime endTime = DateTime.Now;
            Console.WriteLine("Duration with thread: " + (startTime - endTime));
        }
    }
}
