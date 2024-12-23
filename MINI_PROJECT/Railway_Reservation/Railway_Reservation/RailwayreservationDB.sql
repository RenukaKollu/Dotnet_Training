create database RailwayReservation

use RailwayReservation

--creating trains table

create table Trains(
TrainNo int primary key, 
TrainName Varchar(50),
FromStation Varchar(50),
ToStation Varchar(50),
Price Decimal(10,2),
ClassofTravel Varchar(50),
TrainStatus Varchar(50),
SeatsAvailable int);

insert into Trains(TrainNo,TrainName,FromStation,ToStation,Price,ClassofTravel,TrainStatus,SeatsAvailable)
values(12759,'Charminar Sf Exp','Tambaram','Hyderabad',450.00,'SL','Active',10),
(17643,'Circar Express','Tambaram','Kakinada Port',955.00,'3A','Active',2),
(12679,'CBE Intercity','Chennai','Tirupur',635.00,'CC','Active',1),
(16382,'Chennai Exp','Delhi','Chennai',795.00,'3E','Active',12);

select * from Trains

--Creating users Table

CREATE TABLE Users
(
    UserId INT IDENTITY(1,1) PRIMARY KEY,  -- Identity column starts at 1 and increments by 1
    UserName VARCHAR(50),
    Password VARCHAR(15),
    Role VARCHAR(25)
);

update Users
set Role='Admin'
where UserId=2

select * from users

--Creating Bookings Table

CREATE TABLE Bookings
(
    BookingID INT IDENTITY(1,1) PRIMARY KEY,  -- Identity column starts at 1 and increments by 1
    UserID INT FOREIGN KEY (UserId) REFERENCES Users(UserId),
    TrainNo INT FOREIGN KEY (TrainNo) REFERENCES Trains(TrainNo),
    SeatsBooked INT,
    BookingDate DATETIME
);


CREATE TABLE Cancellations
(
    CancellationId INT identity(1,1) PRIMARY KEY,
    BookingId INT FOREIGN KEY (BookingId) REFERENCES Bookings(BookingID),
    CancelledSeats INT,
    CancellationDate DATETIME
);

select * from Trains
select * from Bookings
select * from Cancellations
select * from users