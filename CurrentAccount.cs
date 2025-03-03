using System;
using System.Security.Cryptography.X509Certificates;

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
        private decimal OverdraftLimit = 200;

        // Override the Withdraw method to include specific behavior
        public override void Withdraw(decimal amount)
        {
            try
            {
                // Validate the withdraw amount is positive
                if (amount <= 0)
                {
                    Console.WriteLine("Withdraw amount must be positive");
                    return;
                }

                // Check if the withdraw amount exceed the balance + overdraft limit
                if (amount > Balance + OverdraftLimit)
                {
                    Console.WriteLine("Insufficient fund including overdraft limit");
                }
                else
                {
                    // Reduce the amount from the balance
                    Balance -= amount;
                    Console.WriteLine($"Withdraw {amount}, New balance is {Balance}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occurred during withdraw: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Withdraw operation completed...");
            }
        }
    }
}