using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonthlyExpenseManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8; //gõ dấu trong C#
            ExpenseManager expenseManager = new ExpenseManager();
            while (true)
            {
                Console.WriteLine("Chọn chức năng:");
                Console.WriteLine("1. Thêm giao dịch");
                Console.WriteLine("2. Hiển thị giao dịch");
                Console.WriteLine("3. Đặt ngân sách theo từng mục");
                Console.WriteLine("4. Kiểm tra cảnh báo ngân sách");
                Console.WriteLine("5. Thoát");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        expenseManager.AddTransaction();
                        break;
                    case "2":
                        expenseManager.DisplayExpenses();
                        break;
                    case "3":
                        expenseManager.SetBudget();
                        break;
                    case "4":
                        expenseManager.CheckBudgetAlerts();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng thử lại.");
                        break;
                }

                Console.WriteLine();
            }
        }
    }
}