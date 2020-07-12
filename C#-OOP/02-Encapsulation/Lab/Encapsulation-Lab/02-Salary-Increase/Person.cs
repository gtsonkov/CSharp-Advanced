namespace PersonsInfo
{
    public class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public decimal Salary { get; set; }

        public Person(string name, string lastName, int age, decimal salary)
        {
            this.FirstName = name;
            this.LastName = lastName;
            this.Age = age;
            this.Salary = salary;
        }


        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age > 30)
            {
                this.Salary += this.Salary * percentage / 100;
            }
            else
            {
                this.Salary += this.Salary * percentage / 200;
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} receives {Salary:F2} leva.";
        }
    }
}