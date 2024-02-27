
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your percentage grade?");
        string userInput = Console.ReadLine();
        int grades = int.Parse(userInput);

        if (grades >= 90)
        {
            Console.WriteLine("Your grade is A");
        }
        else if (grades >= 80)
        {
            Console.WriteLine("Your grade is B");
        }
        else if (grades >= 70)
        {
            Console.WriteLine("Your grade is C");
        }
        else if (grades >= 60)
        {
            Console.WriteLine("Your grade is D");
        }
        else if (grades == 60)
        {
            Console.WriteLine("Your grade is F");
        }
        else
        {
            Console.WriteLine("Please man, get real, if your grade is less than 60, you should be studying");
        }
    }
}