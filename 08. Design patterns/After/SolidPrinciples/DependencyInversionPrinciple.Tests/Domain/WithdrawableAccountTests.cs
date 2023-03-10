using DependencyInversionPrinciple.Domain;
using DependencyInversionPrinciple.Domain.Services;

using Xunit;

namespace DependencyInversionPrinciple.Tests.Domain
{
    public class WithdrawableAccountTests
    {
        [Fact]
        public void WithdrawShouldSucceed()
        {
            var amountCalculator = new DummyCalculator();
            var debitAccount = new DebitAccount("RO19PORL1528178466271384", 0.1m, amountCalculator);
            debitAccount.Deposit(100m);
            debitAccount.Withdraw(10);
            Assert.Equal(90m, debitAccount.Balance);
        }

        class DummyCalculator : IWithdrawalAmountCalculator
        {
            public decimal CalculateWithdrawalAmount(decimal withdrawalComissionPercent, decimal amount)
            {
                return amount;
            }
        }
    }
}