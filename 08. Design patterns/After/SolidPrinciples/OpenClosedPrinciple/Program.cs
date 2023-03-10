

using OpenClosedPrinciple.Domain;
using OpenClosedPrinciple.Domain.Services;

var bankingService = new BankingService();
var debitAccount = new Account(AccountType.Debit, "RO19PORL1528178466271384", bankingService);
debitAccount.Deposit(100m);
Console.WriteLine(debitAccount.Balance);
debitAccount.Withdraw(10);
Console.WriteLine(debitAccount.Balance);

var creditAccount = new Account(AccountType.Credit, "RO52PORL2253286597578374", bankingService);
creditAccount.Deposit(100m);
Console.WriteLine(creditAccount.Balance);
creditAccount.Withdraw(10);
Console.WriteLine(creditAccount.Balance);