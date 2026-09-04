using System.Collections.Generic;

Console.WriteLine("Enter a list of numbers, type 0 when finished.");

List<int> numbers = new List<int>();

int number = -1;

while (number != 0)
{
    Console.Write("Enter number: ");
    string userInput = Console.ReadLine();
    number = int.Parse(userInput);

    if (number != 0)
    {
        numbers.Add(number);
    }
}

// sum
int sum = 0;

foreach (int value in numbers)
{
    sum += value;
}

// average
double average = (double)sum / numbers.Count;

//largest number
int largest = numbers[0];

foreach (int value in numbers)
{
    if (value > largest)
    {
        largest = value;
    }
}

// Show results
Console.WriteLine($"The sum is: {sum}");
Console.WriteLine($"The average is: {average}");
Console.WriteLine($"The largest number is: {largest}");