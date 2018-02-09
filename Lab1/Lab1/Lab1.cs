using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        //Point p - вызов функции из другого класса;

        static bool isPrime(int n)
        {
            for (int i = 2; i <= Math.Sqrt(n); i++)
                if (n % i == 0)
                    return false;
            return true;
        }

        static void Main(string[] args)
        {
            /*Point p = new Point();
            p.GetValue();*/ //вызов другого класса 

            /* #1 - string line = Console.ReadLine();

            string[] arr = line.Split(' ');
            for (int i = 0; i < arr.Length; i++)
            {
                //другой способ - Console.WriteLine(arr[i] + " " + isPrime(int.Parse(arr[i])));
                if (isPrime(int.Parse(arr[i])))

                    Console.Write(arr[i] + " ");              
            }*/

           /* #2 Student a = new Student("Almas", "Toibaev", "3.4");//How to use ToString
            Console.WriteLine(a);*/

            string s = Console.ReadLine();


            // #3 Rectangle r = new Rectangle(int.Parse(s), int.Parse(s1));

            Circle r = new Circle(int.Parse(s));
            Console.WriteLine(r);

        }
    }
}
