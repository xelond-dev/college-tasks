using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cakes
{
    internal class Menu
    {
        public static int Show(int maxPosition)
        {
            int position = 7;
            maxPosition += position - 1;

            while (true)
            {
                Console.SetCursorPosition(1, position);
                Console.WriteLine("o");
                Console.SetCursorPosition(1, position);

                ConsoleKeyInfo KeyReader = Console.ReadKey();

                switch (KeyReader.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (position != 7)
                        {
                            Console.SetCursorPosition(1, position);
                            Console.WriteLine(" ");
                            position--;
                        }
                        break;

                    case ConsoleKey.DownArrow:
                        if (position != maxPosition)
                        {
                            Console.SetCursorPosition(1, position);
                            Console.WriteLine(" ");
                            position++;
                        }
                        break;

                    case ConsoleKey.Enter:
                        return position - 7 + 1;
                }
            }

        }
    }
}
