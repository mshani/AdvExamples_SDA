using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AdvExceptions
{
    internal class BankAccount
    {
        public string AccountHolder { get; set; }
        public decimal Balance { get; private set; } = 100;
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Invalid amount");
            }
            if (Balance - amount < 0)
            {
                throw new Exception("Not enough funds");
            }
            Balance = Balance - amount;
        }
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new Exception("Invalid amount");
            }
            Balance = Balance + amount;
        }
        public void GetBankAccountInfo()
        {
            Console.WriteLine($"{AccountHolder}: {Balance}");
        }
    }
}
