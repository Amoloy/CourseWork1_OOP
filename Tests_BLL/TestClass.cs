// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using BLL;

namespace Tests_BLL
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod_User_ChangeName()
        {
            User actual = new User("Vasya", "Pupkin", "100A");
            User result = new User("Sanya", "Pupkin", "100A");

            actual.ChangeName("Sanya");
            
            Assert.AreEqual(result, actual);
        }

        [Test]
        public void TestMethod_User_ChangeSurname()
        {
            User actual = new User("Vasya", "Pupkin", "100A");
            User result = new User("Vasya", "Nevsky", "100A");

            actual.ChangeSurname("Nevsky");

            Assert.AreEqual(result, actual);
        }

        [Test]
        public void TestMethod_User_ChangeAcademic_Group()
        {
            User actual = new User("Vasya", "Pupkin", "100A");
            User result = new User("Vasya", "Pupkin", "103B");

            actual.ChangeAcademic_Group("103B");

            Assert.AreEqual(result, actual);
        }

        [Test]
        public void TestMethod_User_ChangeAll_1()
        {
            User actual = new User("Vasya", "Pupkin", "100A");
            User result = new User("Sanya", "Nevsky", "103B");

            actual.ChangeAll("Sanya", "Nevsky", "103B");

            Assert.AreEqual(result, actual);
        }

        [Test]
        public void TestMethod_User_ChangeAll_2()
        {
            User actual = new User("Vasya", "Pupkin", "100A");
            User result = new User("Sanya", "Nevsky", "103B");

            actual.ChangeAll(result);

            Assert.AreEqual(result, actual);
        }

        [Test]
        public void TestMethod_User_ReturnBook()
        {
            User actual = new User("Vasya", "Pupkin", "100A");
            User result = new User(actual);
            Book book = new Book("NameEveryoneVasyaPupkin", "Lector");
            actual.Taken_Books.Add(book);

            actual.ReturnBook(0);

            Assert.AreEqual(result, actual);

            //--------------------------------------

            Book book2 = new Book("Shvarts", "Nevsky");
            actual.Taken_Books.Add(book);
            actual.Taken_Books.Add(book2);
            result.Taken_Books.Add(book2);

            actual.ReturnBook(0);

            Assert.AreEqual(result, actual);
        }

        //-----------------------------------------Book------------------------------------------

        [Test]
        public void TestMethod_Book_ChangeName()
        {
            Book actual = new Book("Black", "Pupkin");
            Book result = new Book("White", "Pupkin");

            actual.ChangeName("White");

            Assert.AreEqual(result, actual);
        }

        [Test]
        public void TestMethod_Book_ChangeAuthor()
        {
            Book actual = new Book("Black", "Pupkin");
            Book result = new Book("Black", "Nevsky");

            actual.ChangeAuthor("Nevsky");

            Assert.AreEqual(result, actual);
        }

        [Test]
        public void TestMethod_Book_ChangeAll_1()
        {
            Book actual = new Book("Black", "Pupkin");
            Book result = new Book("White", "Nevsky");

            actual.ChangeAll("White", "Nevsky");

            Assert.AreEqual(result, actual);
        }

        [Test]
        public void TestMethod_Book_ChangeAll_2()
        {
            Book actual = new Book("Black", "Pupkin");
            Book result = new Book("White", "Nevsky");

            actual.ChangeAll(result);

            Assert.AreEqual(result, actual);
        }

        //---------------------------------------- LibraryUsers ------------------------------------------

        [Test]
        public void TestMethod_LibraryUsers_Length()
        {
            LibraryUsers actual = new LibraryUsers();
            LibraryUsers result = new LibraryUsers();
            User user = new User();
            actual.Clear();
            result.Clear();

            actual.Add(user);
            result.Add(user);

            Assert.AreEqual(result.Length, actual.Length);
        }

        [Test]
        public void TestMethod_LibraryUsers_Remove()
        {
            LibraryUsers actual = new LibraryUsers();
            LibraryUsers result = new LibraryUsers();
            User user = new User();
            actual.Clear();
            result.Clear();
            actual.Add(user);

            actual.Remove(user);

            Assert.AreEqual(result, actual);
        }

        [Test]
        public void TestMethod_LibraryUsers_RemoveAt()
        {
            LibraryUsers actual = new LibraryUsers();
            LibraryUsers result = new LibraryUsers();
            User user = new User();
            actual.Clear();
            result.Clear();
            actual.Add(user);

            actual.RemoveAt(0);

            Assert.AreEqual(result, actual);
        }

        [Test]
        public void TestMethod_LibraryUsers_ReplaceAt()
        {
            LibraryUsers actual = new LibraryUsers();
            LibraryUsers result = new LibraryUsers();
            User user = new User();
            User user2 = new User("Sanya", "Nevsky", "228P");
            actual.Clear();
            result.Clear();
            actual.Add(user);
            result.Add(user2);

            actual.ReplaceAt(0, user2);

            Assert.AreEqual(result, actual);
        }

        [Test]
        public void TestMethod_LibraryUsers_SortByName()
        {
            LibraryUsers actual = new LibraryUsers();
            LibraryUsers result = new LibraryUsers();
            User user1 = new User("A","C","2");
            User user2 = new User("B", "B", "3");
            User user3 = new User("C", "A", "1");
            actual.Clear();
            result.Clear();
            actual.Add(user1);
            actual.Add(user3);
            actual.Add(user2);
            result.Add(user2);
            result.Add(user1);
            result.Add(user3);

            actual.SortByName();
            result.SortByName();

            Assert.AreEqual(result, actual);
        }

        [Test]
        public void TestMethod_LibraryUsers_SortBySurname()
        {
            LibraryUsers actual = new LibraryUsers();
            LibraryUsers result = new LibraryUsers();
            User user1 = new User("A", "C", "2");
            User user2 = new User("B", "B", "3");
            User user3 = new User("C", "A", "1");
            actual.Clear();
            result.Clear();
            actual.Add(user1);
            actual.Add(user3);
            actual.Add(user2);
            result.Add(user2);
            result.Add(user1);
            result.Add(user3);

            actual.SortBySurname();
            result.SortBySurname();

            Assert.AreEqual(result, actual);
        }

        [Test]
        public void TestMethod_LibraryUsers_SortByAcademic_Group()
        {
            LibraryUsers actual = new LibraryUsers();
            LibraryUsers result = new LibraryUsers();
            User user1 = new User("A", "C", "2");
            User user2 = new User("B", "B", "3");
            User user3 = new User("C", "A", "1");
            actual.Clear();
            result.Clear();
            actual.Add(user1);
            actual.Add(user3);
            actual.Add(user2);
            result.Add(user2);
            result.Add(user1);
            result.Add(user3);

            actual.SortByAcademic_Group();
            result.SortByAcademic_Group();

            Assert.AreEqual(result, actual);
        }

        [Test]
        public void TestMethod_LibraryUsers_get()
        {
            LibraryUsers somelist = new LibraryUsers();
            User result = new User("A", "C", "2");
            User actual;
            somelist.Clear();
            somelist.Add(result);

            actual = somelist[0];

            Assert.AreEqual(result, actual);
        }

        [Test]
        public void TestMethod_LibraryUsers_set()
        {
            LibraryUsers actual = new LibraryUsers();
            LibraryUsers result = new LibraryUsers();
            User user1 = new User("A", "C", "2");
            actual.Clear();
            result.Clear();
            actual.Add(new User());
            result.Add(user1);

            actual[0] = result[0];

            Assert.AreEqual(result, actual);
        }

        //---------------------------------------- LibraryLiterature ------------------------------------------

        [Test]
        public void TestMethod_LibraryLiterature_Length()
        {
            LibraryLiterature actual = new LibraryLiterature();
            LibraryLiterature result = new LibraryLiterature();
            Book book = new Book();
            actual.Clear();
            result.Clear();

            actual.Add(book);
            result.Add(book);

            Assert.AreEqual(result.Length, actual.Length);
        }

        [Test]
        public void TestMethod_LibraryLiterature_Remove()
        {
            LibraryLiterature actual = new LibraryLiterature();
            LibraryLiterature result = new LibraryLiterature();
            Book book = new Book();
            actual.Clear();
            result.Clear();
            actual.Add(book);

            actual.Remove(book);

            Assert.AreEqual(result, actual);
        }

        [Test]
        public void TestMethod_LibraryLiterature_RemoveAt()
        {
            LibraryLiterature actual = new LibraryLiterature();
            LibraryLiterature result = new LibraryLiterature();
            Book book = new Book();
            actual.Clear();
            result.Clear();
            actual.Add(book);

            actual.RemoveAt(0);

            Assert.AreEqual(result, actual);
        }

        [Test]
        public void TestMethod_LibraryLiterature_ReplaceAt()
        {
            LibraryLiterature actual = new LibraryLiterature();
            LibraryLiterature result = new LibraryLiterature();
            Book book = new Book();
            Book book2 = new Book("Sanya", "Nevsky");
            actual.Clear();
            result.Clear();
            actual.Add(book);
            result.Add(book2);

            actual.ReplaceAt(0, book2);

            Assert.AreEqual(result, actual);
        }

        [Test]
        public void TestMethod_LibraryLiterature_SortByName()
        {
            LibraryLiterature actual = new LibraryLiterature();
            LibraryLiterature result = new LibraryLiterature();
            Book book1 = new Book("A", "C");
            Book book2 = new Book("B", "B");
            Book book3 = new Book("C", "A");
            actual.Clear();
            result.Clear();
            actual.Add(book1);
            actual.Add(book3);
            actual.Add(book2);
            result.Add(book2);
            result.Add(book1);
            result.Add(book3);

            actual.SortByName();
            result.SortByName();

            Assert.AreEqual(result, actual);
        }

        [Test]
        public void TestMethod_LibraryLiterature_SortByAuthor()
        {
            LibraryLiterature actual = new LibraryLiterature();
            LibraryLiterature result = new LibraryLiterature();
            Book book1 = new Book("A", "C");
            Book book2 = new Book("B", "B");
            Book book3 = new Book("C", "A");
            actual.Clear();
            result.Clear();
            actual.Add(book1);
            actual.Add(book3);
            actual.Add(book2);
            result.Add(book2);
            result.Add(book1);
            result.Add(book3);

            actual.SortByAuthor();
            result.SortByAuthor();

            Assert.AreEqual(result, actual);
        }

        [Test]
        public void TestMethod_LibraryLiterature_get()
        {
            LibraryLiterature somelist = new LibraryLiterature();
            Book result = new Book("A", "C");
            Book actual;
            somelist.Clear();
            somelist.Add(result);

            actual = somelist[0];

            Assert.AreEqual(result, actual);
        }

        [Test]
        public void TestMethod_LibraryLiterature_set()
        {
            LibraryLiterature actual = new LibraryLiterature();
            LibraryLiterature result = new LibraryLiterature();
            Book book1 = new Book("A", "C");
            actual.Clear();
            result.Clear();
            actual.Add(new Book());
            result.Add(book1);

            actual[0] = result[0];

            Assert.AreEqual(result, actual);
        }


    }
}
