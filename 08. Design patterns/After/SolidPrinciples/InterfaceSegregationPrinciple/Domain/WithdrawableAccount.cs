using InterfaceSegregationPrinciple.Domain.Services;

namespace InterfaceSegregationPrinciple.Domain
{
    internal abstract class WithdrawableAccount : Account
    {
        protected WithdrawableAccount(string iban, BankingService bankingService) : base(iban)
        {
            BankingService = bankingService;
        }

        protected BankingService BankingService { get; }

        protected abstract decimal WithdrawalComissionPercent { get; }

        public void Withdraw(decimal amount)
        {
            var toWithdraw = BankingService.CalculateWithdrawalAmount(WithdrawalComissionPercent, amount);
            if (Balance < toWithdraw)
            {
                throw new ArgumentException("Insufficient funds.");
            }

            Balance -= toWithdraw;
        }

    }
}
