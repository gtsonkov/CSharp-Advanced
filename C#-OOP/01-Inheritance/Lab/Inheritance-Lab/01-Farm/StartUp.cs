using System;

namespace _01_Farm
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();

            dog.Bark();
            dog.Eat();

            Puppy pup = new Puppy();
            pup.Eat();
            pup.Bark();
            pup.Weep();
        }
    }
}