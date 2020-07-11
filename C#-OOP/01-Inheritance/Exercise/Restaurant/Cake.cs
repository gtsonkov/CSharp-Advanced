namespace Restaurant
{
    public class Cake : Dessert
    {
        private const double Grams = 250.00;
        private const double Calories = 1000.00;
        private const decimal Price = 5.00M;

        public Cake(string name) 
            : base(name, Price, Grams, Calories)
        {
        }
    }
}