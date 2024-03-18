//for exceeding requirements, i allowed the user to guess
//the hidden word in the scripture text.

using System;
using System.Collections.Generic;
using System.Linq;


class Program
{
    static void Main()
    {
        Scripture scripture = new Scripture("John 3:16", "For God So loved the world that He gave his one and only Son, that whosoever believes in Him shall not perish but have eternal life.");

        Console.Clear();
        scripture.DisplayScripture();

        while(true)
        {
            Console.WriteLine("Press Enter to continue or type 'quit' to exit:");

            string userinput = Console.ReadLine();

            if (userinput.ToLower() == "quit")
            {
                break;
            }
            else
            {
                
                Console.Clear();
                scripture.HideWord();
                scripture.DisplayScripture();

                if (scripture.AllWordsHidden())
                {
                    Console.WriteLine("Congratulations! you have memeorized scripture.");
                    
                    break;
                }

            }
        }
    }
}

class Scripture
{
    private string reference;
    private string text;
    private List<string> hiddenWords;


    public Scripture(string reference, string text)
    {
        this.reference = reference;
        this.text = text;
        this.hiddenWords = new List<string>();
    }

    public void DisplayScripture()
    {
        Console.WriteLine(reference);
        string[] words = text.Split(' ');
        foreach (string word in words)
        {
            if (hiddenWords.Contains(word))
            {
                Console.Write("_______ ");
            }
            else
            {
                Console.Write(word + " ");
            }
        }
        Console.WriteLine();
    }

    public void HideWord()
    {
        string[] words = text.Split(' ');
        Random rand = new Random();

        int index = rand.Next(words.Length);
        string wordToHide = words[index];

        hiddenWords.Add(wordToHide);
    }
    public bool AllWordsHidden()
    {
        string[] words = text.Split(' ');
        return hiddenWords.Count == words.Length;
    }
}

