using DependencyInversionPrinciple.Domain.Services;

namespace DependencyInversionPrinciple.Domain
{
    internal class CreditAccount : WithdrawableAccount
    {
        public CreditAccount(string iban, decimal withdrawalComissionPercent, WithdrawalAmountCalculator withdrawalAmountCalculator) : base(iban, withdrawalAmountCalculator)
        {
            WithdrawalComissionPercent = withdrawalComissionPercent;
        }

        protected override decimal WithdrawalComissionPercent { get; }
    }
}
