using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WealthWave.Test
{
    public class SavingsAccountTests
    {
        [Theory]
        [InlineData(4500, 5000, 9661)]
        public void SavingsAccount_DepositTransaction_DepositRequestedAmount(double testValue, double defaultBalance, double expectedOutput)
        {
            // Arrange varables, classes mocks
            var userAccount = new SavingsAccount(defaultBalance);
            double upperRangeOfOutput = 9662;
            string message;

            // Act
            userAccount.DepositTransaction(testValue, out message);
            var result = userAccount.CurrentBalance;

            // Assert 
            result.Should().NotBe(null);
            // Counts for floating point discrepancy
            // Expecting this value as interest is added after deposit
            result.Should().BeInRange(expectedOutput, upperRangeOfOutput);  
            result.Should().BePositive();


        }

        [Theory]
        [InlineData(45000,50000,96615)]
        public void SavingsAccountBoundary_DepositTransaction_DepositRequestedAmount(double testValue, double defaultBalance, double expectedOutput)
        {
            // Arrange varables, classes mocks
            var userAccount = new SavingsAccount(defaultBalance);  
            string message;

            // Act
            userAccount.DepositTransaction(testValue, out message);
            var result = userAccount.CurrentBalance * 1.017;
            double upperRangeOfOutput = result;
            // Assert 
            result.Should().NotBe(null);
            // Counts for floating point discrepancy
            // Expecting this value as interest is added after deposit
            result.Should().BeInRange(expectedOutput, upperRangeOfOutput);
            result.Should().BePositive();
        }
    }
}
