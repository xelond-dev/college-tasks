namespace RapidTyping
{
    internal class Program
    {
        private static int[] outputArea = new int[2];
        private static int[] textPosition = new int[2] { 0, 0 };

        private static bool timerThreadStopFlag = false; // Flag to stop timer thread.
        static void Main(string[] args)
        {
            ConsoleKeyInfo keyInfo; // Key info
            string name = "unknown";

            // Types
            string[] textsToType = {
                "Капибара - самый крупный грызун мировой фауны, достигающий 1,5 м длины и массы 60 кг. Внешне капибара похожа на гигантскую большеголовую морскую свинку. Пальцы ног имеют небольшие плавательные перепонки. Тело покрыто рыжевато-бурыми волосами, жесткими, как щетина.",
                "У капибары есть короткие конечности, заканчивающиеся частично перепончатыми пальцами. Передние конечности характеризуется наличием четырех пальцев, в то время как на задних - по три пальца. На пальцах есть короткие и мощные когти. В отличие от некоторых грызунов у капибары нет хвоста.",
                "В общем, капибара распространена от Панамы до северной части Аргентины. Водосвинка занимает территорию площадью от 10 до 15 гектаров в зависимости от района, обилия корма и расстояния до источника воды.",
                "Капибары - травоядные животные, которые в основном питаются водными растениями, травой, камышом, корой деревьев, зерном, зелеными листьями (в основном маниока), а также овощами, такими как сквош, и фруктами, включая бананы и дыни."
            };

            // Get name
            Console.Write("Введите ваше имя: ");
            name = Console.ReadLine();

            while (true)
            {
                Console.Clear(); // Clear console
                keyInfo = new ConsoleKeyInfo(); // Reset key info
                textPosition = new int[2] { 0, 0 }; // Reset text position
                // int[] typeStat = new int[2] { 0, 0 }; // Corrected and not corrected words, but it`s not working
                int correctSymbols = 0;
                timerThreadStopFlag = false;


                // Set timer thread.
                Thread timerThread = new Thread(new ThreadStart(Timer));

                string randomText = textsToType[new Random().Next(0, textsToType.Length)]; // Get random text
                //int randomTextIndex = new Random().Next(0, textsToType.Length); // Get random text index

                Console.WriteLine(randomText);
                Console.WriteLine("\n---------------------------");

                outputArea = new int[2] { Console.GetCursorPosition().Left, Console.GetCursorPosition().Top }; // Set output area.

                Console.WriteLine("Нажмите <Enter> чтобы начать.");

                while (keyInfo.Key != ConsoleKey.Enter)
                {
                    keyInfo = Console.ReadKey(true);
                }

                Console.SetCursorPosition(outputArea[0], outputArea[1]); // Go to output area
                Console.WriteLine("                             "); // Clear output area
                /*for (int i = 0; i < Console.WindowWidth; i++) // Clear output area
                {
                    Console.Write(" ");
                }*/

                timerThread.Start();

                foreach (char c in randomText)
                {
                    if (timerThread.IsAlive)
                    {
                        if (textPosition[0] == Console.WindowWidth)
                        {
                            textPosition[0] = 0;
                            textPosition[1]++;
                        }

                        Console.SetCursorPosition(textPosition[0], textPosition[1]); // Set position
                        char userChar = Console.ReadKey().KeyChar; // Get user char

                        if (userChar == c)
                        {
                            Console.SetCursorPosition(textPosition[0], textPosition[1]);
                            Console.ForegroundColor = ConsoleColor.Green; // Color console Green
                            Console.WriteLine(userChar);

                            //typeStat[0]++;
                            correctSymbols++;
                            textPosition[0]++;
                        }
                        else
                        {
                            Console.SetCursorPosition(textPosition[0], textPosition[1]);
                            Console.ForegroundColor = ConsoleColor.Red; // Color console to Red
                            Console.WriteLine(userChar);

                            //typeStat[1]++;
                            textPosition[0]++;
                        }

                        Console.ResetColor();
                    }
                }

                timerThreadStopFlag = true;
                timerThread.Join(); // Wait to stop timer thread.
                timerThread.Interrupt();

                Console.SetCursorPosition(outputArea[0], outputArea[1]);
                Console.WriteLine("Время вышло.");
                Thread.Sleep(2000);

                RecordTable.ShowRecordTable(name, correctSymbols);
                
            }
        }

        static void Timer()
        {
            int currentlySeconds = 59;

            Console.SetCursorPosition(outputArea[0], outputArea[1]);
            Console.WriteLine("1:00");
            Console.SetCursorPosition(textPosition[0], textPosition[1]);

            for (int i = 0; i <= 60; i++)
            {
                if (!timerThreadStopFlag)
                {
                    Thread.Sleep(1000);
                    Console.SetCursorPosition(outputArea[0], outputArea[1]);
                    Console.WriteLine("0:" + currentlySeconds);
                    Console.SetCursorPosition(textPosition[0], textPosition[1]);
                    currentlySeconds--;
                } else
                {
                    break;
                }
            }
        }
    }
}