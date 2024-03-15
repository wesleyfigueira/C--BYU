using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Define the scripture
        string reference = "John 3:16";
        string text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";

        // Store the scripture
        Scripture scripture = new Scripture(reference, text);

        // Display the complete scripture
        Console.Clear();
        scripture.Display();

        // Prompt the user to press enter or type quit
        while (scripture.HasHiddenWords())
        {
            Console.WriteLine("\nPress Enter to continue or type 'quit' to exit.");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
                break;

            // Hide random words in the scripture
            scripture.HideRandomWord();

            // Clear console and display the scripture again
            Console.Clear();
            scripture.Display();
        }

        Console.WriteLine("\nAll words in the scripture have been hidden. Press Enter to exit.");
        Console.ReadLine();
    }
}

class Scripture
{
    private string reference;
    private string text;
    private List<string> words;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.text = text;
        words = new List<string>(text.Split(' '));
    }

    public bool HasHiddenWords()
    {
        return words.Exists(word => word.StartsWith("["));
    }

    public void HideRandomWord()
    {
        Random random = new Random();
        int index = random.Next(words.Count);
        if (!words[index].StartsWith("["))
        {
            words[index] = "[" + words[index] + "]";
        }
    }

    public void Display()
    {
        Console.WriteLine(reference + "\n");
        foreach (string word in words)
        {
            Console.Write(word + " ");
        }
        Console.WriteLine();
    }
}

