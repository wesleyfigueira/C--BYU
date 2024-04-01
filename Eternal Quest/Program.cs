using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

// Base class for all types of goals
[Serializable]
abstract class Goal
{
    protected string name;
    protected int points;

    public Goal(string name, int points)
    {
        this.name = name;
        this.points = points;
    }

    // Abstract method to display the goal
    public abstract void Display();

    // Method to record the completion of the goal and return points
    public virtual int RecordCompletion()
    {
        return points;
    }
}

// Class for simple goals
[Serializable]
class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points) : base(name, points)
    {
    }

    public override void Display()
    {
        Console.WriteLine($"Simple Goal: {name}");
    }
}

// Class for eternal goals
[Serializable]
class EternalGoal : Goal
{
    public EternalGoal(string name, int points) : base(name, points)
    {
    }

    public override void Display()
    {
        Console.WriteLine($"Eternal Goal: {name}");
    }
}

// Class for checklist goals
[Serializable]
class ChecklistGoal : Goal
{
    private int requiredTimes;
    private int completedTimes;

    public ChecklistGoal(string name, int points, int requiredTimes) : base(name, points)
    {
        this.requiredTimes = requiredTimes;
        completedTimes = 0;
    }

    public override void Display()
    {
        Console.WriteLine($"Checklist Goal: {name} - Completed {completedTimes}/{requiredTimes} times");
    }

    // Record completion of the goal
    public override int RecordCompletion()
    {
        if (completedTimes < requiredTimes)
        {
            completedTimes++;
            if (completedTimes == requiredTimes)
            {
                // Bonus points when the goal is completed
                return base.RecordCompletion() * requiredTimes;
            }
            else
            {
                return base.RecordCompletion();
            }
        }
        else
        {
            return 0; // Return 0 points if already completed required times
        }
    }
}

// Class to manage goals and score
[Serializable]
class GoalManager
{
    private List<Goal> goals;
    private int score;

    public GoalManager()
    {
        goals = new List<Goal>();
        score = 0;
    }

    public void AddGoal(Goal goal)
    {
        goals.Add(goal);
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Current Goals:");
        foreach (Goal goal in goals)
        {
            goal.Display();
        }
    }

    public void RecordCompletion(int index)
    {
        if (index >= 0 && index < goals.Count)
        {
            score += goals[index].RecordCompletion();
            Console.WriteLine($"Goal '{goals[index].name}' completed. You gained {goals[index].points} points.");
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine($"Your current score: {score} points");
    }

    // Save goals and score to a file
    public void SaveProgress(string fileName)
    {
        try
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, this);
                Console.WriteLine("Progress saved successfully.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving progress: {ex.Message}");
        }
    }

    // Load goals and score from a file
    public static GoalManager LoadProgress(string fileName)
    {
        try
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                return (GoalManager)formatter.Deserialize(fs);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading progress: {ex.Message}");
            return new GoalManager();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();

        // Example goals
        goalManager.AddGoal(new SimpleGoal("Run a marathon", 1000));
        goalManager.AddGoal(new EternalGoal("Read scriptures", 100));
        goalManager.AddGoal(new ChecklistGoal("Attend the temple", 50, 10));

        // Display goals
        goalManager.DisplayGoals();

        // Record completion of goals
        goalManager.RecordCompletion(0); // Complete simple goal
        goalManager.RecordCompletion(1); // Record eternal goal
        goalManager.RecordCompletion(2); // Record checklist goal
        goalManager.RecordCompletion(2); // Record checklist goal again

        // Display score
        goalManager.DisplayScore();

        // Save progress
        goalManager.SaveProgress("progress.dat");

        // Load progress
        GoalManager loadedProgress = GoalManager.LoadProgress("progress.dat");
        loadedProgress.DisplayGoals();
        loadedProgress.DisplayScore();
    }
}
