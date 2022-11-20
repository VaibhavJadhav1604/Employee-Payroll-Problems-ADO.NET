use Ado_Payroll_Service

create table Employee
(
EmployeeID int primary key identity,
EmployeeName varchar(255),
PhoneNumber varchar(255),
Address varchar(255),
Department varchar(255),
Gender char(1),
BasicPay float,
Deductions float,
TaxablePay float,
Tax float,
NetPay float,
StartDate Date,
City varchar(255),
Country varchar(255)
)
Insert Into Employee values('Oggy',987654321,'Sangvi','HR','M',15000,200,100,100,200,'2019/08/12','Pune','India')
Insert Into Employee values('Jack',123456789,'Sangmeshwar','Sales','M',20000,300,200,200,300,'2019/12/08','Noida','India')
Insert Into Employee values('Terrisa',789654123,'Juhu','Finance','F',10000,200,100,100,200,'2019/03/10','Kolhapur','India')
select * from Employee

--ForUC3--
Create Procedure UpdateSalaryProcedure
(
@EmployeeId int,
@EmployeeName varchar(255),
@BasicPay float
)
As
Begin
Update Employee
Set BasicPay=@BasicPay where EmployeeID=@EmployeeId AND EmployeeName=@EmployeeName
End

--ForRefactor_UC4--
Create Procedure UpdateSalaryProcedure_ByName
(
@EmployeeName varchar(255),
@BasicPay float
)
As
Begin
Update Employee
Set BasicPay=@BasicPay where EmployeeName=@EmployeeName
End

--ForUC5--
Create Procedure EmployeeBetweenDates
(
@SDate Date,
@EDate Date
)
As
Begin
select * from Employee where StartDate Between CAST(@SDate AS DATE) And CAST(@EDate AS DATE)
End
