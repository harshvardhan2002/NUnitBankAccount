# NUnitBankAccount

This project involves unit testing for a simple Account class using NUnit. The Account class represents a bank account with various methods for handling deposits, withdrawals, balance inquiries, and transfers. The tests ensure the reliability and correctness of these methods.
Custom exceptions like AmountToBePositiveException, InsufficientBalanceException, and NoAccountFoundException are created for specific error handling.

## Account Class Methods
Deposit: Adds money to the account. Throws an exception if the amount is not positive.
Withdraw: Subtracts money from the account. Throws exceptions if the amount is not positive or if it leaves the balance below a minimum limit.
GetBalance: Returns the current balance.
Transfer: Transfers money to another account. Throws an exception if the recipient account is invalid or if the amount conditions are not met.

## Test Cases
Balance Inquiry Test: Ensures GetBalance returns the correct balance.

Deposit Tests:
1. Valid deposit increases the balance.
2. Invalid deposit throws AmountToBePositiveException.
   
Withdrawal Tests:
1. Valid withdrawal decreases the balance.
2. Withdrawal exceeding balance or below zero throws InsufficientBalanceException or AmountToBePositiveException.
   
Transfer Tests:
1. Transfers reduce the balance in the sender and increase it in the receiver.
2. Invalid recipient account throws NoAccountFoundException.

## How to Run Tests
Run tests using the built-in test runner
