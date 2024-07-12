using System;

class Program
{
    static void Main(string[] args)
    {
        double so1, so2, tich;

        so1 = double.Parse(Console.ReadLine());
        so2 = double.Parse(Console.ReadLine());

        tich = TinhTich(so1, so2);

        Console.WriteLine(tich);
    }

    static double TinhTich(double a, double b)
    {
        return a * b;
    }
}