//for the additional requirements, i added another kind od activity
//that tests the selected activity by the user duration 

using System;
using System.Threading;


class Activity
{
    public string Description {get; set;}
    public int Duration {get; set;}

    public Activity(string description)
    {
        Description = description;
    }

    public virtual void Start()
    {
        Console.WriteLine($"Activity: {Description}");
        Console.WriteLine($"Duration: {Duration} seconds");

        Console.WriteLine("Prepare to begin....");
        Thread.Sleep(3000);
    }

    public virtual void End()
    {
        Console.WriteLine("Good job! you have completed the activity.");
        Console.WriteLine($"Duration: {Duration} seconds");
        Thread.Sleep(3000);
    }
}

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity - Relax and focus on your breathing")
    {
    }

    public override void Start()
    {
        base.Start();
        Console.WriteLine("Breath in....");
        Thread.Sleep(2000);
        Console.WriteLine("Breath out....");
        Thread.Sleep(2000);
    }

    public override void End()
    {
        base.End();
    }
}

class ReflectionActivity : Activity
{
    private string[] prompts = {"Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need,", "Think of a time when you did something truly selfless."};

    private string[] questions = {"Why was this experience meaningful to you?", "Have you ever done anything like this before?", "How did you get started?", "How did you feel when it was complete?", "What made this time different from other times when you were not as successfull?", "What is your favorite thing about this experience?", "What could you learn from this experience that applies to other situations?", "What did you learn about yourself through this experience?", "How can you keep this experience in mind in the future?"};

    public ReflectionActivity() : base("Reflection Activity - Reflect on past experiences")
    {
    }

    public override void Start()
    {
        base.Start();
        Random random = new Random();
        int index = random.Next(prompts.Length);
        Console.WriteLine($"Prompt: {prompts[index]}");

        foreach(string question in questions)
        {
            Console.WriteLine(question);
            Thread.Sleep(3000);
            //pause for several seconds

            //display spinner animation

            Console.WriteLine("Processing....");
            //placeholder for spinner animation

            Thread.Sleep(2000);//Simulate spinner animation
        }
        base.End();

    }
}


class ListingActivity : Activity
{
    private string[] prompts = {"Who are people that you appreciate?", "What are personal strengths of yours?", "What are people that you have helped this week?", "When have you felt the Holy Ghost this month?", "Who are some of your personal heroes?"};

    public ListingActivity() : base("Listing Activity - List positive aspects in your life")
    {
    }

    public override void Start()
    {
        base.Start();
        Random random = new Random();

        int index = random.Next(prompts.Length);
        Console.WriteLine($"Prompts :{prompts[index]}");

        //countdown for user tot think about prompt

        Console.WriteLine("Please take a few moments to list as many items as you can.");
        Console.WriteLine("When you are ready, start listing....");


        //simulating the user listing items for the specified duration

        for(int i = 1; i <= Duration; i++)
        {
            Console.WriteLine($"Item{i}");
            Thread.Sleep(1000);//simulate user listing items everyn 1 second
        }

        Console.WriteLine($"Total items listed: {Duration}");

        base.End();
    }
}

class Program
{
    static void Main(string[] args)
    {

        Activity selectedActivity = null;

        while(selectedActivity == null)
        {
            Console.WriteLine("Choose an activity:");
            Console.WriteLine("1.Breathing Activity");
            Console.WriteLine("2.Reflection Activity");
            Console.WriteLine("3. Listing Activity");

            string userinput = Console.ReadLine();

            switch (userinput)
            {
                case "1": 
                selectedActivity = new BreathingActivity();
                break;
                case "2":
                selectedActivity = new ReflectionActivity();
                break;
                case "3":
                selectedActivity = new ListingActivity();
                break;

                default: Console.WriteLine("Invalid selection. Please try again.");
                break;
            }
        }

        Console.WriteLine("\n-------------------------------------------------------------\n");
       
        selectedActivity.Duration = 5;
        //for testing purposes
        selectedActivity.Start();


        Console.WriteLine("\n-------------------------------------------------------------\n");

        selectedActivity.End();

        Console.ReadLine();
    }
}