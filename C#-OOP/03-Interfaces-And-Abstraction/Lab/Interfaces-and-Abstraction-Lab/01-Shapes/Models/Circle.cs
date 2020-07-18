using Shapes.Constracts;
using System;

namespace Shapes.Models
{
    public class Circle : IDrawable
    {
        private int radius;

        public Circle(int radius)
        {
            this.radius = radius;
        }

        public void Draw()
        {

            double r_In = this.radius - 0.4;
            double r_Out = this.radius + 0.4;

            if (this.radius > 0)
            {

                for (double i = this.radius; i >= -this.radius; --i)
                {
                    for (double j = -this.radius; j < r_Out; j += 0.5)
                    {
                        double current = i * i + j * j;
                        if (current >= r_In * r_In && current <= r_Out * r_Out)
                        {
                            Console.Write("*");
                        }
                        else
                        {
                            Console.Write(" ");
                        }
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}