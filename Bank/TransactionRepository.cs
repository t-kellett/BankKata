namespace Bank
{
    public class TransactionRepository
    {
        private const string HEADER = "Date || Amount || Balance";
        private readonly IDateTimeWrapper _dateTimeWrapper;
        public IList<string> items;
        public TransactionRepository( IDateTimeWrapper dateTimeWrapper)
        {
            items = new List<string> { HEADER };
            _dateTimeWrapper = dateTimeWrapper;
        }
        public void AddItem(int amount, int balance)
        {
            items.Insert(1, $"{_dateTimeWrapper.Now.ToShortDateString()} || {amount} || {balance}");
        }
    }
}