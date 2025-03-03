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

            while (true)
            {
                // Try block
                try
                {
                    // Display the menu for user
                    Console.WriteLine("\n1. Create Savings Account\n2. Create current Account\n3. Deposit\n4. Withdraw\n5. Balance Inquiry\n6. Exit");
                    Console.Write("Enter your choice: ");
                    int choice = int.Parse(Console.ReadLine());

                    // Switch statement to handle the user choice
                    switch (choice)
                    {
                        case 1:

                            // Create Savings Account
                            Console.Write("Enter account number: ");
                            string savingsAccountNumber = GetValidAccountNumber();
                            Console.Write("Enter account holder name: ");
                            string savingsAccountHolder = GetValidAccountHolderName();
                            String Message = "Enter initial balance: ";
                            decimal savingsInitialBalance = GetDecimalInput(Message);
                            bank.CreateSavingsAccount(savingsAccountNumber, savingsAccountHolder, savingsInitialBalance);
                            break;
                        case 2:

                            // Create Current Account
                            Console.Write("Enter account number: ");
                            string currentAccountNumber = GetValidAccountNumber();
                            Console.Write("Enter account holder name: ");
                            string currentAccountHolder = GetValidAccountHolderName();
                            Message = "Enter initial balance: ";
                            decimal currentInitialBalance = GetDecimalInput(Message);
                            bank.CreatecurrentAccount(currentAccountNumber, currentAccountHolder, currentInitialBalance);
                            break;
                        case 3:

                            // Deposit money to account
                            Console.Write("Enter account number: ");
                            string depositAccountNumber = GetValidAccountNumber();
                            BankAccount depositAccount = bank.GetAccount(depositAccountNumber);
                            if (depositAccount != null)
                            {
                                Message = "Enter amount to deposit: ";
                                decimal depositAmount = GetDecimalInput(Message);
                                depositAccount.Deposit(depositAmount);
                            }
                            else
                            {
                                Console.WriteLine("Account not found.");
                            }
                            break;
                        case 4:

                            // Withdraw money from account
                            Console.Write("Enter account number: ");
                            string withdrawAccountNumber = GetValidAccountNumber();
                            BankAccount withdrawAccount = bank.GetAccount(withdrawAccountNumber);
                            if (withdrawAccount != null)
                            {
                                Message = "Enter amount to withdraw: ";
                                decimal withdrawAmount = GetDecimalInput(Message);
                                withdrawAccount.Withdraw(withdrawAmount);
                            }
                            else
                            {
                                Console.WriteLine("Account not found");
                            }
                            break;
                        case 5:

                            // Check the balance of the account
                            Console.Write("Enter account number: ");
                            string inquiryAccountNumber = GetValidAccountNumber();
                            BankAccount inquiryAccount = bank.GetAccount(inquiryAccountNumber);
                            if (inquiryAccount != null)
                            {
                                inquiryAccount.BalanceInquiry();
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

        // Method to validate account holder name
        static string GetValidAccountHolderName()
        {
            string name;
            while (true)
            {
                name = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(name) && IsAlphabetic(name))
                {
                    return name; // Return valid account holder name
                }
                Console.WriteLine("Invalid name Please enter a name that contains only alphabetic characters");
                Console.Write("Enter account holder name: ");
            }
        }

        // Method to validate account number
        static string GetValidAccountNumber()
        {
            string accountNumber;
            while (true)
            {
                accountNumber = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(accountNumber) && IsNumeric(accountNumber))
                {
                    return accountNumber; // Return valid account number
                }
                Console.WriteLine("Invalid account number Please enter a number that contains only numeric characters");
                Console.Write("Enter account number: ");
            }
        }

        // Method to check the account holder name contains only alphabetic characters
        static bool IsAlphabetic(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsLetter(c))
                {
                    return false;
                }
            }
            return true;
        }

        // Method to check the account number contains only numeric characters
        static bool IsNumeric(string input)
        {
            foreach (char c in input)
            {
                if (!char.IsDigit(c))
                {
                    return false;
                }
            }
            return true;
        }

        // Method to prompt user for amount input with validation
        static decimal GetDecimalInput(String Message)
        {
            Console.Write(Message);
            decimal amount;
            while (!decimal.TryParse(Console.ReadLine(), out amount))
            {
                Console.Write("Invalid amount entered Please enter valid amount: ");
            }
            return amount;
        }
    }
}