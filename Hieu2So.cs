using System;

class Program
{
    static double Hieu2So(double a, double b)
    {
        return a - b;
    }
}
    static void Main(string[] args)
    {
        double x, y, Hieu;

        x = double.Parse(Console.ReadLine());
        y = double.Parse(Console.ReadLine());

        Hieu = Hieu2So(x, y);

        Console.WriteLine(Hieu);
    }