# Time Complexity
### Total Time Complexity: O(n)


### Program.cs File
```csharp
using System;

namespace Bankingsystem
{
    public class Program
    {
        // Main Method
        public static void Main()
        {
            // Instance for Bank class 
            Bank bank = new Bank();

            while (true) // Time Complexity: O(n)
            {
                // Try block
                try
                {
                    // Display the menu for user
                    Console.WriteLine("\n1. Create Savings Account\n2. Create current Account\n3. Deposit\n4. Withdraw\n5. Balance Inquiry\n6. Exit");
                    Console.Write("Enter your choice: ");
                    int choice = int.Parse(Console.ReadLine()); // Time Complexity: O(1)

                    // Switch statement to handle the user choice
                    switch (choice) // Time Complexity: O(1)
                    {
                        case 1:

                            // Create Savings Account
                            Console.Write("Enter account number: ");
                            string savingsAccountNumber = Console.ReadLine(); // Time Complexity: O(1)
                            Console.Write("Enter account holder name: ");
                            string savingsAccountHolder = Console.ReadLine(); // Time Complexity: O(1)
                            Console.Write("Enter initial balance: ");
                            decimal savingsInitialBalance = decimal.Parse(Console.ReadLine()); // Time Complexity: O(1)
                            bank.CreateSavingsAccount(savingsAccountNumber, savingsAccountHolder, savingsInitialBalance); // Time Complexity: O(1)
                            break;
                        case 2:

                            // Create Current Account
                            Console.Write("Enter account number: ");
                            string currentAccountNumber = Console.ReadLine(); // Time Complexity: O(1)
                            Console.Write("Enter account holder name: ");
                            string currentAccountHolder = Console.ReadLine(); // Time Complexity: O(1)
                            Console.Write("Enter initial balance: ");
                            decimal currentInitialBalance = decimal.Parse(Console.ReadLine()); // Time Complexity: O(1)
                            bank.CreatecurrentAccount(currentAccountNumber, currentAccountHolder, currentInitialBalance); // Time Complexity: O(1)
                            break;
                        case 3:

                            // Deposit money to account
                            Console.Write("Enter account number: ");
                            string depositAccountNumber = Console.ReadLine(); // Time Complexity: O(1)
                            BankAccount depositAccount = bank.GetAccount(depositAccountNumber); // Time Complexity: O(1)
                            if (depositAccount != null)
                            {
                                Console.Write("Enter amount to deposit: ");
                                decimal depositAmount = decimal.Parse(Console.ReadLine()); // Time Complexity: O(1)
                                depositAccount.Deposit(depositAmount); // Time Complexity: O(1)
                            }
                            else
                            {
                                Console.WriteLine("Account not found.");
                            }
                            break;
                        case 4:

                            // Withdraw money from account
                            Console.Write("Enter account number: ");
                            string withdrawAccountNumber = Console.ReadLine(); // Time Complexity: O(1)
                            BankAccount withdrawAccount = bank.GetAccount(withdrawAccountNumber); // Time Complexity: O(1)
                            if (withdrawAccount != null)
                            {
                                Console.Write("Enter amount to withdraw: ");
                                decimal withdrawAmount = decimal.Parse(Console.ReadLine()); // Time Complexity: O(1)
                                withdrawAccount.Withdraw(withdrawAmount); // Time Complexity: O(1)
                            }
                            else
                            {
                                Console.WriteLine("Account not found");
                            }
                            break;
                        case 5:

                            // Check the balance of the account
                            Console.Write("Enter account number: ");
                            string inquiryAccountNumber = Console.ReadLine(); // Time Complexity: O(1)
                            BankAccount inquiryAccount = bank.GetAccount(inquiryAccountNumber); // Time Complexity: O(1)
                            if (inquiryAccount != null)
                            {
                                inquiryAccount.BalanceInquiry(); // Time Complexity: O(1)
                            }
                            else
                            {
                                Console.WriteLine("Account not found"); 
                            }
                            break;
                        case 6:

                            // To exit program
                            return;
                        default:

                            // Handle invalid choice
                            Console.WriteLine("Invalid choice Please try again");
                            break;
                    }
                }
                // Catch block
                catch (FormatException)
                {
                    Console.WriteLine("Invalid choice Please enter valid choice");
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error occured: " + e.Message);
                }

                // Finally block
                finally
                {
                    Console.WriteLine("Operation successfully completed...");
                }
            }
        }
    }
}
```csharp

