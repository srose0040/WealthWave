using ControlzEx.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WealthWave
{
   /*
    * Class Name:	Account
    * Purpose:		The purpose of this class is to provide the necessary data members, methods and properties to be derived by more specialized account classes.
    * By:			Saje Antoine Rose
    * Abilities:	This class initializes its data members, allows access to its methods and properties.
    */
    internal class Account
    {
        private int accountNumber;

        private double currentBalance;

        private static int numberOfAccountsCreated = 0; // This is so that we can keep track of the account numbers (they cannot repeat)

        private int accountLevel; // This is so that we know the type of account it is

        /*
        * Constructor: Account()
        * Description: This constructor initializes all the data members with default values.
        * Parameters:  Void.
        * Returns:     Acccount Obj.
        */
        public Account()
        {
            currentBalance = Constants.kEmptyAccountBalance; // Default initialization

            // If no accounts created, assign default account number ELSE add number of accounts created to default number
            if (numberOfAccountsCreated == Constants.kZero)
            {
                accountNumber = Constants.kDefaultAccountNumber; // Default initialization
            }
            else
            {
                accountNumber = Constants.kDefaultAccountNumber + numberOfAccountsCreated;
            }

            numberOfAccountsCreated++; // Keeping track of accounts created
            accountLevel = Constants.kBaseAccount; // Letting the program know that this is a default account
        }

        /*
        * Constructor: Account()
        * Description: This constructor initializes all the data members with default values while accepting a specified number to be the default account balance.
        * Parameters:  double newCurrentBalance: The user specified default balance for the account
        * Returns:     Account Obj.
        */
        public Account(double newCurrentBalance)
        {
            if (newCurrentBalance < Constants.kEmptyAccountBalance) // If they want to add a negative balance to the account
            {
                currentBalance = Constants.kEmptyAccountBalance; // This will not be allowed and will be defaulted to $0
            }
            else
            {
                currentBalance = newCurrentBalance;
            }

            // If no accounts created, assign default account number ELSE add number of accounts created to default number
            if (numberOfAccountsCreated == Constants.kZero)
            {
                accountNumber = Constants.kDefaultAccountNumber;
            }
            else
            {
                accountNumber = Constants.kDefaultAccountNumber + numberOfAccountsCreated;
            }

            numberOfAccountsCreated++; // Increment the number of accounts created
            accountLevel = Constants.kBaseAccount; // Letting the program know that this is a default account
        }

        /*
        * Property:    AccountNumber
        * Description: This property provides the account number and supports setting a new account number privatley
        * Parameters:  Void.
        * Returns:     int accountNumber
        */
        public int AccountNumber
        {
            get { return accountNumber; }
            private set { accountNumber = value; } // The customer should not be allowed to set it
        }

        /*
        * Property:    CurrentBalance
        * Description: This property provides the current balance and supports setting a new current balance within the derived classes 
        * Parameters:  Void.
        * Returns:     double currentBalance
        */
        public double CurrentBalance
        {
            get { return currentBalance; }
            protected set { currentBalance = value; }
        }

        /*
        * Property:    AccountLevel
        * Description: This property provides the account level and supports setting a new account level within the derived classes 
        * Parameters:  Void.
        * Returns:     int accountLevel
        */
        public int AccountLevel
        {
            get { return accountLevel; }
            protected set { accountLevel = value; } // The customer should not be allowed to set it
        }

        /*
        * Property:    NumberOfAccountsCreated
        * Description: This property provides the number of accounts created and supports setting a value privatley
        * Parameters:  Void.
        * Returns:     int numberOfAccountsCreated
        */
        public int NumberOfAccountsCreated
        {
            get { return numberOfAccountsCreated; }
            private set { numberOfAccountsCreated = value; } // Only we should set this
        }

        /*
        * Method:      GetAccountInfo()
        * Description: This method provides the user with the accounts info 
        * Parameters:  Void.
        * Returns:     Void.
        */
        public void GetAccountInfo()
        {
            Console.WriteLine("Account Number: {0}\nYour Account Balance Is: {1:C}\n", AccountNumber, CurrentBalance); // Maybe use \n?
        }

        /*
        * Method:      GetAccountInfo()
        * Description: This overloaded and overrided method provides the user with the accounts info based on the account level
        * Parameters:  double accountRate: The account level
        * Returns:     Void.
        */
        public virtual void GetAccountInfo(double accountRate)
        {
            if (AccountLevel == Constants.kSavingsAccount)
            {
                Console.WriteLine("Account Type: Savings Account\nAccount Number: {0}\nYour Account Balance Is: {1:C}\nYour Interest Rate Is: {2:0.00}%\n",
                    AccountNumber, CurrentBalance, Constants.kSavingsAccountPrintableInterestRate);
            }
            else if (AccountLevel == Constants.kChequingAccount)
            {
                Console.WriteLine("Account Type: Chequing Account\nAccount Number: {0}\nYour Account Balance Is: {1:C}\nYour Annual Fee Is: {2:C}\n",
                    AccountNumber, CurrentBalance, accountRate);
            }
            else if (AccountLevel == Constants.kLoanAccount)
            {
                Console.WriteLine("Account Type: Loan Account\nAccount Number: {0}\nYour Account Balance Is: {1:C}\nYour Loan Interest Rate Is: {2:0.00}%\n",
                    AccountNumber, CurrentBalance, Constants.kLoanAccountPrintableInterestRate);
            }

        }

        /*
        * Method:      DepositTransaction()
        * Description: This overrided method provides the user with the ability to deposit into their account
        * Parameters:  double newDepositAmount: The suggested amount to deposit
        * Returns:     Void.
        */
        public virtual void DepositTransaction(double newDepositAmount)
        {
            if (newDepositAmount > Constants.kZero) // if the deposit amount is greater than $0
            {
                CurrentBalance += newDepositAmount; // Adding the deposit amount to the current balance
            }
            else
            {
                Console.WriteLine("Please deposit a positive amount... \n"); // This error message is because it is impossible to deposit a negative amount into an account
            }
        }

        /*
        * Method:      WithdrawTransaction()
        * Description: This overrided method provides the user with the ability to withdraw from their account
        * Parameters:  double newWithdrawAmount: The suggested amount to deposit
        * Returns:     Void.
        */
        public virtual void WithdrawTransaction(double newWithdrawAmount)
        {
            const double kEpsilon = -0.00404; // This is to know if the values are equal or not due to floating point inaccuracy
            double floatingPointComparator = CurrentBalance - newWithdrawAmount; // This is to compare to the epsilon

            if (newWithdrawAmount > Constants.kZero) // If the amount to withdraw is a positive number
            {
                if (Constants.kZero > (CurrentBalance - newWithdrawAmount)) // If the account balance is now going to be less than $0
                {
                    if (floatingPointComparator > kEpsilon) // If the withdraw request is actually valid but we are just dealing with floating point inaccuracy
                    {
                        CurrentBalance -= newWithdrawAmount; // Subtracting the withdraw amount to the current balance
                    }
                    else
                    {
                        InvalidTransaction(); // Sorry withdrawl cant be done

                    }
                }
                else
                {
                    CurrentBalance -= newWithdrawAmount; // Subtracting the withdraw amount to the current balance
                }
            }
            else
            {
                Console.WriteLine("Please withdraw a positive amount... \n");
                // This error message is because it is impossible to withdraw a negative amount into an account in the terms of this program you must withdraw a positive double
            }
        }

        /*
        * Method:      InvalidTransaction()
        * Description: This method tells the user that their transaction was invalid and is called when there is a withdrawl that is more than the account balance
        * Parameters:  Void.
        * Returns:     Void.
        */
        public void InvalidTransaction()
        {
            Console.WriteLine("Sorry, you have insuffcient funds to complete this transaction... \nPlease withdraw an amount no greater than {0:C}\n", CurrentBalance);
        }

    }
}
