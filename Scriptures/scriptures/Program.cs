using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Define the scripture
        Reference reference = new Reference("John", 3, 16);
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

            // Hide a random word in the scripture
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
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        
        string[] splitText = text.Split(' ');
        foreach (string word in splitText)
        {
            _words.Add(new Word(word));
        }
    }

    public bool HasHiddenWords()
    {
        return _words.Exists(word => !word.IsHidden);
    }

    public void HideRandomWord()
    {
        Random random = new Random();
        int index = random.Next(_words.Count);
        if (!_words[index].IsHidden)
        {
            _words[index].Hide();
        }
    }

    public void Display()
    {
        Console.WriteLine(_reference);
        foreach (Word word in _words)
        {
            Console.Write(word + " ");
        }
        Console.WriteLine();
    }
}

class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public void Show()
    {
        _isHidden = false;
    }

    public override string ToString()
    {
        return _isHidden ? "[______]" : _text;
    }

    public bool IsHidden
    {
        get { return _isHidden; }
    }
}

class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _verse = verse;
    }

    public override string ToString()
    {
        return $"{_book} {_chapter}:{_verse}\n";
    }
}


