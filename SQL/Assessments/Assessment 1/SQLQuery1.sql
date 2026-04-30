create database Assessment1

use  Assessment1

-- 1. Create a book table with id as primary key and provide
-- the appropriate data type to other attributes .isbn no should be unique for each book

CREATE TABLE books (
    id INT PRIMARY KEY,
    title VARCHAR(200),
    author VARCHAR(100),
    isbn VARCHAR(20) UNIQUE,
    published_date DATETIME
);

INSERT INTO books (id, title, author, isbn, published_date)
VALUES
(1, 'My First SQL book', 'Mary Parker', '981483029127', '2012-02-22 12:08:17'),
(2, 'My Second SQL book', 'John Mayer', '857300923713', '1972-07-03 09:22:45'),
(3, 'My Third SQL book', 'Cary Flint', '523120967812', '2015-10-18 14:05:44');

-- Write a query to fetch the details of the books written by author whose name ends with er.

SELECT *
FROM books
WHERE author LIKE '%er';


CREATE TABLE Reviews (
    id INT PRIMARY KEY,
    book_id INT NOT NULL,
    reviewer_name VARCHAR(100) NOT NULL,
    content VARCHAR(500),
    rating INT,
    published_date DATETIME,
    FOREIGN KEY (book_id) REFERENCES Books(id)
);

INSERT INTO reviews VALUES
(1, 1, 'John Smith', 'My first review', 4, '2017-12-10 05:50:11'),
(2, 2, 'John Smith', 'My second review', 5, '2017-10-13 15:05:12'),
(3, 2, 'Alice Walker', 'Another review', 1, '2017-10-22 23:47:10');

-- Display the Title ,Author and ReviewerName for all the books from the above table

SELECT
    B.title,
    B.author,
    R.reviewer_name
FROM books B
JOIN reviews R
ON B.id = R.book_id;

-- 2.Display Reviewer Name who reviewed more than one book

SELECT
    reviewer_name
FROM Reviews
GROUP BY reviewer_name
HAVING COUNT(DISTINCT book_id) > 1;


-- 3. Display the Name for the customer from above customer 
-- table who live in same address which has character o anywhere in address



CREATE TABLE Customers (
    ID INT PRIMARY KEY,
    Name VARCHAR(50),
    AGE INT,
    ADDRESS VARCHAR(100),
    SALARY DECIMAL(10,2)
);

INSERT INTO Customers VALUES
(1, 'Ramesh', 32, 'Ahmedabad', 2000.00),
(2, 'Khilan', 25, 'Delhi', 1500.00),
(3, 'Kaushik', 23, 'Kota', 2000.00),
(4, 'Chaitali', 25, 'Mumbai', 6500.00),
(5, 'Hardik', 27, 'Bhopal', 8500.00),
(6, 'Komal', 22, 'MP', 4500.00),
(7, 'Muffy', 24, 'Indore', 10000.00);


SELECT name
FROM Customers
WHERE address LIKE '%o%';

-- 4.Write a query to display the Date,Total no of customer placed order on same Date


CREATE TABLE Orders (
    OID INT PRIMARY KEY,
    ORDERDATE DATETIME,
    CUSTOMER_ID INT,
    AMOUNT INT
);


INSERT INTO Orders VALUES
(102, '2009-10-08 00:00:00', 3, 3000),
(100, '2009-10-08 00:00:00', 3, 1500),
(101, '2009-11-20 00:00:00', 2, 1560),
(103, '2008-05-20 00:00:00', 4, 2060);


SELECT 
    ORDERDATE,
    COUNT(DISTINCT CUSTOMER_ID) AS Total_Customers
FROM Orders
GROUP BY ORDERDATE;

-- 5.Display the Names of the Employee in lower case, whose salary is null

CREATE TABLE Employee (
    ID INT PRIMARY KEY,
    Name VARCHAR(50),
    AGE INT,
    ADDRESS VARCHAR(100),
    SALARY DECIMAL(10,2) NULL
);

INSERT INTO Employee VALUES
(1, 'Ramesh', 32, 'Ahmedabad', 2000.00),
(2, 'Khilan', 25, 'Delhi', 1500.00),
(3, 'Kaushik', 23, 'Kota', 2000.00),
(4, 'Chaitali', 25, 'Mumbai', 6500.00),
(5, 'Hardik', 27, 'Bhopal', 8500.00),
(6, 'Komal', 22, 'MP', NULL),
(7, 'Muffy', 24, 'Indore', NULL);


SELECT LOWER(Name) AS employee_name
FROM Employee
WHERE SALARY IS NULL;


-- 6. Write a sql server query to display the Gender,Total 
-- no of male and female from the above relation


CREATE TABLE StudentDetails (
    RegisterNo INT PRIMARY KEY,
    Name VARCHAR(50) NOT NULL,
    Age INT,
    Qualification VARCHAR(50),
    MobileNo VARCHAR(15),
    Mail_id VARCHAR(100),
    Location VARCHAR(50),
    Gender CHAR(1)
);

INSERT INTO StudentDetails VALUES
(2, 'Sai', 22, 'B.E', '9952836777', 'Sai@gmail.com', 'Chennai', 'M'),
(3, 'Kumar', 20, 'BSC', '7890125648', 'Kumar@gmail.com', 'Madurai', 'M'),
(4, 'Selvi', 22, 'B.Tech', '8904567342', 'Selvi@gmail.com', 'Salem', 'F'),
(5, 'Nisha', 25, 'M.E', '7834672310', 'Nisha@gmail.com', 'Theni', 'F'),
(6, 'SaiSaren', 21, 'B.A', '7890435678', 'Saran@gmail.com', 'Madurai', 'F'),
(7, 'Tom', 23, 'BCA', '8901234675', 'Tom@gmail.com', 'Pune', 'M');


SELECT Gender,COUNT(*) AS Total_Count
FROM StudentDetails
GROUP BY Gender;












