
// Generate a random number
Random randomGenerator = new Random();
int magicNumber = randomGenerator.Next(1,101);

int guess = -1;


//Loop
while (guess != magicNumber)
{
    Console.Write("What is your guess? ");
    string userInput = Console.ReadLine();
    guess = int.Parse(userInput);

    if (guess < magicNumber)
    {
        Console.WriteLine("Higher");
    }
    else if (guess > magicNumber)
    {
        Console.WriteLine("Lower");
    }
    else
    {
        Console.WriteLine("You guess it! ");
    }
}

