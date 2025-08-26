using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LibraryManagementSystem
{
    public class Library
    {
        private List<LibraryItem> items = new List<LibraryItem>();              // Stores mixed items (Books and Magazines)
        private List<Member> members = new List<Member>();                      // Stores registered members

        private int nextItemId = 1;                                             // Automatically increments the ID for each new item added
        private int nextMemberId = 1;                                           // Automatically increments the ID for each new member added
        private int nextMagId = 1;                                              // Automatically increments the ID for each new magazine added

        // Method Overloading: By passing different parameters.
        public void AddItem(Book book)                                          // Assigns a unique ID to each book and adds it to the items list
        {
            book.Id = nextItemId++;
            items.Add(book);
            Console.WriteLine("Book added successfully.");
        }

        public void AddItem(Magazine magazine)                                  // Assigns a unique ID to each magazine and adds it to the items list
        {
            magazine.Id = nextItemId++;
            items.Add(magazine);
            Console.WriteLine("Magazine added successfully.");
        }

        // When you don't have a Book
        public void AddItem(string title, string author, int year, string genre)
        {
            Book book = new Book(nextItemId++, title, author, year, genre);
            items.Add(book);
            Console.WriteLine("Book added successfully via overloaded method.");
        }

        // When you don't have a Book
        public void AddItem(string title, string author, int year, int issueNumber)
        {
            Magazine mag = new Magazine(nextMagId++, title, author, year, issueNumber);
            items.Add(mag);
            Console.WriteLine("Magazine added successfully via overloaded method.");
        }

        // Creates a new member with a unique ID 
        public void RegisterMember(string name, string email)
        {
            Member member = new Member(nextMemberId++, name, email);
            members.Add(member);
            Console.WriteLine("Member registered successfully.");
        }

        // Displays all items in the library
        public void ViewAllItems()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("No items in library.");
                return;
            }
            foreach (var item in items)
            {
                item.DisplayInfo();
            }
        }

        // Displays all registered members
        public void ViewAllMembers()
        {
            if (members.Count == 0)
            {
                Console.WriteLine("No registered members.");
                return;
            }
            foreach (var member in members)
            {
                member.DisplayInfo();
            }
        }

        // LINQ Query 
        // Searches for items by title or author
        public void SearchItems(string query)
        {
            var results = items.Where(i =>
                i.Title.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0 ||
                i.Author.IndexOf(query, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            if (results.Count == 0)
            {
                Console.WriteLine("No matching items found.");
                return;
            }

            Console.WriteLine($"Search results for '{query}':");
            foreach (var item in results)
                item.DisplayInfo();
        }

        // Saves the current state of items and members to files
        public void SaveData(bool appendAll = true)
        {
            try
            {
                var itemLines = items.Select(i => i.ToDataString());
                var memberLines = members.Select(m => m.ToDataString());

                if (appendAll)                      // If appendAll is true, it appends to the files
                {
                    File.AppendAllLines("items.txt", itemLines);
                    File.AppendAllLines("members.txt", memberLines);
                }
                else                                // If appendAll is false, it overwrites the files       
                {
                    File.WriteAllLines("items.txt", itemLines);     // overwrites
                    File.WriteAllLines("members.txt", memberLines); // overwrites
                }

                Console.WriteLine("Data saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving data: " + ex.Message);
            }
        }

        /*
        public void SaveData()
        {
            try
            {
                var itemLines = items.Select(i => i.ToDataString());
                File.WriteAllLines("items.txt", itemLines);                                 // Overwrites old file

                var memberLines = members.Select(m => m.ToDataString());
                File.WriteAllLines("members.txt", memberLines);                             // Overwrites old file

                Console.WriteLine("Data saved successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error saving data: " + ex.Message);
            }
        }         
        */


        // Optional
        // LoadData method reads the saved data from files and reconstructs the LibraryItem and Member objects
        public void LoadData()
        {
            try
            {
                // Checks if the 'items.txt' exists
                if (File.Exists("items.txt"))
                {
                    var itemLines = File.ReadAllLines("items.txt");                 // Loads all lines from 'items.txt' into a string[]
                    foreach (var line in itemLines)                                 // Loops through each line in the file
                    {
                        var item = LibraryItem.FromDataString(line);                // Parses each line and creates either a Book or Magazine object
                        items.Add(item);
                        if (item.Id >= nextItemId)                                  // Ensures the nextItemId is always greater than the highest ID in the file
                            nextItemId = item.Id + 1;
                    }
                }

                // Checks if the 'members.txt' exists
                if (File.Exists("members.txt"))
                {
                    var memberLines = File.ReadAllLines("members.txt");             // Loads all lines from 'members.txt' into a string[]
                    foreach (var line in memberLines)                               // Loops through each line in the file
                    {
                        var member = Member.FromDataString(line);
                        members.Add(member);
                        if (member.MemberId >= nextMemberId)                        // Ensures the nextMemberId is always greater than the highest MemberId in the file
                            nextMemberId = member.MemberId + 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading data: " + ex.Message);
            }
        }
    }
}