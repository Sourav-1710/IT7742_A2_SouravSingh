README.txt

Project Title: Customer Management App
Version: 1.0
Author: Sourav Singh (20231008)
Date: 30/10/2025

1. Overview********************************************************(

This project is a small customer management system made using C#.
It helps to add, edit, delete, and view customer information.
The project follows the Model-View-Controller (MVC) design pattern.
The controller manages the logic, the model keeps the data, and the form shows the screen to the user.

The app is built as a Windows Form Application (WinForms).
A simple form is used to manage the customer records.
It can later be expanded to connect with a database or more screens.

2. Requirements******************************************************

Before running this project, please make sure these are installed:

Visual Studio 2022 or later

.NET 8.0 SDK

Windows OS (for running WinForms)

(Optional) Git if you want to keep version control


3. Customer management Application (Winform)*************************

Download or clone the project folder.

Open the solution file (.sln) in Visual Studio.

Wait for Visual Studio to load all files.

Make sure the startup project is set to CustomerManagementApp.

Press Ctrl + F5 or click Run to start the program.

The form will open with fields for Customer Code, Name, and buttons for Add, Edit, Delete, and Clear.

You can test by typing customer details and pressing the buttons to see how it works.


4. Testing **********************************************************

To test the account classes from Assessment 1:

Open the test project folder SouravBankingAppTests.

Right-click on the test project in Visual Studio and choose Run Tests.

Wait for the test results in the Test Explorer window.

You can view passed or failed tests with their messages.


5. Features***********************************************************

Add new customer with code and name.

Edit customer details using their code.

Delete a customer from the list.

Display all customers in a data grid view.

Clear all input fields easily.

Proper input validation and error messages.

Follows MVC pattern to keep code clean and separate.


6. Future Improvements******************************************

Add a database (like SQL Server or MySQL) instead of list storage.

Create a web or mobile version using the same controller logic.

Add login page for admin or user roles.

