using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("What is the magic number?");
            int magicNumber = Convert.ToInt32(Console.ReadLine());
            
            int numberOfGuesses = 0;

            while (true)
            {
                Console.WriteLine("What is your guess?");
                int userGuess = Convert.ToInt32(Console.ReadLine());

                if (userGuess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (userGuess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    break; // Exit the inner loop when the guess is correct
                }

                numberOfGuesses++;
            }

            Console.WriteLine($"You guessed it in {numberOfGuesses} guesses!");

            Console.WriteLine("Do you want to play again? (yes/no)");
            string playAgain = Console.ReadLine();

            if (playAgain.ToLower() != "yes")
            {
                break; // Exit the outer loop if the user doesn't want to play again
            }
        }
    }
}
