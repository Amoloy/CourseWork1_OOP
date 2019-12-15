using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace PL
{
    public class Menu
    {
        private LibraryUsers UsersOperations = new LibraryUsers();
        private LibraryLiterature DocumentOperations = new LibraryLiterature();

        private bool Exit;
        private bool Incorrect = false;
        private char ChoosenOperation;

        public void Open()
        {
            Exit = false;
            while (!Exit)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of operation you want to use:");
                Console.WriteLine("1. Operations with users;");
                Console.WriteLine("2. Operations with literature;");
                Console.WriteLine("3. Exit.");

                if (Incorrect)
                {
                    Console.WriteLine("Use only showed numbers");
                    Incorrect = false;
                }

                ChoosenOperation = Console.ReadKey().KeyChar;

                if (ChoosenOperation == '1')
                {
                    OperationsWithUsers();
                }

                else if (ChoosenOperation == '2')
                {
                    OperationWithLiterature();
                }

                else if (ChoosenOperation == '3')
                {
                    Exit = true;
                }

                else
                {
                    Incorrect = true;
                }
            }

            UsersOperations.SaveInfo();
            DocumentOperations.SaveInfo();
        }

        //---------------------------------------User start-------------------------------------------

        private void OperationsWithUsers()
        {
            while (!Exit)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of operation you want to use:");
                Console.WriteLine("1. Show the list of users;");
                Console.WriteLine("2. Add new user;");
                Console.WriteLine("3. Remove user;");
                Console.WriteLine("4. Choose user for some operations;");
                Console.WriteLine("5. Sort list by name;");
                Console.WriteLine("6. Sort list by surname;");
                Console.WriteLine("7. Sort list by academic group;");
                Console.WriteLine("8. Search by key word;");
                Console.WriteLine("9. Cancel.");

                if (Incorrect)
                {
                    Console.WriteLine("Use only showed numbers");
                    Incorrect = false;
                }

                ChoosenOperation = Console.ReadKey().KeyChar;

                if (ChoosenOperation == '1')
                {
                    Console.Clear();

                    ShowUsers();

                    Console.WriteLine("Enter anything to continue");
                    ChoosenOperation = Console.ReadKey().KeyChar;
                }

                else if (ChoosenOperation == '2')
                {
                    UserAdd();
                }

                else if (ChoosenOperation == '3')
                {
                    UserRemove();
                }

                else if (ChoosenOperation == '4')
                {
                    ChooseUser();
                }

                else if (ChoosenOperation == '5')
                {
                    UsersOperations.SortByName();
                }

                else if (ChoosenOperation == '6')
                {
                    UsersOperations.SortBySurname();
                }

                else if (ChoosenOperation == '7')
                {
                    UsersOperations.SortByAcademic_Group();
                }

                else if (ChoosenOperation == '8')
                {
                    UserSearch();
                }

                else if (ChoosenOperation == '9')
                {
                    Exit = true;
                }

                else
                {
                    Incorrect = true;
                }
            }

            Exit = false;
        }

        private void UserSearch()
        {
            Console.Clear();
            Console.WriteLine("Write key word:");
            string key = Console.ReadLine();

            List<User> SimilarUsers = UsersOperations.FindByKeyWord(key);

            if(SimilarUsers.Count == 0)
            {
                Console.WriteLine("There is not anybody with such word");
            }

            else
            {
                for(int i = 0; i < SimilarUsers.Count; i++)
                {
                    Console.WriteLine($"{i}. Name: {SimilarUsers[i].Name}, Surname: {SimilarUsers[i].Surname}, Academic group: {SimilarUsers[i].Academic_Group}");
                }
            }
            Console.WriteLine("Enter anything to continue");
            ChoosenOperation = Console.ReadKey().KeyChar;

        }

        private void UserAdd()
        {
            string Name, Surname, Academic_Group;

            do
            {
                Console.Clear();
                Console.WriteLine("Write name(only symbols):");
                Name = Console.ReadLine();

            } while (!CheckOnSymbols(Name));

            do
            {
                Console.Clear();
                Console.WriteLine("Write surname(only symbols):");
                Surname = Console.ReadLine();

            } while (!CheckOnSymbols(Surname));

            do
            {
                Console.Clear();
                Console.WriteLine("Write academic group(format XXXC, X - number, C - symbol):");
                Academic_Group = Console.ReadLine();

            } while (!CheckGroup(Academic_Group));

            UsersOperations.Add(new User(Name, Surname, Academic_Group));
        }

        private void UserRemove()
        {
            string temp;
            bool InvalidInput = false;

            while (true)
            {
                Console.Clear();
                ShowUsers();

                Console.WriteLine();

                if(InvalidInput == true)
                {
                    InvalidInput = false;
                    Console.WriteLine("Invalid input");
                }

                Console.WriteLine("Enter id of user you want to remove or -1 if you want to cancel removing:");

                temp = Console.ReadLine();

                if (CheckOnNumbers(temp) && temp != "")
                {
                    int input = Convert.ToInt32(temp);
                    if (input == -1)
                    {
                        break;
                    }

                    else if (input > UsersOperations.Length - 1 || input < 0)
                    {
                        InvalidInput = true;
                    }

                    else
                    {
                        UsersOperations.RemoveAt(input);
                        break;
                    }
                }

                else
                {
                    InvalidInput = true;
                }
            }

        }

        private void ChooseUser()
        {
            string temp;
            bool InvalidInput = false;

            User ChoosenUser;

            while (true)
            {
                Console.Clear();
                ShowUsers();
                Console.WriteLine();

                if (InvalidInput == true)
                {
                    InvalidInput = false;
                    Console.WriteLine("Invalid input");
                }

                Console.WriteLine("Enter id of user you want to choose or -1 if you want to cancel choosing:");

                temp = Console.ReadLine();

                if (CheckOnNumbers(temp) && temp != "")
                {
                    int input = Convert.ToInt32(temp);

                    if (input == -1)
                    {
                        break;
                    }

                    else if (input > UsersOperations.Length - 1 || input < 0)
                    {
                        InvalidInput = true;
                    }

                    else
                    {
                        ChoosenUser = UsersOperations[input];
                        ActionWithUser(ChoosenUser);
                        break;
                    }
                }

                else
                {
                    InvalidInput = true;
                }
            }
        }

        private void ActionWithUser(User ChoosenUser)
        {
            while (!Exit)
            {
                Console.Clear();
                Console.WriteLine($"Choosen user: Name: {ChoosenUser.Name}, Surname: {ChoosenUser.Surname}, Academic group: {ChoosenUser.Academic_Group}");
                Console.WriteLine();
                Console.WriteLine("Enter the number of operation you want to use:");
                Console.WriteLine("1. Change Name;");
                Console.WriteLine("2. Change Surname;");
                Console.WriteLine("3. Change Academic group;");
                Console.WriteLine("4. Take book;");
                Console.WriteLine("5. Show taken books;");
                Console.WriteLine("6. Exit.");

                if (Incorrect)
                {
                    Console.WriteLine("Use only showed numbers");
                    Incorrect = false;
                }

                ChoosenOperation = Console.ReadKey().KeyChar;

                if (ChoosenOperation == '1')
                {
                    string NewName;

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Write name(only symbols):");
                        NewName = Console.ReadLine();

                    } while (!CheckOnSymbols(NewName));

                    ChoosenUser.ChangeName(NewName);
                }

                else if (ChoosenOperation == '2')
                {
                    string NewSurname;

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Write surname(only symbols):");
                        NewSurname = Console.ReadLine();

                    } while (!CheckOnSymbols(NewSurname));

                    ChoosenUser.ChangeSurname(NewSurname);
                }

                else if (ChoosenOperation == '3')
                {
                    string NewGroup;

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Write academic group(format XXXC, X - number, C - symbol):");
                        NewGroup = Console.ReadLine();

                    } while (!CheckGroup(NewGroup));

                    ChoosenUser.ChangeAcademic_Group(NewGroup);
                }

                else if (ChoosenOperation == '4')
                {
                    string temp;
                    bool InvalidInput = false;

                    if (ChoosenUser.Taken_Books.Count == 4)
                    {
                        Console.WriteLine("User has already 4 book and can`t take new one while don`t return one of taken books");
                    }

                    else
                    {
                        while (true)
                        {
                            Console.Clear();
                            ShowBooks();

                            Console.WriteLine();

                            if (InvalidInput == true)
                            {
                                InvalidInput = false;
                                Console.WriteLine("Invalid input");
                            }

                            Console.WriteLine("Enter id of book you want user to take or -1 if you want to cancel:");

                            temp = Console.ReadLine();

                            if (CheckOnNumbers(temp) && temp != "")
                            {
                                int input = Convert.ToInt32(temp);

                                if (input == -1)
                                {
                                    break;
                                }

                                else if (input > DocumentOperations.Length - 1 || input < 0)
                                {
                                    InvalidInput = true;
                                }

                                else
                                {
                                    DocumentOperations[input].Take(ChoosenUser);
                                    break;
                                }
                            }

                            else
                            {
                                InvalidInput = true;
                            }
                        }
                    }

                    Console.WriteLine("Enter anything to continue");
                    ChoosenOperation = Console.ReadKey().KeyChar;
                }

                else if (ChoosenOperation == '5')
                {
                    Console.Clear();

                    if (ChoosenUser.Taken_Books == null)
                    {
                        Console.WriteLine("List if empty");
                    }

                    else
                    {
                        string temp;
                        bool InvalidInput = false;

                        while (true)
                        {
                            Console.Clear();
                            for (int i = 0; i < ChoosenUser.Taken_Books.Count; i++)
                            {
                                Console.WriteLine($"{i}. Name: {ChoosenUser.Taken_Books[i].Name}, Author: {ChoosenUser.Taken_Books[i].Author}");
                            }

                            Console.WriteLine();

                            if (InvalidInput == true)
                            {
                                InvalidInput = false;
                                Console.WriteLine("Invalid input");
                            }

                            Console.WriteLine("Enter id of book you want user to return or -1 if you want to cancel:");

                            temp = Console.ReadLine();

                            if (CheckOnNumbers(temp) && temp != "")
                            {
                                int input = Convert.ToInt32(temp);

                                if (input == -1)
                                {
                                    break;
                                }

                                else if (input > ChoosenUser.Taken_Books.Count - 1 || input < 0)
                                {
                                    InvalidInput = true;
                                }

                                else
                                {
                                    ChoosenUser.ReturnBook(input);
                                    break;
                                }
                            }

                            else
                            {
                                InvalidInput = true;
                            }
                        }
                        
                    }

                    Console.WriteLine("Enter anything to continue");
                    ChoosenOperation = Console.ReadKey().KeyChar;
                }

                else if (ChoosenOperation == '6')
                {
                    Exit = true;
                }

                else
                {
                    Incorrect = true;
                }
            }

            Exit = false;
        }

        private void ShowUsers()
        {
            for (int i = 0; i < UsersOperations.Length; i++)
            {
                Console.WriteLine($"{i}. Name: {UsersOperations[i].Name}, Surname: {UsersOperations[i].Surname}, Academic group: {UsersOperations[i].Academic_Group}");
            }
        }

        //------------------------------------------------User End---------------------------------------------

        //------------------------------------------------Book Start--------------------------------------------

        private void OperationWithLiterature()
        {
            while (!Exit)
            {
                Console.Clear();
                Console.WriteLine("Enter the number of operation you want to use:");
                Console.WriteLine("1. Show the list of books;");
                Console.WriteLine("2. Add new book;");
                Console.WriteLine("3. Remove book;");
                Console.WriteLine("4. Choose book for some operations;");
                Console.WriteLine("5. Sort list by name;");
                Console.WriteLine("6. Sort list by author;");
                Console.WriteLine("7. Search book with key word;");
                Console.WriteLine("8. Cancel.");

                if (Incorrect)
                {
                    Console.WriteLine("Use only showed numbers");
                    Incorrect = false;
                }

                ChoosenOperation = Console.ReadKey().KeyChar;

                if (ChoosenOperation == '1')
                {
                    Console.Clear();

                    ShowBooks();

                    Console.WriteLine("Enter anything to continue");
                    ChoosenOperation = Console.ReadKey().KeyChar;
                }

                else if (ChoosenOperation == '2')
                {
                    BookAdd();
                }

                else if (ChoosenOperation == '3')
                {
                    BookRemove();
                }

                else if (ChoosenOperation == '4')
                {
                    ChooseBook();
                }

                else if (ChoosenOperation == '5')
                {
                    DocumentOperations.SortByName();
                }

                else if (ChoosenOperation == '6')
                {
                    DocumentOperations.SortByAuthor();
                }

                else if (ChoosenOperation == '7')
                {
                    BookSearch();
                }

                else if (ChoosenOperation == '8')
                {
                    Exit = true;
                }

                else
                {
                    Incorrect = true;
                }
            }

            Exit = false;
        }

        private void BookSearch()
        {
            Console.Clear();
            Console.WriteLine("Write key word:");
            string key = Console.ReadLine();

            List<Book> SimilarBooks = DocumentOperations.FindByKeyWord(key);

            if (SimilarBooks.Count == 0)
            {
                Console.WriteLine("There is not anybody with such word");
            }

            else
            {
                for (int i = 0; i < SimilarBooks.Count; i++)
                {
                    Console.WriteLine($"{i}. Name: {SimilarBooks[i].Name}, Author: {SimilarBooks[i].Author}");
                }
            }
            Console.WriteLine("Enter anything to continue");
            ChoosenOperation = Console.ReadKey().KeyChar;

        }

        private void BookAdd()
        {
            string Name, Author;

            do
            {
                Console.Clear();
                Console.WriteLine("Write name(only symbols):");
                Name = Console.ReadLine();

            } while (!CheckOnSymbols(Name));

            do
            {
                Console.Clear();
                Console.WriteLine("Write name of author(only symbols):");
                Author = Console.ReadLine();

            } while (!CheckOnSymbols(Author));

            DocumentOperations.Add(new Book(Name, Author));
        }

        private void BookRemove()
        {
            string temp;
            bool InvalidInput = false;

            while (true)
            {
                Console.Clear();
                ShowBooks();

                Console.WriteLine();

                if (InvalidInput == true)
                {
                    InvalidInput = false;
                    Console.WriteLine("Invalid input");
                }

                Console.WriteLine("Enter id of book you want to remove or -1 if you want to cancel removing:");

                temp = Console.ReadLine();

                if (CheckOnNumbers(temp) && temp != "")
                {
                    int input = Convert.ToInt32(temp);
                    if (input == -1)
                    {
                        break;
                    }

                    else if (input > DocumentOperations.Length - 1 || input < 0)
                    {
                        InvalidInput = true;
                    }

                    else
                    {
                        DocumentOperations.RemoveAt(input);
                        break;
                    }
                }

                else
                {
                    InvalidInput = true;
                }
            }

        }

        private void ShowBooks()
        {
            for (int i = 0; i < DocumentOperations.Length; i++)
            {
                Console.WriteLine($"{i}. Name: {DocumentOperations[i].Name}, Author: {DocumentOperations[i].Author}");
            }
        }

        private void ChooseBook()
        {
            string temp;
            bool InvalidInput = false;

            Book ChoosenBook;

            while (true)
            {
                Console.Clear();
                ShowBooks();
                Console.WriteLine();

                if (InvalidInput == true)
                {
                    InvalidInput = false;
                    Console.WriteLine("Invalid input");
                }

                Console.WriteLine("Enter id of book you want to choose or -1 if you want to cancel choosing:");

                temp = Console.ReadLine();

                if (CheckOnNumbers(temp) && temp != "")
                {
                    int input = Convert.ToInt32(temp);

                    if (input == -1)
                    {
                        break;
                    }

                    else if (input > DocumentOperations.Length - 1 || input < 0)
                    {
                        InvalidInput = true;
                    }

                    else
                    {
                        ChoosenBook = DocumentOperations[input];
                        ActionWithBook(ChoosenBook);
                        break;
                    }
                }

                else
                {
                    InvalidInput = true;
                }
            }
        }

        private void ActionWithBook(Book ChoosenBook)
        {
            while (!Exit)
            {
                Console.Clear();
                Console.WriteLine($"Choosen book: Name: {ChoosenBook.Name}, Author: {ChoosenBook.Author}");
                Console.WriteLine();
                Console.WriteLine("Enter the number of operation you want to use:");
                Console.WriteLine("1. Change Name;");
                Console.WriteLine("2. Change Author;");
                Console.WriteLine("3. Show the keeper of this book;");
                Console.WriteLine("4. Exit.");

                if (Incorrect)
                {
                    Console.WriteLine("Use only showed numbers");
                    Incorrect = false;
                }

                ChoosenOperation = Console.ReadKey().KeyChar;

                if (ChoosenOperation == '1')
                {
                    string NewName;

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Write name(only symbols):");
                        NewName = Console.ReadLine();

                    } while (!CheckOnSymbols(NewName));

                    ChoosenBook.ChangeName(NewName);
                }

                else if (ChoosenOperation == '2')
                {
                    string NewAuthor;

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Write name of author(only symbols):");
                        NewAuthor = Console.ReadLine();

                    } while (!CheckOnSymbols(NewAuthor));

                    ChoosenBook.ChangeAuthor(NewAuthor);
                }

                else if (ChoosenOperation == '3')
                {
                    if(ChoosenBook.KeeperOfBook == null)
                    {
                        Console.WriteLine("Nobody has taken this book");
                    }

                    else
                    {
                        Console.WriteLine($"Keeper: Name: {ChoosenBook.KeeperOfBook.Name}, Surname: {ChoosenBook.KeeperOfBook.Surname}, Academic group: {ChoosenBook.KeeperOfBook.Academic_Group}");
                    }

                    Console.WriteLine("Enter anything to continue");
                    ChoosenOperation = Console.ReadKey().KeyChar;
                }

                else if (ChoosenOperation == '4')
                {
                    Exit = true;
                }

                else
                {
                    Incorrect = true;
                }
            }

            Exit = false;
        }

        //------------------------------------------------Book End----------------------------------------------

        private bool CheckGroup(string temp)
        {
            if(temp.Length != 4)
            {
                return false;
            }

            for(int i = 0; i < 4; i++)
            {
                if (i == 3 && !(temp[i] >= 'A' && temp[i] <= 'Z'))
                {
                    return false;
                }

                else if (i != 3 && !(temp[i] >= '0' && temp[i] <= '9'))
                {
                    return false;
                }
            }

            return true;
        }

        private bool CheckOnNumbers(string temp)
        {
            for (int i = 0; i < temp.Length; i++)
            {
                if (!(temp[i] >= '0' && temp[i] <= '9') && temp[i] != '-')
                {
                    return false;
                }
            }
            return true;
        }

        private bool CheckOnSymbols(string temp)
        {
            for (int i = 0; i < temp.Length; i++)
            {
                if (!(temp[i] >= 'a' && temp[i] <= 'z') && !(temp[i] >= 'A' && temp[i] <= 'Z'))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
