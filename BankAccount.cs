using System;

namespace Bankingsystem
{

    // Abstract class 
    public abstract class BankAccount
    {
        // Account details with getter and setter
        public string AccountNumber 
        { 
            get; 
        }
        public string AccountHolder 
        { 
            get; 
        }
        public decimal Balance 
        { 
            get; 
            protected set;
        }

        // Constructor to initialize the bank account with respective field
        public BankAccount(string accountNumber, string accountHolder, decimal initialBalance = 0)
        {
            AccountNumber = accountNumber;
            AccountHolder = accountHolder;
            Balance = initialBalance;
        }

        // Virtual method for deposit money to account
        public virtual void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine($"Deposited {amount}, New balance is {Balance}");
        }


        // Virtual method for withdraw money from account
        public virtual void Withdraw(decimal amount)
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
                Console.WriteLine($"Withdraw {amount}, New balance is {Balance}");
            }
        }

        // Method to display account balance, account holder, account number
        public void BalanceInquiry()
        {
            Console.WriteLine($"Account holder: {AccountHolder}");
            Console.WriteLine($"Account number: {AccountNumber}");
            Console.WriteLine($"Account balance: {Balance}");
        }
    }
}