void CheckBudgetAlerts()
{
    var monthlyExpenses = transactions
        .Where(t => t.Date.Month == DateTime.Now.Month && t.Date.Year == DateTime.Now.Year)
        .GroupBy(t => t.Category)
        .Select(g => new { Category = g.Key, TotalAmount = g.Sum(t => t.Amount) });

    foreach (var expense in monthlyExpenses)
    {
        if (budget.ContainsKey(expense.Category))
        {
            if (expense.TotalAmount >= budget[expense.Category])
            {
                Console.WriteLine($"Cảnh báo: Bạn đã vượt quá ngân sách cho {expense.Category}!");
            }
            else if (expense.TotalAmount >= budget[expense.Category] * 0.9m)
            {
                Console.WriteLine($"Cảnh báo: Bạn gần đạt đến ngân sách cho {expense.Category}!");
            }
        }
    }
}
