using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalcConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Calc.Calc  calc = new Calc.Calc();
            Console.Write("A: ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("B: ");
            int b= Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"Add: {calc.Add(a, b)}");
            Console.WriteLine($"Substract: {calc.Substract(a, b)}");
            Console.WriteLine($"Divide: {calc.Divide(a, b)}");
            Console.WriteLine($"Multiply: {calc.Multiply(a, b)}");
            Console.ReadLine();
        }
    }
}
