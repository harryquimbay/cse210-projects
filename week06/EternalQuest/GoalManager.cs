using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start()
    {
        int choice = 0;

        while (choice != 6)
        {
            Console.WriteLine();
            DisplayPlayerInfo();

            Console.WriteLine();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");

            choice = ReadInt("Select a choice from the menu: ", 1);

            switch (choice)
            {
                case 1:
                    CreateGoal();
                    break;

                case 2:
                    ListGoalDetails();
                    break;

                case 3:
                    SaveGoals();
                    break;

                case 4:
                    LoadGoals();
                    break;

                case 5:
                    RecordEvent();
                    break;

                case 6:
                    Console.WriteLine("Thanks for playing Eternal Quest!");
                    break;

                default:
                    Console.WriteLine("Invalid menu option.");
                    break;
            }
        }
    }

    private int ReadInt(string message, int minimum = 0)
    {
        while (true)
        {
            Console.Write(message);

            string input = Console.ReadLine();

            if (int.TryParse(input, out int value) && value >= minimum)
            {
                return value;
            }

            Console.WriteLine($"Please enter a number of at least {minimum}.");
        }
    }

    private string ReadText(string message)
    {
        while (true)
        {
            Console.Write(message);

            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input) &&
                !input.Contains("|") &&
                !input.Contains(":") &&
                !input.Contains("\n"))
            {
                return input.Trim();
            }

            Console.WriteLine("Enter valid text without | or : characters.");
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
        Console.WriteLine($"Level: {GetLevel()} - {GetLevelTitle()}");

        int pointsToNextLevel = 500 - (_score % 500);

        Console.WriteLine($"Points until next level: {pointsToNextLevel}");
    }

    // EXTRA FEATURE: Leveling system
    public int GetLevel()
    {
        return Math.Max(0, _score) / 500 + 1;
    }

    public string GetLevelTitle()
    {
        int level = GetLevel();

        if (level == 1)
        {
            return "Beginner";
        }
        else if (level == 2)
        {
            return "Adventurer";
        }
        else if (level == 3)
        {
            return "Champion";
        }
        else if (level == 4)
        {
            return "Hero";
        }
        else
        {
            return "Legend";
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine();
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");

        int type = ReadInt("Which type of goal would you like to create? ", 1);

        if (type < 1 || type > 3)
        {
            Console.WriteLine("Invalid goal type.");
            return;
        }

        string name = ReadText("What is the name of your goal? ");
        string description = ReadText("What is a short description of it? ");
        int points = ReadInt("What is the amount of points associated with this goal? ", 1);

        if (type == 1)
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == 2)
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else
        {
            int target = ReadInt("How many times does this goal need to be accomplished? ", 1);
            int bonus = ReadInt("What is the bonus for accomplishing it? ", 0);

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }

        Console.WriteLine("Your goal has been created!");
    }

    public void ListGoalDetails()
    {
        Console.WriteLine();
        Console.WriteLine("The goals are:");

        if (_goals.Count == 0)
        {
            Console.WriteLine("You have no goals yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("Create a goal first.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("The goals are:");

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }

        int number = ReadInt("Which goal did you accomplish? ", 1);

        if (number > _goals.Count)
        {
            Console.WriteLine("Invalid goal number.");
            return;
        }

        Goal goal = _goals[number - 1];

        if (goal.IsComplete())
        {
            Console.WriteLine("This goal is already complete.");
            return;
        }

        int previousLevel = GetLevel();

        goal.RecordEvent();

        int earnedPoints = goal.GetPointsEarned();

        _score += earnedPoints;

        Console.WriteLine($"Congratulations! You have earned {earnedPoints} points!");
        Console.WriteLine($"You now have {_score} points.");

        // EXTRA FEATURE: Celebrate leveling up
        if (GetLevel() > previousLevel)
        {
            Console.WriteLine();
            Console.WriteLine("********************************");
            Console.WriteLine("          LEVEL UP!             ");
            Console.WriteLine($"  Level {GetLevel()}: {GetLevelTitle()}");
            Console.WriteLine("********************************");
        }
    }

    public void SaveGoals()
    {
        string filename = ReadText("What is the filename for the goal file? ");

        try
        {
            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_score);

                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }

            Console.WriteLine("Goals saved successfully!");
        }
        catch (Exception error)
        {
            Console.WriteLine($"Unable to save: {error.Message}");
        }
    }

    public void LoadGoals()
    {
        string filename = ReadText("What is the filename for the goal file? ");

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        try
        {
            string[] lines = File.ReadAllLines(filename);

            if (lines.Length == 0)
            {
                Console.WriteLine("The file is empty.");
                return;
            }

            int loadedScore = int.Parse(lines[0]);
            List<Goal> loadedGoals = new List<Goal>();

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':', 2);

                if (parts.Length != 2)
                {
                    throw new FormatException("Invalid goal data.");
                }

                string type = parts[0];
                string[] data = parts[1].Split('|');

                if (type == "SimpleGoal" && data.Length == 4)
                {
                    loadedGoals.Add(new SimpleGoal(
                        data[0],
                        data[1],
                        int.Parse(data[2]),
                        bool.Parse(data[3])
                    ));
                }
                else if (type == "EternalGoal" && data.Length == 3)
                {
                    loadedGoals.Add(new EternalGoal(
                        data[0],
                        data[1],
                        int.Parse(data[2])
                    ));
                }
                else if (type == "ChecklistGoal" && data.Length == 6)
                {
                    loadedGoals.Add(new ChecklistGoal(
                        data[0],
                        data[1],
                        int.Parse(data[2]),
                        int.Parse(data[4]),
                        int.Parse(data[3]),
                        int.Parse(data[5])
                    ));
                }
                else
                {
                    throw new FormatException("Unknown goal type or invalid data.");
                }
            }

            _score = loadedScore;
            _goals = loadedGoals;

            Console.WriteLine("Goals loaded successfully!");
        }
        catch (Exception error)
        {
            Console.WriteLine($"Unable to load: {error.Message}");
        }
    }
}