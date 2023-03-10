
using LiskovSubstitutionPrinciple.Domain;
using LiskovSubstitutionPrinciple.Domain.Services;

var bankingService = new BankingService();
var debitAccount = new DebitAccount("RO19PORL1528178466271384", 0.1m, bankingService);
debitAccount.Deposit(100m);
debitAccount.Withdraw(10);

var creditAccount = new CreditAccount("RO52PORL2253286597578374", 0.5m, bankingService);
creditAccount.Deposit(100m);
creditAccount.Withdraw(10);

var savingsAccount = new SavingsAccount("RO02RZBR8879674797566559");
savingsAccount.Deposit(100m);

bankingService.PrintBalanceReport(new Account[] { debitAccount, creditAccount, savingsAccount });

try
{
    bankingService.Transfer(savingsAccount, creditAccount, 20);
}
catch (NotSupportedException ex)
{
    Console.WriteLine(ex.Message);
}