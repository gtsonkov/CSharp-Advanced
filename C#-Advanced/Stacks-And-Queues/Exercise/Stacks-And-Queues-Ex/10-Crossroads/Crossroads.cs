using System;
using System.Collections.Generic;

namespace _10.Crossroads
{
    public class Crossroads
    {
        public static void Main()
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            Queue<string> cars = new Queue<string>();

            bool isTrashed = false;
            int succesfulCount = 0;

            while (input != "END")
            {
                if (input == "green")
                {
                    int crrGreenLight = greenLight;
                    while (crrGreenLight > 0 && cars.Count > 0)
                    {
                        string currentCar = cars.Dequeue();
                        int lengthOfCar = currentCar.Length;

                        if (crrGreenLight - lengthOfCar > 0
                            && crrGreenLight - lengthOfCar <= crrGreenLight)
                        {
                            crrGreenLight -= lengthOfCar;
                        }

                        else
                        {
                            int left = crrGreenLight - lengthOfCar;

                            if (left > 0)
                            {
                                crrGreenLight -= lengthOfCar;
                            }
                            else
                            {
                                if (freeWindow - -left >= 0)
                                {
                                    freeWindow -= -left;
                                    crrGreenLight -= lengthOfCar;
                                }
                                else
                                {
                                    isTrashed = true;
                                    Console.WriteLine("A crash happened!");
                                    Console.WriteLine($"{currentCar} was hit at {currentCar[crrGreenLight + freeWindow]}.");
                                    break;
                                }
                            }
                        }

                        succesfulCount++;
                    }
                }

                else
                {
                    cars.Enqueue(input);
                }

                if (isTrashed)
                {
                    break;
                }

                input = Console.ReadLine();
            }

            if (!isTrashed)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{succesfulCount} total cars passed the crossroads.");
            }
        }
    }
}