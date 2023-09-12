using System;
using System.Collections.Generic;
using AdminNamespace;
using UserNamespace;
using PostNamespace;

namespace ProgramNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User
            {
                UserId = 1,
                UserName = "user123",
                UserEmail = "user@example.com",
                Password = "userpassword"
            };

            Admin admin = new Admin
            {
                id = "admin1",
                username = "admin123",
                email = "admin@example.com",
                password = "adminpassword"
            };

            List<Post> posts = new List<Post>
            {
                new Post
                {
                    Id = 1,
                    Content = "This is the first post.",
                    CreationDateTime = DateTime.Now,
                    LikeCount = 0,
                    ViewCount = 0
                },
                new Post
                {
                    Id = 2,
                    Content = "This is the second post.",
                    CreationDateTime = DateTime.Now,
                    LikeCount = 0,
                    ViewCount = 0
                }
            };

            Console.WriteLine("Welcome to the User-Admin System");
            Console.Write("Are you a User or Admin? (user/admin): ");
            string userType = Console.ReadLine();

            if (userType.ToLower() == "user")
            {
                Console.Write("Enter your username or email: ");
                string inputUsernameOrEmail = Console.ReadLine();
                Console.Write("Enter your password: ");
                string inputPassword = Console.ReadLine();

                if ((inputUsernameOrEmail == user.UserName || inputUsernameOrEmail == user.UserEmail) &&
                    inputPassword == user.Password)
                {
                    Console.WriteLine("Login successful as User.");
                }
                else
                {
                    Console.WriteLine("Login failed. Invalid credentials.");
                }
            }
            else if (userType.ToLower() == "admin")
            {
                Console.Write("Enter your username or email: ");
                string inputUsernameOrEmail = Console.ReadLine();
                Console.Write("Enter your password: ");
                string inputPassword = Console.ReadLine();

                if ((inputUsernameOrEmail == admin.username || inputUsernameOrEmail == admin.email) &&
                    inputPassword == admin.password)
                {
                    Console.WriteLine("Login successful as Admin.");
                }
                else
                {
                    Console.WriteLine("Login failed. Invalid credentials.");
                }
            }
            else
            {
                Console.WriteLine("Invalid user type.");
            }
            if (userType.ToLower() == "user")
            {
                Console.WriteLine("User actions:");
                Console.WriteLine("1. View Post");
                Console.WriteLine("2. Like Post");

                int userChoice;
                if (int.TryParse(Console.ReadLine(), out userChoice))
                {
                    switch (userChoice)
                    {
                        case 1:
                            Console.Write("Enter the ID of the post you want to view: ");
                            if (int.TryParse(Console.ReadLine(), out int postId))
                            {
                                Post postToView = posts.Find(p => p.Id == postId);
                                if (postToView != null)
                                {
                                    postToView.ViewCount++;
                                    Console.WriteLine("Post Content: " + postToView.Content);
                                    Console.WriteLine("View Count: " + postToView.ViewCount);

                                    admin.Notifications.Add(new Notification("Post Viewed", $"User {user.UserName} viewed post {postId}"));
                                }
                                else
                                {
                                    Console.WriteLine("Post not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input for post ID.");
                            }
                            break;

                        case 2:
                            Console.Write("Enter the ID of the post you want to like: ");
                            if (int.TryParse(Console.ReadLine(), out int likePostId))
                            {
                                Post postToLike = posts.Find(p => p.Id == likePostId);
                                if (postToLike != null)
                                {
                                    postToLike.LikeCount++;
                                    Console.WriteLine("Post Liked!");
                                    Console.WriteLine("Like Count: " + postToLike.LikeCount);

                                    admin.Notifications.Add(new Notification("Post Liked", $"User {user.UserName} liked post {likePostId}"));
                                }
                                else
                                {
                                    Console.WriteLine("Post not found.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input for post ID.");
                            }
                            break;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }


        }
    }
}
