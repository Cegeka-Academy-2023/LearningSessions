using System.Text;

namespace DependencyInversionPrinciple.Domain.Services
{
    internal class ReportingService
    {
        public void PrintBalanceReport(IEnumerable<Account> accounts)
        {
            var sb = new StringBuilder();
            sb.AppendLine("==========================================");
            foreach (var account in accounts)
            {
                sb.AppendLine(string.Format("{0}    {1}", account.Iban, account.Balance));
            }
            sb.AppendLine("==========================================");
            Console.WriteLine(sb.ToString());
        }
    }
}
