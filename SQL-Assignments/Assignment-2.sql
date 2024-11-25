create database SQL_Assignment      --database creation
create table EMP                    --Creating emp table
(
Empno int primary key,
Ename varchar,
job varchar,
Mgr_id int ,
Hiredate date ,
Sal int ,
Comm int,
Deptno int references DEPT(Deptno)
)
Alter table Emp                       --For changing varchar size i have used alter command
Alter  COLUMN Ename varchar(50)
Alter table Emp
Alter  COLUMN job varchar(50)

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


select *from Emp                  --Fetching Emp table
sp_help EMP                       --Description regarding emp table

create table DEPT                 --Creating DEPT table
(
Deptno int primary key,
Dname varchar not null,
loc varchar
)

Alter table DEPT                   --For changing varchar size i have used alter command
Alter  COLUMN Dname varchar(50)
Alter table DEPT
Alter  COLUMN loc varchar(50)

insert into DEPT                   --inserting values into Dept table
values (10,'ACCOUNTING','NEW YORK' ),
	   (20, 'RESEARCH', 'DALLAS' ),
	   (30, 'SALES', 'CHICAGO' ),
	   (40, 'OPERATIONS','BOSTON' )



select * from DEPT              --Fetching details of DEPT
sp_help DEPT                    --Describing DEPT table

                            
							    Assignment-2   (QUERIES)


select Ename from Emp where ename like 'A%'     --1.fetching employeee name starting with A

select Ename from EMP where Mgr_id is null      --2.fetching employee name who dont have manager

select Ename,Empno,Sal                          --3.fetching employee name,number,sal whose salary is between 1200 and 1400
from EMP
where Sal between 1200 and 1400    

select Sal,Sal*1.10 as Pay_raise                --4.giving payrise of 10% and displaying them properly(using subQuery)
from Emp
where Deptno=(select Deptno from Dept where Dname='Research')

select count(*) as Clerk_Count                  --5.Fetching the count of clerk
from EMP
where job='Clerk'

select job,avg(sal) as Avg_Salary ,count(*) as EMP_Count   --6.grouping based on job
from EMP
Group by job;
 
select Ename from EMP                         --7.fetching empnames with highest and lowest salary
where Sal=(select max(Sal) from EMP)
select ename from emp 
where sal=(select min(sal) from Emp)


select d.Dname                                 -- 8.fetching department name which doesnt have employees
from dept d Left join EMP e 
on d.Deptno=e.Deptno
where e.Deptno IS NULL

select * from emp                             --9.fetching details who is analyst and sal >1200 as well as deptno is 20
where job='Analyst' and sal>1200 and deptno=20

select e.Ename,e.Sal,e.Deptno,sum(e1.Sal) as Total_sal  --10.fetching salaries,employee names and total salary based on their departemnt using self join
from emp e join emp e1
on e.Deptno=e1.Deptno
group by e.ename,e.sal,e.deptno

select ename sal from emp                     --11.fetching sal of miller and smith using in opearator
where ename in ('smith','miller')

select ename from EMP                        --12.fetching employee names whose names starts with A and M
where Ename like 'A%' or  Ename like 'M%'

select ename,sal,sal*12 as Smith_Annual_sal   --13.fetching annual salary of smith
from emp
where ename='Smith'

select ename,sal from emp                     --14.fetching Employee names and salaries whose salary is not in between 1500 and 2850
where sal not between 1500 and 2850

select mgr_id,count(*) as Emp_Count           --15.fetching managers who have more than 2 employees reporting to them
from emp group by mgr_id
having  count(*)>2







