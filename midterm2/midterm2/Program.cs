using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Reflection;
namespace midterm2
{
    class Program
    {
        public static Packman p = new Packman();
        public static ReadFiles a = new ReadFiles();
        static int direction = 2;
        public static int score = 0;
        public static bool gameOver = false;

        static void playGame()
        {
            while (true)
            {
                if (direction == 1)
                    p.Left();
                if (direction == 2)
                    p.Rigth();
                if (direction == 3)
                    p.Up();
                if (direction == 4)
                    p.Down();

                Console.Clear();

                p.Draw();
                a.DrawWall();
                a.DrawFruit();

                if (p.CollisionWithWall(a))
                {
                    //Console.SetCursorPosition(p.body[0].x - 1, p.body[0].y - 1);
                    p.Draw();
                    //Thread.CurrentThread.Abort();
                    //p.Wait(p.body[0].x, p.body[0].y);
                    Console.ReadKey();
                    //Thread.CurrentThread.;
                }
                if (p.CollisionWithFood(a))
                {
                    p.EatFruit(a);
                    score++;
                    //for (int i = 0; i < a.fruit.Count; i++)
                }

                Thread.Sleep(1000);
            }

        }


        static void Main(string[] args)
        {
            a.ReadWall();

            Console.CursorVisible = false;
            Thread thread = new Thread(playGame);
            thread.Start();


            while (!gameOver)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                if (keyInfo.Key == ConsoleKey.UpArrow)
                    direction = 3;
                if (keyInfo.Key == ConsoleKey.DownArrow)
                    direction = 4;
                if (keyInfo.Key == ConsoleKey.LeftArrow)
                    direction = 1;
                if (keyInfo.Key == ConsoleKey.RightArrow)
                    direction = 2;
                if (keyInfo.Key == ConsoleKey.Escape)
                {
                    //thread.Abort();
                    Console.Clear();
                    Console.Write("final score: " + score);
                    Console.ReadKey();
                    gameOver = true;

                }

            }


        }

    }
}
