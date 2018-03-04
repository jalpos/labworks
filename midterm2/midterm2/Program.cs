using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
namespace midterm2
{
    class Program
    {
        public static Packman p;
        public static ReadFiles a;
        static int direction = 2;
        //static bool gameOver = false;


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
                if (p.CollisionWithWall(a.points))
                {
                    p.Move(0, 0);
                    
                }
                if (p.CollisionWithFood(a.fruit))
                {
                    
                    
                    
                }

                //Console.WriteLine("HI");
                Thread.Sleep(1000);
            }
        }

        public static int score = 0;
        static void Main(string[] args)
        {

            p = new Packman();
            a = new ReadFiles();
            a.ReadWall();


            Console.CursorVisible = false;
            Thread thread = new Thread(playGame);
            thread.Start();

            while (true)
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
                    break;
            }

        }

    }
}
