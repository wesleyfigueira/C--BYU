using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create videos
        Video video1 = new Video("Title 1", "Author 1", 300);
        Video video2 = new Video("Title 2", "Author 2", 400);
        Video video3 = new Video("Title 3", "Author 3", 500);

        // Add comments to videos
        video1.AddComment("User 1", "Comment 1 for video 1");
        video1.AddComment("User 2", "Comment 2 for video 1");
        video2.AddComment("User 3", "Comment 1 for video 2");
        video2.AddComment("User 4", "Comment 2 for video 2");
        video3.AddComment("User 5", "Comment 1 for video 3");
        video3.AddComment("User 6", "Comment 2 for video 3");

        // Create a list to hold the videos
        List<Video> videos = new List<Video> { video1, video2, video3 };

        // Display information for each video
        foreach (var video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            // Display comments for the video
            foreach (var comment in video.Comments)
            {
                Console.WriteLine($"Comment by {comment.Name}: {comment.Text}");
            }

            Console.WriteLine();
        }
    }
}

class Video
{
    public string Title { get; private set; }
    public string Author { get; private set; }
    public int Length { get; private set; }
    public List<Comment> Comments { get; private set; }

    public Video(string title, string author, int length)
    {
        Title = title;
        Author = author;
        Length = length;
        Comments = new List<Comment>();
    }

    public void AddComment(string name, string text)
    {
        Comments.Add(new Comment(name, text));
    }

    public int GetNumberOfComments()
    {
        return Comments.Count;
    }
}

class Comment
{
    public string Name { get; private set; }
    public string Text { get; private set; }

    public Comment(string name, string text)
    {
        Name = name;
        Text = text;
    }
}

