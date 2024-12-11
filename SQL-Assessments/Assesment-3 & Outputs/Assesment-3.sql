create database Assesment_3
use Assesment_3


create function Course_duration_in_days          --1.function creation for calculating duration in days
(
@Start_Date date,
@End_Date date
)
returns int 
as
begin
return Datediff(day,@start_Date,@End_Date)  
end

select C_id,C_Name, dbo.Course_duration_in_days(Start_Date,End_Date )as [course_duration_in_Dayss]
from  CourseDetails;
------------------------------------------------------------------------------------------------------------------------------------------------------------------

create trigger Update_in_T_courseInfo   ---2.creating a trigger which modifies in t_CourseInfo
on CourseDetails
after insert
as
begin
Insert into T_CourseInfo(C_Name,Start_Date)
select C_Name,Start_Date from inserted;
end

insert into CourseDetails values('1234','Assesment-3','2024-10-16','2025-01-17',7000)   --Checking the updation in T_courseInfpo table
select*from T_CourseInfo;

-------------------------------------------------------------------------------------------------------------------------------------------------------------
create or alter proc update_id @Prod_Name varchar(30), @Prod_Price float    --3.Creation of a procedure   for product table
as
begin
    declare @id int;
	insert into ProductsDetails(ProductName, Price) values (@Prod_Name,@Prod_price);
	select @id=ProductId from ProductsDetails where ProductName=@Prod_Name and Price=@prod_Price;
	return @id;
end

select * from ProductsDetails;




---------------------------------------All Tables Creation-----------------------------------------------------------------------

create table ProductDetails
(
productId int primary key,
ProductName varchar(15),
price float,
DiscountedPrice as  (price-(price*0.1)));




create table T_CourseInfo
(
C_Name varchar(15),
Start_Date Date
)


create table CourseDetails
(
C_id varchar(15) primary key,
C_Name varchar(20) ,
Start_date Date,
End_date Date,
fee int
)

insert into CourseDetails 
values('DN003','DotNet','2018-02-01','2018-02-28',15000),
       ('DV004','DataVisualization','2018-03-01','2018-04-15',15000),
	   ('JA002','AdvancedJava','2018-01-02','2018-01-12',10000),
	   ('JC001','CoreJava','2018-01-02','2018-01-12',3000);

