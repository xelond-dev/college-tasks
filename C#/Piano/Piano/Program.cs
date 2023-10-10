using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Piano
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] currentlyOctave = new int[] {};

            currentlyOctave = getOctave(0);

            while(true)
            {
                ConsoleKeyInfo keyReader = Console.ReadKey();
                Console.Clear();

                // Switch octave            
                switch (keyReader.Key)
                {
                    case ConsoleKey.F1:
                        currentlyOctave = getOctave(0);
                        Console.WriteLine("Первая окатава");
                        break;

                    case ConsoleKey.F2:
                        currentlyOctave = getOctave(1);
                        Console.WriteLine("Вторая окатава");
                        break;
                }

                // Play sound
                playSound(keyReader, currentlyOctave);
            }
        }

        static void playSound(ConsoleKeyInfo keyReader, int[] currentlyOctave)
        {
            int timeout = 80; // Timout

            switch (keyReader.Key)
            {
                case ConsoleKey.A:
                    Console.Beep(currentlyOctave[0], timeout);
                    break;
                case ConsoleKey.W:
                    Console.Beep(currentlyOctave[1], timeout);
                    break;
                case ConsoleKey.S:
                    Console.Beep(currentlyOctave[2], timeout);
                    break;
                case ConsoleKey.E:
                    Console.Beep(currentlyOctave[3], timeout);
                    break;
                case ConsoleKey.D:
                    Console.Beep(currentlyOctave[4], timeout);
                    break;
                case ConsoleKey.R:
                    Console.Beep(currentlyOctave[5], timeout);
                    break;
                case ConsoleKey.F:
                    Console.Beep(currentlyOctave[6], timeout);
                    break;
                case ConsoleKey.T:
                    Console.Beep(currentlyOctave[7], timeout);
                    break;
                case ConsoleKey.G:
                    Console.Beep(currentlyOctave[8], timeout);
                    break;
                case ConsoleKey.Y:
                    Console.Beep(currentlyOctave[9], timeout);
                    break;
                case ConsoleKey.H:
                    Console.Beep(currentlyOctave[10], timeout);
                    break;
                case ConsoleKey.U:
                    Console.Beep(currentlyOctave[11], timeout);
                    break;
            }
        }

        static int[] getOctave(int octaveNumber)
        {
            switch (octaveNumber)
            {
                case 0: return new int[] { 1635, 1732, 1835, 1945, 2060, 2183, 2312, 2450, 2596, 2750, 2914, 3087 }; // First octave
                case 1: return new int[] { 3270, 3465, 3671, 3889, 4120, 4365, 4625, 4900, 5191, 5500, 5827, 6174 }; // Second octave

                default: return null;
            }
        }
    }
}


