DROP DATABASE IF EXISTS BankApplication;

CREATE DATABASE IF NOT EXISTS BankApplication;

USE BankApplication;

CREATE TABLE Bank(
	BankID INT(10) NOT NULL AUTO_INCREMENT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Code INT(10) NOT NULL UNIQUE,
    Address VARCHAR(25),
    DateOfEstablishment DATE -- Debate not null.
);

DESCRIBE Bank;

CREATE TABLE Branch(
	BranchId INT(10) NOT NULL AUTO_INCREMENT PRIMARY KEY,
    BankId INT(10) NOT NULL, -- NOT NULL enforces mandatory many. REVIEW WITH HIM.
    BranchName VARCHAR(25) NOT NULL,
    Address VARCHAR(25),
    CONSTRAINT Fk_Branch_BankId FOREIGN KEY (BankId) REFERENCES Bank(BankId)
);

DESCRIBE Branch;


CREATE TABLE Loan (
	LoanId INT(10) NOT NULL PRIMARY KEY AUTO_INCREMENT,
	BranchId INT(10) NOT NULL, -- Mandatory many.
	LoanTypeName VARCHAR(25) NOT NULL,
	Amount DECIMAL(15, 2) NOT NULL,
	CONSTRAINT Fk_Loan_BranchId FOREIGN KEY (BranchId) REFERENCES Branch(BranchId)
);

DESCRIBE Loan;

CREATE TABLE Department (
	DepartmentId INT(10) NOT NULL AUTO_INCREMENT PRIMARY KEY,
    DepartmentName VARCHAR(25) -- NULLABLE?
);

DESCRIBE Department;


CREATE TABLE Customer(
    CustomerId INT(10) NOT NULL AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(25) NOT NULL,
    LastName VARCHAR(25) NOT NULL,
    Sex VARCHAR(6),
    MaritialStatus  VARCHAR(10),
    CountryStatus VARCHAR(15),
    Address VARCHAR(25),
    PhoneNumber VARCHAR(15),
    DateOfBirth DATE,
	Password1 VARCHAR(25),
	username VARCHAR(12),
    CurrentBalance DOUBLE,
    Email VARCHAR(25) NOT NULL UNIQUE,
    SinNumber INT(10) NOT NULL UNIQUE
);

DESCRIBE Customer;

CREATE TABLE Employee(
    EmployeeId INT(10) NOT NULL AUTO_INCREMENT PRIMARY KEY,
    BranchId INT(10) NOT NULL, -- Mandatory many.
    DepartmentId INT(10) NOT NULL, -- Mandatory many, ask him since mandatory one makes no sense.
    FirstName VARCHAR(25) NOT NULL,
    LastName VARCHAR(25) NOT NULL,
    Sex VARCHAR(6),
    MaritalStatus VARCHAR(10),
    CountryStatus VARCHAR(15),
    Address VARCHAR(25),
    PhoneNumber VARCHAR(15),
    DateOfBirth DATE,
    Password1 VARCHAR(25),
    Email VARCHAR(25) NOT NULL UNIQUE,
    SinNumber INT(10) NOT NULL UNIQUE,
  
    CONSTRAINT Fk_Employee_BranchId FOREIGN KEY (BranchId) REFERENCES Branch(BranchId),
    CONSTRAINT Fk_Employee_DepartmentId FOREIGN KEY (DepartmentId) REFERENCES Department(DepartmentId)
);
DESCRIBE Employee;


CREATE TABLE AccountType(
	AccountTypeId INT(10) NOT NULL PRIMARY KEY AUTO_INCREMENT,
	AccountTypeName VARCHAR(25)
);

DESCRIBE AccountType;


