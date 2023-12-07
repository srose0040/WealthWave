using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
   /*
    * Class Name:	ChequingAccount
    * Purpose:		The purpose of this class is to provide the necessary data member and logic behind the methods and properties 
    *               to be applied to a more specialized account type, which is itself the ChequingAccount. It inherits from the base class, Account
    * By:			Saje Antoine Rose
    * Abilities:	This class initializes its data members, allows access to its methods and properties.
    */
    public class ChequingAccount : Account
    {
        private double annualFee;
        private int quartersOfTheYear; // used to determine when the annual fee should be charged

        /*
        * Constructor: ChequingAccount() : base()
        * Description: This constructor initializes all the data members with default values while calling on its parents default constructor.
        * Parameters:  Void.
        * Returns:     ChequingAcccount Obj.
        */
        public ChequingAccount() : base()
        {
            annualFee = Constants.kDefaultAnnualFee;
            quartersOfTheYear = Constants.kZero;
            AccountLevel = Constants.kChequingAccount; // Letting the program know that this is a chequing account
        }

        /*
        * Constructor: ChequingAccount() : base()
        * Description: This constructor initializes all the data members with specified values while calling on its parents overloaded constructor.
        * Parameters:  double newCurrentBalance: The user specified default balance for the account
        * Returns:     ChequingAcccount Obj.
        */
        public ChequingAccount(double newCurrentBalance) : base(newCurrentBalance)
        {
            annualFee = Constants.kDefaultAnnualFee;
            quartersOfTheYear = Constants.kZero;
            AccountLevel = Constants.kChequingAccount; // Letting the program know that this is a chequing account
        }

        /*
        * Property:    AnnualFee
        * Description: This property provides the annual fee and supports setting a new annual fee privatley
        * Parameters:  Void.
        * Returns:     double annualFee
        */
        public double AnnualFee
        {
            get { return annualFee; }
            private set { annualFee = value; }
        }

        /*
        * Property:    QuartersOfTheYear
        * Description: This property provides the quarter of the year and supports setting a new amount of quarters in the year privatley
        * Parameters:  Void.
        * Returns:     int quartersOfTheYear
        */
        public int QuartersOfTheYear
        {
            get { return quartersOfTheYear; }
            private set { quartersOfTheYear = value; }
        }


        /*
        * Method:      ApplyAnnualFee()
        * Description: This overrided method provides the bank with the ability to charge the annual fee. It is called when the user withdraws their funds
        * Parameters:  Void.
        * Returns:     Void.
        */
        public void ApplyAnnualFee() // Could use more logic once annual fee requirements are more known
        {
            CurrentBalance -= AnnualFee;
        }


        /*
        * Method:      WithdrawTransaction()
        * Description: This overrided method provides the user with the ability to withdraw from their account
        * Parameters:  double newWithdrawAmount: The suggested amount to deposit
        * Returns:     Void.
        */
        public override void WithdrawTransaction(double newWithdrawAmount)
        {
            const double kEpsilon = -0.00404; // This is to know if the values are equal or not due to floating point inaccuracy
            double floatingPointComparator = CurrentBalance - newWithdrawAmount; // This is to compare to the epsilon

            if (newWithdrawAmount > Constants.kZero) // If the amount to withdraw is a positive number
            {
                if (Constants.kZero > (CurrentBalance - newWithdrawAmount)) // If the account balance is now going to be less than $0
                {
                    if (floatingPointComparator > kEpsilon) // If the withdraw request is valid but we are just dealing with floating point inaccuracy
                    {
                        if (QuartersOfTheYear == Constants.kMaxQuartersOfYear) // if a "Year" has gone by
                        {
                            ApplyAnnualFee();
                            Console.WriteLine("The Annual fee has just been applied. If your account balance is negative please restore it to good standings.\n");
                            QuartersOfTheYear = Constants.kZero; // reset the year calendar
                        }

                        CurrentBalance -= newWithdrawAmount; // Subtracting the withdraw amount to the current balance
                        QuartersOfTheYear++;

                    }
                    else
                    {
                        InvalidTransaction(); // Not gonna get the money today bud.

                    }
                }
                else
                {
                    if (QuartersOfTheYear == Constants.kMaxQuartersOfYear) // if a "Year" has gone by
                    {
                        ApplyAnnualFee(); // Bank needs to get PAID!!!
                        Console.WriteLine("The Annual fee has just been applied. If your account balance is negative please restore it to good standings.\n");
                        QuartersOfTheYear = Constants.kZero; // reset the year calendar
                    }

                    CurrentBalance -= newWithdrawAmount; // Subtracting the withdraw amount to the current balance
                    QuartersOfTheYear++;
                }
            }
            else
            {
                Console.WriteLine("Please withdraw a positive amount... \n");
                // This error message is because it is impossible to withdraw a negative amount into an account in the terms of this program you must withdraw a positive double
            }
        }
    }
}
