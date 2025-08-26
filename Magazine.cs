using System;

namespace LibraryManagementSystem
{
    public class Magazine : LibraryItem                             // Inheriting from LibraryItem
    {
        public int IssueNumber { get; set; }                        // New property for Magazine class to represent the issue number of the magazine

        public Magazine() { }

        public Magazine(int id, string title, string author, int year, int issueNumber)
            : base(id, title, author, year)
        {
            IssueNumber = issueNumber;
        }

        // Override DisplaysInfo() method and it also adds the IssueNumber to it.
        public override void DisplayInfo()
        {
            Console.WriteLine($"[Magazine] ID: {Id}, Title: {Title}, Author: {Author}, Year: {Year}, Issue#: {IssueNumber}");
        }

        // Override ToDataString() method to include the IssueNumber in the string representation of the Magazine object
        public override string ToDataString()
        {
            return $"{Id}|{Title}|{Author}|{Year}|Magazine|{IssueNumber}";
        }
    }
}