CREATE TABLE Account (
	AccountId INT(10) NOT NULL AUTO_INCREMENT PRIMARY KEY,
    CustomerId INT(10) NOT NULL, -- Mandatory many.
    AccountTypeId INT(10) NOT NULL, -- Mandatory many, changed since mandatory one would mean each account type is unique.
    LoanId INT(10) NULL, -- Optional many.
    BranchId INT(10) NOT NULL, -- Mandatory many, changed as otherwise you could only have one account per branch.
    Balance DECIMAL(15, 2) NOT NULL, -- Debate not null, decimal precision selected is arbitrary (figured 13 digits before decimal / 2 after works).
    CONSTRAINT Fk_Account_CustomerId FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId),
    CONSTRAINT Fk_Account_AccountTypeId FOREIGN KEY (AccountTypeId) REFERENCES AccountType(AccountTypeId),
    CONSTRAINT Fk_Account_LoanId FOREIGN KEY (LoanId) REFERENCES Loan(LoanId),
    CONSTRAINT Fk_Account_BranchId FOREIGN KEY (BranchId) REFERENCES Branch(BranchId)
);

DESCRIBE Account;

CREATE TABLE Transaction (
	TransactionId INT(10) NOT NULL AUTO_INCREMENT PRIMARY KEY,
    TypeOfTransaction VARCHAR(25) NOT NULL,
    Date DATE NOT NULL,
    Time VARCHAR(10),
    FromAccountId VARCHAR(25) NOT NULL, -- ?
    ToAccountId VARCHAR(25) NOT NULL, -- ?
    Amount DECIMAL(15, 2) NOT NULL
);

DESCRIBE Transaction;

CREATE TABLE AccountTransaction (
	AccountId INT(10) NOT NULL,
	TransactionId INT(10) NOT NULL,
    CONSTRAINT Fk_AccountTransaction_AccountId FOREIGN KEY (AccountId) REFERENCES Account(AccountID),
    CONSTRAINT Fk_AccountTransaction_TransactionId FOREIGN KEY (TransactionId) REFERENCES Transaction(TransactionId)
);



INSERT INTO Bank (Name, Code, Address, DateOfEstablishment) VALUES
	("CIBC", 1, "123 Fake Street", "1950-12-01"),
	("TD", 2, "456 Fake Street", "1951-12-01"),
	("Scotiabank", 3, "100 University Ave", "2023-10-05");

INSERT INTO Branch (BankId, BranchName, Address) VALUES
	(1, "CIBC Branch #1", "123 Fake Street"),
	(1, "CIBC Branch #2", "200 University Ave"),
	(1, "CIBC Branch #3", "?");

/*DESCRIBE Bank;
DESCRIBE Branch;MaritalStatus
DESCRIBE Account;
DESCRIBE Transaction;
DESCRIBE Department;
DESCRIBE Customer;
DESCRIBE Employee;*/

