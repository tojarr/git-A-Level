using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum Log
    {
        admin
    }
    class Program
    {
        static void Main(string[] args)
        {
            bool usname = true;
            int numUs = 1;
            // Creat library shelf
            Console.Write("Enter number for creat a library shelf:");
            int ShelfSize = int.Parse(Console.ReadLine());
            string[] LibShelf = new string[ShelfSize];
            for (int i = 0; i < LibShelf.Length; i++)
            {
                LibShelf[i] = "Book" + (i + 1);
            }
            // Array user
            string[] arrBase = new string[2];
            arrBase[0] = "admin";
            arrBase[1] = "user";
            while (true)
            {
                Console.Clear();
                Console.WriteLine("--- MAIN MENU ---");
                Console.WriteLine();
                Console.WriteLine("Enter 1 for admin menu.");
                Console.WriteLine("Enter 2 for user menu.");
                Console.WriteLine("Enter 3 for add user.");
                Console.WriteLine("Enter 4 for quit.");
                Console.WriteLine();
                Console.Write("Enter:");
                string numlog = Console.ReadLine();
                string login = "";
                if (numlog == "1")
                {
                    Console.Write("Enter login:");
                    login = Console.ReadLine();
                    if (login != Convert.ToString(Log.admin))
                    {
                        IncNum(usname);
                    }
                    else
                    {
                        Console.Clear();
                        AdminMet(LibShelf, ShelfSize, login, usname);
                    }
                }
                else if (numlog == "2")
                {
                    Console.Write("Enter login:");
                    login = Console.ReadLine();
                    bool logTrue = false;
                    for (int i = 0; i < arrBase.Length; i++)
                    {
                        if (login == arrBase[i])
                        {
                            Console.Clear();
                            numUs = i;
                            UserMet(LibShelf, ShelfSize, login, usname, numUs);
                            logTrue = true;
                            break;
                        }
                    }
                    if (logTrue != true)
                    {
                        usname = false;
                        IncNum(usname);
                        usname = true;
                    }
                }
                else if (numlog == "3")
                {
                    string[] arrBase1 = new string[arrBase.Length + 1];
                    AddUser(arrBase, arrBase1);
                    arrBase = arrBase1;
                    Console.WriteLine("Enter name new user");
                    arrBase[arrBase.Length - 1] = Console.ReadLine();
                    for (int i = 0; i < arrBase.Length; i++)
                    {
                        Console.WriteLine(arrBase[i]);
                    }
                }
                else if (numlog == "4")
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    IncNum(usname);
                }
            }
        }
        //Methods
        //Admin
        static void AdminMet(string[] libshelf, int LSsize, string login, bool usname)
        {
            while (true)
            {
                //Menu admin
                Console.Clear();
                Console.WriteLine("--- ADMIN MENU ---");
                Console.WriteLine();
                Console.WriteLine("1 - Delete book.");
                Console.WriteLine("2 - Add book.");
                Console.WriteLine("3 - List of books.");
                Console.WriteLine("4 - Quit to main menu.");
                Console.WriteLine();
                Console.Write("Enter:");
                string DelAdd = Console.ReadLine();
                // Goto Delete
                if (DelAdd == "1")
                {
                    DelBook(libshelf, LSsize, login, usname);
                }
                // Goto Add
                else if (DelAdd == "2")
                {
                    AddBook(libshelf, LSsize, login, usname);
                }
                //List of books
                else if (DelAdd == "3")
                {
                    PrintLib(libshelf, LSsize, login);
                    Console.WriteLine();
                    Console.Write("Press any key to admin menu.");
                    Console.ReadKey();
                }
                // Quit
                else if (DelAdd == "4")
                {
                    Console.Clear();
                    break;
                }
                //Goto Begin
                else
                {
                    IncNum(usname);
                }
            }

        }
        //User
        static void UserMet(string[] libshelf, int ShelfSize, string login, bool usname, int numUs)
        {
            while (true)
            {
                // Menu user
                Console.Clear();
                Console.WriteLine("--- USER MENU ---");
                Console.WriteLine();
                Console.WriteLine("1 - Take a book.");
                Console.WriteLine("2 - List of books.");
                Console.WriteLine("3 - Quit to main menu.");
                Console.WriteLine();
                Console.Write("Enter:");
                string TakeRet = Console.ReadLine();
                // Goto Take a book
                if (TakeRet == "1")
                {
                    TakeBook(libshelf, ShelfSize, login, usname);
                }
                // List of books
                else if (TakeRet == "2")
                {
                    PrintLib(libshelf, ShelfSize, login);
                    Console.WriteLine();
                    Console.Write("Press any key to user menu.");
                    Console.ReadKey();
                }
                // Quit
                else if (TakeRet == "3")
                {
                    Console.Clear();
                    break;
                }
                // Goto Begin
                else
                {
                    IncNum(usname);
                }
            }
        }
        //LibShelf Print
        static void PrintLib(string[] libshelf, int ShelfSize, string login)
        {
            Console.Clear();
            Console.WriteLine("--- LIST OF BOOKS ---");
            Console.WriteLine();
            for (int i = 0; i < ShelfSize; i++)
            {
                if (libshelf[i] == "Book is taken" & login != "admin")
                {
                    continue;
                }
                else if (libshelf[i] == "Empty" & login != "admin")
                {
                    continue;
                }
                Console.WriteLine((i + 1) + " - " + libshelf[i]);
            }
        }
        // Add Book
        static void AddBook(string[] libshelf, int ShelfSize, string login, bool usname)
        {
            while (true)
            {
                string s = "";
                int NumBook;
                PrintLib(libshelf, ShelfSize, login);
                while (true)
                {
                    while (true)
                    {
                        Console.Write("Enter number for add book:");
                        s = Console.ReadLine();
                        bool res = Int32.TryParse(s, out NumBook);
                        if (res)
                        {
                            if (NumBook > 0 & NumBook <= ShelfSize)
                            {
                                break;
                            }
                            else
                            {
                                IncNum(usname);
                                PrintLib(libshelf, ShelfSize, login);
                            }
                        }
                        else
                        {
                            IncNum(usname);
                            PrintLib(libshelf, ShelfSize, login);
                        }
                    }

                    if (libshelf[NumBook - 1] == "Empty")
                    {
                        Console.Write("Enter a book:");
                        string book = Console.ReadLine();
                        libshelf[NumBook - 1] = book;
                        PrintLib(libshelf, ShelfSize, login);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Number is full.");
                        break;
                    }
                }
                Console.Write("Quit to admin menu y/n:");
                string quit = Console.ReadLine();
                if (quit == "y")
                {
                    Console.Clear();
                    break;
                }
            }
        }
        // Delete book
        static void DelBook(string[] libshelf, int ShelfSize, string login, bool usname)
        {
            while (true)
            {
                string s = "";
                int NumBook;
                PrintLib(libshelf, ShelfSize, login);
                while (true)
                {
                    while (true)
                    {
                        Console.Write("Enter number for delete book:");
                        s = Console.ReadLine();
                        bool res = Int32.TryParse(s, out NumBook);
                        if (res)
                        {
                            if (NumBook > 0 & NumBook <= ShelfSize)
                            {
                                break;
                            }
                            else
                            {
                                IncNum(usname);
                                PrintLib(libshelf, ShelfSize, login);
                            }
                        }
                        else
                        {
                            IncNum(usname);
                            PrintLib(libshelf, ShelfSize, login);
                        }
                    }
                    if (libshelf[NumBook - 1] != "Empty" & libshelf[NumBook - 1] != "Book is taken")
                    {
                        libshelf[NumBook - 1] = "Empty";
                        PrintLib(libshelf, ShelfSize, login);
                        break;
                    }
                    else if (libshelf[NumBook - 1] == "Empty")
                    {
                        Console.WriteLine("Number is empty");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Book is taken");
                        break;
                    }
                }
                Console.Write("Quit to admin menu y/n:");
                string quit = Console.ReadLine();
                if (quit == "y")
                {
                    Console.Clear();
                    break;
                }
            }
        }
        // Take book
        static void TakeBook(string[] libshelf, int ShelfSize, string login, bool usname)
        {
            while (true)
            {
                string s = "";
                int NumBook;
                while (true)
                {
                    PrintLib(libshelf, ShelfSize, login);
                    Console.Write("Enter number of book to take:");
                    s = Console.ReadLine();
                    bool res = Int32.TryParse(s, out NumBook);
                    if (res)
                    {
                        if (NumBook > 0 | NumBook < ShelfSize)
                        {
                            break;
                        }
                        else
                        {
                            IncNum(usname);
                        }
                    }
                    else
                    {
                        IncNum(usname);
                    }
                }
                if (libshelf[NumBook - 1] != "Empty")
                {
                    libshelf[NumBook - 1] = "Book is taken";
                    PrintLib(libshelf, ShelfSize, login);
                }
                else
                {
                    Console.WriteLine("Number is empty");
                    PrintLib(libshelf, ShelfSize, login);
                }
                Console.Write("Quit to user menu y/n:");
                string quit = Console.ReadLine();
                if (quit == "y")
                {
                    Console.Clear();
                    break;
                }
            }
        }
        // Print incorrect
        static void IncNum(bool usname)
        {
            Console.Clear();
            Console.WriteLine("Incorrect input");
            if (usname == false)
            {
                Console.WriteLine("Creat a new user in main menu. ");
            }
            Console.WriteLine("Press any key.");
            Console.ReadKey();
        }
        // Creat New User
        static string[] AddUser(string [] arrBase, string[] arrBase1)
        {
            for (int i = 0; i < arrBase.Length; i++)
            {
                arrBase1[i] = arrBase[i];
            }
            Console.WriteLine("Press any key to main menu");
            Console.ReadKey();
            return arrBase1;
        }
    }
}
