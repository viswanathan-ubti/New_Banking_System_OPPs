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
            // Try block
            try
            {
                Balance += amount;
                Console.WriteLine($"Deposited {amount}, New balance is {Balance}");
            }
            // Catch block
            catch (Exception e)
            {
                Console.WriteLine("Error occured in Depsoit method: " + e.Message);
            }
            // Finally block
            finally
            {
                Console.WriteLine("Deposit operation completed...");
            }
        }


        // Virtual method for withdraw money from account
        public virtual void Withdraw(decimal amount)
        {
            // Try block
            try
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
            // Catch block
            catch (Exception e)
            {
                Console.WriteLine("Error occured in withdraw method: " + e.Message);
            }
            // Finally block
            finally
            {
                Console.WriteLine("Withdraw operation completed...");
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