INSERT INTO Customer (FirstName, LastName, Sex, MaritialStatus, CountryStatus, Address, PhoneNumber, DateOfBirth, Password1, Username, CurrentBalance, Email, SinNumber)
VALUES
  ('John', 'Doe', 'Male', 'Single', 'USA', '123 Main St', '123-456-7890', '1990-01-15', 'password123', 'john_doe', 1000.00, 'john.doe@example.com', 123456789),
  ('Jane', 'Smith', 'Female', 'Married', 'Canada', '456 Oak St', '987-654-3210', '1985-07-22', 'pass456', 'jane_smith', 1500.50, 'jane.smith@example.com', 987654321),
  ('Bob', 'Johnson', 'Male', 'Single', 'UK', '789 Elm St', '555-123-4567', '1995-03-10', 'securepass', 'bob_j', 750.75, 'bob.j@example.com', 654321987),
  ('Alice', 'Williams', 'Female', 'Divorced', 'Australia', '101 Pine St', '111-222-3333', '1982-11-05', 'mysecret', 'alice_w', 2000.25, 'alice.w@example.com', 789456123),
  ('Charlie', 'Davis', 'Male', 'Single', 'Germany', '202 Maple St', '444-555-6666', '1998-09-30', 'access123', 'charlie_d', 1200.00, 'charlie.d@example.com', 369852147),
  ('Eva', 'Brown', 'Female', 'Widowed', 'USA', '303 Cedar St', '777-888-9999', '1970-12-18', 'evapass', 'eva_b', 1800.50, 'eva.b@example.com', 159753468),
  ('Daniel', 'Miller', 'Male', 'Married', 'Canada', '404 Birch St', '222-333-4444', '1988-04-25', 'danielpass', 'daniel_m', 2200.75, 'daniel.m@example.com', 456789123),
  ('Sophia', 'Wilson', 'Female', 'Single', 'UK', '505 Oak St', '666-777-8888', '1993-08-12', 'sophiapass', 'sophia_w', 1300.25, 'sophia.w@example.com', 987123456),
  ('Frank', 'Taylor', 'Male', 'Divorced', 'Australia', '606 Pine St', '333-444-5555', '1978-02-28', 'frankpass', 'frank_t', 1600.00, 'frank.t@example.com', 321654987),
  ('Olivia', 'Moore', 'Female', 'Single', 'Germany', '707 Elm St', '888-999-0000', '1996-06-15', 'oliviapass', 'olivia_m', 1900.50, 'olivia.m@example.com', 654987321),
  ('George', 'Anderson', 'Male', 'Single', 'USA', '808 Maple St', '999-000-1111', '1980-10-08', 'georgepass', 'george_a', 1400.75, 'george.a@example.com', 789321654),
  ('Ava', 'Jones', 'Female', 'Married', 'Canada', '909 Cedar St', '111-222-3333', '1975-05-20', 'avapass', 'ava_j', 2000.25, 'ava.j@example.com', 456852147),
  ('Samuel', 'White', 'Male', 'Single', 'UK', '1010 Birch St', '222-333-4444', '1992-09-28', 'samuelpass', 'samuel_w', 1200.00, 'samuel.w@example.com', 987654322),
  ('Emily', 'Harris', 'Female', 'Divorced', 'Australia', '1111 Oak St', '333-444-5555', '1986-03-15', 'emilypass', 'emily_h', 1700.50, 'emily.h@example.com', 654123789),
  ('William', 'Martin', 'Male', 'Single', 'Germany', '1212 Pine St', '444-555-6666', '1997-11-18', 'williampass', 'william_m', 1500.25, 'william.m@example.com', 789456124),
  ('Lily', 'Johnson', 'Female', 'Widowed', 'USA', '1313 Elm St', '555-666-7777', '1973-07-22', 'lilypass', 'lily_j', 2100.75, 'lily.j@example.com', 159357456),
  ('Henry', 'Thompson', 'Male', 'Single', 'Canada', '1414 Cedar St', '777-888-9999', '1994-04-12', 'henrypass', 'henry_t', 1300.00, 'henry.t@example.com', 753951852),
  ('Grace', 'Scott', 'Female', 'Divorced', 'UK', '1515 Maple St', '888-999-0000', '1981-08-30', 'gracepass', 'grace_s', 1800.50, 'grace.s@example.com', 456852148),
  ('Andrew', 'Ward', 'Male', 'Single', 'Australia', '1616 Birch St', '111-222-3333', '1999-12-05', 'andrewpass', 'andrew_w', 1600.25, 'andrew.w@example.com', 987654323),
  ('Chloe', 'Morgan', 'Female', 'Married', 'Germany', '1717 Oak St', '222-333-4444', '1984-05-28', 'chloepass', 'chloe_m', 1900.00, 'chloe.m@example.com', 654789125);
ALTER TABLE bankapplication.customer
ADD COLUMN LoanAccountBalance DOUBLE,
ADD COLUMN ChequingAccountBalance DOUBLE,
ADD COLUMN SavingAccountBalance DOUBLE;

-- insering a value for the new columns by using  ID  named 'CustomerId'
-- Add columns to the existing Customer table
ALTER TABLE Customer
ADD COLUMN LoanAccountBalance DOUBLE,
ADD COLUMN ChequingAccountBalance DOUBLE,
ADD COLUMN SavingAccountBalance DOUBLE;

-- Update the values for the new columns
-- Add columns to the existing Customer table
ALTER TABLE Customer
ADD COLUMN LoanAccountBalance DOUBLE,
ADD COLUMN ChequingAccountBalance DOUBLE,
ADD COLUMN SavingAccountBalance DOUBLE;

