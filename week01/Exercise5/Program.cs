
//Welcome sms
static void DisplayWelcome()
{
    Console.WriteLine("Welcome to the Program!");
}


//Ask Name
static string PromptUserName()
{
    Console.Write("Please enter your name: ");
    string name = Console.ReadLine();
    return name;
}


//Ask fav number
static int PromptUserNumber()
{
    Console.Write("Please enter your favorite number: ");
    string userInput = Console.ReadLine();
    int number = int.Parse(userInput);
    return number;
}



//Square of the #
static int SquareNumber(int number)
{
    int square = number * number;
    return square;
}


//Show result
static void DisplayResult(string name, int square)
{
    Console.WriteLine($"{name}, the square of your number is {square}");
}


//Function to save result
DisplayWelcome();

string userName = PromptUserName();
int userNumber = PromptUserNumber();
int squaredNumber = SquareNumber(userNumber);

DisplayResult(userName, squaredNumber);