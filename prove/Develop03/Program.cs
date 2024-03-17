//for exceeding requirements, i allowed the user to guess
//the hidden word in the scripture text.

using System;
using System.Collections.Generic;


class Program
{
    static void Main()
    {
        var scripture = new Scripture("John 3:16","For God so loved the world that He gave His one and only begotten son, that whoever believes in Him shall not perish but have eternal Life.");

        
        while (!scripture.IsHiddenCompletely)
        {
            Console.Clear();
            scripture.Display();
            
            Console.WriteLine("Press enter to continure or type 'quit' to exit or guess a word:");

            string input = Console.ReadLine();


            if (string.IsNullOrEmpty(input)|| input.ToLower() == "quit")
            {
                break;
            }

            if (scripture.CheckWord(input))
            {
                Console.WriteLine("Correct guess! Press enter to continue.");
            }
            else
            {
                Console.WriteLine("Incorrect guess. press Enter to continue.");
            }
            Console.ReadLine();
             
            scripture.HideRandomWords();
        }

    }
}

class Scripture
{
    private string reference;
    private string text;
    private List<string> hiddenWords;



    public bool IsHiddenCompletely => hiddenWords.Count == text.Split(' ').Length;

    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.text = text;
        hiddenWords = new List<string>(); 
    }
    public void Display()
    {
        Console.WriteLine($"{reference}\n");

        foreach (var word in text.Split(' '))
        {
            if (hiddenWords.Contains(word))
            {
                Console.Write("_____");
            }
            else
            {
                Console.Write(word + " ");
            }
        }
        Console.WriteLine();
    }

    public void HideRandomWords()
    {
        Random rnd = new Random();

        string[] words = text.Split(' ');

        int wordToHide = rnd.Next(words.Length);

        hiddenWords.Add(words[wordToHide]);
    }
    
    public bool CheckWord(string guess)
    {
        return hiddenWords.Contains(guess);
    }
}
    