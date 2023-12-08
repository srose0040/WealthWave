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
            int amountToWithdraw = 10000;
            var userAccount = new LoanAccount();
            string result;


            // Act
            userAccount.ApplyForLoan(amountToWithdraw, out result);
            

            // Assert 
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Contain("Your loan request has been granted.", Exactly.Once());
            


        }
    }
}