### Bank.cs
```csharp 
using System;
using System.Collections.Generic;

namespace Bankingsystem
{
    //  Bank class for multiple bank account
    public class Bank
    {
        // Dictionary to store bank account details
        private Dictionary<string, BankAccount> accounts = new Dictionary<string, BankAccount>(); // Time Complexity: O(1)

        // Method to create savings account
        public void CreateSavingsAccount(string accountNumber, string accountHolder, decimal initialBalance) // Time Complexity: O(1)
        {
            // Try block
            try
            {
                // Check if the account already exist
                if (accounts.ContainsKey(accountNumber)) // Time Complexity: O(1)
                {
                    Console.WriteLine("Account already exist");
                }

                // Create a new savings account and add it to the dictionary
                else
                {
                    accounts[accountNumber] = new SavingsAccount(accountNumber, accountHolder, initialBalance); // Time Complexity: O(1)
                    Console.WriteLine($"Savings account created for {accountHolder}");
                }
            }
            // Catch block
            catch (Exception e)
            {
                Console.WriteLine("Error occured in creating savings account: " + e.Message);
            }
            // Finally block
            finally
            {
                Console.WriteLine("Successfully savings account created...");
            }
            
        }

        // Method to create current account
        public void CreatecurrentAccount(string accountNumber, string accountHolder, decimal initialBalance) // Time Complexity: O(1)
        {
            // Try block
            try
            {
                // Check if the account already exist
                if (accounts.ContainsKey(accountNumber)) // Time Complexity: O(1)
                {
                    Console.WriteLine("Account already exist");
                }

                // Create a new current account and add it to the dictionary
                else
                {
                    accounts[accountNumber] = new currentAccount(accountNumber, accountHolder, initialBalance); // Time Complexity: O(1)
                    Console.WriteLine($"current account created for {accountHolder}");
                }    
            }
             // Catch block
            catch (Exception e)
            {
                Console.WriteLine("Error occured in creating current account: " + e.Message);
            }
            // Finally block
            finally
            {
                Console.WriteLine("Successfully current account created...");
            }
        }


        // Method to retrieve account
        public BankAccount GetAccount(string accountNumber) // Time Complexity: O(1)
        {
            if (accounts.TryGetValue(accountNumber, out BankAccount account)) // Time Complexity: O(1)
                return account;
            return null;
        }
    }
}
```csharp

### BankAccount.cs
```csharp
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
        public BankAccount(string accountNumber, string accountHolder, decimal initialBalance = 0) // Time Complexity: O(1)
        {
            AccountNumber = accountNumber;
            AccountHolder = accountHolder;
            Balance = initialBalance;
        }

        // Virtual method for deposit money to account
        public virtual void Deposit(decimal amount) // Time Complexity: O(1)
        {
            // Try block
            try
            {
                Balance += amount; // Time Complexity: O(1)
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
        public virtual void Withdraw(decimal amount) // Time Complexity: O(1)
        {
            // Try block
            try
            {
                // Check withdraw amount is greater than balance
                if (amount > Balance) // Time Complexity: O(1)
                {
                    Console.WriteLine("Insufficient fund");
                }
                // Reduce amount from the balance
                else
                {
                    Balance -= amount; // Time Complexity: O(1)
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
        public void BalanceInquiry() // Time Complexity: O(1)
        {
            Console.WriteLine($"Account holder: {AccountHolder}");
            Console.WriteLine($"Account number: {AccountNumber}");
            Console.WriteLine($"Account balance: {Balance}");
        }
    }
}
```csharp

### SavingsAccount.cs
```csharp
using System;

namespace Bankingsystem
{
    // SavingsAccount class inherit from BankAccount class
    public class SavingsAccount : BankAccount
    {
        // Constructor for SavingsAccount that call the base class constructor
        public SavingsAccount(string accountNumber, string accountHolder, decimal initialBalance) // Time Complexity: O(1)
            : base(accountNumber, accountHolder, initialBalance) 
        {
        }
    }
}
```csharp

### CheckingAccount.js
```csharp
using System;

namespace Bankingsystem
{
    // currentAccount class inherit the BankAccount class
    public class currentAccount : BankAccount
    {
        // Constructor for CurrentAccount that call the base class constructor
        public currentAccount(string accountNumber, string accountHolder, decimal initialBalance) // Time Complexity: O(1)
            : base(accountNumber, accountHolder, initialBalance)
        {
        }

        // Override the Withdraw method to include specific behavior
        public override void Withdraw(decimal amount) // Time Complexity: O(1)
        {
            // Try block
            try
            {
                // Check withdraw amount is greater than balance
                if (amount > Balance)  // Time Complexity: O(1)
                {
                    Console.WriteLine("Insufficient fund");
                }

                // Reduce amount from the balance
                else
                {
                    Balance -= amount; // Time Complexity: O(1)
                    Console.WriteLine($"Withdraw {amount}. New balance is {Balance}");
                }
            }

            // Catch block
            catch (Exception e)
            {
                Console.WriteLine("Error occured in Withdraw method: " + e.Message);
            }

            // Finally block
            finally
            {
                Console.WriteLine("Withdraw operation completed...");
            }
        }
    }
}