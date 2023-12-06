﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WealthWave.Test
{
    public class ChequingAccountTests
    {
        [Theory]
        [InlineData(150, 2850, 2700)]
        public void ChequingAccount_WithdrawTransaction_WithdrawRequestedAmount(double testValue, double defaultBalance, double expectedOutput)
        {
            // Arrange varables, classes mocks
            var userAccount = new ChequingAccount(defaultBalance);


            // Act
            userAccount.WithdrawTransaction(testValue);
            var result = userAccount.CurrentBalance;

            // Assert 
            result.Should().NotBe(null);
            result.Should().Be(expectedOutput);
            result.Should().BePositive();

        }
    }
}