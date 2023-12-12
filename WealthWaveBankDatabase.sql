DROP DATABASE IF EXISTS XyzBank;

CREATE DATABASE IF NOT EXISTS XyzBank;

USE XyzBank;

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
    MaritalStatus VARCHAR(10),
    CountryStatus VARCHAR(15),
    Address VARCHAR(25),
    PhoneNumber VARCHAR(15),
    DateOfBirth DATE,
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
DESCRIBE Branch;
DESCRIBE Account;
DESCRIBE Transaction;
DESCRIBE Department;
DESCRIBE Customer;
DESCRIBE Employee;*/