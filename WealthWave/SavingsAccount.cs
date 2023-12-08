using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WealthWave
{
    public class SavingsAccount : Account
    {
        private double interestRate;

        /*
        * Constructor: SavingsAccount() : base()
        * Description: This constructor initializes all the data members with default values while calling on its parents default constructor.
        * Parameters:  Void.
        * Returns:     SavingsAcccount Obj.
        */
        public SavingsAccount() : base()
        {
            interestRate = Constants.kDefaultInterestRate;
            AccountLevel = Constants.kSavingsAccount; // Letting the program know that this is a savings account
        }

        /*
        * Constructor: SavingsAccount() : base()
        * Description: This constructor initializes all the data members with specified values while calling on its parents overloaded constructor.
        * Parameters:  double newCurrentBalance: The user specified default balance for the account
        * Returns:     SavingsAcccount Obj.
        */
        public SavingsAccount(double newCurrentBalance) : base(newCurrentBalance)
        {
            interestRate = Constants.kDefaultInterestRate;
            AccountLevel = Constants.kSavingsAccount; // Letting the program know that this is a savings account
        }

        /*
        * Property:    InterestRate
        * Description: This property provides the interest rate and supports setting a new interest rate privatley
        * Parameters:  Void.
        * Returns:     double interestRate
        */
        public double InterestRate
        {
            get { return interestRate; }
            private set { interestRate = value; }
        }

        /*
        * Method:      ApplyInterest()
        * Description: This method adds the users gained interest to their current balance
        * Parameters:  Void.
        * Returns:     Void.
        */
        public void ApplyInterest()
        {
            CurrentBalance *= InterestRate;
        }

        /*
        * Method:      DepositTransaction()
        * Description: This overrided method provides the user with the ability to deposit into their account. It also applies interest to their balance
        * Parameters:  double newDepositAmount: The suggested amount to deposit
        * Returns:     Void.
        */
        public override void DepositTransaction(double newDepositAmount, out string message)
        {
            message = string.Empty;
            if (newDepositAmount > Constants.kZero)
            {
                CurrentBalance += newDepositAmount; // Adding the deposit amount to the current balance
                ApplyInterest(); // Applying interest to the current balance after the transaction
            }
            else
            {
                message = "Please deposit a positive amount... \n"; // This error message is because it is impossible to deposit a negative amount into an account
            }
        }
    }
}
