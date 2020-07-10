namespace Person
{
    public class Person
    {
        private string _name;

        private int _age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name 
        { 
            get { return this._name; } 
            private set { this._name = value; } 
        }

        public int Age
        {
            get { return this._age; }
            private set { this._age = value; }
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }
    }
}