using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankAccounts
{
    class Account
    {
        private string _id;
        private string _name;
        private decimal _balance;

        public Account(string id, string name, decimal balance)
        {
            _id = id;
            _name = name;
            _balance = balance;
        }

        public string Id
        {
            get { return _id; }
        }
        public string Name { get { return _name; } }
        public decimal Balance { get { return _balance; } }
         
        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                _balance += amount;
                Console.WriteLine($"Deposited {amount:C}. New balance is {Balance:C}");
            }
            else
            {
                Console.WriteLine("Deposit amount must be greater than zero.");
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be greater than zero.");
                return;
            }

            if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds for withdrawal.");
            }
            else
            {
                _balance -= amount;
                Console.WriteLine($"Withdrawn {amount:C}. New balance is {Balance:C}");
            }
        }
    }
}
