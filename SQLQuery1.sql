create database EmployeeManagement
create table EmployeePayrollservice1
(
    Id int primary key identity,
	Name varchar(200),
	Salary int,
	StartDate Date
);

-----uc3 intsert data--------
insert into EmployeePayrollservice1(Name,Salary,StartDate)values
                                                 ('navitha',10000,GETDATE()),
												 ('Devi',20000,GETDATE()),
												 ('Madhu',40000,GETDATE()),
												 ('kiran',35000,GETDATE()),
												 ('Akshara',45000,GETDATE()),
												 ('Aditya',85000,GETDATE())
create table Salary
(
   SalaryId int primary key identity,
	EmployeeId int,
	EmployeeName varchar(200),
	Jobdescription varchar(200),
	Month varchar(50),
	Employeesalary int

)
select * from EmployeeManagement
select * from Salary

insert into Salary values(1,'Rye','HR',15000)
insert into Salary values (2,'John','manager',20000)
insert into Salary values(3,'Sam','HR',30000)

create procedure SpUpdateEmployeeSalary
(
  @Id int,
  @Month varchar(10),
  @Salary int,
  @EmpId int 
)
as
begin
        update Salary
		set Employeesalary = @Salary where SalaryId = @id and Month = @Month and EmployeeId = @EmpId
		select e.EmployeeID,e.EmployeeName,s.Jobdescription,s.EmployeeSalary,s.Month,s.SalaryId
		from EmployeePayrollservice1 e.inner join Salary.s on e.EmloyeeId=s.EmployeeId where s.SalaryId = @id