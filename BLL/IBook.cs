using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    interface IBook
    {
        void ChangeName(string New_Name);

        void ChangeAuthor(string New_Author);

        void ChangeAll(string New_Name, string New_Author);
    }
}
