using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WealthWave.Test
{
    public class LoanAccountTests
    {
        [Fact]
        public void LoanAccount_ApplyForLoan_GetApprovedForLoanAmount()
        {
            // Arrange varables, classes mocks
            int amountToApplyFor = 10000;
            var userAccount = new LoanAccount();
            string result;


            // Act
            userAccount.ApplyForLoan(amountToApplyFor, out result);
            

            // Assert 
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Contain("Your loan request has been granted.", Exactly.Once());
            
        }

        [Fact]
        public void LoanAccountBoundary_ApplyForLoan_GetApprovedForLoanAmount()
        {
            // Arrange varables, classes mocks
            int amountToApplyFor = 25000;
            var userAccount = new LoanAccount();
            string result;


            // Act
            userAccount.ApplyForLoan(amountToApplyFor, out result);


            // Assert 
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Contain("Your loan request has been granted.", Exactly.Once());

        }



        [Theory]
        [InlineData(10000, 0, 10611)]
        public void LoanAccount_InterestCalculation_NoticeInterestAppliedToLoan(double testValue, double expectedOutput, double upperRangeOfOutput)
        {
            // Arrange varables, classes mocks
            var userAccount = new LoanAccount();
            string message;
            


            // Act
            userAccount.ApplyForLoan(testValue, out message);
            userAccount.InterestCalculation();
            var result = userAccount.LoanAmount;


            // Assert 
            result.Should().NotBe(null);
            // Counts for floating point discrepancy
            result.Should().BeInRange(expectedOutput, upperRangeOfOutput);
            result.Should().BePositive();
        }

        [Theory]
        [InlineData(10000, -10000)]
        public void LoanAccount_WithdrawTransaction_WithdrawRequestedAmount(double testValue, double expectedOutput)
        {
            // Arrange varables, classes mocks
            var userAccount = new LoanAccount();
            string message;



            // Act
            userAccount.ApplyForLoan(testValue, out message);
            userAccount.WithdrawTransaction(testValue, out message);
            var result = userAccount.CurrentBalance;


            // Assert 
            result.Should().NotBe(null);
            // Counts for floating point discrepancy
            result.Should().Be(expectedOutput);
            result.Should().BeNegative();
        }

        [Theory]
        [InlineData(500, 0)]
        public void LoanAccount_DebtCollector_CollectUserDebt(double testValue, double expectedOutput)
        {
            // Arrange varables, classes mocks
            var userAccount = new LoanAccount();
            string message;



            // Act
            userAccount.ApplyForLoan(testValue, out message);
            userAccount.DebtCollector();
            var result = userAccount.LoanAmount;


            // Assert 
            result.Should().NotBe(null);
            // Counts for floating point discrepancy
            result.Should().Be(expectedOutput);
            
        }

        [Theory]
        [InlineData(800, 12546, 12462.50, 12463)]
        public void LoanAccount_DepositTransaction_DepositRequestedAmount(double testValue, double requestedLoan, double expectedOutput, double upperRangeOfOutput)
        {
            // Arrange varables, classes mocks
            var userAccount = new LoanAccount();
            string message;



            // Act
            userAccount.ApplyForLoan(requestedLoan, out message);
            userAccount.WithdrawTransaction(requestedLoan, out message); // Must withdraw loan before paying it off
            userAccount.DepositTransaction(testValue, out message);
            var result = userAccount.LoanAmount;


            // Assert 
            result.Should().NotBe(null);
            // Counts for floating point discrepancy
            result.Should().BeInRange(expectedOutput, upperRangeOfOutput);
            result.Should().BePositive();

        }


    }
}
