// See https://aka.ms/new-console-template for more information
using SingleResponsibilityPrinciple.Domain;

var account = new Account("RO19PORL1528178466271384", 0.1m);
account.Deposit(100m);
Console.WriteLine(account.Balance);
account.Withdraw(10);
Console.WriteLine(account.Balance);
try
{
	account.Withdraw(90);
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}

