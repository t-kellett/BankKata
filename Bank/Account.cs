
namespace Bank
{
    public class Account : AccountService
    {
        public int balance { get; set; }
        public TransactionRepository transactions { get; set; }
        public Account(int initialBalance, IDateTimeWrapper dateTimeWrapper)
        {
            balance = initialBalance;
            transactions = new TransactionRepository(dateTimeWrapper);
        }

        public void Deposit(int amount)
        {
            balance += amount;
            transactions.AddItem(amount, balance);
        }

        public void Withdraw(int amount)
        {
            balance -= amount;
            transactions.AddItem(-amount, balance);

        }

        public void printStatement()
        {
            StatementPrinter.Print(transactions);
        }
    }
}
