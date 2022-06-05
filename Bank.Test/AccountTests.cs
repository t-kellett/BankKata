using NUnit.Framework;
using System;
using Moq;
using System.IO;

namespace Bank.Test
{
    public class AccountTests
    {
        private Account account;
        [SetUp]
        public void Setup()
        {
            var mockDate = new Mock<IDateTimeWrapper>();
            mockDate.Setup(x => x.Now).Returns(new DateTime(2022, 06, 05));
            account = new Account(1000, mockDate.Object);
        }

        [Test]
        public void ToDepositAmount()
        {
            account.Deposit(500);
            Assert.AreEqual(1500, account.Balance);
        }

        [Test]
        public void ToWithdrawAmount()
        {
            account.Withdraw(500);
            Assert.AreEqual(500, account.Balance);
        }

        [Test]
        public void ShouldStoreDepositTransaction()
        {
            account.Deposit(500);
            string lastTransaction = "05/06/2022 || 500 || 1500";
            Assert.AreEqual(lastTransaction, account.Transactions.statement[1]);
        }

        [Test]
        public void ShouldStoreWithdrawalTransaction()
        {
            account.Withdraw(500);
            string lastTransaction = "05/06/2022 || -500 || 500";
            Assert.AreEqual(lastTransaction, account.Transactions.statement[1]);
        }
    }
}

