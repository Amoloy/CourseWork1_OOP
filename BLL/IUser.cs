using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    interface IUser
    {
        void ChangeName(string New_Name);

        void ChangeSurname(string New_Surname);

        void ChangeAcademic_Group(string New_Academic_Group);

        void ChangeAll(string New_Name, string New_Surname, string New_Academic_Group);

    }
}
