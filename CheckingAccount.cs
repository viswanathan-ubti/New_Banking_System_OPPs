using System;

namespace Bankingsystem
{
    // currentAccount class inherit the BankAccount class
    public class currentAccount : BankAccount
    {
        // Constructor for CurrentAccount that call the base class constructor
        public currentAccount(string accountNumber, string accountHolder, decimal initialBalance)
            : base(accountNumber, accountHolder, initialBalance)
        {
        }

        // Override the Withdraw method to include specific behavior
        public override void Withdraw(decimal amount)
        {
            // Check withdraw amount is greater than balance
            if (amount > Balance)
            {
                Console.WriteLine("Insufficient fund");
            }

            // Reduce amount from the balance
            else
            {
                Balance -= amount;
                Console.WriteLine($"Withdraw {amount}. New balance is {Balance}");
            }
        }
    }
}