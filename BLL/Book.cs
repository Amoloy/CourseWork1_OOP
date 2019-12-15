using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    [Serializable]
    public class Book : IBook
    {
        public string Name { get; private set; }
        public string Author { get; private set; }
        public User KeeperOfBook = null;
        public bool Taken = false;

        public Book()
        {
            Name = "NoName";
            Author = "NoName";
        }

        public Book(string Name, string Author)
        {
            this.Name = Name;
            this.Author = Author;
        }

        public Book(Book smth)
        {
            Name = smth.Name;
            Author = smth.Author;
        }

        //--------------------------------------------------

        public void Take(User smb)
        {
            KeeperOfBook = smb;
            smb.Taken_Books.Add(this);
            Taken = true;
        }

        public void ChangeName(string New_Name)
        {
            Name = New_Name;
        }

        public void ChangeAuthor(string New_Author)
        {
            Author = New_Author;
        }

        public void ChangeAll(string New_Name, string New_Author)
        {
            Name = New_Name;
            Author = New_Author;
        }

        public void ChangeAll(Book book)
        {
            Name = book.Name;
            Author = book.Author;
        }

        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Book CheckingBook = (Book)obj;

                if (Name == CheckingBook.Name && Author == CheckingBook.Author)
                {
                    return true;
                }
                return false;
            }
        }

        //--------------------------------------------------

        internal class NameComparer : IComparer<Book>
        {
            public int Compare(Book book1, Book book2)
            {
                return book1.Name.CompareTo(book2.Name);
            }
        }

        internal class AuthorComparer : IComparer<Book>
        {
            public int Compare(Book book1, Book book2)
            {
                return book1.Author.CompareTo(book2.Author);
            }
        }
    }
}
