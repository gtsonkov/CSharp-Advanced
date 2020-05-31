using System;
using System.Collections.Generic;
using System.Linq;

namespace _02_AverageStudentGrades
{
    class AverageStudentGrades
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> gradesBook = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();

                if (gradesBook.ContainsKey(input[0]))
                {
                    gradesBook[input[0]].Add(decimal.Parse(input[1]));
                }

                else
                {
                    List<decimal> list = new List<decimal>();
                    list.Add(decimal.Parse(input[1]));

                    gradesBook.Add(input[0], list);
                }
            }

            foreach (var student in gradesBook)
            {
                decimal middleNote = 0;

                foreach (var note in student.Value)
                {
                    middleNote += note;
                }

                Console.WriteLine($"{student.Key} -> {string.Join(" ", student.Value.Select(x => x.ToString("f2")))} (avg: {(middleNote / student.Value.Count):f2})");
            }
        }
    }
}