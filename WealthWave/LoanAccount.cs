using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WealthWave
{
    /*
     * Class Name:	LoanAccount
     * Purpose:		The purpose of this class is to provide the necessary data member and logic behind the methods and properties 
     *               to be applied to a more specialized account type, which is itself the ChequingAccount. It inherits from the base class, Account
     * By:			Saje Antoine Rose
     * Abilities:	This class initializes its data members, allows access to its methods and properties.
     */
    public class LoanAccount : Account
    {
        public double loanInterestRate;
        public double loanAmount; // How much does the user owe the bank?
        public int deferredPayments; // How many times have they tried to skirt around paying their bills

        /*
        * Constructor: LoanAccount() : base()
        * Description: This constructor initializes all the data members with default values while calling on its parents default constructor.
        * Parameters:  Void.
        * Returns:     LoanAcccount Obj.
        */
        public LoanAccount() : base()
        {
            loanInterestRate = Constants.kDefaultLoanInterestRate;
            AccountLevel = Constants.kLoanAccount; // Letting the program know that this is a loan account
            loanAmount = Constants.kDefaultLoanAmount;
            deferredPayments = Constants.kZero;
        }

        /*
        * Constructor: LoanAccount() : base()
        * Description: This constructor initializes all the data members with specified values while calling on its parents overloaded constructor.
        * Parameters:  double newCurrentBalance: The user specified default balance for the account
        * Returns:     LoanAcccount Obj.
        */
        public LoanAccount(double newCurrentBalance) : base(-1 * newCurrentBalance) // This makes it so that it doesnt add to users balance. They will have to withdraw this amount
        { // THE VALUE IN THE BASE PARAMETER LIST MUST NEVER BE CHANGED^^^^^
            loanInterestRate = Constants.kDefaultLoanInterestRate;
            AccountLevel = Constants.kLoanAccount; // Letting the program know that this is a loan account
            loanAmount = newCurrentBalance; // Loan amount is what the user specified
            deferredPayments = Constants.kZero;
        }

        /*
        * Property:    LoanInterestRate
        * Description: This property provides the interest rate and supports setting a new interest rate privatley
        * Parameters:  Void.
        * Returns:     double loanInterestRate
        */
        public double LoanInterestRate
        {
            get { return loanInterestRate; }
            set { loanInterestRate = value; } // Should only be able to be done internally
        }

        /*
        * Property:    LoanAmount
        * Description: This property provides the interest amount and supports setting a new interest amount privatley
        * Parameters:  Void.
        * Returns:     double loanAmount
        */
        public double LoanAmount
        {
            get { return loanAmount; }
            set { loanAmount = value; }
        }

        /*
        * Property:    DeferredPayments
        * Description: This property provides the amount of deferred payments and supports setting a new amount of deferred payments privatley
        * Parameters:  Void.
        * Returns:     double deferredPayments
        */
        public int DeferredPayments
        {
            get { return deferredPayments; }
            set { deferredPayments = value; }
        }

        /*
        * Method:      ApplyForLoan()
        * Description: This method provides the user with the ability to apply for a loan. 
        * Parameters:  double requestedLoanAmount: How much the user wants to borrow from the bank.
        * Returns:     Void.
        */
        public void ApplyForLoan(double requestedLoanAmount, out string message)
        {
            message = string.Empty;

            // If you already have a loan NO LOAN
            if (LoanAmount > Constants.kDefaultLoanAmount)
            {
                message = string.Format("You cannot apply for a new loan without paying off your loan in full first.\nYou still have {0:C} as an outstanding balance.\nPlease make a payment to keep your account in good standing.\n", LoanAmount);
            }
            else if (requestedLoanAmount > Constants.kMaxLoanAmount) // if they want too much money that the bank is not prepared to give
            {

                message = string.Format("Your loan request is greater than the maximum allowed amount. Your loan has been capped at {0:C}.\nThe interest rate of {1:0.0}% has already been applied\n", Constants.kMaxLoanAmount, Constants.kLoanAccountPrintableInterestRate);
                LoanAmount = Constants.kMaxLoanAmount; // forcing them to take what we will give
            }
            else if (requestedLoanAmount < Constants.kOne) // If they want a loan of $0
            {
                message = "The minimum amount to be approved for a loan is $1\n";
            }
            else
            {
                if (CurrentBalance < Constants.kZero) // if they have an outstanding balance
                {
                    message = string.Format("You cannot apply for a new loan without settling your account first.\nYou still have {0:C} as an outstanding balance.\nPlease make a payment to keep your account in good standing.\n", CurrentBalance);
                }
                else // Everything is A-OK
                {

                    message = string.Format("Your loan request has been granted. You have been granted a loan of {0:C}.\nThe interest rate of {1:0.0}% has already been applied\nPlease withdraw the loan amount in full to avoid additional fees\n", requestedLoanAmount, Constants.kLoanAccountPrintableInterestRate);
                    LoanAmount = requestedLoanAmount;
                }
            }
        }

        /*
        * Method:      InterestCalculation()
        * Description: This method provides the bank with the ability to charge the user interest on their loan.
        * Parameters:  Void.
        * Returns:     Void.
        */
        public void InterestCalculation()
        {
            LoanAmount *= Constants.kDefaultLoanInterestRate; // charging interest rate
            CurrentBalance = ChangeSignOfNumber(LoanAmount); // Updating balance
        }

        /*
        * Method:      ChangeSignOfNumber()
        * Description: This method turns a postivine number negative or vice-versa
        * Parameters:  double numberToChange: The number to convert
        * Returns:     double numberToChange: The converted number
        */
        private double ChangeSignOfNumber(double numberToChange) // Private because user can cause harm with this
        {
            const int kSignChangeOperator = -1; // The number that will help us change the sign.
            numberToChange *= kSignChangeOperator; // Converting the number
            return numberToChange;
        }

        /*
        * Method:      WithdrawTransaction()
        * Description: This overrided method provides the user with the ability to withdraw from their account.
        *              It prevents them from withdrawing anything but the loan amount
        * Parameters:  double newWithdrawAmount: The suggested amount to deposit
        * Returns:     Void.
        */
        public override void WithdrawTransaction(double newWithdrawAmount, out string message)
        {
            message = string.Empty;
            if (newWithdrawAmount > Constants.kZero) // if they want to withdraw a positive #
            {
                double calculatedBalanceAfterPotentialWithdrawl = (CurrentBalance - newWithdrawAmount);
                if (calculatedBalanceAfterPotentialWithdrawl < (ChangeSignOfNumber(LoanAmount)))
                {
                    // If the account balance is now going to be less than $0
                    message = "You cannot withdraw more than the loan approved you for.\n";
                }
                else if (newWithdrawAmount == LoanAmount) // if they are withdrawing a valid amount
                {
                    CurrentBalance -= newWithdrawAmount; // Subtracting the withdraw amount to the current balance
                }
                else
                { // if they dont want to withdraw enough
                    message = string.Format("Please withdraw the full amount of the requested loan {0:C}\n", LoanAmount.ToString());
                }
            }
            else
            {
                message = "Please withdraw a positive amount... \n";
                // This error message is because it is impossible to withdraw a negative amount into an account in the terms of this program you must withdraw a positive double
            }
        }

        /*
        * Method:      DebtCollector()
        * Description: This method provides the bank with the ability to collect user debt.
        * Parameters:  Void.
        * Returns:     Void.
        */
        public string DebtCollector()
        {
            string message = string.Empty;
            if (LoanAmount > Constants.kZero) // if the user owe the bank
            {
                CurrentBalance = Math.Round(CurrentBalance);
                LoanAmount = Math.Round(LoanAmount); // Rounding these to make them easier
                const int kReposessionValue = 1; // So we can steal the users money
                message += "You have failed to repay the loan back in time. Your account is now in collections.";
                message += string.Format("The Loan Amount of {0:C} will now be retrived and the account will be settled.\n", LoanAmount);
                for (int counter = Constants.kZero; LoanAmount > Constants.kZero; counter++)
                {
                    CurrentBalance += kReposessionValue;
                    LoanAmount -= kReposessionValue;
                    // Fairly re-assigning the money back to the bank  
                }
            }
            return message;
        }



        /*
        * Method:      DepositTransaction()
        * Description: This overrided method provides the user with the ability to deposit into their account. It also applies interest to their balance
        * Parameters:  double newDepositAmount: The suggested amount to deposit
        * Returns:     Void.
        */
        public override void DepositTransaction(double newDepositAmount, out string message) // This is to pay off the loan so maybe the account balance should decrease
        {
            message = string.Empty;
            int deferredPaymentsLast = DeferredPayments; // Storing amount of deferred payments
            if (newDepositAmount > Constants.kZero) // if they want to deposit a positive amount
            {
                if ((newDepositAmount + CurrentBalance) <= Constants.kZero) // if tey want to withdraw a valid amount
                {
                    CurrentBalance += newDepositAmount; // Adding the deposit amount to the current balance
                    LoanAmount -= newDepositAmount; // Updating loan amount
                    InterestCalculation();
                }
                else if (LoanAmount < 0.02) // Fixes floating point problems
                {
                    LoanAmount = 0;
                    CurrentBalance = 0;
                }
                else // they are trying to overfill the account THIS WILL ALSO BE CALLED IF THE USER DOES NOT WITHDRAW THEIR LOAN FIRST
                {
                    message += "You cannot deposit more than the account will allow. This is a Loan Account, not a Savings Account";
                    message += string.Format("The most you can deposit is {0:C}\n", LoanAmount);
                }

                if (DeferredPayments == Constants.kMaxDeferredPayments) // Being fair and giving user 6 chances to pay balance in full
                {
                    DebtCollector(); // If the user has a balance to be collected
                    DeferredPayments = Constants.kZero;
                }

            }
            else
            {
                message += ("Please deposit a positive amount... \n"); // This error message is because it is impossible to deposit a negative amount into an account
            }
            if (deferredPaymentsLast == Constants.kMaxDeferredPayments)
            {
                DeferredPayments = Constants.kZero; // Restoring deferred payments
            }
            else
            {
                DeferredPayments++; // Incrementing deferred payments
            }

        }
    }
}
