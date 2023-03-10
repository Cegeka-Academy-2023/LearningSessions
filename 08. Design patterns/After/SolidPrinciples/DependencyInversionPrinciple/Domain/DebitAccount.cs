using DependencyInversionPrinciple.Domain.Services;

namespace DependencyInversionPrinciple.Domain
{
    internal class DebitAccount : WithdrawableAccount
    {
        public DebitAccount(string iban, decimal withdrawalComissionPercent, IWithdrawalAmountCalculator withdrawalAmountCalculator) : base(iban, withdrawalAmountCalculator)
        {
            WithdrawalComissionPercent = withdrawalComissionPercent;
        }

        protected override decimal WithdrawalComissionPercent { get; }
    }
}
