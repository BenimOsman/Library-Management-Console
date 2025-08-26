using System;

namespace LibraryManagementSystem
{
    public class Member
    {
        public int MemberId { get; set; }
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";

        public Member() { }

        public Member(int id, string name, string email)
        {
            MemberId = id;
            Name = name;
            Email = email;
        }

        // Method to display member information
        public void DisplayInfo()
        {
            Console.WriteLine($"ID: {MemberId}, Name: {Name}, Email: {Email}");
        }

        // Converts the Member into a text format for saving to a file
        public string ToDataString()
        {
            return $"{MemberId}|{Name}|{Email}";
        }

        // Optional
        // When the console starts again, you need to load those saved members back into memory.
        public static Member FromDataString(string line)
        {
            var parts = line.Split('|');
            return new Member(int.Parse(parts[0]), parts[1], parts[2]);
        }
    }
}