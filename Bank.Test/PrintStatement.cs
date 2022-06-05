using NUnit.Framework;
using System;
using Moq;
using System.IO;

namespace Bank.Test
{
    public class PrintStatement
    {
        private Account account;
        [Test]
        public void ShouldPrintStatement()
        {
            var mockDate = new Mock<IDateTimeWrapper>();
            var output = new StringWriter();
            Console.SetOut(output);
            mockDate.SetupSequence(x => x.Now)
                .Returns(new DateTime(2012, 01, 10))
                .Returns(new DateTime(2012, 01, 13))
                .Returns(new DateTime(2012, 01, 14));
            account = new Account(0, mockDate.Object);
            string expectedStatement =
                "Date || Amount || Balance\r\n14/01/2012 || -500 || 2500\r\n13/01/2012 || 2000 || 3000\r\n10/01/2012 || 1000 || 1000\r\n";

            account.Deposit(1000);
            account.Deposit(2000);
            account.Withdraw(500);

            account.printStatement();

            Assert.AreEqual(expectedStatement, output.ToString());
        }
    }
}