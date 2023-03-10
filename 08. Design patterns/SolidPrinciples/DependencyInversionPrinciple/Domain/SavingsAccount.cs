namespace DependencyInversionPrinciple.Domain
{
    internal class SavingsAccount : Account
    {
        public SavingsAccount(string iban) : base(iban)
        {
        }
    }
}
