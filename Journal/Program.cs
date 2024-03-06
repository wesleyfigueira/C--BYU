using System;
using System.Collections.Generic;
using System.IO;

class Entry {
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }

    public Entry(string prompt, string response, DateTime date) {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public override string ToString() {
        return $"{Date.ToString("yyyy-MM-dd")} - {Prompt}\n{Response}\n";
    }
}

class Journal {
    private List<Entry> entries;

    public Journal() {
        entries = new List<Entry>();
    }

    public void AddEntry(Entry entry) {
        entries.Add(entry);
    }

    public void DisplayEntries() {
        foreach (var entry in entries) {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename) {
        using (StreamWriter writer = new StreamWriter(filename)) {
            foreach (var entry in entries) {
                writer.WriteLine($"{entry.Date.ToString("yyyy-MM-dd")},{entry.Prompt},{entry.Response}");
            }
        }
        Console.WriteLine("Journal saved to file successfully.");
    }

    public void LoadFromFile(string filename) {
        entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (var line in lines) {
            string[] parts = line.Split(',');
            DateTime date = DateTime.Parse(parts[0]);
            string prompt = parts[1];
            string response = parts[2];
            Entry entry = new Entry(prompt, response, date);
            entries.Add(entry);
        }
        Console.WriteLine("Journal loaded from file successfully.");
    }
}

class Program {
    static void Main(string[] args) {
        Journal journal = new Journal();
        bool running = true;

        while (running) {
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice) {
                case "1":
                    WriteNewEntry(journal);
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    Console.Write("Enter filename to save: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    break;
                case "4":
                    Console.Write("Enter filename to load: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    break;
                case "5":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void WriteNewEntry(Journal journal) {
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        Random random = new Random();
        int index = random.Next(prompts.Length);
        string prompt = prompts[index];

        Console.WriteLine($"Prompt: {prompt}");
        Console.Write("Response: ");
        string response = Console.ReadLine();
        Entry entry = new Entry(prompt, response, DateTime.Now);
        journal.AddEntry(entry);
    }
}

