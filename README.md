Student Resource Tracker

A desktop-based resource management system developed using VB.NET and Windows Forms. This application allows users to manage educational resources efficiently through a secure login system and database integration.

Overview

The Student Resource Tracker is designed to simplify the organization and management of student learning resources. The system provides functionalities for adding, updating, deleting, searching, and displaying records using a connected SQL Server database.

This project was developed as part of a Software Design and Analysis course to demonstrate practical implementation of desktop application development using VB.NET.

Features

- Secure user login authentication  
- Add new resources  
- Update existing records  
- Delete resources  
- Search resources by title  
- Display records using DataGridView  
- SQL Server database integration  
- Simple and user-friendly interface  

Technologies Used

VB.NET  
Windows Forms  
Microsoft SQL Server  
Visual Studio  
.NET Framework 4.7.2  

Project Structure

StudentResourceTracker/
│
├── Form1.vb  
├── LoginForm.vb  
├── DBConnection.vb  
├── App.config  
├── StudentResourceTracker.vbproj  
└── README.md  

System Modules

Login Module

The login module authenticates users before granting access to the main application.

SELECT * FROM Users WHERE Username=@u AND Password=@p  

Resource Management Module

The application supports full CRUD operations.

Add Resource

INSERT INTO Resources(Title, Category, Author, Quantity)
VALUES(@t, @c, @a, @q)

Update Resource

UPDATE Resources
SET Title=@t,
    Category=@c,
    Author=@a,
    Quantity=@q
WHERE ResourceID=@id

Delete Resource

DELETE FROM Resources WHERE ResourceID=@id

Search Resource

SELECT * FROM Resources WHERE Title LIKE @search

Database Connection

The application connects to SQL Server using SqlConnection.

Public Shared con As New SqlConnection(
    "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StudentResourceTracker;Integrated Security=True"
)

Installation Guide

Requirements

Visual Studio  
.NET Framework 4.7.2  
Microsoft SQL Server  

Steps

1. Clone or download the repository  
2. Open the project in Visual Studio  
3. Configure the SQL Server database  
4. Update the connection string if needed  
5. Build and run the application  

Objectives

Develop a functional student resource management system  
Apply VB.NET programming concepts  
Implement SQL database connectivity  
Improve resource organization and accessibility
