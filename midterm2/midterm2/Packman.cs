using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Threading;

namespace midterm2
{
    public class Packman
    {
        public List<Point> body;


        public int cnt;

        public Packman()
        {
            body = new List<Point>();

        }
        public void Move(int dx, int dy)
        {

            body[0].x += dx;
            body[0].y += dy;
       
        }

        public void Up()
        {
            body[0].y--;
        }
        public void Down()
        {
            body[0].y++;

        }
        public void Left()
        {
            body[0].x--;

        }
        public void Rigth()
        {
            body[0].x++;

        }

        public bool CollisionWithWall(List<Point> p)
        {
            foreach (Point a in p.points)
            {
                if (a.x == body[0].x && a.y == body[0].y)
                    return true;
                return false;
            }
        }
        public bool CollisionWithFood(List<Point> p)
        {
            foreach (Point a in p.fruit)
            {
                if (a.x == body[0].x && a.y == body[0].y)
                    return true;
                return false;
            }
        }

        public void Draw()
        {
            Console.SetCursorPosition(body[0].x, body[0].y);
            Console.Write("O");
        }

    }
}
