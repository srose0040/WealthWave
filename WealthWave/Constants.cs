using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WealthWave
{
   /*
    * Class Name:	Constants
    * Purpose:		The purpose of this class is to provide a lot of the constants needed in this solution file.
    * By:			Saje Antoine Rose
    * Abilities:	This class allows for the removal of magic numbers.
    */
    internal class Constants
    {
        public const int kDefaultAccountNumber = 10000000; // The default number for an account 8 Digit number. 
        public const int kEmptyAccountBalance = 0;  // Default account balance
        public const int kOne = 1; // This is needed to make sure they cant apply for a loan of 10 cents or anything. // This bank will make no loans under $1
        public const int kZero = 0; // Represents the value "0" for many scenarios removing the possibility of magic numbers
        public const double kDefaultInterestRate = 1.017; // This is the standard interest rate for RBC Savings Accounts 
        public const double kDefaultLoanInterestRate = 1.061; // The mathematical representation for a 6.1% loan
        public const double kLoanAccountPrintableInterestRate = 6.1; // This is a better printable representation of the interest rate
        public const double kSavingsAccountPrintableInterestRate = 1.7; // This is a better printable representation of the interest rate
        public const double kDefaultLoanAmount = 0; // Default loan amount
        public const double kMaxLoanAmount = 100000;
        public const int kMaxDeferredPayments = 6; // Maximum payments the user can defer if thwish not to be put into collections with account balance able to pay off debt
        public const int kBaseAccount = 0; // Account Level identifyer in numerical form
        public const int kSavingsAccount = 1; // Account Level identifyer in numerical form
        public const int kChequingAccount = 2; // Account Level identifyer in numerical form
        public const int kLoanAccount = 3; // Account Level identifyer in numerical form
        public const double kDefaultAnnualFee = 48; // The yearly fee for RBC day-to-day chequing accounts
        public const int kMaxQuartersOfYear = 4; // There are 4 quarters in a year
    }
}
