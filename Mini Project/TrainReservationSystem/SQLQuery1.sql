CREATE DATABASE TrainReservationDB;


USE TrainReservationDB;


CREATE TABLE Users
(
    UserId INT PRIMARY KEY IDENTITY,
    Username VARCHAR(50),
    Password VARCHAR(50),
    UserType VARCHAR(20)
);

CREATE TABLE Trains
(
    TrainNo INT PRIMARY KEY,
    TrainName VARCHAR(100),
    FromStation VARCHAR(100),
    ToStation VARCHAR(100),

    Seats2AC INT,
    Price2AC DECIMAL(10,2),

    Seats3AC INT,
    Price3AC DECIMAL(10,2),

    SleeperSeats INT,
    SleeperPrice DECIMAL(10,2),

    IsDeleted BIT DEFAULT 0
);

CREATE TABLE Bookings
(
    BookingId INT PRIMARY KEY IDENTITY,
    BookingDate DATE,
    TravelDate DATE,
    TrainNo INT,
    TravelClass VARCHAR(20),
    PassengerCount INT,
    Amount DECIMAL(10,2),

    FOREIGN KEY (TrainNo)
    REFERENCES Trains(TrainNo)
);

CREATE TABLE Passengers
(
    PassengerId INT PRIMARY KEY IDENTITY,
    BookingId INT,
    PassengerName VARCHAR(100),
    Age INT,
    Gender VARCHAR(10),

    FOREIGN KEY (BookingId)
    REFERENCES Bookings(BookingId)
);

CREATE TABLE Cancellations
(
    CId INT PRIMARY KEY IDENTITY,
    BookingId INT,
    NoTickets INT,
    RefundAmount DECIMAL(10,2),
    CancelDate DATE,

    FOREIGN KEY (BookingId)
    REFERENCES Bookings(BookingId)
);

INSERT INTO Users VALUES
('admin','admin123','Admin'),
('arul','1234','User');


select * from Users

INSERT INTO Trains VALUES (102, 'Kovai Express', 'Chennai', 'Tiruppur', 15, 2200, 35, 1300, 90, 650, 0);

INSERT INTO Trains VALUES (103, 'Madurai Express', 'Chennai', 'Madurai', 10, 2000, 30, 1200, 80, 500, 0);

select * from Trains