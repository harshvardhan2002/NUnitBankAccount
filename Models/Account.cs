using BankAccountNUnit.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountNUnit.Models
{
    internal class Account
    {
        public int AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string BankName { get; set; }
        public double OpeningBalance { get; set; }
        const double MIN_BALANCE = 500;

        public Account(int accountNumber, string accountName, string bankName, double openingBalance)
        {
            AccountNumber = accountNumber;
            AccountName = accountName;
            BankName = bankName;
            OpeningBalance = openingBalance < MIN_BALANCE ? MIN_BALANCE : openingBalance;
        }

        public string Deposit(double amount)
        {
            if (amount <= 0)
                throw new AmountToBePositiveException("Deposit amount must be positive.");

            OpeningBalance += amount;
            return "Amount deposited successfully.";
        }

        public string Withdraw(double amount)
        {
            if (amount <= 0)
                throw new AmountToBePositiveException("withdrawal amount must be positive.");
            else if (OpeningBalance - amount < MIN_BALANCE)
                throw new InsufficientBalanceException("Insufficient balance, withdrawal is denied!");

            OpeningBalance -= amount;
            return "Amount withdrawal successful";
        }

        public double GetBalance()
        {
            return OpeningBalance;
        }


        public string Transfer(Account toAccount, double amount)
        {
            if (toAccount == null || toAccount.AccountNumber <= 0)
                throw new NoAccountFoundException("The account in which money is to be transferred cannot be found");

            Withdraw(amount);
            toAccount.Deposit(amount);

            return "Transfer done successfully";
        }

        public override string ToString()
        {
            return $"Account Number: {AccountNumber}\n" +
                $"Account Name: {AccountName}\n" +
                $"Bank: {BankName}\n" +
                $"Balance: {OpeningBalance}";
        }
    }
}
