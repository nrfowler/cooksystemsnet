using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace ConsoleApplication1
{
    class Program
    {
        static void writeHangman(int guesses)
        {




            string noose = "|            | ";
            string bar = "----------------";
            string head = "|            O ";
            string leftarm = "|          /  ";
            string chest = "|          / | ";
            string rightarm = "|          / | \\";
            string leftleg = "|           / ";
            string rightleg = "|           / \\";
            string empty = "|               ";
            if (guesses == 0)
            {
                Console.WriteLine(bar);
                Console.WriteLine(noose);
                Console.WriteLine(empty);
                Console.WriteLine(empty);
                Console.WriteLine(empty);

            }
            else if (guesses == 1)
            {
                Console.WriteLine(bar);
                Console.WriteLine(noose);
                Console.WriteLine(head);
                Console.WriteLine(empty);
                Console.WriteLine(empty);
            }
            else if (guesses == 2)
            {
                Console.WriteLine(bar);
                Console.WriteLine(noose);
                Console.WriteLine(head);
                Console.WriteLine(leftarm);
                Console.WriteLine(empty);
            }
            else if (guesses == 3)
            {
                Console.WriteLine(bar);
                Console.WriteLine(noose);
                Console.WriteLine(head);
                Console.WriteLine(chest);
                Console.WriteLine(empty);
            }
            else if (guesses == 4)
            {
                Console.WriteLine(bar);
                Console.WriteLine(noose);
                Console.WriteLine(head);
                Console.WriteLine(rightarm);
                Console.WriteLine(empty);
            }
            else if (guesses == 5)
            {
                Console.WriteLine(bar);
                Console.WriteLine(noose);
                Console.WriteLine(head);
                Console.WriteLine(rightarm);
                Console.WriteLine(leftleg);
            }
            else if (guesses == 6)
            {
                Console.WriteLine(bar);
                Console.WriteLine(noose);
                Console.WriteLine(head);
                Console.WriteLine(rightarm);
                Console.WriteLine(rightleg);
            }
        }

        static void Main(string[] args)
        {
            Random rand = new Random();
            string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Nathan\Desktop\CookSysNet\HangManWords.txt");
            if (lines.Length == 0)
            {
                Console.WriteLine("File is Empty");
                Console.ReadKey();
            }
            else
            {
                String continuePlay = "y";
                while (continuePlay.Equals("y")|| continuePlay.Equals("Y"))
                {
                    string word = lines[rand.Next(0, lines.Length)].ToLower();
                    string mask = Regex.Replace(word, @"\w", "*");
                    int WrongGuesses = 0;
                    ArrayList CorrectGuesses = new ArrayList();
                    ArrayList IncorrectGuesses = new ArrayList();
                    writeHangman(0);
                    Console.WriteLine("Guess the next letter");
                    while (WrongGuesses < 6 && !mask.Equals(word))
                    {
                        Console.WriteLine("Mask is {0}, enter your next guess", mask);
                        string letter = Console.ReadLine();
                        if (letter.Length == 0)
                            Console.WriteLine("Empty Input");
                        else if (IncorrectGuesses.Contains(letter))
                        {
                            Console.WriteLine("Already guessed this letter");
                        }
                        else
                        {

                            if (Regex.Match(word, letter).Success)
                            {
                                CorrectGuesses.Add(letter);
                                string regexstring = @"[^" + string.Join(" ", CorrectGuesses.ToArray()) + "]";
                                mask = Regex.Replace(word, regexstring, "*");
                                Console.WriteLine("That is correct. You may guess {0} more times", 6 - WrongGuesses);
                                CorrectGuesses.Add(letter);
                            }


                            else
                            {
                                WrongGuesses++;
                                IncorrectGuesses.Add(letter);
                                Console.WriteLine("That is incorrect. You may guess {0} more times", 6 - WrongGuesses);

                            }
                            if (IncorrectGuesses.Count > 0)
                                Console.WriteLine("Previous incorrect guesses were {0}", string.Join(" ", IncorrectGuesses.ToArray()));
                            writeHangman(WrongGuesses);

                        }

                    };
                    if (!mask.Equals(word))
                    {
                        Console.WriteLine("You have lost, would you like to play again?");
                        continuePlay = Console.ReadLine();

                    }
                    else
                    {
                        Console.WriteLine("Congratulations, you have correctly guessed the word {0}! Would you like to play again?", word);
                        continuePlay = Console.ReadLine();
                    }
                }
            }
        }
    }
}
