using System;
using Twitter.MongoDB.Core.Entities;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Collections.Generic;

namespace Twitter.MongoDB.Infra.Data
{
    public class TwitterContextSeed
    {
        public static void SeedData(IMongoDatabase database)
        {
            Console.WriteLine($"SeedData");

            InsertUsers(database.GetCollection<User>(nameof(User)));
            InsertFollowers(database.GetCollection<Following>(nameof(Following)));
            InsertTweets(database.GetCollection<Tweet>(nameof(Tweet)));
        }

        private static void InsertUsers(IMongoCollection<User> userCollection)
        {
            Console.WriteLine($"InsertUsers");
            // db.User.insert({Id:"605fbfdda571444fd7ade05b",UserName: "rsjudge17", Password: "P455w0rd", Fullname: "Ruel Sison", Email: "rsjudge17@gmail.com"})
            // db.User.insert({ Id: "605fbfecdefb479679f08517",UserName: "sebliam", Password: "P455w0rd", Fullname: "Liam Sebastian Sison", Email: "sebliam@gmail.com"})
            userCollection.DeleteMany(_ => true);
            userCollection.InsertMany(
                new List<User>
                {
                    new User
                    {
                        Id = "605fbfdda571444fd7ade05b",
                        UserName = "rsjudge17",
                        Password = "P455w0rd",
                        Fullname = "Ruel Sison",
                        AvatarURL = "https://pbs.twimg.com/profile_images/1252238395/image_normal.jpg",
                        Email = "rsjudge17@gmail.com"
                    },
                    new User
                    {
                        Id = "605fbfecdefb479679f08517",
                        UserName = "sebliam",
                        Password = "P455w0rd",
                        Fullname = "Liam Sebastian Sison",
                        AvatarURL = "https://i.pinimg.com/originals/a6/58/32/a65832155622ac173337874f02b218fb.png",
                        Email = "sebliam@gmail.com"
                    }
                }); ;
        }

        private static void InsertFollowers(IMongoCollection<Following> followingCollection)
        {
            Console.WriteLine($"InsertFollowers");
            followingCollection.DeleteMany(_ => true);
            followingCollection.InsertMany(
                new List<Following>
                {
                    new Following
                    {
                        Id = ObjectId.GenerateNewId().ToString(),
                        UserId = "605fbfdda571444fd7ade05b",
                        FollowingUserId = "605fbfecdefb479679f08517",
                        Followed = DateTime.Now
                    },
                    new Following
                    {
                        Id = ObjectId.GenerateNewId().ToString(),
                        UserId = "605fbfecdefb479679f08517",
                        FollowingUserId = "605fbfdda571444fd7ade05b",
                        Followed = DateTime.Now
                    }
                }); ;
        }

        private static void InsertTweets(IMongoCollection<Tweet> tweetCollection)
        {
            Console.WriteLine($"InsertTweets");
            tweetCollection.DeleteMany(_ => true);
            tweetCollection.InsertMany(
                new List<Tweet>
                {
                    new Tweet
                    {
                        Id = ObjectId.GenerateNewId().ToString(),
                        TweetId = 1,
                        UserName = "sebliam",
                        Message = "It appears to be a slow #robotics news day.\nShow us what you're working on! Working on a new robot? We want to see it!",
                        //Message = "It appears to be a slow #robotics news day.",
                        ImageURL = "https://www.focus2move.com/wp-content/uploads/2020/01/Tesla-Roadster-2020-1024-03.jpg",
                        TotalReplies = 0,
                        TotalRetweets = 1,
                        TotalLikes = 100,
                        TotalShares = 1000,
                        Created = DateTime.Now
                    },
                    new Tweet
                    {
                        Id = ObjectId.GenerateNewId().ToString(),
                        TweetId = 2,
                        UserName = "rsjudge17",
                        Message = "What interview questions would you ask a C++ programmer \nwith 2-3 years experience?",
                        //Message = "What interview questions would you ask a C++ programmer with 2-3 years experience?",
                        ImageURL = "images/post-image-1.jpeg",
                        TotalReplies = 0,
                        TotalRetweets = 2,
                        TotalLikes = 200,
                        TotalShares = 2000,
                        Created = DateTime.Now
                    },
                    new Tweet
                    {
                        Id = ObjectId.GenerateNewId().ToString(),
                        TweetId = 3,
                        UserName = "rsjudge17",
                        Message = "It appears to be a slow #robotics news day.\nShow us what you're working on! Working on a new robot? We want to see it!",
                        //Message = "It appears to be a slow #robotics news day.",
                        ImageURL = "https://www.focus2move.com/wp-content/uploads/2020/01/Tesla-Roadster-2020-1024-03.jpg",
                        TotalReplies = 0,
                        TotalRetweets = 1,
                        TotalLikes = 100,
                        TotalShares = 1000,
                        Created = DateTime.Now
                    },
                });
        }
    }
}
