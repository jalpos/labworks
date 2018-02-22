using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
namespace Serialization
{
    [Serializable]
    public class Complex
    {
        public int a, b;
        public Complex() { }
        public Complex(int x, int y)
        {
            this.a = x;
            this.b = y;
        }
        public Complex Add(Complex c)
        {
            Complex res = new Complex(this.a + c.a, this.b + c.b);
            // res = new Complex(6, 8);
            // res.a = 6
            // res.b = 8
            return res;

        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            Complex res = new Complex(c1.a + c2.a, c1.b + c2.b);
            res.Simplify();
            return res;
        }

        public static Complex operator -(Complex c1, Complex c2)
        {
            Complex res = new Complex(c1.a - c2.a, c1.b - c2.b);
            return res;
        }

        public void Simplify()
        {
            int _a = this.a;
            int _b = this.b;

            while (_a > 0 && _b > 0)
            {
                if (_a > _b)
                    _a = _a % _b;
                else
                    _b = _b % _a;
            }
            // _a = 0, _b = 0 gcd(a, b) = _a + _b
            int gcd = _a + _b;
            this.a /= gcd;
            this.b /= gcd;
        }
        public override string ToString()
        {
            return a + "/" + b;
        }

    }

    /*[Serializable]
    class Number
    {
        public int ComplexNumber { get; set; }

        public Number(int complexNumber)
        {
            this.ComplexNumber = complexNumber;

        }
    }*/
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string[] token = s.Split();
            Complex result = new Complex(0, 0);
            for (int t = 0; t < token.Length, t++)
            {
                string[] arr = t.Split('/');

            }
            Complex cmp = new Complex(int.Parse(arr[0]), int.Parse(arr[1]));
            result = result + cmp;

            Console.WriteLine(result);
            Console.ReadKey();

            /*

            Number number = new Number((int.Parse(result)));
            Console.WriteLine("Обьект создан");
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream ab = new FileStream("complexNum.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(ab, number);
                Console.WriteLine("Обьект сериализован");

            }
            using (FileStream ab = new FileStream("complexNum.dat", FileMode.OpenOrCreate))
            {
                Number newNumber = (Number)formatter.Deserialize(ab);
                Console.WriteLine("обьект дисериализован");
            }
            Console.ReadLine();*/
            FileStream fs = new FileStream("complexNum.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, result);
            fs.Close();
            Console.WriteLine("Обьект сериализован");
        }
     }

    }
}

