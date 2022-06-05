
namespace Bank
{
    public class Account : AccountService
    {
        public int Balance { get; set; }
        public TransactionRepository Transactions { get; set; }
        public Account(int initialBalance, IDateTimeWrapper dateTimeWrapper)
        {
            Balance = initialBalance;
            Transactions = new TransactionRepository(dateTimeWrapper);
        }

        public void Deposit(int amount)
        {
            Balance += amount;
            Transactions.AddItem(amount, Balance);
        }

        public void Withdraw(int amount)
        {
            Balance -= amount;
            Transactions.AddItem(-amount, Balance);

        }

        public void printStatement()
        {
            Console.WriteLine(string.Join(Environment.NewLine, Transactions.statement));
        }
    }
}
