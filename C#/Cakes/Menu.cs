using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cakes
{
    internal class Menu
    {
        private int maxPosition;
        public Menu(int max)
        {
            maxPosition = max;
        }

        public int Show()
        {
            int position = 7;

            while (true)
            {
                Console.SetCursorPosition(1, position);
                Console.WriteLine("*");

                ConsoleKeyInfo KeyReader = Console.ReadKey();

                switch (KeyReader.Key)
                {
                    case ConsoleKey.UpArrow:
                        Console.SetCursorPosition(1, position);
                        Console.WriteLine(" ");
                        position--;
                        break;

                    case ConsoleKey.DownArrow:
                        Console.SetCursorPosition(1, position);
                        Console.WriteLine(" ");
                        position++;
                        break;

                    case ConsoleKey.Enter:

                        break;
                }
            }


        }
    }
}
