using Shapes.Constracts;
using System;

namespace Shapes.Models
{
    public class Rectangle : IDrawable
    {
        private int x;
        private int y;

        public Rectangle(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Draw()
        {
            if (x > 0 && y > 0)
            {
                Console.WriteLine(new string('*', y));

                for (int i = 0; i < x - 2; i++)
                {
                    Console.WriteLine("*" + new string(' ', y - 2) + '*');
                }

                Console.WriteLine(new string('*', y));
            }
        }
    }
}