namespace Notebook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo KeyReader;
            DateTime Date = DateTime.Today; // Currently date

            // Notes
            Note note1 = new Note() { title = "Example note 1", description = "This is example note." };
            Note note2 = new Note() { title = "Example note 2", description = "This is example note." };
            Note note3 = new Note() { title = "Have a good day today!", description = "Your smile is best of the world." };
            Note note4 = new Note() { title = "Example note 3", description = "This is example note." };
            Note note5 = new Note() { title = "Example note 4", description = "This is example note." };

            // Dictionary
            Dictionary<DateTime, Note> allNotes = new Dictionary<DateTime, Note> { };
            allNotes.Add(DateTime.Today.AddDays(-5), note1);
            allNotes.Add(DateTime.Today.AddDays(-2), note2);
            allNotes.Add(DateTime.Today, note3);
            allNotes.Add(DateTime.Today.AddDays(3), note4);
            allNotes.Add(DateTime.Today.AddDays(8), note5);


            int position = 1;
            

            while (true)
            {
                int maxPosition = 0;
                bool noteIsDisplayed = false;

                Console.Clear();
                Console.WriteLine(Date.ToShortDateString()); // To short


                foreach (var varNote in allNotes)
                {
                    if (Date.ToShortDateString() == varNote.Key.ToShortDateString()) {
                        Console.WriteLine("[ ] " + varNote.Value.title);

                        maxPosition++;
                    }
                }

                do
                {
                    if (maxPosition != 0 && noteIsDisplayed == false)
                    {
                        Console.SetCursorPosition(1, position);
                        Console.WriteLine("*");
                    }

                    KeyReader = Console.ReadKey();

                    if (KeyReader.Key == ConsoleKey.RightArrow)
                    {
                        Date = Date.AddDays(1);
                        break;
                    } else if (KeyReader.Key == ConsoleKey.LeftArrow)
                    {
                        Date = Date.AddDays(-1);
                        break;
                    }

                    if (maxPosition != 0)
                    {
                        Console.SetCursorPosition(1, position);
                        Console.WriteLine(" ");

                        if (KeyReader.Key == ConsoleKey.Enter && noteIsDisplayed == false)
                        {
                            Console.Clear();

                            foreach (var varNote in allNotes)
                            {
                                if (Date.ToShortDateString() == varNote.Key.ToShortDateString())
                                {
                                    Console.WriteLine("Название заметки: " + varNote.Value.title);
                                    Console.WriteLine("Описание заметки: " + varNote.Value.description);
                                }
                            }

                            noteIsDisplayed = true;
                        } else
                        {l
                            break;
                        }

                        switch (KeyReader.Key)
                        {
                            case ConsoleKey.UpArrow:
                                if (position != 1)
                                {
                                    position--;
                                }
                                break;

                            case ConsoleKey.DownArrow:
                                if (position != maxPosition)
                                {
                                    position--;
                                }
                                break;
                            case ConsoleKey.Enter:
                          


                                break;
                        }
                    }
                   
                } while (true);
            }
        }
    }
}