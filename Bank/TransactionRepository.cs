namespace Bank
{
    public class TransactionRepository
    {
        private const string HEADER = "Date || Amount || Balance";
        private readonly IDateTimeWrapper _dateTimeWrapper;
        public IList<string> statement;
        public TransactionRepository( IDateTimeWrapper dateTimeWrapper)
        {
            statement = new List<string> { HEADER };
            _dateTimeWrapper = dateTimeWrapper;
        }
        public void AddItem(int amount, int balance)
        {
            statement.Insert(1, $"{_dateTimeWrapper.Now.ToShortDateString()} || {amount} || {balance}");
        }
    }
}