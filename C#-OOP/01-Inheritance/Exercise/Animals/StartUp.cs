using System;
using System.Collections.Generic;
using System.Linq;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Animal> animals = new List<Animal>();

            while (input != "Beast!")
            {
                string[] data = Console.ReadLine().Split().ToArray();

                string name = null;
                int age = 0;
                string gender = null;

                try
                {
                    name = data[0];
                    age = int.Parse(data[1]);
                    if (input != "Tomcat" && input != "Kitten")
                    {
                        gender = data[2];
                    }

                    switch (input)
                    {
                        case "Dog":
                            Dog currDog = new Dog(name, age, gender);
                            animals.Add(currDog);

                            break;

                        case "Frog":
                            Frog currFrog = new Frog(name, age, gender);
                            animals.Add(currFrog);

                            break;

                        case "Cat":
                            Cat currCat = new Cat(name, age, gender);
                            animals.Add(currCat);
                            break;

                        case "Kitten":
                            if (data.Length > 2)
                            {
                                Kitten currKitty = new Kitten(name, age, data[2]);
                                animals.Add(currKitty);
                            }
                            else
                            {
                                Kitten currKitty = new Kitten(name, age);
                                animals.Add(currKitty);
                            }
                            break;

                        case "Tomcat":

                            if (data.Length > 2)
                            {
                                Tomcat currTom = new Tomcat(name, age, data[2]);
                                animals.Add(currTom);
                            }
                            else
                            {
                                Tomcat currTom = new Tomcat(name, age);
                                animals.Add(currTom);
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    throw new ArgumentException("Invalid input!");
                }

                input = Console.ReadLine();
            }

            foreach (var animal in animals)
            {
                Console.WriteLine(animal.GetType().Name);
                Console.WriteLine($"{animal.Name} {animal.Age} {animal.Gender}");
                Console.WriteLine(animal.ProduceSound());
            }
        }
    }
}