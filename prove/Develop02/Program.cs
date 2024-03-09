//i saved other additional information in the journal entry
using System;
using System.Collections.Generic;
using System.IO;

//Define the entry class to store each journal entry
class Entry
{
    public string Prompt {get;set;}
    public string Response {get;set;}
    public string Date {get;set;}
}

//define the journal program class
class JournalProgram
{
    private List<Entry> journalEntries = new List<Entry> ();
    private List<string> prompts = new List<string>
    {
        "Who was the most interesting person interacted with today?",
        "What was the best part of my day?",
        "How did i see the hand of the Lord in my life today?",
        "If i could do one thing over today, what would it be?",
        "What was stopping you from writing in your journal today?",
        "What distractiuons did you overcome and how can you continue to adhere to the promptings of the holy ghost?"
    };


    //method to write a new entry

    void WriteNewEntry()
    {
        Random rand = new Random();
        Entry newEntry = new Entry();
        newEntry.Date = DateTime.Now.ToShortDateString();
        newEntry.Prompt =  prompts[rand.Next(prompts.Count)];
        Console.WriteLine("Prompt: " + newEntry.Prompt);
        Console.Write("Your response:");
        newEntry.Response = Console.ReadLine();
        journalEntries.Add(newEntry);
    }


    //Method to display the journal
    void DisplayJournal()
    {
        foreach(var entry in journalEntries)
        {
            Console.WriteLine("Date:" + entry.Date);
            Console.WriteLine("Prompt:" + entry.Prompt);
            Console.WriteLine("Response:" + entry.Response);

            Console.WriteLine();
        }
    }

    //method to save the journal to a file
    void SaveJournal()
    {
        Console.Write("Enter the filename to save the journal: ");
        string filename = Console.ReadLine();
        using (StreamWriter file = new StreamWriter(filename))
        {
            foreach(var entry in journalEntries)
            {
                file.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
                file.WriteLine("Your file will be saved with these information");
            }
        }
    }
    //method to load the journal from a file
    void LoadJournal()
    {
        Console.Write("Enter the filename to load the journal:");
        string filename = Console.ReadLine();
        if (File.Exists(filename))
        {
            journalEntries.Clear();
            string[] lines = File.ReadAllLines(filename);
            foreach (var line in lines)
            {
                string[] parts = line.Split("|");
                Entry loadedEntry = new Entry
                {
                    Date = parts[0],
                    Prompt = parts[1],
                    Response = parts[2]
                };

                journalEntries.Add(loadedEntry);
            }
            Console.WriteLine("Journal loaded successfully.");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
    //Main menu method
    void MainMenu()
    {
        Console.Write("What would you like to do select a number below?");
        while(true)
        {
            Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file.");
            Console.WriteLine("4. Load the journal from a file.");
            Console.WriteLine("5. Exit");
       
            int choice = Convert.ToInt32(Console.ReadLine());
        
            switch (choice)
            {
                
                case 1: WriteNewEntry();
                break;
                case 2: DisplayJournal();
                break;
                case 3: SaveJournal();
                break;
                case 4: LoadJournal();
                break;
                case 5: Environment.Exit(0);
                break;

                default: Console.WriteLine("Invalid choice. Please try again.");
                break;
            }
        }
    }
    //main method to start the program
    static void Main(string[] args)
    {
        JournalProgram journal = new JournalProgram();
        journal.MainMenu();
    }
}