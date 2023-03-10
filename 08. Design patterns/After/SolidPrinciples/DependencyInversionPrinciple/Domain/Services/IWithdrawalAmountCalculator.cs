namespace DependencyInversionPrinciple.Domain.Services
{
    internal interface IWithdrawalAmountCalculator
    {
        decimal CalculateWithdrawalAmount(decimal withdrawalComissionPercent, decimal amount);
    }
}