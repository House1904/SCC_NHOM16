namespace MonthlyExpenseManager
{
    // 3. Đặt ngân sách theo từng mục
public void SetBudget()
{
    Console.WriteLine("Nhập loại mục (ăn uống, điện nước, wifi, đi chơi, ...): ");
    string category = Console.ReadLine();

    Console.WriteLine("Nhập ngân sách hàng tháng: ");
    if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
    {
        Console.WriteLine("Số tiền không hợp lệ.");
        return;
    }

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
}