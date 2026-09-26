using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // 1st video.
        Video video1 = new Video(
            "Japan Travel Guide: Flights, Hotels and Budget",
            "Japan Travel Tips",
            720
        );

        video1._comments.Add(new Comment(
            "Harry",
            "How much should I budget for a two-week trip to Japan?"
        ));

        video1._comments.Add(new Comment(
            "Andres",
            "The hotel recommendations were very helpful."
        ));

        video1._comments.Add(new Comment(
            "Karen",
            "I would love to visit Japan next year."
        ));


        // 2nd video.
        Video video2 = new Video(
            "Tokyo Travel Itinerary",
            "Explore Japan",
            650
        );

        video2._comments.Add(new Comment(
            "Carlos",
            "How many days do you recommend staying in Tokyo?"
        ));

        video2._comments.Add(new Comment(
            "Nahomy",
            "I really want to visit Shibuya and Shinjuku."
        ));

        video2._comments.Add(new Comment(
            "Robert",
            "This itinerary is perfect for my first trip to Japan."
        ));


        // 3rd video.
        Video video3 = new Video(
            "Osaka and Kyoto Travel Itinerary",
            "Japan Adventures",
            840
        );

        video3._comments.Add(new Comment(
            "Dory",
            "Kyoto looks amazing. I would love to visit the temples."
        ));

        video3._comments.Add(new Comment(
            "Miguel",
            "How many days should I spend in Osaka and Kyoto?"
        ));

        video3._comments.Add(new Comment(
            "Sofia",
            "The transportation tips between Osaka and Kyoto are very useful."
        ));


        // 4th video.
        Video video4 = new Video(
            "Japan Food and Visa Guide for Latin American Travelers",
            "Travel Japan Latino",
            780
        );

        video4._comments.Add(new Comment(
            "Lina",
            "I would love to try authentic Japanese food."
        ));

        video4._comments.Add(new Comment(
            "Maria",
            "The travel information for Latin American visitors was very helpful."
        ));

        video4._comments.Add(new Comment(
            "Yuly",
            "Could you make another video about travel requirements for Colombians?"
        ));


        // Store all videos in a list
        List<Video> videos = new List<Video>
        {
            video1,
            video2,
            video3,
            video4
        };


        // Display all videos and their comments
        foreach (Video video in videos)
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Title: {video._title}");
            Console.WriteLine($"Author: {video._author}");
            Console.WriteLine($"Length: {video._length} seconds");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            Console.WriteLine("Comments:");

            foreach (Comment comment in video._comments)
            {
                Console.WriteLine($"  {comment._commenterName}: {comment._text}");
            }

            Console.WriteLine();
        }
    }
}