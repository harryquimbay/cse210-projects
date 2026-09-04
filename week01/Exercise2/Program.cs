
// ask for the grade
Console.Write("What is your grade percentage? ");
string userInput = Console.ReadLine();
int grade = int.Parse(userInput);

//variable
string letter;


//Conditional to assign the grade in letters
if (grade >= 90)
{
    letter = "A";
}
else if (grade >= 80)
{
    letter = "B";
}
else if (grade >= 70)
{
    letter = "C";
}
else if (grade >= 60)
{
    letter = "D";
}
else
{
    letter = "F";
}
{
    Console.WriteLine($"Your grade is {letter}."); 
}

