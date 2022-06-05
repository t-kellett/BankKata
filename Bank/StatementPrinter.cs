namespace Bank
{
    public class StatementPrinter
    {
        public static void Print(TransactionRepository transactions)
        {
            Console.WriteLine(string.Join(Environment.NewLine, transactions.items));
        }
    }
}