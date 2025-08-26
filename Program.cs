/*
--------------------------------------------------------------------------------------
                Problem Statement: Library Management Console App 
--------------------------------------------------------------------------------------

Objective:
Design and implement a console-based Library Management System in C#.NET 
that allows a librarian to manage books, magazines, and members.

The application must demonstrate core object-oriented programming (OOP) concepts:
- Inheritance
- Method Overloading
- Method Overriding

It should also use:
- List<T> collections for data storage in memory
- File I/O operations for data persistence between application runs

--------------------------------------------------------------------------------------
Class Requirements:

1. Base Class: LibraryItem  
   - Properties:
     • Id (int)
     • Title (string)
     • Author (string)
     • Year (int)

2. Derived Classes:
   - Book (inherits LibraryItem)
     • Additional Property: Genre (string)
   - Magazine (inherits LibraryItem)
     • Additional Property: IssueNumber (int)

3. Member Class:
   - Properties:
     • MemberId (int)
     • Name (string)
     • Email (string)
--------------------------------------------------------------------------------------
OOP Concepts to Implement:

Method Overloading:
- In the Library class, create overloaded methods:
  • AddItem(Book book)
  • AddItem(Magazine magazine)
  • AddItem(string title, string author, int year, string genre)

Method Overriding:
- Define a virtual method DisplayInfo() in LibraryItem
- Override DisplayInfo() in Book and Magazine to include their specific properties

Collections:
- Use List<LibraryItem> to store all books and magazines
- Use List<Member> to store all registered members

File I/O:
- Save all library items to "items.txt"
- Save all members to "members.txt"
- Load saved data from files when the application starts

--------------------------------------------------------------------------------------
Functionalities to Implement:

1. Add Book  
2. Add Magazine  
3. Register Member  
4. View All Items  
5. View All Members  
6. Search Items by Title or Author  
7. Save & Exit  

--------------------------------------------------------------------------------------
Sample Console Menu:

Library Management System
-------------------------
1. Add Book  
2. Add Magazine  
3. Register Member  
4. View All Items  
5. View All Members  
6. Search Item  
7. Save & Exit  
Enter your choice: 

--------------------------------------------------------------------------------------
*/

using System;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main()
        {
            Library library = new Library();
            library.LoadData();

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\nLibrary Management System");
                Console.WriteLine("-------------------------");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Add Magazine");
                Console.WriteLine("3. Register Member");
                Console.WriteLine("4. View All Items");
                Console.WriteLine("5. View All Members");
                Console.WriteLine("6. Search Item");
                Console.WriteLine("7. Save & Exit");
                Console.Write("Enter your Choice: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Title: ");
                        string? bookTitle = Console.ReadLine() ?? "";
                        Console.Write("Enter Author: ");
                        string? bookAuthor = Console.ReadLine() ?? "";
                        Console.Write("Enter Year: ");
                        int bookYear = int.TryParse(Console.ReadLine(), out int y) ? y : 0;
                        Console.Write("Enter Genre: ");
                        string? bookGenre = Console.ReadLine() ?? "";

                        library.AddItem(bookTitle, bookAuthor, bookYear, bookGenre);
                        break;

                    case "2":
                        Console.Write("Enter Title: ");
                        string? magTitle = Console.ReadLine() ?? "";
                        Console.Write("Enter Author: ");
                        string? magAuthor = Console.ReadLine() ?? "";
                        Console.Write("Enter Year: ");
                        int magYear = int.TryParse(Console.ReadLine(), out int my) ? my : 0;
                        Console.Write("Enter Issue Number: ");
                        int issueNum = int.TryParse(Console.ReadLine(), out int inum) ? inum : 0;

                        Magazine mag = new Magazine(0, magTitle, magAuthor, magYear, issueNum);
                        library.AddItem(mag);
                        break;

                    case "3":
                        Console.Write("Enter Member Name: ");
                        string? memberName = Console.ReadLine() ?? "";
                        Console.Write("Enter Member Email: ");
                        string? memberEmail = Console.ReadLine() ?? "";

                        library.RegisterMember(memberName, memberEmail);
                        break;

                    case "4":
                        library.ViewAllItems();
                        break;

                    case "5":
                        library.ViewAllMembers();
                        break;

                    case "6":
                        Console.Write("Enter search query (title or author): ");
                        string? query = Console.ReadLine() ?? "";
                        library.SearchItems(query);
                        break;

                    case "7":
                        library.SaveData();
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
    }
}

/*
using System;

namespace LibraryManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Library library = new Library();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nLibrary Management System");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Add Magazine");
                Console.WriteLine("3. Register Member");
                Console.WriteLine("4. View All Items");
                Console.WriteLine("5. View All Members");
                Console.WriteLine("6. Search Item");
                Console.WriteLine("7. Save & Exit");
                Console.Write("Enter your choice: ");

                string input = Console.ReadLine();
                Console.WriteLine();

                switch (input)
                {
                    case "1":
                        Console.Write("Enter Title: ");
                        string bookTitle = Console.ReadLine();
                        Console.Write("Enter Author: ");
                        string bookAuthor = Console.ReadLine();
                        Console.Write("Enter Year: ");
                        int bookYear = int.Parse(Console.ReadLine());
                        Console.Write("Enter Genre: ");
                        string genre = Console.ReadLine();
                        library.AddItem(bookTitle, bookAuthor, bookYear, genre); // overloaded method
                        break;

                    case "2":
                        Console.Write("Enter Title: ");
                        string magTitle = Console.ReadLine();
                        Console.Write("Enter Author: ");
                        string magAuthor = Console.ReadLine();
                        Console.Write("Enter Year: ");
                        int magYear = int.Parse(Console.ReadLine());
                        Console.Write("Enter Issue Number: ");
                        string issue = Console.ReadLine();
                        library.AddItem(magTitle, magAuthor, magYear, issue); // overloaded method
                        break;

                    case "3":
                        Console.Write("Enter Member Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter Email: ");
                        string email = Console.ReadLine();
                        library.RegisterMember(name, email);
                        break;

                    case "4":
                        library.ViewAllItems();
                        break;

                    case "5":
                        library.ViewAllMembers();
                        break;

                    case "6":
                        Console.Write("Enter search query (title/author): ");
                        string query = Console.ReadLine();
                        library.SearchItems(query);
                        break;

                    case "7":
                        library.SaveData(); // always flush mode
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }

            Console.WriteLine("Exiting Library Management System.");
        }
    }
}
 */