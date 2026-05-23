CREATE DATABASE StudentResourceTracker;
GO

USE StudentResourceTracker;
GO

CREATE TABLE Users (
    UserID INT PRIMARY KEY IDENTITY(1,1),
    Username VARCHAR(50),
    Password VARCHAR(50),
    Role VARCHAR(20)
);
GO

INSERT INTO Users (Username, Password, Role)
VALUES ('admin', '1234', 'Admin');
GO

CREATE TABLE Resources (
    ResourceID INT PRIMARY KEY IDENTITY(1,1),
    Title VARCHAR(100),
    Category VARCHAR(50),
    Author VARCHAR(100),
    Quantity INT
);
GO