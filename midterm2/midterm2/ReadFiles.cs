using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
namespace midterm2
{

    public class ReadFiles
    {

        public List<Point> points;
        public List<Point> fruit = new List<Point>();

        public ReadFiles()
        {
            points = new List<Point>();
            fruit = new List<Point>();
        }

        public void ReadWall()
        {
            StreamReader ab = new StreamReader(@"/Users/Farkhat_Sarsekeyev/desktop/input.txt");
            int n = int.Parse(ab.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string s = ab.ReadLine();
                for (int j = 0; j < s.Length; j++)
                {
                    if (s[j] == '*')
                    {
                        points.Add(new Point(j, i));
                    }
                    if (s[j] == 'z')
                    {
                        Program.p.body.Add(new Point(j, i));
                    }
                    if (s[j] == '1')
                    {
                        fruit.Add(new Point(j, i));

                    }
                }
            }
        }

        public void DrawWall()
        {
            foreach (Point p in points)
            {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write("*");
            }
        }
        public void DrawFruit()
        {
            foreach (Point a in fruit)
            {
                Console.SetCursorPosition(a.x, a.y);
                Console.Write("1");
            }
        }

    }
}