-- Update the values for the new columns

UPDATE Customer
SET LoanAccountBalance = 5000.50, ChequingAccountBalance = 3000.75, SavingAccountBalance = 7000.25
WHERE CustomerId = 1;

UPDATE Customer
SET LoanAccountBalance = 2500.25, ChequingAccountBalance = 4500.00, SavingAccountBalance = 8000.50
WHERE CustomerId = 2;

UPDATE Customer
SET LoanAccountBalance = 8000.75, ChequingAccountBalance = 1500.25, SavingAccountBalance = 2000.50
WHERE CustomerId = 3;

UPDATE Customer
SET LoanAccountBalance = 7000.00, ChequingAccountBalance = 2500.50, SavingAccountBalance = 6000.75
WHERE CustomerId = 4;

UPDATE Customer
SET LoanAccountBalance = 3500.25, ChequingAccountBalance = 2000.00, SavingAccountBalance = 9000.25
WHERE CustomerId = 5;

UPDATE Customer
SET LoanAccountBalance = 4500.00, ChequingAccountBalance = 3500.75, SavingAccountBalance = 1500.00
WHERE CustomerId = 6;

UPDATE Customer
SET LoanAccountBalance = 5500.50, ChequingAccountBalance = 4000.25, SavingAccountBalance = 2500.50
WHERE CustomerId = 7;

UPDATE Customer
SET LoanAccountBalance = 2000.75, ChequingAccountBalance = 1000.25, SavingAccountBalance = 8000.00
WHERE CustomerId = 8;

UPDATE Customer
SET LoanAccountBalance = 9000.25, ChequingAccountBalance = 5500.50, SavingAccountBalance = 3000.25
WHERE CustomerId = 9;

UPDATE Customer
SET LoanAccountBalance = 6000.00, ChequingAccountBalance = 3000.75, SavingAccountBalance = 9500.00
WHERE CustomerId = 10;

-- Add similar lines for other records

UPDATE Customer
SET LoanAccountBalance = 9000.25, ChequingAccountBalance = 1500.25, SavingAccountBalance = 5500.25
WHERE CustomerId = 11;

UPDATE Customer
SET LoanAccountBalance = 3000.50, ChequingAccountBalance = 6000.25, SavingAccountBalance = 7500.50
WHERE CustomerId = 12;

UPDATE Customer
SET LoanAccountBalance = 1500.25, ChequingAccountBalance = 2500.00, SavingAccountBalance = 4000.75
WHERE CustomerId = 13;

UPDATE Customer
SET LoanAccountBalance = 4500.75, ChequingAccountBalance = 3500.25, SavingAccountBalance = 6000.00
WHERE CustomerId = 14;

UPDATE Customer
SET LoanAccountBalance = 7000.50, ChequingAccountBalance = 4000.75, SavingAccountBalance = 8500.25
WHERE CustomerId = 15;

UPDATE Customer
SET LoanAccountBalance = 8000.25, ChequingAccountBalance = 2000.25, SavingAccountBalance = 3000.50
WHERE CustomerId = 16;

UPDATE Customer
SET LoanAccountBalance = 1000.75, ChequingAccountBalance = 500.50, SavingAccountBalance = 7000.00
WHERE CustomerId = 17;

UPDATE Customer
SET LoanAccountBalance = 9500.25, ChequingAccountBalance = 4500.50, SavingAccountBalance = 2000.75
WHERE CustomerId = 18;

UPDATE Customer
SET LoanAccountBalance = 3000.00, ChequingAccountBalance = 1500.25, SavingAccountBalance = 5000.00
WHERE CustomerId = 19;

UPDATE Customer
SET LoanAccountBalance = 6000.25, ChequingAccountBalance = 3000.50, SavingAccountBalance = 2500.75
WHERE CustomerId = 20;

UPDATE Customer
SET LoanAccountBalance = 6000.25, ChequingAccountBalance = 38000.50, SavingAccountBalance = 28500.75
WHERE CustomerId = 21;

-- Verify the changes
SELECT * FROM Customer;





