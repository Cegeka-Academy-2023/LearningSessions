using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleResponsibilityPrinciple.Domain
{
    internal class Account
    {
        public Account(string iban, decimal withdrawalComissionPercent)
        {
            Iban = iban;
            WithdrawalComissionPercent = withdrawalComissionPercent;
            Balance = 0m;
        }

        public string Iban { get; }

        public decimal WithdrawalComissionPercent { get; }

        public decimal Balance { get; private set; }

        public void Withdraw(decimal amount)
        {
            decimal toWithdraw = CalculateWithdrawalAmount(amount);
            ValidateBalance(toWithdraw);
            Balance -= toWithdraw;
        }

        private decimal CalculateWithdrawalAmount(decimal amount)
        {
            return amount + amount * WithdrawalComissionPercent / 100;
        }

        private void ValidateBalance(decimal toWithdraw)
        {
            if (Balance < toWithdraw)
            {
                throw new ArgumentException("Insufficient funds.");
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0m)
            {
                throw new ArgumentException(nameof(amount), "Amount must be greater than zero.");
            }

            Balance += amount;
        }
    }
}
