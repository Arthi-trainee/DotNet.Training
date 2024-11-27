

use Sql_1
select *from Book          --1.fetching details of books  where author name ends with er
where author like '%er'

select b.title,b.author,r.reviewer_name           -----2.displaying title ,author,reviewer name 
from Book b join reviews r
on  b.id=r.book_id


select reviewer_name from Reviews               -- 3.reviewe name who reviewed more than one book
where book_id is not null
group by reviewer_name
having count(distinct book_id)>1

select lower(Ename) as Employee_name                  --3.query for fetching employee names in lower case whose salary is null
 from employee
 where salary is null

 select Ename from Employee                            --4.query to fetch whose address have o
 where addres like'%o%'

 SELECT Date, COUNT(CUSTOMER_ID) AS TotalCustomers FROM Orders GROUP BY Date;  ---- 4.displaying no of customers and date

select gender,count(*) as Total_count                   ---5.query to display no of males and female employees
from Student_details
group by gender

                            -----------------Book----------------
create table Book
(
id int primary key,
title varchar(20) ,
author varchar(20),
isbn int,
published_date datetime
)
alter table Book
alter column isbn float 
alter table Book
alter column isbn float not null 

insert into Book values
(1,'My First SQL book','Mary Parker',981483029127,'2019-02-22'),
(2,'My Second SQL book','John Maryer',857300923713,'1972-07-03'),
(3,'My Third SQL book','Cary Flint',523120967812,'2015-10-18')



                                           ----------REVIEWs--------------
create table Reviews
(
id int references Book(Id),
book_id int not null,
reviewer_name varchar(30) not null,
content varchar(30) not null,
rating int not null,
published_date date,
)
 
 insert into reviews values
(1,1,'John Smith','My first review',4,'2017-12-10'),
(2,2,'John Smith','My second review',5,'2017-10-13'),
(3,2,'Alice Walker','Another review',1,'2017-10-22')
 



                                                -----Employee table-----------------------

create table Employee
(
Id int not null,
Ename varchar(20) not null,
Age int not null,
Addres varchar(20) not null,
Salary int
)
 

insert into Employee values                                -- inserting values into Employee
 (1,'Ramesh',32,'Ahmedabad',2000.00),
(2,'Khilan',25,'Delhi',1500.00),
(3,'Kaushik',23,'Kota',2000.00),
(4,'Chaitali',25,'Mumbai',6500.00),
(5,'Hardik',27,'Bhopal',8500.00),
(6,'Komal',22,'MP',null),
(7,'Muffy',24,'Indore',null)
 
 

                                 -----Customers and Orders table--------------
create table CUSTOMERS (
    ID int primary key,
    NAME varchar(20),
    AGE int,
    ADDRESS varchar(30),
    SALARY float
)

create table Employees
(
Id int not null,
Ename varchar(20) not null,
Age int not null,
Addres varchar(20) not null,
Salary int
)
 

insert into Employees values                                -- inserting values into Employee
 (1,'Ramesh',32,'Ahmedabad',2000.00),
(2,'Khilan',25,'Delhi',1500.00),
(3,'Kaushik',23,'Kota',2000.00),
(4,'Chaitali',25,'Mumbai',6500.00),
(5,'Hardik',27,'Bhopal',8500.00),
(6,'Komal',22,'MP',12000),
(7,'Muffy',24,'Indore',600)
                                          ----CUSTOMERS & ORDERS -------------
insert into CUSTOMERS VALUES
(1,'Ramesh', 32, 'Ahmedabad', 2000.00),
(2,'Khilan', 25, 'Delhi', 1500.00),
(3,'Kaushik', 23, 'Kota', 2000.00),
(4,'Chaitali', 25, 'Mumbai', 6500.00),
(5,'Hardik', 27, 'Bhopal', 8500.00),
(6,'Komal', 22, 'MP', 4500.00),
(7,'Muffy', 24, 'Indore', 10000.00);

 

create table ORDERS
( OID int, DATE varchar(20),
CUSTOMER_ID int, AMOUNT int, 
foreign key(CUSTOMER_ID) references CUSTOMERS(id) )

insert into ORDERS 
values(102,'2009-10-08 00:00:00',3,3000),
(100,'2009-10-08 00:00:00',3,1500), (101,'2009-11-20 00:00:00',2,1560), 
(103,'2008-05-20 00:00:00',4,2060) 


	
	
                          ------------student details-------
create table Student_details                     -- creating table called Student_details
(
Register_no int primary key,
Name varchar(30) not null,
Age int not null,
Qualification varchar(20),
Mobile_no float not null,
Mail_id varchar(30),
locationn varchar(30),
Gender varchar(1)
)
 

insert into Student_details values                     -- inserting values into Student_details
(2,'Sai',22,'B.E',9952836779,'sai@gmail,com','Chennai','M'),
(3,'Kumar',20,'BSC',7252836779,'kumar@gmail,com','Madurai','M'),
(4,'Selvi',22,'B.TECH',8952836779,'selvi@gmail,com','Selam','F'),
(5,'Nisha',25,'M.E',6352836779,'nisha@gmail,com','Theni','F'),
(6,'SaiSaran',21,'B.A',9865836779,'saisaran@gmail,com','Madurai','F'),
(7,'Tom',23,'BCA',6552836779,'tom@gmail,com','Pune','M')




