// BASE CLASS
// Book & Magazine classes inherit from LibraryItem

using System;

namespace LibraryManagementSystem
{
    public class LibraryItem
    {
        // Representing Auto-Implemented properties
        public int Id { get; set; }
        public string Title { get; set; } = "";                     // Default values are used for strings to avoid null reference issues
        public string Author { get; set; } = "";                    // Default values are used for strings to avoid null reference issues
        public int Year { get; set; }

        public LibraryItem() { }

        public LibraryItem(int id, string title, string author, int year)
        {
            Id = id;
            Title = title;
            Author = author;
            Year = year;
        }

        // To Display library item information  ---  Marked as virtual so that it can be overridden in derived classes (i.e. Books can add 'Genre')
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"ID: {Id}, Title: {Title}, Author: {Author}, Year: {Year}");
        }

        // Converts the LibraryItem into a text format for saving a file  ---  Marked as virtual so that it can be overridden in derived classes ('Genre', 'IssueNumber')
        public virtual string ToDataString()
        {
            return ($"{Id}|{Title}|{Author}|{Year}|LibraryItem|");
        }

        // When the app starts again, you need to load those saved items back into memory. But the data is just a line of text —
        // so you need to parse it and reconstruct the correct object type. That's where this functiion was used.

        public static LibraryItem FromDataString(string line)
        {
            // Step - 1: Split the string
            var parts = line.Split('|');                            // Splits the saved string into parts using the '|' character

            // Step - 2: Parse common fields
            int id = int.Parse(parts[0]);
            string title = parts[1];
            string author = parts[2];
            int year = int.Parse(parts[3]);
            
            // Step - 3: Check the item type (Book, Magazine, etc.) // Based on type, the method decides what kind of object to create
            string type = parts[4];                                 // Extracts the type of item
            string extra = parts.Length > 5 ? parts[5] : "";        // If the condition is true, it extracts the extra information (like Genre or IssueNumber), otherwise it sets it to an empty string


            if (type == "Book")
            {
                return new Book(id, title, author, year, extra);    // If book, then extra is the Genre
            }
            else if (type == "Magazine")
            {
                int issueNumber = int.TryParse(extra, out int n) ? n : 0;       // If magazine, then extra is the IssueNumber, and it tries to parse it to an integer
                return new Magazine(id, title, author, year, issueNumber);
            }
            else
            {
                return new LibraryItem(id, title, author, year);
            }
        }
    }
}

// TryParse() - Converts the string to number if possible.