using System;

namespace Bankingsystem
{
    // SavingsAccount class inherit from BankAccount class
    public class SavingsAccount : BankAccount
    {
        // Constructor for SavingsAccount that call the base class constructor
        public SavingsAccount(string accountNumber, string accountHolder, decimal initialBalance)
            : base(accountNumber, accountHolder, initialBalance)
        {
        }
    }
}