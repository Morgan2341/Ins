using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PostNamespace;

namespace AdminNamespace
{
    public class Admin
    {
        public string id;
        public string username;
        public string email;
        public string password;
        List<Post> posts = new List<Post>();
        public List<Notification> Notifications = new List<Notification>();
    }

    public class Notification
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; }

        public Notification(string title, string message)
        {
            Title = title;
            Message = message;
            Timestamp = DateTime.Now;
        }

        public void Display()
        {
            Console.WriteLine("Title: " + Title);
            Console.WriteLine("Message: " + Message);
            Console.WriteLine("Timestamp: " + Timestamp);
            Console.WriteLine();
        }
    }
}