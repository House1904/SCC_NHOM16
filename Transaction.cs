public class Transaction
    {
        public string Category { get; }
        public decimal Amount { get; }
        public DateTime Date { get; }

        public Transaction(string category, decimal amount, DateTime date)
        {
            Category = category;
            Amount = amount;
            Date = date;
        }

        public override string ToString()
        {
            return $"{Date.ToShortDateString()} - {Category}: {Amount:C}";
        }
    }
}