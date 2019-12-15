using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class LibraryUsers : ILibraryList<User>
    {
        private List<User> users;

        public int Length
        {
            get
            {
                return users.Count;
            }
        }

        public LibraryUsers()
        {
            users = (List<User>)DataBase.UsersDeserialize();
        }

        //---------------------------------------------------------

        public User this[int index]
        {
            get
            {
                return users[index];
            }

            set
            {
                users[index] = value;
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
                LibraryUsers CheckingList = (LibraryUsers)obj;

                if (users.SequenceEqual(CheckingList.users))
                {
                    return true;
                }
                return false;
            }
        }

        public void Add(User user)
        {
            users.Add(user);
        }

        public void Clear()
        {
            users.Clear();
        }

        public void Remove(User user)
        {
            users.Remove(user);
        }

        public void RemoveAt(int index)
        {
            users.RemoveAt(index);
        }

        public void ReplaceAt(int index, User user)
        {
            users[index].ChangeAll(user);
        }

        public List<User> FindByKeyWord(string key)
        {
            List<User> result = new List<User>();
            for (int i = 0; i < users.Count; i++)
            {
                if (HasFragment(key, i))
                {
                    result.Add(users[i]);
                }
            }

            return result;
        }

        private bool HasFragment(string fragment, int index)
        {
            if (fragment.Length > users[index].Name.Length && fragment.Length > users[index].Surname.Length)
            {
                return false;
            }

            if (fragment.Length < users[index].Name.Length)
            {
                if(users[index].Name.IndexOf(fragment) > -1)
                {
                    return true;
                }
            }

            if(users[index].Surname.IndexOf(fragment) > -1)
            {
                return true;
            }

            return false;
        }

        public void SortByName()
        {
            users.Sort(new User.NameComparer());
        }

        public void SortBySurname()
        {
            users.Sort(new User.SurnameComparer());
        }

        public void SortByAcademic_Group()
        {
            users.Sort(new User.Academic_GroupComparer());
        }

        //-----------------------------------------------------------------------

        public void GetInfo()
        {
            users = (List<User>)DataBase.UsersDeserialize();
        }

        public void SaveInfo()
        {
            DataBase.UsersSerialize(users);
        }
    }
}
