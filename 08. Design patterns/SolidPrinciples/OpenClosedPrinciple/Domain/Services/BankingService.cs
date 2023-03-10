using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosedPrinciple.Domain.Services
{
    internal class BankingService
    {
        public decimal CalculateWithdrawalAmount(AccountType accountType, decimal amount)
        {
            switch (accountType)
            {
                case AccountType.Debit:
                    return amount + amount * 0.1m / 100;
                case AccountType.Credit:
                    return amount + amount * 0.5m / 100;
                default:
                    return amount;
            }
        }

    }
}
