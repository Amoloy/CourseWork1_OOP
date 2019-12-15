using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    [Serializable]
    public class User : IUser
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Academic_Group { get; private set; }

        public List<Book> Taken_Books = new List<Book>();


        public User()
        {
            Name = "NoName";
            Surname = "NoSurname";
            Academic_Group = "000O";
        }

        public User(string Name, string Surname, string Academic_Group)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Academic_Group = Academic_Group;
        }

        public User(User smb)
        {
            Name = smb.Name;
            Surname = smb.Surname;
            Academic_Group = smb.Academic_Group;
        }

        //---------------------------------------------------

        public void ReturnBook(int index)
        {
            Taken_Books[index].KeeperOfBook = null;
            Taken_Books[index].Taken = false;
            Taken_Books[index] = null;
            Taken_Books.RemoveAt(index);
        }

        public void ChangeName(string New_Name)
        {
            Name = New_Name;
        }



        public void ChangeSurname(string New_Surname)
        {
            Surname = New_Surname;
        }

        public void ChangeAcademic_Group(string New_Academic_Group)
        {
            Academic_Group = New_Academic_Group;
        }

        public void ChangeAll(string New_Name, string New_Surname, string New_Academic_Group)
        {
            Name = New_Name;
            Surname = New_Surname;
            Academic_Group = New_Academic_Group;
        }

        public void ChangeAll(User user)
        {
            Name = user.Name;
            Surname = user.Surname;
            Academic_Group = user.Academic_Group;
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
                User CheckingUser = (User)obj;

                if(Name == CheckingUser.Name && Surname == CheckingUser.Surname && Academic_Group == CheckingUser.Academic_Group)
                {
                    if(Taken_Books.Count == 0 && CheckingUser.Taken_Books.Count == 0)
                    {
                        return true;
                    }
                    else if (Taken_Books.SequenceEqual(CheckingUser.Taken_Books))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        //--------------------------------------------------------

        internal class NameComparer : IComparer<User>
        {
            public int Compare(User user1, User user2)
            {
                return user1.Name.CompareTo(user2.Name);
            }
        }

        internal class SurnameComparer : IComparer<User>
        {
            public int Compare(User user1, User user2)
            {
                return user1.Surname.CompareTo(user2.Surname);
            }
        }

        internal class Academic_GroupComparer : IComparer<User>
        {
            public int Compare(User user1, User user2)
            {
                int i = 0;
                while (true)
                {
                    if (user1.Academic_Group[i] > user2.Academic_Group[i])
                    {
                        return 1;
                    }

                    else if (user1.Academic_Group[i] < user2.Academic_Group[i])
                    {
                        return -1;
                    }

                    else if (i == 3)
                    {
                        return 0;
                    }

                }
            }
        }


    }

    

}
