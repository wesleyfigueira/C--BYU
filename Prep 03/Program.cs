//prep 03 guess
using System;

class Program
{
    static void Main(string[] args)
    {
        int magicNumber;
        int guessNumber;


            Console.WriteLine("What is the magic Number ?");
            string userInput = Console.ReadLine();
            magicNumber = int.Parse(userInput);

        do
        {
            Console.WriteLine("What is your guess ?");
            string userInput2 = Console.ReadLine();
            guessNumber = int.Parse(userInput2);

            if (magicNumber < guessNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (magicNumber > guessNumber)
            {
                Console.WriteLine("Lower");
            }

        } while (magicNumber != guessNumber);

        Console.WriteLine("Congratulations! You guessed the magic number!");
    }
}