using System;
using System.Threading;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RunActivity(new BreathingActivity());
                    break;
                case "2":
                    RunActivity(new ReflectionActivity());
                    break;
                case "3":
                    RunActivity(new ListingActivity());
                    break;
                case "4":
                    Console.WriteLine("Exiting program...");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }

    static void RunActivity(Activity activity)
    {
        Console.Write("Enter duration in seconds: ");
        int duration = int.Parse(Console.ReadLine());
        activity.StartActivity(duration);
    }
}

abstract class Activity
{
    protected string name;
    protected string description;
    protected Random random = new Random();

    public abstract void StartActivity(int duration);

    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine($"Starting in {i}...");
            Thread.Sleep(1000);
        }
    }

    protected void ShowSpinner(int seconds)
    {
        char[] spinners = { '|', '/', '-', '\\' };
        int index = 0;

        for (int i = 0; i < seconds; i++)
        {
            Console.Write($"\r{spinners[index]}");
            Thread.Sleep(250);
            index = (index + 1) % spinners.Length;
        }
    }
}

class BreathingActivity : Activity
{
    public BreathingActivity()
    {
        name = "Breathing";
        description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
    }

    public override void StartActivity(int duration)
    {
        Console.WriteLine($"Starting {name} Activity:");
        Console.WriteLine(description);
        Console.WriteLine($"Duration: {duration} seconds");
        ShowCountdown(3);

        while (duration > 0)
        {
            Console.WriteLine("Breathe in...");
            Thread.Sleep(1000);
            Console.WriteLine("Breathe out...");
            Thread.Sleep(1000);
            duration -= 2;
        }

        EndActivity(duration);
    }

    private void EndActivity(int duration)
    {
        Console.WriteLine("Great job!");
        Console.WriteLine($"You have completed {name} activity.");
        Console.WriteLine($"Duration: {duration} seconds");
        ShowCountdown(3);
    }
}

class ReflectionActivity : Activity
{
    private string[] prompts = {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private string[] questions = {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectionActivity()
    {
        name = "Reflection";
        description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
    }

    public override void StartActivity(int duration)
    {
        Console.WriteLine($"Starting {name} Activity:");
        Console.WriteLine(description);
        Console.WriteLine($"Duration: {duration} seconds");
        ShowCountdown(3);

        while (duration > 0)
        {
            string prompt = prompts[random.Next(prompts.Length)];
            Console.WriteLine(prompt);
            ShowCountdown(3);

            foreach (string question in questions)
            {
                Console.WriteLine(question);
                ShowSpinner(3);
            }

            duration--;
        }

        EndActivity(duration);
    }

    private void EndActivity(int duration)
    {
        Console.WriteLine("Great job!");
        Console.WriteLine($"You have completed {name} activity.");
        Console.WriteLine($"Duration: {duration} seconds");
        ShowCountdown(3);
    }
}

class ListingActivity : Activity
{
    private string[] prompts = {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
    {
        name = "Listing";
        description = "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
    }

    public override void StartActivity(int duration)
    {
        Console.WriteLine($"Starting {name} Activity:");
        Console.WriteLine(description);
        Console.WriteLine($"Duration: {duration} seconds");
        ShowCountdown(3);

        while (duration > 0)
        {
            string prompt = prompts[random.Next(prompts.Length)];
            Console.WriteLine(prompt);
            ShowCountdown(5);

            ListItems();
            duration--;
        }

        EndActivity(duration);
    }

    private void ListItems()
    {
        List<string> items = new List<string>();
        string item;
        do
        {
            Console.Write("Enter an item (or 'done' to finish listing): ");
            item = Console.ReadLine();
            if (item.ToLower() != "done")
                items.Add(item);
        } while (item.ToLower() != "done");

        Console.WriteLine($"Number of items listed: {items.Count}");
    }

    private void EndActivity(int duration)
    {
        Console.WriteLine("Great job!");
        Console.WriteLine($"You have completed {name} activity.");
        Console.WriteLine($"Duration: {duration} seconds");
        ShowCountdown(3);
    }
}
