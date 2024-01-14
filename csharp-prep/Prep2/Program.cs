using System;

class Program
{
    static void Main()
    {
        // Core Requirement 1: Ask the user for their grade percentage
        Console.Write("Enter your grade percentage: ");
        double percentage = Convert.ToDouble(Console.ReadLine());

        string letter;
        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Core Requirement 3: Check if the user passed and display messages
        if (percentage >= 70)
        {
            Console.WriteLine($"Congratulations! You passed with a {letter}.");
        }
        else
        {
            Console.WriteLine($"You didn't pass this time. Keep working hard for the next attempt!");
        }

        // Core Requirement 4: Print the letter grade at the end
        Console.WriteLine($"Your letter grade is: {letter}");
    }
}
