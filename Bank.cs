using System;
using System.Collections.Generic;

namespace Bankingsystem
{
    //  Bank class for multiple bank account
    public class Bank
    {
        // Dictionary to store bank account details
        private Dictionary<string, BankAccount> accounts = new Dictionary<string, BankAccount>();

        // Method to create savings account
        public void CreateSavingsAccount(string accountNumber, string accountHolder, decimal initialBalance)
        {
            // Check if the account already exist
            if (accounts.ContainsKey(accountNumber))
            {
                Console.WriteLine("Account already exist");
            }

            // Create a new savings account and add it to the dictionary
            else
            {
                accounts[accountNumber] = new SavingsAccount(accountNumber, accountHolder, initialBalance);
                Console.WriteLine($"Savings account created for {accountHolder}");
            }
        }

        // Method to create current account
        public void CreatecurrentAccount(string accountNumber, string accountHolder, decimal initialBalance)
        {
            // Check if the account already exist
            if (accounts.ContainsKey(accountNumber))
            {
                Console.WriteLine("Account already exist");
            }

            // Create a new current account and add it to the dictionary
            else
            {
                accounts[accountNumber] = new currentAccount(accountNumber, accountHolder, initialBalance);
                Console.WriteLine($"current account created for {accountHolder}");
            }
        }


        // Method to retrieve account
        public BankAccount GetAccount(string accountNumber)
        {
            if (accounts.TryGetValue(accountNumber, out BankAccount account))
                return account;
            return null;
        }
    }
}