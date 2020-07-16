using System;
using System.Linq;

namespace _04_PizzaCalories
{
    class StratUp
    {
        static void Main(string[] args)
        {
            Pizza pizza;
            string[] input = Console.ReadLine()
                .Split().
                ToArray();
            try
            {
                pizza = new Pizza(input[1]);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return;
            }

            input = Console.ReadLine()
                .Split().
                ToArray();

            try
            {

                Dough dough = new Dough(input[1], input[2], double.Parse(input[3]));
                pizza.Dough = dough;

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return;
            }

            while (input[0] != "END")
            {
                input = Console.ReadLine()
                .Split().
                ToArray();

                if (input[0] == "Topping")
                {
                    try
                    {
                        Topping topping = new Topping(input[1], double.Parse(input[2]));
                        pizza.AddTopping(topping);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        return;
                    }
                }
            }

            Console.WriteLine(pizza.ToString());

        }
    }
}