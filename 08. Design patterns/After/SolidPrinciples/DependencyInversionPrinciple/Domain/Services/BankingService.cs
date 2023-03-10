using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DependencyInversionPrinciple.Domain.Services
{
    internal class BankingService
    {
        public void Transfer(WithdrawableAccount from, Account to, decimal amount)
        {
            from.Withdraw(amount);
            to.Deposit(amount);
        }
    }
}
