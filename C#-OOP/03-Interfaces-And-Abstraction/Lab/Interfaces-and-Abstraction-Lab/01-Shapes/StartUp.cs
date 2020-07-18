using Shapes.Constracts;
using Shapes.Models;
using System;

namespace Shapes
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int r = int.Parse(Console.ReadLine());

            IDrawable circle = new Circle(r);

            int x = int.Parse(Console.ReadLine());
            int y = int.Parse(Console.ReadLine());

            IDrawable recangle = new Rectangle(x,y);

            circle.Draw();
            recangle.Draw();

        }
    }
}