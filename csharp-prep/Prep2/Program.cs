using System;
using System.Collections.Generic;
using System.IO;

class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }

    public Entry(string prompt, string response)
    {
        Prompt = prompt;
        Response = response;
        Date = DateTime.Now;
    }
}

class Journal
{
    private List<Entry> entries = new List<Entry>();
    private Random random = new Random();

    public void WriteNewEntry()
    {
        string randomPrompt = GetRandomPrompt();
        Console.WriteLine("Random Prompt: " + randomPrompt);
        Console.Write("Your Response: ");
        string response = Console.ReadLine();

        Entry newEntry = new Entry(randomPrompt, response);
        entries.Add(newEntry);
    }

    public void DisplayJournal()
    {
        foreach (Entry entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date.ToString("yyyy-MM-dd HH:mm:ss")}\nPrompt: {entry.Prompt}\nResponse: {entry.Response}\n");
        }
    }

    public void SaveJournalToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                writer.WriteLine($"{entry.Date.ToString("yyyy-MM-dd HH:mm:ss")}|{entry.Prompt}|{entry.Response}");
            }
        }
    }

    public void LoadJournalFromFile(string filename)
    {
        entries.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            while (!reader.EndOfStream)
            {
                string[] entryData = reader.ReadLine().Split('|');
                DateTime entryDate = DateTime.ParseExact(entryData[0], "yyyy-MM-dd HH:mm:ss", null);
                Entry loadedEntry = new Entry
                {
                    Date = entryDate,
                    Prompt = entryData[1],
                    Response = entryData[2]
                };
                entries.Add(loadedEntry);
            }
        }
    }

    private string GetRandomPrompt()
    {
        List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };
        return prompts[random.Next(prompts.Count)];
    }
}

class Program
{
    static void Main()
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option (1-5): ");

            int choice;
            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        journal.WriteNewEntry();
                        break;
                    case 2:
                        journal.DisplayJournal();
                        break;
                    case 3:
                        Console.Write("Enter the filename to save: ");
                        string saveFilename = Console.ReadLine();
                        journal.SaveJournalToFile(saveFilename);
                        break;
                    case 4:
                        Console.Write("Enter the filename to load: ");
                        string loadFilename = Console.ReadLine();
                        journal.LoadJournalFromFile(loadFilename);
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please choose a number between 1 and 5.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}
