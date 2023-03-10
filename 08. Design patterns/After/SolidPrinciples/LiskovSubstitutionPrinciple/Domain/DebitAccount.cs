using LiskovSubstitutionPrinciple.Domain.Services;

namespace LiskovSubstitutionPrinciple.Domain
{
    internal class DebitAccount : Account
    {
        public DebitAccount(string iban, decimal withdrawalComissionPercent, BankingService bankingService) : base(iban, bankingService)
        {
            WithdrawalComissionPercent = withdrawalComissionPercent;
        }

        protected override decimal WithdrawalComissionPercent { get; }
    }
}
