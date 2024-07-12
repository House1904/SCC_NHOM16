using System;

class Program
{
    static void Main(string[] args)
    {
        double a, b, c;

        a = double.Parse(Console.ReadLine());
        b = double.Parse(Console.ReadLine());

        c = TinhChia(so1, so2);

        Console.WriteLine(c);
    }

    static double TinhChia(double x, double y)
    {
        return x / y;
    }
}