create database Assignment_5
use Assignment_5

create or alter proc PaySlip(@EmpId int)                        --1.Payslip 
as
begin
declare @Ename varchar(20),@Sal int
declare @HRA float
declare @DA float
declare @PF float
declare @IT float
declare @Deduction float
declare @Gross_Salary float
declare @Net_Salary float
select @Ename=EName,@Sal=Sal from Emp where EmpNo=@EmpId
set @HRA=@sal*0.10   --HRA as 10% of salary
set @DA=@sal*0.20    --DA as 20 % of salary
set @PF=@sal*0.08    --PF as 8% of salary
set @IT=@sal*0.05    --IT as 5% of salary
set @Deduction=@PF+@IT  --Deductions as sum of PF and IT
set @Gross_Salary=@sal+@HRA+@DA --Gross Salary as sum of Salary, HRA, DA
set @Net_Salary=@Gross_Salary-@Deduction--Net Salary as Gross Salary - Deductions

print 'Payslip for Employee : ' +@Ename
print 'Basic Salary : '+cast(@Sal as varchar(10))
print 'HRA : ' +cast(@HRA as varchar(10))
print 'DA : ' +cast(@DA as varchar(10))
print 'PF : ' +cast(@PF as varchar(10))
print 'IT : ' +cast(@IT as varchar(10))
print 'Deduction : ' +cast(@Deduction as varchar(10))
print 'Gross salary : ' +cast(@Gross_Salary as varchar(10))
print 'Net salary : ' +cast(@Net_Salary as varchar(10))
end
exec PaySlip 7369




CREATE TABLE Holidays (                     ---2.HOLIDAYS TABLE
    holiday_date DATE PRIMARY KEY,
    holiday_name VARCHAR(20) NOT NULL
);
INSERT INTO Holidays (holiday_date, holiday_name) VALUES
('2024-01-26', 'Republic Day'),
('2024-03-29', 'Holi'),
('2024-08-15', 'Independence Day'),
('2024-11-12', 'Diwali');
insert into holidays values('2024-12-06','Holiday');
CREATE or alter TRIGGER RestrictManipulationOnHolidays
ON Emp
for insert,update,delete
as
BEGIN
    DECLARE @holiday_name VARCHAR(20);
	declare @current_date date = cast(getdate() as date)
    SELECT @holiday_name =holiday_name
    FROM Holidays
    WHERE holiday_date = @current_date;
    IF @holiday_name IS NOT NULL
	begin
        raiserror('Data manipulation is restricted due to %s',16,1, @holiday_name)
		rollback transaction
    END 
END
update Emp set ename='Arthitej' where EmpNo=7067
select * from emp