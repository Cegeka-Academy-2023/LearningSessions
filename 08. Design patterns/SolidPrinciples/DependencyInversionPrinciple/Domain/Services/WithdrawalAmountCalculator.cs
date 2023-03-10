namespace DependencyInversionPrinciple.Domain.Services
{
    internal class WithdrawalAmountCalculator : IWithdrawalAmountCalculator
    {
        public decimal CalculateWithdrawalAmount(decimal withdrawalComissionPercent, decimal amount)
        {
            return amount * withdrawalComissionPercent / 100 + amount;
        }
    }
}
