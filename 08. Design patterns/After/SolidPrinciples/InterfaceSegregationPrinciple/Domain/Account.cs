using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceSegregationPrinciple.Domain
{
    internal abstract class Account
    {
        public Account(string iban)
        {
            Iban = iban;
            Balance = 0m;
        }

        public string Iban { get; }

        public decimal Balance { get; protected set; }


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
