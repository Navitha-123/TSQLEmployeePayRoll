using System;
using TSQLEmployeePayRollManagement;

namespace EmployeePayrollTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenSalaryDetailsAbleToUpdate()
        {
            Salary salary = new Salary();
            SalaryUpdateModel salaryUpdateModel = new SalaryUpdateModel();
            {
                int SalaryId = 3,
                Month = 'F',
                EmployeeSalary = 30000,
                EmployeeId = 3;
                    
            }
            //Act
            int EmpSalary = salary.UpdateEmployeeSalary(salaryUpdateModel);
            //Assert
            Assert.AreEqual(salaryUpdateModel.EmployeeSalary,EmpSalary);    
        }
    }
}