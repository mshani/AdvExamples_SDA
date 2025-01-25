//BankAccount
//prop AccountHolder
//prop Balance
//Withdraw(int amount)
//Deposit(int amount)

using AdvExceptions;

Console.WriteLine("Enter 1 to withdraw");
Console.WriteLine("Enter 2 to deposit");
string s = Console.ReadLine();
BankAccount account = new BankAccount()
{
    AccountHolder = "Filan Fisteku"
};
try
{
    int value = Int32.Parse(s);
    if (value != 1 && value != 2)
    {
        throw new Exception("Invalid menu option");
    }
    account.GetBankAccountInfo();
    Console.WriteLine("Enter amount");
    string s2 = Console.ReadLine();
    int amount = Int32.Parse(s2);
    if (value == 1)
    {
        account.Withdraw(amount);
    }
    else if (value == 2) {
        account.Deposit(amount);
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    account.GetBankAccountInfo();
}