using System;

namespace LibraryManagementSystem
{
    public class Book : LibraryItem                                 // Inheriting from LibraryItem
    {
        public string Genre { get; set; } = "";                     // New property for Book class to represent the genre of the book

        public Book() { }

        public Book(int id, string title, string author, int year, string genre)
            : base(id, title, author, year)
        {
            Genre = genre;
        }

        // Override DisplaysInfo() method and it also adds the Genre to it.
        public override void DisplayInfo()
        {
            Console.WriteLine($"[Book] ID: {Id}, Title: {Title}, Author: {Author}, Year: {Year}, Genre: {Genre}");
        }

        // Override ToDataString() method to include the Genre in the string representation of the Book object
        public override string ToDataString()
        {
            return ($"{Id}|{Title}|{Author}|{Year}|Book|{Genre}");
        }
    }
}