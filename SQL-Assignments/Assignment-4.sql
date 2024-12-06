create database Assignment_4
use Assignment_4


create function dbo.Factorial (@number int)   --1.Factorial of a number
returns bigint
as
begin
    declare @result bigint
    set @result = 1
    while @number > 1
    begin
        set @result = @result * @number
        set @number = @number - 1
		end
    return @result
	end
select dbo.Factorial(5) as Factorial





create procedure Mul_table                --2.Multiplication of a table
    @Number int,
    @Limit int
	as
	begin
    set nocount on;
    declare @Counter int = 1;
    print 'Multiplication Table for ' + cast(@Number as varchar(10)) + ' up to ' + cast(@Limit as varchar(10));
    while @Counter <= @Limit
    begin
      print cast(@Number as varchar(10)) + ' x ' + cast(@Counter as varchar(10)) + ' = ' + cast(@Number * @Counter as varchar(10));
       set @Counter = @Counter + 1;
      end
	end;

Exec Mul_table @Number = 5, @Limit = 10;


create table Student (                               --3.Creating	student table
    Stdid int primary key,
    Sname varchar(50)
);

insert into Student 
values(1, 'Jack'),(2, 'Rithvik'),(3, 'Jaspreeth'),(4, 'Praveen'),(5, 'Bisa'),(6, 'Suraj');


create table Marks (
    Markid int primary key,
    Stdid int,
    Score int,
	foreign key (Stdid) references Student(Stdid)
	);

insert into Marks (Markid, Stdid, Score)
values (1, 1, 23),(2, 6, 95),(3, 4, 98),(4, 2, 17),(5, 3, 53),(6, 5, 13);
 
 create function GetStudent_Status (@Score int)
returns varchar(10)
as
begin
declare @status varchar(10);
    if @Score >= 50
	return 'Pass';
    else 
    return 'Fail';
	return @status;

end;

select

  s.Stdid as StudentID,

    s.Sname as StudentName,

    m.Score as Score,

    dbo.GetStudent_Status(m.Score) as Status

from   Student s LEFT JOIN 

Marks m on s.Stdid = m.Stdid order by s.Stdid;
 