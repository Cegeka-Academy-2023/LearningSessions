using OpenClosedPrinciple.Domain.Services;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrinciple.Domain
{
    internal class Account
    {
        public Account(AccountType accountType, string iban, BankingService bankingService)
        {
            AccountType = accountType;
            Iban = iban;
            BankingService = bankingService;
            Balance = 0m;
        }

        private AccountType AccountType { get; }
        
        private BankingService BankingService { get; }

        public string Iban { get; }

        public decimal Balance { get; private set; }

        public void Withdraw(decimal amount)
        {
            var toWithdraw = BankingService.CalculateWithdrawalAmount(this.AccountType, amount);
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
