namespace Animals
{
    public class Animal
    {
        public string Name { get; private set; }

        public int Age { get; private set; }

        public string Gender { get; private set; }

        public Animal(string name, int age, string gender)
        {
            this.Name = name;

            this.Age = age;

            this.Gender = gender;
        }

        public virtual string ProduceSound()
        {
            return "Test";
        }
    }
}