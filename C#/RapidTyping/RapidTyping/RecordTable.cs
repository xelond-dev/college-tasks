using Newtonsoft.Json;

namespace RapidTyping
{
    internal class RecordTable
    {
        public static void ShowRecordTable(string username, int correctSymbols) {
            Console.Clear();
            
            List<RecordType> recordTable = JsonConvert.DeserializeObject<List<RecordType>>(File.ReadAllText("/home/xelond/DotNetProjects/RapidTyping/RapidTyping/test.json"));
            
            //RecordType newRecord = new RecordType() { name = username, symbolsPerMinute = typeStat[0] - typeStat[1], symbolsPerSecond = (typeStat[0] - typeStat[1]) / 60 };
            recordTable.Add(new RecordType() { name = username, symbolsPerMinute = correctSymbols, symbolsPerSecond = correctSymbols / 60 });

            Console.WriteLine("Имя                 Символов в минуту   Символов в секунду");
            
            int topPosition = 1;
            foreach (RecordType record in recordTable) {
                Console.SetCursorPosition(0, topPosition);
                System.Console.WriteLine(record.name);

                Console.SetCursorPosition(20, topPosition);
                System.Console.WriteLine(record.symbolsPerMinute);

                Console.SetCursorPosition(40, topPosition);
                System.Console.WriteLine(record.symbolsPerSecond);

                topPosition++;
            }

            File.WriteAllText("/home/xelond/DotNetProjects/RapidTyping/RapidTyping/test.json", JsonConvert.SerializeObject(recordTable));
                        
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();

            Console.WriteLine("\nНажмите <Enter>, если хотите попробовать еще.");

            while (keyInfo.Key != ConsoleKey.Enter)
            {
                keyInfo = Console.ReadKey(true);
            }

            /* List<RecordType> recordTable = JsonConvert.DeserializeObject<List<RecordType>>(test);\
            // foreach (RecordType symbolInfo in recordTable)
            // {
            //     Console.WriteLine($"Name: {symbolInfo.Name}, SymbolsPerMinute: {symbolInfo.SymbolsPerMinute}, SymbolsPerSecond: {symbolInfo.SymbolsPerSecond}");
            // }
            */

        }
    }
}