using DependencyInversionPrinciple.Domain.Services;

namespace DependencyInversionPrinciple.Domain
{
    internal abstract class WithdrawableAccount : Account
    {
        protected WithdrawableAccount(string iban, IWithdrawalAmountCalculator withdrawalAmountCalculator) : base(iban)
        {
            WithdrawalAmountCalculator = withdrawalAmountCalculator;
        }

        protected IWithdrawalAmountCalculator WithdrawalAmountCalculator { get; }

        protected abstract decimal WithdrawalComissionPercent { get; }

        public void Withdraw(decimal amount)
        {
            var toWithdraw = WithdrawalAmountCalculator.CalculateWithdrawalAmount(WithdrawalComissionPercent, amount);
            if (Balance < toWithdraw)
            {
                throw new ArgumentException("Insufficient funds.");
            }

            Balance -= toWithdraw;
        }

    }
}
