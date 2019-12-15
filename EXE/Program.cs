using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PL;
using BLL;


namespace DLL
{
    class Program
    {
        static void Main(string[] args)
        {
            User actual = new User("Vasya", "Pupkin", "100A");
            User result = new User("Vasya", "Pupkin", "100A");
            Book book2 = new Book("Shvarts", "Nevsky");
            Book book = new Book("NameEveryoneVasyaPupkin", "Lector");
            List<Book> s1 = new List<Book>();
            List<Book> s2 = new List<Book>();
            
            bool check = actual.Equals(result);
            
            Menu NewMenu = new Menu();

            NewMenu.Open();
        }
    }
}
