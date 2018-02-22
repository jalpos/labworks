using System;
using System.IO;

namespace Lab2_2
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader ab = new StreamReader(@"/Users/Farkhat_Sarsekeyev/desktop/calarts/3d/notes.txt");
            string line = ab.ReadLine();
            string[] a = line.Split(" ");
            int min = int.Parse(a[0]);
            int max = int.Parse(a[1]);
            for (int i = 0; i < a.Length; i++)
            {
                if (int.Parse(a[i]) < min)
                {
                    min = int.Parse(a[i]);
                }
                if (int.Parse(a[i]) > max)
                {
                    max = int.Parse(a[i]);
                }

            }
            //Console.WriteLine((min + " " + max));

            StreamWriter cc = new StreamWriter(@"/Users/Farkhat_Sarsekeyev/desktop/notes1");
            cc.WriteLine(min + " " + max);
            cc.Close();

        }
    }
}
