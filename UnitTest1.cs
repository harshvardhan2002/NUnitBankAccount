using BankAccountNUnit.Exceptions;
using BankAccountNUnit.Models;

namespace BankAccountNUnit
{
    public class Tests
    {
        Account _account;
        [SetUp]
        public void Setup()
        {
            _account = new Account(101,"Harsh", "Axis", 10000);
        }
        [TestCase(10000)]
        public void AsksForBalance_ReturnsCurrentBalance(double currentBalance)
        {
            Assert.AreEqual(currentBalance,_account.GetBalance());
        }
        [TestCase(5000,15000)]
        [TestCase(10000,20000)]
        public void Deposit_ValidAmount_ReturnsIncreasingValue(double depositAmount, double expectedBalance)
        {
            _account.Deposit(depositAmount);
            Assert.AreEqual(_account.GetBalance(), expectedBalance);
        }

        [TestCase(-1000)]
        public void Deposit_InvalidAmount_ThrowsException(double amount)
        {
            Assert.Throws<AmountToBePositiveException>(() => _account.Deposit(amount));
        }
        [TestCase(3000, 7000)]
        public void Withdraw_ValidAmount_DecreasingValue(double withdrawAmount, double expectedBalance)
        {
            _account.Withdraw(withdrawAmount);
            Assert.AreEqual(expectedBalance, _account.GetBalance());
        }
        [TestCase(12000)]
        public void Withdraw_AmountIsGreaterThanBalance_ThrowsException(double amount)
        {
            Assert.Throws<InsufficientBalanceException>(() => _account.Withdraw(amount));
        }
        [TestCase(-100)]
        public void Withdraw_InvalidAmount_ThrowsException(double amount)
        {
            Assert.Throws<AmountToBePositiveException>(() => _account.Withdraw(amount));
        }
        [TestCase(2000, 8000, 4500)]
        public void Tranfer_FromMyAccount_ToOtherAccount(double amount, double expectedMyBalance, double expectedOtherAccountBalance)
        {
            Account otherAccount = new Account(102, "hv", "SBI", 2500);
            _account.Transfer(otherAccount,amount);
            Assert.AreEqual(otherAccount.GetBalance(),expectedOtherAccountBalance);
            Assert.AreEqual(expectedMyBalance,_account.GetBalance());
        }
        [TestCase(1000)]
        public void Transfer_ToInvalidAccount(int amount)
        {
            Account receiverAccount = new Account(0, "hvv", "SBI", 3500);

            Assert.Throws<NoAccountFoundException>(() => _account.Transfer(receiverAccount, amount));
        }
    }
}