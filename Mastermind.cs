using System;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] secretCode = GenerateSecretCode(); // generate the secret code of 4 digits between 1-6
            int attempts = 0;
            while (attempts < 10) // the player has 12 chances to guess the code
            {
                Console.Write("Enter your guess (4 digits between 1-6): ");
                int[] guess = GetGuess(); // get the guess from the player
                string score = GetScore(secretCode, guess); // get the score for the guess
                Console.WriteLine(score); // print the score
                if (score == "++++") // if the player has correctly guessed the code
                {
                    Console.WriteLine("You solved it!");
                    break; // end the game
                }
                attempts++;
            }
            if (attempts == 10) // if the player has used up all 12 chances
                Console.WriteLine("You lose :("); // player loses
        }

        static int[] GenerateSecretCode()
        {
            int[] secretCode = new int[4];
            Random rnd = new Random();
            for (int i = 0; i < 4; i++)
                secretCode[i] = rnd.Next(1, 7); // generate a random number between 1-6
            return secretCode;
        }

        static int[] GetGuess()
        {
            string input = Console.ReadLine(); // read the player's guess as a string
            int[] guess = new int[4];
            for (int i = 0; i < 4; i++)
                guess[i] = int.Parse(input[i].ToString()); // convert each character in the string to an integer
            return guess;
        }

        static string GetScore(int[] secretCode, int[] guess)
        {
            string score = "";
            int[] secretCodeCount = new int[7]; // array to store the frequency of each digit in the secret code
            int[] guessCount = new int[7]; // array to store the frequency of each digit in the guess

            for (int i = 0; i < 4; i++)
            {
                if (secretCode[i] == guess[i]) // if the digit in the same position is correct
                {
                    score += "+"; // add a '+' to the score
                }
                else
                {
                    secretCodeCount[secretCode[i]]++; // increment the frequency of the digit in the secret code
                    guessCount[guess[i]]++; // increment the frequency of the digit in the guess
                }
            }

            for (int i = 1; i <= 6; i++)
            {
                int common = Math.Min(secretCodeCount[i], guessCount[i]); // get the minimum frequency of the digit in both secret code and guess
                for (int j = 0; j < common; j++)
                {
                    score += "-"; // add a '-' to the score for each common digit
                }
            }

            return score;
        }
    }
}