using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "";
            int FinalScore = 0;
            Console.CursorVisible = false; // Чтобы было приятно глазу
            int level = 1;
            if (level == 1) // Получаем имя нашего игрока
            {
                Console.SetCursorPosition(10, 10);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Enter your name: ");
                Console.SetCursorPosition(27, 10);
                name = Console.ReadLine();
                Console.Clear();

            }

            Snake snake = new Snake();
            Wall wall = new Wall(level);
            Fruit f = new Fruit(wall);
            Fruit c = new Fruit(wall);
            Fruit d = new Fruit(wall);
            snake.Draw();
            wall.Draw();
            f.FoodDrawer();

            Console.SetCursorPosition(Console.WindowWidth - 16, 1); // Здесь оно будет показывать имя пользователя
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Name " + name);
            Console.SetCursorPosition(Console.WindowWidth - 16, Console.WindowHeight - 1); // А так же его счёт
            Console.ForegroundColor = ConsoleColor.Green;
            int n = snake.body.Count - 1;
            Console.WriteLine("Score = " + n);


            int cnt = 0;
            while (true) // Бесконечный цикл, игра началась
            {
                Console.SetCursorPosition(Console.WindowWidth - 16, 1); // Тут чтобы обновлялись наши очки каждый раз и не пропадали
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Name " + name);
                Console.SetCursorPosition(Console.WindowWidth - 16, Console.WindowHeight - 1);
                Console.ForegroundColor = ConsoleColor.Green;
                n = snake.body.Count - 1;
                Console.WriteLine("Score = " + n);
                ConsoleKeyInfo key = Console.ReadKey(); // Проверяем какую кнопку мы нажали чтобы передвигать змейку
                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (cnt == 1 && snake.body.Count != 1) continue; // Блочим змейку если она после низа хочет пойти навверх
                    snake.Move(0, 1); // Ислключение если у змейка имеется только голова
                    cnt = 2;
                }
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (cnt == 2 && snake.body.Count != 1) continue;
                    snake.Move(0, -1);
                    cnt = 1;
                }
                if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (cnt == 3 && snake.body.Count != 1) continue;
                    snake.Move(-1, 0);
                    cnt = 4;
                }
                if (key.Key == ConsoleKey.RightArrow)
                {
                    if (cnt == 4 && snake.body.Count != 1) continue;
                    snake.Move(1, 0);
                    cnt = 3;
                }
                if (key.Key == ConsoleKey.S)
                {
                    if (cnt == 1 && snake.body.Count != 1) continue;
                    snake.Move(0, 1);
                    cnt = 2;
                }
                if (key.Key == ConsoleKey.W)
                {
                    if (cnt == 2 && snake.body.Count != 1) continue;
                    snake.Move(0, -1);
                    cnt = 1;
                }
                if (key.Key == ConsoleKey.A)
                {
                    if (cnt == 3 && snake.body.Count != 1) continue;
                    snake.Move(-1, 0);
                    cnt = 4;
                }
                if (key.Key == ConsoleKey.D)
                {
                    if (cnt == 4 && snake.body.Count != 1) continue;
                    snake.Move(1, 0);
                    cnt = 3;
                }
                if (key.Key == ConsoleKey.R) // Для рестарта игры
                {
                    level = 1;
                    snake = new Snake();
                    wall = new Wall(level);
                    f = new Fruit(wall);
                    FinalScore = 0;
                }
                if (snake.CollisionWithWall(wall) || snake.Collision()) // Проверяем не столкнулась наша змейка со стеной или самой собой
                {
                    Console.Clear();
                    Console.SetCursorPosition(40, 10);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Game Over, Good Luck Next Time");
                    Console.ReadKey();
                    snake = new Snake();
                    level = 1;
                    wall = new Wall(level);
                    f = new Fruit(wall);
                    FinalScore = 0;
                }
                Console.Clear();
                if (snake.CollisionWithFood(f)) // Проверка, скушала ли наша змейка фрукт
                {
                    snake.body.Add(new Point(snake.body.Last().x + 1, snake.body.Last().y + 1));
                    f = new Fruit(wall);
                    f.FoodDrawer();
                    /* if(level == 2)
                    {
                        c = new Fruit(wall);
                        c.FoodDrawer();
                    }
                    if(level == 3)
                    {
                        c = new Fruit(wall);
                        c.FoodDrawer();
                        d = new Fruit(wall);
                        d.FoodDrawer();
                    } */
                }


                if (snake.body.Count % 6 == 0 && level == 1) // Переходим на 2ой лвл 
                {
                    level++;
                    wall = new Wall(level);
                    snake = new Snake();
                    f = new Fruit(wall);
                    Console.Clear();
                    wall.Draw();
                    snake.Draw();
                    f.FoodDrawer();
                    FinalScore += 5;
                }
                if (snake.body.Count % 11 == 0 && level == 2) // Переходим на 3 лвл
                {
                    level++;
                    wall = new Wall(level);
                    snake = new Snake();
                    f = new Fruit(wall);
                    Console.Clear();
                    wall.Draw();
                    snake.Draw();
                    f.FoodDrawer();
                    FinalScore += 10;
                }
                if (snake.body.Count % 16 == 0 && level == 3) // Переходим к поздравлениям
                {
                    FinalScore += 15;
                    level++;
                    Console.Clear();
                }
                if (level == 4) // Поздравление + финальные поинты
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(40, 10);
                    Console.WriteLine("Congratuations, you have won this game " + name + "!!!!");
                    Console.SetCursorPosition(40, 11);
                    Console.WriteLine("Your Final Score was " + FinalScore);
                    Console.SetCursorPosition(40, 20);
                    Console.WriteLine("Press R to Restart");
                    Console.SetCursorPosition(40, 22);
                    Console.WriteLine("Press Any Other Key To Exit");
                    //Console.Clear();
                    var pressedKey = Console.ReadKey();
                    if (pressedKey.Key == ConsoleKey.R) // Чтобы начать игру заново после прохождения
                    {
                        level = 1;
                        Console.Clear();
                        Main(null);
                    }
                    else break;

                }
                snake.Draw();
                wall.Draw();
                f.FoodDrawer();
            }
        }
    }
}