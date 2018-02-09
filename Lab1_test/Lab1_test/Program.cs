using System;
using System.IO;

namespace Lab1_test
{
    class Program
    {
        static bool isPrime(int n)
        {
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0)
                    return false;
            return true;
        }
        static void Main(string[] args)
        {
            string line = Console.ReadLine();
            string[] a = line.Split(' ');
            int min = int.Parse(a[0]);
            int max = int.Parse(a[1]);
            for (int i = 0; i < a.Length; i++)
            {
                if (isPrime(int.Parse(a[i])))
                {

                    if (int.Parse(a[i]) > max)

                        max = int.Parse(a[i]);
                    
                    if (int.Parse(a[i]) < min)
                        min = int.Parse(a[i]);
                        
                        
                }
                    
            }
            Console.WriteLine("min: " + min + "max: " + max);

        }

    }
}

