 public class ExpenseManager
    {
        private List<Transaction> transactions;
        private Dictionary<string, decimal> budget;

        public ExpenseManager()
        {
            transactions = new List<Transaction>();
            budget = new Dictionary<string, decimal>();
        }

        public void AddTransaction()
        {
            Console.WriteLine("Nhập loại giao dịch (ăn uống, điện nước, wifi, đi chơi, ...): ");
            string category = Console.ReadLine();
            Console.WriteLine("Nhập số tiền: ");
            decimal amount;
            if (decimal.TryParse(Console.ReadLine(), out amount))
            {
                Console.WriteLine("Nhập ngày (dd/MM/yyyy): ");
                DateTime date;
                if (DateTime.TryParse(Console.ReadLine(), out date))
                {
                    transactions.Add(new Transaction(category, amount, date));
                    Console.WriteLine("Giao dịch đã được thêm thành công.");
                }
                else
                {
                    Console.WriteLine("Ngày không hợp lệ.");
                }
            }
            else
            {
                Console.WriteLine("Số tiền không hợp lệ.");
            }
        }

        public void DisplayExpenses()
        {
            Console.WriteLine("Chọn khoảng thời gian hiển thị: ");
            Console.WriteLine("1. Ngày");
            Console.WriteLine("2. Tuần");
            Console.WriteLine("3. Tháng");
            string choice = Console.ReadLine();

            IEnumerable<Transaction> filteredTransactions = null;
            DateTime now = DateTime.Now;

            switch (choice)
            {
                case "1":
                    filteredTransactions = transactions.Where(t => t.Date.Date == now.Date);
                    break;
                case "2":
                    var startOfWeek = now.AddDays(-(int)now.DayOfWeek);
                    filteredTransactions = transactions.Where(t => t.Date >= startOfWeek && t.Date <= now);
                    break;
                case "3":
                    filteredTransactions = transactions.Where(t => t.Date.Month == now.Month && t.Date.Year == now.Year);
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ.");
                    return;
            }

            foreach (var transaction in filteredTransactions)
            {
                Console.WriteLine(transaction);
            }
        }
        public void SetBudget()
        {
            Console.WriteLine("Nhập loại mục (ăn uống, điện nước, wifi, đi chơi, ...): ");
            string category = Console.ReadLine();
            Console.WriteLine("Nhập ngân sách hàng tháng: ");
            decimal amount;
            if (decimal.TryParse(Console.ReadLine(), out amount))
            {
                if (budget.ContainsKey(category))
                {
                    budget[category] = amount;
                }
                else
                {
                    budget.Add(category, amount);
                }
                Console.WriteLine("Ngân sách đã được đặt thành công.");
            }
            else
            {
                Console.WriteLine("Số tiền không hợp lệ.");
            }
        }