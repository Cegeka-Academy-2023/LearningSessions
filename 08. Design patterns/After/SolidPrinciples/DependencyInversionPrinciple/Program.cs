
using DependencyInversionPrinciple.Domain;
using DependencyInversionPrinciple.Domain.Services;

var amountCalculator = new WithdrawalAmountCalculator();
var debitAccount = new DebitAccount("RO19PORL1528178466271384", 0.1m, amountCalculator);
debitAccount.Deposit(100m);
debitAccount.Withdraw(10);

var creditAccount = new CreditAccount("RO52PORL2253286597578374", 0.5m, amountCalculator);
creditAccount.Deposit(100m);
creditAccount.Withdraw(10);

var savingsAccount = new SavingsAccount("RO02RZBR8879674797566559");
savingsAccount.Deposit(100m);
var reportingService = new ReportingService();
reportingService.PrintBalanceReport(new Account[] { debitAccount, creditAccount, savingsAccount });

var bankingService = new BankingService();
bankingService.Transfer(debitAccount, creditAccount, 20);