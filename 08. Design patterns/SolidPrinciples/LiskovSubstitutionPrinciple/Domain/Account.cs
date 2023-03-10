using LiskovSubstitutionPrinciple.Domain.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiskovSubstitutionPrinciple.Domain
{
    internal abstract class Account
    {
        public Account(string iban, BankingService bankingService)
        {
            Iban = iban;
            BankingService = bankingService;
            Balance = 0m;
        }

        protected BankingService BankingService { get; }

        protected abstract decimal WithdrawalComissionPercent { get; }

        public string Iban { get; }

        public decimal Balance { get; private set; }

        public void Withdraw(decimal amount)
        {
            var toWithdraw = BankingService.CalculateWithdrawalAmount(WithdrawalComissionPercent, amount);
            if (Balance < toWithdraw)
            {
                throw new ArgumentException("Insufficient funds.");
            }

            Balance -= toWithdraw;
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
