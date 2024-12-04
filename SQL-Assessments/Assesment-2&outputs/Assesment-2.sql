create database SQl_Assesment_2
use  SQl_Assesment_2
                              ----QUERIES---------
select DATENAME(weekday,'20-SEP-2003') as Arthi_Birthday     --1.finding my day (Date of birth)


select DATEDIFF(DAY,'20-SEP-2003',getdate()) as Arthi_age    --2.finding my age(based on Date of birth)


select *                                                    --3.dispalying all details of employees who has joined before 5 years
from emp
where Hiredate <=DATEADD(year,-5,getdate()) and month(Hiredate)=month(getdate())  



Begin transaction                                           --4.creating employee table and performing all opearations in one transaction                                          
insert into Employee 
values(1,'Arthi',6000,'16-OCT-2000'),
       (2,'Teja',6300,'13-sep-2009'),
	   (3,'Tarun',6500,'20-mar-2020'),
	   (4,'siva',6900,'16-jul-2000')

update employee 
set sal=sal+(sal*0.15)
where empno=2

delete from employee 
where empno=1

rollback

commit
   

create Function Calculate_Bonus                 -- 5.creating a function calcuLATE BONUS AND performing the inceremental bonus
(
  @deptno int,
  @sal decimal(18,2)
  )
  returns decimal(18,2)
  as 
  begin
  declare @Bonus float;
  if  @deptno=10
     set  @bonus=@sal*0.15;
  else if @deptno=20
     set @bonus=@sal*0.20;
  else
       set @bonus=@sal*0.05;
  return @bonus;
  end;

     select empno, ename,dbo.Calculate_Bonus(deptno,sal) as BONUS from emp     ---calling bonus function


  create procedure  Sal_update_in_Sales_dept                    --6.creating a procedure and performing updations
  as
  begin
    update emp
    set sal=sal+500
	where deptno=(select deptno from dept where dname='SALES') and sal<1500
  end

  Exec Sal_update_in_Sales_dept
  select *from emp

         ---------------TABLE CREATIONS-------------------



create table EMP                    --Creating emp table
(
Empno int primary key,
Ename varchar(50),
job varchar(50),
Mgr_id int ,
Hiredate date ,
Sal int ,
Comm int,
Deptno int references DEPT(Deptno)
)

insert into EMP
values (7369, 'SMITH', 'CLERK', 7902, '17-DEC-80' , 800 ,null ,20),
	   (7499,'ALLEN','SALESMAN',7698, '20-FEB-81', 1600,300 ,30),
		(7521, 'WARD', 'SALESMAN', 7698, '22-FEB-81', 1250, 500 , 30),
		(7566, 'JONES', 'MANAGER', 7839, '02-APR-81', 2975,null, 20),
		(7654, 'MARTIN', 'SALESMAN', 7698, '28-SEP-81', 1250,1400, 30),
		(7698, 'BLAKE','MANAGER',7839, '01-MAY-81', 2850 ,null,30),
		(7782, 'CLARK','MANAGER', 7839, '09-JUN-81', 2450 ,null, 10),
		(7788,'SCOTT','ANALYST', 7566 ,'19-APR-87',3000, null, 20),
		(7839, 'KING','PRESIDENT',null,'17-NOV-81',5000 ,null,10),
		(7844, 'TURNER','SALESMAN',7698, '08-SEP-81',1500, 0, 30),
		(7876, 'ADAMS', 'CLERK', 7788,'23-MAY-87', 1100,null, 20),
		(7900, 'JAMES', 'CLERK', 7698,'03-DEC-81',950,null, 30),
		(7902, 'FORD', 'ANALYST', 7566, '03-DEC-81',3000,null, 20),
		(7934, 'MILLER', 'CLERK', 7782, '23-JAN-82',1300,null, 10)

create table DEPT                 --Creating DEPT table
(
Deptno int primary key,
Dname varchar(50) not null,
loc varchar(50)
)

insert into DEPT                   --inserting values into Dept table
values (10,'ACCOUNTING','NEW YORK' ),
	   (20, 'RESEARCH', 'DALLAS' ),
	   (30, 'SALES', 'CHICAGO' ),
	   (40, 'OPERATIONS','BOSTON' )


create table  Employee(
empno int primary key,
ename varchar(50),
sal float,
DOJ DATE
)