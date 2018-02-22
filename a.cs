using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            //string[] arr = s.Split();
            double a = double.Parse(s);
	    s = Console.ReadLine();
            double b = double.Parse(s);
            double c = Math.Sqrt(Math.Pow(a, 2) + b * b);
            Console.WriteLine(c);
            //Console.ReadKey();
        }
    }
}
