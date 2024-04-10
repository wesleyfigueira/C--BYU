using System;

// Address class to store address details
public class Address
{
    public string Street { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string ZipCode { get; private set; }

    public Address(string street, string city, string state, string zipCode)
    {
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
    }

    public override string ToString()
    {
        return $"{Street}, {City}, {State} {ZipCode}";
    }
}

// Base Event class
public class Event
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public DateTime DateTime { get; private set; }
    public Address Address { get; private set; }

    public Event(string title, string description, DateTime dateTime, Address address)
    {
        Title = title;
        Description = description;
        DateTime = dateTime;
        Address = address;
    }

    public string GetStandardDetails()
    {
        return $"Event Title: {Title}\nDescription: {Description}\nDate: {DateTime.ToShortDateString()}\nTime: {DateTime.ToShortTimeString()}\nAddress: {Address}";
    }

    public virtual string GetFullDetails()
    {
        return GetStandardDetails();
    }

    public virtual string GetShortDescription()
    {
        return $"{GetType().Name}: {Title}, Date: {DateTime.ToShortDateString()}";
    }
}

// Lecture class derived from Event
public class Lecture : Event
{
    public string Speaker { get; private set; }
    public int Capacity { get; private set; }

    public Lecture(string title, string description, DateTime dateTime, Address address, string speaker, int capacity) : base(title, description, dateTime, address)
    {
        Speaker = speaker;
        Capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetStandardDetails()}\nType: Lecture\nSpeaker: {Speaker}\nCapacity: {Capacity}";
    }
}

// Reception class derived from Event
public class Reception : Event
{
    public string RsvpEmail { get; private set; }

    public Reception(string title, string description, DateTime dateTime, Address address, string rsvpEmail) : base(title, description, dateTime, address)
    {
        RsvpEmail = rsvpEmail;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetStandardDetails()}\nType: Reception\nRSVP Email: {RsvpEmail}";
    }
}

// OutdoorGathering class derived from Event
public class OutdoorGathering : Event
{
    public string WeatherForecast { get; private set; }

    public OutdoorGathering(string title, string description, DateTime dateTime, Address address, string weatherForecast) : base(title, description, dateTime, address)
    {
        WeatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return $"{base.GetStandardDetails()}\nType: Outdoor Gathering\nWeather Forecast: {WeatherForecast}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create address
        Address eventAddress = new Address("123 Main St", "Cityville", "State", "12345");

        // Create events
        Lecture lecture = new Lecture("Tech Talk", "Introduction to AI", DateTime.Now.AddDays(7), eventAddress, "John Doe", 50);
        Reception reception = new Reception("Networking Event", "Meet and Greet", DateTime.Now.AddDays(14), eventAddress, "rsvp@example.com");
        OutdoorGathering gathering = new OutdoorGathering("Picnic", "Family Fun Day", DateTime.Now.AddDays(21), eventAddress, "Sunny");

        // Generate and output marketing messages
        Console.WriteLine("Standard Details:");
        Console.WriteLine(lecture.GetStandardDetails());
        Console.WriteLine(reception.GetStandardDetails());
        Console.WriteLine(gathering.GetStandardDetails());

        Console.WriteLine("\nFull Details:");
        Console.WriteLine(lecture.GetFullDetails());
        Console.WriteLine(reception.GetFullDetails());
        Console.WriteLine(gathering.GetFullDetails());

        Console.WriteLine("\nShort Descriptions:");
        Console.WriteLine(lecture.GetShortDescription());
        Console.WriteLine(reception.GetShortDescription());
        Console.WriteLine(gathering.GetShortDescription());
    }
}

