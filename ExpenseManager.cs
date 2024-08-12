namespace MonthlyExpenseManager
{
// 2. Lớp ExpenseManager: Xử lý logic chính của ứng dụng
public class ExpenseManager
{
    private List<Transaction> transactions;  
    private Dictionary<string, decimal> budget; 

    public ExpenseManager()
    {
        transactions = new List<Transaction>();
        budget = new Dictionary<string, decimal>();
    }

    // 2.1. Thêm giao dịch
    public void AddTransaction()
    {
        Console.WriteLine("Chọn loại giao dịch:");
        Console.WriteLine("1. Chi tiêu");
        Console.WriteLine("2. Thu nhập");
        string choice = Console.ReadLine(); 

        // Kiểm tra đầu vào cho loại giao dịch
        bool isExpense = false;
        if (choice == "1")
        {
            isExpense = true;
        }
        else if (choice != "2")
        {
            Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn 1 hoặc 2.");
            return;
        }

        Console.WriteLine("Nhập loại mục (ăn uống, điện nước, wifi, đi chơi, ...): ");
        string category = Console.ReadLine();

        Console.WriteLine("Nhập số tiền: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
        {
            Console.WriteLine("Số tiền không hợp lệ.");
            return;
        }

        Console.WriteLine("Nhập ngày (dd/MM/yyyy): ");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
        {
            Console.WriteLine("Ngày không hợp lệ.");
            return;
        }

        transactions.Add(new Transaction(category, amount, date, isExpense));
        Console.WriteLine("Giao dịch đã được thêm thành công!");
    }

    // 2.2. Hiển thị các khoản chi tiêu
    public void DisplayExpenses()
    {
        Console.WriteLine("Chọn khoảng thời gian hiển thị: ");
        Console.WriteLine("1. Ngày");
        Console.WriteLine("2. Tuần");
        Console.WriteLine("3. Tháng");
        Console.WriteLine("4. Tất cả");
        string choice = Console.ReadLine();

        IEnumerable<Transaction> filteredTransactions = null;

        switch (choice)
        {
            case "1":
                filteredTransactions = transactions.Where(t => t.Date.Date == DateTime.Now.Date);
                break;
            case "2":
                DateTime startOfWeek = DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek + (int)DayOfWeek.Monday);
                DateTime endOfWeek = startOfWeek.AddDays(6);
                filteredTransactions = transactions.Where(t => t.Date >= startOfWeek && t.Date <= endOfWeek);
                break;
            case "3":
                filteredTransactions = transactions.Where(t => t.Date.Month == DateTime.Now.Month && t.Date.Year == DateTime.Now.Year);
                break;
            case "4":
                filteredTransactions = transactions;
                break;
            default:
                Console.WriteLine("Lựa chọn không hợp lệ.");
                return;
        }

        Console.WriteLine("-------------------------------------------");
        if (filteredTransactions != null && filteredTransactions.Any())
        {
            foreach (var transaction in filteredTransactions)
            {
                Console.WriteLine(transaction);
            }
        }
        else
        {
            Console.WriteLine("Không có giao dịch nào.");
        }
        Console.WriteLine("-------------------------------------------");
    }
}
}