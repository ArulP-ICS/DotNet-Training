use InfiniteDB

-- 1.	Write a query to display your birthday( day of week)

SELECT DATENAME(WEEKDAY, '2004-11-03') AS DayOfWeek;

-- 2.	Write a query to display your age in days

select datediff(day, '2004-11-03', getdate()) as age_in_days;

-- 3. Write a query to display all employees information those who joined before 5 years in the current month

select *
from emp
where hiredate < dateadd(year, -5, getdate())
  and month(hiredate) = month(getdate());


-- 4.Create table Employee with empno, ename, sal, doj columns or use your emp table and perform the following operations in a single transaction
-- a. First insert 3 rows 
-- b. Update the second row sal with 15% increment  
-- c. Delete first row.
-- After completing above all actions, recall the deleted row without losing increment of second row.


create table employee1 (
    empno int primary key,
    ename varchar(20),
    sal decimal(10,2),
    doj datetime
);


begin transaction;

insert into employee1 values
(1, 'aaa', 1000, convert(datetime, '01-01-2020', 105)),
(2, 'bbb', 2000, convert(datetime, '01-01-2020', 105)),
(3, 'ccc', 3000, convert(datetime, '01-01-2020', 105));

select * from employee1;   

commit;


begin transaction;

update employee1
set sal = sal * 1.15
where empno = 2;

select * from employee1;   

commit;   


begin transaction;

delete from employee1
where empno = 1;

rollback;

select * from employee1;   





-- 5.Create a user defined function calculate Bonus for all employees of a  given dept using 	following conditions
-- a.For Deptno 10 employees 15% of sal as bonus.
-- b.For Deptno 20 employees  20% of sal as bonus
-- c.For Others employees 5%of sal as bonus

create or alter function dbo.calculate_bonus
(
    @deptno int,
    @sal decimal(10,2)
)
returns decimal(10,2)
as
begin
    declare @bonus decimal(10,2);

    if @deptno = 10
        set @bonus = @sal * 0.15;
    else if @deptno = 20
        set @bonus = @sal * 0.20;
    else
        set @bonus = @sal * 0.05;

    return @bonus;
end;

-- a.For Deptno 10 employees 15% of sal as bonus.
select empno,
       ename,
       sal,
       deptno,
       sal * 0.15 as bonus
from emp
where deptno = 10;

-- b.For Deptno 20 employees  20% of sal as bonus

select empno,
       ename,
       sal,
       deptno,
       sal * 0.20 as bonus
from emp
where deptno = 20;

-- c.For Others employees 5%of sal as bonus

select empno,
       ename,
       sal,
       deptno,
       sal * 0.05 as bonus
from emp
where deptno not in (10, 20);










-- 6. Create a procedure to update the salary of employee by 500 whose
-- dept name is Sales and current salary is below 1500 (use emp table)

create table emp1 (
    empno int primary key,
    ename varchar(50),
    job varchar(30),
    sal decimal(10,2),
    doj datetime
);

insert into emp1 values
(1, 'AAA', 'SALESMAN', 1200, convert(datetime, '01-01-2020', 105)),
(2, 'BBB', 'CLERK', 1800, convert(datetime, '01-01-2020', 105)),
(3, 'CCC', 'SALESMAN', 1400, convert(datetime, '01-01-2020', 105));

create or alter procedure update_salesman_salary_emp1
as
begin
    update emp1
    set sal = sal + 500
    where job = 'SALESMAN'
      and sal < 1500;
end;
go

exec update_salesman_salary_emp1;

select empno, ename, job, sal
from emp1;