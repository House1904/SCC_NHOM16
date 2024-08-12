namespace MonthlyExpenseManager
{
        // 4. Kiểm tra cảnh báo ngân sách
    public void CheckBudgetAlerts()
    {
        DateTime now = DateTime.Now;
        int daysInMonth = DateTime.DaysInMonth(now.Year, now.Month);


        var monthlyBalance = transactions
            .Where(t => t.Date.Month == now.Month && t.Date.Year == now.Year)
            .GroupBy(t => t.Category)
            .Select(g => new
            {
                Category = g.Key,
                TotalIncome = g.Where(t => !t.IsExpense).Sum(t => t.Amount),
                TotalExpense = g.Where(t => t.IsExpense).Sum(t => t.Amount)
            });

        foreach (var item in monthlyBalance)
        {
            if (budget.ContainsKey(item.Category))
            {
                decimal budgetLimit = budget[item.Category];
                decimal dailyBudget = budgetLimit / daysInMonth;
                decimal balance = item.TotalIncome - item.TotalExpense;

                if (balance <= 0)
                {
                    Console.WriteLine($"Cảnh báo: Bạn đã hết ngân sách cho {item.Category}! Vượt quá: {Math.Abs(balance):C}");
                }
                else if (balance <= dailyBudget * 2)
                {
                    Console.WriteLine($"Cảnh báo: Bạn sắp hết ngân sách cho {item.Category}! Chỉ còn lại: {balance:C}");
                }


            }
            else
            {
                Console.WriteLine($"Lưu ý: Bạn chưa đặt ngân sách cho {item.Category}.");
            }
        }
    }
}