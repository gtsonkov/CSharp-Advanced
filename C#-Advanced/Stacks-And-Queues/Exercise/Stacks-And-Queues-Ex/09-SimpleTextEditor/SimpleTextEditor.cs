using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _09_SimpleTextEditor
{
    class SimpleTextEditor
    {
        static void Main(string[] args)
        {
            int numberOfOperations = int.Parse(Console.ReadLine());
            Stack<string> text = new Stack<string>();

            for (int i = 0; i < numberOfOperations; i++)
            {
                string token = Console.ReadLine();
                string command = "";
                if (token.Length>1)
                {
                   command = token.Substring(2);
                }

                switch (token[0])
                {
                    case '1':
                        if (text.Count>0)
                        {
                            string currentText = text.Peek() + command;
                            text.Push(currentText);
                        }
                        else
                        {
                            text.Push(command);
                        }
                        break;

                    case '2':
                        {
                            string currentText = text.Peek();
                            int charsToRemove = int.Parse(command);
                            currentText = currentText.Substring(0, (currentText.Length - charsToRemove));
                            text.Push(currentText);
                        }
                        break;

                    case '3':
                        {
                            string currentText = text.Peek();
                            int charIndex = int.Parse(command) -1;
                            Console.WriteLine(currentText[charIndex]);
                        }

                        break;

                    case '4':
                        text.Pop();
                        break;
                }
            }
        }
    }
}