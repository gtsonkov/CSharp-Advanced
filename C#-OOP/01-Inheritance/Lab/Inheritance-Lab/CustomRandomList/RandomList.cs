using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    /// <summary>
    /// Remove random Element from List
    /// </summary>
    public class RandomList : List<string>
    {
        private Random _random;

        public RandomList(IEnumerable<string> data)
            :base (data)
        {
            this._random = new Random();
        }

        public string RandomString()
        {
            string result = string.Empty;

            int index = _random.Next(0, this.Count);

            result = this[index];

            this.RemoveAt(index);

            return result;
        }
    }
}