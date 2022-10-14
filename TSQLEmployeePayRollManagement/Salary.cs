using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSQLEmployeePayRollManagement
{
    public class Salary
    {
        private static SqlConnection ConnectionSetup()
        {
            return new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=EmployeeManagement;Integrated Security=True");

        }

        public int UpdateEmployeeSalary(SalaryUpdateModel salaryUpdateModel)
        {
            SqlConnection sqlConnection = ConnectionSetup();
            int Salary = 0;
            try
            {
                using (sqlConnection)
                {
                    SalaryDetailedModel salaryDetailedModel = new SalaryDetailedModel();
                    SqlCommand command = new SqlCommand("SpUpdateEmployeeSalary", sqlConnection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Id", salaryUpdateModel.SalaryId);
                    command.Parameters.AddWithValue("@Month", salaryUpdateModel.Month);
                    command.Parameters.AddWithValue("@Salary", salaryUpdateModel.EmployeeSalary);
                    command.Parameters.AddWithValue("@EmpId", salaryUpdateModel.EmployeeId);
                    sqlConnection.Open();
                    SqlDataReader reader = command.ExecuteReader(); 
                    if(reader.HasRows)
                    {
                        while(reader.Read())
                        {
                            salaryDetailedModel.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                            salaryDetailedModel.EmployeeName = reader["EmployeeName"].ToString();
                            salaryDetailedModel.Jobdescription = reader["jobdescription"].ToString();
                            salaryDetailedModel.Month = reader["Month"].ToString();
                            salaryDetailedModel.Employeesalary = Convert.ToInt32(reader["EmployeeID"]);
                            salaryDetailedModel.SalaryyId = Convert.ToInt32(reader["EmployeeID"]);
                            Console.WriteLine("{0} {1} {2} {3} {4} {5} ", salaryDetailedModel.EmployeeID, salaryDetailedModel.EmployeeName, salaryDetailedModel.Jobdescription, salaryDetailedModel.Month, salaryDetailedModel.Employeesalary, salaryDetailedModel.SalaryyId);
                            Salary = salaryDetailedModel.Employeesalary;
                                

                        }
                    }
                    else
                    {
                        Console.WriteLine("Dta not found");
                    }
                    sqlConnection.Close();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
            return Salary;
        }
    }
}
