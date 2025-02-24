using System;

namespace Bankingsystem
{
    // Account structure
    struct Account
    {
        // Field to store account holder details
        public string Accountholder;
        public string Accountnumber;
        public string Bankname;
        public decimal Balance; 

        // Method to deposit amount into the account
        public void Deposit(decimal amount)
        {
            Balance += amount;
            Console.WriteLine("Deposited: " + amount);
        }

        // Method to Withdraw amount from the account
        public void Withdraw(decimal amount)
        {
            // Check the withdraw amount is less than or equal to balance amount
            if (amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine("Withdraw: " + amount);
            }
            // If withdraw amount is greater than balance then print Insufficient Balance
            else
            {
                Console.WriteLine("Insufficient Balance");
            }
        }

        // Method to Inquriy or display the account details
        public void BalanceInquiry()
        {
            Console.WriteLine("Account Holder: " + Accountholder);
            Console.WriteLine("Account Number: " + Accountnumber);
            Console.WriteLine("Bank Name: " + Bankname);
            Console.WriteLine("Current Balance: " + Balance);
        }
    }

    // class for bankingsystem
    class Bankingsystem
    {
        // Main method
        static void Main(string[] args)
        {
            // Initialize account with default values
            Account myaccount = new Account();
            myaccount.Accountholder = "viswa";
            myaccount.Accountnumber = "1234554513156";
            myaccount.Bankname = "HDFC";
            myaccount.Balance = 10000;

            bool exit = true;

            while (exit)
            {
                // display menu for users
                Console.WriteLine("Banking System");
                Console.WriteLine("1. Deposit");
                Console.WriteLine("2. Withdraw");
                Console.WriteLine("3. Balance Inquiry");
                Console.WriteLine("4. Exit");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                // handle the operation based on user choice
                switch (choice)
                {
                    case "1":
                        Console.Write("Enter amount to deposit: ");
                        decimal depositamount = Convert.ToDecimal(Console.ReadLine());
                        myaccount.Deposit(depositamount);
                        break;
                    case "2":
                        Console.Write("Enter amount to withdraw: ");
                        decimal withdrawamount = Convert.ToDecimal(Console.ReadLine());
                        myaccount.Withdraw(withdrawamount);
                        break;
                    case "3":
                        myaccount.BalanceInquiry();
                        break;
                    case "4":
                        exit = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option Please try again");
                        break;
                }
            }
        }
    }
}