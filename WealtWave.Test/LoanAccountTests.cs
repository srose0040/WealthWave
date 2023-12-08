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

        [Theory]
        [InlineData(10000, 10610, 10611)]
        public void LoanAccount_ApplyInterestOnLoan_NoticeInterestAppliedToLoan(double testValue, double expectedOutput, double upperRangeOfOutput)
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
    }
}
