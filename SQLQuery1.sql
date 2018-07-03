CREATE DATABASE SecondDB
ON
(
	NAME='SecondDB',
	FILENAME = 'D:\SecondDB.mdf',
	SIZE=200MB,
	MAXSIZE=2000MB,
	FILEGROWTH=10MB
)
LOG ON
(
	NAME = 'LogSecondDB',
	FILENAME = 'D:\SecondDB.ldf',
	SIZE=100MB,
	MAXSIZE=1000MB,
	FILEGROWTH=10MB
)
COLLATE Cyrillic_General_CI_AS

EXECUTE sp_helpdb SecondDB;

USE SecondDB
GO

BACKUP DATABASE [SecondDB]
TO DISK = 'd:\course\SecondDB.Bak'

CREATE TABLE Departments
(
	DepartmentId int IDENTITY NOT NULL
	PRIMARY KEY,
	DepartmentName Varchar(20) NOT NULL,
	Salary int NOT NULL,
)
GO

CREATE TABLE Workers
(
	WorkerId int IDENTITY NOT NULL
	PRIMARY KEY,
	WorkerName Varchar (20) NOT NULL,
	DepartmentId int NOT NULL
	FOREIGN KEY REFERENCES Departments(DepartmentId),
	Sex Varchar (6) NOT NULL,
	Age int NOT NULL,
	ChildrenCount int,
	Experience int,
)
GO

CREATE TABLE Brigades
(
	BrigadeId int IDENTITY NOT NULL
	PRIMARY KEY,
	DepartmentId int NOT NULL
	FOREIGN KEY REFERENCES Departments(DepartmentId),
	BrigadeName Varchar (20) NOT NULL,
)
GO

CREATE TABLE BrigadeMembers
(
	BrigadeMembersId int IDENTITY NOT NULL
	PRIMARY KEY,
	BrigadeId int NOT NULL
	FOREIGN KEY REFERENCES Brigades(BrigadeId),
	WorkerId int NOT NULL
	FOREIGN KEY REFERENCES Workers(WorkerId),
)
GO

CREATE TABLE Administrators
(
	AdministratorId int IDENTITY NOT NULL 
	PRIMARY KEY,
	WorkerId int NOT NULL
	FOREIGN KEY REFERENCES Workers(WorkerId),
)
GO

CREATE TABLE Routs
(
	RouteId int IDENTITY NOT NULL
	PRIMARY KEY,
	RouteName Varchar (20) NOT NULL,
	StartPoint Varchar (20) NOT NULL,
	LastPoint Varchar (20) NOT NULL,
	RouteTime int NOT NULL,
	Category Varchar (20) NOT NULL,
)
GO

CREATE TABLE HubStations
(	
	HubStationsId int IDENTITY NOT NULL
	PRIMARY KEY,
	StationName Varchar(20) NOT NULL,
	RouteId int NOT NULL
	FOREIGN KEY REFERENCES Routs(RouteId),
)
GO

CREATE TABLE Trains
(
	TrainId int IDENTITY NOT NULL
	PRIMARY KEY,
	TrainNumber Varchar (20) NOT NULL,
	TrainType Varchar (20) NOT NULL,
	BrigadeId int NOT NULL
	FOREIGN KEY REFERENCES Brigades(BrigadeId),
	TrainAge int NOT NULL,
)
GO

CREATE TABLE Inspection
(
	InspectionId int IDENTITY NOT NULL
	PRIMARY KEY,
	TrainId int NOT NULL
	FOREIGN KEY REFERENCES Trains(TrainId),
	Inspection Varchar (5),
	DateOfInspection Date,
)
GO

CREATE TABLE Repair
(
	RepairId int IDENTITY NOT NULL
	PRIMARY KEY,
	TrainId int NOT NULL
	FOREIGN KEY REFERENCES Trains(TrainId),
	Repair Varchar (5),
	DateOfRepair Date,
)
GO

CREATE TABLE TimeTable
(
	PassageId int IDENTITY NOT NULL
	PRIMARY KEY,
	TimeTableName Varchar (20) NOT NULL,
	TrainNumber int NOT NULL
	FOREIGN KEY REFERENCES Trains(TrainId),
	RouteId int NOT NULL
	FOREIGN KEY REFERENCES Routs(RouteId),
	DepartureTime DateTime,
	ArrivalTime DateTime,
	Canceled Varchar (5),
	Detained Varchar (5),
	TicketPrice int,
)
GO

CREATE TABLE Clients
(
	ClientId int IDENTITY NOT NULL
	PRIMARY KEY,
	ClientName Varchar (20),
	Adress Varchar (20),
	Age int,
	Sex Varchar (5),
	GivenPackage Varchar(5),
)

CREATE TABLE Tickets
(
	TicketId int IDENTITY NOT NULL
	PRIMARY KEY,
	WorkerId int 
	FOREIGN KEY REFERENCES Workers(WorkerId),
	BuyerId int 
	FOREIGN KEY REFERENCES Clients (ClientId),
	PassageId int NOT NULL
	FOREIGN KEY REFERENCES TimeTable(PassageId),
	SoldCHeck Varchar (5),
	TimeOfSell Varchar (20),
	Reservation Varchar (5),
)
GO

CREATE TABLE TakenBackTickets
(
	TakenBackTicketsId int IDENTITY NOT NULL
	PRIMARY KEY,
	TicketId int NOT NULL
	FOREIGN KEY REFERENCES Tickets(TicketId),
	TakenBack Varchar(5),
	DateWhenTakenBack Date,
	)
	GO

	SELECT COUNT(WorkerID) as Coun, Age
	FROM Workers
	GROUP BY Age
	ORDER BY Age

	select MAX(Age) from Workers