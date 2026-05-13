CREATE DATABASE Employeemanagement;

use Employeemanagement;


-- 1.Create a stored procedure that adds new rows to the Employee_Details Table. 
-- The procedure should accept all the details as input except empno. 
-- You need to write the code in the procedure to generate the empno and then insert
CREATE TABLE Employee_Details
(
    Empno INT PRIMARY KEY,
    EmpName VARCHAR(50) NOT NULL,
    Empsal NUMERIC(10,2) CHECK (Empsal >= 25000),
    Emptype CHAR(1) CHECK (Emptype IN ('F','P'))
);

INSERT INTO Employee_Details (Empno, EmpName, Empsal, Emptype)
VALUES 
(1, 'Arul', 30000, 'F'),
(2, 'Kumar', 28000, 'P'),
(3, 'Ravi', 35000, 'F');


CREATE PROCEDURE AddEmployee
    @EmpName VARCHAR(50),
    @Empsal NUMERIC(10,2),
    @Emptype CHAR(1)
AS
BEGIN
    DECLARE @NewEmpno INT;

    
    SELECT @NewEmpno = ISNULL(MAX(Empno),0) + 1 FROM Employee_Details;

    INSERT INTO Employee_Details (Empno, EmpName, Empsal, Emptype)
    VALUES (@NewEmpno, @EmpName, @Empsal, @Emptype);
END;



EXEC AddEmployee 'David', 32000, 'F';
EXEC AddEmployee 'Priya', 27000, 'P';

SELECT * FROM Employee_Details;


-- 2. Write a procedure that takes empid as input and outputs the updated salary as current salary + 100 for the given employee.

ALTER PROCEDURE UpdateSalary
    @Empno INT,
    @UpdatedSalary NUMERIC(10,2) OUTPUT
AS
BEGIN
    IF EXISTS
    (
        SELECT *
        FROM Employee_Details
        WHERE Empno = @Empno
    )
    BEGIN
        UPDATE Employee_Details
        SET Empsal = Empsal + 100
        WHERE Empno = @Empno;

        SELECT @UpdatedSalary = Empsal
        FROM Employee_Details
        WHERE Empno = @Empno;
    END
    ELSE
    BEGIN
        SET @UpdatedSalary = NULL;
    END
END;
GO

-- Declare Output Variable
DECLARE @sal NUMERIC(10,2);

-- Execute Procedure
EXEC UpdateSalary 1, @sal OUTPUT;

-- Display Updated Salary
SELECT @sal AS UpdatedSalary;