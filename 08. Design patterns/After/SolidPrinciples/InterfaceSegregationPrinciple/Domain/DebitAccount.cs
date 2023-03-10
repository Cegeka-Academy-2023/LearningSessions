using InterfaceSegregationPrinciple.Domain.Services;

namespace InterfaceSegregationPrinciple.Domain
{
    internal class DebitAccount : WithdrawableAccount
    {
        public DebitAccount(string iban, decimal withdrawalComissionPercent, BankingService bankingService) : base(iban, bankingService)
        {
            WithdrawalComissionPercent = withdrawalComissionPercent;
        }

        protected override decimal WithdrawalComissionPercent { get; }
    }
}
