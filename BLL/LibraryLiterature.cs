using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class LibraryLiterature : ILibraryList<Book>
    {
        private List<Book> books;

        public int Length
        {
            get
            {
                return books.Count;
            }
        }

        public LibraryLiterature()
        {
            books = (List<Book>)DataBase.BooksDeserialize();
        }

        //-------------------------------------------------------------

        public Book this[int index]
        {
            get
            {
                return books[index];
            }

            set
            {
                books[index] = value;
            }
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
                LibraryLiterature CheckingList = (LibraryLiterature)obj;

                if (books.SequenceEqual(CheckingList.books))
                {
                    return true;
                }
                return false;
            }
        }

        public void Add(Book book)
        {
            books.Add(book);
        }

        public void Clear()
        {
            books.Clear();
        }

        public void Remove(Book book)
        {
            books.Remove(book);
        }

        public void RemoveAt(int index)
        {
            books.RemoveAt(index);
        }

        public void ReplaceAt(int index, Book book)
        {
            books[index].ChangeAll(book);
        }

        public List<Book> FindByKeyWord(string key)
        {
            List<Book> result = new List<Book>();
            for (int i = 0; i < books.Count; i++)
            {
                if (HasFragment(key, i))
                {
                    result.Add(books[i]);
                }
            }

            return result;
        }

        private bool HasFragment(string fragment, int index)
        {
            if (fragment.Length > books[index].Name.Length && fragment.Length > books[index].Author.Length)
            {
                return false;
            }

            if (fragment.Length < books[index].Name.Length)
            {
                if (books[index].Name.IndexOf(fragment) > -1)
                {
                    return true;
                }
            }

            if (books[index].Author.IndexOf(fragment) > -1)
            {
                return true;
            }

            return false;
        }

        public void SortByName()
        {
            books.Sort(new Book.NameComparer());
        }

        public void SortByAuthor()
        {
            books.Sort(new Book.AuthorComparer());
        }

        //-------------------------------------------------------

        public void GetInfo()
        {
            books = (List<Book>)DataBase.BooksDeserialize();
        }

        public void SaveInfo()
        {
            DataBase.BooksSerialize(books);
        }


    }
}
