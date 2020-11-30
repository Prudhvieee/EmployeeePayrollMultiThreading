using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeePayrollMultiThreading
{
    public class EmployeePayrollRepo
    {
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PayrollService;Integrated Security=True";
        SqlConnection sqlconnection = new SqlConnection(connectionString);
         public List<EmployyeePayrollModel> employeePayrollList = new List<EmployyeePayrollModel>();
        public bool AddEmployee(EmployyeePayrollModel employyeePayrollModel)
        {
            try
            {
                using (this.sqlconnection)
                {
                    SqlCommand sqlCommand = new SqlCommand("AddEmployee", this.sqlconnection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue("@id", employyeePayrollModel.id);
                    sqlCommand.Parameters.AddWithValue("@Name", employyeePayrollModel.Name);
                    sqlCommand.Parameters.AddWithValue("@salary", employyeePayrollModel.salary);
                    sqlCommand.Parameters.AddWithValue("@Start_Date", employyeePayrollModel.Start_Date);
                    sqlCommand.Parameters.AddWithValue("@Gender", employyeePayrollModel.Gender);
                    sqlCommand.Parameters.AddWithValue("@Employee_Address", employyeePayrollModel.Employee_Address);
                    sqlCommand.Parameters.AddWithValue("@Department", employyeePayrollModel.Department);
                    sqlCommand.Parameters.AddWithValue("@Phone_Number", employyeePayrollModel.Phone_Number);
                    sqlCommand.Parameters.AddWithValue("@Basic_Pay", employyeePayrollModel.Basic_Pay);
                    sqlCommand.Parameters.AddWithValue("@Deductions", employyeePayrollModel.Deductions);
                    sqlCommand.Parameters.AddWithValue("@Taxable_Pay", employyeePayrollModel.Taxable_Pay);
                    sqlCommand.Parameters.AddWithValue("@Income_Tax", employyeePayrollModel.Income_Tax);
                    sqlCommand.Parameters.AddWithValue("@Net_Pay", employyeePayrollModel.Net_Pay);
                    this.sqlconnection.Open();
                    var result = sqlCommand.ExecuteNonQuery();
                    this.sqlconnection.Close();
                    if (result != 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                this.sqlconnection.Close();
            }
            return false;
        }
        public void AddEmployeeListToEmployeePayrollDataBase(List<EmployyeePayrollModel> employeeModelList)
        {
            employeeModelList.ForEach(employeeData =>
            {
                Console.WriteLine("Employee being added: " + employeeData.Name);
                this.AddEmployee(employeeData);
                Console.WriteLine("Employee added: " + employeeData.Name);
            });
            Console.WriteLine(this.employeePayrollList.ToString());
        }
        public void AddMultipleEmployeeUsingThread(List<EmployyeePayrollModel> employeeModelList)
        {
            employeeModelList.ForEach(employeeData =>
            {
                Task task = new Task(() =>
                {
                    Console.WriteLine("Employee being added: " + employeeData.Name);
                    Console.WriteLine("Current thread Id: " + Thread.CurrentThread.ManagedThreadId);
                    this.AddEmployee(employeeData);
                    Console.WriteLine("Employee Added:  " + employeeData.Name);
                });
                task.Start();
            });
        }
    }
}
