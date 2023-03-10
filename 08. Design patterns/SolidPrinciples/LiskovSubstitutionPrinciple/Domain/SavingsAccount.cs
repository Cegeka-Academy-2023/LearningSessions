using LiskovSubstitutionPrinciple.Domain.Services;

namespace LiskovSubstitutionPrinciple.Domain
{
    internal class SavingsAccount : Account
    {
        public SavingsAccount(string iban) : base(iban, null)
        {
        }

        protected override decimal WithdrawalComissionPercent => throw new NotSupportedException("Cannot withdraw from savings account.");
    }
}
