namespace MonthlyExpenseManager
{
    // 1. Lớp Transaction: Đại diện cho một giao dịch (chi tiêu hoặc thu nhập)
public class Transaction
{
    public string Category { get; } //Loại giao dịch
    public decimal Amount { get; }  //Số tiền
    public DateTime Date { get; }   //Ngày tháng
    public bool IsExpense { get; }  //Kiểm tra có phải chi tiêu không?

    public Transaction(string category, decimal amount, DateTime date, bool isExpense)
    {
        Category = category;
        Amount = amount;
        Date = date;
        IsExpense = isExpense;
    }

    public override string ToString() //Tạo ra một chuỗi mô tả chi tiết về giao dịch
    {
        string type = IsExpense ? "Chi tiêu" : "Thu nhập";
        return $"{Date:dd/MM/yyyy} - {type} - {Category}: {Amount:C}";
    }
}
}