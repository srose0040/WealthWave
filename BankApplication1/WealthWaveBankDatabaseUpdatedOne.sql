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
	Username VARCHAR(12) NOT NULL UNIQUE,
    LoanAccountBalance DOUBLE,
    ChequingAccountBalance DOUBLE, 
    SavingAccountBalance DOUBLE,
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

INSERT INTO Customer (FirstName, LastName, Sex, MaritialStatus, CountryStatus, Address, PhoneNumber, DateOfBirth, Password1, Username,  LoanAccountBalance, ChequingAccountBalance,SavingAccountBalance,Email, SinNumber)
VALUES
  ('John', 'Doe', 'Male', 'Single', 'USA', '123 Main St', '123-456-7890', '1990-01-15', 'password123', 'john_doe', 1000.00,2500,5544, 'john.doe@example.com', 123456789),
  ('Jane', 'Smith', 'Female', 'Married', 'Canada', '456 Oak St', '987-654-3210', '1985-07-22', 'pass456', 'jane_smith',  10088.00,25500,55454, 'jane.smith@example.com', 987654321),
  ('Bob', 'Johnson', 'Male', 'Single', 'UK', '789 Elm St', '555-123-4567', '1995-03-10', 'securepass', 'bob_j', 10007.00,5500,5544,'bob.j@example.com', 654321987),
  ('Alice', 'Williams', 'Female', 'Divorced', 'Australia', '101 Pine St', '111-222-3333', '1982-11-05', 'mysecret', 'alice_w',  1700.00,2500,5544, 'alice.w@example.com', 789456123),
  ('Charlie', 'Davis', 'Male', 'Single', 'Germany', '202 Maple St', '444-555-6666', '1998-09-30', 'access123', 'charlie_d',  6000.00,2700,5044,'charlie.d@example.com', 369852147),
  ('Eva', 'Brown', 'Female', 'Widowed', 'USA', '303 Cedar St', '777-888-9999', '1970-12-18', 'evapass', 'eva_b',  65400.00,8500,10000, 'eva.b@example.com', 159753468),
  ('Daniel', 'Miller', 'Male', 'Married', 'Canada', '404 Birch St', '222-333-4444', '1988-04-25', 'danielpass', 'daniel_m',  10900.00,8500,5544, 'daniel.m@example.com', 456789123),
  ('Sophia', 'Wilson', 'Female', 'Single', 'UK', '505 Oak St', '666-777-8888', '1993-08-12', 'sophiapass', 'sophia_w',  1000.00,2500,5544, 'sophia.w@example.com', 987123456),
  ('Frank', 'Taylor', 'Male', 'Divorced', 'Australia', '606 Pine St', '333-444-5555', '1978-02-28', 'frankpass', 'frank_t',  1000.00,2500,5544, 'frank.t@example.com', 321654987)








