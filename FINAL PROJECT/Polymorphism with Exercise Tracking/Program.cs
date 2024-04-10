using System;
using System.Collections.Generic;

// Base Activity class
public class Activity
{
    private DateTime date;
    private int durationMinutes;

    public Activity(DateTime date, int durationMinutes)
    {
        this.date = date;
        this.durationMinutes = durationMinutes;
    }

    public virtual double GetDistance()
    {
        return 0; // Base class doesn't have distance
    }

    public virtual double GetSpeed()
    {
        return 0; // Base class doesn't have speed
    }

    public virtual double GetPace()
    {
        return 0; // Base class doesn't have pace
    }

    public virtual string GetSummary()
    {
        return $"{date.ToShortDateString()} - Duration: {durationMinutes} min";
    }
}

// Running class derived from Activity
public class Running : Activity
{
    private double distance; // in miles

    public Running(DateTime date, int durationMinutes, double distance) : base(date, durationMinutes)
    {
        this.distance = distance;
    }

    public override double GetDistance()
    {
        return distance;
    }

    public override double GetSpeed()
    {
        return distance / (base.GetDurationHours()) ;
    }

    public override double GetPace()
    {
        return 1 / GetSpeed() * 60;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} Running - Distance: {distance} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min/mile";
    }
}

// Cycling class derived from Activity
public class Cycling : Activity
{
    private double speed; // in mph

    public Cycling(DateTime date, int durationMinutes, double speed) : base(date, durationMinutes)
    {
        this.speed = speed;
    }

    public override double GetSpeed()
    {
        return speed;
    }

    public override double GetDistance()
    {
        return speed * (base.GetDurationHours());
    }

    public override double GetPace()
    {
        return 60 / speed;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} Cycling - Speed: {speed} mph, Distance: {GetDistance()} miles, Pace: {GetPace()} min/mile";
    }
}

// Swimming class derived from Activity
public class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int durationMinutes, int laps) : base(date, durationMinutes)
    {
        this.laps = laps;
    }

    public override double GetDistance()
    {
        return laps * 50 / 1000 * 0.62; // Distance in miles
    }

    public override double GetSpeed()
    {
        return GetDistance() / (base.GetDurationHours());
    }

    public override double GetPace()
    {
        return 1 / GetSpeed() * 60;
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()} Swimming - Laps: {laps}, Distance: {GetDistance()} miles, Speed: {GetSpeed()} mph, Pace: {GetPace()} min/mile";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create list to store activities
        List<Activity> activities = new List<Activity>();

        // Create sample activities
        Activity running = new Running(new DateTime(2022, 11, 3), 30, 3.0);
        Activity cycling = new Cycling(new DateTime(2022, 11, 3), 30, 12.0);
        Activity swimming = new Swimming(new DateTime(2022, 11, 3), 30, 10);

        // Add activities to the list
        activities.Add(running);
        activities.Add(cycling);
        activities.Add(swimming);

        // Display summary for each activity
        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}

