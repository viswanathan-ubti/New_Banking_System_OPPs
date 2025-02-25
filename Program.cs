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
                        string savingsAccountNumber = Console.ReadLine();
                        Console.Write("Enter account holder name: ");
                        string savingsAccountHolder = Console.ReadLine();
                        Console.Write("Enter initial balance: ");
                        decimal savingsInitialBalance = decimal.Parse(Console.ReadLine());
                        bank.CreateSavingsAccount(savingsAccountNumber, savingsAccountHolder, savingsInitialBalance);
                        break;
                    case 2:

                        // Create Current Account
                        Console.Write("Enter account number: ");
                        string currentAccountNumber = Console.ReadLine();
                        Console.Write("Enter account holder name: ");
                        string currentAccountHolder = Console.ReadLine();
                        Console.Write("Enter initial balance: ");
                        decimal currentInitialBalance = decimal.Parse(Console.ReadLine());
                        bank.CreatecurrentAccount(currentAccountNumber, currentAccountHolder, currentInitialBalance);
                        break;
                    case 3:

                        // Deposit money to account
                        Console.Write("Enter account number: ");
                        string depositAccountNumber = Console.ReadLine();
                        BankAccount depositAccount = bank.GetAccount(depositAccountNumber);
                        if (depositAccount != null)
                        {
                            Console.Write("Enter amount to deposit: ");
                            decimal depositAmount = decimal.Parse(Console.ReadLine());
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
                        string withdrawAccountNumber = Console.ReadLine();
                        BankAccount withdrawAccount = bank.GetAccount(withdrawAccountNumber);
                        if (withdrawAccount != null)
                        {
                            Console.Write("Enter amount to withdraw: ");
                            decimal withdrawAmount = decimal.Parse(Console.ReadLine());
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
                        string inquiryAccountNumber = Console.ReadLine();
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
        }
    }
}