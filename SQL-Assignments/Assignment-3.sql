create database SQL_2
use SQL_2
select* from emp       --1.fetching details from emp
select * from DEPT     --fetching details of dept


select ename            --2.fetching all details where job=manager
from emp 
where job='manager'

select ename,sal        --3.fetching ename and sal where sal greater than 1000
from emp 
where sal>1000


select ename,sal        --4.fetching ename ,sal where ename not equal 
from emp 
where ename!='james'

select empno,ename,job,mgr_id,hiredate,sal,comm,deptno --5.select all details whose name starts with s
from emp 
where ename like 's%'

select ename                                         --6.select ename where employee name consist a
from emp 
where ename like '%a%'

select ename                                         --7.fetch ename whose name consists of l as 3rd character
from emp 
where ename like '__l%'

select ename,                                        --8.fetch employees daily salary and ename is james
round(sal /30,2) as 'Day Salary' 
from emp  
where ename='james'

select sum                                           --9.fetch sum of salaries
(distinct sal) as "Total Salary"
from emp

select avg(sal*12) as "Annual Salary"                --10.seelct annual salary of employees
from emp

select ename,job,sal,deptno                         --11.fetch deatils whose job is salesman and deptno is 30
from emp 
where not( deptno=30 and job='salesman')

select distinct deptno                              --12.seelct unique deptno from dept
from emp

select ename as' Employee',                          --13.fetch employee details 
sal as 'Monthlysalary' 
from emp 
where sal>1500 and (deptno=10 or deptno=30)

select ename,job,sal               --14.fetch details  where job is manager or analyst and sal not in 1000,3000,5000
from emp 
where (job='manager' or job='analyst') and sal not in (1000,3000,5000)

select ename,sal,comm                --15.adding commision ton employees
from emp 
where comm>sal*1.1

select ename                          --16.select ename consists of atleast 2 l and dept num is 30 and mgr_id id 7782
from emp 
where (ename like '%l%l%' and (deptno=30 or mgr_id=7782))

select ename                               --17
from emp
where datediff(year,hiredate,getdate())between 30 and 40

select count(empno)                            --18
from emp 
where datediff(year,hiredate,getdate())between 30 and 40

select dept.dname,emp.ename                      --19
from emp
join dept on emp.deptno=dept.deptno
order by dept.dname asc, emp.ename desc

select ename,datediff(year,hiredate,getdate()) as 'Experience'    --20.find experience of individual employee
from emp
where ename='miller