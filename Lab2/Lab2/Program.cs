using System;
using System.IO;
namespace Lab2
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
            string s = Console.ReadLine();
            string[] arr = s.Split(' ');
            int max =int.Parse( arr[0]);
            int min = int.Parse(arr[1]);
            for (int i = 0; i < arr.Length; i++)
            {
                if (isPrime(int.Parse(arr[i])))
                {
                    if (int.Parse(arr[i]) > max)
                    {
                        max = int.Parse(arr[i]);
                    }
                    if (int.Parse(arr[i]) < min)
                    {
                        min = int.Parse(arr[i]);
                        
                    }

                }

             }
            Console.WriteLine("max: " + max + "," + "min: " + min);


        }
    }
}
